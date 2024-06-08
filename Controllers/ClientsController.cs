using KolokwiumAPBD.DbContext;
using KolokwiumAPBD.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClientsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}/subscriptions")]
        public async Task<IActionResult> GetClientSubscriptions(int id)
        {
            var client = await _context.Client.Include(c => c.Sales)
                                              .ThenInclude(s => s.IdSubscriptionNavigation)
                                              .Where(c => c.IdClient == id)
                                              .Select(c => new
                                              {
                                                  c.FirstName,
                                                  c.LastName,
                                                  c.Email,
                                                  c.Phone,
                                                  Subscriptions = c.Sales.Select(s => new
                                                  {
                                                      s.IdSubscriptionNavigation.IdSubscription,
                                                      s.IdSubscriptionNavigation.Name,
                                                      TotalPaidAmount = s.IdSubscriptionNavigation.Payments
                                                                         .Where(p => p.IdClient == id)
                                                                         .Sum(p => p.Amount)
                                                  })
                                              })
                                              .FirstOrDefaultAsync();

            if (client == null)
                return NotFound();

            return Ok(client);
        }

        [HttpPost("{clientId}/subscriptions/{subscriptionId}/payments")]
        public async Task<IActionResult> AddPayment(int clientId, int subscriptionId, [FromBody] Payment payment)
        {
            var clientExists = await _context.Client.AnyAsync(c => c.IdClient == clientId);
            var subscriptionExists = await _context.Subscription.AnyAsync(s => s.IdSubscription == subscriptionId);

            if (!clientExists || !subscriptionExists)
                return BadRequest("Client or subscription does not exist.");

            var lastPayment = await _context.Payment.Where(p => p.IdClient == clientId && p.IdSubscription == subscriptionId)
                                                    .OrderByDescending(p => p.Date)
                                                    .FirstOrDefaultAsync();

            if (lastPayment != null && (DateTime.Now - lastPayment.Date).Days < 30)
                return BadRequest("Payment already made for this period.");


            _context.Payment.Add(payment);
            await _context.SaveChangesAsync();

            return Ok(new { payment.IdPayment });
        }
    }
}
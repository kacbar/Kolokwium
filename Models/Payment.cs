namespace KolokwiumAPBD.Models
{
    public class Payment
    {
        public int IdPayment{ get; set; }
        public DateTime Date { get; set; }
        public int IdClient { get; set; }
        public string IdSubscription { get; set; }
        public virtual Client IdClientNavigation { get; set; }
        public virtual Subscription IdSubscriptionNavigation { get; set; }
    }
}

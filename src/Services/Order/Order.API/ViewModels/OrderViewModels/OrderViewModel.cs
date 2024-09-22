using Order.API.InputModels.OrderInputModels;

namespace Order.API.ViewModels.OrderViewModels
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string ShippingAddress { get; set; }
        public string BillingAddress { get; set; }
        public List<OrderItemViewModel> Items { get; set; }
        public string? OrderStatus { get; set; }
        public string? PaymentMethod { get; set; }
        public bool IsPaid { get; set; }
        public DateTime? ShippingDate { get; set; }
    }
}

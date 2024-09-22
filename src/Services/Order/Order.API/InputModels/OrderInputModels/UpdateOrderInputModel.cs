namespace Order.API.InputModels.OrderInputModels
{
    public class UpdateOrderInputModel
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; } 
        public decimal TotalAmount { get; set; } 
        public string ShippingAddress { get; set; } 
        public string BillingAddress { get; set; }
        public List<OrderItemInputModel> Items { get; set; }
        public string? OrderStatus { get; set; } 
        public string? PaymentMethod { get; set; }
        public bool IsPaid { get; set; } 
        public DateTime? ShippingDate { get; set; } 
    }
}

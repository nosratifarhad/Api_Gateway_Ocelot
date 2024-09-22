namespace Order.API.InputModels.OrderInputModels
{
    public class OrderItemInputModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } 
        public int Quantity { get; set; } 
        public decimal UnitPrice { get; set; }
    }
}

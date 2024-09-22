using Product.API.Enums;

namespace Product.API.ViewModels.ProductViewModels
{
    public class ProductViewModel
    {

        public ProductViewModel(
            int productId,
            string productName,
            string productTitle,
            string? productDescription,
            ProductCategory? productCategory,
            string? mainImageName,
            string? mainImageTitle,
            string? mainImageUri,
            ProductColor? color,
            bool isFreeDelivery,
            bool isExisting,
            int? weight)
        {
            ProductId = productId;
            ProductName = productName;
            ProductTitle = productTitle;
            ProductDescription = productDescription;
            ProductCategory = productCategory;
            MainImageName = mainImageName;
            MainImageTitle = mainImageTitle;
            MainImageUri = mainImageUri;
            Color = color;
            IsFreeDelivery = isFreeDelivery;
            IsExisting = isExisting;
            Weight = weight;
        }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductTitle { get; set; }

        public string? ProductDescription { get; set; }

        public ProductCategory? ProductCategory { get; set; }

        public string? MainImageName { get; set; }

        public string? MainImageTitle { get; set; }

        public string? MainImageUri { get; set; }

        public ProductColor? Color { get; set; }

        public bool IsFreeDelivery { get; set; }

        public bool IsExisting { get; set; }

        public int? Weight { get; set; }
    }
}

namespace ProductMicroService.Models.DTOs
{
    public class PaginateProducts
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 5;
    }
    public class ProductPriceFiler
    {
        public float MinPrice { get; set; } =0;
        public float MaxPrice { get; set; } = 0;
    }
    public class ProductStockFilter
    {
        public int MinStock { get; set; } = 0;
        public int MaxStock { get; set; } = 0;
    }
    public class ProductAvailabilityFilter
    {
        public Status Availability { get; set; } = Status.Unavailable;
    }
    public class ProductImageFilter
    {
        public bool IsImageAvailable { get; set; } = false;
    }
    public class ProductsRequestDTO
    {
        public ProductPriceFiler? PriceFilter { get; set; }
        public ProductStockFilter? StockFilter { get; set; }
        public ProductAvailabilityFilter? AvailabilityFilter { get; set; }
        public ProductImageFilter? ImageFilter { get; set; }
        public PaginateProducts? Pagination { get; set; }

        //Sort by price ascending 1, descending -1
        //sort by stock ascending 2, descending -2
        //sort by availability ascending 3
        public int? SortOrder { get; set; }
        public ProductsRequestDTO()
        {
            PriceFilter = new ProductPriceFiler();
            StockFilter = new ProductStockFilter();
            AvailabilityFilter = new ProductAvailabilityFilter();
            ImageFilter = new ProductImageFilter();
            Pagination = new PaginateProducts();
        }
    }
}

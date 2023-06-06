namespace ProniaBB102Web.ViewModels
{
    public class UpdateProductVM
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string SKU { get; set; }
        public int CategoryId { get; set; }

        public List<int> TagIds { get; set; }

        public IFormFile MainPhoto { get; set; }

        public IFormFile HoverPhoto { get; set; }

        public List<IFormFile> Photos { get; set; }

        public List<ProductImageVM> ProductImageVMs { get; set; }

        public List<int> ImagesIds { get; set; }



    }

    public class ProductImageVM
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public bool? IsPrimary { get; set; }
    }
}

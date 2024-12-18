using Microsoft.EntityFrameworkCore;
using ProductMicroService.Contexts;
using ProductMicroService.Interfaces;
using ProductMicroService.Models;
using ProductMicroService.Repositories;

namespace ProductServiceTest
{
    public class ProductRepositoryTest
    {
        IRepository<int, Product> _productRepository;
        ProductContext context;
        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ProductContext>()
                .UseInMemoryDatabase(databaseName: "ProductMicroService")
                .Options;
            context = new ProductContext(options);
            _productRepository = new ProductRepository(context);
        }

        [Test]
        public async Task AddTest()
        {
            // Arrange
            Product product = new Product
            {
                Title = "Test Product",
                PricePerUnit = 100,
                StockAvailable = 10,
                Description = "Test Description",
                ImageUrl = "Test Image Url",
            };
            //Act
            var result = await _productRepository.Add(product);
            //Assert
            Assert.That(result.Title, Is.EqualTo(product.Title));
        }

        [Test]
        public async Task GetAllTest()
        {
            //Arrange
           Product product = new Product
           {
               Title = "Test Product",
               PricePerUnit = 100,
               StockAvailable = 10,
               Description = "Test Description",
               ImageUrl = "Test Image Url",
           };
            await _productRepository.Add(product);
            //Act
            var result = await _productRepository.GetAll();
            //Assert
            Assert.That(result.Count(), Is.EqualTo(1));
        }
        [Test]
        public async Task GetAllExceptionTest()
        {
           Assert.ThrowsAsync<Exception>(() => _productRepository.GetAll());
        }
    }
}
using CarRental.Repository.Models;
using CarRental.WEB.Controllers;
using CarRental.WEB.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CarRental.WEB.Test
{
    public class BrandsControllerTest
    {
        private readonly Mock<IApiService> _mock;
        private readonly BrandsController _brandsController;
        private List<Brand> brands;



        public BrandsControllerTest()
        {
            _mock = new Mock<IApiService>();
            //_brandsController = new BrandsController(_mock.Object);
            /*brands = new List<Brand>() { new Brand { Id = 1, Name = "Kalem", Price = 100, Stock = 50, Color = "Kırmızı" },
            new Brand { Id = 2, Name = "Defter", Price = 200, Stock = 500, Color = "Mavi" }};*/
        }

        [Fact]
        public async void Index_ActionExecutes_ReturnView()
        {
            var result = await _brandsController.Index();
            Assert.IsType<ViewResult>(result);
        }
    }
}

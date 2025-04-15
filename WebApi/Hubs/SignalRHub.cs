using Business.Abstract;
using DataAccess.Concrete.Context;
using Microsoft.AspNetCore.SignalR;

namespace WebApi.Hubs
{
    public class SignalRHub:Hub
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IRestaurantTableService _restaurantTableService;

        public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IRestaurantTableService restaurantTableService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
            _restaurantTableService = restaurantTableService;
        }

        public async Task SendStatistic()
        {
            var count = await _categoryService.CategoryCountAsync();
            await Clients.All.SendAsync("ReceiveCategoryCount", count.Data);

            var count2 = await _productService.ProductCountAsync();
            await Clients.All.SendAsync("ReceiveProductCount", count2.Data);

            var count3 = await _categoryService.ActiveCategoryCountAsync();
            await Clients.All.SendAsync("ReceiveActiveCategoryCount", count3.Data);

            var count4 = await _categoryService.PassiveCategoryCountAsync();
            await Clients.All.SendAsync("ReceivePassiveCategoryCount", count4.Data);

            var count5 = await _categoryService.ProductCountByCategoryNameQəlyanaltılarAsync();
            await Clients.All.SendAsync("ReceiveProductCountByCategoryNameQəlyanaltılar", count5.Data);

            var count6 = await _productService.ProductPriceAvgAsync();
            await Clients.All.SendAsync("ReceiveProductPriceAvg", count6.Data.ToString("0.00") + "₼");

            var count7 = await _productService.ProductNameByMaxPriceAsync();
            await Clients.All.SendAsync("ReceiveProductNameByMaxPrice", count7.Data);

            var count8 = await _productService.ProductNameByMinPriceAsync();
            await Clients.All.SendAsync("ReceiveProductNameByMinPrice", count8.Data);

            var count9 = await _productService.ProductPriceAvgByBurgerAsync();
            await Clients.All.SendAsync("ReceiveProductPriceAvgByBurger", count9.Data.ToString("0.00") + "₼");

            var count10 = await _orderService.TotalOrderCountAsync();
            await Clients.All.SendAsync("ReceiveTotalOrderCount", count10.Data);

            var count11 = await _orderService.TodayTotalPriceAsync();
            await Clients.All.SendAsync("ReceiveTodayTotalPrice", count11.Data.ToString("0.00") + "₼");

            var count12 = await _restaurantTableService.RestaurantTableCountAsync();
            await Clients.All.SendAsync("ReceiveRestaurantTableCount", count12.Data);
        }

        public async Task SendProgress()
        {
            var count = await _orderService.TotalAmountAsync();
            await Clients.All.SendAsync("ReceiveTotalAmount", count.Data.ToString("0.00") + " " + "₼");

            var count2 = await _orderService.TotalOrderCountAsync();
            await Clients.All.SendAsync("ReceiveTotalOrderCount", count2.Data);

            var count3 = await _restaurantTableService.RestaurantTableCountAsync();
            await Clients.All.SendAsync("ReceiveRestaurantTableCount", count3.Data);
        }

    }
}

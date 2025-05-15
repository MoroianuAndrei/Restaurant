using System;
using System.Collections.ObjectModel;
using System.Linq;
using Restaurant.Models.DataTransferLayer;
using Restaurant.Models.EntityLayer.Enums;

namespace Restaurant.Models.BusinessLogicLayer
{
    public static class ReportQueries
    {
        public static ObservableCollection<Tuple<CategoryDTO, decimal>> GetValueOfCategories()
        {
            var categories = CategoryBLL.GetCategories();
            var products = ProductBLL.GetProducts();

            var query = from category in categories
                        join product in products
                            on category.Id equals product.Category.Id
                        group product by category
                        into g
                        select Tuple.Create(g.Key, g.Sum(p => (decimal)p.Price));

            return new ObservableCollection<Tuple<CategoryDTO, decimal>>(query);
        }

        public static ObservableCollection<Tuple<DateOnly, decimal>> GetIncomeForMonth(UserDTO selectedUser, EMonth month)
        {
            var orders = OrderBLL.GetOrders();

            var query = orders
                .Where(order => order.UserId == selectedUser.Id && DateTime.Parse(order.EstimatedDeliveryTime.ToString()).Month == (int)month)
                .GroupBy(order => DateOnly.FromDateTime(DateTime.Parse(order.EstimatedDeliveryTime.ToString())))
                .Select(g => Tuple.Create(g.Key, g.Sum(r => r.TotalAmount)));

            return new ObservableCollection<Tuple<DateOnly, decimal>>(query);
        }

        public static OrderDTO GetMostValuableOrderByDate(DateTime date)
        {
            var orders = OrderBLL.GetOrders();

            var targetDateOnly = date.Date;

            var query = orders
                .Where(order => DateTime.Parse(order.EstimatedDeliveryTime.ToString() ?? string.Empty).Date == targetDateOnly)
                .MaxBy(order => order.TotalAmount);

            return query ?? new OrderDTO();
        }

        public static ProductDTO GetMostSoldProductByCategory(int categoryId)
        {
            var orderItems = OrderItemBLL.GetOrderItems();
            var products = ProductBLL.GetProducts();

            var query = from orderItem in orderItems
                        join product in products
                            on orderItem.ProductId equals product.Id
                        where product.Category.Id == categoryId
                        group orderItem by product into g
                        orderby g.Sum(oi => oi.Quantity) descending
                        select g.Key;

            return query.FirstOrDefault() ?? new ProductDTO();
        }
    }
}
//using System.Collections.ObjectModel;
//using Restaurant.Models.DataTransferLayer;
//using Restaurant.Models.EntityLayer.Enums;

//namespace Restaurant.Models.BusinessLogicLayer;

//public static class ReportQueries
//{
//    public static ObservableCollection<Tuple<CategoryDTO, float>> GetValueOfCategories()
//    {
//        var categories = CategoryBLL.GetCategories();
//        var products = ProductBLL.GetProducts();

//        var query = from category in categories
//                    join product in products
//                        on category.Id equals product.CategoryId
//                    group product by category
//            into g
//                    select Tuple.Create(g.Key, g.Sum(p => p.Price));

//        return new ObservableCollection<Tuple<CategoryDTO, float>>(query);
//    }

//    public static ObservableCollection<Tuple<DateOnly, float>> GetIncomeForMonth(UserDTO selectedUser, EMonth month)
//    {
//        var receipts = OrderBLL.GetOrders();

//        var query = receipts
//            .Where(receipt => receipt.UserId == selectedUser.Id && DateTime.Parse(receipt.IssueDate).Month == (int)month)
//            .GroupBy(receipt => DateOnly.FromDateTime(DateTime.Parse(receipt.IssueDate)))
//            .Select(g => Tuple.Create(g.Key, g.Sum(r => r.AmountReceived ?? 0)));

//        return new ObservableCollection<Tuple<DateOnly, float>>(query);
//    }

//    public static ReceiptDTO GetMostValuableReceiptByDate(DateTime date)
//    {
//        var receipts = ReceiptBLL.GetReceipts();

//        var targetDateOnly = date.Date;

//        var query = receipts
//            .Where(receipt => DateTime.Parse(receipt.IssueDate ?? string.Empty).Date == targetDateOnly)
//            .MaxBy(receipt => receipt.AmountReceived);

//        return query ?? new ReceiptDTO();
//    }
//}
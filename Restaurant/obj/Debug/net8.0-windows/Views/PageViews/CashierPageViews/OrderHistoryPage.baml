   M S B A M L   `   `   `  ����E  ARestaurant, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:Restaurant.Extensions.EnumExtensions$Restaurant.Extensions.EnumExtensions  5      �Hclr-namespace:Restaurant.ViewModels.PageViewModels.CashierPageViewModels:Restaurant.ViewModels.PageViewModels.CashierPageViewModels  5      B    <Restaurant.Views.PageViews.CashierPageViews.OrderHistoryPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      M IWpf.Ui, Version=4.0.0.0, Culture=neutral, PublicKeyToken=11f9f5cc97b3ffd6/ui&http://schemas.lepo.co/wpfui/2022/xaml  5      @enumExt2clr-namespace:Restaurant.Extensions.EnumExtensions  5      dcashierPageViewModelsHclr-namespace:Restaurant.ViewModels.PageViewModels.CashierPageViewModels  5        N� Title$  OrderHistoryPage��5
       � DataContext 5      Z   TRestaurant.ViewModels.PageViewModels.CashierPageViewModels.OrderHistoryPageViewModel  5   
   .��5      ]� .+�5   
   � $	��Top=�5      .+�5        Wpf.Ui.Controls.TextBlock  $��Order History��5      
�������   FontTypography$ Title=�5       �� Padding$ 16 24q�5      5        Wpf.Ui.Controls.DataGrid  5   
   $��
12 0 12 12q�5      $��
4 12 12 12q�5      &   System.Windows.Controls.DataGrid   GridLinesVisibility$	 All=�5         AutoGenerateColumns$ False��5         
IsReadOnly$
 True��5      ��5      �� *
UserOrders+   ColumnHeaderStyle 5      �� 5        �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6   .�5!      �� 	 �� Property	 � ��
 �� Value$
 18(�61   �� 5"      	 � ��$
 0 0 0 1 q�68   �� 5#      	 � ��

 �����64   �� 5$      	 � ��$
 Center=�6A   �� 5%      	 � ��$
 10q�60   �� 5&      	 � ��$

 Bold"�63   5'         	CellStyle 5)      �� 5*      *  $System.Windows.Controls.DataGridCell"  6   .�5+      �� 	 � ��
 5,      �� 5-       �� 
TargetType"  6.   .R�5.   "   � .+�5/   &   �� $��Center=�50   )   $��8q�51   )   52   #   53      55      �� 56      	 � ��$
 16(�61   57         Columns 59      0  *System.Windows.Controls.DataGridTextColumn  5:      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Order Date��5;         Width5	  /System.Windows.Controls.DataGridLengthConverter$
 Auto	 5=      1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 5<      �� *	OrderDate+ �� StringFormat$ {0:yyyy-MM-dd HH:mm}��5=        5>      $ 
Order Code��5?      $
 Auto	 5A       5@      �� *	OrderCode+5A      4  .System.Windows.Controls.DataGridTemplateColumn  5B      $ Items��5C      $ *	 5D         CellTemplate 5E      �� 5F      .R�5G      �� ��6+   �� *
OrderItems+��5H   "   �� 5I   &   .R�5J   *   �� �� 5K   .   �62   �� *
Quantity+ �� 5L   .   $�x��62    �� 5M   .   �62   �� *Name+ �� 5N   .   $�(��62    �� 5O   .   �62   �� *	UnitPrice+$ C�� �� 5P   .   $�)��62   5Q   +   5R   '   5T      5U      5W        5X      $ 	Food Cost��5Y      $
 Auto	 5[       5Z      �� *SubtotalAmount+$ C��5[        5\      $ Shipping Cost��5]      $
 Auto	 5_       5^      �� *ShippingCost+$ C��5_        5`      $ 
Total Cost��5a      $
 Auto	 5c       5b      �� *TotalAmount+$ C��5c        5d      $ Est. Delivery Time��5e      $
 Auto	 5g       5f      �� *EstimatedDeliveryTime+$ 	{0:HH:mm}��5g        5h      $ Status��5i      $
 Auto	 5k       5j      �� *Status+5k        5l      $ Details��5m      $
 Auto	 5n       5o      �� 5p      .R�5q        Wpf.Ui.Controls.Button  $��View Details��5r   !   $��4q�5s   !      Icon 5t   !   '  !Wpf.Ui.Markup.SymbolIconExtension  *
Search24+��5u   !   �� * DataContext.ViewDetailsCommand+ �� RelativeSource ��  �� AncestorType" N���5v   !   �� 5w      5y      5{      5|      5}      
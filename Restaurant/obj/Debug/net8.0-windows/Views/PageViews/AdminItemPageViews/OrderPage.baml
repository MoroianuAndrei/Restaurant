   M S B A M L   `   `   `  ����E  ARestaurant, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:Restaurant.Extensions.EnumExtensions$Restaurant.Extensions.EnumExtensions  5      �[clr-namespace:Restaurant.ViewModels.PageViewModels.AdminPageViewModels.ObjectPageViewModelsMRestaurant.ViewModels.PageViewModels.AdminPageViewModels.ObjectPageViewModels  5      3    -Restaurant.Views.AdminItemPageViews.OrderPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      M IWpf.Ui, Version=4.0.0.0, Culture=neutral, PublicKeyToken=11f9f5cc97b3ffd6/ui&http://schemas.lepo.co/wpfui/2022/xaml  5      @enumExt2clr-namespace:Restaurant.Extensions.EnumExtensions  5      vobjectPageViewModels[clr-namespace:Restaurant.ViewModels.PageViewModels.AdminPageViewModels.ObjectPageViewModels  5        N� Title$  	OrderPage��5
       � DataContext 5      f   `Restaurant.ViewModels.PageViewModels.AdminPageViewModels.ObjectPageViewModels.OrderPageViewModel  5   
   .��5      ]� .+�5   
   � $	��Top=�5       � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $
��Auto �6#   .+�5        Wpf.Ui.Controls.TextBlock  $��Orders��5      
�������   FontTypography$ Title=�5       �� Padding$ 16 24q�5      �� 5      $��1��6    �� Orientation$ 
Horizontal=�6)   $��Center=�6B   $��0 0 24 0q�6]   .+�5      "  Wpf.Ui.Controls.ToggleSwitch  $��0 0 16 0q�5      $��Active Orders Only��5       d� 	IsChecked 5      �� *ShowActiveOrdersOnly+ �� Mode$ TwoWay=�5       5!        Wpf.Ui.Controls.DataGrid  5#   
   $��
12 0 12 12q�5%      $��
4 12 12 12q�5&      &   System.Windows.Controls.DataGrid   GridLinesVisibility$	 All=�5'      	   AutoGenerateColumns$	 False��5(      
   
IsReadOnly$

 True��5)      ��5$      �� *Orders+   ColumnHeaderStyle 5*      �� 5+       �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6   .�5,      ��  �� Property � �� �� Value$ 18(�61   �� 5-       � ��$ 0 0 0 1 q�68   �� 5.       � ��
 �����64   �� 5/       � ��$ Center=�6A   �� 50       � ��$ 10q�60   �� 51       � ��$
 Bold"�63   52         	CellStyle 54      �� 55      *  $System.Windows.Controls.DataGridCell"  6   .�56      ��  � �� 57      �� 58       �� 
TargetType"  6.   .R�59   "   � .+�5:   &   �� $��Center=�5;   )   $��8q�5<   )   5=   #   5>      5@      �� 5A       � ��$ 16(�61   5B         Columns 5D      0  *System.Windows.Controls.DataGridTextColumn  5E      ,	  &System.Windows.Controls.DataGridColumn 	  Header$ 
Order Date��5F       	  Width5
  /System.Windows.Controls.DataGridLengthConverter$
 Auto
 5H      1  +System.Windows.Controls.DataGridBoundColumn   Binding 5G      �� *	OrderDate+ �� StringFormat$ {0:yyyy-MM-dd HH:mm}��5H        5I      $ 
Order Code��5J      $
 Auto
 5L       5K      �� *	OrderCode+5L      4  .System.Windows.Controls.DataGridTemplateColumn  5M      $ Items��5N      $ *
 5O         CellTemplate 5P      �� 5Q      .R�5R      �� ��6+   �� *
OrderItems+��5S   "   �� 5T   &   .R�5U   *   �� �� 5V   .   �62   �� *
Quantity+ �� 5W   .   $�x��62    �� 5X   .   �62   �� *Name+ �� 5Y   .   $�(��62    �� 5Z   .   �62   �� *	UnitPrice+$ C�� �� 5[   .   $�)��62   5\   +   5]   '   5_      5`      5b        5c      $ 	Food Cost��5d      $
 Auto
 5f       5e      �� *SubtotalAmount+$ C��5f        5g      $ Shipping Cost��5h      $
 Auto
 5j       5i      �� *ShippingCost+$ C��5j        5k      $ 
Total Cost��5l      $
 Auto
 5n       5m      �� *TotalAmount+$ C��5n        5o      $ Est. Delivery Time��5p      $
 Auto
 5r       5q      �� *EstimatedDeliveryTime+$ 	{0:HH:mm}��5r        5s      $ Status��6)   $
 Auto
 69    5t      �� 5u      .R�5v      �� ;   5Restaurant.Extensions.EnumExtensions.EStatusExtension   Statuses#��Z 5w      $	��130��5z      $��Center=�5{       �� SelectedItem 5x      �� *Status+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�{�5y      �� *IsEditableStatus+5{      5|      5~        5      $ Details��5�      $
 Auto
 5�       5�      �� 5�      .R�5�        Wpf.Ui.Controls.Button  $��View Details��5�   !   $��4q�5�   !      Icon 5�   !   '  !Wpf.Ui.Markup.SymbolIconExtension  *
Search24+��5�   !   �� * DataContext.ViewDetailsCommand+ �� RelativeSource ��  �� AncestorType" N���5�   !   �� 5�      5�      5�      5�      5�      
   M S B A M L   `   `   `  ����E  ARestaurant, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Fclr-namespace:Restaurant.ViewModels.PageViewModels.AdminPageViewModels8Restaurant.ViewModels.PageViewModels.AdminPageViewModels  5      ;    5Restaurant.Views.PageViews.AdminPageViews.ReportsPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      M IWpf.Ui, Version=4.0.0.0, Culture=neutral, PublicKeyToken=11f9f5cc97b3ffd6/ui&http://schemas.lepo.co/wpfui/2022/xaml  5      `adminPageViewModelsFclr-namespace:Restaurant.ViewModels.PageViewModels.AdminPageViewModels  5        N� Title$  ReportsPage��5	       � DataContext 5
      S   MRestaurant.ViewModels.PageViewModels.AdminPageViewModels.ReportsPageViewModel  5   
   .��5      ]� .+�5   
     Wpf.Ui.Controls.TextBlock  $	��Top=�5      $��Reports��5         FontTypography$ Title=�5      
�������$��16 24q�5        Wpf.Ui.Controls.Card  5   
   $��8 0 8 8q�5      $��Stretch=�5      $	��Top=�5      .��5      �� .+�5      "  Wpf.Ui.Controls.CardExpander  $��0 0 0 8q�5         Icon 5         Wpf.Ui.Controls.SymbolIcon  5        Wpf.Ui.Controls.FontIcon   FontSize$ 30(�5          Symbol$ Money24=�5!      ��5#      �� 5$      .+�5%        $ 
BodyStrong=�5&   !   $��Sales by Category Report��5'   !     5(         
Appearance$ 	Secondary=�5)   !   $/��)View a list of sales grouped by category.��5*   !   $��WrapWithOverflow=�5+   !   5,      .��5.        .��5/        Wpf.Ui.Controls.DataGrid  $��0 0 8 8q�51      &   System.Windows.Controls.DataGrid   GridLinesVisibility$	 All=�52         AutoGenerateColumns$ False��53      	   
IsReadOnly$
	 True��54      ��50      �� *ValuesByCategoryReport+
   ColumnHeaderStyle
 55      �� 56   "    �� 
TargetType=	  7System.Windows.Controls.Primitives.DataGridColumnHeader" 	 6(   .�57   &   ��  �� Property � �� �� Value$ 18(�6A   �� 58   &    � ��$ 0 0 0 1q�6H   �� 59   &    � ��
 �����6D   �� 5:   &    � ��$ Center=�6Q   �� 5;   &    � ��$ 10q�6@   �� 5<   &    � ��$
 Bold"�6C   5=   #      	CellStyle 5?      �� 5@   "   *
  $System.Windows.Controls.DataGridCell" 
 6(   .�5A   &   ��  � �� 5B   *   �� 5C   .    �� 
TargetType" 
 6>   .R�5D   2   � .+�5E   6   �� $��Center=�5F   9   $��8q�5G   9   5H   3   5I   /   5K   '   �� 5L   &    � ��$ 16(�6A   5M   #      Columns 5O      0  *System.Windows.Controls.DataGridTextColumn  5P   "   ,  &System.Windows.Controls.DataGridColumn   Header$ Category��5Q   %      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 5S   %   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5R   %   �� *Item1.CategoryName+5S   %     5T   "   $ Value��5U   %   $ * 5W   %    5V   %   �� *Item2+5W   %   5Y      5Z      5[        5^      $��0 0 0 8q�5_       5`        5a      $ 30(�5b      $ PersonMoney24=�5c      ��5e      �� 5f      .+�5g        $ 
BodyStrong=�5h   !   $��Sales by Client Report��5i   !     5j      $ 	Secondary=�5k   !   $D��>View a list of sales grouped by cashier for a specific period.��5l   !   $��WrapWithOverflow=�5m   !   5n      .��5p      �� .+�5q        .��5r      ]� .+�5s   "     $
��Left=�5t   %   $��Center=�5u   %   $"��Select a client and a month.��5v   %   �� 5w   "   $��Right=�5x   %    �� Orientation$ 
Horizontal=�5y   %   $��Right=�5z   %   .+�5{   &   �� $	��180��5|   )    �� DisplayMemberPath$ LastName��5~   )   $��0 0 8 0q�5�   )   ��5}   )   �� *	Clients+ �� SelectedItem 5   )   �� *SelectedUser+5�   )   �� 5�   &   $	��180��5�   )   ��5�   )   �� *Months+ 5�   )   �� *SelectedMonth+5�   #   5�      5�        5�      y�5�      �� *IncomeByMonthReportVisibility+.��5�        $��0 0 8 8q�5�   !   $	 All=�5�   !   $ False��5�   !   $
	 True��5�   !   ��5�   !   �� *IncomeByMonthReport+
 5�   "   �� 5�   &   " 	 6,   .�5�   *   ��  � ��$ 18(�6E   �� 5�   *    � ��$ 0 0 0 1q�6L   �� 5�   *    � ��
 �����6H   �� 5�   *    � ��$ Center=�6U   �� 5�   *    � ��$ 10q�6D   �� 5�   *    � ��$
 Bold"�6G   5�   '    5�   "   �� 5�   &   " 
 6,   .�5�   *   ��  � �� 5�   .   �� 5�   2   " 
 6B   .R�5�   6   � .+�5�   :   �� $��Center=�5�   =   $��8q�5�   =   5�   7   5�   3   5�   +   �� 5�   *    � ��$ 16(�6E   5�   '    5�   "     5�   &   $	 Day��5�   )   $ * 5�   )    5�   )   �� *Item1+5�   )     5�   &   $ Value��5�   )   $ * 5�   )    5�   )   �� *Item2+5�   )   5�      5�      5�      5�        5�      $��0 0 0 8q�5�       5�        5�      $ 30(�5�      $ ReceiptMoney24=�5�      ��5�      �� 5�      .+�5�        $ 
BodyStrong=�5�   !   $ ��Most Valuable Order Report��5�   !     5�      $ 	Secondary=�5�   !   $6��0View the most valuable order for a specific day.��5�   !   $��WrapWithOverflow=�5�   !   5�      .��5�      �� .+�5�        .��5�      ]� .+�5�   "     $
��Left=�5�   %   $��Center=�5�   %   $��Select a date.��5�   %   (  "System.Windows.Controls.DatePicker  5�   "   $��Right=�5�   %   $��Right=�5�   %   $	��200��5�   %      SelectedDateFormat$
 Long=�5�   %      SelectedDate 5�   %   �� *SelectedDate+ �� Mode$ TwoWay=�5�      5�        5�      y�5�      �� *MostValuableOrderVisibility+.��5�        $��8 0 8 16q�5�   !   $	��360��5�   !   .��5�   "   �  � ColumnDefinitions 5�   &   �� 5�   *   $��* �6;   �� 5�   *   $
��Auto �6;    � RowDefinitions 5�   &   �� 5�   *   $
��Auto �68   �� 5�   *   $
��Auto �68   �� 5�   *   $
��Auto �68   �� 5�   *   $
��Auto �68   �� 5�   *   $
��Auto �68   .+�5�   &     $��0��5�   )   $��0��5�   )   $��	Order No:��5�   )   $
 Body=�5�   )     5�   &   $��0��5�   )   $��1��5�   )    �� TextAlignment$ Right=�5�   )   $ 
BodyStrong=�5�   )   ��5�   )   �� *MostValuableOrder.OrderCode+5�   )     5�   &   $��1��5�   )   $��0��5�   )   $��Cashier:��5�   )   $
 Body=�5�   )     5�   &   $��1��5�   )   $��1��5�   )   $ Right=�5   )   $ 
BodyStrong=�5  )   ��5�   )   �� *!MostValuableOrder.User.LastName+5  )     5  &   $��2��5  )   $��0��5  )   $��
Issued on:��5  )   $
 Body=�5  )     5  &   $��2��5  )   $��1��5	  )   $ Right=�5  )   $ 
BodyStrong=�5  )   ��5
  )   �� *)'MostValuableOrder.EstimatedDeliveryTime+5  )   �� 5  &   $��3��5  )   $��0��5  )   $��2��5  )   $��16q�5  )   ��5  )   �� *MostValuableOrder.OrderItems+��5  *   �� 5  .   .R�5  2   �  5  6   �� 5  :   $��1* �6K   �� 5  :   $��4* �6K   �� 5  :   $
��Auto �6K    5  6   �� 5  :   $
��Auto �6H   �� 5  :   $
��Auto �6H   .+�5  6     $��0��5   9   $��0��5!  9   $ Right=�5#  9   $��0 0 16 0q�5$  9   $
 Body=�5%  9   ��5"  9   �� *
Quantity+5%  9   �� 5&  6   $��0��5'  9   $��1��5(  9   $��2��5)  9   $ 
Horizontal=�5*  9   .+�5+  :     $
 Body=�5-  =   ��5,  =   �� *Unit+5-  =     5.  :   $��  x  ��5/  =   $
 Body=�50  =     51  :   $
 Body=�53  =   $��0 0 16 0q�54  =   ��52  =   �� *Price+54  =   55  7     56  6   $��1��57  9   $��0��58  9   $��2��59  9   $��0 0 16 0q�5;  9   ��5:  9   �� *Product.Name+5;  9     5<  6   $��1��5=  9   $��2��5>  9   $ Right=�5@  9   ��5?  9   �� *
Subtotal+5@  9   5A  3   5B  /   5D  '     5E  &   $��4��5F  )   $��0��5G  )   $��TOTAL��5H  )   $ 
BodyStrong=�5I  )     5J  &   $��4��5K  )   $��1��5L  )   $ Right=�5N  )   $ 
BodyStrong=�5O  )   ��5M  )   �� *MostValuableOrder.TotalAmount+5O  )   5P  #   5Q     5R     5S     5T       5W     $��0 0 0 8q�5X      5Y       5Z     $ 30(�5[     $ ShoppingBag24=�5\     ��5^     �� 5_     .+�5`       $ 
BodyStrong=�5a  !   $#��Most Sold Product by Category��5b  !     5c     $ 	Secondary=�5d  !   $:��4View the most sold product from a specific category.��5e  !   $��WrapWithOverflow=�5f  !   5g     .��5i     �� .+�5j       .��5k     ]� .+�5l  "     $
��Left=�5m  %   $��Center=�5n  %   $��Select a category.��5o  %   �� 5p  "   $��Right=�5q  %   $��Right=�5r  %   $	��180��5s  %   $ CategoryName��5u  %   ��5t  %   �� *
Categories+ 5v  %   �� *$"SelectedCategoryForMostSoldProduct+5w     5x       5y     y�5z     �� *%#MostSoldProductByCategoryVisibility+.��5{       $��8 0 8 16q�5|  !   $	��360��5}  !   .��5~  "   �  5  &   �� 5�  *   $��* �6;   �� 5�  *   $
��Auto �6;    5�  &   �� 5�  *   $
��Auto �68   �� 5�  *   $
��Auto �68   �� 5�  *   $
��Auto �68   .+�5�  &     $��0��5�  )   $��0��5�  )   $��Product Name:��5�  )   $
 Body=�5�  )     5�  &   $��0��5�  )   $��1��5�  )   $ Right=�5�  )   $ 
BodyStrong=�5�  )   ��5�  )   �� *'%MostSoldProductByCategory.ProductName+5�  )     5�  &   $��1��5�  )   $��0��5�  )   $��Price:��5�  )   $
 Body=�5�  )     5�  &   $��1��5�  )   $��1��5�  )   $ Right=�5�  )   $ 
BodyStrong=�5�  )   ��5�  )   �� *!MostSoldProductByCategory.Price+5�  )   5�  #   5�     5�     5�     5�     5�     5�     5�     5�     
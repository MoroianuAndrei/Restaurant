   M S B A M L   `   `   `  ����E  ARestaurant, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�_clr-namespace:Restaurant.ViewModels.PageViewModels.AdminPageViewModels.ObjectEditPageViewModelsQRestaurant.ViewModels.PageViewModels.AdminPageViewModels.ObjectEditPageViewModels  5      6    0Restaurant.Views.AdminItemEditPages.MenuEditPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      M IWpf.Ui, Version=4.0.0.0, Culture=neutral, PublicKeyToken=11f9f5cc97b3ffd6/ui&http://schemas.lepo.co/wpfui/2022/xaml  5      ~objectEditPageViewModels_clr-namespace:Restaurant.ViewModels.PageViewModels.AdminPageViewModels.ObjectEditPageViewModels  5        N� Title$  MenuEditPage��5	       � DataContext 5
      m   gRestaurant.ViewModels.PageViewModels.AdminPageViewModels.ObjectEditPageViewModels.MenuEditPageViewModel  5   
   .��5      ]� .+�5   
     Wpf.Ui.Controls.TextBlock  $	��Top=�5      
�������   FontTypography$ Title=�5       �� Padding$ 16 24q�5      ��5      �� *Title+5      � 5   
   $��Bottom=�5       � ColumnDefinitions 5      �� 5      $��* �6#   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��Right=�62   .+�5        Wpf.Ui.Controls.Button  $
��Save��5      $	��108��5         
Appearance$ Primary=�5      $��
0 16 16 16q�5       ��5      �� *SaveCommand+��5      ��  �� RelativeSource ��  �� AncestorType" N�5         5!      $��Cancel��5"      $	��108��5%      $��
0 16 16 16q�5&      ��5#      �� *CancelCommand+��5$      ��  �� " N�5&      5'      5(      �� 5)   
   .��5*      �  5+      �� 5,      $
��Auto �6'   $	��108��64   �� 5-      $��* �6'   	 � RowDefinitions	 5/      �� 50      $
��Auto �6$   �� 51      $
��Auto �6$   �� 52      $
��Auto �6$   �� 53      $
��Auto �6$   �� 54      $��* �6$   .+�57        $
��Name��58      $��0��59      $��0��5:      $��14(�5;      
�������$��Center=�5=      $ 8q�5>      $
��16 8q�5?        Wpf.Ui.Controls.TextBox  5@      $��0��5B      $��1��5C      $
��16 8q�5D      ��5A      �� *	Menu.Name+5D        Wpf.Ui.Controls.InfoBar  5E      
   Title$
 Error��5F         Severity$ Error=�5I      $��
16 0 16 16q�5J      $��1��5K      $��1��5L         Message 5G      �� *ErrorMessage+   IsOpen 5H      �� *NameHasError+5L        5N      $��Discount (%)��5O      $��2��5P      $��0��5Q      $��14(�5R      
�������$��Center=�5T      $ 8q�5U      $
��16 8q�5V        5W      $��2��5Y      $��1��5Z      $
��16 8q�5[      ��5X      �� *Menu.Discount+ �� StringFormat$ {0:N2}��5[      � 5]      $��4��5^      $��0��5_      $��2��5`      $��16q�5a      	 5b      �� 5c      $
��Auto �6(   �� 5d      $��* �6(   .+�5g      � $��0��6    5h      �� 5i      $��* �6/   �� 5j      $
��Auto �6/   .+�5l        $��
Menu Items��5m      $ Title=�5n      $��16(�5o      
�������5p        5q      $��Add Product��5r      $��1��5u      $��8 0 0 0q�5v         Icon 5s      '  !Wpf.Ui.Markup.SymbolIconExtension  *Add16+��5t      �� *AddMenuItemCommand+5v      5w        Wpf.Ui.Controls.DataGrid  5y      $��1��5z      &   System.Windows.Controls.DataGrid   AutoGenerateColumns$ False��5|         
IsReadOnly$ False��5}      $��0 8 0 0q�5~      ��5{      �� *Menu.MenuItems+   Columns 5      0	  *System.Windows.Controls.DataGridTextColumn	  5�      ,
  &System.Windows.Controls.DataGridColumn 
  Header$ Product��5�   !    
  Width5  /System.Windows.Controls.DataGridLengthConverter$ * 5�   !   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5�   !   �� *ProductName+	  5�      $ Quantity��5�   !   $
 Auto 5�   !    5�   !   �� *
Quantity+4  .System.Windows.Controls.DataGridTemplateColumn  5�      $ Actions��5�   !   $
 Auto 5�   !      CellTemplate 5�   "   �� 5�   &   .R�5�   *   �� $ 
Horizontal=�65   .+�5�   .     $��Remove��5�   1    5�   1     *
Delete16+��5�   1   �� *#!DataContext.RemoveMenuItemCommand+ �� " N���5�   1   �� 5�   +   5�   '   5�      5�      5�      5�      5�      5�      5�      
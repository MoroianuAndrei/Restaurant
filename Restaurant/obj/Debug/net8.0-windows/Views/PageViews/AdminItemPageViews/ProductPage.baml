   M S B A M L   `   `   `  ����E  ARestaurant, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�[clr-namespace:Restaurant.ViewModels.PageViewModels.AdminPageViewModels.ObjectPageViewModelsMRestaurant.ViewModels.PageViewModels.AdminPageViewModels.ObjectPageViewModels  5      5    /Restaurant.Views.AdminItemPageViews.ProductPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      M IWpf.Ui, Version=4.0.0.0, Culture=neutral, PublicKeyToken=11f9f5cc97b3ffd6/ui&http://schemas.lepo.co/wpfui/2022/xaml  5      vobjectPageViewModels[clr-namespace:Restaurant.ViewModels.PageViewModels.AdminPageViewModels.ObjectPageViewModels  5        N� Title$  ProductPage��5	       � DataContext 5
      h   bRestaurant.ViewModels.PageViewModels.AdminPageViewModels.ObjectPageViewModels.ProductPageViewModel  5   
   .��5      ]� .+�5   
   � $	��Top=�5       � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $
��Auto �6#   .+�5        Wpf.Ui.Controls.TextBlock  $��Products��5      
�������   FontTypography$ Title=�5       �� Padding$ 16 24q�5        Wpf.Ui.Controls.Button  5      -   5        $��AddIconButton��5      $��Add New��5      $��12q�5      $��1��5          Icon 5      '  !Wpf.Ui.Markup.SymbolIconExtension  *Add16+��5      �� *AddNewCommand+��5      ��  �� RelativeSource ��  �� AncestorType" N�5       5!        Wpf.Ui.Controls.DataGrid  5#   
   $��
12 0 12 12q�5%      $��
4 12 12 12q�5&      &   System.Windows.Controls.DataGrid   GridLinesVisibility$	 All=�5'      	   AutoGenerateColumns$	 False��5(      
   
IsReadOnly$

 True��5)      ��5$      �� *
Products+   RowStyle 5*      �� 5+       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6    �� Triggers 5,      �� 5-       �� Binding 6&   �� *
IsLowStock+ �� Value True6E   .a�5.      ��  �� Property � �� �� Value �	#FFF8D7DA6;   �� 50       � ��
 �   �6;   �� 51       � ��$
 Bold"�6;   52      54         ColumnHeaderStyle 56      �� 57      =  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6   .�58      ��  � ��$ 18(�61   �� 59       � ��$ 0 0 0 1 q�68   �� 5:       � ��
 �����64   �� 5;       � ��$ Center=�6A   �� 5<       � ��$ 10q�60   �� 5=       � ��$
 Bold"�63   5>         	CellStyle 5@      �� 5A      *	  $System.Windows.Controls.DataGridCell" 	 6   .�5B      ��  � �� 5C      �� 5D       �� 
TargetType" 	 6.   .R�5E   "   � .+�5F   &   �� $��Center=�5G   )   $��8q�5H   )   5I   #   5J      5L      �� 5M       � ��$ 16(�61   5N         Columns 5P      0
  *System.Windows.Controls.DataGridTextColumn
  5Q      ,  &System.Windows.Controls.DataGridColumn   Header$ Product Name��5R         Width5  /System.Windows.Controls.DataGridLengthConverter$ * 5T      1  +System.Windows.Controls.DataGridBoundColumn   Binding 5S      �� *ProductName+5T      
  5U      $ Portion Quantity��5V      $ * 5X       5W      �� *PortionQuantity+5X      
  5Y      $ Total Quantity��5Z      $ * 5\       5[      �� *TotalQuantity+5\      4  .System.Windows.Controls.DataGridTemplateColumn  5]      $ Actions��5^         CanUserResize$ False��5_         CanUserReorder$ False��5`         CanUserSort$ False��5a      $
 Auto 5b         CellTemplate 5c      �� 5d      .R�5e      ��  �� Orientation$ 
Horizontal=�5f   !   .+�5g   "     $
��Edit��5h   %   $��4q�5i   %    5j   %     *Edit16+��5k   %   �� *DataContext.EditCommand+ �� " N���5l   &   `� 5m   *      BindingConverter `� 	Converter# [  67   .1�5n   .   �� �� 5o   .    66   �� " N�5p   +   5r   #     5s   "   $��Remove��5t   %   $��4q�5u   %    5v   %     *
Delete16+��5w   %   �� *DataContext.RemoveCommand+ �� " N���5x   %   �� 5y      5z      5|      5~      5      5�      
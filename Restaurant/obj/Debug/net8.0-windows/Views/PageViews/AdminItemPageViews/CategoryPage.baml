   M S B A M L   `   `   `  ����E  ARestaurant, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�[clr-namespace:Restaurant.ViewModels.PageViewModels.AdminPageViewModels.ObjectPageViewModelsMRestaurant.ViewModels.PageViewModels.AdminPageViewModels.ObjectPageViewModels  5      6    0Restaurant.Views.AdminItemPageViews.CategoryPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      M IWpf.Ui, Version=4.0.0.0, Culture=neutral, PublicKeyToken=11f9f5cc97b3ffd6/ui&http://schemas.lepo.co/wpfui/2022/xaml  5      vobjectPageViewModels[clr-namespace:Restaurant.ViewModels.PageViewModels.AdminPageViewModels.ObjectPageViewModels  5        � DataContext  5
      i   cRestaurant.ViewModels.PageViewModels.AdminPageViewModels.ObjectPageViewModels.CategoryPageViewModel  5   
   .��5      ]� .+�5   
   � $	��Top=�5       � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $
��Auto �6#   .+�5        Wpf.Ui.Controls.TextBlock  $��
Categories��5      
�������   FontTypography$ Title=�5       �� Padding$ 16 24q�5        Wpf.Ui.Controls.Button  5      -   5        $��AddIconButton��5      $��Add New��5      $��12q�5      $��1��5          Icon 5      '  !Wpf.Ui.Markup.SymbolIconExtension  *Add16+��5      �� *AddNewCommand+��5      ��  �� RelativeSource ��  �� AncestorType" N�5       5!        Wpf.Ui.Controls.DataGrid  5#   
   $��
12 0 12 12q�5%      $��
4 12 12 12q�5&      &   System.Windows.Controls.DataGrid   GridLinesVisibility$	 All=�5'         AutoGenerateColumns$ False��5(      	   
IsReadOnly$
	 True��5)      ��5$      �� *
Categories+
   ColumnHeaderStyle
 5*      �� 5+       �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6   .�5,      ��  �� Property � �� �� Value$ 18(�61   �� 5-       � ��$ 0 0 0 1 q�68   �� 5.       � ��
 �����64   �� 5/       � ��$ Center=�6A   �� 50       � ��$ 10q�60   �� 51       � ��$
 Bold"�63   52         	CellStyle 54      �� 55      *  $System.Windows.Controls.DataGridCell"  6   .�56      ��  � �� 57      �� 58       �� 
TargetType"  6.   .R�59   "   � .+�5:   &   �� $��Center=�5;   )   $��8q�5<   )   5=   #   5>      5@      �� 5A       � ��$ 16(�61   5B         Columns 5D      0	  *System.Windows.Controls.DataGridTextColumn	  5E      ,
  &System.Windows.Controls.DataGridColumn 
  Header$ Category Name��5F       
  Width5  /System.Windows.Controls.DataGridLengthConverter$ * 5H      1  +System.Windows.Controls.DataGridBoundColumn   Binding 5G      �� *CategoryName+5H      4  .System.Windows.Controls.DataGridTemplateColumn  5I      $ Actions��5J       
  CanUserResize$ False��5K       
  CanUserReorder$ False��5L       
  CanUserSort$ False��5M      $
 Auto 5N         CellTemplate 5O      �� 5P      .R�5Q      ��  �� Orientation$ 
Horizontal=�5R   !   .+�5S   "     $
��Edit��5T   %   $��4q�5U   %    5V   %     *Edit16+��5W   %   �� *DataContext.EditCommand+ �� " N���5X   &   `� 5Y   *      BindingConverter `� 	Converter# [  67   .1�5Z   .   �� �� 5[   .    66   �� " N�5\   +   5^   #     5_   "   $��Remove��5`   %   $��4q�5a   %    5b   %     *
Delete16+��5c   %   �� *DataContext.RemoveCommand+ �� " N���5d   %   �� 5e      5f      5h      5j      5k      5l      
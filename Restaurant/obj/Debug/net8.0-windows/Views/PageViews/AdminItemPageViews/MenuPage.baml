   M S B A M L   `   `   `  ����E  ARestaurant, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�[clr-namespace:Restaurant.ViewModels.PageViewModels.AdminPageViewModels.ObjectPageViewModelsMRestaurant.ViewModels.PageViewModels.AdminPageViewModels.ObjectPageViewModels  5      2    ,Restaurant.Views.AdminItemPageViews.MenuPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      M IWpf.Ui, Version=4.0.0.0, Culture=neutral, PublicKeyToken=11f9f5cc97b3ffd6/ui&http://schemas.lepo.co/wpfui/2022/xaml  5      vobjectPageViewModels[clr-namespace:Restaurant.ViewModels.PageViewModels.AdminPageViewModels.ObjectPageViewModels  5        N� Title$  MenuPage��5	       � DataContext 5
      e   _Restaurant.ViewModels.PageViewModels.AdminPageViewModels.ObjectPageViewModels.MenuPageViewModel  5   
   .��5      ]� .+�5   
   � $	��Top=�5       � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $
��Auto �6#   .+�5        Wpf.Ui.Controls.TextBlock  $��Menus��5      
�������   FontTypography$ Title=�5       �� Padding$ 16 24q�5        Wpf.Ui.Controls.Button  5      -   5        $��AddIconButton��5      $��Add New��5      $��12q�5      $��1��5          Icon 5      '  !Wpf.Ui.Markup.SymbolIconExtension  *Add16+��5      �� *AddNewCommand+��5      ��  �� RelativeSource ��  �� AncestorType" N�5       5!        Wpf.Ui.Controls.DataGrid  5#   
   $��
12 0 12 12q�5%      $��
4 12 12 12q�5&      &   System.Windows.Controls.DataGrid   GridLinesVisibility$	 All=�5'      	   AutoGenerateColumns$	 False��5(      
   
IsReadOnly$

 True��5)      ��5$      �� *Menus+   ColumnHeaderStyle 5*      �� 5+       �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6   .�5,      ��  �� Property � �� �� Value$ 18(�61   �� 5-       � ��$ 0 0 0 1 q�68   �� 5.       � ��
 �����64   �� 5/       � ��$ Center=�6A   �� 50       � ��$ 10q�60   �� 51       � ��$
 Bold"�63   52         	CellStyle 54      �� 55      *  $System.Windows.Controls.DataGridCell"  6   .�56      ��  � �� 57      �� 58       �� 
TargetType"  6.   .R�59   "   � .+�5:   &   �� $��Center=�5;   )   $��8q�5<   )   5=   #   5>      5@      �� 5A       � ��$ 16(�61   5B         Columns 5D      0	  *System.Windows.Controls.DataGridTextColumn	  5E      ,
  &System.Windows.Controls.DataGridColumn 
  Header$ 	Menu Name��5F       
  Width5  /System.Windows.Controls.DataGridLengthConverter$ * 5H      1  +System.Windows.Controls.DataGridBoundColumn   Binding 5G      �� *Name+5H      	  5I      $ Number of Products��5J      $ * 5L       5K      �� *MenuItems.Count+5L      4  .System.Windows.Controls.DataGridTemplateColumn  5M      $ Actions��5N       
  CanUserResize$ False��5O       
  CanUserReorder$ False��5P       
  CanUserSort$ False��5Q      $
 Auto 5R         CellTemplate 5S      �� 5T      .R�5U      ��  �� Orientation$ 
Horizontal=�5V   !   .+�5W   "     $
��Edit��5X   %   $��4q�5Y   %    5Z   %     *Edit16+��5[   %   �� *DataContext.EditCommand+ �� " N���5\   &   `� 5]   *      BindingConverter `� 	Converter# [  67   .1�5^   .   �� �� 5_   .    66   �� " N�5`   +   5b   #     5c   "   $��Remove��5d   %   $��4q�5e   %    5f   %     *
Delete16+��5g   %   �� *DataContext.RemoveCommand+ �� " N���5h   %   �� 5i      5j      5l      5n      5o      5p      
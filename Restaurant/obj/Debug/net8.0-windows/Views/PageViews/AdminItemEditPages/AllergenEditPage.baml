   M S B A M L   `   `   `  ����E  ARestaurant, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�_clr-namespace:Restaurant.ViewModels.PageViewModels.AdminPageViewModels.ObjectEditPageViewModelsQRestaurant.ViewModels.PageViewModels.AdminPageViewModels.ObjectEditPageViewModels  5      :    4Restaurant.Views.AdminItemEditPages.AllergenEditPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      M IWpf.Ui, Version=4.0.0.0, Culture=neutral, PublicKeyToken=11f9f5cc97b3ffd6/ui&http://schemas.lepo.co/wpfui/2022/xaml  5      ~objectEditPageViewModels_clr-namespace:Restaurant.ViewModels.PageViewModels.AdminPageViewModels.ObjectEditPageViewModels  5        N� Title$  AllergenEditPage��5	       � DataContext 5
      q   kRestaurant.ViewModels.PageViewModels.AdminPageViewModels.ObjectEditPageViewModels.AllergenEditPageViewModel  5   
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
��Auto �6$   .+�56        $
��Name��57      $��0��58      $��0��59      $��14(�5:      
�������$��Center=�5<      $ 8q�5=      $
��16 8q�5>        Wpf.Ui.Controls.TextBox  5?      $��0��5A      $��1��5B      $
��16 8q�5C      ��5@      �� *Allergen.AllergenName+5C        Wpf.Ui.Controls.InfoBar  5D      
   Title$
 Error��5E         Severity$ Error=�5H      $��
16 0 16 16q�5I      $��1��5J      $��1��5K         Message 5F      �� *ErrorMessage+   IsOpen 5G      �� *NameHasError+5K        5M      $��Description��5N      $��2��5O      $��0��5P      $��14(�5Q      
�������$��Center=�5S      $ 8q�5T      $
��16 8q�5U        5V      $��2��5X      $��1��5Y       �� AcceptsReturn$
 True��5Z       �� TextWrapping$
 Wrap=�5[      $	��120��5\      $	��Top=�5]      $
��16 8q�5^      ��5W      �� *Allergen.Description+5^      5_      5`      5a      5b      
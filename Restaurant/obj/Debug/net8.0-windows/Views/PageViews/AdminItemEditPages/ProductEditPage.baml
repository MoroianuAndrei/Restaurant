   M S B A M L   `   `   `  ����E  ARestaurant, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�_clr-namespace:Restaurant.ViewModels.PageViewModels.AdminPageViewModels.ObjectEditPageViewModelsQRestaurant.ViewModels.PageViewModels.AdminPageViewModels.ObjectEditPageViewModels  5      9    3Restaurant.Views.AdminItemEditPages.ProductEditPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      M IWpf.Ui, Version=4.0.0.0, Culture=neutral, PublicKeyToken=11f9f5cc97b3ffd6/ui&http://schemas.lepo.co/wpfui/2022/xaml  5      ~objectEditPageViewModels_clr-namespace:Restaurant.ViewModels.PageViewModels.AdminPageViewModels.ObjectEditPageViewModels  5        N� Title$  ProductEditPage��5	       � DataContext 5
      p   jRestaurant.ViewModels.PageViewModels.AdminPageViewModels.ObjectEditPageViewModels.ProductEditPageViewModel  5   
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
��Auto �6$   �� 54      $
��Auto �6$   �� 55      $
��Auto �6$   �� 56      $
��Auto �6$   �� 57      $
��Auto �6$   �� 58      $
��Auto �6$   �� 59      $
��Auto �6$   �� 5:      $
��Auto �6$   �� 5;      $
��Auto �6$   �� 5<      $
��Auto �6$   .+�5?        $
��Name��5@      $��0��5A      $��0��5B      $��14(�5C      
�������$��Center=�5E      $ 8q�5F      $
��16 8q�5G        Wpf.Ui.Controls.TextBox  5H      $��0��5J      $��1��5K      $
��16 8q�5L      ��5I      �� *Product.ProductName+5L        Wpf.Ui.Controls.InfoBar  5M      
   Title$
 Error��5N         Severity$ Error=�5Q      $��
16 0 16 16q�5R      $��1��5S      $��1��5T         Message 5O      �� *ErrorMessage+   IsOpen 5P      �� *NameHasError+5T        5V      $��Price��5W      $��2��5X      $��0��5Y      $��14(�5Z      
�������$��Center=�5\      $ 8q�5]      $
��16 8q�5^        5_      $��2��5a      $��1��5b      $
��16 8q�5c      ��5`      �� *Product.Price+ �� UpdateSourceTrigger$ PropertyChanged=�5c        5d      $
 Error��5e      $ Error=�5h      $��
16 0 16 16q�5i      $��3��5j      $��1��5k       5f      �� *ErrorMessage+ 5g      �� *PriceHasError+5k        5m      $��Portion Quantity��5n      $��4��5o      $��0��5p      $��14(�5q      
�������$��Center=�5s      $ 8q�5t      $
��16 8q�5u        5v      $��4��5x      $��1��5y      $
��16 8q�5z      ��5w      �� *Product.PortionQuantity+$ PropertyChanged=�5z        5|      $��Measurement Unit��5}      $��5��5~      $��0��5      $��14(�5�      
�������$��Center=�5�      $ 8q�5�      $
��16 8q�5�        5�      $��5��5�      $��1��5�      $
��16 8q�5�      ��5�      �� *Product.MeasurementUnit+5�        5�      $��Total Quantity��5�      $��6��5�      $��0��5�      $��14(�5�      
�������$��Center=�5�      $ 8q�5�      $
��16 8q�5�        5�      $��6��5�      $��1��5�      $
��16 8q�5�      ��5�      �� *Product.TotalQuantity+$ PropertyChanged=�5�        5�      $��Category��5�      $��7��5�      $��0��5�      $��14(�5�      
�������$��Center=�5�      $ 8q�5�      $
��16 8q�5�      �� 5�      $��7��5�      $��1��5�      $
��16 8q�5�      ��5�      �� *
Categories+ �� SelectedItem 5�      �� *
Category+5�        5�      $
 Error��5�      $ Error=�5�      $��
16 0 16 16q�5�      $��8��5�      $��1��5�       5�      �� *ErrorMessage+ 5�      �� *CategoryHasError+5�        5�      $��Is Menu Item��5�      $��9��5�      $��0��5�      $��14(�5�      
�������$��Center=�5�      $ 8q�5�      $
��16 8q�5�      �� 5�      $��9��5�      $��1��5�      $
��16 8q�5�      $��Center=�5�       d� 	IsChecked 5�      �� *Product.IsMenu+5�      "  Wpf.Ui.Controls.CardExpander  5�      $��10��5�      $��0��5�      $��2��5�      $
��16 8q�5�         Icon 5�      '  !Wpf.Ui.Markup.SymbolIconExtension  *	Alert24+��5�      � 5�      	 5�      �� 5�   "   $
��Auto �60   �� 5�   "   $
��Auto �60    5�      �� 5�   "   $��* �63   �� 5�   "   $
��Auto �63   .+�5�        $��0��5�   !   $��0��5�   !   $��16(�5�   !   $
 Body=�5�   !   $��	Allergens��5�   !     5�      $��1��5�   !   $��0��5�   !   $��12(�5�   !   $,��&Select the allergens for this product.��5�   !   ��5�   !   *  $Wpf.Ui.Markup.ThemeResourceExtension  *TextFillColorSecondaryBrush+5�   !   5�      .��5�      !	  Wpf.Ui.Controls.CardControl	  $��8q�6%   .��5�      ]� .+�5�      � $	��Top=�6#   $��0 0 0 8q�68    5�   "   �� 5�   &   $��* �67   �� 5�   &   $
��Auto �67   .+�5�   "   �� $��0��5�   %    �� DisplayMemberPath$ AllergenName��5�   %   $��0 0 8 0q�5�   %   ��5�   %   �� *AvailableAllergens+ 5�   %   �� *SelectedAllergen+5�   %     5�   "   $��1��5�   %   $	��Add��5�   %   $ Primary=�5�   %   ��5�   %   �� *AddAllergenCommand+5�   %   5�        5�      $	��Top=�5�   !   $ 
BodyStrong=�5�   !   $��Selected Allergens:��5�   !   $	��0 8q�5�   !   �� 5�      
������ 
������ $	��200��5�   !   ��5�   !   �� *Product.Allergens+��5   "   �� 5  &   .R�5  *   �  5  .   �� 5  2   $��* �6C   �� 5  2   $
��Auto �6C   .+�5  .   �� $��0��5  1   $��Center=�5
  1   ��5	  1   �� *AllergenName+5
  1     5  .   $��1��5  1   $ Danger=�5  1      Icon 5  1     *	Dismiss12+��5  1   �� *#!DataContext.RemoveAllergenCommand+ �� " ����5  1   �� 5  +   5  '   5     5     5     5       5     $��11��5     $��0��5     $��2��5     $
��16 8q�5      5       *	Image24+��5      � 5!     	 5"     �� 5#  "   $
��Auto �60   �� 5$  "   $
��Auto �60    5&     �� 5'  "   $��* �63   �� 5(  "   $
��Auto �63   .+�5*       $��0��5+  !   $��0��5,  !   $��16(�5-  !   $
 Body=�5.  !   $��Image��5/  !     50     $��1��51  !   $��0��52  !   $��12(�53  !   $$��Set an image for this product.��55  !   ��54  !     *TextFillColorSecondaryBrush+55  !   56     .��58     	  $��8q�6%    	  Header 59     �� 5:     $��4q�5;  !   .+�5<  "     $ 
BodyStrong=�5=  %   $��Selected image path��5>  %     5?  "      
Appearance$ 	Secondary=�5@  %   ��5A  %   �� *SelectedImagePath+
  Wpf.Ui.Controls.Image
  5B  "   $	��224��5C  %   $��Center=�5D  %    
  CornerRadius$ 4��5E  %   $��8q�5F  %   y�5G  %   �� *ImageVisibility+ 
  Source 5H  %   �� *SelectedImagePath+  5I  "      PlaceholderText$ Image Description��5K  %   $��8q�5L  %   ��5J  %   �� *Product.ImageDescription+5L  %   5M     .��5O       $��Browse��5P     $��8q�5R      5Q       *OpenFolder24+��5S     �� *BrowseForImageCommand+5T     5U     5V     5W     5X     5Y     
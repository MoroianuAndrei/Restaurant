   M S B A M L   `   `   `  ����E  ARestaurant, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:Restaurant.ViewModels.PageViewModels$Restaurant.ViewModels.PageViewModels  5   	   +    %Restaurant.Views.PageViews.SignInPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   M IWpf.Ui, Version=4.0.0.0, Culture=neutral, PublicKeyToken=11f9f5cc97b3ffd6/ui&http://schemas.lepo.co/wpfui/2022/xaml  5   	   GpageViewModels2clr-namespace:Restaurant.ViewModels.PageViewModels  5   	     N� Title$  
SignInPage��5	   	    � DataContext 5
      >   8Restaurant.ViewModels.PageViewModels.SignInPageViewModel  5   
   .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
     Wpf.Ui.Controls.Image  $��0��5         Source$. (../../Assets/Images/store_management.png��5      $	��300��5      $��0 0 64 0q�5      $��Right=�5      �� 5   
   $��1��5       �� Orientation$ Vertical=�5      $
��Left=�5      $��Center=�5      $��16 0 0 0q�5      .+�5        Wpf.Ui.Controls.TextBlock  $��Create Account��5      $��24(�5       $
��Bold"�5!      
�������$	��396��5#       �� TextAlignment$ Center=�5$      $��0,0,0,32q�5%        Wpf.Ui.Controls.TextBox  5&      $	��396��5(      $��0,0,0,12q�5)         PlaceholderEnabled$
 True��5*         PlaceholderText$ 
First Name��5+      ��5'      �� *	FirstName+ �� UpdateSourceTrigger$ PropertyChanged=�5+        5,      $	��396��5.      $��0,0,0,12q�5/      $
 True��50      $ 	Last Name��51      ��5-      �� *
LastName+$ PropertyChanged=�51        52      $	��396��54      $��0,0,0,12q�55      $
 True��56      $ Email��57      ��53      �� *Email+$ PropertyChanged=�57        58      $	��396��5:      $��0,0,0,12q�5;      $
 True��5<      $ Phone��5=      ��59      �� *Phone+$ PropertyChanged=�5=        5>      $	��396��5@      $��0,0,0,12q�5A      $
 True��5B      $ Delivery Address��5C      ��5?      �� *DeliveryAddress+$ PropertyChanged=�5C      !  Wpf.Ui.Controls.PasswordBox  5D      $	��396��5F      $��0,0,0,12q�5G      $
 True��5H      	   PasswordChar$		 ●��5I      $ Password��5J      
   Password
 5E      �� *
Password+ �� Mode$ TwoWay=�$ PropertyChanged=�5J        5K      $	��396��5M      $��0,0,0,12q�5N      $
 True��5O      $		 ●��5P      $ Confirm Password��5Q      
 5L      �� *ConfirmPassword+$ TwoWay=�$ PropertyChanged=�5Q        Wpf.Ui.Controls.InfoBar  5R         Title$ Error��5S         Severity$ Error=�5V      $��0,0,0,12q�5W         Message 5T      �� *ErrorMessage+   IsOpen 5U      �� *
HasError+5W        Wpf.Ui.Controls.Button  5X      $��Sign In��5Y      $	��396��5Z         
Appearance$ Primary=�5[      $��Center=�5\      $��0,0,0,12q�5_      ��5]      �� *SignInCommand+��5^      ��  �� RelativeSource ��  �� AncestorType Page5_        5`      $��Back to Login��5a      $	��396��5b      $ 	Secondary=�5c      $��Center=�5d      ��5e      �� *BackToLoginCommand+��5f      ��  ��  Page5g      5h      5i      
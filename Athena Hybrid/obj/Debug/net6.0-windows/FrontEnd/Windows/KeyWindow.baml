   M S B A M L   `   `   `  ����H  DAthena Hybrid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Athena_Hybrid.FrontEnd.WindowsAthena_Hybrid.FrontEnd.Windows  5   	   D @AdonisUI, Version=1.17.1.0, Culture=neutral, PublicKeyToken=nullK3clr-namespace:AdonisUI.Extensions;assembly=AdonisUIAdonisUI.Extensions 5   	   .    (Athena_Hybrid.FrontEnd.Windows.KeyWindow   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >local,clr-namespace:Athena_Hybrid.FrontEnd.Windows     5   	   A =Wpf.Ui, Version=2.0.2.0, Culture=neutral, PublicKeyToken=null/ui&http://schemas.lepo.co/wpfui/2022/xaml  5   	   JadonisExtensions3clr-namespace:AdonisUI.Extensions;assembly=AdonisUI  5   	   -   5        $	��500��5
   	   $	��916��5   	   $	��916��5   	     � WindowStartupLocation$  CenterScreen=�5   	   $	��500��5   	    � Title$	 Key��5   	   $	��419��6   $	��795��6"   
������� � 
ResizeMode$ CanMinimize=�6A    � Icon$; 5https://frostchanger.de:3012/cdn/Logo-Transparent.ico��6Z    � WindowStyle$
 None=�6�    � 	Resources 5         MontserratBold  MontserratMedium  MontserratSemiBold  windowIn �� 
TargetName �� TargetProperty9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime	 O� Value
   EasingFunction.  (System.Windows.Media.Animation.PowerEase7  1System.Windows.Media.Animation.EasingFunctionBase   
EasingMode��%  &	        &	 /     &	 `     &	 �     *�5   
   /Fonts/#Montserrat Bold)�6E   *�5   
   /Fonts/#Montserrat Medium)�6I   *�5   
   /Fonts/#Montserrat SemiBold)�6M   �� 5   
   .��5      U� $ label��6,   $ (UIElement.Opacity)�6J   .\�5        $ 00:00:00��6'   $	 0.001Q�6:   
 5        5      $ EaseOut=�6$   5        5      $ 00:00:00.4000000��6'   $	 1Q�6B   
 5        5      $ EaseOut=�6$   5       5!      U� 5"      $ label1��6,   $ (UIElement.Opacity)�6K   .\�5#        $ 00:00:00��6'   $	 0.001Q�6:   
 5$        5%      $ EaseOut=�6$   5'        5(      $ 00:00:00.1000000��6'   $	 0Q�6B   
 5)        5*      $ EaseOut=�6$   5,        5-      $ 00:00:00.5000000��6'   $	 1Q�6B   5.      U� 5/      $ KeyBox��6,   $ (UIElement.Opacity)�6K   .\�50        $ 00:00:00��6'   $	 0.001Q�6:   
 51        52      $ EaseOut=�6$   54        55      $ 00:00:00.3000000��6'   $	 0Q�6B   
 56        57      $ EaseOut=�6$   59        5:      $ 00:00:00.7000000��6'   $	 1Q�6B   5;      U� 5<      $ ContinueBtn��6,   $ (UIElement.Opacity)�6P   .\�5=        $ 00:00:00��6'   $	 0.001Q�6:   
 5>        5?      $ EaseOut=�6$   5A        5B      $ 00:00:00.4000000��6'   $	 0Q�6B   
 5C        5D      $ EaseOut=�6$   5F        5G      $ 00:00:00.8000000��6'   $	 1Q�6B   5H      U� 5I      $ 	GetKeyBtn��6,   $ (UIElement.Opacity)�6N   .\�5J        $ 00:00:00��6'   $	 0.001Q�6:   
 5K        5L      $ EaseOut=�6$   5N        5O      $ 00:00:00.5000000��6'   $	 0Q�6B   
 5P        5Q      $ EaseOut=�6$   5S        5T      $ 00:00:00.9000000��6'   $	 1Q�6B   5U      U� 5V      $ label��6,   $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6J   .\�5W        $ 00:00:00��6'   $	 -46.82Q�6:   
 5X        5Y      $ EaseOut=�6$   5[        5\      $ 00:00:00.4000000��6'   $	 0Q�6B   
 5]        5^      $ EaseOut=�6$   5`      5a      U� 5b      $ label1��6,   $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6K   .\�5c        $ 00:00:00��6'   $	 0Q�6:   
 5d        5e      $ EaseOut=�6$   5g        5h      $ 00:00:00.1000000��6'   $	 -46.82Q�6B   
 5i        5j      $ EaseOut=�6$   5l        5m      $ 00:00:00.5000000��6'   $	 0Q�6B   
 5n        5o      $ EaseOut=�6$   5q      5r      U� 5s      $ KeyBox��6,   $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6K   .\�5t        $ 00:00:00��6'   $	 0Q�6:   
 5u        5v      $ EaseOut=�6$   5x        5y      $ 00:00:00.3000000��6'   $	 -46.82Q�6B   
 5z        5{      $ EaseOut=�6$   5}        5~      $ 00:00:00.7000000��6'   $	 0Q�6B   
 5        5�      $ EaseOut=�6$   5�      5�      U� 5�      $ ContinueBtn��6,   $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6P   .\�5�        $ 00:00:00��6'   $	 0Q�6:   
 5�        5�      $ EaseOut=�6$   5�        5�      $ 00:00:00.4000000��6'   $	 -46.82Q�6B   
 5�        5�      $ EaseOut=�6$   5�        5�      $ 00:00:00.8000000��6'   $	 0Q�6B   
 5�        5�      $ EaseOut=�6$   5�      5�      U� 5�      $ 	GetKeyBtn��6,   $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6N   .\�5�        $ 00:00:00��6'   $	 0Q�6:   
 5�        5�      $ EaseOut=�6$   5�        5�      $ 00:00:00.5000000��6'   $	 -46.82Q�6B   
 5�        5�      $ EaseOut=�6$   5�        5�      $ 00:00:00.9000000��6'   $	 0Q�6B   
 5�        5�      $ EaseOut=�6$   5�      5�      5�      5�      .��5�      � ��5�   
   �� 5�      .��5�      �  � Color$ Black��6    � Offset$ 1Q�6-   � 5�      $ #0f1012��6   $ 0.433Q�6/   5�      .+�5�   
   �� -   5         ��Name$ label��5�      $
��Left=�6   $��	40,75,0,0q�6:   $��Welcome back��6N   $	��Top=�6e   $	��513��6}   $��45��6�   ���	#FFADA8A8  
CustomFont#��[ 6�   $��30(�6�   $��Segoe UI Black)�6�    J� RenderTransformOrigin$ 0.5,0.5&�6  ��6�   Z� z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�      T� 5�      5�      5�      �� 5�   
   -   5        $ label1��5�      $
��Left=�6    $��
47,120,0,0q�6;   $:��4Are you Athena+? Well click Continue, No key needed!��6P   $	��Top=�6�   $	��729��6�   $��25��6�   ���	#FF504E4E#��[ 6�   $��Normal"�6  $ 0.5,0.5&�61  ��6  Z� z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�      T� 5�      5�      5�      �� 5�   
   -   5         ��Name$ KeyBox��5�      #��[ 6"   -  'AdonisUI.Extensions.ValidationExtension#   IsErrorMessageVisibleOnFocus$
 True��6S   2  ,AdonisUI.Extensions.CursorSpotlightExtension   BackgroundBrush �#141416   BorderBrush �#141416'    IsErrorMessageVisibleOnMouseOver$
 True��5�   
   $��50,161,453,0q�6W   ���	#FF09090A
�������$ 0.5,0.5&�6�   ���	#FF373738$��1q�6�    �� SelectionBrush �	#FF313233$��2��6  $	��Top=�60   �� SelectionTextBrush 6�   Z� .��6H  z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�      T� 5�      5�      .��5�   '   5�        Wpf.Ui.Controls.Button  5�   
   -   5          Name$ ContinueBtn��5�   E   #��[ 6      Icon$ Rocket16=�6Z      
IconFilled$
 True��6j   $��Continue��6|   
 �����$��
50,202,0,0q�5�   F   ���	#FF0E0E0E$��1q�6q   
����������	#FF373738 � Cursor$
 Hand��6�   $��2��6�   $	��Top=�6�   $	��191��6  $ 0.5,0.5&�6  z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�      T� 5�      5�      5�        5�   
   -   5        $ 	GetKeyBtn��5�   E   #��[ 6   $ Key16=�6X   $
 True��6e   $��	Get a Key��6w   
 �����$��247,202,0,0q�5�   F   ���	#FF0E0E0E$��1q�6r   
����������	#FF373738$
 Hand��6�   $	��Top=�6�   $	��216��6�   $ 0.5,0.5&�6�   z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�      T� 5�      5�      5�      � 5�   
   -   5         �Name$ notificationContainer��5�   '   $	��222��6   $��77��6   $��684,68,10,355q�6F   6_     Wpf.Ui.Controls.TitleBar  5�   
   $��0��5�         Icon$; 5https://frostchanger.de:3012/cdn/Logo-Transparent.ico��5�         CanMaximize$ False��6J   $��2��6^   ���	#FF18191D$��49��6�   5�      5�      5�      
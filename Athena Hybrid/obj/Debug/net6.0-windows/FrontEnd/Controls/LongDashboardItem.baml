   M S B A M L   `   `   `  ����H  DAthena Hybrid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:Athena_Hybrid.FrontEnd.ControlsAthena_Hybrid.FrontEnd.Controls  5      7    1Athena_Hybrid.FrontEnd.Controls.LongDashboardItem   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?local-clr-namespace:Athena_Hybrid.FrontEnd.Controls     5      A =Wpf.Ui, Version=2.0.2.0, Culture=neutral, PublicKeyToken=null/ui&http://schemas.lepo.co/wpfui/2022/xaml  5      $	��470��5	      $��76��6     � 	Resources  5
         MontserratBold  MontserratMedium  MontserratSemiBold  HoverIn �� 
TargetName �� TargetProperty9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value   EasingFunction4  .System.Windows.Media.Animation.ExponentialEase7  1System.Windows.Media.Animation.EasingFunctionBase   
EasingMode  HoverOut��%�  &	        &	 /     &	 `     &	 �     &	 r    *�5   
   /Fonts/#Montserrat Bold)�6E   *�5   
   /Fonts/#Montserrat Medium)�6I   *�5   
   /Fonts/#Montserrat SemiBold)�6M   �� 5   
   .��5      U� $ border5��6,   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6L   .\�5        $ 00:00:00��6'   $
 0.95Q�6:    5        5      $ EaseOut=�6*   5        5      $ 00:00:00.5000000��6'   $
 1.02Q�6B    5        5      $ EaseOut=�6*   5      5      U� 5      $ border5��6,   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6L   .\�5        $ 00:00:00��6'   $
 0.95Q�6:    5        5      $ EaseOut=�6*   5         5!      $ 00:00:00.5000000��6'   $	 1.1Q�6B    5"        5#      $ EaseOut=�6*   5%      5&      5'      �� 5(   
   .��5)      U� $ border5��6,   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6L   .\�5*        $ 00:00:00��6'   $ 1.0199999825Q�6:    5+        5,      $ EaseOut=�6*   5.        5/      $ 00:00:00.4000000��6'   $
 0.95Q�6B    50        51      $ EaseOut=�6*   53      54      U� 55      $ border5��6,   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6L   .\�56        $ 00:00:00��6'   $ 1.0999999625Q�6:    57        58      $ EaseOut=�6*   5:        5;      $ 00:00:00.4000000��6'   $
 0.95Q�6B    5<        5=      $ EaseOut=�6*   5?      5@      5A      5B      .��5C      � .+�5D   
   �� -   5         ��Name$ border5��5D   >   $��66��6O   ���#18191d���#272932$��3q�6�    �� CornerRadius$ 1��6�   	 � Cursor$
	 Hand��6�   
 J� RenderTransformOrigin$
 0.5,0.5&�6�   $��5,5,5,5q�6�   z�5E      V� 5F      .~�5G      ��  �� ScaleX$
 0.95Q�6%    �� ScaleY$
 0.95Q�63   �� 5H      �� 5I      T� 5J      5K      ._�5M      � .+�5N         Wpf.Ui.Controls.SymbolIcon  -   5          Name$ Symbol��5N          Symbol$ Cloud48=�60   $��10,0,0,0q�6A   $��23��6S   $��17��6_   $
��Left=�6j   �� 5O      -   5         ��Name$ 
HeaderText��5O   E   #��[  6   $��New API��6Y   
�������$��35,14,89,18q�6~   $
��Bold"�6�   �� 5P      -   5         ��Name$ SubtitleText��5P   M   #��[ 6   $A��;Onizuka has a new fast API, Which will help in many things ��6c   $
��Wrap=�6�   $��
34,31,10,5q�6�   ���	#FF908B8B$��9(�6�   5Q      5R      5S      5T      
   M S B A M L   `   `   `  ����H  DAthena Hybrid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:Athena_Hybrid.FrontEnd.ControlsAthena_Hybrid.FrontEnd.Controls  5      3    -Athena_Hybrid.FrontEnd.Controls.DashboardItem   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?local-clr-namespace:Athena_Hybrid.FrontEnd.Controls     5      A =Wpf.Ui, Version=2.0.2.0, Culture=neutral, PublicKeyToken=null/ui&http://schemas.lepo.co/wpfui/2022/xaml  5      $��90��5	      $	��238��6     � 	Resources  5
         MontserratBold  MontserratMedium  MontserratSemiBold  HoverIn �� 
TargetName �� TargetProperty9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value   EasingFunction4  .System.Windows.Media.Animation.ExponentialEase7  1System.Windows.Media.Animation.EasingFunctionBase   
EasingMode  HoverOut��%�  &	        &	 /     &	 `     &	 �     &	 q    *�5   
   /Fonts/#Montserrat Bold)�6E   *�5   
   /Fonts/#Montserrat Medium)�6I   *�5   
   /Fonts/#Montserrat SemiBold)�6M   �� 5   
   .��5      U� $ border��6,   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6K   .\�5        $ 00:00:00��6'   $
 0.95Q�6:    5        5      $ EaseOut=�6*   5        5      $ 00:00:00.4000000��6'   $
 1.04Q�6B    5        5      $ EaseOut=�6*   5      5      U� 5      $ border��6,   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6K   .\�5        $ 00:00:00��6'   $
 0.95Q�6:    5        5      $ EaseOut=�6*   5         5!      $ 00:00:00.4000000��6'   $
 1.01Q�6B    5"        5#      $ EaseOut=�6*   5%      5&      5'      �� 5(   
   .��5)      U� $ border��6,   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6K   .\�5*        $ 00:00:00��6'   $ 1.0399999775Q�6:    5+        5,      $ EaseOut=�6*   5.        5/      $ 00:00:00.5000000��6'   $
 0.95Q�6B    50        51      $ EaseOut=�6*   53      54      U� 55      $ border��6,   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6K   .\�56        $ 00:00:00��6'   $ 1.009999985Q�6:    57        58      $ EaseOut=�6*   5:        5;      $ 00:00:00.5000000��6'   $
 0.95Q�6B    5<        5=      $ EaseOut=�6*   5?      5@      5A      5B      .��5C      � .+�5D   
   �� -   5         ��Name$ border��5D   Y   $��90��6<   $��5,0,5,0q�6H   ���#18191d���#272932$��3q�6�    �� CornerRadius$ 1��6�   	 � Cursor$
	 Hand��6�   
 J� RenderTransformOrigin$
 0.5,0.5&�6�   z�5E      V� 5F      .~�5G      ��  �� ScaleX$
 0.95Q�6%    �� ScaleY$
 0.95Q�63   �� 5H      �� 5I      T� 5J      5K      ._�5M      � .+�5N         Wpf.Ui.Controls.SymbolIcon  -   5          Name$ 
HeaderIcon��5N          Symbol$ ChartMultiple20=�64   $��0,7,0,0q�6M   $	��Top=�6^   $��23��6v   $��17��6�   �� 5O      -   5         ��Name$ 
HeaderText��5O   i   #��[  6   $��Center=�6E   $��Fast Loading time��6}   
�������$��10,29,10,35q�6�   $
��Bold"�6�   �� 5P      -   5         ��Name$ SubtitleText��5P   b    �� TextAlignment$ Center=�6   #��[ 63   $<��6Onizuka has a fast loading time, aswell with swapping!��6x   $
��Wrap=�6�   $��	13,47,4,2q�6�   ���	#FF908B8B$��9(�6�   5Q      5R      5S      5T      
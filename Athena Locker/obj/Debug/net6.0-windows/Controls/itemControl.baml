   M S B A M L   `   `   `  ����H  DAthena Locker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Athena_Locker.ControlsAthena_Locker.Controls  5      (    "Athena_Locker.Controls.itemControl   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:Athena_Locker.Controls     5      A =Wpf.Ui, Version=2.0.2.0, Culture=neutral, PublicKeyToken=null/ui&http://schemas.lepo.co/wpfui/2022/xaml  5      $	��124��5	      $	��290��6     � 	Resources  5
         MontserratBold  MontserratMedium  MontserratSemiBold 
 popout �� 
TargetName �� TargetProperty9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value   EasingFunction/  )System.Windows.Media.Animation.CircleEase7  1System.Windows.Media.Animation.EasingFunctionBase   
EasingMode  removepopout��%m  &	        &	 /     &	 `     &	 �     &	 g    *�5   
   /Fonts/#Montserrat Bold)�6E   *�5   
   /Fonts/#Montserrat Medium)�6J   *�5   
   /Fonts/#Montserrat SemiBold)�6N   �� 5   
   .��5      U� $
 grid��6,   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6I   .\�5        $ 00:00:00��6'   $ 1Q�6:    5        5      $ EaseOut=�6%   5        5      $ 00:00:00.4000000��6'   $
 1.05Q�6B    5        5      $ EaseOut=�6%   5      5      U� 5      $
 grid��6,   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6I   .\�5        $ 00:00:00��6'   $ 1Q�6:    5        5      $ EaseOut=�6%   5         5!      $ 00:00:00.4000000��6'   $
 1.05Q�6B    5"        5#      $ EaseOut=�6%   5%      5&      5'      �� 5(   
   .��5)      U� $
 grid��6,   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6I   .\�5*        $ 00:00:00��6'   $
 1.05Q�6:    5+        5,      $ EaseOut=�6%   5.        5/      $ 00:00:00.4000000��6'   $ 1Q�6B    50        51      $ EaseOut=�6%   53      54      U� 55      $
 grid��6,   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6I   .\�56        $ 00:00:00��6'   $
 1.05Q�6:    57        58      $ EaseOut=�6%   5:        5;      $ 00:00:00.4000000��6'   $ 1Q�6B    5<        5=      $ EaseOut=�6%   5?      5@      5A      5B      .��5C      � -   5         �Name$
 grid��5C      $��4,4,4,4q�6S    J� RenderTransformOrigin$ 0.5,0.5&�6d   z�5D   
   V� 5E      .~�5F      �� �� 5G      �� 5H      T� 5I      5J      .+�5L   
   �� -   5        	 ��Name$	 Border��5L      ���#272932$��2q�67   ._�5M      �� $��3��6   
 � Cursor$

 Hand��6&   ���#18191d.+�5N      �� -   5         ��Name$ Rarity��5N      $a��[https://cdn.discordapp.com/attachments/824438219176280074/1092575727536312391/legendary.png��6(   $
��Fill=�6�   $��53��6�   $	��278��6�   $
��Left=�6�   $��Center=�6�   �� 5O      -   5        $ cosmeticIcon��5O      $H��Bhttps://image.fnbr.co/outfit/5ab17d925f957f27504aa53d/icon_192.png��6.   $��Uniform=�6z   $��53��6�   $��56��6�   $
��Left=�6�   $��Center=�6�    �� Left$ 93��6�   �� 5P      -   5         ��Name$ Description��5P   M   #��[ 6   $��PlaceHolder��6b   ���	#FF8E8888$��WrapWithOverflow=�6�   $ 3��6�   
 �� Top$ 76��6�   $��Center=�6�   $	��Top=�6�   $	��206��6  $��34��6  $��10(�6  �� 5Q      -   5         ��Name$
 Name��5Q      $��	Item Name��6&   $ 3��6:   $ 56��6J   
�������$
��Left=�6m   $��Center=�6�   $	��225��6�   #��[  6�   $��15(�6�   $
��Bold"�6�   5R      5T        Wpf.Ui.Controls.Badge  5U   
   -   5          Name$ ConvertedIcon��5U   h   #��[ 6   $��Center=�6D      
Appearance$ Success=�6�   $��Added��6�   $��
245,5,5,93q�6�   $��6(�6�      Wpf.Ui.Controls.SymbolIcon  5V   
   -   5          Name$ favoriteIcon��5V   7      Symbol$ Add24=�6      Filled$ False��6'   $

 Hand��6M   $	 211��6[   $ 89��6m   $��18��6}   $��16��6�   $
��Left=�6�   $��
256,88,0,0q�6�   $	��Top=�6�   
�������6�   5W      5X      
   M S B A M L   `   `   `  ����H  DAthena Hybrid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Athena_HybridAthena_Hybrid  5   	       Athena_Hybrid.MainWindow   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Athena_Hybrid     5   	   A =Wpf.Ui, Version=2.0.2.0, Culture=neutral, PublicKeyToken=null/ui&http://schemas.lepo.co/wpfui/2022/xaml  5   	   -   5        $	��514��5
   	   $
��1014��5   	   ���#0f1012  � Icon$;  5https://frostchanger.de:3012/cdn/Logo-Transparent.ico��5   	    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ CanMinimize=�5   	    � WindowStyle$
 None=�5   	    � 	Resources 5         MontserratBold  MontserratMedium  MontserratSemiBold��%�   &	        &	 /     &	 `     *�5   
   /Fonts/#Montserrat Bold)�6E   *�5   
   /Fonts/#Montserrat Medium)�6I   *�5   
   /Fonts/#Montserrat SemiBold)�6M   5      .��5      � ���	#FF0F1012 � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ TabControl1��5   j   $��8,54,6,4q�6   $��3��6'   ���#0f1012.@�5      �� -   5         ��Name$ DashboardTab��5   G   #��[ 6   $	��200��6]    �� 
IsSelected$
 True��6i   ��5       � 5       -   5        	  �Name$	 	Dashboard��5       $��2��6/   $	��408��6C   ��5"      �� 5#      
 �� Orientation$
 
Horizontal=�6!   $��23��6:   .+�5$         Wpf.Ui.Controls.SymbolIcon  $��0,0,6,0q�6(      Symbol$ Home24=�69      Filled$
 True��6I   �� 5%      -   5         ��Name$ dashboardTab��5%   $   $��	Dashboard��6:   $��20��6K   5&      5(      �� 5)      -   5        $ SkinTab��5)      $	��200��6'   ��5*       � 5+      -   5        $	 Launch��5+      $��2��6-   $	��408��6A   ��5-      �� 5.      $
 
Horizontal=�6!   $��23��6:   .+�5/        $��0,0,6,0q�6(   $ Play24=�69   $
 True��6I   �� 50      -   5        $ 	launchTab��50   $   #��[ 67   $��Launch��6h   $��20��6v   51      53      �� 54      $	��200��6   ��55       � 56      -	   5        $	 Stats��56      $��2��6,   $	��408��6@   ��58      �� 59      $
 
Horizontal=�6!   $��23��6:   .+�5:        $��0,0,6,0q�6(   $ PuzzlePiece24=�69   $
 True��6P   �� 5;      -
   5        $ customizationTab��5;   $   #��[ 6>   $��Customization��6o   $��20��6�   5<      5>      �� 5?      $	��200��6   ��5@       � 5A      -   5        $	 cBackground��5A      $��2��62   $	��408��6F   ��5C      �� 5D      $
 
Horizontal=�6!   $��23��6:   .+�5E        $��0,0,6,0q�6(   $ Wallpaper24=�69   $
 True��6N   �� 5F      -   5        $ customBackgroundsTab��5F   $   #��[ 6B   $��Custom Background��6s   $��20��6�   5G      5I      �� 5J      -   5        $ SettingsTab��5J      $	��200��6+   ��5K       � 5L      -   5        $	 Settings��5L      $��2��6/   $	��408��6C   ��5N      �� 5O      $
 
Horizontal=�6!   $��23��6:   .+�5P        $��0,0,6,0q�6(   $ 
Settings24=�69   $
 True��6M   �� 5Q      -   5        $ settingsTab��5Q   $   #��[ 69   $��Settings��6j   $��20��6z   5R      5T      5U       � 5V   
   -   5        $	 navigationFrame��5V      $y�Visible=�6)    J� RenderTransformOrigin$ 0.5,0.5&�6>   $��10,42,10,10q�6^   $��1��6s     Wpf.Ui.Controls.TitleBar  5W   
      Title$ Athena Hybrid V1.0-D1��5X      $��0��5Y         ShowMaximize$ False��5Z         Icon$; 5https://frostchanger.de:3012/cdn/Logo-Transparent.ico��5[         CanMaximize$ False��6J   ���	#FF18191D$��49��6u   5\      5]      5^      
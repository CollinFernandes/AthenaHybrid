   M S B A M L   `   `   `  ���� H  DAthena Hybrid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Athena_HybridAthena_Hybrid      Athena_Hybrid.MainWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -localclr-namespace:Athena_Hybrid     A =Wpf.Ui, Version=2.0.2.0, Culture=neutral, PublicKeyToken=null/ui&http://schemas.lepo.co/wpfui/2022/xaml  -   $	��514��$
��1014�����#0f1012  � Icon$4  .http://localhost:1337/cdn/Logo-Transparent.ico�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ CanMinimize=� � WindowStyle$
 None=� � 	Resources    MontserratBold  MontserratMedium  MontserratSemiBold��%�   &	        &	 !     &	 D     *�/Fonts/#Montserrat Bold)�*�/Fonts/#Montserrat Medium)�*�/Fonts/#Montserrat SemiBold)�.��� ���	#FF0F1012 � RowDefinitions �� $
��Auto ��� $��* �.+��� -    ��Name$ TabControl1��$��8,54,6,4q�$��3�����#0f1012.@��� -    ��Name$ DashboardTab��#��[ $	��200�� �� 
IsSelected$
 True���� � -   	  �Name$	 	Dashboard��$��2��$	��408������ 
 �� Orientation$
 
Horizontal=�$��23��.+�   Wpf.Ui.Controls.SymbolIcon  $��0,0,6,0q�   Symbol$ Home24=�   Filled$
 True���� -    ��Name$ dashboardTab��$��	Dashboard��$��20���� -   $ SkinTab��$	��200���� � -   $	 Launch��$��2��$	��408������ $
 
Horizontal=�$��23��.+�  $��0,0,6,0q�$ Play24=�$
 True���� -   $ 	launchTab��#��[ $��Launch��$��20���� $	��200���� � -	   $	 Stats��$��2��$	��408������ $
 
Horizontal=�$��23��.+�  $��0,0,6,0q�$ PuzzlePiece24=�$
 True���� -
   $ customizationTab��#��[ $��Customization��$��20���� $	��200���� � -   $	 cBackground��$��2��$	��408������ $
 
Horizontal=�$��23��.+�  $��0,0,6,0q�$ Wallpaper24=�$
 True���� -   $ customBackgroundsTab��#��[ $��Custom Background��$��20���� -   $ SettingsTab��$	��200���� � -   $	 Settings��$��2��$	��408������ $
 
Horizontal=�$��23��.+�  $��0,0,6,0q�$ 
Settings24=�$
 True���� -   $ settingsTab��#��[ $��Settings��$��20�� � -   $	 navigationFrame��$y�Visible=� J� RenderTransformOrigin$ 0.5,0.5&�$��10,42,10,10q�$��1��  Wpf.Ui.Controls.TitleBar     Title$ Athena Hybrid V1.0-D1��$��0��   ShowMaximize$ False��   Icon$4 .http://localhost:1337/cdn/Logo-Transparent.ico��   CanMaximize$ False�����	#FF18191D$��49��
   M S B A M L   `   `   `  ����H  DAthena Locker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Athena_LockerAthena_Locker  5   	       Athena_Locker.MainWindow   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Athena_Locker     5   	   A =Wpf.Ui, Version=2.0.2.0, Culture=neutral, PublicKeyToken=null/ui&http://schemas.lepo.co/wpfui/2022/xaml  5   	   -   5          � WindowStartupLocation$  CenterScreen=�5   	   ���#0f1012 � 
ResizeMode$ CanMinimize=�5
   	    � WindowStyle$
 None=�5   	    � Title$ 
MainWindow��5   	   $	��450��6   $	��900��6)    � 	Resources 5         MontserratBold  MontserratMedium  MontserratSemiBold��%�   &	        &	 /     &	 `     *�5   
   /Fonts/#Montserrat Bold)�6E   *�5   
   /Fonts/#Montserrat Medium)�6J   *�5   
   /Fonts/#Montserrat SemiBold)�6N   5      .��5      � ���	#FF0F1012 � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   � -   5         �Name$ 
loadinGrid��5      $��1��6   $y�Visible=�60   .+�5      �� -   5         ��Name$ Loading_Text��5      $��Loading Program��6.   #��[  6E    �� TextAlignment$ Center=�6r   
�������$��150,227,150,35q�6�   "  Wpf.Ui.Controls.ProgressRing  5      	   IsIndeterminate$
	 True��6   $	��100��65   $	��100��6B   $��400,100,400,201q�6N   5      � 5   
   -   5        $ mainGrid��5      $y�Visible=�6!   $��1��66   .+�5        Wpf.Ui.Controls.Button  -   5        
  Name$
 saveLockerButton��5       � Cursor$
 Hand��6Q   $
{�True��6_   #��[  6p      
Appearance$ Primary=�6�   $��Login��6�   $��5,40,0,0q�6�   $	��Top=�6�   $	��192��6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   �� 5      -   5        $��Enable Custom Locker��5   Q   $��5,8,0,0q�6p   $	��Top=�6�   #��[  6�   $��16��6�     Wpf.Ui.Controls.TextBox  5       -   5          Name$ KeyBox��5       #��[ 6)      PlaceholderEnabled$
 True��6Z      PlaceholderText$ 	Search...��6t   $��581,24,37,0q�5!      ���	#FF09090A
�������$ 0.5,0.5&�6P   ���	#FF373738$��1q�6�    �� SelectionBrush �	#FF313233$	��Top=�6�    �� SelectionTextBrush 6p   Z� 6�      Wpf.Ui.Controls.SymbolIcon  5"      $
 Hand��6      Symbol$ Search24=�6*   $��
865,24,0,0q�6<   $��32(�6P   $	��Top=�6^   $
��Left=�6v   � 5#      -   5        $ cosmeticsGrid��5#      $��5,75,5,5q�6*   .+�5$      �� .��5%      � -	   5         �Name$ allPanel��5%       5&      5'      5(        Wpf.Ui.Controls.TitleBar  5)   
      Title$ Athena Hybrid - Installer��5*      $��0��5+      #��[  5,         CanMaximize$ False��5-      ���	#FF18191D$��49��68   5.      5/      50      
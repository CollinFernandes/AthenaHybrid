   M S B A M L   `   `   `  ���� H  DAthena Hybrid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Athena_Hybrid.FrontEnd.WindowsAthena_Hybrid.FrontEnd.Windows  D @AdonisUI, Version=1.17.1.0, Culture=neutral, PublicKeyToken=nullK3clr-namespace:AdonisUI.Extensions;assembly=AdonisUIAdonisUI.Extensions 0    *Athena_Hybrid.FrontEnd.Windows.LoginWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     >local,clr-namespace:Athena_Hybrid.FrontEnd.Windows     A =Wpf.Ui, Version=2.0.2.0, Culture=neutral, PublicKeyToken=null/ui&http://schemas.lepo.co/wpfui/2022/xaml  JadonisExtensions3clr-namespace:AdonisUI.Extensions;assembly=AdonisUI  $	��350��$	��670��$	��670��$	��350��  � WindowStartupLocation$  CenterScreen=� � Title$	 Key��$	��350��$	��670��
������� � 
ResizeMode$ CanMinimize=� � Icon$4 .http://localhost:1337/cdn/Logo-Transparent.ico�� � WindowStyle$
 None=� � 	Resources    MontserratBold  MontserratMedium  MontserratSemiBold��%�   &	        &	 !     &	 D     *�/Fonts/#Montserrat Bold)�*�/Fonts/#Montserrat Medium)�*�/Fonts/#Montserrat SemiBold)�.��� ���� .���  � Color$ Black�� � Offset$ 1Q�� $ #0f1012��$ 0.433Q�.+�� -    �Name$ epicGamesLogin��$y�Visible=�.+�  Wpf.Ui.Controls.Button  -   	  Name$	 ContinueBtn��#��[ 
   Icon$
 Person24=�   
IconFilled$
 True��$��Login with EpicGames��2  ,AdonisUI.Extensions.CursorSpotlightExtension   BorderBrush
 ��������	#FF0E0E0E$��1q�
����������	#FF373738 � Cursor$
 Hand��$	��282��$��Center=��� -   #��[ $
 Hand��$��Center=�$��Center=�$��	0,196,0,0q�$��Skip for now��$	��Top=�$	��282��$��30��
�������  
CustomFont#��[ $��14(���Z� � -   $ discordLogin��$y�Hidden=�.+�  -   $	 discordLoginBtn��#��[ $
 Person24=�$
 True��$��Authorize with Discord��
 ��������	#FF0E0E0E$��1q�
����������	#FF373738$
 Hand��$	��282��$��Center=��� #��[ $
��Wrap=� �� TextAlignment$ Center=�$f��`you need to connect your discord account to Athena Hybrid to use it! We don't save any Password!��$��194,195,194,93q�  Wpf.Ui.Controls.TitleBar  $��0��   Title$ Athena Hybrid Login��   Icon$4 .http://localhost:1337/cdn/Logo-Transparent.ico��   CanMaximize$ False��$��2�����	#FF18191D$��49��
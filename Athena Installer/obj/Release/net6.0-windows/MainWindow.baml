   M S B A M L   `   `   `  ���� K  GAthena Installer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Athena_InstallerAthena_Installer  !    Athena_Installer.MainWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:Athena_Installer     A =Wpf.Ui, Version=2.0.2.0, Culture=neutral, PublicKeyToken=null/ui&http://schemas.lepo.co/wpfui/2022/xaml  -     � WindowStartupLocation$  CenterScreen=����#0f1012 � 
ResizeMode$ CanMinimize=� � WindowStyle$
 None=� � Title$ 
MainWindow��$	��400��$	��700�� � 	Resources    MontserratBold  MontserratMedium  MontserratSemiBold  WelcomeBackIn �� 
TargetName �� TargetProperty9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value	   EasingFunction.  (System.Windows.Media.Animation.PowerEase7  1System.Windows.Media.Animation.EasingFunctionBase
   
EasingMode  WelcomeBackOut2  ,System.Windows.Media.Animation.QuadraticEase  AgreementIn4  .System.Windows.Media.Animation.ExponentialEase  AgreementOut  	InstallIn  
InstallOut 	 DownloadingIn 
 DownloadingOut  afterDownloadIn  UninstallIn��%B  &	        &	 !     &	 D     &	 i     &	 �    &	 �    &	 L    &	 �    &	 �    &		 �$    &	
 �-    &	 �5    &	 �<    *�/Fonts/#Montserrat Bold)�*�/Fonts/#Montserrat Medium)�*�/Fonts/#Montserrat SemiBold)��� .��U� $ label��$ (UIElement.Opacity)�.\�  $ 00:00:00��$ 0Q�	   $
 EaseOut=�  $ 00:00:00.4000000��$ 1Q�	   $
 EaseOut=�U� $ label1��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�.\�  $ 00:00:00.1000000��$ 37.728Q�	   $
 EaseOut=�  $ 00:00:00.5000000��$ 0Q�	   $
 EaseOut=�U� $ label1��$ (UIElement.Opacity)�.\�  $ 00:00:00��$ 0Q�  $ 00:00:00.1000000��$ 0Q�	   $
 EaseOut=�  $ 00:00:00.5000000��$ 1Q�	   $
 EaseOut=��� .��U� $ label��$ (UIElement.Opacity)�.\�  $ 00:00:00��$ 1Q�	   $
 EaseIn=�  $ 00:00:00.4000000��$ 0Q�	   $
 EaseIn=�U� $ label1��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\�  $ 00:00:00.1000000��$ 0Q�	   $
 EaseIn=�  $ 00:00:00.5000000��$ -37.728Q�	   $
 EaseIn=�U� $ label1��$ (UIElement.Opacity)�.\�  $ 00:00:00.1000000��$ 1Q�	   $
 EaseIn=�  $ 00:00:00.5000000��$ 0Q�	   $
 EaseIn=��� .��U� $ headerasdasdas��$ (UIElement.Opacity)�.\�  $ 00:00:00��$ 0Q�	   $
 EaseOut=�  $ 00:00:00.4000000��$ 1Q�	   $
 EaseOut=�U� $ label2��$ (UIElement.Opacity)�.\�  $ 00:00:00��$ 0Q�	   $
 EaseOut=�  $ 00:00:00.4000000��$ 1Q�	   $
 EaseOut=�U� $ headerasdasdas��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\�  $ 00:00:00��$ 37.728Q�	   $
 EaseOut=�  $ 00:00:00.4000000��$ 0Q�	   $
 EaseOut=�U� $ label2��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\�  $ 00:00:00��$ 37.728Q�	   $
 EaseOut=�  $ 00:00:00.4000000��$ 0Q�	   $
 EaseOut=�U� $ border��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\�  $ 00:00:00��$ 37.728Q�  $ 00:00:00.1000000��$ 37.728Q�	   $
 EaseOut=�  $ 00:00:00.5000000��$ 0.943Q�	   $
 EaseOut=�U� $ checkBox��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\�  $ 00:00:00��$ 37.728Q�  $ 00:00:00.2000000��$ 37.728Q�	   $
 EaseOut=�  $ 00:00:00.6000000��$ 0Q�	   $
 EaseOut=�U� $ LANext��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\�  $ 00:00:00��$ 37.728Q�  $ 00:00:00.3000000��$ 37.728Q�	   $
 EaseOut=�  $ 00:00:00.7000000��$ 0Q�	   $
 EaseOut=�U� $ border��$ (UIElement.Opacity)�.\�  $ 00:00:00��$ 0Q�  $ 00:00:00.1000000��$ 0Q�	   $
 EaseOut=�  $ 00:00:00.5000000��$ 1Q�	   $
 EaseOut=�U� $ checkBox��$ (UIElement.Opacity)�.\�  $ 00:00:00��$ 0Q�  $ 00:00:00.2000000��$ 0Q�	   $
 EaseOut=�  $ 00:00:00.6000000��$ 1Q�	   $
 EaseOut=�U� $ LANext��$ (UIElement.Opacity)�.\�  $ 00:00:00��$ 0Q�  $ 00:00:00.3000000��$ 0Q�	   $
 EaseOut=�  $ 00:00:00.7000000��$ 1Q�	   $
 EaseOut=��� .��U� $ headerasdasdas��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\�  $ 00:00:00��$ 0Q�	   $
 EaseIn=�  $ 00:00:00.4000000��$ -37.728Q�	   $
 EaseIn=�U� $ label2��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\�  $ 00:00:00��$ 0Q�	   $
 EaseIn=�  $ 00:00:00.4000000��$ -37.728Q�	   $
 EaseIn=�U� $ label2��$ (UIElement.Opacity)�.\�  $ 00:00:00��$ 1Q�	   $
 EaseIn=�  $ 00:00:00.4000000��$ 0Q�	   $
 EaseIn=�U� $ headerasdasdas��$ (UIElement.Opacity)�.\�  $ 00:00:00��$ 1Q�	   $
 EaseIn=�  $ 00:00:00.4000000��$ 0Q�	   $
 EaseIn=�U� $ border��$ (UIElement.Opacity)�.\�  $ 00:00:00.1000000��$ 1Q�	   $
 EaseIn=�  $ 00:00:00.5000000��$ 0Q�	   $
 EaseIn=�U� $ border��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\�  $ 00:00:00.1000000��$ 0Q�	   $
 EaseIn=�  $ 00:00:00.5000000��$ -37.728Q�	   $
 EaseIn=�U� $ checkBox��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\�  $ 00:00:00.2000000��$ 0Q�	   $
 EaseIn=�  $ 00:00:00.6000000��$ -37.728Q�	   $
 EaseIn=�U� $ checkBox��$ (UIElement.Opacity)�.\�  $ 00:00:00.2000000��$ 1Q�	   $
 EaseIn=�  $ 00:00:00.6000000��$ 0Q�	   $
 EaseIn=�U� $ LANext��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\�  $ 00:00:00.3000000��$ 0Q�	   $
 EaseIn=�  $ 00:00:00.7000000��$ -37.728Q�	   $
 EaseIn=�U� $ LANext��$ (UIElement.Opacity)�.\�  $ 00:00:00.3000000��$ 1Q�	   $
 EaseIn=�  $ 00:00:00.7000000��$ 0Q�	   $
 EaseIn=��� .��U� $ 
symbolIcon��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\�  $ 00:00:00��$ 57.36Q�	   $
 EaseOut=�  $ 00:00:00.4000000��$ 0Q�	   $
 EaseOut=�U� $ label123��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\�  $ 00:00:00��$ 57.36Q�	   $
 EaseOut=�  $ 00:00:00.4000000��$ 0Q�	   $
 EaseOut=�U� $ 
symbolIcon��$ (UIElement.Opacity)�.\�  $ 00:00:00��$ 0Q�	   $
 EaseOut=�  $ 00:00:00.4000000��$ 1Q�	   $
 EaseOut=�U� $ label123��$ (UIElement.Opacity)�.\�  $ 00:00:00��$ 0Q�	   $
 EaseOut=�  $ 00:00:00.4000000��$ 1Q�	   $
 EaseOut=�U� $ installButton��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\�  $ 00:00:00.1000000��$ 57.36Q�	   $
 EaseOut=�  $ 00:00:00.5000000��$ 0Q�	   $
 EaseOut=�U� $ installButton��$ (UIElement.Opacity)�.\�  $ 00:00:00��$ 0Q�	   $
 EaseOut=�  $ 00:00:00.1000000��$ 0Q�	   $
 EaseOut=�  $ 00:00:00.5000000��$ 1Q�	   $
 EaseOut=�U� $ uninstallButton��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\�  $ 00:00:00.2000000��$ 57.36Q�	   $
 EaseOut=�  $ 00:00:00.6000000��$ 0Q�	   $
 EaseOut=�U� $ uninstallButton��$ (UIElement.Opacity)�.\�  $ 00:00:00��$ 0Q�	   $
 EaseOut=�  $ 00:00:00.2000000��$ 0Q�	   $
 EaseOut=�  $ 00:00:00.6000000��$ 1Q�	   $
 EaseOut=�U� $ button��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\�  $ 00:00:00��$ 0Q�	   $
 EaseOut=�  $ 00:00:00.3000000��$ 57.36Q�	   $
 EaseOut=�  $ 00:00:00.7000000��$ 0Q�	   $
 EaseOut=�U� $ button��$ (UIElement.Opacity)�.\�  $ 00:00:00��$ 0Q�	   $
 EaseOut=�  $ 00:00:00.3000000��$ 0Q�	   $
 EaseOut=�  $ 00:00:00.7000000��$ 1Q�	   $
 EaseOut=��� .��U� $ label123��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\�  $ 00:00:00��$ 0Q�	   $
 EaseIn=�  $ 00:00:00.4000000��$ -33.02Q�	   $
 EaseIn=�U� $ installButton��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\�  $ 00:00:00.1000000��$ 0Q�	   $
 EaseIn=�  $ 00:00:00.5000000��$ -33.02Q�	   $
 EaseIn=�U� $ uninstallButton��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\�  $ 00:00:00.2000000��$ 0Q�	   $
 EaseIn=�  $ 00:00:00.6000000��$ -33.02Q�	   $
 EaseIn=�U� $ button��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\�  $ 00:00:00.3000000��$ 0Q�	   $
 EaseIn=�  $ 00:00:00.7000000��$ -33.02Q�	   $
 EaseIn=�U� $ button��$ (UIElement.Opacity)�.\�  $ 00:00:00.3000000��$ 1Q�	   $
 EaseIn=�  $ 00:00:00.7000000��$ 0Q�	   $
 EaseIn=�U� $ uninstallButton��$ (UIElement.Opacity)�.\�  $ 00:00:00.6000000��$ 0Q�	   $
 EaseIn=�U� $ installButton��$ (UIElement.Opacity)�.\�  $ 00:00:00.5000000��$ 0Q�	   $
 EaseIn=�U� $ label123��$ (UIElement.Opacity)�.\�  $ 00:00:00.4000000��$ 0Q�	   $
 EaseIn=�U� $ 
symbolIcon��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\�  $ 00:00:00��$ 0Q�	   $
 EaseIn=�  $ 00:00:00.4000000��$ -33.02Q�	   $
 EaseIn=�U� $ 
symbolIcon��$ (UIElement.Opacity)�.\�  $ 00:00:00��$ 1Q�	   $
 EaseIn=�  $ 00:00:00.4000000��$ 0Q�	   $
 EaseIn=��� .��U� $ label3��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\�  $ 00:00:00��$ 33.02Q�	   $
 EaseOut=�  $ 00:00:00.4000000��$ 0Q�	   $
 EaseOut=�U� $ downloadedBar��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\�  $ 00:00:00��$ 0Q�	   $
 EaseOut=�  $ 00:00:00.1000000��$ 45.19Q�	   $
 EaseOut=�  $ 00:00:00.5000000��$ 0Q�	   $
 EaseOut=�U� $ downloadedLabel��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\�  $ 00:00:00��$ 0Q�	   $
 EaseOut=�  $ 00:00:00.2000000��$ 33.02Q�	   $
 EaseOut=�  $ 00:00:00.6000000��$ 0Q�	   $
 EaseOut=�U� $ 
speedLabel��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\�  $ 00:00:00��$ 0Q�	   $
 EaseOut=�  $ 00:00:00.3000000��$ 33.02Q�	   $
 EaseOut=�  $ 00:00:00.7000000��$ 0Q�	   $
 EaseOut=�U� $ button1��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\�  $ 00:00:00��$ 0Q�	   $
 EaseOut=�  $ 00:00:00.4000000��$ 45.19Q�	   $
 EaseOut=�  $ 00:00:00.8000000��$ 0Q�	   $
 EaseOut=�U� $ label3��$ (UIElement.Opacity)�.\�  $ 00:00:00��$ 0Q�	   $
 EaseOut=�  $ 00:00:00.4000000��$ 1Q�	   $
 EaseOut=�U� $ downloadedBar��$ (UIElement.Opacity)�.\�  $ 00:00:00��$ 0Q�	   $
 EaseOut=�  $ 00:00:00.1000000��$ 0Q�	   $
 EaseOut=�  $ 00:00:00.5000000��$ 1Q�	   $
 EaseOut=�U� $ downloadedLabel��$ (UIElement.Opacity)�.\�  $ 00:00:00��$ 0Q�	   $
 EaseOut=�  $ 00:00:00.2000000��$ 0Q�	   $
 EaseOut=�  $ 00:00:00.6000000��$ 1Q�	   $
 EaseOut=�U� $ button1��$ (UIElement.Opacity)�.\�  $ 00:00:00��$ 0Q�	   $
 EaseOut=�  $ 00:00:00.4000000��$ 0Q�	   $
 EaseOut=�  $ 00:00:00.8000000��$ 1Q�	   $
 EaseOut=�U� $ 
speedLabel��$ (UIElement.Opacity)�.\�  $ 00:00:00��$ 0Q�	   $
 EaseOut=�  $ 00:00:00.3000000��$ 0Q�	   $
 EaseOut=�  $ 00:00:00.7000000��$ 1Q�	   $
 EaseOut=��� .��U� $ label3��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\�  $ 00:00:00��$ 0Q�	   $
 EaseIn=�  $ 00:00:00.4000000��$ -33.02Q�	   $
 EaseIn=�U� $ label3��$ (UIElement.Opacity)�.\�  $ 00:00:00��$ 1Q�	   $
 EaseIn=�  $ 00:00:00.4000000��$ 0Q�	   $
 EaseIn=�U� $ downloadedBar��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\�  $ 00:00:00.1000000��$ 0Q�	   $
 EaseIn=�  $ 00:00:00.5000000��$ -33.02Q�	   $
 EaseIn=�U� $ downloadedBar��$ (UIElement.Opacity)�.\�  $ 00:00:00.1000000��$ 1Q�	   $
 EaseIn=�  $ 00:00:00.5000000��$ 0Q�	   $
 EaseIn=�U� $ downloadedLabel��$ (UIElement.Opacity)�.\�  $ 00:00:00.2000000��$ 1Q�	   $
 EaseIn=�  $ 00:00:00.6000000��$ 0Q�	   $
 EaseIn=�U� $ downloadedLabel��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\�  $ 00:00:00.2000000��$ 0Q�	   $
 EaseIn=�  $ 00:00:00.6000000��$ -33.02Q�	   $
 EaseIn=�U� $ 
speedLabel��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\�  $ 00:00:00.3000000��$ 0Q�	   $
 EaseIn=�  $ 00:00:00.7000000��$ -33.02Q�	   $
 EaseIn=�U� $ 
speedLabel��$ (UIElement.Opacity)�.\�  $ 00:00:00.3000000��$ 1Q�	   $
 EaseIn=�  $ 00:00:00.7000000��$ 0Q�	   $
 EaseIn=�U� $ button1��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\�  $ 00:00:00.4000000��$ 0Q�	   $
 EaseIn=�  $ 00:00:00.8000000��$ -45.19Q�	   $
 EaseIn=�U� $ button1��$ (UIElement.Opacity)�.\�  $ 00:00:00.4000000��$ 1Q�	   $
 EaseIn=�  $ 00:00:00.8000000��$ 0Q�	   $
 EaseIn=��� .��U� $ symbolIcon1��$ (UIElement.Opacity)�.\�  $ 00:00:00��$ 0Q�	   $
 EaseOut=�  $ 00:00:00.4000000��$ 1Q�	   $
 EaseOut=�U� $ label4��$ (UIElement.Opacity)�.\�  $ 00:00:00��$ 0Q�	   $
 EaseOut=�  $ 00:00:00.4000000��$ 1Q�	   $
 EaseOut=�U� $ symbolIcon1��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\�  $ 00:00:00��$ 53.036Q�	   $
 EaseOut=�  $ 00:00:00.4000000��$ 0Q�	   $
 EaseOut=�U� $ label4��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\�  $ 00:00:00��$ 53.036Q�	   $
 EaseOut=�  $ 00:00:00.4000000��$ 0Q�	   $
 EaseOut=�U� $ button2��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\�  $ 00:00:00��$ 0Q�	   $
 EaseOut=�  $ 00:00:00.1000000��$ 53.036Q�	   $
 EaseOut=�  $ 00:00:00.5000000��$ 0Q�	   $
 EaseOut=�U� $ button2��$ (UIElement.Opacity)�.\�  $ 00:00:00��$ 0Q�	   $
 EaseOut=�  $ 00:00:00.1000000��$ 0Q�	   $
 EaseOut=�  $ 00:00:00.5000000��$ 1Q�	   $
 EaseOut=�U� $ button3��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\�  $ 00:00:00��$ 0Q�	   $
 EaseOut=�  $ 00:00:00.2000000��$ 53.036Q�	   $
 EaseOut=�  $ 00:00:00.6000000��$ 0Q�	   $
 EaseOut=�U� $ button3��$ (UIElement.Opacity)�.\�  $ 00:00:00��$ 0Q�	   $
 EaseOut=�  $ 00:00:00.2000000��$ 0Q�	   $
 EaseOut=�  $ 00:00:00.6000000��$ 1Q�	   $
 EaseOut=��� .��U� $ symbolIcon2��$ (UIElement.Opacity)�.\�  $ 00:00:00��$ 0Q�	   $
 EaseOut=�  $ 00:00:00.4000000��$ 1Q�	   $
 EaseOut=�U� $ label5��$ (UIElement.Opacity)�.\�  $ 00:00:00��$ 0Q�	   $
 EaseOut=�  $ 00:00:00.4000000��$ 1Q�	   $
 EaseOut=�U� $ button4��$ (UIElement.Opacity)�.\�  $ 00:00:00��$ 0Q�	   $
 EaseOut=�  $ 00:00:00.1000000��$ 0Q�	   $
 EaseOut=�  $ 00:00:00.5000000��$ 1Q�U� $ symbolIcon2��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\�  $ 00:00:00��$ 53.036Q�	   $
 EaseOut=�  $ 00:00:00.4000000��$ 0Q�	   $
 EaseOut=�U� $ label5��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\�  $ 00:00:00��$ 53.036Q�	   $
 EaseOut=�  $ 00:00:00.4000000��$ 0Q�	   $
 EaseOut=�U� $ button4��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\�  $ 00:00:00��$ 0Q�	   $
 EaseOut=�  $ 00:00:00.1000000��$ 53.036Q�	   $
 EaseOut=�  $ 00:00:00.5000000��$ 0Q�	   $
 EaseOut=�.��� ���	#FF0F1012 � RowDefinitions �� $
��Auto ��� $��* �.+�� -    �Name$ welcomeGrid��$��1��$y�Hidden=�.+��� -    ��Name$ label��$��Athena Hybrid��$��Center=�#��[  $��55(�
�������$��0,130,0,153q� J� RenderTransformOrigin$ 0.5,0.5&�z�V� .~��� �� �� T� �� -   $ label1��$��Welcome��$��Center=�#��[ $��25(�
�������$��
0,198,0,85q�$ 0.5,0.5&�z�V� .~��� �� �� T� � -   $ agreementGrid��$��1��$y�Hidden=�.+�   Wpf.Ui.Controls.SymbolIcon  -     Name$ headerasdasdas�����#4d89ff   Symbol$ BuildingBank24=�$��1��$��37��$��36��$��40(�$
��Left=�$��	10,10,0,0q�$	��Top=�$ 0.5,0.5&�z�V� .~��� �� �� T� �� -   $ label2��$��License Agreement��$��1��$��36(�
�������$��51,6,273,299q�$
��Bold"�#��[  $ 0.5,0.5&�z�V� .~��� �� �� T� �� -    ��Name$ border��$��1��$��10,60,10,73q����#18191d���#272932$��3q� �� CornerRadius$ 1��$ 0.5,0.5&�z�V� .~��� �� �� T� ._��� $��5,5,5,5q�.���� 
�������#��[ $
��Wrap=�nlplease read this agreement carefully and attentively. it contains important information about athena hybrid.�� �� HFby installing our software, you accept our agreement of this document.�� �� ?=if you do not accept our terms, you may not use our software!�� �� mk§1.0 - the athena team has the right to exclude you from the project at any time if you violate our rules.�� �� ��§1.1 - when using athena it is possible to get an account ban. the athena team is not responsible if this happens to your account. therefore we recommend using an alt (alternate) account when using athena.�� �� FD§1.2 - you agree that you must log in with your epic games account.�� �� a_§1.3 - your epic games token and discord information will be stored on your personal computer.�� �� ><your data will not be shared with any third party companies.�� �� 31athena hybrid does not cooperate with epic games!�� -	    ��Name$ checkBox��#��[  $%��I accept the license agreement.��$��1��$��
10,290,0,0q�$	��Top=�$��5��$ 0.5,0.5&�z�V� .~��� �� �� T�   Wpf.Ui.Controls.Button  -
     Name$ LANext�� � Cursor$
 Hand��${�False��#��[     
Appearance$ Primary=�$
��Next��$��1��$��591,309,0,0q�$	��Top=�$��99��$ 0.5,0.5&�z�V� .~��� �� �� T� � -   $ installGrid��$��1��$y�Hidden=�.+�  -   $ 
symbolIcon�����#4d89ff$ 	Options24=�$��1��$��37��$��36��$��40(�$
��Left=�$��	10,10,0,0q�$	��Top=�$ 0.5,0.5&�z�V� .~��� �� �� T� �� -   $ label123��$��Installation��$��1��$��36(�
�������$��51,6,273,299q�$
��Bold"�#��[  $ 0.5,0.5&�z�V� .~��� �� �� T�   -   $ installButton��$
 Hand��#��[  $
{�True��   Icon$ ArrowDownload24=�$��Center=�$��Install Athena Hybrid��$ Primary=�$��	0,124,0,0q�$	��Top=�$	��290��$ 0.5,0.5&�z�V� .~��� �� �� T�   -   $ uninstallButton��$
 Hand��#��[  ${�False��$ Delete24=�$��Center=�$��Uninstall Athena Hybrid��$ Primary=�$	��290��$��	0,176,0,0q�$	��Top=�$ 0.5,0.5&�z�V� .~��� �� �� T�   -   $ button��$
 Hand��$
{�True��#��[  $ Primary=�$
��Next��$��1��$��591,309,0,0q�$	��Top=�$��99��$ 0.5,0.5&�z�V� .~��� �� �� T� � -   $ downloadingGrid��$��1��$y�Hidden=�.+��� -   $ label3��$��installing Athena Hybrid��$��Center=�#��[ $��Center=�$��32(�
�������$��
0,97,0,211q�$	��700��$ 0.5,0.5&�z�V� .~��� �� �� T� � -    �Name$ downloadedBar��$��Center=�$��0,155,0,184q�$	��400��$ 0.5,0.5&�z�V� .~��� �� �� T� �� -   $ downloadedLabel��$��1,3mb/6,3mb Downloaded��$��Center=�#��[ $��Center=�$��0,172,0,160q�$	��700��$ 0.5,0.5&�z�V� .~��� �� �� T� �� -   $ 
speedLabel��$��5,21mb/s��$��Center=�#��[ $��Center=�$��0,191,0,141q�$	��700��$ 0.5,0.5&�z�V� .~��� �� �� T�   -   $ button1��$
 Hand��$
{�True��#��[  $ Primary=�$��Start Installing.��$��	0,215,0,0q�$	��Top=�$	��192��$ 0.5,0.5&�$��Center=�z�V� .~��� �� �� T� � -   $ afterDeleteGrid��$��1��$y�Hidden=�.+�  -   $ symbolIcon2�����#4d89ff$ ArchiveArrowBack24=�$��37��$��41��$��40(�$
��Left=�$��	10,10,0,0q�$	��Top=�$ 0.5,0.5&�z�V� .~��� �� �� T� �� -   $ label5��$��uninstall done��$��1��$��36(�
�������$��51,6,273,299q�$
��Bold"�#��[  $ 0.5,0.5&�z�V� .~��� �� �� T�   -   $ button4��$
 Hand��#��[  $
{�True��$ Play24=�$��Center=�$��Exit the Installer��$ Primary=�$	��290��$ 0.5,0.5&�z�V� .~��� �� �� T� � -   $ afterDownloadGrid��$��1��$y�Hidden=�.+�  -   $ symbolIcon1�����#4d89ff$ ArchiveArrowBack24=�$��37��$��41��$��40(�$
��Left=�$��	10,10,0,0q�$	��Top=�$ 0.5,0.5&�z�V� .~��� �� �� T� �� -   $ label4��$��Installation Done.��$��1��$��36(�
�������$��51,6,273,299q�$
��Bold"�#��[  $ 0.5,0.5&�z�V� .~��� �� �� T�   -   $ button2��$
 Hand��#��[  $
{�True��$ Play24=�$��Center=�$��Launch Athena Hybrid��$ Primary=�$��	0,124,0,0q�$	��Top=�$	��290��$ 0.5,0.5&�z�V� .~��� �� �� T�   -   $ button3��$
 Hand��#��[  $
{�True��$ ArrowExit20=�$��Center=�$��Close Installer��$ Primary=�$	��290��$��	0,176,0,0q�$	��Top=�$ 0.5,0.5&�z�V� .~��� �� �� T�   Wpf.Ui.Controls.TitleBar     Title$ Athena Hybrid - Installer��$��0��#��[     CanMaximize$ False�����	#FF18191D$��49��
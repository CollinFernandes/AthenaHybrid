   M S B A M L   `   `   `  ���� H  DAthena Hybrid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Athena_Hybrid.FrontEnd.PagesAthena_Hybrid.FrontEnd.Pages  4    .Athena_Hybrid.FrontEnd.Pages.CustomizationPage   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     <local*clr-namespace:Athena_Hybrid.FrontEnd.Pages     A =Wpf.Ui, Version=2.0.2.0, Culture=neutral, PublicKeyToken=null/ui&http://schemas.lepo.co/wpfui/2022/xaml  -     N� Title$  CustomizationPage�� � Cursor$  �� � 	Resources    MontserratBold  MontserratMedium  MontserratSemiBold  loadingGridIn �� 
TargetName �� TargetProperty9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value   EasingFunction4  .System.Windows.Media.Animation.ExponentialEase7  1System.Windows.Media.Animation.EasingFunctionBase   
EasingMode  loadingGridOut  
mainGridIn  mainGridOut.  (System.Windows.Media.Animation.PowerEase  	labelAnim/  )System.Windows.Media.Animation.CircleEase��%V.  &	        &	 !     &	 D     &	 i     &	 �    &	 �    &	 b    &	 �+    *�/Fonts/#Montserrat Bold)�*�/Fonts/#Montserrat Medium)�*�/Fonts/#Montserrat SemiBold)��� .��U� $ progressBar��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\�  $ 00:00:00��$ -9.386Q�   $ EaseOut=�  $ 00:00:00.5000000��$ 0Q�   $ EaseOut=�U� $ progressBar��$ (UIElement.Opacity)�.\�  $ 00:00:00��$ 0Q�   $ EaseOut=�  $ 00:00:00.5000000��$ 1Q�   $ EaseOut=�U� $ loadingLabel��$ (UIElement.Opacity)�.\�  $ 00:00:00��$ 0Q�   $ EaseOut=�  $ 00:00:00.1000000��$ 0Q�   $ EaseOut=�  $ 00:00:00.6000000��$ 1Q�   $ EaseOut=�U� $ loadingLabel��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\�  $ 00:00:00��$ 0Q�   $ EaseOut=�  $ 00:00:00.1000000��$ -37.544Q�   $ EaseOut=�  $ 00:00:00.6000000��$ 0Q�   $ EaseOut=�U� $ progressBar��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�.\�  $ 00:00:00��$ 0.939Q�   $ EaseOut=�  $ 00:00:00.5000000��$ 0Q�   $ EaseOut=��� .��U� $ progressBar��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\�  $ 00:00:00��$ 0Q�   $ EaseIn=�  $ 00:00:00.5000000��$ 37.544Q�   $ EaseIn=�U� $ progressBar��$ (UIElement.Opacity)�.\�  $ 00:00:00��$ 1Q�   $ EaseIn=�  $ 00:00:00.5000000��$ 0Q�   $ EaseIn=�U� $ loadingLabel��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\�  $ 00:00:00.1000000��$ 0Q�   $ EaseIn=�  $ 00:00:00.6000000��$ 37.544Q�   $ EaseIn=�U� $ loadingLabel��$ (UIElement.Opacity)�.\�  $ 00:00:00.1000000��$ 1Q�   $ EaseIn=�  $ 00:00:00.6000000��$ 0Q�   $ EaseIn=��� .��U� $ VBucksCustomization��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\�  $ 00:00:00��$ -37.544Q�   $ EaseOut=�  $ 00:00:00.5000000��$ 0Q�   $ EaseOut=�U� $ LevelCustomization��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\�  $ 00:00:00��$ -37.544Q�   $ EaseOut=�  $ 00:00:00.5000000��$ 0Q�   $ EaseOut=�U� $ BattlestarsCustomization��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\�  $ 00:00:00��$ 0Q�   $ EaseOut=�  $ 00:00:00.1000000��$ -37.544Q�   $ EaseOut=�  $ 00:00:00.6000000��$ 0Q�   $ EaseOut=�U� $ RankBuildCustomization��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\�  $ 00:00:00��$ 0Q�   $ EaseOut=�  $ 00:00:00.1000000��$ -37.544Q�   $ EaseOut=�  $ 00:00:00.6000000��$ 0Q�   $ EaseOut=�U� $&  RankBuildPercentageCustomization��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\�  $ 00:00:00��$ 0Q�   $ EaseOut=�  $ 00:00:00.2000000��$ -37.544Q�   $ EaseOut=�  $ 00:00:00.7000000��$ 0Q�   $ EaseOut=�U� $ RankNoBuildCustomization��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\�  $ 00:00:00��$ 0Q�   $ EaseOut=�  $ 00:00:00.2000000��$ -37.544Q�   $ EaseOut=�  $ 00:00:00.7000000��$ 0Q�   $ EaseOut=�U� $( "RankNoBuildPercentageCustomization��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\�  $ 00:00:00��$ 0Q�   $ EaseOut=�  $ 00:00:00.2000000��$ -37.544Q�   $ EaseOut=�  $ 00:00:00.7000000��$ 0Q�   $ EaseOut=�U� $ ProfileContainer��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\�  $ 00:00:00.1000000��$ -37.544Q�   $ EaseOut=�  $ 00:00:00.6000000��$ 0Q�   $ EaseOut=�U� $ VBucksCustomization��$ (UIElement.Opacity)�.\�  $ 00:00:00��$ 0Q�   $ EaseOut=�  $ 00:00:00.5000000��$ 1Q�   $ EaseOut=�U� $ LevelCustomization��$ (UIElement.Opacity)�.\�  $ 00:00:00��$ 0Q�   $ EaseOut=�  $ 00:00:00.5000000��$ 1Q�   $ EaseOut=�U� $ BattlestarsCustomization��$ (UIElement.Opacity)�.\�  $ 00:00:00��$
 0.01Q�   $ EaseOut=�  $ 00:00:00.1000000��$ 0Q�   $ EaseOut=�  $ 00:00:00.6000000��$ 1Q�   $ EaseOut=�U� $ RankBuildCustomization��$ (UIElement.Opacity)�.\�  $ 00:00:00��$
 0.01Q�   $ EaseOut=�  $ 00:00:00.1000000��$ 0Q�   $ EaseOut=�  $ 00:00:00.6000000��$ 1Q�   $ EaseOut=�U� $&  RankBuildPercentageCustomization��$ (UIElement.Opacity)�.\�  $ 00:00:00��$
 0.01Q�   $ EaseOut=�  $ 00:00:00.2000000��$ 0Q�   $ EaseOut=�  $ 00:00:00.7000000��$ 1Q�   $ EaseOut=�U� $ RankNoBuildCustomization��$ (UIElement.Opacity)�.\�  $ 00:00:00��$
 0.01Q�   $ EaseOut=�  $ 00:00:00.2000000��$ 0Q�   $ EaseOut=�  $ 00:00:00.7000000��$ 1Q�   $ EaseOut=�U� $( "RankNoBuildPercentageCustomization��$ (UIElement.Opacity)�.\�  $ 00:00:00��$
 0.01Q�   $ EaseOut=�  $ 00:00:00.2000000��$ 0Q�   $ EaseOut=�  $ 00:00:00.7000000��$ 1Q�   $ EaseOut=�U� $ ProfileContainer��$ (UIElement.Opacity)�.\�  $ 00:00:00��$ 0Q�   $ EaseOut=�  $ 00:00:00.1000000��$ 0Q�   $ EaseOut=�  $ 00:00:00.6000000��$ 1Q�   $ EaseOut=�U� $ loginButton��$ (UIElement.Opacity)�.\�  $ 00:00:00��$ 0Q�   $ EaseOut=�  $ 00:00:00.3000000��$
 0.01Q�   $ EaseOut=�  $ 00:00:00.8000000��$ 1Q�U� $ 
saveButton��$ (UIElement.Opacity)�.\�  $ 00:00:00��$ 0Q�   $ EaseOut=�  $ 00:00:00.4000000��$
 0.01Q�   $ EaseOut=�  $ 00:00:00.9000000��$ 1Q�U� $ loginButton��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\�  $ 00:00:00��$ 0Q�   $ EaseOut=�  $ 00:00:00.3000000��$ -37.544Q�   $ EaseOut=�  $ 00:00:00.8000000��$ 0Q�   $ EaseOut=�U� $ 
saveButton��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\�  $ 00:00:00��$ 0Q�   $ EaseOut=�  $ 00:00:00.4000000��$ -37.544Q�   $ EaseOut=�  $ 00:00:00.9000000��$ 0Q�   $ EaseOut=��� .��U� $ VBucksCustomization��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\�  $ 00:00:00��$ 0Q�   $ EaseIn=�  $ 00:00:00.5000000��$ 37.544Q�   $ EaseIn=�U� $ LevelCustomization��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\�  $ 00:00:00��$ 0Q�   $ EaseIn=�  $ 00:00:00.5000000��$ 37.544Q�   $ EaseIn=�U� $ BattlestarsCustomization��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\�  $ 00:00:00��$ 0Q�   $ EaseIn=�  $ 00:00:00.5000000��$ 37.544Q�   $ EaseIn=�U� $ VBucksCustomization��$ (UIElement.Opacity)�.\�  $ 00:00:00��$ 1Q�   $ EaseIn=�  $ 00:00:00.5000000��$ 0.005Q�   $ EaseIn=�U� $ LevelCustomization��$ (UIElement.Opacity)�.\�  $ 00:00:00��$ 1Q�   $ EaseIn=�  $ 00:00:00.5000000��$ 0.005Q�   $ EaseIn=�U� $ BattlestarsCustomization��$ (UIElement.Opacity)�.\�  $ 00:00:00��$ 1Q�   $ EaseIn=�  $ 00:00:00.5000000��$ 0.005Q�   $ EaseIn=�U� $ RankBuildCustomization��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\�  $ 00:00:00��$ 0Q�   $ EaseIn=�  $ 00:00:00.6000000��$ 37.544Q�   $ EaseIn=�U� $&  RankBuildPercentageCustomization��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\�  $ 00:00:00��$ 0Q�   $ EaseIn=�  $ 00:00:00.6000000��$ 37.544Q�   $ EaseIn=�U� $ RankBuildCustomization��$ (UIElement.Opacity)�.\�  $ 00:00:00��$ 1Q�   $ EaseIn=�  $ 00:00:00.6000000��$ 0.005Q�   $ EaseIn=�U� $&  RankBuildPercentageCustomization��$ (UIElement.Opacity)�.\�  $ 00:00:00��$ 1Q�   $ EaseIn=�  $ 00:00:00.6000000��$ 0.005Q�   $ EaseIn=�U� $ RankNoBuildCustomization��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\�  $ 00:00:00��$ 0Q�   $ EaseIn=�  $ 00:00:00.7000000��$ 37.544Q�   $ EaseIn=�U� $( "RankNoBuildPercentageCustomization��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\�  $ 00:00:00��$ 0Q�   $ EaseIn=�  $ 00:00:00.7000000��$ 37.544Q�   $ EaseIn=�U� $ RankNoBuildCustomization��$ (UIElement.Opacity)�.\�  $ 00:00:00��$ 1Q�   $ EaseIn=�  $ 00:00:00.7000000��$ 0.005Q�   $ EaseIn=�U� $( "RankNoBuildPercentageCustomization��$ (UIElement.Opacity)�.\�  $ 00:00:00��$ 1Q�   $ EaseIn=�  $ 00:00:00.7000000��$ 0.005Q�   $ EaseIn=�U� $ ProfileContainer��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\�  $ 00:00:00.1000000��$ 0Q�   $ EaseIn=�  $ 00:00:00.7000000��$ 37.544Q�   $ EaseIn=�U� $ ProfileContainer��$ (UIElement.Opacity)�.\�  $ 00:00:00.1000000��$ 1Q�   $ EaseIn=�  $ 00:00:00.7000000��$ 0Q�   $ EaseIn=�U� $ loginButton��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\�  $ 00:00:00.2000000��$ 0Q�   $ EaseIn=�  $ 00:00:00.8000000��$ 37.544Q�   $ EaseIn=�U� $ loginButton��$ (UIElement.Opacity)�.\�  $ 00:00:00.2000000��$ 1Q�   $ EaseIn=�  $ 00:00:00.8000000��$ 0Q�   $ EaseIn=�U� $ 
saveButton��$ (UIElement.Opacity)�.\�  $ 00:00:00.3000000��$ 1Q�   $ EaseIn=�  $ 00:00:00.9000000��$ 0Q�   $ EaseIn=�U� $ 
saveButton��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\�  $ 00:00:00.3000000��$ 0Q�   $ EaseIn=�  $ 00:00:00.9000000��$ 37.544Q�   $ EaseIn=��� .��U� $ loadingLabel��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�.\�  $ 00:00:00��$ 0Q�   $ EaseOut=�  $ 00:00:00.4000000��$ 9.386Q�   $ EaseOut=�  $ 00:00:00.5000000��$ 9.386Q�   $ EaseOut=�  $ 00:00:00.8000000��$ 0Q�   $ EaseOut=�U� $ loadingLabel��$ (UIElement.Opacity)�.\�  $ 00:00:00��$ 1Q�   $ EaseOut=�  $ 00:00:00.4000000��$ 0Q�   $ EaseOut=�  $ 00:00:00.5000000��$ 0Q�   $ EaseOut=�  $ 00:00:00.8000000��$ 1Q�   $ EaseOut=�.��� .+�� -   	 �Name$	 mainGrid��$y�Visible=�.+��� -   
 ��Name$
 VBucksCustomization��$��10,10,809,326q����#18191d���#272932$��3q� �� CornerRadius$ 1�� J� RenderTransformOrigin$ 0.5,0.5&�z�V� .~��� �� �� T� ._�� .+��� -    ��Name$ 
HeaderText��$��VBucks��$��18(�
�������$��5,3,5,40q�$
��Bold"�#��[   Wpf.Ui.Controls.TextBox  -     Name$ 	vbucksBox��#��[ ���	#FF0E0E0E$��1q�
����������	#FF373738   PlaceholderEnabled$
 True��   PlaceholderText$
 1000��$��5,31,5,0q�$	��Top=��� -   $
 LevelCustomization��$��10,92,809,244q����#18191d���#272932$��3q�$ 1��$ 0.5,0.5&�z�V� .~��� �� �� T� ._�� .+��� -   $ LevelHeader��$��Level��$��18(�
�������$��5,4,5,40q�$
��Bold"�$��Segoe UI Semibold)�  -   $ levelBox��#��[ ���	#FF0E0E0E$��1q�
����������	#FF373738$
 True��$	 182��$��5,31,5,0q�$	��Top=��� -	   $
 BattlestarsCustomization��$��10,174,809,162q����#18191d���#272932$��3q�$ 1��$ 0.5,0.5&�z�V� .~��� �� �� T� ._�� .+��� -
   $ BattlestarsHeader��$��Battlestars��$��18(�
�������$��5,3,5,40q�$
��Bold"�$��Segoe UI Semibold)�  -   $ battlestarsBox��#��[ ���	#FF0E0E0E$��1q�
����������	#FF373738$
 True��$	 182��$��5,31,5,0q�$	��Top=��� -   $
 RankBuildCustomization��$��190,10,629,261q����#18191d���#272932$��3q�$ 1��$ 0.5,0.5&�z�V� .~��� �� �� T� ._�� .+��� -   $ CurrentRankHeaderBuild��$��Current Rank (Build)��$
��14.5(�
�������$��	5,2,5,112q�$
��Bold"�#��[  �� -    ��Name$ currentRankBuildBox��#��[ ���	#FF0E0E0E$��1q�
����������	#FF373738$��5,29,5,0q�$	��Top=�.@��� .��
Bronze 1�� .��
Bronze 2�� .��
Bronze 3�� .��
Silber 1�� .��
Silber 2�� .��
Silber 3�� .��Gold 1�� .��Gold 2�� .��Gold 3�� .��
Platin 1�� .��
Platin 2�� .��
Platin 3�� .��	Diamond 1�� .��	Diamond 2�� .��	Diamond 3�� .��Elite�� .��
Champion�� .��Unreal�� -   $ HighestRankHeaderBuild��$��Highest Rank (Build)��$
��14.5(�
�������$��	5,68,5,41q�$
��Bold"�#��[  �� -   $ highestRankBuildBox��#��[ ���	#FF0E0E0E$��1q�
����������	#FF373738$��5,95,5,0q�$	��Top=�.@��� .��
Bronze 1�� .��
Bronze 2�� .��
Bronze 3�� .��
Silber 1�� .��
Silber 2�� .��
Silber 3�� .��Gold 1�� .��Gold 2�� .��Gold 3�� .��
Platin 1�� .��
Platin 2�� .��
Platin 3�� .��	Diamond 1�� .��	Diamond 2�� .��	Diamond 3�� .��Elite�� .��
Champion�� .��Unreal�� -   $&
  RankBuildPercentageCustomization��$��190,157,629,179q����#18191d���#272932$��3q�$ 1��$ 0.5,0.5&�z�V� .~��� �� �� T� ._�� .+��� -   $ BuildPercentageHeader��$��Rank % (Build)��$��18(�
�������$��5,3,5,40q�$
��Bold"�#��[    Wpf.Ui.Controls.NumberBox  -     Name$ BuildPercentageBox��#��[ ���	#FF0E0E0E$��1q�
����������	#FF373738$
 True��$	 182��$��5,31,5,0q�$	��Top=�$ IBeam��   Icon$ DocumentPercent24=�   DecimalPlaces$ 0��
   Max$	 100Q�
   Min$ 0Q��� -   $
 RankNoBuildCustomization��$��370,10,449,261q����#18191d���#272932$��3q�$ 1��$ 0.5,0.5&�z�V� .~��� �� �� T� ._�� .+��� -   $ CurrentRankHeaderNoBuild��$��Current Rank (No Build)��$��13(�
�������$��
5,2,-6,112q�$
��Bold"�#��[  �� -   $ currentRankNoBuildBox��#��[ ���	#FF0E0E0E$��1q�
����������	#FF373738$��5,29,5,0q�$	��Top=�.@��� .��
Bronze 1�� .��
Bronze 2�� .��
Bronze 3�� .��
Silber 1�� .��
Silber 2�� .��
Silber 3�� .��Gold 1�� .��Gold 2�� .��Gold 3�� .��
Platin 1�� .��
Platin 2�� .��
Platin 3�� .��	Diamond 1�� .��	Diamond 2�� .��	Diamond 3�� .��Elite�� .��
Champion�� .��Unreal�� -   $ HighestRankHeaderNoBuild��$��Highest Rank (No Build)��$
��12.5(�
�������$��	5,68,5,41q�$
��Bold"�#��[  �� -   $ highestRankNoBuildBox��#��[ ���	#FF0E0E0E$��1q�
����������	#FF373738$��5,95,5,0q�$	��Top=�.@��� .��
Bronze 1�� .��
Bronze 2�� .��
Bronze 3�� .��
Silber 1�� .��
Silber 2�� .��
Silber 3�� .��Gold 1�� .��Gold 2�� .��Gold 3�� .��
Platin 1�� .��
Platin 2�� .��
Platin 3�� .��	Diamond 1�� .��	Diamond 2�� .��	Diamond 3�� .��Elite�� .��
Champion�� .��Unreal�� -   $(
 "RankNoBuildPercentageCustomization��$��370,157,449,179q����#18191d���#272932$��3q�$ 1��$ 0.5,0.5&�z�V� .~��� �� �� T� ._�� .+��� -   $ NoBuildPercentageHeader��$��Rank % (No Build)��$��17(�
�������$��5,3,5,40q�$
��Bold"�#��[    -   $ NoBuildPercentageBox��#��[ ���	#FF0E0E0E$��1q�
����������	#FF373738$
 True��$	 182��$��5,31,5,0q�$	��Top=�$ IBeam��$ DocumentPercent24=�$ 0��$	 100Q�$ 0Q��� -   $
 ProfileContainer��$��10,329,745,10q����#18191d���#272932$��3q�$ 1��$ 0.5,0.5&�z�V� .~��� �� �� T� ._�� .+��� $��0��$y�Hidden=�$��60��$��60��$ 20��$��10,14,190,15q����� -   FortnitePicture���� -   $ LoggedInHeader��#��[  $��Logged in as:��
�������$��	10,6,5,29q�$
��Bold"�$��22(��� -    ��Name$ LoggedInName��#��[ $��Epic Name lololol��$
��Wrap=�$��10,39,10,12q����	#FF908B8B$��14(�  Wpf.Ui.Controls.Button  -      Name$ loginButton��#��[ $
 Hand��   
Appearance$ Primary=�   Icon$ Person24=�$��Login��$��837,334,0,0q�$	��Top=�$	��147��$ 0.5,0.5&�z�V� .~��� �� �� T�   -!   $ 
saveButton��#��[ $
 Hand��$ Primary=�$ Save24=�$
��Save��$��837,371,0,0q�$	��Top=�$	��147��$ 0.5,0.5&�z�V� .~��� �� �� T� � -"   $	 loadingGrid��$y�Hidden=�.+�� -#    �Name$ progressBar��$��Center=� � IsIndeterminate$
 True��$	��350��$ 0.5,0.5&�z�V� .~��� �� �� T� �� -$   $ loadingLabel��$��
Loading...�� �� TextAlignment$ Center=�$
��Wrap=�
�������$��322,218,322,109q�$ 0.5,0.5&�z�V� .~��� �� �� T� � -%   $	 notificationContainer��$	��222��$��77��$��762,10,10,326q�
   M S B A M L   `   `   `  ����C  ?Mythodex, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Mythodex.ViewMythodex.View  5      7 clr-namespace:Mythodex.ViewModelMythodex.ViewModel  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5	          Mythodex.View.Week   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      a ]GongSolutions.WPF.DragDrop, Version=3.0.0.0, Culture=neutral, PublicKeyToken=91f1945125b7a587ddurn:gong-wpf-dragdrop  5      'localclr-namespace:Mythodex.View  5      )vm clr-namespace:Mythodex.ViewModel  5      0sys&clr-namespace:System;assembly=mscorlib  5	      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5
        N� Title$
  Week��5       � 	Resources 5      +   %Mythodex.ViewModel.MaxHeightConverter   MaxHeightConverter  MaxHeightCalebrate �� 
TargetType  WeekTaskStyle �� Property �� Value  CompleteFlagButton �� 
TargetType ��Name �� CornerRadius F�Name	 �� Stretch
 �� Triggers P� Property P� Value �� 
TargetName  
EditButton A�Name  TitleTextBox �� Triggers :� RoutedEvent �� TargetProperty �� KeyTime �� Value	 �� To g� Duration  DescriptionTextBox  WeekGridStyle  WeekGridLabelStyle 	 WeekGridListBoxStyle)  #GongSolutions.Wpf.DragDrop.DragDrop �� Padding � RowDefinitions � ColumnDefinitions J� IsHitTestVisible �� RelativeSource �� AncestorType ��Name �� Path.  (System.Windows.Interactivity.Interaction   Triggers/  )System.Windows.Interactivity.EventTrigger   	EventName.  (System.Windows.Interactivity.TriggerBase    Actions6  0System.Windows.Interactivity.InvokeCommandAction!   Command 
 AddTaskButtonStyle  
BaseButton" �� BasedOn��%a  &	        &	      &	 -     &	 7    &	 2    &	     &	 F
    &	 o    &	 R    &		 �    7  7  7  7  &	
      7    5   
   6    ��5   
   60��63   �� 5   
   " ��6   .�5      ��  � ��$ Lorem ipsum��6%   �� 5       � ��$
 Auto��6'   �� 5       � ��$	 260��6&   �� 5       � ��$	 Top=�62   �� 5       � ��
 �����6+   �� 5       � ��$ 5q�6'   5      �� 5   
   " ��6   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� $ Bd��6!   
������ $ 90��5   !   ._�5       F� $ Pt��6#   =����        �@ @ � 5  5 �@  5 � 5 @ �@B @B 	$	 Uniform=�5!      
���   �$��2��68   5"      
 5#      P� 5$       �@J�IsMouseOver$
 True��6=   . �5&   "   �� $ Bd��6)    � �� �	#A0FF00006O   �� 5'   "   $ Pt��6)    � ��
 �����6K   5(      5*      5,      5-      �� 5.   
   " ��6   .�5/      ��  � �� 50      �� 51      " ��6&   .R�52      �� $ Bd��6!   
������ ._�53      � .+�54   "   A� $ St��6*   $��12��66   $��12��6A   ���	#800000006M   A� 55   "   $ Pt��6*   $��8��66   $��8��6@   ��6K   �� *PriorityColor+56      57      
 58      P� 59       �@J�IsMouseOver$
 True��6=   . �5:   "   �� $ Pt��6)    � �� �	#B00000FF6K   5;      5=      5?      5@      �� 5A   
   " ��6   .�5B      ��  � ��$
 Left=�64   �� 5C       � ��$ Center=�62   �� 5D       � ��$8 2pack://application:,,,/View/Resources/#NoirPro ☞)�6+   �� 5E       � ��$ 16(�6)   �� 5F       � ��$ Normal$�6*   �� 5G       � ��$ Normal"�6+   �� 5H       � ��$ 0,0,0,0q�6'   �� 5I       � ��
 �����6+   �� 5J       � ��
 ���� 6+   �� 5K       � ��$ 0q�60   �� 5L       �@��TextWrapping$
 Wrap=�6-   �� 5M       �@��
IsReadOnly$
 True��6+    5N      :� 5O      $ MouseDoubleClick��6   [�5P      �� 5Q      .��5R      �� .��5S   "   �� $ 
IsReadOnly�6A   .p�5T   &   s� $ 0:0:0��6>   $ False��6N   5U   #   �� 5V   "   $ Background.Color�61    	#B0FFFFFF5W   )   $ 0:0:1D�68   �� 5X   "   $ Foreground.Color�61   	 Black5Y   )   $ 0:0:1D�64   5Z      5[      5]      :� 5^      $ 	LostFocus��6   [�5_      �� 5`      .��5a      �� .��5b   "   �� $ 
IsReadOnly�6A   .p�5c   &   s� $ 0:0:0��6>   $
 True��6N   5d   #   �� 5e   "   $ Background.Color�61    Transparent5f   )   $ 0:0:1D�6:   �� 5g   "   $ Foreground.Color�61    
WhiteSmoke5h   )   $ 0:0:1D�69   5i      5j      5l      5n      �� 5o   
   " ��6   .�5p      ��  � ��$
 Left=�64   �� 5q       � ��$ Center=�62   �� 5r       � ��$8 2pack://application:,,,/View/Resources/#NoirPro ☞)�6+   �� 5s       � ��$ 14(�6)   �� 5t       � ��$ Normal$�6*   �� 5u       � ��$ Light"�6+   �� 5v       � ��$ 0,0,0,0q�6'   �� 5w       � ��
 �����6+   �� 5x       � ��
 ���� 6+   �� 5y       � ��$ 0q�60   �� 5z       �@��TextWrapping$
 Wrap=�6-   �� 5{       �@��
IsReadOnly$
 True��6+    5|      :� 5}      $ MouseDoubleClick��6   [�5~      �� 5      .��5�      �� .��5�   "   �� $ 
IsReadOnly�6A   .p�5�   &   s� $ 0:0:0��6>   $ False��6N   5�   #   �� 5�   "   $ Background.Color�61    	#B0FFFFFF5�   )   $ 0:0:1D�68   �� 5�   "   $ Foreground.Color�61   	 Black5�   )   $ 0:0:1D�64   5�      5�      5�      :� 5�      $ 	LostFocus��6   [�5�      �� 5�      .��5�      �� .��5�   "   �� $ 
IsReadOnly�6A   .p�5�   &   s� $ 0:0:0��6>   $
 True��6N   5�   #   �� 5�   "   $ Background.Color�61    Transparent5�   )   $ 0:0:1D�6:   �� 5�   "   $ Foreground.Color�61    
WhiteSmoke5�   )   $ 0:0:1D�69   5�      5�      5�      5�      �� 5�   
   " �6   .�5�      ��  � ��$	 Top=�62   �� 5�       � ��$ 5q�6'   �� 5�       � ��$	 260��6&   �� 5�       � ��$
 Auto��6'   �� 5�       � �� �	#300000006+   5�      �� 5�   
   " ��6   .�5�      ��  � ��$ 12(�6)   �� 5�       � ��
 �����6+   �� 5�       � ��$8 2pack://application:,,,/View/Resources/#NoirPro ☞)�6+   �� 5�       � ��$
 Bold"�6+   �� 5�       � ��$ Center=�64   �� 5�       � ��$ Center=�62   5�      �� 5�   
   " ��6   .�5�      ��  � ��$ 0q�6'   �� 5�       � ��$ 20��6*   �� 5�       � �� �	#20FFFFFF6+   �� 5�       � ��$ 0q�60   �� 5�       � ��$ False��6>   �� 5�       � ��$ Disabled=�6K   �� 5�       �@ IsDragSource$
 True��69   �� 5�       �@ IsDropTarget$
 True��69   �� 5�       �@ UseDefaultDragAdorner$
 True��6B   �� 5�       � �� 5�      �� 5�      " ��6   .�5�      ��  � �� 5�      �� 5�   "   " ��62   .R�5�   &   �� 
������ 
������ $��0q�5�   -   $ 0q�5�   -   ._�5�   *   �� 5�   '   5�   #   5�      5�      5�      �� 5�       � �� 5�      �� 5�      .R�5�      � $	��240��6   $��0,15,0,0q�5�      
������ $��Disabled=�5�   !   $��Disabled=�5�   !    5�      �� 5�   "   �� 5�   "   .+�5�      � $��0��6#   $��0,0,0,5q�5�   #   $
��Auto��5�   #    5�   "   �� 5�   &   $��30 �67   �� 5�   &   $��* �67   .+�5�   "   �� $��20��6)   $��20��5�   )   $��0,3,0,0q�5�   )   8��  $
 True��5�   )   $	��Top=�5�   )   $��Center=�5�   )   $��0��5�   )   ��5�   )   �� *DataContext.DeleteCommand+ �� " ����5�   )   �� 5�   #   �� 5�   "   $��20��6)   $��20��5�   )   $��0,25,0,0q�5�   )   $
 True��5�   )   $	��Top=�5�   )   $��Center=�5�   )   $��0��5�   )   8�� ��5�   )   �� *#!DataContext.ChangePriorityCommand+ �� " ����5�   )   �� �� 5�   "   $��1��6-   $
��Auto��5�   -   .+�5�   &   �� $ textBox��5�   .   8�� ��5�   .   �� $ Title�.��5�   ?    5�   *     5�   .   $ 	LostFocus��6=   .  5�   2     ! 6H   �� *DataContext.SaveCommand+ �� " ��5�   /   .��5�   B   5�   '   �� 5�   &   8�� ��6.   �� $ Description�.��5�   Z    5�   *     5�   .   $ 	LostFocus��6=   .  5�   2     ! 6H   �� *DataContext.SaveCommand+ �� " ��5   /   .��5  B   5  '   5  #   5     �� 5     $��Bottom=�6(   $��Stretch=�5  (   $��2��5  (   ���	#60000000$��1��5	  (   5
     5     5     5     �� 5  
   " ��6   8"   .�5     ��  � �� 6(   �� *NewTaskCommand+�� 5      � ��$ 2��6)   �� 5      � ��$ 5q�6'   �� 5      � ��$ Новая задача��6(   5     5     .��5     � .+�5  
   �� $
��Auto��6   $
��Auto��5     $
}�True��5     $��Center=�5     $��1��5     .+�5     �� # �� Orientation$# 
Horizontal=�6   $��Center=�5      5       DataTextBox��%�  &	       �� 5     " ��6   .�5      ��  � ��
 �����67   �� 5!      � ��$8 2pack://application:,,,/View/Resources/#NoirPro ☞)�67   �� 5"      � ��$ 16(�65   �� 5#      � ��$ Normal$�66   �� 5$      � ��$ Normal"�67   �� 5%      � ��$
 Auto��62   �� 5&      � ��$ Center=�6>   �� 5'      � ��$ Center=�6@   5(     5)     .+�5*     �� $��L��6   $��20��5+     $��20��5,     $��0,0,10,0q�5-       RoundedBaseButton#��[ 5.     $��0��50     ��5/     �� *DateSwitchCommand+50     �� 51     #��[ 6   $ �� TextAlignment$$ Right=�55     ��52     �� *FirstDayWeekDate+% �� StringFormat$%  {0:D}��& �� ConverterCulture$& ru-RU��55     �� 56     #��[ 6   $��-��57     �� 58     #��[ 6   $
$ Left=�5<     ��59     �� *LastDayWeekDate+$%  {0:D}��$& ru-RU��5<     �� 5=     $��R��6   $��20��5>     $��20��5?     $��10,0,0,0q�5@     #��[ 5A     $��1��5C     ��5B     �� *DateSwitchCommand+5C     5D     �� 5E     -   5        $��Disabled=�5E     $��Hidden=�5F     $��Center=�5H     $
��Auto��5I     .��5J     �� $# 
Horizontal=�6   ��5K     �� $ ActualHeight� �� *FindAncestor+" N�' �� 	Converter#' [  ( �� ConverterParameter#( [ .+�5Q     � #��[ 6    5R     �� 5S     $��30 �6,   �� 5T     $��* �6,   �� 5U     $��30 �6,   .+�5W     �� $��Понедельник��6    $��0��5X      #��[ 5Y      �� 5Z     $��1��6"   #��[	 5[  %   ��5\  %   �� *MondayItems+5^     �� 5_     #��[
 6!   $��MondayItems��5`  !   5a     � 5c     #��[ 6    5d     �� 5e     $��30 �6,   �� 5f     $��* �6,   �� 5g     $��30 �6,   .+�5i     �� $��Вторник��6    $��0��5j  !   #��[ 5k  !   �� 5l     $��1��6"   #��[	 5m  %   ��5n  %   �� *TuesdayItems+�� 5o     #��[
 6!   $��TuesdayItems��5p  !   5q     � 5s     #��[ 6    5t     �� 5u     $��30 �6,   �� 5v     $��* �6,   �� 5w     $��30 �6,   .+�5y     �� $��
Среда��6    $��0��5z  !   #��[ 5{  !   �� 5|     $��1��6"   #��[	 5}  %   ��5~  %   �� *WednesdayItems+�� 5     #��[
 6!   $��WednesdayItems��5�  !   5�     � 5�     #��[ 6    5�     �� 5�     $��30 �6,   �� 5�     $��* �6,   �� 5�     $��30 �6,   .+�5�     �� $��Четверг��6    $��0��5�  !   #��[ 5�  !   �� 5�     $��1��6"   #��[	 5�  %   ��5�  %   �� *ThursdayItems+�� 5�     #��[
 6!   $��ThursdayItems��5�  !   5�     � 5�     #��[ 6    5�     �� 5�     $��30 �6,   �� 5�     $��* �6,   �� 5�     $��30 �6,   .+�5�     �� $��Пятница��6    $��0��5�  !   #��[ 5�  !   �� 5�     $��1��6"   #��[	 5�  %   ��5�  %   �� *FridayItems+�� 5�     #��[
 6!   $��FridayItems��5�  !   5�     � 5�     #��[ 6    5�     �� 5�     $��30 �6,   �� 5�     $��* �6,   �� 5�     $��30 �6,   .+�5�     �� $��Суббота��6    $��0��5�  !   #��[ 5�  !   �� 5�     $��1��6"   #��[	 5�  %   ��5�  %   �� *SaturdayItems+�� 5�     #��[
 6!   $��SaturdayItems��5�  !   5�     � 5�     #��[ 6    5�     �� 5�     $��30 �6,   �� 5�     $��* �6,   �� 5�     $��30 �6,   .+�5�     �� $��Воскресенье��6    $��0��5�  !   #��[ 5�  !   �� 5�     $��1��6"   #��[	 5�  %   ��5�  %   �� *SundayItems+�� 5�     #��[
 6!   $��SundayItems��5�  !   5�     5�     5�     5�     5�     5�     
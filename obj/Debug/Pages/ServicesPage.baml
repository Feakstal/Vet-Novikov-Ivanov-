   M S B A M L   `   `   `  ����>  :Vet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Vet.Pages	Vet.Pages  5          Vet.Pages.ServicesPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:Vet.Pages     5        N� Title$  Сервисы��5	      .��5
      �  � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $
��7.5* �6   �� 5      $
��1.5* �6   .+�5   
   �� $��0��6   $
��left=�6"   $��	0 0 150 0q�6=    �� Orientation$ 
Horizontal=�6P   .+�5      �� $#��Список сервисов��6   $��5q�6/      tbTitlePage#��[  6:   5      � 5   
   $��0��6   $��Right=�6!   $	��Top=�6=   $��10 0 0 0q�6U   .+�5      � .+�5      �� -   5         ��Name$ 
tboxSearch��5        tbAuthWindow#��[ 6.   $��Center=�6T   $��Center=�6x   $	��250��6�   .��6�    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 4Q�6+      	Direction$	 270Q�6;      ShadowDepth$ 3Q�6K      Color$ 	LightGray��6[   .��5   &   5      �� 5      	 J� IsHitTestVisible	 .  $��
Поиск��65   $��14(�6B   $	��Top=�6P   $��Center=�6h   $��0 5 0 0q�6�   ��5      �� 5      
 �� 
TargetType"
 ��6    .�5      ��  �� Property � y� �� Value$ 	Collapsed=�6;    �� Triggers 5      �� 5   "    �� Binding 6.   �� *Text+ �� ElementName$ 
tboxSearch�� �� Value  6_   .a�5    &   ��  � y�$ Visible=�6C   �� 5!   &    � ��
 �����6C   5"   #   5$      5&      5'      5(      � 5)   
   $��Center=�6   $��2��61   .+�5*      �� -   5         ��Name$ btnAddServiceWindow��5*        btnAllPandW#��[ 62   $#��Добавить запись��6W   $��	0 10 15 0q�6�    5+        5,      $ 4Q�6'   $	 270Q�66   $ 3Q�6F   $ 	LightGray��6V    � 	Resources 5.      ��%^   '��       �� 5/      "
 ��6   .�50      ��  �@��CornerRadius$ 5��69   51      52      53      �� 54      -   5        $ 	btnDelete��54      #��[ 6(   $!��Удалить запись��6M   $��	0 10 15 0q�6~    55        56      $ 4Q�6'   $	 270Q�66   $ 3Q�6F   $ 	LightGray��6V    58      ��%^   '��       �� 59      "
 ��6   .�5:      ��  �@��CornerRadius$ 5��69   5;      5<      5=      �� 5>      -   5        $ btnSave��5>      #��[ 6&   $��Сохранить��6K   $��	0 10 15 0q�6u    5?        5@      $ 4Q�6'   $	 270Q�66   $ 3Q�6F   $ 	LightGray��6V    5B      ��%^   '��       �� 5C      "
 ��6   .�5D      ��  �@��CornerRadius$ 5��69   5E      5F      5G      �� 5H      -   5        $ 	btnGoBack��5H      #��[ 6(   $��Главное меню��6M   $��0 10 0 0q�6|    5I        5J      $ 4Q�6'   $	 270Q�66   $ 3Q�6F   $ 	LightGray��6V    5L      ��%^   '��       �� 5M      "
 ��6   .�5N      ��  �@��CornerRadius$ 5��69   5O      5P      5Q      5R      &   System.Windows.Controls.DataGrid  5S   
   -   5          Name$ ServicesGrid��5S         AutoGenerateColumns .  $��1��6e   $��Stretch=�6r      
IsReadOnly .  ��6)   �� *	Service+   Columns 5T      0  *System.Windows.Controls.DataGridTextColumn  5U      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Номер��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *	IDService+  5V      $ Услуга��6%    65   �� *ServiceName+  5W      $ Цена��6%    63   �� *Price+  5X      $+ %Длительность сеанса��6%    6B   �� *Length+  5Y      $ Удален��6%    65   �� *	IsDeleted+5[      5\      5]      
   M S B A M L   `   `   `  ����>  :Vet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Vet.Pages	Vet.Pages  5          Vet.Pages.ChequesPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:Vet.Pages     5        N� Title$&   Услуги и расценки��5	      .��5      �  � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $
��7.5* �6   �� 5      $
��1.5* �6   .+�5   
   �� $��0��6   $
��left=�6"   $��	0 0 150 0q�6=    �� Orientation$ 
Horizontal=�6P   .+�5      �� $��Архив чеков��6   $��5q�6+      tbTitlePage#��[  66   5      � 5   
   $��0��6   $��right=�6!   $��	0 0 150 0q�6=   .+�5      � .+�5      �� -   5         ��Name$ Search��5        tbAuthWindow#��[ 6*   $��Right=�6P   $��Center=�6s   $	��Top=�6�   $	��250��6�   .��6�    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 4Q�6+      	Direction$	 270Q�6;      ShadowDepth$ 3Q�6K      Color$ 	LightGray��6[   .��5   &   5      �� 5      	 J� IsHitTestVisible	 .  $6��0Поиск в реальном времени...��65   $��14(�6X   $	��Top=�6f   $��Center=�6~   $��0 5 0 0q�6�   ��5      �� 5      
 �� 
TargetType"
 ��6    .�5      ��  �� Property � y� �� Value$ 	Collapsed=�6;    �� Triggers 5      �� 5    "    �� Binding 6.   �� *Text+ �� ElementName$ Search�� �� Value  6[   .a�5!   &   ��  � y�$ Visible=�6C   �� 5"   &    � ��
 �����6C   5#   #   5%      5'      5(      5)      �� 5*   
   $��Center=�6   $��2��62   $ 
Horizontal=�6?   .+�5+      �� -   5         ��Name$ 	btnGoBack��5+        btnAllPandW#��[ 6(   $��
Назад��6M    5,        5-      $ 4Q�6'   $	 270Q�67   $ 3Q�6G   $ 	LightGray��6W    � 	Resources 5/      ��%^   '��       �� 50      "
 ��6   .�51      ��  �@��CornerRadius$ 5��69   52      53      54      55      &   System.Windows.Controls.DataGrid  56   
   -   5          Name$ ChequesGrid��56         AutoGenerateColumns .  $��1��6c   $��Stretch=�6p      
IsReadOnly .    CanUserAddRows .  ��6(   �� *Cheque+   Columns 57      0  *System.Windows.Controls.DataGridTextColumn  58      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Номер��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *
IDClient+ �� TargetNullValue$ (отсутствует)��  59      $ Цена��6%    63   �� *Price+$ (отсутствует)��  5:      $ Номер записи��6%    6;   �� *IDApp+$ (отсутствует)��  5;      $ Дата-время��6%    69   �� *
ChequeDate+$ (отсутствует)��  5<      $ Адрес филиала��6%    6<   �� *
DepAddress+$ (отсутствует)��5>      5?      5@      
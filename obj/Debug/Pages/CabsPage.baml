   M S B A M L   `   `   `  ����>  :Vet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Vet.Pages	Vet.Pages  5          Vet.Pages.CabsPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:Vet.Pages     5        N� Title$  Кабинеты��5	      .��5
      �  � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $
��7.5* �6   �� 5      $
��1.5* �6   .+�5   
   �� $��0��6   $
��left=�6"   $��	0 0 150 0q�6=    �� Orientation$ 
Horizontal=�6P   .+�5      �� $��Кабинеты��6   $��5q�6(      tbTitlePage#��[  63   5      � 5   
   $��1��6    5      �� 5      $��1* �6    �� 5      $��1* �6    .+�5      �� $��0��6   $��
2 этаж��6)     tbFloors#��[ 69   $��15q�6[   �� 5      $��1��6   $��Stretch=�6)   $ 
Horizontal=�6E   .+�5      �� $��1��6   $��
1 этаж��6-   #��[ 6=   $��15q�6_   �� 5      -   5         ��Name$ CabsList��5      $
��auto��6-   $
��auto��6:    �� View 5      �� 5      .P�5      �� $��Кабинет��6-    �� CellTemplate 5   "   �� 5    &   .R�5!   *   ��  ��Name$ btnCab��61   -   5          btnCabs#��[ 5!   A   $��№кабинета��6b    J� Effect 5"   .   3  -System.Windows.Media.Effects.DropShadowEffect  5#   2      
BlurRadius$ 4Q�6C   	   	Direction$		 270Q�6S   
   ShadowDepth$
 3Q�6c      Color$ 	LightGray��6s    � 	Resources 5%   .    �� 
TargetType �� Property �� Value��%^   '��       �� 5&   2   " ��68   .�5'   6   ��  �@��CornerRadius$ 5��6U   5(   3   5)   /   5*   +   5+   '   5-      55      57      58      59      �� 5:   
   $��Center=�6   $��2��62   $ 
Horizontal=�6?   .+�5;      �� -   5        $ 	btnGoBack��5;        btnAllPandW#��[ 6(   $��
Назад��6M    5<        5=      $ 4Q�6'   $		 270Q�67   $
 3Q�6G   $ 	LightGray��6W    5?      ��%^   '��       �� 5@      " ��6   .�5A      ��  �@��CornerRadius$ 5��69   5B      5C      5D      5E      5F      5G      
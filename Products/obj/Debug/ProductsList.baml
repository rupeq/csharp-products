   M S B A M L   `   `   `  ����C  ?Products, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:ProductsProducts  5          Products.ProductsList   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:Products     5      b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	        N� Title$  ProductsList��5
      .��5      � -   5         �Name$ TableContent��5      
������� � ColumnDefinitions 5   
   �� 5      �� 5      $
��Auto �6   $	��776��6,   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��ProductsTable��5      $
��Left=�5      $	��502��5      $��	28,40,0,0q�5      $	��Top=�5      $	��835��5         CanUserReorderColumns .     CanUserResizeColumns .     CanUserSortColumns .     AutoGenerateColumns .    
IsReadOnly . $��2��5      ��5      �� *PCollection+   Columns 5#      0  *System.Windows.Controls.DataGridTextColumn  5$      ,  &System.Windows.Controls.DataGridColumn	   Header$!	 Группа товаров��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 170 5%   %   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5&   %   �� *	GroupName+  5'      $	 Наименование��6%   $	
 170 5(   %    5)   %   �� *ProductName+  5*      $	 Изготовитель��6%   $	
 170 5+   %    5,   %   �� *Maker+  5-      $'	 !Дата изготовления��6%   $	
 180 5/   %    5.   %   �� *ProductionDate+5/   %     50      $	 Срок годности��6%   $	
 150 51   %    52   %   �� *
ExpiryTime+54      � 55   
   -   5        $ Buttons��55      $��0,0,159.2,0.4q�6    .+�56      �� -   5         ��Name$ PlusBtn��5=      $��+��56      $
��Left=�57      $��878,40,-921,0q�58      $	��Top=�59      $��43��5:      $��1��5;      5=      �� 5>      -   5        $ 	DeleteBtn��5D      $��-��5>      $
��Left=�5?      $��878,105,-921,0q�5@      $	��Top=�5A      $��43��5B      $��1��5C      5D   (   �� 5E      -   5        $ SerializeBtn��5K      $��S��5E      $
��Left=�5F      $��878,243,-921,0q�5G      $	��Top=�5H      $��43��5I      $��1��5J      5K   +   �� 5L      -   5        $ DeserializeBtn��5S      $��DS��5L      $
��Left=�5M      $��878,318,-921,0q�5N      $	��Top=�5O      $��43��5P      $��	10,4,16,4q�5Q      $��1��5R      5T      �� 5U      -   5        $ ApplyBtn��5\      $y�	Collapsed=�5U      $��A��5V      $
��Left=�5W      $��878,40,-921,0q�5X      $	��Top=�5Y      $��43��5Z      $��1��5[      5]      �� 5^      -	   5        $ 	UpdateBtn��5d      $��U��5^      $
��Left=�5_      $��878,174,-921,0q�5`      $	��Top=�5a      $��43��5b      $��1��5c      5e      �� 5f      -
   5        $ DateBtn��5m      $
��Left=�5f      $��878,472,-921,0q�5g      $	��Top=�5h      $��43��5i      $��	10,4,16,4q�5j      $��1��5k      $��42��5n      ��5l      Z� ��5p      �� 5q       �� ImageSource$ Assets/calendar.png��6!   5s      5t      � 5u   
   $��0,0,72.2,0.4q�6   $��2��6%   .+�5v      �� -   5         ��Name$ 
SearchText��5v      $
��Left=�6*   $��23��6E   $��28,9,0,0q�6Q    �� TextWrapping$
 Wrap=�6c   $�� ��6w   $	��Top=�6   $	��835��6�   5w       � 5z   
   -   5          �Name$ CreateFrame��5z      $��28,10,72.2,0.4q�6%   $��2��6=   �� 5{   
   -   5        $ 	SearchBtn��5{      $��707.8,10,72.2,521.4q�5|      $
��Auto��5}       J� RenderTransformOrigin$ 1.963,0.417&�5�      $��1��69   ��5~      Z� ��5�      �� 5�      $ Assets/search.png��6   ��5�      �� 5�      $ Assets/search.png��6   5�      5�      5�      
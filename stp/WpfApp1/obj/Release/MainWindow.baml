   M S B A M L   `   `   `  ���� B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1      WpfApp1.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     'localclr-namespace:WpfApp1     -     � Title$(  "Equery - Интерфейс СТП��$��309.235��$��848.451��$��DIN Condensed)� � 
ResizeMode$ NoResize=�.��� $��0,0,-8,6q�.+��� $��25(�$��В очереди: ��$
��Left=�$	��259��$��	10,10,0,0q�$	��Top=�$	��212��.���� -    ��Name$ query_tb��$
��Left=�$	��221�� �� TextWrapping$
 Wrap=�$�� ��$	��Top=�$	��202��$��0,0,-2,0q�$��Center=� �� 
IsReadOnly . �� $��25(�$#��Сейчас в работе:��$
��Left=�$	��127��$��
227,10,0,0q�$	��Top=�$	��380��.��� -   $	��Cur��$
��Left=�$��88��$��0,0,-2,0q�$	��Top=�$	��370�� � ShowGridLines .   � RowDefinitions �� ��  � ColumnDefinitions �� �� �� .+��� -   $��1��$��0��$��Открыть��$��Stretch=�$��Stretch=�$	��122��$��40���� -   $��1��$��1��$��Отложить��$��Stretch=�$��Stretch=�$	��122��$��40���� -   $��1��$��2��$��Решить��$��Stretch=�$��Stretch=�$	��122��$��40���� -   $ current_req_tb��$��0��$��Stretch=�$��Stretch=�$��RFS123456_7890��$��Center=�$��Center=�$��3���� $��25(�$+��%Следующая в очереди:��$
��Left=�$	��127��$��227,142,0,0q�$	��Top=�$	��380��.���� -   $ next_req_tb��$
��Left=�$��45��$
 Wrap=�$��RFS123456_7890��$	��Top=�$	��370��$��0,0,-2,0q�$��Center=� . �� -	    ��Name$ solve_bt_Copy��$ ��Взять в работу��$
��Left=�$��235,222,0,0q�$	��Top=�$	��366��$��42��$��25(��� $��25(�$��Отложенные:��$
��Left=�$	��259��$��
612,10,0,0q�$	��Top=�$	��212��.���� -
   $ postponed_tb��$
��Left=�$	��221��$
 Wrap=�$�� ��$	��Top=�$	��202��$��0,0,-2,0q�$��Center=� . 
   M S B A M L   `   `   `  ����J  FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1  5   	   !    WpfApplication1.ldap_search   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfApplication1     5   	     � Title$  ldap_search��5   	    � WindowStartupLocation$ CenterScreen=�6    � WindowStyle$
 None=�6C    � 
ResizeMode$ NoResize=�6V    � ShowInTaskbar .   � AllowsTransparency .    found_by_ldap#��[  6�   .��5      � $	��812��6   $	��541��6   .+�5   
   �� $��Имя��6   $��73, 60, 682, 449q�6   $��20(�68   ���#9999996]   �� 5   
   -   5         ��Name$ fio_tb��5      $��29(�6"   $
��Bold"�60   $��73, 96, 73, 365q�6B   $'��!Уга буга шуга дуга��6[   ���#333333$��0q�6�   
������ $	��665��6�   $��80��6�    �� 
IsReadOnly . 6�   �� 5   
   $
��LDAP��6   $��73, 210, 677, 293q�6   ���#999999$��20(�6O   6_   �� 5   
   -   5        $ ldap_tb��5      $��20(�6#   $��60000000��61   ���#333333$��0q�6V   
������ $	��109��6�   $��32��6�   $��73, 252, 629, 257q�6�   6�   �� 5   
   $��Должность��6   $��273, 210, 364, 293q�6$   ���#999999$��20(�6U   6e   �� 5   
   -   5        $ title_tb��5      $��20(�6$   $8��2Самый крутой отдел на свете��62   ���#333333$��0q�6j   
������ $	��465��6�   $��274,252,73,225q�6�    �� TextWrapping$
 Wrap=�6�   "	 �� VerticalScrollBarVisibility$	 Hidden=�5      
 �� AcceptsReturn
 . 5      �� 5   
   -   5          miss#��[ 5      $!��Нет, это ошибка��6/   $��106, 381, 422, 50q�6I   6}   �� 5   
   -   5          confirm_user#��[ 5      $��Да, это я��67   $��422, 381, 106, 50q�6K   6   5      5      
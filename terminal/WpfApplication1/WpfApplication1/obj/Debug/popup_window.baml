   M S B A M L   `   `   `  ����J  FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1  5   	   "    WpfApplication1.popup_window   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfApplication1     5   	   U QWpfAnimatedGif, Version=2.0.0.0, Culture=neutral, PublicKeyToken=9e7cd3b544a090dc,gif"http://wpfanimatedgif.codeplex.com  5   	     � Title$  popup_window��5	   	    � WindowStartupLocation$ CenterScreen=�6    � 
ResizeMode$ NoResize=�6C   $��Roboto)�6Y    � WindowStyle$
 None=�6m   $��1q�6�      Popup_window_style#��[  6�    � AllowsTransparency . .��5
      � .+�5   
   �� -   5        $��textbox_main��5      $��Center=�6&    �� 
IsReadOnly . $��80��6U    �� TextWrapping$
 Wrap=�6a   $��TextBox��6u   $	��Top=�6�   $	��812��6�   $��0,342,0,317q�6�   $ �� HorizontalScrollBarVisibility$ Hidden=�6�   $��Center=�6�   $
��Bold"�6  $��34(�6  $��0q�6(  �� 5   
   -   5        $��textbox_secondary��5      $	��lol��6+    . $
 Wrap=�6H   {�.  $��Center=�6n   $��0q�6�   $��102,446,74, 219q�6�   $ Hidden=�6�   $��Center=�6�   $��Center=�6�   $	��636��6  $��74��6*  $��26(�66  6D  �� 5   
   -   5         ��Name$ button��5      $��left_btn��6!     miss#��[ 64   $��106, 579, 422, 50q�6g   $��Center=�6�   	 K� ZIndex$	 	100000000��6�   �� 5   
   -   5        $ confirm_button��5      $��	right_btn��6)     confirm_user#��[ 6=   $��422, 579, 106, 50q�6�   $��Center=�6�   $	 100000��6�   �� 5   
   -   5        
 ��Name$	
 img��5      $	��290��6   $	��290��6)   $��261, 0, 261, 456q�66   �� 5   
   -   5        $
 gf��5      "  WpfAnimatedGif.ImageBehavior   AnimatedSource$ /Resources/91.gif��6   $	��100��6Q   $	��100��6]   $��Bottom=�6j   $��356, 0,356,200q�6�   $y�Hidden=�6�   5      5      
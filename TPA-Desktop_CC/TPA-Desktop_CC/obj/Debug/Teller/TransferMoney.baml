   M S B A M L   `   `   `  ����I  ETPA-Desktop_CC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:TPA_Desktop_CCTPA_Desktop_CC  5   	   "    TPA_Desktop_CC.TransferMoney   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:TPA_Desktop_CC     5   	     � Title$%  Kong Bu Bank（孔布 银行）��5   	   $��355.138��6%   $��398.466��66    � 
ResizeMode$ NoResize=�6F    � WindowStartupLocation$ CenterScreen=�6\   .��5	      � ��5
   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FFE4A3A3��6    � Offset$ 0Q�61   � 5      $ Bisque��6   $ 1Q�6.   5      .+�5   
   �� $��Transfer Money��6   $
��Left=�6)   $��	10,10,0,0q�6D   $	��Top=�6W   $	��119��6o   $��29��6{   ���	#FF461C1C$
��Bold"�6�   $��14(�6�   ��6�   Z� 6�   �� 5   
   $��Input Nominal��6   $
��Left=�6(   $��	10,84,0,0q�6C   $	��Top=�6V   $	��175��6n   $��33��6z   $��16(�6�   ���	#FF2017176�   �� 5   
   -   5         ��Name$ 
nominaltxt��5      $
��Left=�6&   $��27��6A   $��
202,88,0,0q�6M    �� TextWrapping$
 Wrap=�6a   $	��Top=�6u   $	��180��6�   $��Center=�6�   ���	#FF5C4747$��16(�6�   ��6�   Z� .��6�   ��5      �� 5      	 �� Color$	 White��6"   
 �� Opacity$	
 0.5Q�60   .��5   "   5      �� 5   
   $
��Note��6   $
��Left=�6   $��
10,127,0,0q�6:   $	��Top=�6N   $	��175��6f   $��33��6r   $��16(�6~   ���	#FF2017176�   �� 5   
   -   5         ��Name$ notetxt��5      $
��Left=�6'   $��83��6B   $��202,131,0,0q�6N   $	��Top=�6c   $	��180��6{   $��16(�6�   ���	#FF4C3636��6�   Z� ��5      �� 5      $	 White��6"   $	
 0.5Q�60   . �5      /� .T�5      J� .*�6   .*�5      �� 5      5       5!      �� 5"   
   -   5         ��Name$ combobox��5"      $
��Left=�6%   $��
202,49,0,0q�6@   $	��Top=�6T   $	��180��6l   ���	#FF3C2D2D �� 
IsEditable . ��6x   Z� ��5#      �� 5$      $	 Black��6"   $	
 0.5Q�60   5&      �� 5'   
   $��Sender��6   $
��Left=�6!   $��	10,45,0,0q�6<   $	��Top=�6O   $	��175��6g   $��33��6s   $��16(�6   ���	#FF2017176�   �� 5(   
   -   5         ��Name$ 
donebutton��5(      $
��DONE��6%   $
��Left=�64   $��151,251,0,0q�6O   $	��Top=�6d   $	��105��6|   
����������	#FFAD8C8C$��32��6�   $��Yu Gothic UI Semilight)�6�   $��16(�6�   ��6�   Z� 6  �� 5)   
   -   5        $
��BACK��5)      $
��Left=�6    $��
10,286,0,0q�6;   $	��Top=�6O   $��55��6g   $��29��6r   $��16(�6~   ���	#FFBA5555���	#FFD6B6B66�   5+      5,      
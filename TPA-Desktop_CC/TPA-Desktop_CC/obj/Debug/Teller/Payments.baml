   M S B A M L   `   `   `  ����I  ETPA-Desktop_CC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:TPA_Desktop_CCTPA_Desktop_CC  5   	       TPA_Desktop_CC.Payments   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:TPA_Desktop_CC     5   	     � Title$%  Kong Bu Bank（孔布 银行）��5   	   $��355.138��6%   $��398.466��66    � 
ResizeMode$ NoResize=�6F    � WindowStartupLocation$ CenterScreen=�6\   .��5	      � ��5
   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FFE4A3A3��6    � Offset$ 0Q�61   � 5      $ Bisque��6   $ 1Q�6.   5      .+�5   
   �� $��Payments��6   $
��Left=�6#   $��	10,10,0,0q�6>   $	��Top=�6Q   $	��197��6i   $��38��6u   ���	#FF461C1C$
��Bold"�6�   $��20(�6�   ��6�   Z� 6�   �� 5   
   $��Sender Name��6   $
��Left=�6&   $	��Top=�6A   $��	10,48,0,0q�6Y   ���	#FF201717$��16(�6�   �� 5   
   $��Receiver Account��6   $
��Left=�6+   $	��Top=�6F   $��	10,85,0,0q�6^   ���	#FF201717$��16(�6�   �� 5   
   $��Amount��6   $
��Left=�6!   $	��Top=�6<   $��
10,122,0,0q�6T   ���	#FF201717$��16(�6   �� 5   
   $
��Type��6   $
��Left=�6   $	��Top=�6:   $��
10,159,0,0q�6R   ���	#FF201717$��16(�6}   �� 5   
   -   5         ��Name$ rcvtxt��5      $
��Left=�6"   $��27��6=   $��
201,87,0,0q�6I    �� TextWrapping$
 Wrap=�6]   $	��Top=�6q   $	��181��6�   $��16(�6�   	 �� 	IsEnabled	 . ���	#FF5C4747$��Center=�6�   ��6�   Z� .��6  ��5      �� 5      
 �� Color$
 White��6"    �� Opacity$	 0.5Q�60   .��5   "   5      �� 5   
   -   5         ��Name$ combobox��5      $
��Left=�6%   $��
202,53,0,0q�6@   $	��Top=�6T   $	��180��6l   ���	#FF3C2D2D �� 
IsEditable . ��6x   Z� ��5      �� 5      $
 Black��6"   $	 0.5Q�60   5      �� 5   
   -   5        $ amountxt��5      $
��Left=�6$   $��27��6?   $��200,125,0,0q�6K   $
 Wrap=�6`   $	��Top=�6t   $	��181��6�   $��16(�6�   	 . ���	#FF5C4747$��Center=�6�   ��6�   Z� .��6  ��5       �� 5!      $
 White��6"   $	 0.5Q�60   .��5"   "   5#      �� 5$   
   -   5        $
��BACK��5$      $
��Left=�6    $��
10,286,0,0q�6;   $	��Top=�6O   $��55��6g   $��29��6r   $��16(�6~   ���	#FFBA5555���	#FFD6B6B66�   �� 5%   
   -   5         ��Name$ 
donebutton��5%      $
��DONE��6%   $
��Left=�64   $��153,263,0,0q�6O   $	��Top=�6d   $	��105��6|   
����������	#FFAD8C8C$��32��6�   $��Yu Gothic UI Semilight)�6�   $��16(�6�   ��6�   Z� 6  �� 5&   
   -   5        $ typebox��5&      $
��Left=�6$   $��201,166,0,0q�6?   $	��Top=�6T   $	��180��6l   ���	#FF3C2D2D$ �� IsSynchronizedWithCurrentItem$
 TrueY�6�   ��6x   Z� ��5'      �� 5(      $
 Black��6"   $	 0.5Q�60   5*      5,      5-      
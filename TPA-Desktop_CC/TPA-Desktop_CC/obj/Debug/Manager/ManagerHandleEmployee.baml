   M S B A M L   `   `   `  ����I  ETPA-Desktop_CC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:TPA_Desktop_CC.ManagerTPA_Desktop_CC.Manager  5   	   2    ,TPA_Desktop_CC.Manager.ManagerHandleEmployee   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:TPA_Desktop_CC.Manager     5   	     � Title$%  Kong Bu Bank（孔布 银行）��5   	   $��355.138��6%   $��398.466��66    � 
ResizeMode$ NoResize=�6F    � WindowStartupLocation$ CenterScreen=�6\   .��5	      � ��5
   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FF968EA9��6    � Offset$ 0Q�61   � 5      $ 	#FFFBA581��6   $ 1Q�61   � 5      $ 	#FFD6959A��6   $ 0.504Q�61   5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ datagrid��5      $
��Left=�6%   $	��143��6@   $��	10,89,0,0q�6M   $	��Top=�6`   $	��363��6x      	RowHeight$ 30Q�6�   
�������	   RowBackground
	 �����
   AlternatingRowBackground

 ��ح�   
IsReadOnly . $��Center=�6  $��Center=�66  ��6�   Z� 66  �� 5   
   -   5         ��Name$ employeename��5      $
��NAme��6&   $
��Left=�65   $��	10,10,0,0q�6P   $	��Top=�6c   $��20(�6{   $
��Bold"�6�   ���	#FF5C20206�   �� 5   
   $��Violation :��6   $
��Left=�6&   $��	10,47,0,0q�6A   $	��Top=�6T   $��20(�6l   $
��Bold"�6z   ���	#FF4B20206�   �� 5   
   -   5        $ notxt��5      $��No Violation Data!��6   $
��Left=�6<   $��
10,128,0,0q�6W   $	��Top=�6k   $	��363��6�   ���	#FF8C5353$
��Bold"�6�   $��20(�6�   $��Center=�6�   $��Center=�6�   �� 5   
   -   5        $
��BACK��5      $
��Left=�6    $��29��6;   $��
10,279,0,0q�6G   $	��Top=�6[   $��65��6s   $��20(�6~   ���	#FFD47070���	#FFE0ACAC$
��Bold"�6�   ��6�   Z� 6�   �� 5   
   -   5         ��Name$ 
firebutton��5      $
��FIRE��6%   $
��Left=�64   $��140,240,0,0q�6O   $	��Top=�6d   $	��111��6|   $��40��6�   $��20(�6�   $
��Bold"�6�   ���	#FFCD5A5A���	#FF4E1212��6�   Z� 6�   �� 5   
   -   5        $ scoretxt��5      $��Label��6"   $
��Left=�62   $��
314,47,0,0q�6M   $	��Top=�6a   $��20(�6y   $
��Bold"�6�   5      5      
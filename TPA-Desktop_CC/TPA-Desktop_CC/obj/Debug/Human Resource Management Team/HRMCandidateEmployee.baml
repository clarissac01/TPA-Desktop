   M S B A M L   `   `   `  ����I  ETPA-Desktop_CC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:TPA_Desktop_CCTPA_Desktop_CC  5   	   H    BTPA_Desktop_CC.Human_Resource_Management_Team.HRMCandidateEmployee   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:TPA_Desktop_CC     5   	     � Title$%  Kong Bu Bank（孔布 银行）��5   	   $��355.138��6%   $��398.466��66    � 
ResizeMode$ NoResize=�6F    � WindowStartupLocation$ CenterScreen=�6\   .��5	      � ��5
   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63    �� RelativeTransform 5      V� 5      .~�5      ��  �� CenterY$	 0.5Q�6)    �� CenterX$	 0.5Q�67   �� 5       �� CenterY$	 0.5Q�6(   	 �� CenterX$		 0.5Q�66   �� 5      
 �� Angle$
 -28.301Q�6*    �� CenterY$	 0.5Q�6:    �� CenterX$	 0.5Q�6H   T� 5      5      .��5      �  � Color$ 	#FF9FA5D5��6    � Offset$ 0Q�61   � 5      $ 	#FFE8F5C8��6   $ 1Q�61   5      .+�5   
   �� -   5        $
��BACK��5      $
��Left=�6    $��30��6;   $��
16,281,0,0q�6G   $	��Top=�6[   $��66��6s   $��20(�6~   ���	#FFD47070���	#FFE0ACAC$
��Bold"�6�   ��6�   Z� 6�   �� 5   
   $��CANDIDATE EMPLOYEE��6   $
��Left=�6-   $��	10,10,0,0q�6H   $	��Top=�6[   $��20(�6s   $
��Bold"�6�   ���	#FF4915156�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ datagrid��5      $
��Left=�6%   $	��144��6@   $��	10,47,0,0q�6M   $	��Top=�6`   $	��363��6x      	RowHeight$ 30Q�6�      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$	 100 6�   
�������   RowBackground
 �����   AlternatingRowBackground
 ��ح�   
IsReadOnly . $��Center=�6&  ��6�   Z� 6H  �� 5   
   -   5         ��Name$ notxt��5      $0��*Currently, there is no candidate employee!��6   $
��Left=�6T   $��	10,82,0,0q�6o   $	��Top=�6�   $��16(�6�   $
��Bold"�6�   ���	#FF963853$	��363��6�   $��Center=�6�   �� 5   
   -   5         ��Name$ addbtn��5      $��ADD CANDIDATE��6!   $
��Left=�69   $��130,216,0,0q�6T   $	��Top=�6i   $	��142��6�   $��47��6�   ���	#FF8FF4AA���	#FF23085F$��16(�6�   ��6�   Z� 6�   �� 5   
   -   5        $ deleteallbtn��5      $��
DELETE ALL��6'   $
��Left=�6<   $��277,281,0,0q�6W   $	��Top=�6l   $��95��6�   $��30��6�   ���	#FFF4F18F���	#FF5F4A08$��16(�6�   ��6�   Z� 6�   5      5       
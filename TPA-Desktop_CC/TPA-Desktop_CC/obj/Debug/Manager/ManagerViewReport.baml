   M S B A M L   `   `   `  ����I  ETPA-Desktop_CC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:TPA_Desktop_CC.ManagerTPA_Desktop_CC.Manager  5   	   | xSystem.Windows.Controls.DataVisualization.Toolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35�{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit2System.Windows.Controls.DataVisualization.Charting 5	   	   .    (TPA_Desktop_CC.Manager.ManagerViewReport   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:TPA_Desktop_CC.Manager     5   	   �chartingToolkit{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit     5	   	     � Title$%  Kong Bu Bank（孔布 银行）��5   	   $��436.738��6%   $��574.466��66    � 
ResizeMode$ NoResize=�6F    � WindowStartupLocation$ CenterScreen=�6\   .��5
      � ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FF968EA9��6    � Offset$ 0Q�61   � 5      $ 	#FFFBA581��6   $ 1Q�61   � 5      $ 	#FFD6959A��6   $ 0.504Q�61   5      .+�5   
   >  8System.Windows.Controls.DataVisualization.Charting.Chart  -   5        $��	linechart��5   n   
 �� Top$	 150��6     �� Left$ 10��61   $��0,0,10,67.2q�6B   ��6W   Z� 	   Series	 5      C  =System.Windows.Controls.DataVisualization.Charting.LineSeries  ?  9System.Windows.Controls.DataVisualization.Charting.Series
   Title$
 Transactions��6-   $��0,0,0.4,-0.8q�5   .   H  BSystem.Windows.Controls.DataVisualization.Charting.DataPointSeries   IndependentValueBinding 5   B   ��  �� Path$	 Key�   DependentValueBinding 5      �� $ Value�5      5      �� 5   
   $$��Transactions Report This Month��6   $
��Left=�69   $��	10,10,0,0q�6T   $	��Top=�6g   $��16(�6   $
��Bold"�6�   ���	#FF1A034F��6�   Z� 6�   �� 5   
   -   5        $��REPORT TRANSCRIPT��5      $
��Left=�6-   $��170,330,0,0q�6H   $	��Top=�6]   $	��237��6u   $��52��6�   ���	#FFB7E8BB���	#FF371A6F$
��Bold"�6�   $��20(�6�   ��6�   Z� 6�   �� 5   
   -   5        $
��BACK��5      $
��Left=�6    $��
10,365,0,0q�6;   $	��Top=�6O   $��55��6g   $��29��6r   $��16(�6~   ���	#FFBA5555���	#FFD6B6B66�   5      5      
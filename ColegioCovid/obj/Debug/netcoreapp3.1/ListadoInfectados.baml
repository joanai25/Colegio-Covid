   M S B A M L   `   `   `  ����G  CColegioCovid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ColegioCovidColegioCovid  5   	   $    ColegioCovid.ListadoInfectados   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:ColegioCovid     5   	     � Title$  ListadoInfectados��5   	   $	��450��6#   $	��800��60   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��* �6   6+   �� 5      $��* �6   6+   �� 5      $��* �6   6+   �� 5      $��* �6   6+    � RowDefinitions 5   
   �� 5      $��* �6   6)   �� 5      $��* �6   6)   �� 5      $��* �6   6)   �� 5      $��* �6   6)   .+�5   
   �� $��Curso��6   $��Center=�6    $	��Top=�6D   $��0��6c   $��0��6s   $��30(�5      $��	0,5,0,103q�6   $��2��61   �� 5   
   -   5         ��Name$ cbCurso��5      $��0��6E   $��0��6U   $��20,65,20,10q�6b   �� 5   
   -   5         ��Name$ btnSeleccionar��5      $��Seleccionar��6+   $��1��6A   $��0��6Q   $��Center=�6^   $��130,25,130,36q�6�   $��25(�5      $��2��6<   �� 5   
   -   5         ��Name$ listAlumnos��5      $��2��6(   
���   �$��20q�6Q   $��1��6]   $��3��6j   ��5      �� 5      .R�5       � .+�5"      �� $y�Hidden=�6=   ��6$   ��  �� Path$ id�6=   �� 5#      ��6$   �� $ nombre��� 5%      ��6$   �� $ 	apellidos�5'      5)      5+      &   System.Windows.Controls.DataGrid  5,   
   -   5          Name$ gridContactos��5,      $��16(�6*      CanUserAddRows$ False��68   	   AutoGenerateColumns$	 False��6O   $��2��6k   
���   �$��20q�6�   $��1��6�   $��3��6�   $��2��6�   
   Columns
 5-      0  *System.Windows.Controls.DataGridTextColumn  5.      ,  &System.Windows.Controls.DataGridColumn   
Visibility$ Hidden=�6%      Header$ Identificador��69   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6P   �� $ id�  5/      $ Nombre��6%    65   �� $ nombre�  50      $ 	Apellidos��6%    68   �� $ 	apellidos�  51      $ Fecha��6%    64   �� $ fecha�  52      $
 Hora��6%    63   �� $
 hora�54      (  "System.Windows.Controls.DatePicker  55   
   -   5          Name$ 
calendario��55         SelectedDateFormat$ Short=�6)   $��3��6D   $��0��6T   $��20,20,20,49q�6c   56      57      
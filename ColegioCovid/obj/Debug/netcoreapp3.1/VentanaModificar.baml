   M S B A M L   `   `   `  ����G  CColegioCovid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ColegioCovidColegioCovid  5   	   #    ColegioCovid.VentanaModificar   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:ColegioCovid     5   	     � Title$  VentanaModificar��5   	   $	��768��6"   $
��1024��6/   .��5	      � 
����� � � ColumnDefinitions 5
   
   �� 5      $��* �6   6+   �� 5      $��* �6   6+   �� 5      $��* �6   6+   �� 5      $��* �6   6+    � RowDefinitions 5   
   �� 5      $��* �6   6)   �� 5      $��* �6   6)   �� 5      $��* �6   6)   �� 5      $��* �6   6)   �� 5      $��* �6   6)   �� 5      $��* �6   6)   �� 5      $��* �6   6)   �� 5      $��* �6   6)   .+�5   
   �� $��Modificar Alumno��6   $��Center=�6+   $��0��6N   $��1��6[   $��2��6k   $��35(�5      $
��Bold"�6   $��Center=�60   6O   �� 5   
   -   5         ��Name$ cbAlumno��5      $��1��6%   $��0��62   $��2��6B   $��30q�6V   �� 5   
   -   5         ��Name$ btnSeleccionar��5      $��Seleccionar��6)   $��1��6?   $��2��6L   $��30q�6\   $��20(�6h   6�   �� 5!   
   $��Nombre��6   $��2��6!   $��0��6.   $��25(�6>   $
��Bold"�6L   $��15,0,0,0q�6^   $��Bottom=�6p   $��0,0,0,5q�6�   6�   �� 5"   
   $��	Apellidos��6   $��2��6$   $��2��61   $��25(�6A   $
��Bold"�6O   $��15,0,0,0q�6a   $��Bottom=�6s   $��0,0,0,5q�6�   6�   �� 5#   
   -   5         ��Name$ 	txtNombre��5#      $��3��6%   $��0��62   $��2��6B   $��15,0,100,50q�6V   $��25(�6k   6|   �� 5$   
   -   5        $ txtApellidos��5$      $��3��6(   $��2��65   $��2��6E   $��15,0,100,50q�6Y   $��25(�6n   6   �� 5%   
   $��Telefono��6   $��4��6#   $��0��60   $��25(�6@   $
��Bold"�6N   $��15,0,0,0q�6`   $��Bottom=�6r   $��0,0,0,5q�6�   6�   �� 5&   
   $��Fecha Nacimiento��6   $��4��6+   $��2��68   $��25(�6H   $
��Bold"�6V   $��15,0,0,0q�6h   $��Bottom=�6z   $��0,0,0,5q�6�   6�   �� 5'   
   -   5        $ txtTelefono��5'      $��5��6H   $��0��6U   $��2��6e   $��15,0,100,50q�6y   $��25(�6�   6�   �� 5(   
   -   5        $ txtFecha��5(      $��5��6$   $��2��61   $��2��6A   $��15,0,100,50q�6U   $��25(�6j   6{   �� 5)   
   $��Sexo:��6   $��6��6    $��Center=�6-   $��0��6H   $��25(�6X   $
��Bold"�6f   $��15,0,0,0q�6x   $��0,0,0,5q�6�   6�   	� 5*   
   -   5         	�Name$ 
rdbtHombre��5*      $��Hombre��6*    d� 	IsChecked$ FalseY�6;   $��5��6M   $��20(�6Z   $
��Bold"�6h   $��Center=�6z   $��2��6�   $��136,66,120,28q�6�   $��2��6�   	� 5+   
   -   5        $ 	rdbtMujer��5+      $��Mujer��6)   $ FalseY�69   $��5��6K   $��20(�6X   $
��Bold"�6f   $��Center=�6x   $��2��6�   $��136,94,120,0q�6�   $��2��6�   	� 5,   
   -	   5        $ 	rdbtOtros��5,      $��Otros��6)   $ FalseY�69   $��6��6K   $��20(�6X   $
��Bold"�6f   $��Center=�6x   $��2��6�   $��136,28,120,66q�6�   $��2��6�   �� 5-   
   -
   5        $ 	btnCerrar��5-      $��Cerrar��6$   $��7��65   $��3��6B   $��35(�6R   $��15q�6`   6�   �� 5.   
   -   5        $ btnModificar��5.      $��Modificar Alumno��6'   $��7��6B   $��1��6O   $��2��6_   $��15q�6s   
��� ���$��35(�5/      $
��Bold"�6   6H   �� 50   
   $��Curso��6   $��5��6    $��2��6-   $��25(�6=   $
��Bold"�6K   $��	15,0,0,75q�6]   $��Bottom=�6p   $��0,0,0,5q�6�   $��2��6�   �� 51   
   -   5        $ txtCurso��51      $��6��6$   $��2��61   $��2��6A   $��15,19,100,31q�6U   $��25(�6k   53      54      
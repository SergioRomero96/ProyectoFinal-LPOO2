   M S B A M L   `   `   `  ����
  Vistas$    Vistas.CRUD.Users.ViewUsuarios   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  ViewUsuarios��5   	   $	��417��6   $	��705��6+    � WindowStartupLocation$ CenterScreen=�6N    � 
ResizeMode$ NoResize=�6�   .��5      �  � RowDefinitions 5   
   �� 5      $��45 �6   �� 5      $��35 �6   �� 5	      $	��275 �6    � ColumnDefinitions 5   
   �� 5      $	��350 �6   �� 5      $	��350 �6   .+�5   
   ]� $��0��6   .+�5      �� -   5        $��
textBlock1��5   6   $��Center=�6   $��Gestios de Usuarios��6H   $��27(�6c   $��Center=�6q   5      ]� 5   
   $��0��6   $��1��6!   .+�5      �� -   5        $��
textBlock2��5   6   $��Center=�6   $��Listado de usuarios��6H   $��24(�6c   $��Bottom=�6q   5      ]� 5   
   $��1��6   .+�5      �� -   5        $��	btnAddABM��5   C   $
��Left=�6   $��15 0 5 0q�61   $��Bottom=�6T      StyleBtnPrimary#��[  6o   .��5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��/resources/agregar.png��6   �� 5      $��Nuevo��6    $��10,0,0,0q�6-   $��Center=�6?   5      5      �� 5      -   5        $��btnEditarABM��5   B   $
��Left=�6   $��15 0 5 0q�60   {�.  $��Bottom=�6h     StyleBtnGreed#��[ 6�   .��5       �� $ 
Horizontal=�6   .+�5!      �� $��/resources/editar.png��6   �� 5"      $��Editar��6    $��10,0,0,0q�6.   5#      5$      �� 5&      -   5        $��btnELiminarABM��5&   C   $
��Left=�6   $��15 0 5 0q�61   $��Bottom=�6Y     StyleBtnRed#��[ 6t   .��5'      �� $ 
Horizontal=�6   .+�5(      �� $��/resources/eliminar.png��6   �� 5)      $��Eliminar��6    $��10,0,0,0q�60   $��Center=�6B   5*      5+      5,      �� 5-   
   -   5        $��	groupBox1��5-   �   $��2��6   $��10,10,10,-10q�6    $7��1Presione algun campo para activar el modo edicion��66   
���   �$��Stretch=�6�   $��Stretch=�6�   .��5.      � -   5        $��grdDatos��5.       5/      �� 50      $
��101* �6'   �� 52      $
��200* �6'   .+�56      �� -	   5        $	��lbl��56   `   $��Nombre Usuario:��6   $
��Left=�63   $��3,18,0,0q�6N   $	��Top=�6k   �� 57      -
   5        $��txtNombreUsuario��57   W   $��24��6   $��Stretch=�6&   $��	0,18,25,0q�6D   $	��Top=�6o    �� 	MaxLength$ 12��6�   $��1��6�     EstiloTextBoxIdataError#��[ 6�   $��2��6<  ��6�   ��  �� Path$ NombreUsuario� �� ValidatesOnDataErrors . 	 �� UpdateSourceTrigger$	 PropertyChanged=�6<  �� 58      -   5        $��label2��58   i   $��Contraseña :��6   $��32��6/   $
��Left=�6;   $��	27,74,0,0q�6V   $	��Top=�6w   �� 59      -   5        $��txtContraseña��59   W   $��24��6   $��Stretch=�6&   $��	0,76,25,0q�6D   $	��Top=�6l   $��1��6�   #��[ 6�   $��2��6'  ��6�   �� $ Contraseña� . $	 PropertyChanged=�6'  �� 5:      -   5        $��label3��5:   X   $��Rol :��6   $
��Left=�6)   $��
70,204,0,0q�6D   $	��Top=�6f   �� 5;      -   5        $��cmbRol��5;   Y   $��24��6   $��Stretch=�6'   $��
0,206,25,0q�6E   $	��Top=�6g   $��1��6�   $��2��6�   
 �� SelectedValue
 6�   �� $ 
Rol.Codigo��� 5<      -   5        $��label1��5<   p   $��Apellido y Nombre:��6   $��32��65   $
��Left=�6A   $��
-5,130,0,0q�6\   $	��Top=�6~   �� 5=      -   5        $��
txtApeyNom��5=   X   $��24��6   $��Stretch=�6&   $��
0,132,25,0q�6D   $	��Top=�6j   $ 20��6�   #��[ 6�   $��2��6'  $��1��6;  ��6�   �� $ ApellidoNombre� . $	 PropertyChanged=�6;  �� 5>      -   5        $��lblEmail��5>   n   $��Email (Opcional):��6   $��32��64   $
��Left=�6@   $��	8,170,0,0q�6[   $	��Top=�6~   �� 5?      -   5        $��txtEmail��5?   X   $��24��6   $��Stretch=�6&   $��
0,170,25,0q�6D   $	��Top=�6h   $ 30��6�   #��[ 6�   $��2��6  $��1��60  ��6�   �� $ Email� . $	 PropertyChanged=�60  5A      5B      �� 5D   
   -   5        $��canvas_data��5D      $��1��6$   $��1��64   .+�5E      �� -   5        $��Stretch=�5E      $��Center=�65   $	��328��6R   .+�5F      �� $ 
Horizontal=�6   $��Center=�67   $��Center=�6R   .+�5G      �� -   5        $��btnFirst��5G      $��0 0 10 0q�6-   #��[  6X   .��5H      �� $ 
Horizontal=�6%   .+�5I      �� $��/resources/first.png��6$   5J      5K      �� 5L      -   5        $��btnPrevious��5L      $��0 0 10 0q�60   #��[  6]   .��5M      �� $ 
Horizontal=�6%   .+�5N      �� $��/resources/anterior.png��6$   5O      5P      �� 5Q      -   5        $��btnNext��5Q      $��0 0 10 0q�6,   #��[  6U   .��5R      �� $ 
Horizontal=�6%   .+�5S      �� $��/resources/siguiente.png��6$   5T      5V      �� 5W      -   5        $��btnLast��5W      $��0 0 10 0q�6,   #��[  6U   .��5X      �� $ 
Horizontal=�6%   .+�5Y      �� $��/resources/last.png��6$   5Z      5[      5\      �� 5]      $��Stretch=�6   $��Stretch=�6:   $��0 50 0 0q�6X   .+�5_      �� $��35��6?   
������� �� Padding$ 5q�6^   ��6    �� *NombreUsuario+6^   �� 5`      $��35��6<   
�������$ 5q�6\   ��6    �� *Contraseña+6\   �� 5a      $��35��6@   
�������$ 5q�6_   ��6    �� *ApellidoNombre+6_   �� 5b      $��35��6A   
�������$ 5q�6a   ��6    �� *Rol.Descripcion+6a   �� 5c      $��35��67   
�������$ 5q�6V   ��6    �� *Email+6V   5e      �� 5f      -   5        $��	btnAddabm��5f   6   $
��Left=�6   $��Bottom=�6G   $��0 25 0 0q�6b   #��[  6t   $y�Hidden=�6�   .��5g      �� $ 
Horizontal=�6!   .+�5h      �� $��/resources/agregar.png��6    �� 5i      $��Añadir��6$   $��10,0,0,0q�62   $��Center=�6D   5j      5k      5l      5n      5p      5q      
   M S B A M L   `   `   `  ����
  Vistas%    Vistas.CRUD.Ciudades.AltaCiudad   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  Gestión de Ciudad��5   	   $	��324��6#   $	��350��60    � WindowStartupLocation$ CenterScreen=�6<    � 
ResizeMode$ NoResize=�6a   .��5      � .+�5   
   �� -   5        $��	gbAddCity��5   `   $��Datos��6   $	��160��6"   $��Stretch=�6/   $��	12,62,0,0q�6M   $	��Top=�6q   $	��316��6�   
���   �.��5      �  � ColumnDefinitions 5	      �� 5
      $	��69* �6'   �� 5      $
��235* �6'   .+�5      �� -   5        $��codeAddCity��5   W   $��Codigo��6   $
��Left=�6)   $��	20,25,0,0q�6D   $	��Top=�6j   �� 5      -   5        $��txtCodeAddCity��5   ]    �� 
AcceptsTab .  $��Stretch=�6-   $��3,21,6,0q�6K      EstiloTextBox#��[  6s   $	��Top=�6�   $��1��6�   ��6�   ��  �� Path$ 
Ciu_Codigo� �� ValidatesOnDataErrors . �� 5      -   5        $��nameAddCity��5   W   $��Nombre��6   $
��Left=�6)   $��	15,80,0,0q�6D   $	��Top=�6j   �� 5      -   5        $��txtNameAddCity��5   J   $��Stretch=�6   $��3,76,6,0q�68   #��[  6`   $	��Top=�6�   $��1��6�   ��6�   �� $ 
Ciu_Nombre� . 5      5      �� 5   
   -   5        $��
btnAddCity��5   R   $��Guardar��6   $
��Left=�6#   $��
18,238,0,0q�6>   $	��Top=�6d     StyleBtnPrimary#��[ 6|   |�. 6�   �� 5   
   -   5        $��btnCancelCity��5   T   $��Cancelar��6   $
��Left=�6$   $��235,238,0,0q�6?   $	��Top=�6i     StyleBtnRed#��[ 6�   |�.  6�   ]� 5   
   $��	0,0,0,240q�6   .+�5      �� -	   5        $��	txtbTitle��5   S   $��28(�6   $
��Left=�6&   $��10,0,0,0q�6A   $��Nueva Ciudad��6d   $��Bottom=�6x   5      5      5      
   M S B A M L   `   `   `  ����
  Vistas)    #Vistas.CRUD.Terminales.AltaTerminal   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  Gestión de Terminal��5   	   $	��357��6%   $	��358��62    � WindowStartupLocation$ CenterScreen=�6>    � 
ResizeMode$ NoResize=�6c   .��5      � .+�5   
   �� -   5        $��	gbAddCity��5   \   $��Datos��6   $	��202��6"   $
��Left=�6/   $��8,63,0,0q�6J   $	��Top=�6m   $	��316��6�   
���   �.��5      �  � ColumnDefinitions 5	      �� 5
      $	��69* �6'   �� 5      $
��235* �6'   .+�5      �� -   5        $��	lblCodigo��5   W   $��Codigo��6   $
��Left=�6)   $��	20,25,0,0q�6D   $	��Top=�6h   �� 5      -   5        $��txtCodigoTerminal��5   ]    �� 
AcceptsTab .  $��Stretch=�6-   $��3,21,6,0q�6K      EstiloTextBox#��[  6v   $	��Top=�6�   $��1��6�   ��6�   ��  �� Path$ 
Ter_Codigo� �� ValidatesOnDataErrors . 6  �� 5      -   5        $��	lblCiudad��5   W   $��Ciudad��6   $
��Left=�6)   $��	15,80,0,0q�6D   $	��Top=�6h   �� 5      -   5        $��	cmbCiudad��5   d   $��1��6   $��23��6+   $
��Left=�67   $��3,83,0,0q�6R   $	��Top=�6u   $	��226��6�   6�   �� 5      -   5        $��lblTerminal��5   Z   $��
Dirección��6   $
��Left=�6,   $��	8,131,0,0q�6G   $	��Top=�6m   �� 5      -   5        $��txtNombreTerminal��5   K   $��Stretch=�6   $��	3,127,6,0q�68   #��[  6d   $	��Top=�6�   $��1��6�   ��6�   �� $ 
Ter_Nombre� . 5      5      �� 5   
   -	   5        $��
btnGuardar��5   R   $��Guardar��6   $
��Left=�6#   $��
12,271,0,0q�6>   $	��Top=�6d     StyleBtnPrimary#��[ 6|   |�. 6�   �� 5   
   -
   5        $��btnCancelar��5   T   $��Cancelar��6   $
��Left=�6$   $��237,271,0,0q�6?   $	��Top=�6g     StyleBtnRed#��[ 6   |�.  6�   ]� 5   
   $��	8,0,0,264q�6   .+�5      �� -   5        $��	txtbTitle��5   S   $��28(�6   $
��Left=�6&   $��10,0,0,0q�6A   $��Nueva Terminal��6d   $��Bottom=�6z   5      5      5      
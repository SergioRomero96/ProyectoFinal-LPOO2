   M S B A M L   `   `   `  ����
  Vistas,    &Vistas.CRUD.Terminales.GestionTerminal   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5        .��5      �    StyleBodyGestion#���   6   .+�5
   
   ]� -   5        $��	pnlTitulo��5
   ?   $��75��6   $��Stretch=�6    $	��Top=�6P     StyleHeaderGestion#���  6h     J� Effect  5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$
 Gray��6#      	Direction$	 270Q�60      
BlurRadius$ 25Q�6@      ShadowDepth$ 5Q�6P   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   .+�5      ��   imgGestionTerminales#���  6   �� 5      -   5        $��
textBlock1��5   *   $
��Auto��6   $��Gestion de Terminales��6<     StyleHeaderTitulo#���  6Y   5      5      �� 5   
   -   5        $��	groupBox1��5   X   $��Busqueda��6   $��Stretch=�6%   $��30,105,30,0q�6C   $	��Top=�6i     StyleGBBusqueda#���  6�   .��5      � .+�5      �� -   5        $��label1��5   `   $��Nombre Terminal��6   $
��Left=�62   $��	80,10,0,0q�6M   $	��Top=�6n     
StyleLabel#���  6�   �� 5      -   5        $��txtNombreTerminal��5   O   $��Stretch=�6   $��200,10,120,0q�69   $	��Top=�6h     EstiloTextBox#��[ 6�   6�   5      5      &   System.Windows.Controls.DataGrid  5   
   -   5        $��dgTerminales��5   ]      	RowHeight$ 30Q�6      AutoGenerateColumns .  $��Stretch=�6?   $��Stretch=�6q   $��30,209,30,79q�5         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6*     StyleDataGrid#���  6:   	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Codigo��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *
TER_Codigo+6V     5      $
 Nombre Ciudad��6%    6<   �� *
CIU_Nombre+6]     5       $
 Nombre Terminal��6%    6>   �� *
TER_Nombre+6_   5"      � 5$   
    � Orientation$ 
Horizontal=�6   $��Bottom=�6-   $
��Left=�6H   $��	30,0,0,20q�6c   .+�5%      �� -   5        $��
btnAgregar��5%   C   $
��Left=�6   $��10,0,0,0q�61   $��Bottom=�6U     StyleBtnPrimary#��[ 6p   .��5&      �� $ 
Horizontal=�6   .+�5'      �� $��/resources/agregar.png��6   �� 5(      $��Nuevo��6    $��10,0,0,0q�6-   $��Center=�6?   5)      5*      �� 5+      -	   5        $��	btnEditar��5+   C   $
��Left=�6   $��10,0,0,0q�61   $��Bottom=�6T    	 StyleBtnGreed#��[	 6o   .��5,      �� $ 
Horizontal=�6   .+�5-      �� $��/resources/editar.png��6   �� 5.      $��Editar��6    $��10,0,0,0q�6.   $��Center=�6@   5/      50      �� 51      -
   5        $��btnEliminar��51   C   $
��Left=�6   $��10,0,0,0q�61   $��Bottom=�6V    
 StyleBtnRed#��[
 6q   .��52      �� $ 
Horizontal=�6   .+�53      �� $��/resources/eliminar.png��6   �� 54      $��Eliminar��6    $��10,0,0,0q�60   $��Center=�6B   55      56      57      58      59      
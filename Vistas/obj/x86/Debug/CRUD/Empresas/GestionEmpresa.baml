   M S B A M L   `   `   `  ����
  Vistas)    #Vistas.CRUD.Empresas.GestionEmpresa   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5        .��5      �    StyleBodyGestion#���   6   .+�5	   
   ]� -   5        $��	pnlTitulo��5	   ?   $��75��6   $��Stretch=�6    $	��Top=�6P     StyleHeaderGestion#���  6h     J� Effect  5
      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$
 Gray��6#      	Direction$	 270Q�60      
BlurRadius$ 15Q�6@      ShadowDepth$ 2Q�6P   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   .+�5      ��   imgGestionAutoBus#���  6   �� 5      -   5        $��txtblkEmpresa��5      $��Gestion de Empresas��61     StyleHeaderTitulo#���  6L   5      5      �� 5   
   -   5        $��	groupBox1��5   X   $��Busqueda��6   $��Stretch=�6%   $��30,105,30,0q�6C   $	��Top=�6i     StyleGBBusqueda#���  6�   .��5      � .+�5      �� -   5        $��label1��5   c   $��Nombre de Empresa��6   $
��Left=�65   $��	67,13,0,0q�6P   $	��Top=�6q     
StyleLabel#���  6�   �� 5      -   5        $��txtNombreEmpresa��5   O   $��Stretch=�6   $��210,10,120,0q�69   $	��Top=�6g     EstiloTextBox#��[ 6   6�   5      5      &   System.Windows.Controls.DataGrid  5   
   -   5        $��
dgEmpresas��5   ]      	RowHeight$ 30Q�6      AutoGenerateColumns .  $��Stretch=�6?   $��Stretch=�6o   $��30,209,30,79q�5         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6*     StyleDataGrid#���  6:   	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Codigo��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *
EMP_Codigo+6V     5      $
 Nombre��6%    66   �� *
EMP_Nombre+6W     5      $
 	Direccion��6%    68   �� *EMP_Direccion+6\     5      $
 Telefono��6%    67   �� *EMP_Telefono+6Z     5      $
 Email��6%    64   �� *	EMP_Email+6T   5#      � 5%   
   $��Bottom=�6   $��	30,0,0,20q�6/   .+�5&      �� -   5        $��
btnAgregar��5&   1   $
��Left=�6   $��Bottom=�6C     StyleBtnPrimary#��[ 6^   .��5'      �� $ 
Horizontal=�6   .+�5(      �� $��/resources/agregar.png��6   �� 5)      $��Nuevo��6    $��10,0,0,0q�6-   $��Center=�6?   5*      5+      �� 5-      -	   5        $��	btnEditar��5-   2   $
��Left=�6   $��	10,0,10,0q�6C   $��Bottom=�6V    	 StyleBtnGreed#��[	 6q   .��5.      �� $ 
Horizontal=�6   .+�5/      �� $��/resources/editar.png��6   �� 50      $��Editar��6    $��10,0,0,0q�6.   $��Center=�6@   51      52      �� 54      -
   5        $��btnEliminar��54   2   $
��Left=�6   $��Bottom=�6E    
 StyleBtnRed#��[
 6`   .��55      �� $ 
Horizontal=�6   .+�56      �� $��/resources/eliminar.png��6   �� 57      $��Eliminar��6    $��10,0,0,0q�60   $��Center=�6B   58      59      5:      5;      5<      
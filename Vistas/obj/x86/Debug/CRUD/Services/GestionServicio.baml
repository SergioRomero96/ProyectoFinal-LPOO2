   M S B A M L   `   `   `  ����
  Vistas*    $Vistas.CRUD.Services.GestionServicio   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5        $��ucGestionViajes��5   8   .��5      �    StyleBodyGestion#���   6   .+�5	   
   ]� -   5        $��	pnlTitulo��5	   ?   $��75��6   $��Stretch=�6    $	��Top=�6P     StyleHeaderGestion#���  6h     J� Effect  5
      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$
 Gray��6#      	Direction$	 270Q�60      
BlurRadius$ 15Q�6@      ShadowDepth$ 2Q�6P   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   .+�5      ��   imgGestionViajes#���  6   �� 5      -   5        $��
textBlock1��5      $��Gestión de Viajes��6.     StyleHeaderTitulo#���  6G   5      5      �� 5   
   -   5        $��	groupBox1��5   :   $��Busqueda��6   $��30,105,30,0q�6%     StyleGBBusqueda#���  6K   .��5      � .+�5      �� -   5        $��label1��5   _   $��Codigo Autobus��6   $
��Left=�61   $��	74,10,0,0q�6L   $	��Top=�6m     
StyleLabel#���  6�   �� 5      -   5        $��	txtBuscar��5   O   $��Stretch=�6   $��210,10,120,0q�69   $	��Top=�6`     EstiloTextBox#��[ 6y   6�   5      5      &   System.Windows.Controls.DataGrid  5   
   -   5        $��dgServicios��5   M      AutoGenerateColumns .  $��Stretch=�6/   $��Stretch=�6`   $��30,209,30,79q�5         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6)     StyleDataGrid#���  69      CanUserReorderColumns .  	   CanUserResizeColumns	 .  
   CanUserSortColumns
 .     CanUserResizeRows .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Codigo Servicio��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6>   �� *
SER_Codigo+6_     5      $ Codigo Autobus��6%    6=   �� *
AUT_Codigo+6^     5       $ Fecha y Hora��6%    6;   �� *SER_FechaHora+6_     5!      $ Origen��6%    65   �� *
CIU_Origen+6V     5"      $ Destino��6%    66   �� *CIU_Destino+6X     5#      $ Empresa��6%    66   �� *
EMP_Nombre+6W     5$      $ Estado��6%    65   �� *
SER_Estado+6V   5&      � 5(   
    � Orientation$ 
Horizontal=�6   $��Bottom=�6-   $
��Left=�6H   $��	30,0,0,20q�6c   .+�5)      �� -   5        $��
btnAgregar��5)   2   $
��Left=�6   $��Bottom=�6E     StyleBtnPrimary#��[ 6`   .��5*      �� $ 
Horizontal=�6   .+�5+      �� $��/resources/agregar.png��6   �� 5,      $��Nuevo��6    $��10,0,0,0q�6-   $��Center=�6?   5-      5.      �� 50      -	   5        $��	btnEditar��50   B   $
��Left=�6   $��10,0,0,0q�60   $��Bottom=�6S    	 StyleBtnGreed#��[	 6n   .��51      �� $ 
Horizontal=�6   .+�52      �� $��/resources/editar.png��6   �� 53      $��Editar��6    $��10,0,0,0q�6.   $��Center=�6@   54      55      �� 56      -
   5        $��btnEliminar��56   B   $
��Left=�6   $��10,0,0,0q�60   $��Bottom=�6U    
 StyleBtnRed#��[
 6p   .��57      �� $ 
Horizontal=�6   .+�58      �� $��/resources/eliminar.png��6   �� 59      $��Eliminar��6    $��10,0,0,0q�60   $��Center=�6B   5:      5;      5<      5@      5A      
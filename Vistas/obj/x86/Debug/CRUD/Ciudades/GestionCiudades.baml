   M S B A M L   `   `   `  ����
  Vistas*    $Vistas.CRUD.Ciudades.GestionCiudades   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5        $��ucGestionCiudades��5   8   .��5      �    StyleBodyGestion#���   6   .+�5	   
   &   System.Windows.Controls.DataGrid  -   5        $��dgCities��5	   L       AutoGenerateColumns  . $��Stretch=�6.   $��Stretch=�6\   $��30,209,30,79q�5
         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6M     StyleDataGrid#���  5         
IsReadOnly .    HeadersVisibility$ Column=�6M   $��Center=�6h      CanUserAddRows .     VerticalGridLinesBrush 5
   )   Z� 5      � 5   
    � Orientation$ 
Horizontal=�6   $��Bottom=�6-   $
��Left=�6H   $��	30,0,0,20q�6c   .+�5      �� -   5        $��
btnAddCity��5   C   $
��Left=�6   $��10,0,0,0q�61   $��Bottom=�6U     StyleBtnPrimary#��[ 6p   .��5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��/resources/agregar.png��6   �� 5      $��Nuevo��6    $��10,0,0,0q�6-   $��Center=�6?   5      5      �� 5      -   5        $��	btnEditar��5   B   $
��Left=�6   $��10,0,0,0q�60   $��Bottom=�6S     StyleBtnGreed#��[ 6n   .��5      �� $ 
Horizontal=�6   .+�5      �� $��/resources/editar.png��6   �� 5      $��Editar��6    $��10,0,0,0q�6.   $��Center=�6@   5      5      �� 5      -   5        $��btnEliminar��5   C   $
��Left=�6   $��10,0,0,0q�61   $��Bottom=�6V     StyleBtnRed#��[ 6q   .��5      �� $ 
Horizontal=�6   .+�5      �� $��/resources/eliminar.png��6   �� 5      $��Eliminar��6    $��10,0,0,0q�60   $��Center=�6B   5      5       5!      �� 5"   
   -   5        $��	groupBox1��5"   X   $��Busqueda��6   $��Stretch=�6%   $��30,105,30,0q�6C   $	��Top=�6i     StyleGBBusqueda#���  6�   .��5#      � .+�5$      �� -   5        $��label1��5$   W   $��Ciudad��6   $
��Left=�6)   $��	122,8,0,0q�6D   $	��Top=�6e     
StyleLabel#���  6}   �� 5%      -   5        $��txtBuscarCiudad��5%   O   $��Stretch=�6   $��200,10,120,0q�69   $	��Top=�6f     EstiloTextBox#��[ 6   6�   5,      5-      ]� 5.   
   -	   5        $��pnlTitleCities��5.   ?   $��75��6   $��Stretch=�6    $	��Top=�6U     StyleHeaderGestion#���  6m    J� Effect 5/      3  -System.Windows.Media.Effects.DropShadowEffect  50      	   Color$
	 Gray��6#   
   	Direction$	
 270Q�60      
BlurRadius$ 15Q�6@      ShadowDepth$ 2Q�6P   .+�52      �� $ 
Horizontal=�6   $��Center=�62   .+�53      ��  	 imgGestionCiudades#��� 	 6   �� 54      -
   5        $��	txtCities��54   *   $
��Auto��6   $��Gestion de Ciudades��6;    
 StyleHeaderTitulo#��� 
 6V   55      56      58      59      
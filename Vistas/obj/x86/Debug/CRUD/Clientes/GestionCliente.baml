   M S B A M L   `   `   `  ����
  Vistas    Vistas.GestionCliente   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5        $��ucGestionCliente��5   8   .��5      �    StyleBodyGestion#���   6   .+�5	   
   ]� -   5        $��	pnlTitulo��5	   ?   $��75��6   $��Stretch=�6    $	��Top=�6P     StyleHeaderGestion#���  6h     J� Effect  5
      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$
 Gray��6#      	Direction$	 270Q�60      
BlurRadius$ 15Q�6@      ShadowDepth$ 2Q�6P   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   .+�5      ��   imgGestionClientes#���  6   �� 5      -   5        $��
textBlock1��5      $��Gestión de Clientes��6.     StyleHeaderTitulo#���  6I   5      5      �� 5   
   -   5        $��	groupBox1��5   :   $��Busqueda��6   $��30,105,30,0q�6%     StyleGBBusqueda#���  6K   .��5      � .+�5      �� -   5        $��label1��5   `   $��Ingrese el DNI:��6   $
��Left=�62   $��	80,10,0,0q�6M   $	��Top=�6n     
StyleLabel#���  6�   �� 5      -   5        $��	txtBuscar��5   O   $��Stretch=�6   $��200,10,120,0q�69   $	��Top=�6`     EstiloTextBox#��[ 6y   �� 5      -   5        $��button3��5   G   $��Right=�6   $��0,7,25,0q�65   $	��Top=�6V     StyleBtnPrimary#��[ 6n   .��5      �� $ 
Horizontal=�6!   .+�5      �� $��/resources/buscar.png��6    �� 5      $��Buscar��6$   $��10,0,0,0q�62   $��Center=�6D   5      5      5      5      &   System.Windows.Controls.DataGrid  5    
   -   5        $��
dgClientes��5    M      AutoGenerateColumns .  $��Stretch=�6/   $��Stretch=�6_   $��30,209,30,79q�5!         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6)     StyleDataGrid#���  69      CanUserReorderColumns .  	   CanUserResizeColumns	 .  
   CanUserSortColumns
 .     CanUserResizeRows .     Columns 5#      0  *System.Windows.Controls.DataGridTextColumn  5$      ,  &System.Windows.Controls.DataGridColumn   Header$ Apellido��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *CLI_Apellido+6Z     5%      $ Nombre��6%    65   �� *
CLI_Nombre+6V     5&      $	 Dni��6%    62   �� *	CLI_Dni+6P     5'      $ Telefono��6%    67   �� *CLI_Telefono+6Z     5(      $ Email��6%    64   �� *	CLI_Email+6T   5*      � 5,   
    � Orientation$ 
Horizontal=�6   $��Bottom=�6-   $
��Left=�6H   $��	30,0,0,20q�6c   .+�5-      �� -	   5        $��button1��5-   2   $
��Left=�6   $��Bottom=�6B   #��[ 6]   .��5.      �� $ 
Horizontal=�6   .+�5/      �� $��/resources/agregar.png��6   �� 50      $��Nuevo��6    $��10,0,0,0q�6-   $��Center=�6?   51      52      �� 54      -
   5        $��button2��54   B   $
��Left=�6   $��10,0,0,0q�60   $��Bottom=�6Q    	 StyleBtnGreed#��[	 6l   .��55      �� $ 
Horizontal=�6   .+�56      �� $��/resources/editar.png��6   �� 57      $��Editar��6    $��10,0,0,0q�6.   $��Center=�6@   58      59      �� 5:      -   5        $��btnEliminar��5:   B   $
��Left=�6   $��10,0,0,0q�60   $��Bottom=�6U    
 StyleBtnRed#��[
 6p   .��5;      �� $ 
Horizontal=�6   .+�5<      �� $��/resources/eliminar.png��6   �� 5=      $��Eliminar��6    $��10,0,0,0q�60   $��Center=�6B   5>      5?      5@      5D      5E      
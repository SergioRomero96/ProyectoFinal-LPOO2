   M S B A M L   `   `   `  ����
  Vistas(    "Vistas.CRUD.Users.UCGestionUsuario   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5        $��ucGestionUsuarios��5   9   .��5      �    StyleBodyGestion#���   6   .+�5	   
   &   System.Windows.Controls.DataGrid  -   5        $��dgUsers��5	   M       AutoGenerateColumns  .  $��Stretch=�6/   $��Stretch=�6\   $��30,209,30,79q�5
         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6M     StyleDataGrid#���  6]      
IsReadOnly .    HeadersVisibility$ Column=�5   %   $��Center=�6@      VerticalGridLinesBrush 5
   )   Z�    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Usuario��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   �� *USU_NombreUsuario+6^     5      $ Contraseña��6%    69   �� *USU_Contraseña+6^     5      $ Apellido y Nombre��6%    6@   �� *USU_ApellidoNombre+6i     5      $	 Rol��6%    62   �� *ROL_Descripcion+6X     5      $ Email��6%    64   �� *	USU_Email+6T   5      � 5   
    � Orientation$ 
Horizontal=�6   $��Bottom=�6-   $
��Left=�6H   $��	30,0,0,20q�6c   .+�5      �� -   5        $��btnAddUsers��5   C   $
��Left=�6   $��10,0,0,0q�61   $��Bottom=�6V     StyleBtnPrimary#��[ 6q   .��5      �� 	 �� Orientation$	 
Horizontal=�6   .+�5      �� $��/resources/agregar.png��6   �� 5      $��Nuevo��6    $��10,0,0,0q�6-   $��Center=�6?   5      5      �� 5      -   5        $��	btnEditar��5   B   $
��Left=�6   $��10,0,0,0q�60   $��Bottom=�6S     StyleBtnGreed#��[ 6n   .��5      �� $	 
Horizontal=�6   .+�5      �� $��/resources/editar.png��6   �� 5      $��Editar��6    $��10,0,0,0q�6.   5      5       �� 5"      -   5        $��btnELiminar��5"   C   $
��Left=�6   $��10,0,0,0q�61   $��Bottom=�6V     StyleBtnRed#��[ 6q   .��5#      �� $	 
Horizontal=�6   .+�5$      �� $��/resources/eliminar.png��6   �� 5%      $��Eliminar��6    $��10,0,0,0q�60   $��Center=�6B   5&      5'      �� 5(      -   5        $��btnAbm��5(   B   $
��Left=�6   $��10,0,0,0q�60   #��[ 6P   $��Bottom=�6y   .��5)      �� $	 
Horizontal=�6   .+�5*      �� $��/resources/agregar.png��6   �� 5+      $��10,0,0,0q�6    $��ABM Usuarios��62   $��Center=�6F   5,      5-      �� 5.      -   5        $��
btnOrdenar��5.   B   $
��Left=�6   $��10,0,0,0q�60   #��[ 6T   $��Bottom=�6}   .��5/      �� $	 
Horizontal=�6   .+�51      �� $��10,0,0,0q�6    $��Ordenar��62   $��Center=�6A   52      53      54      �� 55   
   -   5        $��	groupBox1��55   d   $��Busqueda��6   $��80��6%   $��Stretch=�61   $��30,105,30,0q�6O     StyleGBBusqueda#���  6v   .��56      � .+�57      �� -	   5        $��label1��57   b   $��Nombre de Usuario��6   $
��Left=�64   $��	70,10,0,0q�6O   $	��Top=�6p     
StyleLabel#���  6�   �� 58      -
   5        $��
txtUsuario��58   O   $��Stretch=�6   $��200,10,120,0q�69   $	��Top=�6a     EstiloTextBox#��[ 6z   6�   59      5:      ]� 5;   
   -   5        $��pnlTitleCities��5;   ?   $��75��6   $��Stretch=�6    $	��Top=�6U     StyleHeaderGestion#���  6m   
 J� Effect
 5<      3  -System.Windows.Media.Effects.DropShadowEffect  5=         Color$
 Gray��6#      	Direction$	 270Q�60      
BlurRadius$ 15Q�6@      ShadowDepth$ 2Q�6P   .+�5?      �� $	 
Horizontal=�6   $��Center=�62   .+�5@      ��  	 imgGestionUsuarios#��� 	 6   �� 5A      -   5        $��txtUsers��5A   *   $
��Auto��6   $��Gestion de Usuarios��6:    
 StyleHeaderTitulo#��� 
 6U   5B      5C      5E      5F      
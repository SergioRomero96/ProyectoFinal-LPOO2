   M S B A M L   `   `   `  ����F  BClasesBases, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null>.clr-namespace:ClasesBases;assembly=ClasesBasesClasesBases  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R8clr-namespace:System.ComponentModel;assembly=WindowsBaseSystem.ComponentModel 5   	   
 Vistas*   $Vistas.CRUD.Users.ViewOrdenarUsuario   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   KcoleccionUsuario.clr-namespace:ClasesBases;assembly=ClasesBases     5   	   ScomponentModel8clr-namespace:System.ComponentModel;assembly=WindowsBase     5   	     � Title$  ViewOrdenarUsuario��5   	   $	��600��6$   $
��1100��61    � 	Resources 5         	LIST_USER S� 
ObjectType   ClasesBases.WorkUsuario S� 
MethodName  
VISTA_USER �� Source �� SortDescriptions+  %System.ComponentModel.SortDescription   PropertyName   	Direction��%�   &	        &	 7     7   S� 5   
   "  5
      $ getUsuarios��5      �� 5   
   -   5        8    5        5      $ NombreUsuario��61   $ 
Descending=�6N   5      5      .��5      � .+�5   
   ]� -   5        $��pnlTitleCities��5   ?   $��75��6   $��Stretch=�6    $	��Top=�6U   ���#F7F7F7 J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5       	   Color$
	 Gray��6#   
   	Direction$	
 270Q�60      
BlurRadius$ 15Q�6@      ShadowDepth$ 2Q�6P   .+�5"      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   .+�5#      �� $��/resources/clientesN.png��6   $��64��6;   $��64��6F   $��20,0,0,0q�6R   �� 5$      -   5        $��	txtCities��5$   *   $
��Auto��6   $$��Usuarios Ordenados y Filtrados��6;   $
��Left=�6a   $��15,0,0,0q�6|   $��Center=�6�   $��30(�6�   $��Century Gothic)�6�   5%      5&      �� 5(   
   -   5        $��	groupBox1��5(   d   $��Busqueda��6   $��80��6%   $��Stretch=�61   $��30,105,30,0q�6O   $	��Top=�6u   $��15(�6�   
���   �.��5)      � .+�5*      �� -   5        $��label1��5*   p   $��Nombre de Usuario:��6   $��28��65   $
��Left=�6A   $��
111,11,0,0q�6\   $	��Top=�6~   �� 5+      -   5        $��
textBuscar��5+   O   $��Stretch=�6   $��267,11,100,0q�69   $	��Top=�6a     EstiloTextBox#��[ 6y   6�   5-      5.      &   System.Windows.Controls.DataGrid  50   
   -   5        $��dgUsers��50   M      AutoGenerateColumns .  $��Stretch=�6/   $��Stretch=�6\   $��30,209,30,79q�52         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6*     StyleDataGrid#���  53         
IsReadOnly .    HeadersVisibility$ Column=�6M   $��Center=�6h   ��51      ��  �� Source# [    Columns 54      0  *System.Windows.Controls.DataGridTextColumn  55      ,  &System.Windows.Controls.DataGridColumn   Header$ Usuario��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   �� *NombreUsuario+6Z     56      $ Contraseña��6%    69   �� *Contraseña+6Z     57      $ Apellido y Nombre��6%    6@   �� *ApellidoNombre+6e     58      $	 Rol��6%    62   �� *
Rol_Codigo+6S   5:      � 5;   
   $��Bottom=�6   $��470,0,470,20q�6/   .+�5<      �� -   5        $��
btnPreView��5<   3   $��Center=�6   $��	10,0,10,0q�6E   $��Bottom=�6X     StyleBtnPrimary#��[ 6s   .��5=      �� $ 
Horizontal=�6   .+�5?      �� $��Vista Previa��6   $��Center=�60   5@      5A      5B      5C      5D      
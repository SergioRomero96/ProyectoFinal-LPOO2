   M S B A M L   `   `   `  ����
  Vistas+    %Vistas.CRUD.Usuario.UCGestionUsuarios   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5        $��ucGestionUsuarios��5   8   .��5      � .+�5	   
   &   System.Windows.Controls.DataGrid  -   5        $��dgUsers��5	   L       AutoGenerateColumns  . $��Stretch=�6.   $��Stretch=�6[   $��30,209,30,79q�5
         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6M      HorizontalGridLinesBrush �#E3E3E3   StyleDataGrid#���   5         
IsReadOnly .    HeadersVisibility$ Column=�6M   $��Center=�6h      VerticalGridLinesBrush 5
   )   Z� 5      �� 5   
   -   5        $��
btnAddCity��5   @   $
��Left=�6   $��	30,0,0,25q�6-   $��Bottom=�6R     StyleBtnPrimary#��[ 6m   .��5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��/resources/agregar.png��6   �� 5      $��Nuevo��6   $��10,0,0,0q�6)   $��Center=�6;   5      5      �� 5   
   -   5        $��	btnEditar��5   @   $
��Left=�6   $��
194,0,0,25q�6,   $��Bottom=�6Q     StyleBtnGreed#��[ 6l   .��5      �� $ 
Horizontal=�6   .+�5      �� $��/resources/editar.png��6   �� 5      $��Editar��6   $��10,0,0,0q�6*   $��Center=�6<   5      5      �� 5   
   -   5        $��btnELiminar��5   A   $
��Left=�6   $��
300,0,0,25q�6-   $��Bottom=�6T     StyleBtnRed#��[ 6o   .��5      �� $ 
Horizontal=�6   .+�5      �� $��/resources/eliminar.png��6   �� 5      $��Eliminar��6   $��10,0,0,0q�6,   $��Center=�6>   5      5      �� 5    
   -   5        $��	groupBox1��5    d   $��Busqueda��6   $��80��6%   $��Stretch=�61   $��30,105,30,0q�6O   $	��Top=�6u   $��15(�6�   
���   �.��5!      � .+�5"      �� -   5        $��label1��5"   c   $��Nombre de Ciudad:��6   $
��Left=�64   $��
102,11,0,0q�6O   $	��Top=�6q   �� 5#      -   5        $��tbCity��5#   O   $��Stretch=�6   $��267,11,100,0q�69   $	��Top=�6]     EstiloTextBox#��[ 6v   �� 5$      -	   5        $��btnSearchCity��5$   W   $��Buscar��6   $��Right=�6*   $��0,7,6,0q�6F   $	��Top=�6l   #��[ 6�   5%      5&      ]� 5'   
   -
   5        $��pnlTitleCities��5'   ?   $��75��6   $��Stretch=�6    $	��Top=�6U   ���#F7F7F7 J� Effect 5(      3  -System.Windows.Media.Effects.DropShadowEffect  5)         Color$
 Gray��6#   	   	Direction$		 270Q�60   
   
BlurRadius$
 15Q�6@      ShadowDepth$ 2Q�6P   .+�5+      �� $ 
Horizontal=�6   $��Center=�62   .+�5,      �� $��/resources/clientesN.png��6   $��64��6;   $��64��6F   $��20,0,0,0q�6R   �� 5-      -   5        $��	txtCities��5-   *   $
��Auto��6   $��Gestion de Usuarios��6;   $
��Left=�6V   $��15,0,0,0q�6q   $��Center=�6�   $��30(�6�   $��Century Gothic)�6�   5.      5/      51      52      
   M S B A M L   `   `   `  ����
  Vistas$    Vistas.CRUD.Pasajes.VerPasajes   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  
VerPasajes��5   	   $	��600��6   $
��1100��6)    � WindowStartupLocation$ CenterScreen=�66    � 	Resources 5         tipo_servicio � Source � XPath  b2v��%{   &	        &	 T     � 5   
   $* $/ServicesXML/AutobusTipoServicio.xml?�60   $ 
/servicios��6^   �� 5   
   6'   5	      .��5
      � .+�5   
   ]� -   5        $��pnlTitleCities��5   ?   $��75��6   $��Stretch=�6    $	��Top=�6U   ���#F7F7F7 J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$
 Gray��6#      	Direction$	 270Q�60      
BlurRadius$ 15Q�6@   	   ShadowDepth$	 2Q�6P   .+�5      �� 
 �� Orientation$
 
Horizontal=�6   $��Center=�62   .+�5      �� $��/resources/pasajeN.png��6   $��64��69   $��64��6D   $��20,0,0,0q�6P   �� 5      -   5        $��	txtCities��5   *   $
��Auto��6   $��Listado de Pasajes��6;   $
��Left=�6U   $��15,0,0,0q�6p   $��Center=�6�   $��30(�6�   $��Century Gothic)�6�   5      5      	� 5   
   -   5        $��	rbEmpresa��5   d   $��Empresa��6   $��25��6(   $
��Left=�64   $��131,105,0,0q�6O   $	��Top=�6u   6�   	� 5   
   -   5        $��rbTipoServicio��5   n   $��Matricula Autobus��6   $��25��62   $
��Left=�6>   $��210,105,0,0q�6Y   $	��Top=�6�   6�   	� 5   
   -   5        $��rbFechaHora��5   n   $��Fecha de Servicio��6   $��25��62   $
��Left=�6>   $��342,105,0,0q�6Y   $	��Top=�6�   6�   	� 5   
   -   5        $��rbDNI��5   `   $	��DNI��6   $��25��6$   $
��Left=�60   $��464,105,0,0q�6K   $	��Top=�6m   6�   	� 5   
   -   5        $��	rbDefecto��5   d   $��Defecto��6   $��25��6(   $��Right=�64   $��
0,105,30,0q�6P   $	��Top=�6u    d� 	IsChecked$
 TrueY�6�   �� 5   
   -	   5        $��gbBuscar��5   c   $��Filtrar��6   $��75��6$   $��Stretch=�60   $��30,128,30,0q�6N   $	��Top=�6s   $��15(�6�   
���   �.��5      �  � ColumnDefinitions 5      �� 5      $
��548* �6'   �� 5      $
��458* �6'   .+�5!      �� -
   5        $��
lblEmpresa��5!   e   $��Empresa��6   $��28��6*   $
��Left=�66   $��
235,10,0,0q�6Q   $	��Top=�6w   y�5"      �� *	IsChecked+ �� ElementName$ 	rbEmpresa�� �� 	Converter# [ �� 5#      -   5        $��lblTipoServicio��5#   o   $��Matricula Autobus��6   $��28��64   $
��Left=�6@   $��
186,10,0,0q�6[   $	��Top=�6�   y�5$      �� *	IsChecked+$ rbTipoServicio��# [ �� 5%      -   5        $��lblFechaServicioI��5%   j   $��Fecha Inicial��6   $��28��60   $
��Left=�6<   $��	19,10,0,0q�6W   $	��Top=�6�   y�5&      �� *	IsChecked+$ rbFechaHora��# [ �� 5'      -   5        $��lblFechaServicioF��5'   i   $��Fecha Final��6   $��28��6.   $
��Left=�6:   $��
410,10,0,0q�6U   $	��Top=�6�   y�5(      �� *	IsChecked+$ rbFechaHora��# [ �� 5)      -   5        $��lblDni��5)   a   $	��DNI��6   $��28��6&   $
��Left=�62   $��
265,10,0,0q�6M   $	��Top=�6o   y�5*      �� *	IsChecked+$ rbDNI��# [ �� 5+      -   5        $��
cmbEmpresa��5+   V   $��27��6   $
��Left=�6'   $��
335,10,0,0q�6B   $	��Top=�6h   $	��400��6�   $��2��6�   y�5,      �� *	IsChecked+$ 	rbEmpresa��# [ �� 5-      -   5        $��txtMatricula��5-   I   $
��Left=�6   $��
335,10,0,0q�65   $	��400��6]   $��23��6i   $	��Top=�6u   $��2��6�   y�5.      �� *	IsChecked+$ rbTipoServicio��# [ 6u   (  "System.Windows.Controls.DatePicker  5/      -   5          Name$ dtpFechaInicial��5/      $��Right=�66   $��	0,9,183,0q�6R   $	��Top=�6e      SelectedDateFormat$ Short=�6}   $	��250��6�   y�50      �� *	IsChecked+$ rbFechaHora��# [  51      :  4System.Windows.Controls.Primitives.DatePickerTextBox �� 
TargetType �� Property �� Value ��Name �� Path �� StringFormat �� RelativeSource �� AncestorType��%�   '        �� 52      "  6    .�53      ��  � �� 54   "   �� 55   &   .R�56   *   �� $ PART_TextBox��62   ��57   )   �� $ SelectedDate�$ 
yyyy-MM-dd�� �� "  59   '   5;      5<      5=      5>        5?      -   5        $ dtpFechaFinal��5?      $��Right=�64   $��	0,9,245,0q�6P   $	��Top=�6c   $ Short=�6{   $	��250��6�   $��2��5@   v   y�6   �� *	IsChecked+$ rbFechaHora��# [  5A      ��%�   '        �� 5B      "  6    .�5C      ��  � �� 5D   "   �� 5E   &   .R�5F   *   �� $ PART_TextBox��62   ��5G   )   �� $ SelectedDate�$ 
yyyy-MM-dd�� �� "  5I   '   5K      5L      5M      5N      �� 5O      -   5        $��txtDni��5O   I   $
��Left=�6   $��
335,10,0,0q�65   $	��400��6W   $��23��6c   $	��Top=�6o   $��2��6�   y�5P      �� *	IsChecked+$ rbDNI��# [ 6l   �� 5R      -   5        $��	btnBuscar��5R   H   $��Right=�6   $��	0,6,118,0q�65     StyleBtnPrimary#��[ 6Y   $	��Top=�6�   $��1��6�   y�5S      �� *	IsChecked+$ 	rbEmpresa��# [ .��5T      �� $
 
Horizontal=�6!   .+�5U      �� $��/resources/buscar.png��6    �� 5V      $��10,0,0,0q�6$   $��Buscar��66   $��Center=�6D   5W      5X      �� 5Z      -   5        $��btnBuscarFechas��5Z   H   $��Right=�6   $��	0,6,118,0q�65   #��[ 6_   $	��Top=�6�   $��1��6�   y�5[      �� *	IsChecked+$ rbFechaHora��# [ .��5\      �� $
 
Horizontal=�6!   .+�5]      �� $��/resources/buscar.png��6    �� 5^      $��10,0,0,0q�6$   $��Buscar��66   $��Center=�6D   5_      5`      5a      5b      &   System.Windows.Controls.DataGrid  5j   
   -   5        $��	dgPasajes��5j   M      AutoGenerateColumns .  $��Stretch=�6/   $��Stretch=�6^   $��30,209,30,79q�5k         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6M     StyleDataGrid#���  5l         
IsReadOnly .    HeadersVisibility$ Column=�6M   $��Center=�6h      CanUserAddRows .  $   HorizontalScrollBarVisibility$
 Auto=�6�      VerticalGridLinesBrush 5k   )   Z�     Columns  5m      0  *System.Windows.Controls.DataGridTextColumn  5n      ,  &System.Windows.Controls.DataGridColumn!   Header$! Codigo��6%   "   Width$" 48 65   1  +System.Windows.Controls.DataGridBoundColumn#   Binding# 6@   �� *
PAS_Codigo+6a     5o      $! Asiento��6%   $" 50 66   # 6A   �� *PAS_Asiento+6d     5q      $! Fecha Venta��6%   # 6:   �� *PAS_FechaHora+6_     5r      $! Precio��6%   $" 50 65   # 6@   �� *
PAS_Precio+6b     5s      $! Nombre��6%   # 65   �� *
CLI_Nombre+6W     5t      $! Apellido��6%   # 67   �� *CLI_Apellido+6[     5u      $	! Dni��6%   $" 40 62   # 6=   �� *	CLI_Dni+6\     5v      $! Fecha Partida��6%   # 6<   �� *SER_FechaHora+6a     5w      $! Empresa��6%   $" 60 66   # 6A   �� *
EMP_Nombre+6c     5x      $! Origen��6%   # 65   �� *
CIU_Origen+6W     5y      $! Destino��6%   # 66   �� *CIU_Destino+6Y     5z      $! 	Matricula��6%   $" 60 68   # 6C   �� *AUT_Matricula+6h   5}      � 5~   
   $ � Orientation$$ 
Horizontal=�6   $��Bottom=�6-   $
��Left=�6H   $��	30,0,0,20q�6c   .+�5      �� -   5        $��
btnPreView��5   4   $��Center=�6   $��Bottom=�6F   #��[ 6a   .��5�      �� $
 
Horizontal=�6   .+�5�      �� $��/resources/agregar.png��6   �� 5�      $��Vista Previa��6    $��10,0,0,0q�64   $��Center=�6F   5�      5�      �� 5�      -   5        $��btnCancelar��5�   4   $��Center=�6   $��Bottom=�6G   #��[ 6b   $��10,0,0,0q�6�   .��5�      �� $
 
Horizontal=�6   .+�5�      �� $��/resources/agregar.png��6   �� 5�      $��Cancelar��6    $��10,0,0,0q�60   $��Center=�6B   5�      5�      5�      �� 5�   
   -   5        $��	lblBuscar��5�   a   $��Buscar por:��6   $��28��6&   $
��Left=�62   $��
36,100,0,0q�6M   $	��Top=�6r   �� 5�   
   $��	0 0 30 50q�6   $
 
Horizontal=�6(   $��Right=�6A   $��Bottom=�6]   .+�5�      �� -   5        $��lblPasajesVendidos��5�   X   $"��Cantidad de Pasajes Vendidos��6   $��28��6;   $��0,0,0,0q�6G   6X   �� 5�      -   5        $��txtPasajesVendidos��5�   3   $��23��6   $��0,0,0,0q�6"   $��70��6M   {�.  6X   5�      �� 5�   
   $��	0 0 30 25q�6   $
 
Horizontal=�6(   $��Right=�6A   $��Bottom=�6]   .+�5�      �� -   5        $��lblMontoTotal��5�   d   $��Monto Total $��6   $��28��6,   $
��Left=�68   $��0,0,0,0q�6S   $	��Top=�6y   �� 5�      -   5        $��txtMontoTotal��5�   O   $��23��6   $��Right=�6"   $��0,0,0,0q�6>   $	��Top=�6d   $��70��6|   {�.  6�   5�      �� 5�   
   $��0 0 30 0q�6   $
 
Horizontal=�6'   $��Right=�6@   $��Bottom=�6\   .+�5�      �� -   5        $��
lblHoraMax��5�   i   $��Hora De Mas Ventas��6   $��28��61   $
��Left=�6=   $��0,0,0,0q�6X   $	��Top=�6{   �� 5�      -   5        $��txtHora��5�   O   $��23��6   $��Right=�6"   $��0,0,0,0q�6>   $	��Top=�6^   $	��110��6v   {�.  6�   5�      5�      5�      
   M S B A M L   `   `   `  ����F  BClasesBases, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullnFclr-namespace:ClasesBases.Services.Implementation;assembly=ClasesBases#ClasesBases.Services.Implementation  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R8clr-namespace:System.ComponentModel;assembly=WindowsBaseSystem.ComponentModel 5      
 Vistas   Vistas.GestionPasajes   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      J FWpfAnimatedGif, Version=1.4.18.0, Culture=neutral, PublicKeyToken=null,gif"http://wpfanimatedgif.codeplex.com  5      _coleccionServiciosFclr-namespace:ClasesBases.Services.Implementation;assembly=ClasesBases  5      McomponentModel8clr-namespace:System.ComponentModel;assembly=WindowsBase  5      -   5        $��ucGestionPasajes��5
   8     � 	Resources  5         LIST_SERVICES S� 
ObjectType9   3ClasesBases.Services.Implementation.ServicioService S� 
MethodName  VISTA_SERVICES �� Source �� SortDescriptions+  %System.ComponentModel.SortDescription   PropertyName   	Direction��%�   &	        &	 :     7   S� 5   
   "  5      $ GetAllServices��5      �� 5   
   8    5        5      $ 
Ser_Codigo��61   $ 	Ascending=�6K   5      5      .��5!      �   StyleBodyGestion#���  6   .+�5'   
   &   System.Windows.Controls.DataGrid  -   5        $��dgServicios��5'   M      AutoGenerateColumns .  $��Stretch=�6/   $��Stretch=�6`   $��30,209,30,79q�5(         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6*     StyleDataGrid#���  5)      	   
IsReadOnly	 . 
   HeadersVisibility$
 Column=�6M   $��Center=�6h   ��5(   :   ��  �� Source# [    Columns 5*      0  *System.Windows.Controls.DataGridTextColumn  5+      ,  &System.Windows.Controls.DataGridColumn   Header$ Codigo��6%      Width$
 Auto 6T   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *
Ser_Codigo+6c     5,      $ Fecha y Hora��6%    6;   �� *Ser_FechaHora+ �� StringFormat$ {0: dd/MM/yyyy, HH:mm}��6�     5-      $ Empresa��6%    66   �� *Autobus.Empresa.Nombre+6c     5.      $ Nro Autobus��6%    6:   �� *Autobus.Codigo+6_     5/      $ Tipo Servicio��6%    6<   �� *Autobus.TipoServicio+6g     50      $ Origen��6%    65   �� *" TerminalOrigen.Ciudad.Ciu_Nombre+6l     51      $ Destino��6%    66   �� *#!TerminalDestino.Ciudad.Ciu_Nombre+6n     52      $ Estado��6%    65   �� *
Ser_Estado+6V   55      � 57   
    � Orientation$ 
Horizontal=�6   $��Bottom=�6-   $
��Left=�6H   $��	30,0,0,20q�6c   .+�58      �� -   5        $��
btnAgregar��58   C   $
��Left=�6   $��10,0,0,0q�61   $��Bottom=�6U     StyleBtnPrimary#��[ 6p   .��59      ��  �� Orientation$ 
Horizontal=�6   .+�5:      �� $��/resources/agregar.png��6   �� 5;      $��Nuevo��6    $��10,0,0,0q�6-   $��Center=�6?   5<      5=      �� 5>      -   5        $��btnPasajesVendidos��5>   B   $
��Left=�6   $��10,0,0,0q�60   #��[ 6\   $��Bottom=�6�   .��5?      �� $ 
Horizontal=�6   .+�5@      �� $��10,0,0,0q�6    $��Ver Pasajes Vendidos��62   $��Center=�6N   5A      5B      5C      �� 5D   
   -   5        $��	groupBox1��5D   d   $��Busqueda��6   $��80��6%   $��Stretch=�61   $��30,105,30,0q�6O     StyleGBBusqueda#���  6u   .��5E      � .+�5F      �� -   5        $��label1��5F   c   $��Fecha:��6   $��28��6)   $
��Left=�65   $��	15,12,0,0q�6P   $	��Top=�6q     
StyleLabel#���  6�   (  "System.Windows.Controls.DatePicker  5G      -   5        $��dpFecha��5G   W   $��25��6   $
��Left=�6)   $��	65,13,0,0q�6D   $	��Top=�6f   $	��120��6~   6�   �� 5H      -   5        $��label2��5H   n   $��Terminal Origen:��6   $��28��63   $
��Left=�6?   $��
210,12,0,0q�6Z   #���  6|   $	��Top=�6�   �� 5I      -	   5        $��label3��5I   o   $��Terminal Destino:��6   $��28��64   $
��Left=�6@   $��
503,12,0,0q�6[   #���  6}   $	��Top=�6�   �� 5J      -
   5        $��	txtOrigen��5J   U   $��25��6   $
��Left=�6&   $��
320,13,0,0q�6A   $	��Top=�6f   $	��150��6~   6�   �� 5K      -   5        $��
txtDestino��5K   U   $��25��6   $
��Left=�6&   $��
620,13,0,0q�6A   $	��Top=�6g   $	��150��6   6�   5L      5M      ]� 5N   
   -   5        $��	pnlTitulo��5N   ?   $��75��6   $��Stretch=�6    $	��Top=�6P     StyleHeaderGestion#���  6h    J� Effect 5O      3	  -System.Windows.Media.Effects.DropShadowEffect	  5P       	  Color$
 Gray��6#    	  	Direction$	 270Q�60    	  
BlurRadius$ 25Q�6@    	  ShadowDepth$ 5Q�6P   .+�5R      �� $ 
Horizontal=�6   $��Center=�62   .+�5S      ��   imgGestionPasajes#���  6   �� 5T      -   5        $��
textBlock1��5T   *   $
��Auto��6   $��Gestion de Pasajes��6<    	 StyleHeaderTitulo#��� 	 6V   5U      5V      5W      5X      
   M S B A M L   `   `   `  ����
  Vistas&     Vistas.CRUD.Pasajes.PrintPasajes   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  PrintPasajes��5   	   $	��500��6   $
��1100��6+    � WindowStartupLocation$ CenterScreen=�68   .��5      � .+�5   
   ]� -   5        $��pnlTitleCities��5   ?   $��75��6   $��Stretch=�6    $	��Top=�6U   ���#F7F7F7 J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$
 Gray��6#      	Direction$	 270Q�60      
BlurRadius$ 15Q�6@      ShadowDepth$ 2Q�6P   .+�5
      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   .+�5      �� $��/resources/pasajeN.png��6   $��64��69   $��64��6D   $��20,0,0,0q�6P   �� 5      -   5        $��	txtCities��5   *   $
��Auto��6   $��Listado de Pasajes��6;   $
��Left=�6U   $��15,0,0,0q�6p   $��Center=�6�   $��30(�6�   $��Century Gothic)�6�   5      5      -� 5   
    -� ViewingMode$ Scroll=�6   $��	0,76,0,53q�62   .��5      /� -   5        	 �Name$	 DocMain��5      .T�5      J� 
 �� TextAlignment$
 Center=�6   .*�64   Listado de Usuarios6I   �� 5      .r�5      &   System.Windows.Controls.DataGrid  -   5        $��	dgPasajes��5   Y      AutoGenerateColumns .  $��Stretch=�6;   $��Stretch=�6j   $��30,0,0,0q�5         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6I      StyleDataGrid#���   5         
IsReadOnly .    HeadersVisibility$ Column=�6M   $��Center=�6h      CanUserAddRows .  $   HorizontalScrollBarVisibility$
 Auto=�6�      VerticalGridLinesBrush 5   %   Z�    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Codigo��61      Width$ 48 6A   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6L   �� *
PAS_Codigo+6m     5      $ Asiento��61   $ 50 6B    6M   �� *PAS_Asiento+6p     5      $ Fecha��61    6@   �� *PAS_FechaHora+6e     5      $ Precio��61   $ 50 6A    6L   �� *
PAS_Precio+6n     5      $ Nombre��61    6A   �� *
CLI_Nombre+6c     5      $ Apellido��61    6C   �� *CLI_Apellido+6g     5      $	 Dni��61   $ 40 6>    6I   �� *	CLI_Dni+6h     5       $ Partida��61    6B   �� *SER_FechaHora+6g     5!      $ Empresa��61   $ 60 6B    6M   �� *
SER_Estado+6o     5"      $ Origen��61    6A   �� *
CIU_Origen+6c     5#      $ Destino��61    6B   �� *CIU_Destino+6e     5$      $ 	Matricula��61   $ 60 6D    6O   �� *AUT_Matricula+6t   5'      5(      5)      5*      �� 5,   
   -   5        $��btnPrint��5,   A   $
��Left=�6   $��
491,0,0,12q�6-   $��Bottom=�6Q     StyleBtnPrimary#��[ 5-      .��5.      �� $ 
Horizontal=�6   .+�5/      �� $��Imprimir��6   $��10,0,0,0q�6,   $��Center=�6>   50      51      52      53      
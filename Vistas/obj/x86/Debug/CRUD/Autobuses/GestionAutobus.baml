   M S B A M L   `   `   `  ����
  Vistas    Vistas.GestionAutobus   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5        $��ucGestionAutobus��5   8   .��5      �    StyleBodyGestion#���   6   .+�5
   
   ]� -   5        $��	pnlTitulo��5
   ?   $��75��6   $��Stretch=�6    $	��Top=�6P     StyleHeaderGestion#���  6h     J� Effect  5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$
 Gray��6#      	Direction$	 270Q�60      
BlurRadius$ 15Q�6@      ShadowDepth$ 2Q�6P   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   .+�5      ��   imgGestionAutoBus#���  6   �� 5      -   5        $��
textBlock1��5      $��Gestion de Autobus��6.     StyleHeaderTitulo#���  6H   5      5      �� 5   
   -   5        $��	groupBox1��5   X   $��Busqueda��6   $��Stretch=�6%   $��30,105,30,0q�6C   $	��Top=�6i     StyleGBBusqueda#���  6�   .��5      � .+�5      �� -   5        $��label1��5   [   $��	Matricula��6   $
��Left=�6-   $��	80,10,0,0q�6H   $	��Top=�6i     
StyleLabel#���  6�   �� 5      -   5        $��txtMatricula��5   O   $��Stretch=�6   $��210,10,120,0q�69   $	��Top=�6c     EstiloTextBox#��[ 6{   6�   5      5      &   System.Windows.Controls.DataGrid  5   
   -   5        $��dgAutobuses��5   ]      	RowHeight$ 30Q�6      AutoGenerateColumns .  $��Stretch=�6?   $��Stretch=�6p   $��30,209,30,79q�5         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6*     StyleDataGrid#���  6:   	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Numero coche��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *
AUT_Codigo+6\     5      $
 	Capacidad��6%    69   �� *AUT_Capacidad+6]     5       $
 Tipo Servicio��6%    6<   �� *AUT_TipoServicio+6c     5!      $
 	Matricula��6%    68   �� *AUT_Matricula+6\     5"      $
 Empresa��6%    66   �� *
EMP_Nombre+6W   4  .System.Windows.Controls.DataGridTemplateColumn  5$      $

 Foto��6)      CellTemplate 5%      �� 5&      .R�5'      �� $��45��6$   $��45��6/   ��6;   �� *
AUT_Imagen+6[   5(      5*      5.      � 50   
   $��Bottom=�6   $��	30,0,0,20q�6/   .+�51      �� -   5        $��
btnAgregar��51   1   $
��Left=�6   $��Bottom=�6C     StyleBtnPrimary#��[ 6^   .��52      �� $ 
Horizontal=�6   .+�53      �� $��/resources/agregar.png��6   �� 54      $��Nuevo��6    $��10,0,0,0q�6-   $��Center=�6?   55      56      �� 58      -	   5        $��	btnEditar��58   2   $
��Left=�6   $��	10,0,10,0q�6C   $��Bottom=�6V    	 StyleBtnGreed#��[	 6q   .��59      �� $ 
Horizontal=�6   .+�5:      �� $��/resources/editar.png��6   �� 5;      $��Editar��6    $��10,0,0,0q�6.   $��Center=�6@   5<      5=      �� 5?      -
   5        $��btnEliminar��5?   2   $
��Left=�6   $��Bottom=�6E    
 StyleBtnRed#��[
 6`   .��5@      �� $ 
Horizontal=�6   .+�5A      �� $��/resources/eliminar.png��6   �� 5B      $��Eliminar��6    $��10,0,0,0q�60   $��Center=�6B   5C      5D      5E      5F      5G      
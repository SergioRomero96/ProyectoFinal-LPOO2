   M S B A M L   `   `   `  ����F  BClasesBases, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null>.clr-namespace:ClasesBases;assembly=ClasesBasesClasesBases  5   	   
 Vistas   Vistas.AltaAutoBus   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   >svc.clr-namespace:ClasesBases;assembly=ClasesBases     5   	   -   5          � Title$  AltaAutoBus��5   	   $	��550��6   $	��350��6*    � WindowStartupLocation$ CenterScreen=�66    � 
ResizeMode$ NoResize=�6�    � 	Resources 5         tipo_servicio � Source � XPath��%^   &	        � 5   
   $* $/ServicesXML/AutobusTipoServicio.xml?�60   $ 
/servicios��6^   5      .��5	      �  � RowDefinitions 5
   
   �� 5      $��45 �6   �� 5      $��* �6   �� 5      $��55 �6   .+�5   
   ]� $��0��6   .+�5      �� -   5        $��
textBlock1��5   F   $
��Left=�6   $��10,0,0,0q�64   $��Registrar Autobus��6X   $��28(�6q   $��Bottom=�6   5      ]� 5   
   $��2��6   .+�5      �� -   5        $��
btnGuardar��5   V   $��Guardar��6   $��10,0,0,0q�6'   $
��Left=�6:   $��Center=�6h     StyleButtonGuardar#��[ 6�   �� 5      -   5        $��btnCancelar��5   V   $��Cancelar��6   $��0,0,10,0q�6(   $��Right=�6:   $��Center=�6i     StyleButtonCancelar#��[ 6�   6�   5      �� 5   
   -   5        $��	groupBox1��5   g   $��1��6   $��10q�6    $��Datos del Autobus��6,   $��Stretch=�6H   $��Stretch=�6x   .��5      �  � ColumnDefinitions 5      �� 5      $	��86* �6'   �� 5      $
��230* �6'   .+�5      �� -   5        $	��lbl��5   ^   $��Nro de Coche��6   $
��Left=�60   $��	-6,15,0,0q�6K   $	��Top=�6i   �� 5      -   5        $��	txtCodigo��5   W   $��24��6   $��Stretch=�6&   $��	0,15,13,0q�6D   $	��Top=�6h    �� 	MaxLength$ 7��6�   $��1��6�     EstiloTextBoxIdataError#��[ 6�   ��6�   �� 	 �� Path$	 Codigo�
 �� ValidatesOnDataErrors
 .  �� UpdateSourceTrigger$ PropertyChanged=��� 5      -   5        $��
lblEmpresa��5   Y   $��Empresa��6   $
��Left=�6+   $��	14,65,0,0q�6F   $	��Top=�6k   �� 5       -	   5        $��
cmbEmpresa��5    X   $��24��6   $��Stretch=�6'   $��	0,65,12,0q�6E   $	��Top=�6j   $��1��6�    �� Text 6�   �� $	 Empresa�
 . $ PropertyChanged=��� 5"      -
   5        $��label2��5"   g   $��	Capacidad��6   $��32��6,   $
��Left=�68   $��
14,115,0,0q�6S   $	��Top=�6u   �� 5#      -   5        $��txtCapacidad��5#   Z   $��24��6   $��Stretch=�6(   $��
0,115,12,0q�6F   $	��Top=�6n   $��1��6�    �� SelectedIndex$ 0��6�    6�   �� $	 	Capacidad�
 . $ PropertyChanged=�6�   �� 5$      -   5        $��label3��5$   W   $
��Tipo��6   $
��Left=�6(   $��
40,165,0,0q�6C   $	��Top=�6e   �� 5%      -   5        $��cmbTipo��5%   Y   $��24��6   $��Stretch=�6'   $��
0,165,12,0q�6E   $	��Top=�6h   $��1��6�   $ 4��6�   ��6�   ��  �� Source# [   �� XPath$ 
tipo/@name��6�   �� 5&      -   5        $��label1��5&   g   $��	Matricula��6   $��32��6,   $
��Left=�68   $��
20,215,0,0q�6S   $	��Top=�6u   �� 5'      -   5        $��txtMatricula��5'   X   $��24��6   $��Stretch=�6&   $��
0,215,12,0q�6D   $	��Top=�6l   $ 8��6�   $��1��6�   #��[ 6�   ��6�   �� $	 	Matricula�
 . $ PropertyChanged=��� 5(      -   5        $��lblPisos��5(   c   $��Pisos��6   $��32��6(   $
��Left=�64   $��
20,265,0,0q�6O   $	��Top=�6s   �� 5)      -   5        $��cmbPisos��5)   Y   $��24��6   $��Stretch=�6'   $��
0,265,12,0q�6E   $	��Top=�6i   $��1��6�   $ 0��6�   6�   �� 5,      -   5        $��lblFoto��5,   b   $
��Foto��6   $��32��6'   $
��Left=�63   $��
20,310,0,0q�6N   $	��Top=�6q   �� 5-      -   5        $��	mediaFoto��5-   X   $��80��6   $	��120��6)   $��1��65   $��	0 300 0 0q�6E   $��Stretch=�6i   50      �� 54      -   5        $��1��54      $��20��6)   $��15��64   $��0 0 0 10q�6@   $��Right=�6R   $��Bottom=�6n   $	��...��6�   $��11(�6�   $��Black"�6�   $��Arial)�6�   6�   57      58      59      5:      
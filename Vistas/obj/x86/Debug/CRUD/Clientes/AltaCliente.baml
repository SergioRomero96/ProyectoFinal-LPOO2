   M S B A M L   `   `   `  ����F  BClasesBases, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null>.clr-namespace:ClasesBases;assembly=ClasesBasesClasesBases  5   	   
 Vistas   Vistas.AltaCliente   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   >svc.clr-namespace:ClasesBases;assembly=ClasesBases     5   	   -   5          � Title$  Gestion de Cliente��5   	   $	��500��6$   $	��350��61    � WindowStartupLocation$ CenterScreen=�6=    � 
ResizeMode$ NoResize=�6{   .��5      �  � RowDefinitions 5   
   �� 5      $��45 �6   �� 5      $��* �6   �� 5      $��55 �6   .+�5   
   ]� $��0��6   .+�5      �� -   5        $��
textBlock1��5   F   $
��Left=�6   $��10,0,0,0q�64   $��Nuevo Cliente��6X   $��28(�6m   $��Bottom=�6{   5      ]� 5   
   $��2��6   ���#F0F0F0.+�5      �� -   5        $��button1��5   U   $��Guardar��6   $
��Left=�6'   $��10,0,0,0q�6C   $��Center=�6d      StyleButtonGuardar#��[  6�   $��2��6�   �� 5      -   5        $��button2��5   X   $��Cancelar��6   $��Right=�6)   $��0,0,10,0q�6F   $��Center=�6g     StyleButtonCancelar#��[ 6�   $��2��6�   5      �� 5   
   -   5        $��	groupBox1��5   B   $��Datos��6   $��Stretch=�6#   $��Stretch=�6S   $��10q�6p   $��1��6|   
���   �.��5      �  � ColumnDefinitions 5       �� 5!      $	��69* �6'   �� 5"      $
��235* �6'   .+�5$      �� -   5        $	��Dni��5$   U   $	��Dni��6   $
��Left=�6'   $��	36,25,0,0q�6B   $	��Top=�6`   �� 5%      -   5        $��txtDni��5%   l    �� 
AcceptsTab .  $��Stretch=�6-   $��	3,21,25,0q�6K    �� 	MaxLength$ 8��6^     EstiloTextBoxIdataError#��[ 5&      $	��Top=�6K   $��1��6c   .��6�   ��5'      �� 5(       �� Path$	 Dni�6"    �� UpdateSourceTrigger$ PropertyChanged=�6-   	 �� ValidatesOnExceptions	 . 
 �� ValidatesOnDataErrors
 . 5)   ?   .��5*   $   5+      �� 5,      -   5        $��label1��5,   X   $��Nombre��6   $
��Left=�6*   $��	10,80,0,0q�6E   $	��Top=�6f   �� 5-      -	   5        $��	txtNombre��5-   =   $��
3,0,25,212q�6   $ 15��6.   #��[ 5.      $��Bottom=�6M   $��1��6h   .��6�   ��5/      �� 50      $ Nombre�6"   $ PropertyChanged=�60   	 . 
 . 51   ?   .��52   $   53      �� 54      -
   5        $��label2��54   [   $��Apellido��6   $
��Left=�6,   $��
10,135,0,0q�6G   $	��Top=�6i   �� 55      -   5        $��txtApellido��55   [   $��Stretch=�6   $��
3,131,25,0q�68   $ 15��6L   #��[ 56      $	��Top=�6K   $��1��6c   .��6�   ��57      �� 58      $ Apellido�6"   $ PropertyChanged=�62   	 . 
 . 59   ?   .��5:   $   5;      �� 5<      -   5        $��label3��5<   Z   $��Telefono��6   $
��Left=�6,   $��	8,194,0,0q�6G   $	��Top=�6h   �� 5=      -   5        $��txtTelefono��5=   [   $��Stretch=�6   $��
3,190,25,0q�68   $ 10��6L   #��[ 5>      $	��Top=�6L   $��1��6d   .��6�   ��5?      �� 5@      $ Telefono�6"   $ PropertyChanged=�62   	 . 
 . 5A   ?   .��5B   $   5C      �� 5D      -   5        $��label4��5D   X   $��Email��6   $
��Left=�6)   $��
26,250,0,0q�6D   $	��Top=�6f   �� 5E      -   5        $��txtEmail��5E   [   $��Stretch=�6   $��
3,246,25,0q�68   $ 25��6L   #��[ 5F      $	��Top=�6L   $��1��6d   .��6t   ��5G      �� 5H      $ Email�6"   $ PropertyChanged=�6/   	 . 
 . 5I   ?   .��5J   $   5K      5L      5M      5N      5O      
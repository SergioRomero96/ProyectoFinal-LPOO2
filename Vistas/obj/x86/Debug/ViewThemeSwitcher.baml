   M S B A M L   `   `   `  ����
  Vistas    Vistas.ViewThemeSwitcher   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  ViewThemeSwitcher��5   	   $	��400��6#   $	��450��60    � WindowStartupLocation$ CenterScreen=�6<    � 
ResizeMode$ NoResize=�6a    � 	Resources 5         tema � Source � XPath��%T   &	        � 5   
   $# /ServicesXML/ThemeService.xml?�6'   $ /themes��6N   5      .��5      �  � RowDefinitions 5	   
   �� 5
      $	��83* �6   �� 5      $
��225* �6   �� 5      $	��52* �6   .+�5   
   �� -   5        $��imgTema��5   D   $��Stretch=�6   $��10,10,10,10q�6/   $
��Fill=�6S   $��Stretch=�6b   $��1��6~   $��/resources/imgLight.png��6�   �� 5   
   -   5        $��	groupBox1��5   [   $��Seleccionar��6   $��Stretch=�6)   $��
10,10,10,0q�6G   $��Stretch=�6l   $��15(�6�   .��5      �  � ColumnDefinitions 5      �� 5      $	��55* �6'   �� 5      $
��231* �6'   .+�5      �� -   5        $��label1��5   F   $��Tema:��6   $��Center=�6(   $	��Top=�6T   $��5,5,0,0q�6l   �� 5      -   5        $��cmbTemas��5   \   $��1��6   $��Stretch=�6,   $��5,7,10,0q�6J   $	��Top=�6l   ��5      ��  �� Source# [  	 �� XPath$	 option/@name��6c   5      5      ]� 5   
   $��0,0,0,0q�6   $��2��6%   .+�5      �� -   5        $��
btnAplicar��5   V   $��Aplicar��6   $��10,0,0,0q�6'   $
��Left=�6:   $��Center=�6h     StyleBtnPrimary#��[ 6�   6�   �� 5      -   5        $��btnCancelar��5   V   $��Cancelar��6   $��0,0,10,0q�6(   $��Right=�6:   $��Center=�6i     StyleBtnSecondary#��[ 6�   6�   5      5      5      
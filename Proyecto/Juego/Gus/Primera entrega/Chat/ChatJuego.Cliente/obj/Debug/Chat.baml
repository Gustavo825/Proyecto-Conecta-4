   M S B A M L   `   `   `  ����L  HChatJuego.Cliente, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ChatJuego.ClienteChatJuego.Cliente  5   	       ChatJuego.Cliente.Chat   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:ChatJuego.Cliente     5   	   -   5          � Title$
  Chat��5   	   $	��450��6   $	��800��6#   .��5	      � 
������� � RowDefinitions 5
   
   �� 5      $��31 �6   6*   �� 5      $��* �6   6)   �� 5      $��60 �6   6*    � ColumnDefinitions 5   
   �� 5      $��* �6   6+   .+�5   
   � $��0��6   .+�5      �� -   5        $��Titulo��5      $��	Conectado��6"   
�������
���   �$
��Left=�6a   $��1q�6�   6�   5      � 5   
   $��1��6   
����d� 5      �� 5      $	��150 �6#   61   �� 5      $��* �6#   6/   .+�5      �� -   5        $��Scroller��5      $��0��6+   $��Disabled=�6<   $
��Auto=�6e   
������ .��5      �� -   5        $��UsuariosConectados��5      ��5      �� 5      .R�5      � $��5q�6#    5   "   �� 5    &   $��32 �64   6B   .+�5"   "   � $��0��6'   .+�5#   &   ��  �� Orientation$ 
Horizontal=�61   .+�5$   *   �� -   5        $��Center=�5$   0   $��Center=�6T   ��6q   �� *UsuarioConectado+6�   5%   '   5&   #   5'      5(      5*      5+      �� 5,      -   5        $��ScrollerContenido��5,      $��1��64   $��Disabled=�6D   $
��Auto=�6m   
�����f�.��5-      �� -   5        $��PlantillaMensaje��5-      ��5.      �� 5/      .R�50      � $��5q�6#   ��6.   �� *FondoElemento+ 51   "   �� 52   &   $��32 �64   6B   �� 53   &   $��* �64   6A   .+�55   "   � $��0��6'   .+�56   &   �� $ 
Horizontal=�61   ��6J   �� *FondoCabecera+.+�57   *   �� $
��Left=�6K   ��60   �� *Nombre+6h   �� 58   *   $��Right=�6R   ��60   �� *TiempoDeEnvio+6p   59   '   5:   #   � 5;   "   $��1��6'   .+�5<   &   �� $ 
Horizontal=�61   .+�5=   *   �� $��Right=�60   $��Right=�6S   ��6o   �� *MensajeEnviado+6�   5>   '   5?   #   5@      5A      5C      5D      5E      � 5F   
   $��2��6   
�������.+�5G      �� $ 
Horizontal=�6   .+�5H      �� -   5        $��ContenidoDelMensaje��5H      
�������$	��600��6N    �� TextWrapping$
 Wrap=�6Z    �� AcceptsReturn . $��10q�6�   6�   �� 5I      -	   5        $��BotonEnviar��5I      $��Enviar��6,   $��20q�6=   $��Right=�6I   
�������$	��138��6z   
���   �6�   5J      5K      5L      5M      
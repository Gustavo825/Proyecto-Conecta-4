   M S B A M L   `   `   `  ����L  HChatJuego.Cliente, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ChatJuego.ClienteChatJuego.Cliente  5   	       ChatJuego.Cliente.Chat   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:ChatJuego.Cliente     5   	     � Title$
  Chat��5   	   $	��450��6   $	��800��6#   ���#F2F5FF.��5      � 
������� � RowDefinitions 5   
   �� 5      $��31 �6   6*   �� 5      $��* �6   6)   �� 5      $��60 �6   6*    � ColumnDefinitions 5   
   �� 5      $��* �6   6+   .+�5   
   � $��0��6    5      �� 5      $	��150 �6#   61   �� 5      $��* �6#   6/   .+�5      �� -   5         ��Name$ TextoJugadoresConectados��5   %   $��0��6   $��Jugadores conectados��6G   $��Center=�6f   $��Center=�6�   ���#D2DFFF$��A.C.M.E. Explosive)�6�   $��10(�6�   �� 5      -   5        $ Titulo��5   $   $��1��6   $��	Conectado��64   ���#D2DFFF
���   �$��Center=�6p   $��Center=�6�   $��A.C.M.E. Explosive)�6�   6�   5      � 5   
   $��1��6    5      �� 5      $	��150 �6#   61   �� 5       $	��52* �6#   61   �� 5!      $
��118* �6#   �� 5"      $
��229* �6#   �� 5#      $
��243* �6#   .+�5%      �� -   5        $��Scroller��5%      $��0��6+   $��Disabled=�6<   $
��Auto=�6e   
�������.��5&      �� -   5        $��UsuariosConectados��5&      ��5'      �� 5(      .R�5)      � $��5q�6#    5*   "   �� 5+   &   $��32 �64   6B   .+�5-   "   � $��0��6'   .+�5.   &   �� 
�������
���   �$��1,1,1,1q�6T    �� CornerRadius$ 5,5,5,5��6n   ._�5/   *   ��  �� Orientation$ 
Horizontal=�65   $��Center=�6N   $��Center=�6k   .+�50   .   �� ��64   �� *ImagenDeJugador+6Y   �� 51   .   -   5        $��Center=�51   4   $��Center=�6X   ��6u   �� *UsuarioConectado+6�   52   +   53   '   54   #   55      56      58      59      �� 5:      -   5        $��ScrollerContenido��5:      $��1��64   $��Disabled=�6D   $
��Auto=�6m   ���#F2F5FF$��4��6�   .��5<      �� -   5        $��PlantillaMensaje��5<      ��5=      �� 5>       � 	Resources 5?         ItemAnimation g� AutoReverse �� 
TargetName	 �� TargetProperty9  3System.Windows.Media.Animation.EasingDoubleKeyFrame
 O� KeyTime O� Value��%�  &	        �� 5@   "    .  .��5A   &   U� $ MyGrid��6D   $	 (UIElement.Opacity)�6c   .\�5B   *     $
 0��6?   $ 0Q�6K     5C   *   $
 0:0:0.5��6?   $ 1Q�6Q   5D   '   U� 5E   &   $ MyGrid��6D   $8	 2(UIElement.RenderTransform).(TranslateTransform.X)�6c   .\�5F   *     $
 0��6?   $ 0Q�6K     5G   *   $
 0:0:0.1��6?   $ 1Q�6Q   5H   '   5I   #   5J       �� Triggers 5K      :� 5L   "    :� RoutedEvent$ FrameworkElement.Loaded��6/   .[�5M   &   �� #��[  66   5N   #   .R�5P      �  �Name$ MyGrid��6#    J� RenderTransformOrigin$ 0.5,1&�63   $��5q�6{   ��6Q   �� *
Posicion+��6�   �� *FondoElemento+ 5Q   "   �� 5R   &   $��32 �64   6B   �� 5S   &   $��* �64   6A   z�5U   "   V� 5V   &   .~�5W   *   �� 5X   '   .+�5Z   "   � $��0��6'   .+�5\   &   �� $ 
Horizontal=�61   ��6J   �� *FondoCabecera+.+�5]   *   �� $
��Left=�6K   ��60   �� *Nombre+6h   �� 5^   *   $��Right=�6R   ��60   �� *TiempoDeEnvio+6p   5_   '   5`   #   � 5a   "   $��1��6'   .+�5b   &   �� $ 
Horizontal=�61   ���#DCEFFF.+�5c   *   �� $��Right=�60   $��Right=�6S   ��6o   �� *MensajeEnviado+6�   5d   '   5e   #   5f      5g      5i      5j      5l      � 5m   
   $��2��6   
������� 5n      �� 5o      $	��700 �6#   5p      �� 5q      $��* �6#   6/   .+�5s      �� -   5        $��ContenidoDelMensaje��5s   '   $��0��6   $��Center=�6C   
�������$	��665��6x    �� TextWrapping$
 Wrap=�6�   $��10q�6�   6�   �� 5t      -	   5         ��Name$ BotonEnviar��5t   %   $��1��6   $��0q�6;   
������ $��70��6j   $��40��6u   
������  � 	Resources 5u       �� 
TargetType �� Property �� Value��%_   '��       �� 5v      " ��6   .�5w      ��  �@��CornerRadius$ 60��69   5x      5y      .��5z      �� -
   5         ��Name$ ImagenBotonEnviar��5z      $��Iconos\botonEnviar.png��63   $��30��6S   $��65��6_   5{      5|      5}      5~      
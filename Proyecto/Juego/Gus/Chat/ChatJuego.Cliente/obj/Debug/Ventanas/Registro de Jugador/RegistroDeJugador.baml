   M S B A M L   `   `   `  ����L  HChatJuego.Cliente, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ChatJuego.ClienteChatJuego.Cliente  5   	   )    #ChatJuego.Cliente.RegistroDeJugador   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:ChatJuego.Cliente     5   	   -   5          �Name$!  Ventana_Registro_De_Jugador��5   	    � Title$ Registro De Jugador��5	   	   $	��500��6%   $	��800��62   .��5
      � ���#214CAE � ColumnDefinitions 5   
   �� 5      $��5* �6   �� 5      $	��61* �6    � RowDefinitions 5   
   �� 5      $��80 �6   �� 5      $��60 �6   �� 5      $��25 �6   �� 5      $��30 �6   �� 5      $��25 �6   �� 5      $��30 �6   �� 5      $��25 �6   �� 5      $��30 �6   �� 5      $��25 �6   �� 5      $��30 �6   �� 5      $��* �6   .+�5   
   � $��0��6   $��2��6   .+�5      �� -   5         ��Name$ Titulo_Registro��5      $��Iconos\registro.png��6-   $��75��6J   6X   5       � 5!   
   $��1��6   $��2��6    5"      �� 5#      6%   �� 5$      6%   �� 5%      6%   .+�5'      �� -   5        $��imagenJugador��5'      $%��Iconos/imagenPredeterminada.png��6)   $��60��6R   $��60��6^   $��1��6i   $��Center=�6y   6�   �� 5(      -   5         ��Name$ Boton_Imagen��5(      $��Imagen��6+   $��30��6<   $��60��6H   $��2��6S   $
��Left=�6c   6�   5)      � 5*   
   $��3��6   $��2��6   .+�5+      �� -   5        $ Texto_Usuario��5+      $��Iconos\usuario.png��6+   $��177,0,394,0q�6G   6^   �� 5,      -   5         ��Name$ 
TBUsuarioR��5,      $��Center=�6*    �� TextWrapping$
 Wrap=�6G   $��Center=�6[   $	��250��6v   $��22��6�   $��403,4,139,4q�6�   5.      � 5/   
   $��3��6   $��2��6   51      � 52   
   $��5��6   $��2��6   .+�53      �� -   5        $ Texto_Correo��53      $��Iconos\correo.png��6*   $��165,0,394,0q�6E   6\   �� 54      -   5        $��	TBCorreoR��54      $��Center=�6'   $
 Wrap=�6E   $��Center=�6Y   $	��250��6t   $��22��6�   $��403,4,139,4q�6�   6�   56      � 57   
   $��5��6   $��2��6   59      � 5:   
   $��7��6   $��2��6   .+�5;      �� -	   5        $ Texto_Contrasenia��5;      $��Iconos\contrasenia.png��6/   $��159,0,394,0q�6O   6f   G� 5<      -
   5        $��TBContraseniaRegistro��5<      $��Center=�67   $��Center=�6U   $	��250��6p   $��22��6|   $��403,4,139,4q�6�   6�   5>      � 5?   
   $��8��6   $��2��6    5@      �� 5A      $	��43* �6#   �� 5B      $
��353* �6#   5E      � 5F   
   $��9��6   $��2��6   .+�5G      �� -   5        $! Texto_Confirmar_Contrasenia��5G      $%��Iconos\confirmarContrasenia.png��69   $��
26,0,389,0q�6b   6x   G� 5H      -   5         G�Name$' !TBContraseniaRegistroConfirmacion��5H      $��Center=�6E   $��Center=�6b   $	��250��6}   $��22��6�   $��403,4,139,4q�6�   5J      � 5K   
   $��10��6   $��2��6    5L      �� 5M      6%   �� 5N      $��20 �6#   60   �� 5O      6%   .+�5Q      �� -   5        $ BotonRegistrarse��5Q   %   $��0��6   $��62��6?   $	��176��6K   $��0q�6W   
������ 
������ $��Right=�6�   	 � 	Resources	 5R      
 �� 
TargetType �� Property �� Value��%_   '��       �� 5S      "
 ��6   .�5T      ��  �@��CornerRadius$ 60��69   5U      5V      .��5W      �� -   5        $ Boton_Registrarse��5W      $!��Iconos\botonRegistrarse.png��63   $��62��6X   $	��176��6d   5X      �� 5Y      -   5        $ BotonCancelarR��5Y   =   $��2��6   $��62��6%   $	��176��61   $��0q�6U   
������ 
������ $
��Left=�6�   	 5Z      ��%_   '��       �� 5[      "
 ��6   .�5\      ��  �@��CornerRadius$ 60��69   5]      5^      .��5_      �� -   5        $ Boton_Cancelar��5_      $��Iconos\botonCancelar.png��60   $��62��6R   $	��176��6^   5`      5b      5c      5d      
   M S B A M L   `   `   `  ����D  @Conecta 4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ChatJuego.ClienteChatJuego.Cliente  5   	   %    ChatJuego.Cliente.MenuPrincipal   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   
   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:ChatJuego.Cliente     5   	   -   5          �Name$  Ventana_Menu��5   	    � Title$ Menu Principal��5	   	   $	��450��6    $	��800��6-   .��5
      � ���#214CAE � RowDefinitions 5   
   �� 5      $��90 �6   6*   �� 5      $��90 �6   6*   �� 5      $��90 �6   6*   �� 5      $��90 �6   6*   �� 5      $��90 �6   6*    � ColumnDefinitions 5   
   �� 5      $	��150 �6   6-   �� 5      $��* �6   6+   �� 5      $	��150 �6   6-   .+�5   
   �� -   5         ��Name$ TituloVentana��5   -   $��1��6   $��0��6    $��Iconos\conecta 4.png��6D   �� 5   
   -   5         ��Name$ BotonCrearParida��5   .   $��1��6   $��1��6!   $��0q�6H   $��24,10,24,10q�6\   $��80��6q   $	��180��6}   
������ .��5      �� -   5        $ BotonCrear_Partida��5   6   $��Iconos\crear_partida.png��6   $��62��6S   $	��176��6_   5      �� 5   
   -   5        $ BotonUnirsePartida��5   .   $��1��6   $��2��6!   $��0q�6J   $��24,10,24,10q�6^   $��80��6s   $	��180��6   
������ .��5      �� -   5        $ BotonUnirse_Partida��5   9   $!��Iconos\unirse_a_partida.png��6   $��62��6V   $	��176��6b   5      �� 5   
   -   5        $ 
BotonSalir��5      $��1��6%   $��3��65   $��0q�6B   $��24,10,24,10q�6V   $��80��6k   $	��180��6w   
������ .��5      �� -   5        $ Boton_Salir��5   .   $��Iconos\salir.png��6   $��62��6C   $	��176��6O   5       �� 5!   
   -	   5        $ BotonTablaPuntajes��5!   .   $��2��6   $��3��6!   $��0q�6J   
������ 
������ $��90��6�   $��50��6�   $��Center=�6�   $��Center=�6�   $��28,77,32,53q�6�   $��2��6  .��5"      �� $��Iconos\tablaPuntajes.png��6   $��50��66   $��90��6B   5#      �� 5$   
   -
   5        $ BotonConfiguracion��5$   .   $��0��6   $��0��6!   $��0q�6J   
������ 
������ $	��100��6�   $��50��6�   $��Center=�6�   $��Center=�6�   $��22,18,28,22q�6�   .��5%      �� $#��Iconos\iconoConfiguracion.png��6   5&      �� 5'   
   -   5        $ 	BotonChat��5'   .   $��2��6   $��0��6!   $��0q�6A   
������ 
������ $	��100��6�   $��50��6�   $��Center=�6�   $��Center=�6�   $��22,18,28,22q�6�   .��5(      �� $��Iconos\chat.png��6   5)      5*      5+      
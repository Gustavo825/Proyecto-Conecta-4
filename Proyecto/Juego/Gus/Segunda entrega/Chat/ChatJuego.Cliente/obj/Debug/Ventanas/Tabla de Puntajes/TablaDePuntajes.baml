   M S B A M L   `   `   `  ����L  HChatJuego.Cliente, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ChatJuego.ClienteChatJuego.Cliente  5   	   '    !ChatJuego.Cliente.TablaDePuntajes   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:ChatJuego.Cliente     5   	     � Title$  TablaDePuntajes��5   	   $	��450��6!   $	��800��6.   .��5	      � 
������� � RowDefinitions 5
   
   �� 5      $��31 �6   6*   �� 5      $��* �6   6)    � ColumnDefinitions 5   
   �� 5      $��* �6   6+   .+�5   
   � $��0��6   .+�5      �� -   5        $��Titulo��5      $#��Tabla de mejores puntuaciones��6"   ���#D2DFFF
���   �$��Center=�6r   $��Center=�6�   $��1q�6�   $��A.C.M.E. Explosive)�6�   6�   5      � 5   
   $��1��6   
����d� 5      �� 5      $��* �6#   6/   .+�5      �� -   5        $��ScrollerContenido��5      $��1��64   $��Disabled=�6D   $
��Auto=�6m   ���#F2F5FF.��5      �� -   5        $"��PlantillaTablaDePuntuaciones��5      ��5      �� 5      .R�5      � $��5q�6#   ��6.   �� *FondoElemento+ 5   "   �� 5   &   $��32 �67   6E   �� 5   &   $��* �67   6C   �� 5    &   $	��100 �67   6E   .+�5"   "   � $��0��6'   .+�5#   &   �� 
���   �$��1 1 1 1q�6B   ._�5$   *   ��  �� Orientation$ 
Horizontal=�65   ��6N   �� *FondoPosicion+.+�5%   .   �� $��Center=�6N   $��A.C.M.E. Explosive)�6k   ��64   �� *Lugar+6�   5&   +   5'   '   5(   #   � 5)   "   $��1��6'   .+�5*   &   �� 
���   �$��1 1 1 1q�6B   ._�5+   *   �� $ 
Horizontal=�65   .+�5,   .   �� $��Right=�64   $
��Left=�6W   $��A.C.M.E. Explosive)�6�   ��6r   �� *NombreJugador+6�   5-   +   5.   '   5/   #   � 50   "   $��2��6'   .+�51   &   �� 
���   �$��1 1 1 1q�6B   ._�53   *   �� $ 
Horizontal=�65   .+�54   .   �� $��Right=�64   $��Center=�6W   $��A.C.M.E. Explosive)�6�   ��6t   �� *	Puntaje+6�   55   '   56   '   58   #   59      5:      5<      5=      5>      5?      5@      
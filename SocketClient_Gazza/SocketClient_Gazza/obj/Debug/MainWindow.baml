   M S B A M L   `   `   `  ����M  ISocketClient_Gazza, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:SocketClient_GazzaSocketClient_Gazza  5   	   #    SocketClient_Gazza.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:SocketClient_Gazza     5   	     � Title$  CLIENT��5   	   $	��386��6   $	��557��6%   .��5	      � $��	0,0,0,106q�6    � ColumnDefinitions 5
   
   �� 5      .+�5   
   �� -   5         ��Name$ 	btn_Invio��5      $��Invia messaggio��6$   $
��Left=�6>   $��
49,201,0,0q�6Y   $	��Top=�6m   $��32��6�   $��94��6�   �� 5   
   -   5         ��Name$ 	lst_Lista��5      $��233,150,62,-40q�6%   $	��NaN��6=   $	��NaN��6J   �� 5   
   -   5         ��Name$ txt_Inserisci��5      $
��Left=�6)   $��
325,36,0,0q�6D    �� TextWrapping$
 Wrap=�6X   $	��Top=�6l   $	��162��6�   $��26��6�   �� 5   
   -   5        $ txtMessaggio��5      $
��Left=�6(   $��
10,150,0,0q�6C   $
 Wrap=�6W   $	��Top=�6k   $	��172��6�   $��22��6�   �� 5   
   -   5         ��Name$ lbl_LocalIp��5      $��Label��6%   $
��Left=�65   $��	10,10,0,0q�6P   $	��Top=�6c   $	��142��6{    J� Opacity$
 0.99Q�6�   $y�Hidden=�6�   �� 5   
   -   5        $ txt_IpLocal��5      $
��Left=�6'   $��	70,36,0,0q�6B   $
 Wrap=�6U   $	��Top=�6i   $	��162��6�   $��26��6�   �� 5   
   $��	Ip server��6   $
��Left=�6$   $��
265,36,0,0q�6?   $	��Top=�6S   �� 5   
   $��	Ip locale��6   $
��Left=�6$   $��	10,36,0,0q�6?   $	��Top=�6R   �� 5   
   $��Messaggio da inviare��6   $
��Left=�6/   $��
10,119,0,0q�6J   $	��Top=�6^   $	��121��6v   �� 5   
   -   5        $��line7��5      
���   �$��2��6+   	 �� X1$ 10��6?   		 �� X2$		 578��6G   	
 �� Y1$
 70��6P   	 �� Y2$ 70��6X   $��-19,23,-7,139q�6`   �� 5   
   $��Messaggi ricevuti��6   $
��Left=�6,   $��233,119,0,0q�6G   $	��Top=�6\   $	��122��6t   5      5      
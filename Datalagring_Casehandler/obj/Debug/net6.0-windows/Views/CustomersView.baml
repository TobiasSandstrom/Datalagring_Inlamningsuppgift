   M S B A M L   `   `   `  ����R  NDatalagring_Casehandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:Datalagring_Casehandler.ViewsDatalagring_Casehandler.Views  5      1    +Datalagring_Casehandler.Views.CustomersView   5      W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:Datalagring_Casehandler.Views     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��Kunder��6!   $��18(�6/   �� 5   
   $��1��6   $��10 20q�6"   .+�5      �� -   5         ��Name$ lbCases��5      $8��2Välj vilket kund ni vill se information om nedan:��6%   �� 5      -   5         ��Name$ cbCustomers��5      �� 5      -   5        $ lbCustomerError��5      $4��.Det finns inga kunder registrerade i databasen��6-   
���  ��$y�	Collapsed=�6w   �� 5      -   5         ��Name$ 	BtnSubmit��5      $��	Visa kund��6(   $	��200��6<   $��30��6H   $��0 20 0 0q�6T   6f   �� 5      $��10 20q�6   $��1q�6$   
���   �._�5      �� $��10q�6   .+�5      �� $��16(�6_   $��	Underline{�6m   $
��Bold"�6�   $��0 0 0 5q�6�   ��6    ��  �� Path$
 Name� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5      $��Namn:��6    $��14(�6-   $��	Underline{�6;   $
��Bold"�6W   $��0 0 0 5q�6i   �� 5      $��20 0 0 5q�6C   ��6$   �� $ FullName�6C   �� 5       $��20 0 0 5q�6O   ��6$   �� $ SocialSecurityNumber�6O   �� 5#      $��Kontakt:��6    $��14(�60   $��	Underline{�6>   $
��Bold"�6Z   $��0 0 0 5q�6l   �� 5&      $��20 0 0 5q�6<   ��6    �� $ Email�6<   �� 5)      $��20 0 0 5q�6B   ��6    �� $ PhoneNumber�6B   �� 5+      $��Adress:��6    $��14(�6/   $��	Underline{�6=   $
��Bold"�6Y   $��0 5 0 5q�6k   �� 5,      $
��20 0q�6=   ��6    �� $ Adress�6=   �� 5-      $
��20 0q�6B   ��6    �� $ ZipcodeCity�6B   �� 5.      $
��20 0q�6>   ��6    �� $ Country�6>   53      54      55      5<      5P      
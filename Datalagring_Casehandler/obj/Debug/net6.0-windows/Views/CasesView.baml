   M S B A M L   `   `   `  ����R  NDatalagring_Casehandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:Datalagring_Casehandler.ViewsDatalagring_Casehandler.Views  5      -    'Datalagring_Casehandler.Views.CasesView   5      W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:Datalagring_Casehandler.Views     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��Ärenden��6!   $��18(�60   �� 5   
   $��1��6   $��10 20q�6"   .+�5      �� -   5         ��Name$ lbCases��5      $;��5Välj vilket ärende ni vill se information om nedan:��6%   �� 5      -   5         ��Name$ cbCases��5      �� 5      -   5        $ lbCaseError��5      $6��0Det finns inga ärenden registrerade i databasen��6)   
���  ��$y�	Collapsed=�6t   �� 5      -   5         ��Name$ 	BtnSubmit��5      $��Visa ärende��6(   $	��200��6>   $��30��6J   $��0 20 0 0q�6V   6h   �� 5      $��10 20q�6   $��1q�6$   
���   �._�5      �� $��10q�6   .+�5      �� $��16(�6a   $��	Underline{�6o   $
��Bold"�6�   $��0 0 0 5q�6�   ��6    ��  �� Path$ Header� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5      $
��20 0q�6B   ��6    �� $ Description�6B   �� 5      $��Kundinformation:��6    $��14(�68   $��	Underline{�6F   $
��Bold"�6b   $��0 0 0 5q�6t   �� 5      $
��20 0q�6I   ��6    �� $ CustomerNameSocial�6I   �� 5      $
��20 0q�6F   ��6    �� $ CustomerContact�6F   �� 5       $
��20 0q�6F   ��6    �� $ CustomerAddress�6F   �� 5!      $
��20 0q�6J   ��6    �� $ CustomerZipCodeCity�6J   �� 5"      $
��20 0q�6F   ��6    �� $ CustomerCountry�6F   �� 5$      $��Handläggare:��6    $��14(�64   $��	Underline{�6B   $
��Bold"�6^   $��0 5 0 5q�6p   �� 5%      $
��20 0q�6B   ��6    �� $ CaseHandler�6B   �� 5'      $
��20 0q�6A   ��6    �� $ 
CaseStatus�6A   �� 5)      $��0 20 0 0q�6B   $��10(�6T   ��6    �� $ DateCreated�6T   �� 5*      $��10(�6B   ��6    �� $ DateChanged�6B   5-      5.      5/      56      59      
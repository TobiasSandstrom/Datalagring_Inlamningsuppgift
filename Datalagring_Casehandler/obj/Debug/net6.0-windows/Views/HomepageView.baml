   M S B A M L   `   `   `  ����R  NDatalagring_Casehandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:Datalagring_Casehandler.ViewsDatalagring_Casehandler.Views  5      0    *Datalagring_Casehandler.Views.HomepageView   5      W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:Datalagring_Casehandler.Views     5      .��5
      �   � RowDefinitions  5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ lbHeader��5      $�� ��6"   $��0��6-   $��3��6:   $��18(�6O   �� 5   
   -   5        $ lbNotStarted��5      $��1��6J   $��0��6W   $��Center=�6g   ��6&   ��  �� Path$ 
NotStarted�6g   �� 5   
   -   5        $ 	lbOngoing��5      $��1��6D   $��1��6Q   $��Center=�6a   ��6#   �� $ Ongoing�6a   �� 5   
   -   5        $ 
lbFinished��5      $��1��6F   $��2��6S   $��Center=�6c   ��6$   �� $ Finished�6c   �� 5   
   $��2��6   $��3��6"   $��30q�66   $	��500��6B   $��Center=�6N   .+�5      �� $-��'De 10 senaste ärendena från databasen��6   $��14(�6D   �� 5       -   5         ��Name$ lvLatestCases��5        � DataContext$+ %Datalagring_Casehandler.Entities.Case��6.   ��5!      �� 5"      .R�5#      �  5$      �� 5%   "   $��* �63   �� 5&   "   $��* �63   .+�5)      �� $��0��6(   �� 5*   "   $	��NR:��6,   $��0 0 0 0q�67    �� 5+   "   $��3 0 0 0q�6A   ��6-   �� *Id+6A    �� 5,   "   $��   -   ��6,   $��5 0 0 0q�6;   5-      �� 5/      $��1��6(   $��0 0 5 0q�6T   ��68   �� *
CaseHeader+6T   50      52      .@�54      �� $�� ��6   55      �� 56      
���   �$��1q�6)   $��2��6=   57      5A      5B      
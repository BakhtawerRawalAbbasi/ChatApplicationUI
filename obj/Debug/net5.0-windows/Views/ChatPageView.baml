   M S B A M L   `   `   `  ����S  OChat_Application_Clients, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Chat_Application_Clients.ViewsChat_Application_Clients.Views  5      W0clr-namespace:Chat_Application_Clients.ViewModel"Chat_Application_Clients.ViewModel  5      1    +Chat_Application_Clients.Views.ChatPageView   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v21.1, Version=21.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49ae aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      8local,clr-namespace:Chat_Application_Clients.Views  5      @	viewmodel0clr-namespace:Chat_Application_Clients.ViewModel  5      .��5      ��    WordBlueBrush#��[  6   ._�5   
   �   � ColumnDefinitions  5      �� 5      $��247.5 �6#   �� 5      $��* �6#   .+�5      &   System.Windows.Controls.DataGrid  -   5        $��dgEmployees��5         AlternatingRowBackground
 ��ح� �� AlternationCount$ 2��5         AutoGenerateColumns$ False��5      
�������   
IsReadOnly$
 True��5      $��0��5      ��5      �� *
UserList+ �� Mode$ TwoWay=�   Columns 5!      0  *System.Windows.Controls.DataGridTextColumn  5"      ,  &System.Windows.Controls.DataGridColumn   Header$ 	User Name��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$
 AUTO 5#   %   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 5$   %   �� *
UserName+$ TwoWay=�  5%      $ Email ID��6)   $
 AUTO 5&   %   	 5'   %   �� *	EmailID+$ TwoWay=�  5(      $ Status��6)   $
 AUTO 5)   %   	 5*   %   �� *Status+$ TwoWay=�.  (System.Windows.Interactivity.Interaction
   Triggers
 5-      /  )System.Windows.Interactivity.EventTrigger  5.         	EventName$ MouseDoubleClick��6%   .  (System.Windows.Interactivity.TriggerBase   Actions. 5/      6	  0System.Windows.Interactivity.InvokeCommandAction	   	  Command 60   �� *ItemSelectionChanged+ 	  CommandParameter 50   $   ��  �� ElementName$ dgEmployees�� �� Path$ SelectedItem�51      53      � 55      $��1��6    � RowDefinitions 56      �� 57      $
��Auto �6$   �� 58      $��* �6$   �� 59      $
��Auto �6$   .+�5;      �� $��1��6    �� Orientation$ Vertical=�6/   .+�5<      �� $��10q�5=        FontSizeRegular#��[ 5>        LatoBold#��[ 5?        ForegroundVeryDarkBrush#��[ 5@      ��5<       �� *
UserName+5@      �� 5C        
TextButton#��[ 5D      $��Logout��5E      $��Right=�5F      ��5G      �� *LogoutCommand+5J      �� 5L      $
��Auto=�6   $��1��6B   $��1��6R   .��5M      �� ��6#   �� *HistoryMessage+��5N      �� 5O      .R�5P   "   �� $ Vertical=�6-   5Q      ��5S      �� 5T      .R�5U   "   �� 
���   �$
��Left=�6=   $��1q�6X   
�������$��10q�6    �� Padding$ 10q�6�    �� CornerRadius$ 5��6�   $	��495��6�   ._�5V   &   �� $ Vertical=�61   .+�5W   *   �� ��64   �� *SenderEmail+�� 5X   *   $
��Wrap=�5Z   -     LatoRegular#��[ 5[   -   #��[ 5\   -   #��[  5]   -   ��5Y   -   �� *
Messages+5]   -   �� 5_   *   $��Right=�6V   ��64   �� *MessageSentTime+6V   5`   '   5a   #   5b      5d      5e      �� 5g      $ 
Horizontal=�6   $��2��5h      $��1��5i      .+�5j      �� -   5         ��Name$ txt_Mess��5j      
 � Tag$ Write a message...��5l        FontSizeSmall#��[ 5m      $��Center=�5n      $��0q�5o      $��
0 10 10 10q�5p       �� AcceptsReturn$
 True��5q       �� 
AcceptsTab$
 True��5r      " �� VerticalScrollBarVisibility$
 Auto=�5s      $��10q�5t      $	��290��5u      ��5k      �� *MessageSend.Message+$ TwoWay=�.��5v      5x      �� 5y      $
��Send��5z      $��5q�5|      $��43��5}      ��5{      �� *SendCommand+5}      5      5�      5�      5�      5�      
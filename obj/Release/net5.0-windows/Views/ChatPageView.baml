   M S B A M L   `   `   `  ���� S  OChat_Application_Clients, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Chat_Application_Clients.ViewsChat_Application_Clients.Views  W0clr-namespace:Chat_Application_Clients.ViewModel"Chat_Application_Clients.ViewModel  1    +Chat_Application_Clients.Views.ChatPageView   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v21.1, Version=21.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49ae aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  8local,clr-namespace:Chat_Application_Clients.Views  @	viewmodel0clr-namespace:Chat_Application_Clients.ViewModel  .����    WordBlueBrush#��[  ._��   � ColumnDefinitions  �� $��247.5 ��� $��* �.+�&   System.Windows.Controls.DataGrid  -   $��dgEmployees��   AlternatingRowBackground
 ��ح� �� AlternationCount$ 2��   AutoGenerateColumns$ False��
�������   
IsReadOnly$
 True��$��0������ *
UserList+ �� Mode$ TwoWay=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 	User Name��   Width5  /System.Windows.Controls.DataGridLengthConverter$
 AUTO 1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 �� *
UserName+$ TwoWay=�  $ Email ID��$
 AUTO 	 �� *	EmailID+$ TwoWay=�  $ Status��$
 AUTO 	 �� *Status+$ TwoWay=�.  (System.Windows.Interactivity.Interaction
   Triggers
 /  )System.Windows.Interactivity.EventTrigger     	EventName$ MouseDoubleClick��.  (System.Windows.Interactivity.TriggerBase   Actions. 6	  0System.Windows.Interactivity.InvokeCommandAction	   	  Command �� *ItemSelectionChanged+ 	  CommandParameter ��  �� ElementName$ dgEmployees�� �� Path$ SelectedItem�� $��1�� � RowDefinitions �� $
��Auto ��� $��* ��� $
��Auto �.+��� $��1�� �� Orientation$ Vertical=�.+��� $��10q�  FontSizeRegular#��[   LatoBold#��[   ForegroundVeryDarkBrush#��[ ���� *
UserName+��   
TextButton#��[ $��Logout��$��Right=����� *LogoutCommand+�� $
��Auto=�$��1��$��1��.���� ���� *HistoryMessage+���� .R��� $ Vertical=����� .R��� 
���   �$
��Left=�$��1q�
�������$��10q� �� Padding$ 10q� �� CornerRadius$ 5��$	��495��._��� $ Vertical=�.+��� ���� *SenderEmail+�� $
��Wrap=�  LatoRegular#��[ #��[ #��[  ���� *
Messages+�� $��Right=����� *MessageSentTime+�� $ 
Horizontal=�$��2��$��1��.+��� -    ��Name$ txt_Mess��
 � Tag$ Write a message...��  FontSizeSmall#��[ $��Center=�$��0q�$��
0 10 10 10q� �� AcceptsReturn$
 True�� �� 
AcceptsTab$
 True��" �� VerticalScrollBarVisibility$
 Auto=�$��10q�$	��290������ *MessageSend.Message+$ TwoWay=�.���� $
��Send��$��5q�$��43������ *SendCommand+
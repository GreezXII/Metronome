   M S B A M L   `   `   `  ����D  @Metronome, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Metronome	Metronome  5          Metronome.SettingsFrame   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:Metronome     5        N� Title$  SettingsFrame��5      $	��450��64   .��5
      �  � ColumnDefinitions 5   
   �� 5      $��* �6   6+   �� 5      $��* �6   6+   �� 5      $��* �6   6+    � RowDefinitions 5   
   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $��* �6   6)   .+�5   
   �� $!��Звук метронома��6   $��0��6)   $��0��69   $��3��6F   $��20(�6Z   $
��Bold"�6h   6|   �� 5   
   $��0��6   $��1��6    $��5,5,5,5q�6-   $$��Акцентированный��6>   $��Right=�6X   6v   �� 5   
   -   5         ��Name$ txtAccentedBeatFilePath��5      $��1��63   $��1��6C   $��5,5,5,5q�6P   $��Center=�6a   6�   �� 5   
   -   5         ��Name$ btnSelectAccentedBeatFile��5      $��2��64   $��1��6D   $��5,5,5,5q�6Q   $��Выбрать файл��6b   6y   �� 5   
   $��0��6   $��2��6    $��5,5,5,5q�6-   $��Обычный��6>   $��Right=�6P   6n   �� 5   
   -   5        $ txtNormalBeatFilePath��5      $��1��61   $��2��6A   $��5,5,5,5q�6N   $��Center=�6_   �� 5   
   -   5        $ btnSelectNormalBeatFile��5      $��2��62   $��2��6B   $��5,5,5,5q�6O   $��Выбрать файл��6`   6�   �� 5!   
   -   5        $ btnApplySettings��5!      $��2��6+   $��3��6;   $��Применить��6H   $��5,5,5,5q�6\   $
��Bold"�6m   $��Bottom=�6   $��Stretch=�6�   6�   5"      5$      
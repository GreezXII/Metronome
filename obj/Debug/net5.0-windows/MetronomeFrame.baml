   M S B A M L   `   `   `  ����D  @Metronome, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Metronome	Metronome  5          Metronome.MetronomeFrame   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:Metronome     5        N� Title$  MetronomeFrame��5      .��5
      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� 
���   �$��2q�6%   $��0��69   $��0��6I   $��3��6V   $��5,5,5,5q�6j   ._�5      �� -   5         ��Name$ bpmLabel��5      $��0��6&   $��120/4��66   $
��Left=�6F   $��5,5,5,5q�6a   $	��Top=�6r   $��48(�6�   $��Bahnschrift SemiBold)�6�   $
��Bold"�6�   5      �� 5   
   -   5         ��Name$ 
bpmTextBox��5      $
��Left=�6&   $��Center=�6A   $��5,5,5,5q�6\    �� TextWrapping$
 Wrap=�6m   $	��125��6�   $��0��6�   $��1��6�   $	��120��6�    �� 	MaxLength$ 4��6�   $��21.96��6  $��14(�6  �� 5   
   -   5         ��Name$ measureComboBox��5      $��1��6,   $��1��6<   $��5,5,5,5q�6I   $��40��6Z   .@�5      ��  �� 
IsSelected$
 true��6   .��6-   460   �� 5      .��6   36   5      �� 5   
   -   5        	 ��Name$	 applyButton��5      $��2��6&   $��1��66   $��Применить��6C   $��5,5,5,5q�6W   $��75��6h   6�   �� 5    
   -   5        $	 
playButton��5       $��0��6%   $��2��65   $��
Старт��6B   $
��Left=�6R   $��5,5,5,5q�6m   $��125px��6~   $	��Top=�6�   6�   �� 5!   
   -   5        $	 
stopButton��5!      $��1��6%   $��2��65   $��2��6I   $��Стоп��6V   $
��Left=�6e   $��5,5,5,5q�6�   $��125px��6�   $	��Top=�6�   6�   �� 5"   
   $��0��6   $��3��6    $$��Акцентированный��6-   6I   �� 5#   
   -   5        
 ��Name$
 accentedBeatLoudSlider��5#      $��1��61   $��2��6C   $��3��6W   $��Center=�6d    � Value$	 0.8Q�6    � Minimum$ 0Q�6�    � Maximum$ 1Q�6�    � LargeChange$	 0.1Q�6�   6�   �� 5$   
   $��0��6   $��4��6    $��Обычный��6-   6A   �� 5%   
   -   5        $
 normalBeatLoudSlider��5%      $��1��6/   $��2��6A   $��4��6U   $��Center=�6b   $	 0.8Q�6}   $ 0Q�6�   $ 1Q�6�    �� TickFrequency$	 0.1Q�6�   $	 0.1Q�6�   6�   5&      5'      
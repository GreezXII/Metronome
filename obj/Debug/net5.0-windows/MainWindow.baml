   M S B A M L   `   `   `  ����D  @Metronome, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Metronome	Metronome  5   	       Metronome.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Metronome     5   	     � 
ResizeMode$  CanMinimize=�5   	    � WindowStartupLocation$ CenterScreen=�5	   	    � Title$ 
MainWindow��5
   	   $	��300��6   $	��550��6)   .��5      �  � ColumnDefinitions 5   
   �� 5      $��50 �6   �� 5      $
��Auto �6    � RowDefinitions 5   
   �� 5      .+�5   
   �� $��0��6   .+�5      �� -   5         ��Name$ MetronomeViewButton��5      $��M��62   $��50��6>   6n   �� 5      -   5        $ SettingsViewButton��5      $��S��61   $��50��6=   6l   5       � 5   
   -   5          �Name$ Frame��5      $��1��6   $��3��6/   $
��Auto��6<   $
��Auto��6J   $��5,0,5,5q�6W     � NavigationUIVisibility$ Hidden=�6h   5      5      
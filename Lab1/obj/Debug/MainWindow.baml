   M S B A M L   `   `   `  ����?  ;Lab1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Lab1Lab1  5   	       Lab1.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:Lab1     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � 	Resources 5	         Lab1.BoolReverseConverter   boolReverse��%   &	          5
   
   6%   5      .��5      �� .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��	10,10,0,0q�5      .+�5      �� $��Browse .wav file��6   $��30(�5      �� 5      $��Browse��6   $��30(�5      $��20,0,0,0q�5      ��5      �� *BrowseFromWavCommand+5      5      �� 5   
   $��	10,30,0,0q�6   $ 
Horizontal=�5      .+�5      �� $
��Play��6   $��30(�5      $��70��5      $
��Left=�5      $
��play��5      {�5      �� *	IsPlaying+ �� 	Converter# [  ��5      �� *SoundProcessCommand+5      �� 5       $
��Stop��6   $��30(�5!      $��70��5"      $
��Left=�5#      $��20,0,0,0q�5$      $
��stop��5'      {�5%      �� *	IsPlaying+��5&      �� *SoundProcessCommand+5'      5(      �� 5)   
   $��	10,30,0,0q�6   .+�5*      �� $��Run sine volume��6   $��30(�5+      $	��250��5,      $
��Left=�5-      ��5.      �� *RunSineVolumeCommand+�� 51       � Minimum$ 0Q�6    � Maximum$	 100Q�52       �� Orientation$ Vertical=�53      $	��200��54      $��40,0,0,0q�55      {�.   � Value 56      �� *SliderVolume+57      58      59      5:      
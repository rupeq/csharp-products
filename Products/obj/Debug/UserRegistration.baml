   M S B A M L   `   `   `  ����C  ?Products, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:ProductsProducts  5   	       Products.UserRegistration   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Products     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	     � Title$  Регистрация��5   	   $	��450��6   $��587.6��6*   ��5	   R   Z� .��5
      � 
�������$��0,0,-0.2,-52q�6    � ColumnDefinitions 5   
   �� 5      $
��136* �6   �� 5      $
��155* �6   .+�5   
   � $��	0,0,0.8,9q�6   $��2��6"    5      �� 5      $
��657* �6#   �� 5      $
��137* �6#   .+�5      ��  �� CornerRadius$ 20��6   $	��400��6'   $	��550��66   $��10,36,20,26.6q�6F   $	��399��6]   
�������$��Center=�6}    �� Padding$ 18q�6�   $��2��6�    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 30Q�6'      Color$ 	LightGray��67      ShadowDepth$ 0Q�6I   ._�5      �� .+�5      �� $��Привет!��6    $��30(�6/   $
��Bold"�6=   $��0 0 0 20q�6O   � 5      $��0 0 0 20q�6   .+�5      �� $
��Left=�6!   $��Регистирация��5   !   �� 5      -   5        $��Right=�5   !   $��Авторизация��5   !      MaterialDesignFlatButton#��[  5    !   5!   !   5"      �� 5#      -   5         ��Name$ textBoxLogin��5%      )  #MaterialDesignThemes.Wpf.HintAssist	   Hint$	 Введите логин��5#       % !MaterialDesignFloatingHintTextBox#��[ 5$      5%      G� 5&      -   5        
 G�Name$
 textBoxPassword1��5(      $!	 Введите пароль��5&   "    ) %MaterialDesignFloatingHintPasswordBox#��[ 5'      5(      G� 5)      -   5        $
 textBoxPassword2��5+      $%	 Повторите пароль��5)   "   #��[ 5*      5+      �� 5,      -   5        $ textBoxEmail��5.      $	 
Почта��5,      #��[ 5-      5.      �� 5/      -   5        $*��$Зарегистрироваться��5/      $
��0 20q�6:   6H   50      51      52      53      54      
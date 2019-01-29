using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using Connect4_App.Core;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Connect4_App
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        int Player = 1;
        bool GameOver = false;


        public MainPage()
        {
            this.InitializeComponent();
            Board.PopulateCells();
        }

        private void DropChip(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (GameOver == false)
            {
                if (Player == 1)
                {

                    if(Core.Board.DropChip(this, "yellow", Int32.Parse(button.Tag.ToString())))
                        Player *= -1;
                    if (Core.Board.CheckWin(this) == true)
                    {
                        GameOver = true;
                        (FindName("GameEnd") as Button).Content = "Yellow Wins";
                        (FindName("GameEnd") as Button).Background = new SolidColorBrush(Windows.UI.Colors.Yellow);
                    }
                }
                else
                {
                    if(Core.Board.DropChip(this, "red", Int32.Parse(button.Tag.ToString())))
                    Player *= -1;

                    if (Core.Board.CheckWin(this) == true)
                    {
                        GameOver = true;
                        (FindName("GameEnd") as Button).Content = "Red Wins";
                        (FindName("GameEnd") as Button).Background = new SolidColorBrush(Windows.UI.Colors.Red);
                    }
                }
            }
        }

        public void PlayAgain(object sender, RoutedEventArgs e)
        {
            if (GameOver == true)
            {
                Core.Board.Reset(this);
                GameOver = false;
                (sender as Button).Content = "";
                (sender as Button).Background = new SolidColorBrush(Windows.UI.Colors.Transparent);
            }
        }
    }
}
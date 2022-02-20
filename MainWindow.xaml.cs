using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tic_Tac_Toe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UInt16 NumberOfMove;
        private Button[] buttons;

        public MainWindow()
        {
            InitializeComponent();
            buttons = new Button[] { C0R0, C0R1, C0R2, C1R0, C1R1, C1R2, C2R0, C2R1, C2R2 };
            FreshGame();
        }

        private void FreshGame() {
            NumberOfMove = 0;

            foreach (Button button in buttons) {
                button.Content = string.Empty;
                button.Background = Brushes.White;
            }
            
        }

        private bool IsEqual(Button first,Button second,Button third) {
            return first.Content.ToString() == string.Empty ? false : Equals(first.Content, second.Content) && Equals(second.Content,third.Content);

        }
        private void MarkWon(Button first, Button second, Button third) {
            first.Background = Brushes.Green;
            second.Background = Brushes.Green;
            third.Background = Brushes.Green;
        }
        private void GameWon()
        {
            // horizontal
            if(IsEqual(buttons[0],buttons[1],buttons[2])) { MarkWon(buttons[0], buttons[1], buttons[2]); NumberOfMove = 9; return; }
            if (IsEqual(buttons[3], buttons[4], buttons[5])) { MarkWon(buttons[3], buttons[4], buttons[5]); NumberOfMove = 9; return; }
            if (IsEqual(buttons[6], buttons[7], buttons[8])) { MarkWon(buttons[6], buttons[7], buttons[8]); NumberOfMove = 9; return; }
                                                                                                                             
            //vertical                                                                                                        
            if (IsEqual(buttons[0], buttons[3], buttons[6])) { MarkWon(buttons[0], buttons[3], buttons[6]); NumberOfMove = 9; return; }
            if (IsEqual(buttons[1], buttons[4], buttons[7])) { MarkWon(buttons[1], buttons[4], buttons[7]); NumberOfMove = 9; return; }
            if (IsEqual(buttons[2], buttons[5], buttons[8])) { MarkWon(buttons[2], buttons[5], buttons[8]); NumberOfMove = 9; return; }
                                                                                                                             
            //diagonal                                                                                                       
            if (IsEqual(buttons[0], buttons[4], buttons[8])) { MarkWon(buttons[0], buttons[4], buttons[8]); NumberOfMove = 9; return; }
            if (IsEqual(buttons[2], buttons[4], buttons[6])) { MarkWon(buttons[2], buttons[4], buttons[6]); NumberOfMove = 9; return; }
        }

        private void Button_Clicked(object sender, RoutedEventArgs e) {

            if (NumberOfMove < 9) {
                Button button = sender as Button;
                if (Equals(button.Content.ToString(), string.Empty))
                {
                    button.Content = NumberOfMove % 2 == 0 ? "X" : "O";
                    NumberOfMove++;
                    GameWon();
                }
            }
            else{ FreshGame();}
        }
    }
}

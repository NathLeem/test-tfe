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

namespace Jeu_d_échecs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Button[,] cases = new Button[8, 8];
        public MainWindow()
        {
            InitializeComponent();
            Interface();
            SetUpGame();
        }
        public void Interface()
        {
            // Création des colonnes et des lignes
            for (int i = 0; i < 8; i++)
            {
                ColumnDefinition colDef = new ColumnDefinition();
                grdPlate.ColumnDefinitions.Add(colDef);
                RowDefinition rowDef = new RowDefinition();
                grdPlate.RowDefinitions.Add(rowDef);
            }

            // Création des button avec des "?" et coloration des cases
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0;  j < 8;  j++)
                {
                    cases[i, j] = new Button();
                    
                    if(i < 2 || i > 5)
                    {
                        cases[i, j].Content = "?";
                    }
                                    
                    cases[i, j].FontSize = 50;
                    
                    if ((i + 1) % 2 == 0)
                    {
                        if ((j + 1) % 2 != 0)
                        {
                            cases[i, j].Background = Brushes.Green;
                        }
                        
                    }
                    else
                    {
                        if ((j + 1) % 2 == 0)
                        {
                            cases[i, j].Background = Brushes.Green;
                        }
                    }

                    Grid.SetColumn(cases[i, j], j);
                    Grid.SetRow(cases[i, j], i);
                    grdPlate.Children.Add(cases[i, j]);
                }
            }


        }
        public void SetUpGame()
        {
            List<string> pawns = new List<string>()
            {
                "♜","♞","♝","♛","♚","♝","♞","♜",
                "♟","♟️","♟️","♟️","♟️","♟️","♟️","♟️",
                "♙","♙","♙","♙","♙","♙","♙","♙",
                "♖","♘","♗","♕","♔","♗","♘","♖"
            };

            foreach (Button button in grdPlate.Children.OfType<Button>())
            {
                if (button.Content == "?")
                {
                    button.Content = pawns[0];
                    pawns.RemoveAt(0);
                }
            }
        }       
    }
}
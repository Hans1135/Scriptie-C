using System.Windows;
using System.Windows.Controls;

class UnitGrid
{
    public static ClassFormGrid FormGrid = new ClassFormGrid();

    public class ClassFormGrid : Grid
    {
        public UIElement Init()
        {
            int I;

            for (I = 0; I <= 5; I += 1) // maakt 6 kolommen
            {
                ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (I = 0; I <=4; I += 1) // maak kolommen 1 t.m. 5 450 punten breed
            {
                ColumnDefinitions[I].Width = new GridLength(450);
            }

            for (I = 0; I <= 2; I += 1) // maakt 3 rijen
            {
                RowDefinitions.Add(new RowDefinition());
            }
            RowDefinitions[0].Height = GridLength.Auto; // rij 0 voor menu
            RowDefinitions[1].Height = new GridLength(500); // rij 0 voor menu

            Children.Add(UnitMenu.GridMenu.Init());
            Children.Add(UnitTabs.GridTabs.Init());
            Children.Add(UnitText.GridText.Init());
            Children.Add(UnitMedia.GridMedia.Init());

            Modes(1);

            return this;
        }

        public void Done()
        {
            UnitText.GridText.Done();
        }

        public void Modes(int I)
        {
            if (I == 1)
            {
                Move(UnitMenu.GridMenu, 0, 0, 6, 1);
                UnitTabs.GridTabs.Visibility = Visibility.Visible;
                Move(UnitTabs.GridTabs, 4, 1, 2, 2);
                UnitText.GridText.Visibility = Visibility.Visible;
                Move(UnitText.GridText, 2, 1, 2, 2);
                Move(UnitMedia.GridMedia, 0, 1, 2, 1);
            }
            else if (I == 2)
            {
                Move(UnitMedia.GridMedia, 0, 1, 2, 2);
            }
            else if (I == 3)
            {
                Move(UnitText.GridText, 4, 1, 1, 2);
                Move(UnitMedia.GridMedia, 0, 1, 4, 2);
            }
            else if (I == 4)
            {
                UnitText.GridText.Visibility = Visibility.Hidden;
                Move(UnitMedia.GridMedia, 0, 1, 6, 2);
            }
            Mode = I;
        }

        public void Move(UIElement E, int X, int Y, int W, int H)
        {
            SetColumn(E, X);
            SetRow(E, Y);
            SetColumnSpan(E, W);
            SetRowSpan(E, H);
        }

        public void Change()
        {
            if (Mode < 4) Mode += 1; else Mode = 1;
            Modes(Mode);
        }

        public void Pars()
        {
            // W(0) = "mode"
            // V(1) = mode

            Modes((int)UnitPars.V[1]);
        }

        int Mode; // onthoudt de veldindeling
    }
}
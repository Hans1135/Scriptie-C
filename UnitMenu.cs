using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

class UnitMenu
{
    public static ClassGridMenu GridMenu = new ClassGridMenu();

    public class ClassGridMenu : Menu
    {
        public UIElement Init()
        {
            Items.Add(MenuFile.Init());
            Items.Add(MenuEdit.Init());
            Items.Add(MenuView.Init());
            Items.Add(MenuStart.Init());

            return this;
        }

        public void Shortcut(Key K, ModifierKeys M, ExecutedRoutedEventHandler R)
        {
            // maakt een menu shortcut

            RoutedCommand C = new RoutedCommand();

            C.InputGestures.Add(new KeyGesture(K, M));
            UnitForm.MainForm.CommandBindings.Add(new CommandBinding(C, R));
        }
    }

    public static ClassMenuFile MenuFile = new ClassMenuFile();

    public class ClassMenuFile : MenuItem
    {
        //

        public MenuItem Init()
        {
            // start het file menu

            Items.Add(FileSave.Init());
            Items.Add(FileFavorits.Init());
            Items.Add(FileLast.Init());
            Items.Add(FileExplorer.Init());

            Header = "_File";

            return this;
        }
    }

    public static ClassFile_Save FileSave = new ClassFile_Save();

    public class ClassFile_Save : MenuItem
    {
        //TODO opsplitsen

        public MenuItem Init()
        {
            //

            Header = "_Save";
            InputGestureText = "Ctrl+S";
            GridMenu.Shortcut(Key.S, ModifierKeys.Control, Me_Click);
            Click += new RoutedEventHandler(Me_Click);

            return this;
        }

        public void Me_Click(object sender, RoutedEventArgs e)
        {
            // bewaart een text bestand en bewaart het adres van een tekst bestand

            //UnitText.GridText.Save();
            //File.WriteAllText(UnitFile.FileRoot.Items[0].ToString() + @"f\favoriet\laatst.txt", UnitFile.FileRoot.SelectedIndex + "\r\n" + UnitText.TextFile);
        }
    }

    public static ClassFileFavorits FileFavorits = new ClassFileFavorits();

    public class ClassFileFavorits : MenuItem
    {
        //

        public MenuItem Init()
        {
            //

            Header = "_Favorits";
            InputGestureText = "Ctrl+R";
            GridMenu.Shortcut(Key.R, ModifierKeys.Control, Me_Click);
            Click += new RoutedEventHandler(Me_Click);

            return this;
        }
        public void Me_Click(object sender, RoutedEventArgs e)
        {
            // opent het text bestand met favorieten

            //UnitFile.FileRoot.SelectedIndex = 0;
            //UnitFile.TabsFileLoad(UnitFile.FileRoot.Items[0].ToString() + @"f\favoriet\favorieten.txt");
        }
    }

    public static ClassFileLast FileLast = new ClassFileLast();

    public class ClassFileLast : MenuItem
    {
        //

        public MenuItem Init()
        {
            //

            Header = "_Last";
            InputGestureText = "Ctrl+L";
            GridMenu.Shortcut(Key.L, ModifierKeys.Control, Me_Click);
            Click += new RoutedEventHandler(Me_Click);

            return this;
        }
      
        public static void Me_Click(object sender, RoutedEventArgs e)
        {
            // opent een tekst bestand met het bewaarde adres

            //string[] S = File.ReadAllLines(UnitFile.FileRoot.Items[0].ToString() + @"f\favoriet\laatst.txt");
            //UnitFile.FileRoot.SelectedIndex = Convert.ToInt16(S[0]);
            //UnitText.GridText.Load(S[1]);
        }
    }

    public static ClassFileExplorer FileExplorer = new ClassFileExplorer();

    public class ClassFileExplorer : MenuItem
    {
        //

        public MenuItem Init()
        {
            //

            Header = "_Explorer";
            InputGestureText = "Ctrl+E";
            GridMenu.Shortcut(Key.E, ModifierKeys.Control, Me_Click);
            Click += new RoutedEventHandler(Me_Click);

            return this;
        }
        public void Me_Click(object sender, RoutedEventArgs e)
        {
            // opent een text bestand in de explorer

            //string F = @"C:\Windows\explorer.exe /select, " + UnitText.TextFile;
            //Interaction.Shell(F, AppWinStyle.MaximizedFocus);
        }
    }

    public static ClassMenuEdit MenuEdit = new ClassMenuEdit();

    public class ClassMenuEdit : MenuItem
    {
        // MenuEdit

        public MenuItem Init()
        {
            // start het edit menu

            Header = "_Edit";

            return this;
        }

    }
    public static ClassMenuView MenuView = new ClassMenuView();

    public class ClassMenuView : MenuItem
    {
        // MenuView

        public MenuItem Init()
        {
            // start het view menu

            Items.Add(ViewMode.Init());

            Header = "_View";

            return this;
        }
    }

    public static ClassViewMode ViewMode = new ClassViewMode();

    public class ClassViewMode : MenuItem
    {
        //

        public MenuItem Init()
        {
            //

            Header = "_Mode";
            InputGestureText = "Ctrl+M";
            GridMenu.Shortcut(Key.M, ModifierKeys.Control, Me_Click);

            return this;
        }
        public void Me_Click(object sender, RoutedEventArgs e)
        {
            // veranderd de indeling van het formulier veld

            UnitGrid.FormGrid.Change();
        }
    }

    public static ClassMenuStart MenuStart = new ClassMenuStart();

    public class ClassMenuStart : MenuItem
    {
        // Menu_Start

        public MenuItem Init()
        {
            // start het start menu

            Items.Add(StartPars.Init());
            Header = "_Start";

            return this;
        }
    }

    public static ClassStartPars StartPars = new ClassStartPars();

    public class ClassStartPars : MenuItem
    {
        //

        public MenuItem Init()
        {
            //

            Header = "_Pars";
            InputGestureText = "F5";
            Click += new RoutedEventHandler(Me_Click);
            GridMenu.Shortcut(Key.F5, ModifierKeys.None, Me_Click);

            return this;
        }

        public static void Me_Click(object sender, RoutedEventArgs e)
        {
            // start parsen

            //UnitText.GridText.Save();
            //UnitPars.ParsFileInit();
        }
    }
}
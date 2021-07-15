using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

public class UnitFile
{
    //

    public static ClassTabsFile TabsFile = new ClassTabsFile();

    public class ClassTabsFile : TabItem
    {
        //

        public UIElement Init()
        {
            // start bestanden veld

            Header = "Files";
            Content = FileStack.Init();

            return this;
        }

        public void Load(string S)
        {
            //


        }
    }

    public static ClassFileStack FileStack = new ClassFileStack();

    public class ClassFileStack : StackPanel
    {
        //

        public UIElement Init()
        {
            //

            Children.Add(FileText.Init());
            Children.Add(RootLabel.Init());
            Children.Add(FileRoot.Init());
            Children.Add(PathLabel.Init());
            Children.Add(FilePath.Init());
            Children.Add(FileLabel.Init());
            Children.Add(FileFile.Init());
            Children.Add(UsedLabel.Init());
            Children.Add(FileUsed.Init());

            return this;
        }
    }

    public static ClassFileText FileText = new ClassFileText();

    public class ClassFileText : TextBox
    {
        //

        public UIElement Init()
        {
            //

            Text = "Kies een bron";

            return this;
        }
    }
            
    public static ClassRootLabel RootLabel = new ClassRootLabel();

    public class ClassRootLabel : Label
    {
        //

        public UIElement Init()
        {
            //

            Content = "Roots";

            return this;
        }
    }

    public static ClassFileRoot FileRoot = new ClassFileRoot();

    public class ClassFileRoot : ListBox
    {
        //

        public UIElement Init()
        {
            // start de bron lijst

            MouseLeftButtonUp += new MouseButtonEventHandler(Me_MouseLeftButtonUp);
            MaxHeight = 200;
            Update();
            
            return this;
        }

        public void Update()
        {
            //

            int I;
            int N;
            string[] S;

            S = File.ReadAllLines(@"D:\OneDrive\Index\b\bron\data.txt");
            N = S.GetUpperBound(0);
            for (I = 0; I <= N; I++)
            {
                Items.Add(S[I]);
            }
        }

        public void Me_MouseLeftButtonUp(object sender, System.EventArgs e)
        {
            // als een bron gekozen is

            string P = (string)SelectedItem;

            UnitText.GridText.Save();
            UnitText.GridText.Clear();
            UnitText.TextFile = "";
            UnitText.GridText.Show();

            UnitGrid.FormGrid.Modes(1);

            FileUsed.Items.Clear();
            FilePath.Update(P);
            FileFile.Update(P);

            FileText.Text = "kies een pad of een bestand";
        }
    }

    public static ClassPathLabel PathLabel = new ClassPathLabel();

    public class ClassPathLabel : Label
    {
        //

        public UIElement Init()
        {
            //

            Content = "Paths";

            return this;
        }
    }

    public static ClassFilePath FilePath = new ClassFilePath();

    public class ClassFilePath : ListBox
    {
        //

        public UIElement Init()
        {
            // start de paden lijst

            MaxHeight = 200;
            MouseLeftButtonUp += new MouseButtonEventHandler(Me_MouseLeftButtonUp);

            return this;
        }

        public void Update(string S)
        {
            // vult de padlijst opnieuw

            int L;
            string T;

            T = (string)FileRoot.SelectedItem;
            L = T.Length  + 1; // lengte van het bronpad
            if (FilePath.SelectedItem == null) // als er geen selectie in de padlijst is gemaakt
            {
                T = Directory.GetParent(Directory.GetParent(T + @"\" + GetFilePath(UnitText.TextFile)).FullName).FullName;
                if (T.Length < L) T = ""; else T = T.Substring(L);
            }
            else
            {
                T = (string)SelectedItem;
                T = GetPrevPath(T);
            }
            Items.Clear();
            Items.Add(T); // eerste pad om terug te gaan naar ouderpad
            foreach (string D in Directory.GetDirectories(S))
            {
                T = D.Substring(L);
                Items.Add(T);
            }
        }

        public void Me_MouseLeftButtonUp(object sender, System.EventArgs e)
        {
            // als een pad wordt gekozen

            string P = FileRoot.SelectedItem + @"\" + SelectedItem;
            FilePath.Update(P);
            FileFile.Update(P);
        }
    }

    public static ClassFileLabel FileLabel = new ClassFileLabel();

    public class ClassFileLabel : Label
    {
        //

        public UIElement Init()
        {
            //

            Content = "Files";

            return this;
        }
    }

    public static ClassFileFile FileFile = new ClassFileFile();

    public class ClassFileFile : ListBox
    {
        //

        public UIElement Init()
        {
            // start de paden lijst

            MaxHeight = 200;
            MouseLeftButtonUp += new MouseButtonEventHandler(Me_MouseLeftButtonUp);

            return this;
        }

        public void Update(string S)
        {
            //


        }

        public void Me_MouseLeftButtonUp(object sender, System.EventArgs e)
        {
            // als een bestand gekozen is

            //TabsFileLoad(FileRoot.SelectedItem.ToString() + FileFile.SelectedItem.ToString());
        }
    }

    public static ClassUsedLabel UsedLabel = new ClassUsedLabel();

    public class ClassUsedLabel : Label
    {
        //

        public UIElement Init()
        {
            //

            Content = "Used";

            return this;
        }
    }

    public static ClassFileUsed FileUsed = new ClassFileUsed();

    public class ClassFileUsed : ListBox
    {
        //

        public UIElement Init()
        {
            // start de gebruikte bestanden lijst

            MaxHeight = 200;

            return this;
        }

        public void FileUsedUpdate(string S)
        {
            //

            int L = FileRoot.SelectedItem.ToString().Length;
            int N = Items.Count - 1;
            int J = SelectedIndex + 1;
            string T = S.Substring(L).ToLower();
            int I;
            for (I = 0; I <= N; I++)
            {
                if (Items[I].ToString().ToLower() == T)
                {
                    SelectedIndex = I;
                    goto verder;
                }
            }
            Items.Insert(J, T);
            SelectedIndex = J;
        verder:;
        }

    }

    public static void FileNotFound(string S)
    {
        //

        MessageBox.Show(" bestand " + "\r\n" + S + "\n\r" + " niet gevonden");
    }

    public static string GetFileAddress(string S)
    {
        //

        string T = "";

        //T = GetFilePath(UnitPars.FileAddress[FI]) + S;
        if (!File.Exists(T))
        {
            T = FileRoot.SelectedItem + S.Substring(0, 1) + @"\" + S;
            if (!File.Exists(T))
            {
                FileNotFound(S);
                //ParsSkip = true;
            }
        }

        return T;
    }

    public static string GetFileName(string S)
    {
        // bepaalt de naam van het bestand, zonder mappen of type

        int I;

        I = S.LastIndexOf(@"\"); // verwijdert de mappen
        S = S.Substring(I);
        I = S.IndexOf("."); // verwijdert het type
        if (I > -1) S = S.Substring(0, I);

        return S;
    }

    public static string GetFilePath(string S)
    {
        // bepaalt het pad

        S = S.Substring(0, S.LastIndexOf(@"\") + 1);

        return S;
    }

    public static string GetPrevPath(string S)
    {
        // bepaalt het vorige pad

        if (S != "")
        {
            S = S.Substring(0, S.Length - 1);
            int L = S.LastIndexOf(@"\");
            if (L < 0) L = 0;
            S = S.Substring(0, L);
        }

        return S;
    }

    public static string GetFileType(string S)
    {
        // bepaalt het type van een bestand

        int I;

        I = S.LastIndexOf("."); // zoekt laatste punt in bestandadres

        if (I > 0)
        {
            S = S.Substring(I);
        }
        else
        {
            S = "";
        }

        return S;
    }
}
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

public class UnitText
{
    //

    public static ClassGridText GridText = new ClassGridText();
    
    public class ClassGridText : TextBox
    {
        //

        public UIElement Init()
        {
            // start het tekst veld

            FontFamily = new FontFamily("Consolas");
            FontSize = 14;
            AcceptsReturn = true;
            AcceptsTab = true;
            TextWrapping = TextWrapping.Wrap;
            VerticalScrollBarVisibility = ScrollBarVisibility.Auto;

            TextChanged += new TextChangedEventHandler(GridText_TextChanged);
            MouseRightButtonUp += new MouseButtonEventHandler(GridText_MouseRightButtonUp);

            return this;
        }

        public void Done()
        {
            // stopt het tekst veld

            Save();
        }

        public void Load(string S)
        {
            // laadt een tekst bestand

            if (File.Exists(S)) // als het bestand bestaat
            {
                Save();
                Text = File.ReadAllText(S);
                TextFile = S; // onthoud bestand naam
                TextSave = false;
                Show();
                //TabsFileUpdate(GetFilePath(S));
                //FileUsedUpdate(S);
            }
            else // als het bestand niet bestaat
            {
                //FileNotFound(S);
            }
        }

        public void Save()
        {
            // slaat een tekst bestand op als dat veranderd is

            if (TextSave)
            {
                File.WriteAllText(TextFile, Text);
                TextSave = false;
                Show();
            }
        }

        public void Show()
        {
            // toont de naam van het tekst bestand eventueel met een ster als het bestand veranderd is

            if (TextSave)
            {
                UnitForm.MainForm.Title = TextFile + "*";
            }
            else
            {
                UnitForm.MainForm.Title = TextFile;
            }
        }

        public void GridText_TextChanged(object sender, System.EventArgs e)
        {
            // als tekst veranderd is

            TextSave = true;
            Show();
        }

        public void GridText_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            // zoekt een geselecteerd woord

            string T = GridText.Text;
            int N = T.Length - 1;
            int I = GridText.SelectionStart;
            if (I < N)
            {
                int J = I;
                while ((J > 0) && ((int)T[J] > 32))
                {
                    J -= 1;
                }
                int K = I;
                while ((K < N) && ((int)T[K] > 32))
                {
                    K += 1;
                }
                string F = "";
                for (I = J; I <= K; I++)
                {
                    if ((int)T[I] != 44) F += T[I];
                }
                F = F.Trim();
                //FileText.Text = F;
                string P = "";
                //P = FileRoot.SelectedItem.ToString() + F.Substring(0, 1) + @"\" + F + @"\boek.txt";
                if (!File.Exists(P))
                {
                    //P = FileRoot.SelectedItem.ToString() + F.Substring(0, 1) + @"\" + F + @"\info.txt";

                    if (!File.Exists(P))
                    {
                        //P = FileRoot.SelectedItem.ToString() + F.Substring(0, 1) + @"\" + F + ".txt";
                    }
                }
                //TabsFileLoad(P);
            }
            e.Handled = true;
        }
    }

    public static string TextFile;
    public static bool TextSave;
}
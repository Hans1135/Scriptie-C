using System.Windows;
using System.Windows.Controls;

public class UnitTabs
{
    // bestaat uit 1 onderdeel: file

    public static ClassGridTabs GridTabs = new ClassGridTabs();

    public class ClassGridTabs : TabControl
    {
        //

        public UIElement Init()
        {
            // start het tabs veld

            Items.Add(UnitFile.TabsFile.Init());

            return this;
        }
    }
}
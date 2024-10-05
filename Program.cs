using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using Altagr.Class;
using Altagr.Properties;
using DevExpress.LookAndFeel;
using Altagr.WinForms;

namespace Altagr
{
    class Program
    {

        //delegate int IntFunc(int x);

        //static int Square(int x) { return x * x; }       // Static method
        //int Cube(int x) { return x * x * x; }   // Instance method
        //static void Main()
        //{
        //    Delegate staticD = Delegate.CreateDelegate
        //      (typeof(IntFunc), typeof(Program), "Square");

        //    Delegate instanceD = Delegate.CreateDelegate
        //      (typeof(IntFunc), new Program(), "Cube");

        //    Console.WriteLine(staticD.DynamicInvoke(3));      // 9
        //    Console.WriteLine(instanceD.DynamicInvoke(3));    // 27
        //}
        [STAThread]
        static void Main()
        {
            try
            {
                // Get the type of a specified class.
                Type myType1 = Type.GetType("System.Int32");
                Console.WriteLine("The full name is {0}.\n", myType1.FullName);
            }
            catch (TypeLoadException e)
            {
                Console.WriteLine("{0}: Unable to load type System.Int32", e.GetType().Name);
            }

            try
            {
                // Since NoneSuch does not exist in this assembly, GetType throws a TypeLoadException.
                Type myType2 = Type.GetType("NoneSuch", true);
                Console.WriteLine("The full name is {0}.", myType2.FullName);
            }
            catch (TypeLoadException e)
            {
                Console.WriteLine("{0}: Unable to load type NoneSuch", e.GetType().Name);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //  Application.Run(new Form3());
            // var tag = "frmAccounts1";
            //OpenFormByName("frmAccounts");
            //OpenFormByName("frmCurrencies");
            //OpenFormByName("frmAccounts1");




            UserLookAndFeel.Default.SkinName = Settings.Default.SkinName.ToString();
            UserLookAndFeel.Default.SetSkinStyle(Settings.Default.SkinName.ToString(), Settings.Default.PaletteName.ToString());
            //   Application.Run(new WinForms.frmProductList());




             new frmLogin().Show();
            //var f = new Form2();
            Application.Run();
            //Application.Run(f);
        }

    }
}

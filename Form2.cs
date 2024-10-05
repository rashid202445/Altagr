using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Altagr
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // EBS.Controls.ibsTextBox

            propertyGridControl1.SelectedObject = new tet();
            propertyGridControl2.SelectedObject = propertyGridControl1;
        }
        public class tet
        {
            public int int1 { get; set; }
            /// <summary>
            /// خط الشبكة
            /// </summary>
            [Category("2.استايل النظام")]
            [DefaultValueAttribute("dddd dd/MM/yyyy")]
            [DisplayName("11. تنسيق تاريخ قصير")]
            public string name { get; set; }
            public tre Tre { get; set; }
            [Category("2.استايل النظام")]
            [DefaultValueAttribute(typeof(Font), "Arial")]
            [DisplayName("9. خط الشبكة")]
            public Font font1 { get; set; }
            [DisplayName("9. لون الشبكة")]
            public Color Color { get; set; }
            [Category("الطباعة")]
            [DefaultValue("")]
            [DisplayName("طابعة المستندات")]
            [TypeConverter(typeof(ibsStringConverter))]
            public string DocumentsPrinter { get; set; }
        }
        public class ibsStringConverter : StringConverter
        {
            public ibsStringConverter()
            {

            }
            string[] Values = new string[] { "3", "4", "5", "6", "7", "8" };
            public ibsStringConverter(string[] Values)
            {
                this.Values = Values;
            }
            List<string> list = new List<string>();
            public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context) => new StandardValuesCollection(Values);//return null;
            public override bool GetStandardValuesExclusive(ITypeDescriptorContext context) => true;
            public override bool GetStandardValuesSupported(ITypeDescriptorContext context) => true;
        }
        public enum tre
        {
            ret,
            left
        }
    }
}

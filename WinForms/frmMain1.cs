using Altagr.Class;
using Altagr.Properties;
using DevExpress.LookAndFeel;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking2010.Views.NativeMdi;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Altagr.WinForms
{
    public partial class frmMain1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public static frmMain1 _instance;
        public static frmMain1 Instance
        {

            get
            {
                if (_instance == null)
                    _instance = new frmMain1();

                return _instance;
            }
        }
        public frmMain1()
        {
            InitializeComponent();
            accordionControl1.ElementClick += AccordionControl1_ElementClick;
            tabbedView = this.tabbedView1;
        }
        private void AccordionControl1_ElementClick(object sender, DevExpress.XtraBars.Navigation.ElementClickEventArgs e)
        {
            var tag = e.Element.Tag as string;
            if (tag != string.Empty)
            {
                OpenFormByName(tag);
            }
        }
        static DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView;

        public static void OpenFormByName(string name)
        {

            XtraForm frm = null;
            Form floatForm = new Form();


            switch (name)
            {

                case "frmPurchaseInvoicesList":
                    frm = new frmSalesInvoicesList(Class.Master.InvoiceType.Purchase);
                    break;
                case "frmSalesInvoicesList":
                    frm = new frmSalesInvoicesList(Class.Master.InvoiceType.Sales);
                    break;
                default:
                    //var q = from t in Assembly.GetExecutingAssembly().GetTypes()
                    //        where t.IsClass
                    //        select t;

                    //q.ToList().ForEach(t => Console.WriteLine(t.Namespace));
                    var ins = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name == name);//"frmAccounts");
                    if (ins != null)
                    {
                        frm = Activator.CreateInstance(ins) as XtraForm;
                        if (Application.OpenForms[frm.Name] != null)
                        {
                            frm = (XtraForm)Application.OpenForms[frm.Name];
                        var doc=    tabbedView.Documents.FirstOrDefault(x => x.ControlName == frm.Name);
                            if (doc!=null)
                            {
                                tabbedView.ActivateDocument(frm);
                                return;
                            }
                        }
                        else
                        {
                            //    frm.Show();
                        }

                        frm.BringToFront();

                    }
                    break;
            }



            if (frm != null)
            {
                frm.Name = name;
                DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentSettings.Attach(frm, new DocumentSettings()
                {
                    Caption = frm.Text,
                    FloatLocation = new System.Drawing.Point(100, 100),
                    FloatSize = new System.Drawing.Size(600, 400)
                });
                tabbedView.AddDocument(frm);
                //OpenForm(frm);
            }
        }
        public void OpenFormByName1(string name)
        {
            var ins = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(s => s.Name == name);
            if (ins != null)
            {
                var frm = Activator.CreateInstance(ins) as XtraForm;
                frm.Name = name;
                DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentSettings.Attach(frm, new DocumentSettings()
                {
                    Caption = frm.Text,
                    FloatLocation = new System.Drawing.Point(100, 100),
                    FloatSize = new System.Drawing.Size(600, 400)
                });
                documentManager1.View.AddDocument(frm, frm.Text);
                return;
             
            }
        }
        public static void OpenForm(XtraForm frm, bool OpenInDialog = false)
        {
            //var frm = Activator.CreateInstance(ins) as XtraForm;
            //frm.Name = name;
            DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentSettings.Attach(frm, new DocumentSettings()
            {
                Caption = frm.Text,
                FloatLocation = new System.Drawing.Point(100, 100),
                FloatSize = new System.Drawing.Size(600, 400)
            });
            tabbedView.AddDocument(frm);
          
        }
        private void frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.SkinName = UserLookAndFeel.Default.SkinName;
            Settings.Default.PaletteName = UserLookAndFeel.Default.ActiveSvgPaletteName;
            //e.Cancel = true;
            Settings.Default.Save();
            Application.Exit();
        }

        private void frm_Main_Load(object sender, EventArgs e)
        {
            UserLookAndFeel.Default.SkinName = Settings.Default.SkinName.ToString();
            UserLookAndFeel.Default.SetSkinStyle(Settings.Default.SkinName.ToString(), Settings.Default.PaletteName.ToString());
            DevExpress.XtraEditors.WindowsFormsSettings.DefaultFont = Settings.Default.SystemFont;
            accordionControl1.Elements.Clear();
            var screens = Class.Session.ScreensAccesses.Where(x => x.CanShow == true || Session.User.UserType == (byte)Master.UserType.Admin);
            screens.Where(s => s.ParentScreenID == 0).ToList().ForEach(s =>
            {
                AccordionControlElement elm = new AccordionControlElement();
                elm.Text = s.ScreenCaption;
                elm.Tag = s.ScreenName;
                elm.Name = s.ScreenName;
                elm.Style = ElementStyle.Group;
                accordionControl1.Elements.Add(elm);
                //AddAccordionElementGroup(s)
                AddAccordionElement(elm, s.ScreenID);

            });

        }
        void AddAccordionElement(AccordionControlElement parent, long parentID)
        {
            var screens = Class.Session.ScreensAccesses.Where(x => x.CanShow == true || Session.User.UserType == (byte)Master.UserType.Admin);

            screens.Where(s => s.ParentScreenID == parentID).ToList().ForEach(s =>
            {
                AccordionControlElement elm = new AccordionControlElement();
                elm.Text = s.ScreenCaption;
                elm.Tag = s.ScreenName;
                elm.Name = s.ScreenName;
                elm.Style = ElementStyle.Item;
                parent.Elements.Add(elm);
            });

        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (FontDialog dialog = new FontDialog())
            {
                dialog.Font = DevExpress.XtraEditors.WindowsFormsSettings.DefaultFont;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    DevExpress.XtraEditors.WindowsFormsSettings.DefaultFont = dialog.Font;
                    Settings.Default.SystemFont = dialog.Font;
                    Settings.Default.Save();
                }
            }
        }
    }
}
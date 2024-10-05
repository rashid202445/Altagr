using Altagr.Class;
using Altagr.Properties;
using DevExpress.LookAndFeel;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraBars.Docking2010.Views.Tabbed;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraTab;
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
    //public interface ITypeResolver
    //{
    //    string GetName(Type type);
    //    Type GetType(Assembly assembly, string typeName);
    //}
    //class TypeResolver : ITypeResolver
    //{
    //    public string GetName(Type type) => type.AssemblyQualifiedName;
    //    public Type GetType(Assembly assembly, string typeName) =>
    //        assembly.GetType(typeName) ?? Type.GetType(typeName);
    //}
    public partial class frm_Main : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public static frm_Main _instance;
        public static frm_Main Instance
        {

            get
            {
                if (_instance == null)
                    _instance = new frm_Main();

                return _instance;
            }
        }
      
        public frm_Main()
        {
            InitializeComponent();
            accordionControl1.ElementClick += AccordionControl1_ElementClick;
            //dockManager2 = dockManager1;
            //dockPanel2_Container = dockPanel1_Container;
            //tabbedView = this.tabbedView1;
        }
        static DevExpress.XtraBars.Docking.DockManager dockManager2;
        static DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        static DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView;
        private void AccordionControl1_ElementClick(object sender, DevExpress.XtraBars.Navigation.ElementClickEventArgs e)
        {
            var tag = e.Element.Tag as string;
            if (tag != string.Empty)
            {
                OpenFormByName1(tag);
            }
        }
     
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
                    var q = from t in Assembly.GetExecutingAssembly().GetTypes()
                            where t.IsClass
                            select t;

                    q.ToList().ForEach(t => Console.WriteLine(t.Namespace));
                    var ins = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name == name);//"frmAccounts");
                    if (ins != null)
                    {
                        frm = Activator.CreateInstance(ins) as XtraForm;
                        if (Application.OpenForms[frm.Name] != null)
                        {
                            frm = (XtraForm)Application.OpenForms[frm.Name];
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
                tabbedView.AddFloatDocument(frm);
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
                //DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentSettings.Attach(frm, new DocumentSettings()
                //{
                //    Caption = frm.Text,
                //    FloatLocation = new System.Drawing.Point(100, 100),
                //    FloatSize = new System.Drawing.Size(600, 400)
                //});
                DockPanel p1 = dockManager1.AddPanel(DockingStyle.Fill);
                p1.Text = frm.Text;
                frm.TopLevel = false;
                DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container = new ControlContainer();
                dockPanel1_Container.Dock = DockStyle.Fill;
                //p1.Controls.Add(dockPanel1_Container);
                p1.Controls.Add(frm);
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.WindowState = FormWindowState.Maximized;
                frm.Dock = DockStyle.Fill;
                var f = new DockPanel();//   dockPanel1.
                frm.Show();
                this.Controls.Add(p1);
                //p1.ParentPanel.Tabbed = true;
                //var d = new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(components);
                //d. = frm;
                //frm.Show();
                //documentManager1.MdiParent = this;
                //frm.MdiParent = this;
                //nativeMdiView1.AddDocument(frm);
                //widgetView1.AddDocument(frm, frm.Text);
                //documentManager1.View.AddDocument(frm, frm.Text);
                //tabbedView.AddDocument(frm);
                //tabbedView.AddFloatDocument(frm);
                return;
                //frm.MdiParent = this;
                //frm.Show();
                //xtraTabbedMdiManager1.SelectedPage = xtraTabbedMdiManager1.Pages[frm];  // عرض النافذة الفرعية افتراضيًا

                //this.xtraTabbedMdiManager1.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPagesAndTabControlHeader; // إضافة زر حذف بعد تعيين التصنيف ، لا بد من تعيين تسميات متعددة مرة واحدة فقط

                XtraTabPage tab = new XtraTabPage();
                frm.FormBorderStyle = FormBorderStyle.None;
                //  tab.SuspendLayout();
                //       frm.SuspendLayout();
                //xtraTabControl1.SelectedTabPage = tab;
                //foreach (XtraTabPage tab1 in xtraTabControl1.TabPages)
                //{

                //    if (tab1.Text == frm.Text)
                //    {
                //        xtraTabControl1.SelectedTabPage = tab1;
                //        return;
                //    }

                //}
                //xtraTabControl1.TabPages.Add(tab);
                //LayoutControl layout = new LayoutControl();
                //LayoutControlGroup Root = new LayoutControlGroup();
                //((System.ComponentModel.ISupportInitialize)(layout)).BeginInit();
                //layout.SuspendLayout();
                //((ISupportInitialize)(Root)).BeginInit();
                //LayoutControlItem layoutControlItem1 = new LayoutControlItem();
                //((System.ComponentModel.ISupportInitialize)(layoutControlItem1)).BeginInit();
                //layout.Dock = System.Windows.Forms.DockStyle.Fill;
                //layout.Location = new System.Drawing.Point(0, 0);
                //layout.Name = "layoutControl1";
                //layout.OptionsView.RightToLeftMirroringApplied = true;
                //layout.Root = Root;
                //layout.Size = new System.Drawing.Size(565, 417);
                //layout.TabIndex = 0;
                //layout.Text = "layoutControl1";
                //tab.Size = new System.Drawing.Size(565, 417);
                //tab.Text = frm.Text;
                //tab.ImageOptions.SvgImage = frm.IconOptions.SvgImage;// IconOptions.SvgImage
                //tab.Controls.Add(layout);
                //tab.AllowTouchScroll = true;
                //tab.AutoScroll = true;
                //layout.Controls.Add(frm);
                //Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
                //Root.GroupBordersVisible = false;
                //Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
                //layoutControlItem1
                //});

                //layoutControlItem1.Control = frm;
                //layoutControlItem1.Location = new System.Drawing.Point(272, 0);
                //layoutControlItem1.Name = "layoutControlItem1";
                //layoutControlItem1.Size = new System.Drawing.Size(565, 417);
                //layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
                //layoutControlItem1.TextVisible = false;
                //// Root.Name = "Root";
                //Root.Size = new System.Drawing.Size(565, 417);
                //Root.TextVisible = false;
                //frm.WindowState = FormWindowState.Maximized;
                //frm.Dock = DockStyle.Fill;
                //frm.BringToFront();
                //frm.Show();
                ////if (Application.OpenForms[frm.Name] != null)
                ////{
                ////   frm= Application.OpenForms[frm.Name];

                ////}
                ////else
                ////{
                ////    frm.Show();
                ////}
                ////frm.BringToFront();
                //// Application.Run(frm);
            }
        }
        public void OpenFormByName2(string name)
        {
            var ins = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(s => s.Name == name);
            if (ins != null)
            {
                var frm = Activator.CreateInstance(ins) as XtraUserControl;
                //  frm.TopLevel = false;
                //frm.MdiParent = this;
                //frm.Show();
                //xtraTabbedMdiManager1.SelectedPage = xtraTabbedMdiManager1.Pages[frm];  // عرض النافذة الفرعية افتراضيًا

                //this.xtraTabbedMdiManager1.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPagesAndTabControlHeader; // إضافة زر حذف بعد تعيين التصنيف ، لا بد من تعيين تسميات متعددة مرة واحدة فقط

                //XtraTabPage tab = new XtraTabPage();
                ////  frm.FormBorderStyle = FormBorderStyle.None;
                ////  tab.SuspendLayout();
                ////       frm.SuspendLayout();
                //xtraTabControl1.SelectedTabPage = tab;
                //foreach (XtraTabPage tab1 in xtraTabControl1.TabPages)
                //{

                //    if (tab1.Text == frm.Text)
                //    {
                //        xtraTabControl1.SelectedTabPage = tab1;
                //        return;
                //    }

                //}
                //xtraTabControl1.TabPages.Add(tab);
                //LayoutControl layout = new LayoutControl();
                //LayoutControlGroup Root = new LayoutControlGroup();
                //((System.ComponentModel.ISupportInitialize)(layout)).BeginInit();
                //layout.SuspendLayout();
                //((ISupportInitialize)(Root)).BeginInit();
                //LayoutControlItem layoutControlItem1 = new LayoutControlItem();
                //((System.ComponentModel.ISupportInitialize)(layoutControlItem1)).BeginInit();
                //layout.Dock = System.Windows.Forms.DockStyle.Fill;
                //layout.Location = new System.Drawing.Point(0, 0);
                //layout.Name = "layoutControl1";
                //layout.OptionsView.RightToLeftMirroringApplied = true;
                //layout.Root = Root;
                //layout.Size = new System.Drawing.Size(565, 417);
                //layout.TabIndex = 0;
                //layout.Text = "layoutControl1";
                ////   tab.Size = new System.Drawing.Size(565, 417);
                //tab.Text = frm.Text;
                ////  tab.ImageOptions.SvgImage = frm.IconOptions.SvgImage;// IconOptions.SvgImage
                //tab.Controls.Add(layout);
                //tab.AllowTouchScroll = true;
                //tab.AutoScroll = true;
                //layout.Controls.Add(frm);

                //Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
                //Root.GroupBordersVisible = false;
                //Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
                //layoutControlItem1
                //});

                //layoutControlItem1.Control = frm;
                //layoutControlItem1.Location = new System.Drawing.Point(272, 0);
                //layoutControlItem1.Name = "layoutControlItem1";
                //layoutControlItem1.Size = new System.Drawing.Size(565, 417);
                //layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
                //layoutControlItem1.TextVisible = false;
                //// Root.Name = "Root";
                //Root.Size = new System.Drawing.Size(565, 417);
                //Root.TextVisible = false;
                ////   frm.WindowState = FormWindowState.Maximized;
                //frm.Dock = DockStyle.Fill;
                //frm.BringToFront();
                //layout.Dock = DockStyle.Fill;
                //frm.Show();
                ////if (Application.OpenForms[frm.Name] != null)
                ////{
                ////   frm= Application.OpenForms[frm.Name];

                ////}
                ////else
                ////{
                ////    frm.Show();
                ////}
                ////frm.BringToFront();
                //// Application.Run(frm);
            }
        }
       // DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
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
            return;
            //مدير النظام
            DevExpress.XtraBars.Docking.DockPanel panel1 = new DevExpress.XtraBars.Docking.DockPanel();
            panel1.SuspendLayout();
            //  panel1.Controls.Add(this.dockPanel1_Container);
            panel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Float;
            panel1.FloatLocation = new System.Drawing.Point(400, 305);
            panel1.ID = new System.Guid("dc3666f0-4a2a-40dd-b741-7c50807cbdf6");
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = frm.Name;
            panel1.OriginalSize = new System.Drawing.Size(200, 200);
            panel1.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            panel1.SavedIndex = 0;
            panel1.Size = new System.Drawing.Size(200, 200);
            panel1.Text = frm.Text;
            frm.TopLevel = false;
      //      panel1.FloatForm.Owner = frm;
            // panel1.Controls.Add(frm);
         //   dockPanel2_Container.for
            panel1.Controls.Add(dockPanel2_Container);
            if (Session.User.UserType == (byte)Master.UserType.Admin)
            {

                if (OpenInDialog)
                    //EnsureFloatFormOwner
                     frm.ShowDialog();
                else
                {
           //         dockManager2.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
           //panel1 });
                    // dockManager2.RootPanels.
                    frm.Show();
                }
            panel1.ResumeLayout(false);
                return;
            }
            var screen = Session.ScreensAccesses.SingleOrDefault(x => x.ScreenName == frm.Name);
            if (screen != null)
            {
                if (screen.CanOpen == true)
                {
                    if (OpenInDialog)
                        frm.ShowDialog();
                    else
                        frm.Show();
                    return;
                }
                else
                {
                    XtraMessageBox.Show(
                    text: "غير مصرح لك ",
                     caption: "",
                     icon: MessageBoxIcon.Error,
                   buttons: MessageBoxButtons.OK
                     );
                    return;
                }

            }



        }

        private void frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.SkinName = UserLookAndFeel.Default.SkinName;
            Settings.Default.PaletteName = UserLookAndFeel.Default.ActiveSvgPaletteName;
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
        //void AddAccordionElementGroup(Class.ScreensAccessProfile s)
        //{
        //    var screens = Class.Session.ScreensAccesses.Where(x => x.CanShow == true || Session.User.UserType == (byte)Master.UserType.Admin);

        //    screens.Where(s => s.ParentScreenID == parentID).ToList().ForEach(s =>
        //    {
        //        AccordionControlElement elm = new AccordionControlElement();
        //        elm.Text = s.ScreenCaption;
        //        elm.Tag = s.ScreenName;
        //        elm.Name = s.ScreenName;
        //        elm.Style = ElementStyle.Item;
        //        parent.Elements.Add(elm);
        //    });

        //}
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

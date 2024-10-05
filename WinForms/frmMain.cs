using DevExpress.XtraBars;
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
using System.Windows.Forms;

namespace Altagr.WinForms
{
    public partial class frmMain : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public frmMain()
        {
            InitializeComponent();
            accordionControl1.ElementClick += AccordionControl1_ElementClick;
            xtraTabControl1.CloseButtonClick += XtraTabControl1_CloseButtonClick;
        }

      

        private void AccordionControl1_ElementClick(object sender, DevExpress.XtraBars.Navigation.ElementClickEventArgs e)
        {
            var tag = e.Element.Tag as string;
            if (tag != string.Empty)
            {
                OpenFormByName1(tag);
            }
        }
        public void OpenFormByName1(string name)
        {
           // Form frm = null;
            var ins = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(s => s.Name == name);
          
            if (ins != null)
            {
                var frm = Activator.CreateInstance(ins) as Form;
                if (Application.OpenForms[frm.Name] != null)
                {
                    frm = Application.OpenForms[frm.Name];

                }
                else
                {
                    frm.Show();
                }
                frm.BringToFront();
               // Application.Run(frm);
            }
        }
                  

           
        
        //public static void OpenForm(Form frm, bool OpenInDialog = false)
        //{
        //    if (Session.User.UserType == (byte)Master.UserType.Admin)
        //    {
        //        frm.Show();
        //        return;
        //    }
        //    var screen = Session.ScreensAccesses.SingleOrDefault(x => x.ScreenName == frm.Name);
        //    if (screen != null)
        //    {
        //        if (screen.CanOpen == true)
        //        {
        //            if (OpenInDialog)
        //                frm.ShowDialog();
        //            else
        //                frm.Show();
        //            return;
        //        }
        //        else
        //        {
        //            XtraMessageBox.Show(
        //   text: "غير مصرح لك ",
        //   caption: "",
        //   icon: MessageBoxIcon.Error,
        //   buttons: MessageBoxButtons.OK
        //   );
        //            return;
        //        }

        //    }



        //}

        public void OpenFormByName(string name)
        {
            var ins = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(s => s.Name == name);
            if (ins != null)
            {
                var frm = Activator.CreateInstance(ins) as XtraForm;
                frm.TopLevel = false;
                //frm.MdiParent = this;
                //frm.Show();
                //xtraTabbedMdiManager1.SelectedPage = xtraTabbedMdiManager1.Pages[frm];  // عرض النافذة الفرعية افتراضيًا

                //this.xtraTabbedMdiManager1.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPagesAndTabControlHeader; // إضافة زر حذف بعد تعيين التصنيف ، لا بد من تعيين تسميات متعددة مرة واحدة فقط

                XtraTabPage tab = new XtraTabPage();
                
              //  tab.SuspendLayout();
         //       frm.SuspendLayout();
                xtraTabControl1.SelectedTabPage = tab;
                foreach (XtraTabPage tab1 in xtraTabControl1.TabPages)
                {

                    if (tab1.Text == frm.Text)
                    {
                        xtraTabControl1.SelectedTabPage = tab1;
                        return;
                    }

                }
                xtraTabControl1.TabPages.Add(tab);
                LayoutControl layout = new LayoutControl();
                LayoutControlGroup Root = new LayoutControlGroup();
                ((System.ComponentModel.ISupportInitialize)(layout)).BeginInit();
                layout.SuspendLayout();
                ((ISupportInitialize)(Root)).BeginInit();
                LayoutControlItem layoutControlItem1 = new LayoutControlItem();
                ((System.ComponentModel.ISupportInitialize)(layoutControlItem1)).BeginInit();
                layout.Dock = System.Windows.Forms.DockStyle.Fill;
                layout.Location = new System.Drawing.Point(0, 0);
                layout.Name = "layoutControl1";
                layout.OptionsView.RightToLeftMirroringApplied = true;
                layout.Root = Root;
                layout.Size = new System.Drawing.Size(565, 417);
                layout.TabIndex = 0;
                layout.Text = "layoutControl1";
                tab.Size = new System.Drawing.Size(565, 417);
                tab.Text = frm.Text;
                tab.ImageOptions.SvgImage = frm.IconOptions.SvgImage;// IconOptions.SvgImage
                tab.Controls.Add(layout);
                tab.AllowTouchScroll = true;
                tab.AutoScroll = true;
                layout.Controls.Add(frm);
                Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
                Root.GroupBordersVisible = false;
                Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
                layoutControlItem1
                });

                layoutControlItem1.Control = frm;
                layoutControlItem1.Location = new System.Drawing.Point(272, 0);
                layoutControlItem1.Name = "layoutControlItem1";
                layoutControlItem1.Size = new System.Drawing.Size(565, 417);
                layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
                layoutControlItem1.TextVisible = false;
                // Root.Name = "Root";
                Root.Size = new System.Drawing.Size(565, 417);
                Root.TextVisible = false;

                frm.Dock = DockStyle.Fill;
                frm.BringToFront();
                frm.Show();
                //if (Application.OpenForms[frm.Name] != null)
                //{
                //   frm= Application.OpenForms[frm.Name];

                //}
                //else
                //{
                //    frm.Show();
                //}
                //frm.BringToFront();
                // Application.Run(frm);
            }
        }

        private void XtraTabControl1_CloseButtonClick(object sender, EventArgs e)
        {
            try
            {
                xtraTabControl1.TabPages.Remove(xtraTabControl1.SelectedTabPage);
            }
            catch { }
        }

        private void accordionControlElement12_Click(object sender, EventArgs e)
        {

        }
    }
}

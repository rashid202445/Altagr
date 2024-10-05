using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Altagr.WinForms
{
    [System.ComponentModel.Designer(typeof(System.Windows.Forms.Design.ControlDesigner))]
    public partial class frmMaster :XtraForm
    {
       public bool IsNew;
       
        public frmMaster()
        {
            InitializeComponent();
        }
        public virtual void Save()
        {
            XtraMessageBox.Show("تم الحفظ بنجاح");
            RefreshData();
            IsNew = false;
        }
        public virtual void New()
        {
            GetData();
            IsNew = true;
        }
        public virtual void GetData()
        {

        }
        public virtual void SetData()
        {

        }
        public virtual void Delete()
        {
            XtraMessageBox.Show(" تم الحذف   بنجاح ");
            New();
            RefreshData();
        }
        public virtual void RefreshData()
        {

        }
        public virtual void Print()
        {

        }
        public virtual bool IsDataValid()
        {
            return true;
        }
            private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(IsDataValid())
            Save();
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            New();
        }

        private void btnDelet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(XtraMessageBox.Show("تاكيد","تاكيد عملية الحذف",MessageBoxButtons.OKCancel,MessageBoxIcon.Hand)==DialogResult.OK)
            Delete();
        }

        private void frmMaster1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                //Save();
                btnSave.PerformClick();
            }
            if (e.KeyCode == Keys.F2)
            {
                New();
            }
            if (e.KeyCode == Keys.F3)
            {
                Delete();
            }
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Print();
        }
    }
}
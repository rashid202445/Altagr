using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
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
    public partial class frmProductCategory : frmMaster
    {
        DAL.tblLSTypeProduct product;
        public frmProductCategory()
        {
            InitializeComponent();
            New();
        }
        public override void Save()
        {

            if (!IsDataValid()) return;

            var db = new DAL.dbDataContext();
            if (product.ID == 0)
                db.tblLSTypeProducts.InsertOnSubmit(product);
            else
            {
                try
                {
                    // db.tblAccounts.

                    db.tblLSTypeProducts.Attach(product);
                }
                catch
                {
                    product = db.tblLSTypeProducts.FirstOrDefault(e1 => e1.ID == product.ID);
                }
            }

            SetData();
            db.SubmitChanges();
            base.Save();
        }
        public override void New()
        {
            product = new DAL.tblLSTypeProduct();
            base.New();
        }
        public override void GetData()
        {
            textEdit1.Text = product.Name;
            lookUpEdit1.EditValue = product.ParentID;
            base.GetData();
        }
        public override void SetData()
        {
            product.Name = textEdit1.Text;
            product.ParentID = (lookUpEdit1.EditValue as long?)?? 0;
            base.SetData();
        }
        public override bool IsDataValid()
        {
            if (textEdit1.Text.Trim() == string.Empty)
            {
                textEdit1.ErrorText = "الرجاء ادخال اسم الصنف";
                textEdit1.Focus();
                return false;
            }
            if (!productName())
            {
                textEdit1.Focus();
                return false;
            }
            return base.IsDataValid();
        }
        public override void RefreshData()
        {
            var db = new DAL.dbDataContext();
            var groups = db.tblLSTypeProducts;
            lookUpEdit1.Properties.DataSource = groups;
            treeList1.DataSource = groups;
            treeList1.ExpandAll();
            base.RefreshData();
        }

        private void frm_ProductCategory_Load(object sender, EventArgs e)
        {
            RefreshData();
            lookUpEdit1.Properties.DisplayMember = nameof(product.Name);
            lookUpEdit1.Properties.ValueMember = nameof(product.ID);
            lookUpEdit1.Properties.TextEditStyle = TextEditStyles.Standard;
            treeList1.ParentFieldName = nameof(product.ParentID);//"FatherNumber";
            treeList1.KeyFieldName = nameof(product.ID);
            treeList1.OptionsBehavior.Editable = false;
            treeList1.Columns[nameof(product.Name)].Caption = "الاسم";
            treeList1.FocusedNodeChanged += TreeList1_FocusedNodeChanged;
        }

        private void TreeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            int id = 0;
            if (int.TryParse(e.Node.GetValue("ID").ToString(), out id))
            {
                var db = new DAL.dbDataContext();
                product = db.tblLSTypeProducts.Single(x => x.ID == id);
                GetData();
            }
        }
        private void textEdit1_Leave(object sender, EventArgs e)
        {
            productName();
        }
        Boolean productName()
        {
            var db = new DAL.dbDataContext();
            
                var oldObj = db.tblLSTypeProducts.Where(x => x.Name.Trim() == textEdit1.Text.Trim() &&
               x.ID != product.ID);
                if (oldObj.Count() > 0)
                {
                    textEdit1.ErrorText = "هذا الاسم مسجل مسبقا";

                    return false;
                }
                return true;
           

        }
    }
}
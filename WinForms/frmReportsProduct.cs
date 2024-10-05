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
    public partial class frmReportsProduct : DevExpress.XtraEditors.XtraForm
    {
        public frmReportsProduct()
        {
            InitializeComponent();
        }

        private void frmReportsProduct_Load(object sender, EventArgs e)
        {
            searchLookUpEdit1.Properties.DataSource = Class.Session.ProductsView;
            searchLookUpEdit1.Properties.DisplayMember = "ProductName";
            searchLookUpEdit1.Properties.ValueMember = "ID";
            searchLookUpEdit1.EditValueChanged += SearchLookUpEdit1_EditValueChanged;
        

        }

        private void GridLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            vGridControl1.DataSource = new DAL.dbDataContext().vewMainProductUnitQuantities.Where(s => s.ProductsID == (long)searchLookUpEdit1.EditValue);
        }

        private void SearchLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DAL.vewMainProductUnitQuantity vin;
               
                vGridControl1.DataSource = new DAL.dbDataContext().vewMainProductUnitQuantities.Where(s => s.ProductsID == (long)searchLookUpEdit1.EditValue);
                vGridControl1.Rows["row"+nameof(vin.ProductsID)].Visible = false;
                vGridControl1.Rows["row" + nameof(vin.UnitsID)].Visible = false;
                vGridControl1.Rows["row" + nameof(vin.ProductName)].Properties.Caption = "اسم الصنف";
                vGridControl1.Rows["row" + nameof(vin.UnitName)].Properties.Caption = "الوحدة";
                vGridControl1.Rows["row" + nameof(vin.Quantity)].Properties.Caption = "الكمية المخزنة";
                vGridControl1.Rows["row" + nameof(vin.QuantitySales)].Properties.Caption = " المباعات";
                vGridControl1.Rows["row" + nameof(vin.QuantityPurchase)].Properties.Caption = " المشتريات";
            }
            catch { }
        }
    }
}
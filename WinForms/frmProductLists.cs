using Altagr.Class;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
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
    public partial class frmProductLists : frmMasterList
    {
        public frmProductLists()
        {
            InitializeComponent();
        }
        Session.ProductViewClass ins;
        public override void RefreshData()
        {
             gridControl1.DataSource = Session.ProductsView;
        }
        public override void New()
        {
            frmMain1.OpenForm(new frmProduct());
        }
        private void frmProductLists_Load(object sender, EventArgs e)
        {
            RefreshData();
            gridView1.CustomColumnDisplayText += GridView1_CustomColumnDisplayText;
            gridControl1.ViewRegistered += GridControl1_ViewRegistered;
            gridView1.OptionsDetail.ShowDetailTabs = false;
            gridView1.RowClick += GridView1_RowClick;
            gridView1.BeforeLeaveRow += GridView1_BeforeLeaveRow;
            gridView1.FocusedRowChanged += GridView1_FocusedRowChanged;
            Session.Products.ListChanged += Products_ListChanged;

            gridView1.Columns[nameof(ins.CategoryName)].Caption = "الفئه";
            gridView1.Columns[nameof(ins.Notes)].Caption = "الكود";
            gridView1.Columns[nameof(ins.Descreption)].Caption = "الوصف";
            gridView1.Columns[nameof(ins.Status)].Caption = "نشط";
            gridView1.Columns[nameof(ins.ProductName)].Caption = "الاسم العربي";
            gridView1.Columns[nameof(ins.EnglishProductName)].Caption = " الاسم الاجنبي";
            gridView1.Columns[nameof(ins.Type)].Caption = "النوع";
            gridView1.Columns[nameof(ins.ID)].Visible = false;
        }

        private void GridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
           
        }

        private void GridView1_BeforeLeaveRow(object sender, RowAllowEventArgs e)
        {
            
        }

        private void GridView1_RowClick(object sender, RowClickEventArgs e)
        {
            
        }

        private void Products_ListChanged(object sender, ListChangedEventArgs e)
        {
            RefreshData();
        }

        private void GridControl1_ViewRegistered(object sender, ViewOperationEventArgs e)
        {
            if (e.View.LevelName == "Units")
            {
                Session.ProductViewClass.ProductUOMView ins;
                GridView view = e.View as GridView;
                view.OptionsView.ShowViewCaption = true;
                view.ViewCaption = "وحدات القياس ";
                view.Columns[nameof(ins.UnitName)].Caption = "اسم الوحده";
                view.Columns[nameof(ins.Factor)].Caption = "المعامل";
                view.Columns[nameof(ins.SpecialPrice)].Caption = "سعر البيع";
                view.Columns[nameof(ins.PriceCost)].Caption = "سعر الشراء";
                view.Columns[nameof(ins.Barcode)].Caption = "الباركود";
                view.Columns[nameof(ins.DescountValue)].Caption = " الخصم";
                view.Columns[nameof(ins.DescountPercent)].Caption = " نسبة الخصم";
                view.Columns[nameof(ins.Status)].Caption = "الحالة";
                view.Columns[nameof(ins.UnitID)].Visible = false;
            }
        }

       
        public override void OpenForm(long id)
        {
            if (id > 0)
            {
                frmMain1.OpenForm(new frmProduct(id), true);
            }
        }
        private void GridView1_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "Type")
            {
                e.DisplayText = Master.ProductTypesList.Single(x => x.ID == Convert.ToInt32(e.Value)).Name;
            }
        }
    }
}

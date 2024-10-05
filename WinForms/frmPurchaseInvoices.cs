using Altagr.Class;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Altagr.WinForms
{
    public partial class frmPurchaseInvoices : frmMaster
    {
      //  DAL.InvoiceHeader Invoice;
       // Master.InvoiceType Type;
        DAL.dbDataContext generalDB;
        DAL.tblPurchaseInvoice invoice1;
        DAL.tblPurchaseInvoicesDetaile invoicesDetaile;
        RepositoryItemGridLookUpEdit repoItems;
        RepositoryItemLookUpEdit ProductID;
     //   RepositoryItemLookUpEdit repoUOM;
      //  RepositoryItemLookUpEdit repoStores;
        public frmPurchaseInvoices( )
        {
            InitializeComponent();
            InitializeEarlyEvente();
            RefreshData();
            New();
        }
        public frmPurchaseInvoices(long ID)
        {
            InitializeComponent();
            InitializeEarlyEvente();
            RefreshData();
            using (var db = new DAL.dbDataContext())
            {
                invoice1 = db.tblPurchaseInvoices.Single(s => s.ID == ID);
                GetData();
                IsNew = false;
            }
        }
        void InitializeEarlyEvente()
        {
            gridView1.ValidateRow += GridView1_ValidateRow;
            gridView1.InvalidRowException += GridView1_InvalidRowException;
            lkp_Type.EditValueChanged += Lkp_PartType_EditValueChanged;
        }

        //  DAL.InvoiceDetail detailsInstance = new DAL.InvoiceDetail();

        private void frmInvoice_Load(object sender, EventArgs e)
        {
           

            btnPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            lkp_Type.IntializeData(Class.Master.PartTypesList);
            lkp_Type.Properties.PopulateColumns();
            lkp_Type.Properties.Columns["ID"].Visible = false;
            lkp_Type.EditValue = Master.PartType.Cash;
            spn_Paid.Properties.ReadOnly = true;
            //  glkp_ExchangeAccountID.Properties.Buttons.Add(new EditorButton(ButtonPredefines.Plus));
            glkp_ExchangeAccountID.ButtonClick += Lkp_PartType_ButtonClick;
            glkp_ExchangeAccountID.Properties.ValidateOnEnterKey = true;
            glkp_ExchangeAccountID.Properties.AllowNullInput = DefaultBoolean.False;
            glkp_ExchangeAccountID.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            glkp_ExchangeAccountID.Properties.ImmediatePopup = true;
            glkp_ExchangeAccountID.Properties.ButtonClick += RepoItems_ButtonClick;
            var PartIDView = glkp_ExchangeAccountID.Properties.View;
            PartIDView.FocusRectStyle = DrawFocusRectStyle.RowFullFocus;
            PartIDView.OptionsSelection.UseIndicatorForSelection = true;
            PartIDView.OptionsView.ShowAutoFilterRow = true;
            PartIDView.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.ShowAlways;
            PartIDView.PopulateColumns(glkp_ExchangeAccountID.Properties.DataSource);
            //PartIDView.Columns["IsActive"].Visible = false;
            //PartIDView.Columns["Type"].Visible = false;


            gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;

            gridView1.Columns[nameof(invoicesDetaile.ID)].Visible = false;
            gridView1.Columns[nameof(invoicesDetaile.ParentID)].Visible = false;

          //  repoUOM.IntializeData(Session.LSUnit, gridView1.Columns[nameof(invoicesDetaile.UnitID)], gridControl1);
          // repoStores.IntializeData(Session.Store, gridView1.Columns[nameof(detailsInstance.StoreID)], gridControl1);

            repoItems = new RepositoryItemGridLookUpEdit();
            repoItems.IntializeData(Session.ProductsView.Where(x => x.Status == true), gridView1.Columns[nameof(invoicesDetaile.ProductID)], gridControl1, "ProductName", "ID");
            repoItems.ValidateOnEnterKey = true;
            repoItems.AllowNullInput = DefaultBoolean.False;
            repoItems.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            repoItems.ImmediatePopup = true;
            repoItems.Buttons.Add(new EditorButton(ButtonPredefines.Plus));
            repoItems.ButtonClick += RepoItems_ButtonClick;
            var repoView = repoItems.View;
            repoView.FocusRectStyle = DrawFocusRectStyle.RowFullFocus;
            repoView.OptionsSelection.UseIndicatorForSelection = true;
            repoView.OptionsView.ShowAutoFilterRow = true;
            repoView.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.ShowAlways;
            repoView.PopulateColumns(repoItems.DataSource);
            repoView.Columns["Status"].Visible = false;
            repoView.Columns["Type"].Visible = false;

           
            repoView.Columns["ProductName"].Caption = "الاسم العربي";
            repoView.Columns["EnglishProductName"].Caption = "الاسم الاجنبي";
            repoView.Columns["Descreption"].Caption = "الوصف";
            repoView.Columns["CategoryName"].Caption = "الفئه";
            ProductID.IntializeData(Session.ProductsView, gridView1.Columns[nameof(invoicesDetaile.ProductID)], gridControl1, "ProductName", "ID");

            RepositoryItemSpinEdit spinEdit = new RepositoryItemSpinEdit();
            gridView1.Columns[nameof(invoicesDetaile.TotalAMount)].ColumnEdit = spinEdit;
            gridView1.Columns[nameof(invoicesDetaile.UnitPrice)].ColumnEdit = spinEdit;
            gridView1.Columns[nameof(invoicesDetaile.Quantity)].ColumnEdit = spinEdit;
            gridView1.Columns[nameof(invoicesDetaile.DiscountValue)].ColumnEdit = spinEdit;

            RepositoryItemSpinEdit spinRatioEdit = new RepositoryItemSpinEdit();
            gridView1.Columns[nameof(invoicesDetaile.SubDescount)].ColumnEdit = spinRatioEdit;

            spinRatioEdit.Increment = 0.01m;
            spinRatioEdit.Mask.EditMask = "p";
            spinRatioEdit.Mask.UseMaskAsDisplayFormat = true;
            spinRatioEdit.MaxValue = 1;

            gridControl1.RepositoryItems.Add(spinRatioEdit);
            gridControl1.RepositoryItems.Add(spinEdit);
            gridView1.Columns[nameof(invoicesDetaile.TotalAMount)].OptionsColumn.AllowFocus = false;
            gridView1.Columns[nameof(invoicesDetaile.tblProducts)].Visible = false;
            gridView1.Columns[nameof(invoicesDetaile.tblPurchaseInvoice)].Visible = false;
            gridView1.Columns[nameof(invoicesDetaile.tblUser)].Visible = false;
            gridView1.Columns[nameof(invoicesDetaile.UserID)].Visible = false;
            gridView1.Columns[nameof(invoicesDetaile.ExpiryDate)].Visible = false;
            gridView1.Columns[nameof(invoicesDetaile.EnterTime)].Visible = false;


            //gridView1.Columns.Add(new GridColumn() { Name = "clmCode", FieldName = "Code", Caption = "الكود", UnboundType = DevExpress.Data.UnboundColumnType.String });
            gridView1.Columns.Add(new GridColumn()
            {
                Name = "clmIndex",
                FieldName = "Index",
                Caption = "مسلسل",
                UnboundType = DevExpress.Data.UnboundColumnType.Integer,
                MaxWidth = 30
            });

            gridView1.Columns[nameof(invoicesDetaile.ProductID)].Caption = "الصنف";
            gridView1.Columns[nameof(invoicesDetaile.UnitPrice)].Caption = "سعر التكلفه";
            gridView1.Columns[nameof(invoicesDetaile.SubDescount)].Caption = "ن.خصم";
            gridView1.Columns[nameof(invoicesDetaile.DiscountValue)].Caption = "ق.خصم";
            gridView1.Columns[nameof(invoicesDetaile.Quantity)].Caption = "الكميه";
            gridView1.Columns[nameof(invoicesDetaile.UnitID)].Caption = "الوحده";
            gridView1.Columns[nameof(invoicesDetaile.UnitPrice)].Caption = "السعر";
         //   gridView1.Columns[nameof(detailsInstance.StoreID)].Caption = "المخزن";
          //  gridView1.Columns[nameof(invoicesDetaile.TotalAMount)].Caption = "اجمالي التكلفه";
            gridView1.Columns[nameof(invoicesDetaile.TotalAMount)].Caption = "اجمالي السعر";

            gridView1.Columns["Index"].OptionsColumn.AllowFocus = false;
            //  gridView1.Columns[nameof(detailsInstance.TotalCostValue)].OptionsColumn.AllowFocus = false;
            //  gridView1.Columns[nameof(detailsInstance.CostValue)].OptionsColumn.AllowFocus = false;

            gridView1.Columns["Index"].VisibleIndex = 0;
            // gridView1.Columns["Code"].VisibleIndex = 1;
            gridView1.Columns[nameof(invoicesDetaile.ProductID)].MinWidth = 125;
            gridView1.Columns[nameof(invoicesDetaile.ProductID)].VisibleIndex = 1;
            gridView1.Columns[nameof(invoicesDetaile.UnitID)].VisibleIndex = 2;
            gridView1.Columns[nameof(invoicesDetaile.Quantity)].VisibleIndex = 3;
            gridView1.Columns[nameof(invoicesDetaile.UnitPrice)].VisibleIndex = 4;
            gridView1.Columns[nameof(invoicesDetaile.SubDescount)].VisibleIndex = 5;
            gridView1.Columns[nameof(invoicesDetaile.DiscountValue)].VisibleIndex = 6;
            gridView1.Columns[nameof(invoicesDetaile.TotalAMount)].VisibleIndex = 7;
            //gridView1.Columns[nameof(detailsInstance.CostValue)].VisibleIndex = 9;
            //gridView1.Columns[nameof(detailsInstance.TotalCostValue)].VisibleIndex = 10;
            //gridView1.Columns[nameof(detailsInstance.StoreID)].VisibleIndex = 11;

            gridView1.Appearance.EvenRow.BackColor = Color.FromArgb(200, 255, 249, 196);
            gridView1.OptionsView.EnableAppearanceEvenRow = true;

            gridView1.Appearance.OddRow.BackColor = Color.WhiteSmoke;
            gridView1.OptionsView.EnableAppearanceOddRow = true;

            RepositoryItemButtonEdit buttonEdit = new RepositoryItemButtonEdit();
            gridControl1.RepositoryItems.Add(buttonEdit);
            buttonEdit.Buttons.Clear();
            buttonEdit.Buttons.Add(new EditorButton(ButtonPredefines.Delete));
            buttonEdit.ButtonClick += ButtonEdit_ButtonClick;
            GridColumn clmnDelete = new GridColumn()
            {
                Name = "clmnDelete",
                Caption = "",
                FieldName = "Delete",
                ColumnEdit = buttonEdit,
                VisibleIndex = 100,
                Width = 15
            };
            buttonEdit.TextEditStyle = TextEditStyles.HideTextEditor;
            gridView1.Columns.Add(clmnDelete);



            #region Events
            spn_DiscountValue.Enter += new System.EventHandler(this.spn_DiscountValue_Enter);
            spn_DiscountValue.Leave += Spn_DiscountValue_Leave;
            spn_DiscountValue.EditValueChanged += Spn_DiscountValue_EditValueChanged;
            spn_DiscountRation.EditValueChanged += Spn_DiscountValue_EditValueChanged;
            spn_TaxValue.Enter += Spn_TaxValue_Enter;
            spn_TaxValue.Leave += Spn_TaxValue_Leave;
            spn_TaxValue.EditValueChanged += Spn_TaxValue_EditValueChanged;
            spn_Tax.EditValueChanged += Spn_TaxValue_EditValueChanged;
            spn_TaxValue.EditValueChanged += Spn_EditValueChanged;
            spn_DiscountValue.EditValueChanged += Spn_EditValueChanged;
            spn_Expences.EditValueChanged += Spn_EditValueChanged;
            spn_Total.EditValueChanged += Spn_EditValueChanged;
            spn_Paid.EditValueChanged += Spn_Paid_EditValueChanged;
            spn_Net.EditValueChanged += Spn_Paid_EditValueChanged;
            spn_Net.EditValueChanging += Spn_Net_EditValueChanging;

            spn_Net.DoubleClick += Spn_Net_MouseDoubleClick;

            lkp_Branch.EditValueChanging += Lkp_Branch_EditValueChanging;
            gridView1.CustomRowCellEditForEditing += GridView1_CustomRowCellEditForEditing;
            gridView1.CellValueChanged += GridView1_CellValueChanged;
            gridView1.RowCountChanged += GridView1_RowCountChanged;
            gridView1.RowUpdated += GridView1_RowUpdated;
            gridView1.CustomUnboundColumnData += GridView1_CustomUnboundColumnData;
            gridView1.CellValueChanging += GridView1_CellValueChanging;
            gridControl1.ProcessGridKey += GridControl1_ProcessGridKey;
            gridView1.CustomColumnDisplayText += GridView1_CustomColumnDisplayText;

            this.Activated += Frm_Invoice_Activated;
            this.KeyPreview = true;
            this.KeyDown += Frm_Invoice_KeyDown;

            #endregion
        }

        private void GridView1_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "UnitID")
            {
                if (e.Value != null && (e.Value as long?) != 0)
                {
                    var db = new DAL.dbDataContext();
                    e.DisplayText = (from x in db.tblUnits
                                     where x.ID == Convert.ToInt64(e.Value)
                                     join un in db.tblLSUnits on x.UnitID equals un.ID
                                     select new
                                     {
                                         un.Name
                                     }).ToArray()[0].Name;
                }
                    //= Master.ProductTypesList.Single(x => x.ID == Convert.ToInt32(e.Value)).Name;
            }
        }

        private void GridView1_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "ProductID")
            {
                var row = gridView1.GetRow(e.RowHandle) as DAL.tblPurchaseInvoicesDetaile;
                if (row != null)
                {
                    if (row.ProductID != 0 && e.Value.Equals(row.ProductID) == false)
                        row.UnitID = 0;
                }
            }

        }

        private void RepoItems_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            //if (e.Button.Kind == ButtonPredefines.Plus)
            //    frm_Main.OpenFormByName(nameof(frm_Product));
        }

        #region GridViewStuff

        private void Frm_Invoice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                MoveFocuseToGrid(e.Modifiers == Keys.Shift);
            }
            else if (e.KeyCode == Keys.F6)
            {
                //TODO Go to Product by index 
            }
            else if (e.KeyCode == Keys.F7)
                glkp_ExchangeAccountID.Focus();
            else if (e.KeyCode == Keys.F8)
                txt_Code.Focus();
            else if (e.KeyCode == Keys.F9)
                spn_DiscountValue.Focus();
            else if (e.KeyCode == Keys.F10)
                spn_TaxValue.Focus();
            else if (e.KeyCode == Keys.F11)
                spn_Expences.Focus();
            else if (e.KeyCode == Keys.F12)
                spn_Paid.Focus();

        }

        private void ButtonEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            GridView view = ((GridControl)((ButtonEdit)sender).Parent).MainView as GridView;
            if (view.FocusedRowHandle >= 0)
            {
                view.DeleteSelectedRows();
            }
        }

        private void Frm_Invoice_Activated(object sender, EventArgs e)
        {
            MoveFocuseToGrid();
        }

        private void GridView1_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            if (e.Row == null || (e.Row as DAL.tblPurchaseInvoicesDetaile).ProductID == 0)
            {
                gridView1.DeleteRow(e.RowHandle);
                //e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.Ignore ;
            }
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.Ignore;
        }

        private void GridView1_ValidateRow(object sender, ValidateRowEventArgs e)
        {

            var row = e.Row as DAL.tblPurchaseInvoicesDetaile;
            if (row == null )
            {
                e.Valid = false;

            }
        }

        private void GridControl1_ProcessGridKey(object sender, KeyEventArgs e)
        {
            GridControl control = sender as GridControl;
            if (control == null) return;
            GridView view = control.FocusedView as GridView;
            if (view == null) return;
            if (view.FocusedColumn == null) return;
            if (e.KeyCode == Keys.Return)
            {
                string focusedColumn = view.FocusedColumn.FieldName;
                if (view.FocusedColumn.FieldName == "Code" || view.FocusedColumn.FieldName == "ProductID")
                {
                    GridControl1_ProcessGridKey(sender, new KeyEventArgs(Keys.Tab));
                }
                if (view.FocusedRowHandle < 0)
                {
                    view.AddNewRow();
                    view.FocusedColumn = view.Columns[focusedColumn];
                }
                e.Handled = true;

            }
            else if (e.KeyCode == Keys.Tab)
            {
                view.FocusedColumn = view.VisibleColumns[view.FocusedColumn.VisibleIndex - 1];
                e.Handled = true;

            }
            //GridView focusedView = (sender as GridControl).FocusedView as GridView;
            //if (e.KeyData == Keys.F10  && focusedView.FocusedRowHandle == GridControl.NewItemRowHandle && focusedView.RowCount == 0)
            //{
            //    focusedView.FocusedRowHandle = GridControl.InvalidRowHandle;
            //    e.Handled = true;
            //}




        }

        string enteredCode;
        private void GridView1_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            //if (e.Column.FieldName == "Code")
            //{
            //    if (e.IsSetData)
            //    {
            //        enteredCode = e.Value.ToString();
            //    }
            //    else if (e.IsGetData)
            //    {

                //        e.Value = enteredCode;
                //    }
                //}
             if (e.Column.FieldName == "Index")
                e.Value = gridView1.GetVisibleRowHandle(e.ListSourceRowIndex) + 1;
        }


        private void GridView1_RowUpdated(object sender, RowObjectEventArgs e)
        {
            var items = gridView1.DataSource as Collection<DAL.tblPurchaseInvoicesDetaile>;
            if (items == null)
                spn_Total.EditValue = 0;
            else
                spn_Total.EditValue = items.Sum(x => x.TotalAMount);
        }
        int CurrentRowsCount = 0;
        private void GridView1_RowCountChanged(object sender, EventArgs e)
        {

            if (CurrentRowsCount < gridView1.RowCount)
            {

                var rows = (gridView1.DataSource as Collection<DAL.tblPurchaseInvoicesDetaile>);
                var lastRow = rows.Last();
                var row = rows.FirstOrDefault(x => x.ProductID == lastRow.ProductID && x.UnitID == lastRow.UnitID && x != lastRow);

                if (row != null)
                {
                    row.Quantity += lastRow.Quantity;
                   // gridView1.findr
                    GridView1_CellValueChanged(sender,
                        new CellValueChangedEventArgs(gridView1.FindRowHandelByRowObject(row),
                        gridView1.Columns[nameof(row.Quantity)], row.Quantity));
                    rows.Remove(lastRow);
                }
                var data1 = gridView1.DataSource as BindingList<DAL.tblPurchaseInvoicesDetaile>;
                var data = data1.ToList();
                foreach (var item in data)
                {
                    if (item.ProductID == null || item.ProductID == 0 || item.UnitID == null || item.UnitID == 0)
                    {
                        data1.Remove(item);
                    }
                }
            }

            CurrentRowsCount = gridView1.RowCount;
            GridView1_RowUpdated(sender, null);
        }

        private void GridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

            var row = gridView1.GetRow(e.RowHandle) as DAL.tblPurchaseInvoicesDetaile;
            if (row == null)
                return;
            Session.ProductViewClass itemv = null;
            Session.ProductViewClass.ProductUOMView unitv = null;
            //if (e.Column.FieldName == "Code")
            //{
            //    string ItemCode = e.Value.ToString();
            //    if (Session.GlobalSettings.ReadFormScaleBarcode &&
            //        ItemCode.Length == Session.GlobalSettings.BarcodeLength &&
            //        ItemCode.StartsWith(Session.GlobalSettings.ScaleBarcodePrefix))
            //    {
            //        var itemCodeString = e.Value.ToString()
            //            .Substring(Session.GlobalSettings.ScaleBarcodePrefix.Length,
            //            Session.GlobalSettings.ProductCodeLength);
            //        ItemCode = Convert.ToInt32(itemCodeString).ToString();
            //        string Readvalue = e.Value.ToString().Substring(
            //            Session.GlobalSettings.ScaleBarcodePrefix.Length +
            //            Session.GlobalSettings.ProductCodeLength);
            //        if (Session.GlobalSettings.IgnoreCheckDigit)
            //            Readvalue = Readvalue.Remove(Readvalue.Length - 1, 1);
            //        decimal value = Convert.ToDecimal(Readvalue);
            //        value = value / (decimal)(Math.Pow(10, Session.GlobalSettings.DivideValueBy));
            //        if (Session.GlobalSettings.ReadMode == Session.GlobalSettings.ReadValueMode.Weight)
            //            row.Quantity = value;
            //        else if (Session.GlobalSettings.ReadMode == Session.GlobalSettings.ReadValueMode.Price)
            //        {

            //            itemv = Session.ProductsView.FirstOrDefault(x => x.Units.Select(u => u.Barcode).Contains(ItemCode));
            //            if (itemv != null)
            //            {
            //                unitv = itemv.Units.First(x => x.Barcode == ItemCode);
                         
            //                        row.Quantity =(value / unitv.PriceCost);
                                   
                            
            //            }

            //        }

            //    }
            //    if (itemv == null)
            //        itemv = Session.ProductsView.FirstOrDefault(x => x.Units.Select(u => u.Barcode).Contains(ItemCode));
            //    if (itemv != null)
            //    {
            //        row.ProductID = (int)itemv.ID;
            //        if (unitv == null)
            //            unitv = itemv.Units.First(x => x.Barcode == ItemCode);
            //        row.UnitID = unitv.UnitID;


            //        GridView1_CellValueChanged(sender,
            //            new CellValueChangedEventArgs(
            //                e.RowHandle, gridView1.Columns[nameof(invoicesDetaile.ProductID)], row.ProductID));

            //        GridView1_CellValueChanged(sender,
            //          new CellValueChangedEventArgs(
            //              e.RowHandle, gridView1.Columns[nameof(invoicesDetaile.UnitID)], row.UnitID));

            //        enteredCode = string.Empty;
            //        return;
            //    }
            //    enteredCode = string.Empty;

            //}
            ///////////////
            if (row.ProductID == 0)
            {
                gridView1.DeleteRow(e.RowHandle);
                return;
            }
               
            itemv = Session.ProductsView.Single(x => x.ID == row.ProductID);

            if (row.UnitID == 0)
            {
                row.UnitID = itemv.Units.First().UnitID;
                GridView1_CellValueChanged(sender, new CellValueChangedEventArgs(e.RowHandle, gridView1.Columns[nameof(invoicesDetaile.UnitID)], row.UnitID));
            }
            unitv = itemv.Units.Single(x => x.UnitID == row.UnitID);
            ///////////////
            ///
            if(e.Column.FieldName== nameof(invoicesDetaile.Quantity))
            {
                if (row.Quantity < 1)
                {
                    gridView1.DeleteRow(e.RowHandle);
                    return;
                }
            }
            switch (e.Column.FieldName)
            {
                case nameof(invoicesDetaile.ProductID):
                    if (row.ProductID == 0)
                    {
                        gridView1.DeleteRow(e.RowHandle);
                        return;
                    }
                    //if (row.StoreID == 0 && lkp_Branch.IsEditValueValidAndNotZero())
                    //    row.StoreID = Convert.ToInt32(lkp_Branch.EditValue);
                    break;
                case nameof(invoicesDetaile.UnitID):
                    //if (Type == Master.InvoiceType.Purchase || Type == Master.InvoiceType.PurchaseReturn)
                        row.UnitPrice = unitv.SpecialPrice;
                    if (row.Quantity == 0||row.Quantity==null)
                        row.Quantity = 1;
                    if (row.SubDescount == null) row.SubDescount = 0;
                    if (row.DiscountValue == null) row.DiscountValue = 0;
                    if (row.TotalAMount == null) row.TotalAMount = 0;
                    if (row.UserID == null) row.UserID = 1;

                    GridView1_CellValueChanged(sender, new CellValueChangedEventArgs(e.RowHandle, gridView1.Columns[nameof(invoicesDetaile.UnitPrice)], row.UnitPrice));


                    break;
                case nameof(invoicesDetaile.UnitPrice):
                case nameof(invoicesDetaile.SubDescount):
                case nameof(invoicesDetaile.Quantity):
                    row.DiscountValue = row.SubDescount * (row.Quantity * row.UnitPrice);
                    GridView1_CellValueChanged(sender, new CellValueChangedEventArgs(e.RowHandle, gridView1.Columns[nameof(invoicesDetaile.DiscountValue)], row.DiscountValue));
                    break;
                case nameof(invoicesDetaile.DiscountValue):
                    if (gridView1.FocusedColumn.FieldName == nameof(invoicesDetaile.DiscountValue))
                        row.SubDescount = row.DiscountValue / (row.Quantity * row.UnitPrice);
                    row.TotalAMount = (row.Quantity * row.UnitPrice) - row.DiscountValue;
                  //  row.CostValue = row.TotalAMount / row.Quantity;
                 //   row.TotalCostValue = row.TotalPrice;
                    break;
                default:
                    break;
            }

        }

        private void GridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName == "UnitID")
            {
                RepositoryItemLookUpEdit repo = new RepositoryItemLookUpEdit();
                repo.NullText = "";
                e.RepositoryItem = repo;
                var row = gridView1.GetRow(e.RowHandle) as DAL.tblPurchaseInvoicesDetaile;
                if (row == null)
                    return;
                var db = new DAL.dbDataContext();
                var item = (from u in db.tblUnits
                            where u.ProductID == row.ProductID
                            join un in db.tblLSUnits on u.UnitID equals un.ID
                            select new //ProductViewClass.ProductUOMView
                            {
                                ID = u.ID,
                                Name = un.Name,
                                Factor = (u.packaging as decimal?) ?? 0,
                                PriceCost = (u.PriceCost as decimal?) ?? 0,
                                SpecialPrice = (u.SpecialPrice as decimal?) ?? 0,
                                DescountValue = (u.DescountValue as decimal?) ?? 0,
                                DescountPercent = (u.DescountPercent as decimal?) ?? 0,
                                Status = (u.Status as bool?) ?? false,
                                Barcode = u.Barcod,
                            }).ToList();// db.tblUnits.SingleOrDefault(x => x.ID == row.ProductID);
                    // Session.ProductsView.SingleOrDefault(x => x.ID == row.ProductID);
                if (item == null)
                    return;
                repo.DataSource = item;//.Units;
                repo.ValueMember = "ID";
                repo.DisplayMember = "Name";
                repo.PopulateColumns();
                repo.Columns["Status"].Visible = false;
                repo.Columns["Barcode"].Visible = false;



            }
            else if (e.Column.FieldName == nameof(invoicesDetaile.ProductID))
            {
                e.RepositoryItem = repoItems;
            }
        }
        #endregion


        private void Lkp_Branch_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            var items = gridView1.DataSource as Collection<DAL.tblPurchaseInvoicesDetaile>;
            if (e.OldValue is int && e.NewValue is int)
            {

                foreach (var row in items)
                {

                    //if (row.StoreID == Convert.ToInt32(e.OldValue))
                    //    row.StoreID = Convert.ToInt32(e.NewValue);
                }
            }
        }


        private void Lkp_PartType_EditValueChanged(object sender, EventArgs e)
        {
            //    if (lkp_PartType.IsEditValueOfTypeLong())
            //    {
            //        int partType = Convert.ToInt32(lkp_PartType.EditValue);
            //        if (partType == (int)Master.PartType.Customer)
            //            glkp_PartID.IntializeData(Session.Customers);
            //        else if (partType == (int)Master.PartType.Vendor)
            //            glkp_PartID.IntializeData(Session.Vendors);
            //    }

        }


        #region SpenEditCalculations

        private void Spn_Net_MouseDoubleClick(object sender, EventArgs e)
        {
            spn_Paid.EditValue = spn_Net.EditValue;
        }

        private void Spn_Net_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {

            if (Convert.ToDouble(e.OldValue) == Convert.ToDouble(spn_Paid.EditValue))
                spn_Paid.EditValue = e.NewValue;
        }

        private void Spn_Paid_EditValueChanged(object sender, EventArgs e)
        {
            var net = Convert.ToDouble(spn_Net.EditValue);
            var paid = Convert.ToDouble(spn_Paid.EditValue);
            spn_Remaing.EditValue = net - paid;

        }

        private void Spn_EditValueChanged(object sender, EventArgs e)
        {

            var total = Convert.ToDouble(spn_Total.EditValue);
            var tax = Convert.ToDouble(spn_TaxValue.EditValue);
            var discount = Convert.ToDouble(spn_DiscountValue.EditValue);
            var expences = Convert.ToDouble(spn_Expences.EditValue);

            spn_Net.EditValue = (total + tax - discount + expences);
        }


        private void Spn_TaxValue_EditValueChanged(object sender, EventArgs e)
        {
            var total = Convert.ToDouble(spn_Total.EditValue);
            var val = Convert.ToDouble(spn_TaxValue.EditValue);
            var ratio = Convert.ToDouble(spn_Tax.EditValue);

            if (IsTaxValueFocused)
                spn_Tax.EditValue = (val / total);
            else
                spn_TaxValue.EditValue = total * ratio;
        }

        Boolean IsTaxValueFocused;
        private void Spn_TaxValue_Leave(object sender, EventArgs e)
        {
            IsTaxValueFocused = false;
        }

        private void Spn_TaxValue_Enter(object sender, EventArgs e)
        {
            IsTaxValueFocused = true;

        }

        private void Spn_DiscountValue_EditValueChanged(object sender, EventArgs e)
        {
            var total = Convert.ToDouble(spn_Total.EditValue);
            var discountVal = Convert.ToDouble(spn_DiscountValue.EditValue);
            var discountRation = Convert.ToDouble(spn_DiscountRation.EditValue);

            if (IsDiscountValueFocused)
            {
                spn_DiscountRation.EditValue = (discountVal / total);
            }
            else
            {
                spn_DiscountValue.EditValue = total * discountRation;
            }
        }

        private void Lkp_PartType_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
            {
                //using (var frm = new frm_CustomerVendor(Convert.ToInt32(lkp_PartType.EditValue) == (int)Master.PartType.Customer))
                //{
                //    frm.ShowDialog();
                //    RefreshData();
                //}
            }
        }
        Boolean IsDiscountValueFocused;
        private void spn_DiscountValue_Enter(object sender, EventArgs e)
        {
            IsDiscountValueFocused = true;
        }
        private void Spn_DiscountValue_Leave(object sender, EventArgs e)
        {
            IsDiscountValueFocused = false;
        }
        #endregion


        void MoveFocuseToGrid(bool FocuseToItem = false)
        {
            this.gridControl1.Focus();
            //gridView1.FocusedRowHandle = GridControl.InvalidRowHandle;
            //gridView1.FocusedColumn = gridView1.Columns[nameof(invoicesDetaile.ProductID)]; //gridView1.Columns["Code"];
            //gridView1.AddNewRow();
            //gridView1.UpdateCurrentRow();

        }
        public override void RefreshData()
        {
            lkp_AccountID.IntializeData(Session.Accounts.Where(s=> s.AccountType!= "رئيسي" &&s.FatherNumber== 1211), "AccountName", "ID");
            glkp_ExchangeAccountID.Properties.DataSource =
                from x in Session.Accounts
                where x.AccountType != "رئيسي" && x.FatherNumber != 1211
                select new
                {
                    x.AccountName,
                    x.ID
                };
            glkp_ExchangeAccountID.Properties.DisplayMember = "AccountName";
            glkp_ExchangeAccountID.Properties.ValueMember = "ID";
           
            base.RefreshData();
        }
        
        public override bool IsDataValid()
        {
            int NumberOfErrors = 0;
            if (gridView1.RowCount == 0)
            {
                NumberOfErrors++;
                XtraMessageBox.Show(
                    text: "برجاء ادخال صنف واحد علي الاقل",
                    caption: "",
                    buttons: MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Error);
            }
            NumberOfErrors += txt_Code.IsTextVailde() ? 0 : 1;
            NumberOfErrors += lkp_Type.IsEditValueValid() ? 0 : 1;
            NumberOfErrors += lkp_AccountID.IsEditValueValid() ? 0 : 1;
          // NumberOfErrors += lkp_Branch.IsEditValueValid() ? 0 : 1;
            NumberOfErrors += glkp_ExchangeAccountID.IsEditValueValidAndNotZero() ? 0 : 1;
            NumberOfErrors += dt_TheDate.IsDateVailde() ? 0 : 1;
            if (chk_PostToStore.Checked)
            {
                NumberOfErrors += dt_PostDate.IsDateVailde() ? 0 : 1;
                layoutControlGroup3.Expanded = true;
            }
            if ((lkp_Type.EditValue as long?) == (long)Master.PartType.Ajl && (spn_Remaing.EditValue as decimal?) == 0)
            {
                lkp_Type.EditValue = (long)Master.PartType.Cash;
            }
            if((lkp_AccountID.EditValue as long?) == 0)
            {
                lkp_AccountID.ErrorText = Master.ErrorText;
                NumberOfErrors++;
            }
            return (NumberOfErrors == 0);
        }
        long GetNewIvoicTheNumber()
        {

            long maxTheNaumber=0;
            
            using (var db = new DAL.dbDataContext())
            {
                if(db.tblPurchaseInvoices.Count()!=0)
                maxTheNaumber = db.tblPurchaseInvoices.Select(x => x.TheNumber).Max();
            }

            return ++maxTheNaumber;
        }
        public override void New()
        {
            invoice1 = new DAL.tblPurchaseInvoice()
            {
                TheDate = DateTime.Now,
                TheNumber = GetNewIvoicTheNumber(),
            };
           
            //switch (Type)
            //{
            //    case Master.InvoiceType.PurchaseReturn:
            //    case Master.InvoiceType.Purchase:
            //        Invoice.PartType = (int)Master.PartType.Vendor;
            //        Invoice.PartID = Session.Defualts.Vendor;
            //        Invoice.Branch = Session.Defualts.RawStore;
            //        break;
            //    case Master.InvoiceType.SalesReturn:
            //    case Master.InvoiceType.Sales:
            //        Invoice.PartType = (int)Master.PartType.Customer;
            //        Invoice.PartID = Session.Defualts.Customer;
            //        Invoice.Branch = Session.Defualts.Store;
            //        break;
            //    default:
            //        throw new NotImplementedException();
            //}



            base.New();
            MoveFocuseToGrid();

        }

        public override void GetData()
        {
           // lkp_Branch.EditValue = Invoice.Branch;
            lkp_AccountID.EditValue = invoice1.AccountID;
            lkp_Type.EditValue = invoice1.InvoicesType;
            glkp_ExchangeAccountID.EditValue = invoice1.ExchangeAccountID;
            txt_Code.Text =invoice1.TheNumber.ToString();
            dt_TheDate.DateTime = invoice1.TheDate;
            dt_DelivaryDate.EditValue = invoice1.DelivaryDate;
          //  dt_PostDate.EditValue = Invoice.PostDate;
            memoEme_ShoppingAddress.Text = invoice1.ShippingAddress;
            me_Notes.Text = invoice1.Notes;
            // chk_PostToStore.Checked = Invoice.PostedToStore;
            spn_DiscountRation.EditValue = invoice1.DescountPercent;//.DiscountRation;
            spn_DiscountValue.EditValue = invoice1.DescountValue;//.DiscountValue;
            spn_Expences.EditValue = invoice1.Expences;//.Expences;
           // spn_Net.EditValue = Invoice.Net;
            spn_Paid.EditValue = invoice1.Paid;
            spn_Remaing.EditValue = invoice1.Remaing;
            spn_Tax.EditValue = invoice1.Tax;
            spn_TaxValue.EditValue = invoice1.TaxValue;
            spn_Total.EditValue = invoice1.Total;
            generalDB = new DAL.dbDataContext();
            gridControl1.DataSource = generalDB.tblPurchaseInvoicesDetailes.Where(x => x.ParentID == invoice1.ID);

            base.GetData();
        }
        public override void SetData()
        {
           // Invoice.Branch = Convert.ToInt32(lkp_Branch.EditValue);
            invoice1.AccountID = Convert.ToInt64(lkp_AccountID.EditValue);
            invoice1.InvoicesType = Convert.ToByte(lkp_Type.EditValue);
            invoice1.ExchangeAccountID = Convert.ToInt32(glkp_ExchangeAccountID.EditValue);
            invoice1.TheNumber = Convert.ToInt32(txt_Code.Text);
            invoice1.TheDate = dt_TheDate.DateTime;
            invoice1.DelivaryDate = dt_DelivaryDate.EditValue as DateTime?;
         //   Invoice.PostDate = dt_PostDate.EditValue as DateTime?;
            invoice1.ShippingAddress = memoEme_ShoppingAddress.Text;
            invoice1.Notes = me_Notes.Text;
           // Invoice.PostedToStore = chk_PostToStore.Checked;
            invoice1.DescountPercent = Convert.ToDecimal(spn_DiscountRation.EditValue);
            invoice1.DescountValue = Convert.ToDecimal(spn_DiscountValue.EditValue);
            invoice1.Expences = Convert.ToDecimal(spn_Expences.EditValue);
          //  Invoice.Net = Convert.ToDouble(spn_Net.EditValue);
            invoice1.Paid = Convert.ToDecimal(spn_Paid.EditValue);
            invoice1.Remaing = Convert.ToDecimal(spn_Remaing.EditValue);
            invoice1.Tax = Convert.ToDecimal(spn_Tax.EditValue);
            invoice1.TaxValue = Convert.ToDecimal(spn_TaxValue.EditValue);
            invoice1.Total = Convert.ToDecimal(spn_Total.EditValue);
            invoice1.UserID = Session.User.ID;
            invoice1.EnterTime = DateTime.Now;
            invoice1.Prints = 0;
           /// Invoice.InvoiceType = (byte)Type;
            base.SetData();
        }
        public override void Save()
        {
            DAL.dbDataContext db = new DAL.dbDataContext();
            //  int x = 0;
            SetData();
            
            if (invoice1.ID == 0)
                invoice1.ID = db.AddtblPurchaseInvoices(invoice1.TheNumber,invoice1.InvoicesType,invoice1.Total,invoice1.DescountPercent,invoice1.DescountValue,invoice1.Tax,invoice1.TaxValue,invoice1.Paid,invoice1.Remaing,invoice1.Expences,invoice1.AccountID,invoice1.ExchangeAccountID,invoice1.TheDate,invoice1.DelivaryDate,invoice1.Notes,invoice1.ShippingAddress,invoice1.Prints,invoice1.UserID,6);

            else
            {
                // receiving.e
                //db.UPDATEReceiving(receiving.TheDate, receiving.Amount, receiving.CurrencyID, receiving.AccountID, receiving.ExchangeAccountID, receiving.Notes, receiving.Delivery, receiving.EntryID, receiving.PrevRowVersion, receiving.ID);
            }
            if (invoice1.ID > 0)
            {


                var data = gridView1.DataSource as BindingList<DAL.tblPurchaseInvoicesDetaile>;
                foreach (var item in data)
                {
                    
                        item.ParentID = invoice1.ID;
                  //  item.ProductID = invoice1.ID;

                    item.UserID = Session.User.ID;
                    item.EnterTime = DateTime.Now;
                   
                }
                generalDB.SubmitChanges();
            }
            base.Save();
        }
     
        private void Args_Showing(object sender, XtraMessageShowingArgs e)
        {

            e.Form.ControlBox = false;
            e.Form.Height = 150;
            e.Buttons[DialogResult.OK].Text = "متابعه وحفظ";
        }
        public override void Print()
        {
            using (var db = new DAL.dbDataContext())
            {
                var invoice = (from inv in db.tblPurchaseInvoices
                              // join str in db.Stores on inv.Branch equals str.ID
                               from prt in Session.Accounts.Where(x => x.ID == inv.ExchangeAccountID).DefaultIfEmpty()
                               from drw in Session.Accounts .Where(x => x.ID == inv.AccountID).DefaultIfEmpty()
                               where inv.ID == invoice1.ID
                               select new
                               {
                                   inv.ID,
                                   inv.TheNumber,
                                //   Store = str.Name,
                                  Drawer = drw.AccountName,
                                   PartName = prt.AccountName,
                                 //  Phone = prt.Phone,
                                   inv.TheDate,
                                   inv.DescountValue,
                                   inv.Expences,
                                   InvoiceType = "فاتوره مشتريات ",
                                   //(inv.InvoiceType == (byte)Master.InvoiceType.Purchase) ? "فاتوره مشتريات " :
                                   //(inv.InvoiceType == (byte)Master.InvoiceType.Sales) ? "فاتوره مبيعات " :
                                   //(inv.InvoiceType == (byte)Master.InvoiceType.SalesReturn) ? "فاتوره مردود مبيعات " :
                                   //(inv.InvoiceType == (byte)Master.InvoiceType.PurchaseReturn) ? "فاتوره مردود مشتريات " : "UnDefined",
                                   Net= (inv.Total + inv.TaxValue -inv.DescountValue  + inv.Expences) ,
                                   inv.Notes,
                                   inv.Paid,
                                   PartType = "مورد",
                                   //(inv.PartType == (byte)Master.PartType.Customer) ? "عميل" :
                                   //(inv.PartType == (byte)Master.PartType.Vendor) ? "مورد" : "UnDefined",
                                   inv.Remaing,
                                   inv.TaxValue,
                                   inv.Total,
                                   ProductCount = db.tblPurchaseInvoicesDetailes.Where(x => x.ParentID == inv.ID).Count(),
                                   Products = (
                                  from d in db.tblPurchaseInvoicesDetailes.Where(x => x.ParentID == inv.ID)
                                  from p in db.tblProducts.Where(x => x.ID == d.ProductID)
                                  from u in db.tblLSUnits.Where(x => x.ID == d.UnitID).DefaultIfEmpty()
                                  select new
                                  {
                                      ProductName = p.ProductName,
                                      UnitName = u.Name,
                                      d.Quantity,
                                      d.UnitPrice,
                                      d.TotalAMount,
                                  }).ToList()
                               }).ToList();

              //  Reporting.rpt_Invoice.Print(invoice);
            }
            base.Print();
        }

        private void lkp_Type_Properties_EditValueChanged(object sender, EventArgs e)
        {
            if (lkp_Type.EditValue == null)
            {
                lkp_Type.EditValue = Master.PartType.Cash;
                spn_Paid.Properties.ReadOnly = true;

            }
            if ((lkp_Type.EditValue as long?) ==(long)Master.PartType.Cash)
            {
                spn_Paid.Properties.ReadOnly = true;
            }
            else if ((lkp_Type.EditValue as long?) == (long)Master.PartType.Ajl)
                spn_Paid.Properties.ReadOnly = false;
        }
    }
}
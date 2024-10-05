using Altagr.Class;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Altagr.Class.Master;

namespace Altagr.WinForms
{
    public partial class frmProduct : frmMaster
    {
        DAL.tblProducts product;
        RepositoryItemLookUpEdit repoUOM = new RepositoryItemLookUpEdit();
        DAL.tblUnit unit;
        DAL.dbDataContext sdb = new DAL.dbDataContext();
        public frmProduct()
        {
            InitializeComponent();
            RefreshData();
            New();
        }
        public frmProduct(long id)
        {
            InitializeComponent();
            RefreshData();
            LoadProduct(id);
        }
        void LoadProduct(long id)
        {
            using (var db = new DAL.dbDataContext())
            {
                product = db.tblProducts.Single(x => x.ID == id);

            }
            this.Text = string.Format("بيانات صنف : {0}", product.ProductName);
            GetData();
        }
        public override void Save()
        {
            gridView1.UpdateCurrentRow();
          

            var db = new DAL.dbDataContext();
            if (product.ID == 0)
                db.tblProducts.InsertOnSubmit(product);
            else
            {
                try
                {
                    // db.tblAccounts.

                    db.tblProducts.Attach(product);
                }
                catch
                {
                    product = db.tblProducts.FirstOrDefault(e1 => e1.ID == product.ID);
                }
            }

            SetData();
            db.SubmitChanges();
            var data = gridView1.DataSource as BindingList<DAL.tblUnit>;
            foreach (var item in data)
            {
                item.ProductID = product.ID;
                if (string.IsNullOrEmpty(item.Barcod))
                    item.Barcod = "";
                item.UserID = Session.User.ID;
                item.EnterTime = DateTime.Now;
            }
            sdb.SubmitChanges();
            base.Save();
            txtID.Text = product.ID.ToString();
            this.Text = string.Format("بيانات صنف : {0}", product.ProductName);
        }
        public override void New()
        {
            product = new DAL.tblProducts();
            base.New();
            var db = new DAL.dbDataContext();
            var data = gridView1.DataSource as BindingList<DAL.tblUnit>;

            if (db.tblLSUnits.Count() == 0)
            {
                db.tblLSUnits.InsertOnSubmit(new DAL.tblLSUnit() { Name = "حبه" });
                db.SubmitChanges();
                RefreshData();
            }
            data.Add(new DAL.tblUnit() { packaging = 1, UnitID = db.tblLSUnits.First().ID,Status =true,PartingPrice =0,PriceCost=0,AltogetherPrice=0,SpecialPrice=0 ,Barcod = GetNewBarcode(),DescountPercent=0,DescountValue=0 });
        }
        public override void Delete()
        {
            using(var db =new DAL.dbDataContext())
            {
                if(db.tblPurchaseInvoicesDetailes.Where(x=>x.ProductID==product.ID).Count()==0)
                    if(db.tblSalesInvoicesDetailes.Where(x => x.ProductID == product.ID).Count() == 0)
                    {
                        db.tblUnits.DeleteAllOnSubmit(db.tblUnits.Where(x => x.ProductID == product.ID));
                        db.tblProducts.DeleteOnSubmit(db.tblProducts.Single(x => x.ID == product.ID));
                        db.SubmitChanges();
                         base.Delete();
                        return;
                    }
                XtraMessageBox.Show("لا يمكن حذف هذا الصنف بسبب ارتباطة بفواتير ولاكن يمكنك ايقافة");
            }
          
        }
        string GetNewBarcode()
        {
            string maxCode;
            using (var db = new DAL.dbDataContext())
            {
                maxCode = db.tblUnits.Select(x => x.Barcod).Max();
            }

            return GetNextNumberInString(maxCode);
        }
        public static string GetNextNumberInString(string Number)
        {
            if (Number == string.Empty || Number == null)
                return "1";
            string str1 = "";
            foreach (Char c in Number)
                str1 = char.IsDigit(c) ? str1 + c.ToString() : "";
            if (str1 == string.Empty)
                return Number + "1";
            string str2 = str1.Insert(0, "1");
            str2 = (Convert.ToInt64(str2) + 1).ToString();
            string str3 = str2[0] == '1' ? str2.Remove(0, 1) : str2.Remove(0, 1).Insert(0, "1");
            int indx = Number.LastIndexOf(str1);
            Number = Number.Remove(indx);
            Number = Number.Insert(indx, str3);
            return Number;

        }
        public override void GetData()
        {
            txtID.Text = product.ID.ToString();
            txtEnglishName.Text = product.EnglishProductName;
            txtName.Text = product.ProductName;
            txtNotes.Text = product.Notes;
            txtDesc.Text = product.ProductDesc;
            cmbType.EditValue = product.Type;
            cmbcategory.EditValue = product.categoryID;
            checkEdit1.Checked = (product.Status as bool?)??false;
            if (product.ProductImages != null)
                pictureEdit1.Image = GetImageFromByteArray(product.ProductImages.ToArray());
            else
                pictureEdit1.Image = null;
            gridControl1.DataSource = sdb.tblUnits.Where(x => x.ProductID == product.ID);
            base.GetData();
        }
        public override void SetData()
        {
            product.categoryID = Convert.ToInt32(cmbcategory.EditValue);
            product.ID =Convert.ToInt64( txtID.Text);
            product.ProductName = txtName.Text;
            product.Type = Convert.ToByte(cmbType.EditValue);
            product.Status = checkEdit1.Checked;
            product.Notes = txtNotes.Text;
            product.ProductDesc = txtDesc.Text;
            product.EnglishProductName = txtEnglishName.Text;
            product.UserID = Session.User.ID;
            product.EnterTime = DateTime.Now;
            if(pictureEdit1.Image!=null)
            product.ProductImages = GetByteFromImage(pictureEdit1.Image);
            base.SetData();
        }
        public override bool IsDataValid()
        {
            int NumberOfErrors = 0;
            
            NumberOfErrors += cmbcategory.IsEditValueValidAndNotZero() ? 0 : 1;
            NumberOfErrors += cmbType.IsEditValueValid() ? 0 : 1;
            NumberOfErrors += txtName.IsTextVailde() ? 0 : 1;
           
            var db = new DAL.dbDataContext();
            if (db.tblProducts.Where(x => x.ID != product.ID && x.ProductName.Trim() == txtName.Text.Trim()).Count() > 0)
            {
                txtName.ErrorText = "هذا الاسم مسجل بالفعل";
                return false;
            }
           
            return (NumberOfErrors == 0);
        }
        public override void RefreshData()
        {
            using (var db = new DAL.dbDataContext())
            {
                var data = db.tblLSTypeProducts
                    .Where(x => db.tblLSTypeProducts.Where(w => w.ParentID == x.ID).Count() == 0).ToList();
                  repoUOM.DataSource = db.tblLSUnits.ToList();
                cmbcategory.IntializeData(data);
            }
            base.RefreshData();
        }
        Byte[] GetByteFromImage(Image image)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                try
                {
                    image.Save(stream, ImageFormat.Jpeg);
                    return stream.ToArray();
                }
                catch
                {
                    return stream.ToArray();
                }

            }
        }
        Image GetImageFromByteArray(Byte[] ByteArray)
        {
            Image img;
            try
            {
                Byte[] imgbyte = ByteArray;
                MemoryStream stream = new MemoryStream(imgbyte, false);
                img = Image.FromStream(stream);
            }
            catch { img = null; }
            return img;
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
           // RefreshData();
           
            cmbcategory.ProcessNewValue += Lkp_Category_ProcessNewValue;
            cmbcategory.Properties.TextEditStyle =TextEditStyles.Standard;

            cmbType.IntializeData(ProductTypesList);
           

            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;

            gridView1.Columns[nameof(unit.ID)].Visible = false;
            gridView1.Columns[nameof(unit.ProductID)].Visible = false;
            gridView1.Columns[nameof(unit.MaxUnitID)].Visible = false;
            gridView1.Columns[nameof(unit.UserID)].Visible = false;
            gridView1.Columns[nameof(unit.EnterTime)].Visible = false;
            gridView1.Columns[nameof(unit.tblLSUnit)].Visible = false;
            gridView1.Columns[nameof(unit.tblProducts)].Visible = false;
            RepositoryItemCalcEdit calcEdit = new RepositoryItemCalcEdit();

            gridControl1.RepositoryItems.Add(calcEdit);
            gridControl1.RepositoryItems.Add(repoUOM);

            gridView1.Columns[nameof(unit.SpecialPrice)].ColumnEdit = calcEdit;
            gridView1.Columns[nameof(unit.AltogetherPrice)].ColumnEdit = calcEdit;
            gridView1.Columns[nameof(unit.PriceCost)].ColumnEdit = calcEdit;
            gridView1.Columns[nameof(unit.PartingPrice)].ColumnEdit = calcEdit;
            gridView1.Columns[nameof(unit.DescountValue)].ColumnEdit = calcEdit;
            gridView1.Columns[nameof(unit.DescountPercent)].ColumnEdit = calcEdit;

            gridView1.Columns[nameof(unit.packaging)].ColumnEdit = calcEdit;
            gridView1.Columns[nameof(unit.UnitID)].ColumnEdit = repoUOM;

            gridView1.Columns[nameof(unit.Barcod)].Caption = "الباركود";
            gridView1.Columns[nameof(unit.packaging)].Caption = "معامل التحويل";
            gridView1.Columns[nameof(unit.PriceCost)].Caption = "سعر التكلفة ";
            gridView1.Columns[nameof(unit.AltogetherPrice)].Caption = "سعر جملة";
            gridView1.Columns[nameof(unit.PartingPrice)].Caption = "فراق الأسعار";
            gridView1.Columns[nameof(unit.SpecialPrice)].Caption = "سعر تجزئة ";
            gridView1.Columns[nameof(unit.DescountValue)].Caption = "قيمة الخصم ";
            gridView1.Columns[nameof(unit.DescountPercent)].Caption = "نسبة الخصم";
            gridView1.Columns[nameof(unit.UnitID)].Caption = "اسم الوحده";
            gridView1.Columns[nameof(unit.Status)].Caption = "حالة الصنف ";

            repoUOM.ValueMember = "ID";
            repoUOM.DisplayMember = "Name";
            repoUOM.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;

            repoUOM.ProcessNewValue += RepoUOM_ProcessNewValue;

            gridView1.ValidateRow += GridView1_ValidateRow;
            gridView1.InvalidRowException += GridView1_InvalidRowException;
            gridView1.FocusedRowChanged += GridView1_FocusedRowChanged;
            gridView1.CustomRowCellEditForEditing += GridView1_CustomRowCellEditForEditing;
        }

        private void GridView1_CustomRowCellEditForEditing(object sender, CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName == nameof(unit.UnitID))
            {
                try
                {
                    var ids = ((Collection<DAL.tblUnit>)gridView1.DataSource).Select(x => x.UnitID).ToList();
                    RepositoryItemLookUpEdit repo = new RepositoryItemLookUpEdit();
                    using (var db = new DAL.dbDataContext())
                    {
                        var currentID = (long?)e.CellValue;
                        ids.Remove(currentID ?? 0);
                        repo.DataSource = db.tblLSUnits.Where(x => ids.Contains(x.ID) == false).ToList();
                        repo.ValueMember = "ID";
                        repo.DisplayMember = "Name";
                        repo.PopulateColumns();
                        repo.Columns["ID"].Visible = false;
                        repo.TextEditStyle = TextEditStyles.Standard;
                        repo.ProcessNewValue += RepoUOM_ProcessNewValue;
                        e.RepositoryItem = repo;
                    }
                }
                catch { }
                // select * from xxx where id not  in(5,65,6.56)
                //EBS.Classes.modMain formProviders;
                //EBS.Accounts.frmReceiving ibsFormProviders;
                //  EBS.mod1 ibsForms;
                ////  EBS.Accounts.Settings
                //EBS.Security.frmUsers h;
                //EBS.Controls.ibsDataGridViewPlus d;
                //EBS.frmlng_Dictionary dictionary;
                //EBS.Classes.IBSLanguage.Lang lang;
                //EBS.frmSplashScreen frmSplash;
                //EBS.frmFindInGrid
              //  //  EBS.Controls.ibsDataGridView
              //  //  EBS.Classes.Forms j;
              //  //  EBS.Classes.Connections connections;
              //  //  EBS.Classes.ibsFormProvider
              //  //   ClsServiceInfo;
              //  EBS.LSettings.Licensing
            }
        }

        private void GridView1_FocusedRowChanged(object sender,FocusedRowChangedEventArgs e)
        {

            gridView1.Columns[nameof(unit.packaging)].OptionsColumn.AllowEdit = !(e.FocusedRowHandle == 0);

        }
        private void GridView1_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode =ExceptionMode.NoAction;
        }

        private void GridView1_ValidateRow(object sender,ValidateRowEventArgs e)
        {
            var row = e.Row as DAL.tblUnit;
            UnitNoNull(ref row);
            var view = sender as GridView;
            if (row == null)
                return;
            if (row.packaging <= 1 && e.RowHandle != 0)
            {
                e.Valid = false;
                view.SetColumnError(view.Columns[nameof(row.packaging)], "يجب ان تكون القيمه اكبر من 1 ");
            }
            if (row.UnitID <= 0)
            {
                e.Valid = false;
                view.SetColumnError(view.Columns[nameof(row.UnitID)], ErrorText);
            }
            if (CheckIfBarcodeExist(row.Barcod, prdID: product.ID))
            {
                e.Valid = false;
                view.SetColumnError(view.Columns[nameof(row.Barcod)], " هذا الكود موجود بالفعل ");
            }
            

        }
        void UnitNoNull(ref DAL.tblUnit row) 
        {
            row.packaging = row.packaging == null ? 1 : row.packaging;
            row.PartingPrice = (row.PartingPrice as decimal?) ?? 0;
            row.PriceCost = (row.PriceCost as decimal?) ?? 0;
            row.AltogetherPrice = (row.AltogetherPrice as decimal?) ?? 0;
            row.SpecialPrice = (row.SpecialPrice as decimal?) ?? 0;
            row.Status = (row.Status as bool?) ?? true;
            row.UnitID = (row.UnitID as long?) ?? 0;
        }
        Boolean CheckIfBarcodeExist(string barcode, long prdID)
        {
            using (var db = new DAL.dbDataContext())
                return db.tblUnits.Where(x => x.Barcod == barcode && x.ProductID != prdID).Count() > 0;

        }
        private void RepoUOM_ProcessNewValue(object sender, ProcessNewValueEventArgs e)
        {
            if (e.DisplayValue is string value && value.Trim() != string.Empty)
            {
                var NewObject = new DAL.tblLSUnit() { Name = value.Trim() };
                using (DAL.dbDataContext db = new DAL.dbDataContext())
                {
                    db.tblLSUnits.InsertOnSubmit(NewObject);
                    db.SubmitChanges();
                }
                 ((List<DAL.tblLSUnit>)repoUOM.DataSource).Add(NewObject);
                ((List<DAL.tblLSUnit>)(((LookUpEdit)sender).Properties.DataSource)).Add(NewObject);
                e.Handled = true;

            }
        }

        private void Lkp_Category_ProcessNewValue(object sender, ProcessNewValueEventArgs e)
        {
            if (e.DisplayValue is string st && st.Trim() != string.Empty)
            {
                var newObject = new DAL.tblLSTypeProduct() { Name = st, ParentID = 0};
                using (var db = new DAL.dbDataContext())
                {
                    db.tblLSTypeProducts.InsertOnSubmit(newObject);
                    db.SubmitChanges();
                }
                ((List<DAL.tblLSTypeProduct>)cmbcategory.Properties.DataSource).Add(newObject);
                e.Handled = true;

            }
        }
    }
}
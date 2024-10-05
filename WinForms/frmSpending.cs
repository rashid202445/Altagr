using Altagr.Class;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Altagr.WinForms
{
    public partial class frmSpending : frmMaster
    {
        DAL.tblSpending spending;
        DAL.tblAccounts account;
        DAL.tblCurrency currency;
        public frmSpending()
        {
            InitializeComponent();
    
            New();
            TheDate.EditValue = DateTime.Now;
        }
        public override void Save()
        {
           // if (!IsDataValid()) return;
            DAL.dbDataContext db = new DAL.dbDataContext();
            //  int x = 0;
            SetData();
            if (spending.ID == 0)
                spending.ID = db.AddtblSpending(spending.TheDate, 1, spending.Amount, spending.CurrencyID, spending.AccountID, spending.ExchangeAccountID, spending.Notes, spending.Delivery, Session.User.ID, 4);
            else
            {
                // receiving.e
                 db.UPDATESpending(spending.TheDate,  spending.Amount, spending.CurrencyID, spending.AccountID, spending.ExchangeAccountID, spending.Notes, spending.Delivery,spending.EntryID,spending.PrevRowVersion,spending.ID);
            }
            txtID.Text = spending.ID.ToString();
            if (spending.ID > 0) base.Save();
            //var db = new DAL.dbDataContext();
            //if (receiving.ID == 0)
            //    db.tblReceivings.InsertOnSubmit(receiving);
            //else
            //{
            //    try
            //    {
            //        // db.tblAccounts.

            //        db.tblReceivings.Attach(receiving);
            //    }
            //    catch
            //    {
            //        receiving = db.tblReceivings.FirstOrDefault(e1 => e1.ID == receiving.ID);
            //    }
            //}


            //db.SubmitChanges();
            // base.Save();
        }
        public override void GetData()
        {
            txtID.Text = spending.ID.ToString();
            cmbExchangeAccountName.EditValue = spending.ExchangeAccountID;
            cmbAccountName.EditValue = spending.AccountID;
            cmbCurrencyName.EditValue = spending.CurrencyID;
            txtAmount.EditValue = spending.Amount;
            txtDelivery.EditValue = spending.Delivery;
            TheDate.EditValue = spending.TheDate;
            base.GetData();
        }
        public override bool IsDataValid()
        {
            if (txtAccountID.Text.Trim() == txtExchangeAccountID.Text.Trim())
            {
                cmbExchangeAccountName.ErrorText = " يجب ان لا يكون المدين والدائن نفس الحساب";
                cmbExchangeAccountName.Focus();
                return false;
            }
            if (txtAmount.Text.Trim() == string.Empty)
            {
                txtAmount.ErrorText = "يرجاء ادخال المبلغ ";
                txtAmount.Focus();
                return false;
            }
            if (txtAccountID.Text.Trim() == string.Empty)
            {
                cmbAccountName.ErrorText = "يرجاء ادخال الصندوق";
                cmbAccountName.Focus();
                return false;
            }
            if (txtExchangeAccountID.Text.Trim() == string.Empty)
            {
                cmbExchangeAccountName.ErrorText = "يرجاء ادخال الدائن";
                cmbExchangeAccountName.Focus();
                return false;
            }
            if (txtAmount.Text.Trim() == "0")
            {
                txtAmount.ErrorText = "يرجاء ادخال المبلغ";
                txtAmount.Focus();
                return false;
            }
            if (!((long)cmbCurrencyName.EditValue > 0))
            {
                cmbCurrencyName.ErrorText = "يرجاء ادخال العملة";
                cmbCurrencyName.Focus();
                return false;
            }

            return base.IsDataValid();
        }
        public override void New()
        {
            spending = new DAL.tblSpending();
            base.New();
        }
        public override void SetData()
        {

            spending.AccountID = (long)cmbAccountName.EditValue;
            spending.Amount = (decimal)txtAmount.EditValue;
            spending.CurrencyID = (long)cmbCurrencyName.EditValue;
            spending.ExchangeAccountID = (long)cmbExchangeAccountName.EditValue;
            spending.Delivery = txtDelivery.Text.Trim();
            spending.Notes = txtNotes.Text.Trim();
            spending.TheDate = (DateTime?)TheDate.EditValue;
            base.SetData();
        }
        public override void Delete()
        {
            if(XtraMessageBox.Show("هل متاكد من حذف هذا السند","", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                using(var db=new DAL.dbDataContext())
                {
                   
                        spending = db.tblSpendings.FirstOrDefault(e1 => e1.ID == spending.ID);
                 //   DAL.tblEntry tblEntry = db.tblEntries.Single(s => s.ID == spending.EntryID);
                    
                  //  var dd = db.ExecuteQuery<long>("Delete From tblSpending  Where ID=" + spending.ID).ToArray();
                    // db.t
                  //  db.tblEntries.DeleteOnSubmit(tblEntry);
                    db.tblSpendings.DeleteOnSubmit(spending);
                   
                    db.SubmitChanges();
                    //if (dd[0] == 0) return;
                    //else
                        base.Delete();

                }
            }
           
        }
        public override void RefreshData()
        {
            TablaProductos.DataSource = new DAL.dbDataContext().vewSpendings;
            base.RefreshData();
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void frmReceiving_Load(object sender, EventArgs e)
        {
            var db = new DAL.dbDataContext();

            cmbAccountName.IntializeData(Session.Accounts.Where(s => s.AccountType != "رئيسي"), nameof(account.AccountName), nameof(account.ID));
            cmbExchangeAccountName.IntializeData(Session.Accounts.Where(s => s.AccountType != "رئيسي"), nameof(account.AccountName), nameof(account.ID));
           
            cmbExchangeAccountName.Properties.TextEditStyle = TextEditStyles.Standard;

           
            cmbAccountName.Properties.TextEditStyle = TextEditStyles.Standard;


            cmbCurrencyName.Properties.DataSource = db.tblCurrencies;
            cmbCurrencyName.Properties.DisplayMember = nameof(currency.CurrencyName);// "اسم_الحساب";
            cmbCurrencyName.Properties.ValueMember = nameof(currency.ID);//"رقم_الحساب";
            cmbCurrencyName.Properties.TextEditStyle = TextEditStyles.Standard;

            RefreshData();
        }

        private void cmbExchangeAccountName_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtExchangeAccountID.EditValue = new DAL.dbDataContext().tblAccounts.Single(s => s.ID == Convert.ToInt64(cmbExchangeAccountName.EditValue)).AccountNumber.ToString();
            }
            catch
            {
                txtExchangeAccountID.EditValue = "";
            }
        }

        private void cmbAccountName_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtAccountID.EditValue = new DAL.dbDataContext().tblAccounts.Single(s => s.ID == Convert.ToInt64(cmbAccountName.EditValue)).AccountNumber.ToString();
            }
            catch
            {
                txtAccountID.EditValue = "";
            }
        }

       

        private void TablaProductos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                long id = 0;
                if (long.TryParse(TablaProductos.Rows[e.RowIndex].Cells[0].Value.ToString(), out id) && id > 0)
                {
                    using (var db=new DAL.dbDataContext())
                    {
                        spending = db.tblSpendings.Single(s => s.ID == id);
                       var dd= db.ExecuteQuery<long>("Select Cast([RowVersion] as Bigint) from tblSpending Where ID="+id ).ToArray();
                        spending.PrevRowVersion = dd[0];
                        //Convert.ToInt64(spending.RowVersion.ToArray());
                        GetData();
                    }
                }
            }
            catch
            {

            }
        }
      
    }
}
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
using Altagr.Class;
using System.Windows.Forms;

namespace Altagr.WinForms
{
    public partial class frmReceiving : frmMaster
    {
        DAL.tblReceiving receiving;
        DAL.tblAccounts account;
        DAL.tblCurrency currency;
        DAL.tblEntry entry=new DAL.tblEntry();
      //  DAL.tblEntriesDetail entriesDetail= new DAL.tblEntriesDetail();
        public frmReceiving()
        {
            InitializeComponent();
           
            New();
            TheDate.EditValue = DateTime.Now;
        }
        public override void Save()
        {
          
            using (var db = new DAL.dbDataContext())
            {
                if (receiving.ID == 0)
                {
                    db.tblReceivings.InsertOnSubmit(receiving);

                    receiving.TheNumber = GetNewIvoicTheNumber(nameof(receiving));
                    SetData();
                    db.SubmitChanges();
                }
                else
                {
                    try
                    {
                        // db.tblAccounts.

                        db.tblReceivings.Attach(receiving);
                    }
                    catch
                    {
                        receiving = db.tblReceivings.FirstOrDefault(e1 => e1.ID == receiving.ID);
                    }
                    SetData();
                }

               
               // db.tblEntries.DeleteAllOnSubmit(db.tblEntries.Where(x => x.DocumentID == 5 && x.RecordID == receiving.ID));

               

                if (!(receiving.EntryID is long))
                {
                    entry = new DAL.tblEntry();
                    db.tblEntries.InsertOnSubmit(entry) ;
                   entry.RecordID = receiving.ID;
                    entry.RecordNumber = receiving.TheNumber;
                   
                    entry.DocumentID = 5;
                    entry.TheDate = (DateTime)receiving.TheDate;
                    entry.Notes = receiving.Notes;
                    entry.UserID = Session.User.ID;
                    entry.EntryNumber = GetNewIvoicTheNumber(nameof(entry));
                
                    

                }
                else
                {
                    entry = db.tblEntries.FirstOrDefault(x => x.ID == receiving.EntryID);
                }
               
                db.tblEntriesDetails.DeleteAllOnSubmit(db.tblEntriesDetails.Where(x => x.ParentID == entry.ID));
                receiving.PrevRowVersion = db.ExecuteQuery<long>("Select Cast([RowVersion] as Bigint) from tblReceiving Where ID=" + receiving.ID).ToArray()[0];
                db.SubmitChanges();
                db.tblEntriesDetails.InsertOnSubmit(new DAL.tblEntriesDetail()
                {
                    ParentID = entry.ID,
                    Amount = (-1 * receiving.Amount),
                    CurrencyID = receiving.CurrencyID,
                    MCAmount = (-1 * (receiving.Amount * db.ExchangePrice(receiving.CurrencyID))),
                    AccountID = receiving.AccountID,
                    Notes = "من حساب  " + Session.Accounts.Single(x => x.ID == receiving.ExchangeAccountID)

                });
                db.tblEntriesDetails.InsertOnSubmit(new DAL.tblEntriesDetail()
                {
                    ParentID = entry.ID,
                    Amount = (1 * receiving.Amount),
                    CurrencyID = receiving.CurrencyID,
                    MCAmount = (1 * (receiving.Amount * db.ExchangePrice(receiving.CurrencyID))),
                    AccountID = receiving.ExchangeAccountID,
                    Notes = receiving.Notes

                }) ;
                receiving.PrevRowVersion = db.ExecuteQuery<long>("Select Cast([RowVersion] as Bigint) from tblReceiving Where ID=" + receiving.ID).ToArray()[0];
                receiving.EntryID = entry.ID;
                db.SubmitChanges();
            }
            // if (!IsDataValid()) return;
        //    DAL.dbDataContext db = new DAL.dbDataContext();
          //  int x = 0;
         //   SetData();
         //   if(receiving.ID==0)
         //   {

         //   }
         ////   receiving.ID = db.AddReceiving(receiving.TheDate, 1, receiving.Amount,receiving.CurrencyID, receiving.AccountID,receiving.ExchangeAccountID, receiving.Notes, receiving.Delivery, Session.User.ID, 5);
           
         //   else
         //   {
         //       // receiving.e
         //       db.UPDATEReceiving(receiving.TheDate, receiving.Amount, receiving.CurrencyID, receiving.AccountID, receiving.ExchangeAccountID, receiving.Notes, receiving.Delivery, receiving.EntryID, receiving.PrevRowVersion, receiving.ID);
         //   }
            txtID.Text = receiving.TheNumber.ToString();
            if (receiving.ID > 0) base.Save();
            
        }
        public override void SetData()
        {

            receiving.AccountID = (long)cmbAccountName.EditValue;
            receiving.Amount = (decimal)txtAmount.EditValue;
            receiving.CurrencyID = (long)cmbCurrencyName.EditValue;
            receiving.ExchangeAccountID = (long)cmbExchangeAccountName.EditValue;
            receiving.Delivery = txtDelivery.Text.Trim();
            receiving.Notes = txtNotes.Text.Trim();
            receiving.TheDate = (DateTime?)TheDate.EditValue;
            receiving.EnterTime = DateTime.Now;
            receiving.TheMethod = 1;
            receiving.ExchangeAmount = receiving.Amount;
            receiving.ExchangeCurrencyID = receiving.CurrencyID;
            receiving.UserID = Session.User.ID;
            receiving.Prints = 0;
          //  entriesDetail = new DAL.tblEntriesDetail();
           // + "  مناولة بيد   " + receiving.Delivery;


            base.SetData();
        }
        public override void GetData()
        {
            txtID.Text = receiving.ID.ToString();
            cmbExchangeAccountName.EditValue = receiving.ExchangeAccountID;
            cmbAccountName.EditValue = receiving.AccountID;
            cmbCurrencyName.EditValue = receiving.CurrencyID;
            txtAmount.EditValue = receiving.Amount;
            txtDelivery.EditValue = receiving.Delivery;
            TheDate.EditValue = receiving.TheDate;
            txtNotes.Text = receiving.Notes;
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
            if( !((long)cmbCurrencyName.EditValue>0))
            {
                cmbCurrencyName.ErrorText = "يرجاء ادخال العملة";
                cmbCurrencyName.Focus();
                return false;
            }

            return base.IsDataValid();
        }
        public override void New()
        {
            receiving = new DAL.tblReceiving();
            base.New();
        }
      
        long GetNewIvoicTheNumber(string tabl)
        {

            long maxTheNaumber = 0;

            switch (tabl)

            {
                case nameof(receiving): { using (var db = new DAL.dbDataContext())
                        {
                            if (db.tblReceivings.Count() != 0)
                                maxTheNaumber = db.tblReceivings.Select(x => x.TheNumber).Max();
                        }
                    }
                    break;
                case nameof(entry):
                    {
                        using (var db = new DAL.dbDataContext())
                        {
                            if (db.tblEntries.Count() != 0)
                                maxTheNaumber = db.tblEntries.Select(x => x.EntryNumber).Max();
                        }
                    }
                    break;


            }
            return ++maxTheNaumber;
        }
    
        public override void Delete()
        {
            if (XtraMessageBox.Show("هل متاكد من حذف هذا السند", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                using (var db = new DAL.dbDataContext())
                {

                    receiving = db.tblReceivings.FirstOrDefault(e1 => e1.ID == receiving.ID);
                    //   DAL.tblEntry tblEntry = db.tblEntries.Single(s => s.ID == spending.EntryID);

                    //  var dd = db.ExecuteQuery<long>("Delete From tblSpending  Where ID=" + spending.ID).ToArray();
                    // db.t
                    //  db.tblEntries.DeleteOnSubmit(tblEntry);
                    db.tblReceivings.DeleteOnSubmit(receiving);

                    db.SubmitChanges();
                    //if (dd[0] == 0) return;
                    //else
                    base.Delete();

                }
            }
           
        }
        public override void RefreshData()
        {

            TablaProductos.DataSource = new DAL.dbDataContext().vewReceivings;
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
                    using (var db = new DAL.dbDataContext())
                    {
                        receiving = db.tblReceivings.Single(s => s.ID == id);
                        var dd = db.ExecuteQuery<long>("Select Cast([RowVersion] as Bigint) from tblReceiving Where ID=" + id).ToArray();
                        receiving.PrevRowVersion = dd[0];
                        //Convert.ToInt64(spending.RowVersion.ToArray());
                        GetData();
                    }
                }
            }
            catch
            {

            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            New();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            Delete();
        }
        public override void Print()
        {
            base.Print();
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Print();
        }
    }
}
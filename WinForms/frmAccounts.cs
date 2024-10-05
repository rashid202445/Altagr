using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Altagr.Class;

namespace Altagr.WinForms
{
    public partial class frmAccounts : frmMaster
    {
        DAL.vewAccountsMina vew;//= new DAL.vewAccountsMina();
        public frmAccounts()
        {
            InitializeComponent();
           
          //  LookFatherName.Properties.Columns.AddRange(new LookUpColumnInfo[] {
          //  new LookUpColumnInfo(nameof(vew.اسم_الحساب), "اسم الحساب"),
          //  new LookUpColumnInfo(nameof(vew.الحساب_الختامي), "الحساب الختامي")});
            
           
        }
        DAL.tblAccounts account;
       
        public override void GetData()
        {
            
            LookFatherName.EditValue = account.FatherNumber;
            txtAccountName.Text = account.AccountName;
            txtAccountNumber.Text = account.AccountNumber.ToString();
            cmbAccountType.EditValue = ((account.AccountType as string)?? "رئيسي");
            cmbAccountReference.EditValue =((account.AccountReference as string) ?? "الميزانية العمومية");
        }
        public override void SetData()
        {
            account.FatherNumber = (LookFatherName.EditValue as long?) ?? 0;
             
            account.AccountName = txtAccountName.Text;
            account.AccountNumber = Convert.ToInt64(txtAccountNumber.Text);
            account.AccountType = cmbAccountType.EditValue.ToString();
            account.AccountReference = cmbAccountReference.EditValue.ToString();
            account.UserID = Session.User.ID;
        }
        public override void New()
        {
            account = new DAL.tblAccounts();
            LookFatherName.Enabled = true;
            cmbAccountType.Enabled = true;
            base.New();
        }
        public override bool IsDataValid()
        {
            if (txtAccountName.Text.Trim() == string.Empty)
            {
                txtAccountName.ErrorText = "يرجاء ادخال اسم المخزن";
                txtAccountName.Focus();
                return false;
            }
            if (cmbAccountType.SelectedIndex == 1 && LookFatherName.EditValue == null)
            {
                LookFatherName.ErrorText = "يرجاء ادخال الحساب الاب";
                LookFatherName.Focus();
                return false;
            }
            return base.IsDataValid();
        }
        public override void Save()
        {
            if (!IsDataValid()) return;

            var db = new DAL.dbDataContext();
            if (account.ID == 0)
                db.tblAccounts.InsertOnSubmit(account);
            else
            {
                try
                {
                   // db.tblAccounts.

                    db.tblAccounts.Attach(account);
                }
                catch {
                    account=  db.tblAccounts.FirstOrDefault(e1 => e1.ID==account.ID);
                }
            }
               
            SetData();
            db.SubmitChanges();
            base.Save();
            LookFatherName.Enabled = false;
            cmbAccountType.Enabled = false;
        }
        public override void Delete()
        {
            var db = new DAL.dbDataContext();
            try
            {
                try
                {
                    // db.tblAccounts.

                    db.tblAccounts.Attach(account);
                }
                catch
                {
                    account = db.tblAccounts.FirstOrDefault(e1 => e1.ID == account.ID);
                }
                db.tblAccounts.DeleteOnSubmit(account);
                db.SubmitChanges();
            }catch (SqlException ex)
            {
                if (ex.Number == 547)
                    XtraMessageBox.Show("لا يمكن حذف الحساب لان الحساب مرتبط بعمليات اخرأ");
                else XtraMessageBox.Show(ex.Message);
                return;
            }
            
            base.Delete();
        }
        public override void RefreshData()
        {
            
            using(var db = new DAL.dbDataContext())
            {
                LookFatherName.IntializeData(  db.vewAccountsMinas.Where(s => s.نوع_الحساب == "رئيسي").ToList(), nameof(vew.اسم_الحساب), nameof(vew.رقم_الحساب));
                var data = db.vewAccountsMinas.ToList();
                treeList1.DataSource = data;
            }
           // treeList1.DataSource = new DAL.dbDataContext().vewAccountsMinas;
          //  treeList1.ExpandToLevel(2);
            treeList1.ExpandAll();
         
            base.RefreshData();
        }
        private void frmAccounts_Load(object sender, EventArgs e)
        {
            
            RefreshData();
           
            LookFatherName.Properties.TextEditStyle = TextEditStyles.Standard;


            treeList1.ParentFieldName = nameof(vew.FatherNumber);//"FatherNumber";
            treeList1.KeyFieldName = nameof(vew.رقم_الحساب);//"رقم_الحساب";
            treeList1.OptionsBehavior.Editable = false;
            treeList1.Columns[nameof(vew.اسم_الحساب)].Caption = "اسم الحساب";
            treeList1.Columns[nameof(vew.نوع_الحساب)].Caption = "نوع الحساب";
            treeList1.Columns[nameof(vew.الحساب_الختامي)].Caption = "الحساب الختامي";
            treeList1.FocusedNodeChanged += TreeList1_FocusedNodeChanged;

            New();
        }

        private void TreeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            long id=0;
            if(long.TryParse(e.Node[nameof(vew.رقم_الحساب)].ToString(),out id))
            {
                if (id != 0)
                {
                    DAL.dbDataContext db = new DAL.dbDataContext();
                    account = db.tblAccounts.Where(s => s.AccountNumber == id).First();

                    GetData();
                    LookFatherName.Enabled = false;
                    cmbAccountType.Enabled = false;
                }
            }
        }

        void get_NewNumber_From_Number()
        {
            var db = new DAL.dbDataContext();
           // DAL.tblAccount[] tblAccounts;
            
           var tblAccounts = db.tblAccounts.GroupBy(a => a).SelectMany(
                              g => g.Where(
                                  a =>
                                  a.FatherNumber == ((LookFatherName.EditValue as long?) ?? 0) &&
                                 a.AccountType == cmbAccountType.EditValue.ToString() &&
                                  a.AccountName == g.Max(x => x.AccountName)
                              )
                              ).ToArray();
            long maxd = 0;
            if (tblAccounts.Length != 0)
                maxd = tblAccounts.Max(a => a.AccountNumber);
            string s = ((LookFatherName.EditValue as long?) ?? 0).ToString();
            s = s == "0" ? "" : s;
            if (Convert.ToBoolean( cmbAccountType.SelectedIndex))
            {
                ++maxd;
                if (maxd == 1)
                    switch (maxd.ToString().Length)
                    {

                        case 1:
                            s += "000" + maxd;
                            break;
                        case 2:
                            s += "00" + maxd;
                            break;
                        case 3:
                            s += "0" + maxd;
                            break;
                        default:
                            s += maxd;
                            break;
                    }
                else s = maxd.ToString();
            }
            else
            {
                ++maxd;
                if (maxd == 1)
                    s += maxd;
                else s = maxd.ToString();

            }
            txtAccountNumber.Text = s;
        }

        private void LookFatherName_Leave(object sender, EventArgs e)
        {
            if(account.ID==0)
            get_NewNumber_From_Number();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if(account.ID!=0 && account.AccountType!= "رئيسي")
            new frmAccountsDelegation(account.ID).ShowDialog();
        }
    }
}

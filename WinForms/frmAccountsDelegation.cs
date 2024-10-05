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
    public partial class frmAccountsDelegation : frmMaster
    {
        DAL.tblAccountsDelegation CusVnd;
        DAL.tblAccounts accounts;
        public frmAccountsDelegation(long id)
        {
            InitializeComponent();
            LoadObject(id);
          //  New();
        }
        void LoadObject(long id)
        {
           
                accounts = Class.Session.Accounts.Single( x => x.ID == id);
            txt_Name.Text = accounts.AccountName;
            txt_AccountID.Text = accounts.AccountNumber.ToString();
            using (var db = new DAL.dbDataContext())
            {
                CusVnd = db.tblAccountsDelegations.SingleOrDefault(x => x.AccountID == id);
                // IsCustomer = CusVnd.IsCustomer;
                if (CusVnd != null)
                    GetData();
                else
                    CusVnd = new DAL.tblAccountsDelegation();
            }
            //  GetData();

        }
        public override void New()
        {
          
        }
        public override void GetData()
        {
            
            txt_Mobile.Text = CusVnd.Mobile;
            txt_Phone.Text = CusVnd.Phone;
            txt_Address.Text = CusVnd.Address;
          //  txt_AccountID.Text = CusVnd.AccountID.ToString();
            base.GetData();
        }
        public override void SetData()
        {
            CusVnd.AccountID = accounts.ID;
            CusVnd.Mobile = txt_Mobile.Text;
            CusVnd.Phone = txt_Phone.Text;
            CusVnd.Address = txt_Address.Text;
            base.SetData();
        }
        bool IsDataValid()
        {
            
            var db = new DAL.dbDataContext();
            var oldObj = db.tblAccountsDelegations.Where(x => 
            x.AccountID == accounts.ID);
            if (oldObj.Count() > 0)
            {
                txt_Name.ErrorText = "هذا الاسم مسجل مسبقا";
                return false;
            }


            return true;
        }
        
        public override void Save()
        {
            if (IsDataValid() == false)
                return;
            var db = new DAL.dbDataContext();
            if (CusVnd.ID == 0)
            {
                db.tblAccountsDelegations.InsertOnSubmit(CusVnd);
                
            }
            else
            {
                db.tblAccountsDelegations.Attach(CusVnd);
            }


            SetData();
            
         
            db.SubmitChanges();
            base.Save();



        }

        private void frmAccountsDelegation_Load(object sender, EventArgs e)
        {
            btnDelet.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }
    }
}

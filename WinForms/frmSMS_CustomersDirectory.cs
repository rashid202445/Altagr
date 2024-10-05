using System;
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
    public partial class frmSMS_CustomersDirectory : frmMaster
    {
        DAL.tblSMS_CustomersDirectory customers;
        public frmSMS_CustomersDirectory()
        {
            InitializeComponent();
            RefreshData();
            New();
        }
        public override void GetData()
        {
            lkp_AccountID.EditValue = customers.AccountID;
            txt_MobileNumbers.Text = customers.MobileNumbers;
            mem_Notes.Text = customers.Notes;
            tgs_SendSMSWithoutBalance.EditValue = customers.SendSMSWithoutBalance;
            ts_notificationsPurchase.EditValue = customers.notificationsPurchase;
            ts_notificationsReceiving.EditValue = customers.notificationsReceiving;
            ts_notificationsSales.EditValue = customers.notificationsSales;
            ts_notificationsSpending.EditValue = customers.notificationsSpending;
            base.GetData();
        }
        public override void SetData()
        {
            customers.AccountID = (long)lkp_AccountID.EditValue;
            customers.MobileNumbers = txt_MobileNumbers.Text;
            customers.Notes = mem_Notes.Text;
            customers.SendSMSWithoutBalance = (bool)tgs_SendSMSWithoutBalance.EditValue;
            customers.notificationsPurchase = (bool)ts_notificationsPurchase.EditValue;
            customers.notificationsReceiving = (bool)ts_notificationsReceiving.EditValue;
            customers.notificationsSales = (bool)ts_notificationsSales.EditValue;
            customers.notificationsSpending = (bool)ts_notificationsSpending.EditValue;
            customers.UserID = Session.User.ID;
            customers.EnterTime = DateTime.Now;
            base.SetData();
        }
        public override void New()
        {
            customers = new DAL.tblSMS_CustomersDirectory();
            base.New();
        }
        public override void RefreshData()
        {
            lkp_AccountID.IntializeData(Session.Accounts.Where(s => s.AccountType != "رئيسي"), "AccountName", "ID");
            base.RefreshData();
        }
        public override void Save()
        {
            using (var db = new DAL.dbDataContext())
            {
                if (customers.ID == 0)
                    db.tblSMS_CustomersDirectories.InsertOnSubmit(customers);
                else
                {
                    try
                    {
                        // db.tblAccounts.

                        db.tblSMS_CustomersDirectories.Attach(customers);
                    }
                    catch
                    {
                        customers = db.tblSMS_CustomersDirectories.FirstOrDefault(e1 => e1.ID == customers.ID);
                    }
                }

                SetData();
                db.SubmitChanges();
            }
            base.Save();
        }
        public override bool IsDataValid()
        {
            int NumberOfErrors = 0;

            NumberOfErrors += lkp_AccountID.IsEditValueValidAndNotZero() ? 0 : 1;
            NumberOfErrors += mem_Notes.IsTextVailde() ? 0 : 1;

            using (var db = new DAL.dbDataContext())
            {
                if (db.tblSMS_CustomersDirectories.Where(x => x.AccountID == (long)lkp_AccountID.EditValue).Count() > 0)
                {
                    lkp_AccountID.ErrorText = "هذا الاسم مسجل بالفعل";
                    return false;
                }
            }
            return (NumberOfErrors == 0);
        }
    }
}

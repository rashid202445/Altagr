using Altagr.Class;
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
    public partial class frmSMS_CustomersDirectoryList : frmMasterList
    {
        public frmSMS_CustomersDirectoryList()
        {
            InitializeComponent();
        }

        private void frmSMS_CustomersDirectoryList_Load(object sender, EventArgs e)
        {
            gridView1.OptionsDetail.ShowDetailTabs = false;
            Session.SMS_CustomersDirectory.ListChanged += SMS_CustomersDirectory_ListChanged;
        }
        public override void RefreshData()
        {
            base.RefreshData();
        }
        private void SMS_CustomersDirectory_ListChanged(object sender, ListChangedEventArgs e)
        {
            RefreshData();
        }
    }
}

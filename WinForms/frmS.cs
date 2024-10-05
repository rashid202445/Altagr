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
using System.Windows.Forms.Design;

namespace Altagr.WinForms
{
    [System.ComponentModel.Designer(typeof(System.Windows.Forms.Design.ControlDesigner))]
    public partial class frmS : frmMaster
    {
        DAL.tblSpending spending;
        DAL.tblAccounts account;
        DAL.tblCurrency currency;
        public frmS()
        {
            InitializeComponent();
    
            New();
            //TheDate.EditValue = DateTime.Now;
        }
        //[Designer(typeof(ControlDesigner))]
   

        public override void Save()
        {
           // if (!IsDataValid()) return;
          
            // base.Save();
        }
        public override void GetData()
        {
        
            base.GetData();
        }
        public override bool IsDataValid()
        {
          
            return base.IsDataValid();
        }
        public override void New()
        {
      
            base.New();
        }
        public override void SetData()
        {

            base.SetData();
        }
        public override void Delete()
        {
            if(XtraMessageBox.Show("هل متاكد من حذف هذا السند","", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
              
            }
           
        }
        public override void RefreshData()
        {
        
            base.RefreshData();
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void frmReceiving_Load(object sender, EventArgs e)
        {
            
            RefreshData();
        }

        private void TablaProductos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
      
    }
}
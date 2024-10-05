using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
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
    [System.ComponentModel.Designer(typeof(System.Windows.Forms.Design.ControlDesigner))]
    public partial class frmMasterList1 : XtraForm
    {
        public frmMasterList1()
        {
            InitializeComponent();
        }

        private void frmMasterList_Load(object sender, EventArgs e)
        {
            //btnSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //btnPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //gridView1.OptionsBehavior.Editable = false;
            //gridView1.DoubleClick += GridView1_DoubleClick;
        }

        private void GridView1_DoubleClick(object sender, EventArgs e)
        {
            DXMouseEventArgs ea = e as DXMouseEventArgs;
            GridView view = sender as GridView;
            GridHitInfo info = view.CalcHitInfo(ea.Location);
            if (info.InRow || info.InRowCell)
            {
                OpenForm(Convert.ToInt64(view.GetFocusedRowCellValue("ID")));
            }
        }
        public virtual void OpenForm(long id)
        {

        }
     
    }
}

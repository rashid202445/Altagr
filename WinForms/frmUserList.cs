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
    public partial class frmUserList : frmMaster
    {
        public frmUserList()
        {
            InitializeComponent();
            gridView1.OptionsBehavior.Editable = false;
            gridView1.DoubleClick += GridView1_Click;
            RefreshData();
            gridView1.Columns["ID"].Visible = false;
            btnDelet.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }





        public override void RefreshData()
        {
            using (var db = new DAL.dbDataContext())
            {
                gridControl1.DataSource = db.tblUsers.Select(x => new { x.ID, x.Name, x.IsDisabled }).ToList();

            }
            base.RefreshData();
        }
        public override void New()
        {
            var frm = new frmUser();
            frmMain1.OpenForm(frm, true);
            base.New();
        }
        private void GridView1_Click(object sender, EventArgs e)
        {
            DXMouseEventArgs ea = e as DXMouseEventArgs;
            GridView view = sender as GridView;
            GridHitInfo info = view.CalcHitInfo(ea.Location);
            if (info.InRow || info.InRowCell)
            {
                var frm = new frmUser(Convert.ToInt32(view.GetFocusedRowCellValue("ID")));
                frmMain1.OpenForm(frm, true);
                RefreshData();
            }
        }
    }
}
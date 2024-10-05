using DevExpress.Utils;
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
    public partial class frmUserSettingsProfileList : frmMaster
    {
        public frmUserSettingsProfileList()
        {
            InitializeComponent();
            gridView1.OptionsBehavior.Editable = false;
            gridView1.DoubleClick += GridView1_Click;
            RefreshData();
            gridView1.Columns["ID"].Visible = false;
            gridView1.Columns["UserID"].Visible = false;
            gridView1.Columns["EnterTime"].Visible = false;
            btnDelet.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }
        public override void RefreshData()
        {
            using (var db = new DAL.dbDataContext())
            {
                gridControl1.DataSource = db.tblUserSettingsProfiles.ToList();

            }
            base.RefreshData();
        }
        public override void New()
        {
            var frm = new frmUserSettingsProfile();
            frm.Show();
           // frmMain.OpenForm(frm);
        }
        private void GridView1_Click(object sender, EventArgs e)
        {
            DXMouseEventArgs ea = e as DXMouseEventArgs;
            GridView view = sender as GridView;
            GridHitInfo info = view.CalcHitInfo(ea.Location);
            if (info.InRow || info.InRowCell)
            {
                var frm = new frmUserSettingsProfile(Convert.ToInt32(view.GetFocusedRowCellValue("ID")));
                frm.ShowDialog();
                //frmMain.OpenForm(frm, true);

                RefreshData();
            }
        }
    }
}

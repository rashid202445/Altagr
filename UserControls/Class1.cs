using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Altagr.UserControls
{
    [Designer(typeof(ControlDesigner))]
    public class ibsDataGridView : DataGridView
    {
        private DataView dv;
        private int maxRec;
        private int recNo;
        private const int m_pageSizeDefault = 10;
        private bool m_paging;
        private int m_pageCount;
        private int m_currentPage;
        private int m_pageSize;
        private string m_pageInfoFormat;
        private string m_recordInfoFormat;
        private int m_lastHeightMe;
        private int startRec;
        private IContainer components;
        private int endRec;
        private bool changeByMe;

        protected virtual DataTable dtSource
        {

            get
            {
                return (DataTable)null;
            }
           
            set
            {
            }
        }

        internal virtual ToolStripSeparator ToolStripSeparator2
        {

            get
            {
                return (ToolStripSeparator)null;
            }
            
            set
            {
            }
        }

        internal virtual ToolStripButton tsbtnGotoPage
        {

            get
            {
                return (ToolStripButton)null;
            }
            
            set
            {
            }
        }

        internal virtual ToolStripSeparator ToolStripSeparator3
        {

            get
            {
                return (ToolStripSeparator)null;
            }
            
            set
            {
            }
        }

        internal virtual ToolStripLabel tslblRecrodsInfo
        {

            get
            {
                return (ToolStripLabel)null;
            }
            
            set
            {
            }
        }

        internal virtual ContextMenuStrip cmdgv
        {

            get
            {
                return (ContextMenuStrip)null;
            }
            
            set
            {
            }
        }

        internal virtual ToolStripMenuItem cr
        {

            get
            {
                return (ToolStripMenuItem)null;
            }
            
            set
            {
            }
        }

        internal virtual ToolStripMenuItem sumCol
        {

            get
            {
                return (ToolStripMenuItem)null;
            }
            
            set
            {
            }
        }

        internal virtual ToolStripMenuItem AvgCol
        {

            get
            {
                return (ToolStripMenuItem)null;
            }
            
            set
            {
            }
        }

        internal virtual ToolStripMenuItem MaxValue
        {

            get
            {
                return (ToolStripMenuItem)null;
            }
            
            set
            {
            }
        }

        internal virtual ToolStripMenuItem MinValue
        {

            get
            {
                return (ToolStripMenuItem)null;
            }
            
            set
            {
            }
        }

        internal virtual ToolStripMenuItem TotalSelect
        {

            get
            {
                return (ToolStripMenuItem)null;
            }
            
            set
            {
            }
        }

        internal virtual ToolStripMenuItem mnuSumSelectColumns
        {

            get
            {
                return (ToolStripMenuItem)null;
            }
            
            set
            {
            }
        }

        internal virtual ToolStripMenuItem AddTotalRows
        {

            get
            {
                return (ToolStripMenuItem)null;
            }
            
            set
            {
            }
        }

        internal virtual ToolStripSeparator ToolStripMenuItem4
        {

            get
            {
                return (ToolStripSeparator)null;
            }
            
            set
            {
            }
        }

        internal virtual ToolStripMenuItem mnuSearch
        {

            get
            {
                return (ToolStripMenuItem)null;
            }
            
            set
            {
            }
        }

        internal virtual ToolStripSeparator ToolStripSeparator4
        {

            get
            {
                return (ToolStripSeparator)null;
            }
            
            set
            {
            }
        }

        internal virtual ToolStripMenuItem SaveColWidth
        {

            get
            {
                return (ToolStripMenuItem)null;
            }
            
            set
            {
            }
        }

        internal virtual ToolStripMenuItem ColWidthDefault
        {

            get
            {
                return (ToolStripMenuItem)null;
            }
            
            set
            {
            }
        }

        internal virtual ToolStripMenuItem ColHide
        {

            get
            {
                return (ToolStripMenuItem)null;
            }
            
            set
            {
            }
        }

        internal virtual ToolStripMenuItem Maxim
        {

            get
            {
                return (ToolStripMenuItem)null;
            }
            
            set
            {
            }
        }

        internal virtual ToolStripSeparator ToolStripMenuItem5
        {

            get
            {
                return (ToolStripSeparator)null;
            }
            
            set
            {
            }
        }

        internal virtual ToolStripMenuItem ExpToExcel
        {

            get
            {
                return (ToolStripMenuItem)null;
            }
            
            set
            {
            }
        }

        internal virtual ToolStripMenuItem mnuPriview
        {

            get
            {
                return (ToolStripMenuItem)null;
            }
            
            set
            {
            }
        }

        internal virtual ToolStripSeparator ToolStripMenuItem1
        {

            get
            {
                return (ToolStripSeparator)null;
            }
            
            set
            {
            }
        }

        internal virtual ToolStripMenuItem mnuSetFont
        {

            get
            {
                return (ToolStripMenuItem)null;
            }
            
            set
            {
            }
        }

        internal virtual ToolStripMenuItem mnuDefaultFont
        {

            get
            {
                return (ToolStripMenuItem)null;
            }
            
            set
            {
            }
        }

        internal virtual FontDialog FontDialog1
        {

            get
            {
                return (FontDialog)null;
            }
            
            set
            {
            }
        }

        internal virtual ToolStripMenuItem mnuPrint
        {

            get
            {
                return (ToolStripMenuItem)null;
            }
            
            set
            {
            }
        }

        internal virtual ToolStripMenuItem mnuPrintSelected
        {

            get
            {
                return (ToolStripMenuItem)null;
            }
            
            set
            {
            }
        }

        internal virtual ToolStripMenuItem mnuPriviewSelected
        {

            get
            {
                return (ToolStripMenuItem)null;
            }
            
            set
            {
            }
        }

        internal virtual ToolStripMenuItem mnuMarkRow
        {

            get
            {
                return (ToolStripMenuItem)null;
            }
            
            set
            {
            }
        }

        internal virtual ToolStripMenuItem mnuCopyText
        {

            get
            {
                return (ToolStripMenuItem)null;
            }
            
            set
            {
            }
        }

        [DefaultValue("Page {0}/{1}")]
        public string PageInfoFormat
        {

            get
            {
                return (string)null;
            }

            set
            {
            }
        }

        [DefaultValue("Record form {0} to {1} of {2}")]
        public string RecordInfoFormat
        {

            get
            {
                return (string)null;
            }

            set
            {
            }
        }

        [DefaultValue(false)]
        public bool PageSizVisible
        {

            get
            {
                return true;
            }

            set
            {
            }
        }

        [DefaultValue(false)]
        public bool NavigatorVisible
        {

            get
            {
                return true;
            }

            set
            {
            }
        }

        public string PageSizCaption
        {

            get
            {
                return (string)null;
            }

            set
            {
            }
        }

        public new string DataMember
        {

            get
            {
                return (string)null;
            }

            set
            {
            }
        }

        [DefaultValue(true)]
        public bool Paging
        {

            get
            {
                return true;
            }

            set
            {
            }
        }

        public int PageCount
        {

            get
            {
                return 0;
            }
        }

        public int CurrentPage
        {

            get
            {
                return 0;
            }

            set
            {
            }
        }

        [DefaultValue(10)]
        public int PageSize
        {

            get
            {
                return 0;
            }

            set
            {
            }
        }

        public bool IsFirstPage
        {

            get
            {
                return true;
            }
        }

        public bool IsLastPage
        {

            get
            {
                return true;
            }
        }

        internal virtual ToolStrip tsNavigator
        {

            get
            {
                return (ToolStrip)null;
            }
            
            set
            {
            }
        }

        internal virtual ToolStripLabel tslblPageSize
        {

            get
            {
                return (ToolStripLabel)null;
            }
            
            set
            {
            }
        }

        internal virtual ToolStripTextBox tstxtPageSize
        {

            get
            {
                return (ToolStripTextBox)null;
            }
            
            set
            {
            }
        }

        internal virtual ToolStripSeparator ToolStripSeparator1
        {

            get
            {
                return (ToolStripSeparator)null;
            }
            
            set
            {
            }
        }

        internal virtual ToolStripButton tsbtnFirstPage
        {

            get
            {
                return (ToolStripButton)null;
            }
            
            set
            {
            }
        }

        internal virtual ToolStripButton tsbtnPreviousPage
        {

            get
            {
                return (ToolStripButton)null;
            }
            
            set
            {
            }
        }

        internal virtual ToolStripTextBox tstxtPageInfo
        {

            get
            {
                return (ToolStripTextBox)null;
            }
            
            set
            {
            }
        }

        internal virtual ToolStripButton tsbtnNextPage
        {

            get
            {
                return (ToolStripButton)null;
            }
            
            set
            {
            }
        }

        internal virtual ToolStripButton tsbtnLastPage
        {

            get
            {
                return (ToolStripButton)null;
            }
            
            set
            {
            }
        }

        //public event ibsDataGridView.PageChangedEventHandler PageChanged
        //{

        //    add
        //    {
        //    }

        //    remove
        //    {
        //    }
        //}

        static ibsDataGridView()
        {
            //bymALRf1lpiBkvXQPs.bcLJCVPb6();
        }


        public ibsDataGridView()
        {
        }


        public void NextPage()
        {
        }


        public void PreviousPage()
        {
        }


        public void FirstPage()
        {
        }


        public void LastPage()
        {
        }


        public void SetDataSource()
        {
        }


        public void DisplayPageInfo()
        {
        }


        private void LoadPage()
        {
        }


        public void FillIBSIndexColumn()
        {
        }


        private void FillGrid()
        {
        }


        //private enumPageSite GetPageSite()
        //{
        //    return (enumPageSite.FirstAndLast);
        //}


        private void GotoPage(int PageNo)
        {
        }


        public void InitializeComponent()
        {
        }


        private void tstxtPageSize_TextChanged(object sender, System.EventArgs e)
        {
        }


        private void tstxtPageInfo_Click(object sender, System.EventArgs e)
        {
        }


        private void tstxtPageInfo_GotFocus(object sender, System.EventArgs e)
        {
        }


        public void SetNavigatorPosirion()
        {
        }


        public void val_ParentChanged()
        {
        }


        private void c_Disposed()
        {
        }


        private void myBaseDataSourceChanged()
        {
        }


        private void tsbtnGotoPage_Click(object sender, System.EventArgs e)
        {
        }


        private void tstxtPageInfo_KeyDown(object sender, KeyEventArgs e)
        {
        }


        private void firstDtSource_RowChanged(object sender, DataRowChangeEventArgs e)
        {
        }


        public void SetOnChanged(DataRow dr, DataRowAction Action)
        {
        }


        private void FirstPage(object sender, System.EventArgs e)
        {
        }


        private void cr_Click(object sender, System.EventArgs e)
        {
        }


        private void sumCol_Click(object sender, System.EventArgs e)
        {
        }


        private void AvgCol_Click(object sender, System.EventArgs e)
        {
        }


        private void cmdgv_Opening(object sender, CancelEventArgs e)
        {
        }


        private void mnuMarkRow_Click(object sender, System.EventArgs e)
        {
        }


        private void ColHide_Click(object sender, System.EventArgs e)
        {
        }


        private void TotalSelect_Click(object sender, System.EventArgs e)
        {
        }


        private void MaxValue_Click(object sender, System.EventArgs e)
        {
        }


        private void MinValue_Click(object sender, System.EventArgs e)
        {
        }


        private void ExpToExcel_Click(object sender, System.EventArgs e)
        {
        }


        private void AddTotalRows_Click(object sender, System.EventArgs e)
        {
        }


        private void Maxim_Click(object sender, System.EventArgs e)
        {
        }


        private void mnuPrint_Click(object sender, System.EventArgs e)
        {
        }


        private void mnuPrintSelected_Click(object sender, System.EventArgs e)
        {
        }


        private void mnuPriview_Click(object sender, System.EventArgs e)
        {
        }


        private void mnuPriviewSelected_Click(object sender, System.EventArgs e)
        {
        }


        private void mnuSearch_Click(object sender, System.EventArgs e)
        {
        }


        private void mnuSumSelectColumns_Click(object sender, System.EventArgs e)
        {
        }


        private void SaveColWidth_Click(object sender, System.EventArgs e)
        {
        }


        private void ColWidthDefault_Click(object sender, System.EventArgs e)
        {
        }


        protected override void OnKeyDown(KeyEventArgs e)
        {
        }


        protected override void OnMouseDown(MouseEventArgs e)
        {
        }


        protected override void OnCreateControl()
        {
        }


        private void mnuSetFont_Click(object sender, System.EventArgs e)
        {
        }


        public void UpdateGridFont()
        {
        }


        public void SetFont(Font font)
        {
        }


        private void mnuDefaultFont_Click(object sender, System.EventArgs e)
        {
        }


        private void FontDialog1_Apply(object sender, System.EventArgs e)
        {
        }


        private void mnuCopyText_Click(object sender, System.EventArgs e)
        {
        }


        private void ibsDataGridView_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
        }


        private void ibsDataGridView_RightToLeftChanged(object sender, System.EventArgs e)
        {
        }


        private void ibsDataGridView_RegionChanged(object sender, System.EventArgs e)
        {
        }


        private void ibsDataGridView_Paint(object sender, PaintEventArgs e)
        {
        }


        internal static bool HsoCdD6zTRO4Yyl9SDx()
        {
            return true;
        }


        internal static bool uMSQVbTRfFvUxCSRDnl()
        {
            return true;
        }

        //public delegate void PageChangedEventHandler(object Sender, IBSDatagridEventArgs e);
    }
}

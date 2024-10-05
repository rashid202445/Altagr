using DevExpress.XtraEditors;
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
using NumberToText;

namespace Altagr.WinForms
{
    public partial class frmReports : XtraForm
    {
        public frmReports()
        {
            InitializeComponent();
        }

        private void frmReports_Load(object sender, EventArgs e)
        {
            //using()
            lookUpEdit1.IntializeData(Session.Accounts.Where(x=>x.AccountType!= "رئيسي"), "AccountName", "AccountNumber");
            //lookUpEdit1.Properties.DataSource= listBox1.DataSource = Session.Accounts;
            //lookUpEdit1.Properties.DisplayMember= listBox1.DisplayMember = "AccountName";
            //lookUpEdit1.Properties.ValueMember= listBox1.ValueMember = "AccountNumber";
            // TablaProductos.DataSource = Session.Accounts;
            comboBox1.SelectedIndex = 0;
            dateEdit1.EditValue = dateEdit2.EditValue = DateTime.Now;
        }
        public  void RefreshData()
        {
            TablaProductos.DataSource = new DAL.dbDataContext().vewReceivings;
           
        }
        DAL.PROvewDetailedSearchResult pR;
        void DetailedPreviousBalanceSearch()
        {
            long num = (long)lookUpEdit1.EditValue;
            DateTime startdate = (DateTime)dateEdit1.EditValue;
            DateTime endDate = (DateTime)dateEdit2.EditValue;
            var db = new DAL.dbDataContext();
           var table1 = db.vewMainSearches.Where(s => s.رقم_الحساب == num).OrderBy(x => x.التاريخ).ToList();//db.vewMainSearches.Where(s => s.رقم_الحساب == num && s.التاريخ >= startdate && s.التاريخ <= endDate.AddDays(1.0)).ToList();
            if (table1.Count == 0)
            {
                TablaProductos.Invoke((MethodInvoker)delegate { TablaProductos.DataSource = null; });
                return;
            }
            List<DAL.vewMainSearch> source = get_Currency_Account(table1);
            List<DAL.PROvewDetailedPreviousBalanceSearchResult> data = new List<DAL.PROvewDetailedPreviousBalanceSearchResult>();
            foreach (DAL.vewMainSearch row in source)
            {
                
                    data.AddRange(db.PROvewDetailedPreviousBalanceSearch(startdate, num, row.CurrencyID, endDate.AddDays(1.0)));
               

            }
            TablaProductos.DataSource = data;
        }
        void DetailedSearch()
        {
            DAL.dbDataContext db = new DAL.dbDataContext();
            long num = (long)lookUpEdit1.EditValue;
            DateTime startdate = (DateTime)dateEdit1.EditValue;
            DateTime endDate = (DateTime)dateEdit2.EditValue;
            List<DAL.vewMainSearch> table1 = new List<DAL.vewMainSearch>();
           
                table1 = db.vewMainSearches.Where(s => s.رقم_الحساب == num).OrderBy(x => x.التاريخ).ToList();
            if (table1.Count == 0)
            {
                TablaProductos.Invoke((MethodInvoker)delegate { TablaProductos.DataSource = null; });
                return;
            }
            List<DAL.vewMainSearch> source = get_Currency_Account(table1);
            List<DAL.PROvewDetailedSearchResult> data = new List<DAL.PROvewDetailedSearchResult>();

            foreach (DAL.vewMainSearch row in source)
            {
                
                    data.AddRange(db.PROvewDetailedSearch(startdate, num, row.CurrencyID, endDate.AddDays(1.0)));
            }
            TablaProductos.DataSource = data;
        }
        private void TablaProductos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                //try
                //{
                //    // my = e.RowIndex;
                //    // new System.Threading.Thread(DefaultCellStyle).Start();


                //    if (TablaProductos.Rows[e.RowIndex].Cells[nameof(pR.نوع_المستند)].Value.ToString().Contains("الرصيد السابق"))
                //    {
                //        TablaProductos.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 224, 192);
                //    }
                //    if (TablaProductos.Rows[e.RowIndex].Cells[nameof(pR.نوع_المستند)].Value.ToString() == "" && TablaProductos.Rows[e.RowIndex].Cells[nameof(pR.التاريخ)].Value.ToString() == "")
                //    {
                //        TablaProductos.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 224, 192);
                //    }
                //    if (TablaProductos.Rows[e.RowIndex].Cells[nameof(pR.مدين)].Value.ToString().Contains("الاجمالي"))
                //    {
                //        TablaProductos.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Black;
                //        TablaProductos.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                //        TablaProductos.Rows[e.RowIndex].Height += 10;
                //        //   TablaProductos.Font = new Font(TablaProductos.Font, FontStyle.Bold);
                //    }

                //}
                //catch { }
            }
        }
       class Currency
        {
            public long CurrencyID;
            public string name;
        }
        private void totl1()
        {
            DAL.dbDataContext db = new DAL.dbDataContext();
            TablaProductos.DataSource = null;
            long num = (long)lookUpEdit1.EditValue;
            var data =( from x in db.vewMainSearches
                       where x.رقم_الحساب == num
                       group x by x.CurrencyID into g
                       select g).ToArray();

            //(from x in g
            //        orderby x.CurrencyID
            //        select new Currency
            //        {
            //          CurrencyID= (long)x.CurrencyID,
            //          name=  x.العملة
            //        })).ToArray();
            DataTable table2 = new DataTable();
            table2.Columns.Add("مدين");

            table2.Columns.Add("دائن");

            table2.Columns.Add("العملة");

            table2.Columns.Add("البيان");
            foreach (var row in data)
            {
                var data1 = db.vewMainSearches.Where(s => s.رقم_الحساب == num && s.CurrencyID== row.ToArray()[0].CurrencyID).Sum(x => x.Amount);
                DataRow row4 = table2.NewRow();
                decimal Amount = 0;
                if (decimal.TryParse(data1.ToString(), out Amount))
                {
                    row4[0] = (Amount > 0) ? Amount.ToString() : "";
                    row4[1] = Amount < 0 ? (-1 * Amount).ToString() : "";
                    row4[2] = row.ToArray()[0].العملة;
                    //  ToWord toWord = row4[0].ToString() != "" ? new ToWord(Convert.ToDecimal(row1[0]), new CurrencyInfo(row1[2].ToString())) : new ToWord((-1 * Convert.ToDecimal(row1[0])), new CurrencyInfo(row1[2].ToString()));

                    row4[3] =Utils. ConvertMoneyToArabicText(Amount.ToString());//.ConvertToArabic();
                    table2.Rows.Add(row4);
                }
            }
          
            
                       //{
                       //    x.CurrencyID,
                       //    x.Amount,
                       //    x.العملة,

                       //};
         
           
            TablaProductos.DataSource = table2;
           // table2.Dispose();
        }
        // DataTable<DAL.vewMainSearch> table1, table2;
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                totl1();
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                if (toggleSwitch1.IsOn)
                {
                    DetailedPreviousBalanceSearch();
                }
                else DetailedSearch();
            }
          //// var table1 = new DataTable();
          ////  table2 = NEW_DataTable_Account(table2);
          //  DAL.dbDataContext db = new DAL.dbDataContext();
          //  long num = (long)lookUpEdit1.EditValue;
          //  DateTime startdate = (DateTime)dateEdit1.EditValue;
          //  DateTime endDate = (DateTime)dateEdit2.EditValue;
          //  List<DAL.vewMainSearch> table1 = new List<DAL.vewMainSearch>();
          //  if (toggleSwitch1.IsOn)
          //        table1 = db.vewMainSearches.Where(s=>s.رقم_الحساب== num && s.التاريخ >=startdate && s.التاريخ <=endDate.AddDays(1.0)).ToList();
          //  else
          //      table1= db.vewMainSearches.Where(s => s.رقم_الحساب == num ).OrderBy(x=> x.التاريخ).ToList();
          //  if (table1.Count == 0)
          //  {
          //      TablaProductos.Invoke((MethodInvoker)delegate { TablaProductos.DataSource = null; });
          //      return;
          //  }
          //  List<DAL.vewMainSearch> source = get_Currency_Account(table1);
          //  List<DAL.PROvewDetailedPreviousBalanceSearchResult> data = new List<DAL.PROvewDetailedPreviousBalanceSearchResult>();
          //  List<DAL.PROvewDetailedSearchResult> datat = new List<DAL.PROvewDetailedSearchResult>();

          //  foreach (DAL.vewMainSearch row in source)
          //  {
          //      if (toggleSwitch1.IsOn)
          //          data.AddRange( db.PROvewDetailedPreviousBalanceSearch(startdate, num, row.CurrencyID, endDate.AddDays(1.0)));
          //      // table2.Load(ExecuteReader(" PROvewDetailedPreviousBalanceSearch '" + TheDate.Value.ToShortDateString() + "'," + txtAccountNum.Text + " ," + row[1].ToString() + " ,'" + NowDate.Value.AddDays(1.0).ToShortDateString() + "'"));
          //      else
          //         datat.AddRange( db.PROvewDetailedSearch(startdate, num, row.CurrencyID, endDate.AddDays(1.0)));
               

          //      //if (table2.Rows.Count != 0)
          //      //{
          //      //    ConvertToArabic(ref table2, row["EnglishCode"].ToString());
          //      //}
          //      // table2 = new DataTable();

          //  }
          //  TablaProductos.Invoke((MethodInvoker)delegate
          //  {
          //      if (toggleSwitch1.IsOn)
          //          TablaProductos.DataSource = data;
          //      else TablaProductos.DataSource = datat;
          //  });

        }
        List<DAL.vewMainSearch> get_Currency_Account(List<DAL.vewMainSearch> table1)
        {

            var d= (from r in table1.AsEnumerable()
                    group r by r.العملة into g
                    select (from r in g
                            orderby r.التاريخ
                            select r).First<DAL.vewMainSearch>());//.CopyToDataTable<DAL.vewMainSearch>();
            return d.ToList();
        }

        DataTable NEW_DataTable_Account(DataTable table2)
        {
            table2 = new DataTable();

            table2.Columns.Add("مدين");

            table2.Columns.Add("دائن");
            table2.Columns.Add("العملة");

            table2.Columns.Add("نوع المستند");
            table2.Columns.Add("التاريخ");

            table2.Columns.Add("البيان");
            return table2;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

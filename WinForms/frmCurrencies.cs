using Altagr.Class;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
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
    public partial class frmCurrencies : frmMaster
    {
        DAL.tblCurrency currency;
        DAL.tblCurrenciesPrice currenciesPrice;
        public frmCurrencies()
        {
            InitializeComponent();
            New();
        }
        
        public override void Save()
        {
            if (!IsDataValid()) return;


            var db = new DAL.dbDataContext();
            if (currency.ID == 0)
                db.tblCurrencies.InsertOnSubmit(currency);
            else
            {
                try
                {
                    // db.tblAccounts.

                    db.tblCurrencies.Attach(currency);
                }
                catch
                {
                    currency = db.tblCurrencies.FirstOrDefault(e1 => e1.ID == currency.ID);
                }
            }

            SetData();
            db.SubmitChanges();
            base.Save();
            if(!((currency.CurrencyType as bool?)?? true))
            SavePrice();
        }
        void SavePrice()
        {
            var db = new DAL.dbDataContext();
            if (currenciesPrice.ID == 0)
                db.tblCurrenciesPrices.InsertOnSubmit(currenciesPrice);
            else
            {
                try
                {
                    // db.tblAccounts.

                    db.tblCurrenciesPrices.Attach(currenciesPrice);
                }
                catch
                {
                    currenciesPrice = db.tblCurrenciesPrices.FirstOrDefault(e1 => e1.ID == currenciesPrice.ID);
                }
            }

            SetDataPrice();
            db.SubmitChanges();
        }
        void SetDataPrice()
        {
            currenciesPrice.SourceCurrencyID = currency.ID;
            currenciesPrice.TargetCurrencyID = 1;
            currenciesPrice.ExchangePrice = Convert.ToDecimal(txtPrice.Value);
            currenciesPrice.MaxExchangePrice= Convert.ToDecimal(txtMaxPrice.Text);
            currenciesPrice.MinExchangePrice= Convert.ToDecimal(txtMinPrice.Text);
            currenciesPrice.UserID = Session.User.ID;
            currenciesPrice.EnterTime = DateTime.Now;
        }
        public override void New()
        {
            currency = new DAL.tblCurrency();
            currenciesPrice = new DAL.tblCurrenciesPrice();
            base.New();
        }
        public override void Delete()
        {
            base.Delete();
        }
        public override bool IsDataValid()
        {
            var db = new DAL.dbDataContext();
            if (txtCurrencyName.Text.Trim() == string.Empty)
            {
                txtCurrencyName.ErrorText = "يرجاء ادخال اسم العملة";
                txtCurrencyName.Focus();
                return false;
            }
            if (currency.ID == 0)
            {
                if ( db.tblCurrencies.Where(s => s.CurrencyName == txtCurrencyName.Text.Trim()).Count()>0)
                {
                    txtCurrencyName.ErrorText = " اسم العملة موجود من قبل";
                    txtCurrencyName.Focus();
                    return false;
                }
                if(swhType.IsOn)
                if (db.tblCurrencies.Where(s => s.CurrencyType == swhType.IsOn).Count()>0)
                {
                    swhType.ErrorText = "موجود عملة محلية من قبل";
                    swhType.Focus();
                    return false;
                }
            }
            if(!swhType.IsOn)
            {
                if (txtPrice.Text.Trim() == string.Empty)
                {
                    txtPrice.ErrorText = "يرجاء ادخال سعر التحويل";
                    txtPrice.Focus();
                    return false;
                }
                if (txtMaxPrice.Text.Trim() == string.Empty)
                {
                    txtMaxPrice.ErrorText = "يرجاء ادخال أعلى سعر تحويل";
                    txtMaxPrice.Focus();
                    return false;
                }
                if (txtMinPrice.Text.Trim() == string.Empty)
                {
                    txtMinPrice.ErrorText = "يرجاء ادخال أدنئ سعر تحويل";
                    txtMinPrice.Focus();
                    return false;
                }
            }
            return base.IsDataValid();
        }
        public override void RefreshData()
        {
            //  treeList1.DataSource = new DAL.dbDataContext().tblCurrencies;
            using(var db = new DAL.dbDataContext())
            {
                var data = from cu in db.tblCurrencies
                           select new
                           {
                               cu.ID,
                               cu.CurrencyName,
                               cu.ArabicCode,
                               cu.EnglishCode,
                               cu.Notes,
                               UOM = (from u in db.tblCurrenciesPrices
                                      where u.SourceCurrencyID == cu.ID

                                      select new //ProductViewClass.ProductUOMView
                                      {

                                          u.ExchangePrice,
                                          u.MaxExchangePrice,
                                          u.MinExchangePrice,
                                      }).ToList()
                           };

                gridControl1.DataSource = data.ToList();
            }
            //var db = new DAL.dbDataContext();
            //var data= from cu
            base.RefreshData();
        }
        public override void GetData()
        {
            txtCurrencyName.Text = currency.CurrencyName;
            txtArabicCode.Text = currency.ArabicCode;
            txtEnglishCode.Text = currency.EnglishCode;
            txtNotes.Text = currency.Notes;
            swhType.IsOn = ((currency.CurrencyType as bool?) ?? false);
            if (!((currency.CurrencyType as bool?) ?? false))
            {
                txtPrice.Text = currenciesPrice.ExchangePrice.ToString();
                txtMaxPrice.Text = currenciesPrice.MaxExchangePrice.ToString();
                txtMinPrice.Text = currenciesPrice.MinExchangePrice.ToString();
            }
            else
            {
                txtPrice.Text = txtMaxPrice.Text = txtMinPrice.Text = "0";
            }
            base.GetData();
        }
        public override void SetData()
        {
            currency.CurrencyName = txtCurrencyName.Text;
            currency.ArabicCode = txtArabicCode.Text;
            currency.EnglishCode = txtEnglishCode.Text;
            currency.CurrencyType = swhType.IsOn;
            currency.Notes = txtNotes.Text;
            currency.UserID = Session.User.ID;
            currency.EnterTime = DateTime.Now;
            base.SetData();
        }
        private void toggleSwitch1_Toggled(object sender, EventArgs e)
        {
            layoutControl2.Visible = groupBox1.Visible = !swhType.IsOn;
        }

        private void frmCurrencies_Load(object sender, EventArgs e)
        {
            gridView1.OptionsBehavior.Editable = false;
            RefreshData();
            gridView1.OptionsDetail.ShowDetailTabs = false;
            gridControl1.ViewRegistered += GridControl1_ViewRegistered;
            gridView1.DoubleClick += GridView1_DoubleClick;
        }

        private void GridView1_DoubleClick(object sender, EventArgs e)
        {
            int id = 0;
            if (int.TryParse(gridView1.GetFocusedRowCellValue("ID").ToString(), out id) && id > 0)
            {
                using (var db = new DAL.dbDataContext())
                {
                    currency = db.tblCurrencies.Single(x => x.ID == id);
                    if (!((currency.CurrencyType as bool?) ?? false))
                    {
                        currenciesPrice = db.tblCurrenciesPrices.SingleOrDefault(s => s.SourceCurrencyID == id);
                    }
                }
                //this.Text = string.Format("بيانات صنف : {0}", product.ProductName);
                GetData();
            }
        }

        private void GridControl1_ViewRegistered(object sender, ViewOperationEventArgs e)
        {
            if (e.View.LevelName == "UOM")
            {
                GridView view = e.View as GridView;
                view.OptionsView.ShowViewCaption = true;
                view.ViewCaption = "سعر العملة ";
                view.Columns["ExchangePrice"].Caption = "سعر التحويل";
                view.Columns["MaxExchangePrice"].Caption = "أعلى سعر تحويل";
                view.Columns["MinExchangePrice"].Caption = "أدنئ سعر تحويل";
            }
        }
    }
}

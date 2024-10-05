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
    public partial class frmSalesInvoicesList : frmMasterList
    {
        Master.InvoiceType Type;
        public frmSalesInvoicesList(Master.InvoiceType _Type)
        {
            InitializeComponent();
            Type = _Type;

        }
        public override void RefreshData()
        {
            using(var db=new DAL.dbDataContext())
            {
                if (Type == Master.InvoiceType.Purchase)
                    gridControl1.DataSource = (from ivn in db.vewPurchaseInvoices
                                              select new
                                              {
                                                  ivn.ID,
                                                  ivn.TheNumber,
                                                  ivn.ExchangeAccountName,
                                                  ivn.InvoicesType,
                                                  ivn.Total,
                                                  ivn.net,
                                                  ivn.Paid,
                                                  ivn.Remaing,
                                                  ivn.AccountName,
                                                  ivn.TheDate,
                                                  products=(from d in db.tblPurchaseInvoicesDetailes.Where(cc=> cc.ParentID==ivn.ID)
                                                            from pr in db.tblProducts.Where(x => x.ID == d.ProductID)
                                                            from uname in db.tblUnits.Where(x => x.ID == d.UnitID)
                                                            from u in db.tblLSUnits.Where(x => x.ID == uname.UnitID)
                                                            select new
                                                            {
                                                                pr.ProductName,
                                                                u.Name,
                                                                d.UnitPrice,
                                                                d.Quantity,
                                                                d.SubDescount,
                                                                d.TotalAMount

                                                            }).ToList()

                                              }).ToList();
                else gridControl1.DataSource = (from ivn in db.vewSalesInvoices
                                                select new
                                                {
                                                    ivn.ID,
                                                    ivn.TheNumber,
                                                    ivn.ExchangeAccountName,
                                                    ivn.InvoicesType,
                                                    ivn.Total,
                                                    ivn.net,
                                                    ivn.Paid,
                                                    ivn.Remaing,
                                                    ivn.AccountName,
                                                    ivn.TheDate,
                                                    products = (from d in db.tblSalesInvoicesDetailes.Where(cc => cc.ParentID == ivn.ID)
                                                                from pr in db.tblProducts.Where(x => x.ID == d.ProductID)
                                                                from uname in db.tblUnits.Where(x=>x.ID==d.UnitID)
                                                                from u in db.tblLSUnits.Where(x => x.ID == uname.UnitID)
                                                                select new
                                                                {
                                                                    pr.ProductName,
                                                                    u.Name,
                                                                   // d.ProductID,
                                                                    //d.UnitID,
                                                                    d.UnitPrice,
                                                                    d.Quantity,
                                                                    d.SubDescount,
                                                                    d.TotalAMount

                                                                }).ToList()

                                                }).ToList();
            }
          
        }
        public override void OpenForm(long id)
        {
            switch (Type)
            {
                case Master.InvoiceType.Purchase:
                    frmMain1.OpenForm(new frmPurchaseInvoices(id));
                    break;
                case Master.InvoiceType.Sales:
                    frmMain1.OpenForm(new frmSalesInvoices(id));
                    break;
               
                default:
                    break;

            }
            
        }
        private void frmSalesInvoicesList_Load(object sender, EventArgs e)
        {

            switch (Type)
            {
                case Master.InvoiceType.Purchase:
                    this.Text = "فاتوره مشتريات ";
                    break;
                case Master.InvoiceType.Sales:
                    this.Text = "فواتير مبيعات ";
                    break;
                case Master.InvoiceType.PurchaseReturn:
                    break;
                case Master.InvoiceType.SalesReturn:
                    break;
                default:
                    break;

            }
            RefreshData();
        }
    }
}

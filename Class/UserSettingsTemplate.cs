using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraEditors;

namespace Altagr.Class
{
    public class UserSettingsTemplate
    {
        long ProfileID { get; set; }
        public UserSettingsTemplate(long profileid)
        {
            ProfileID = profileid;
            General = new GeneralSettings(ProfileID);
            Invoices = new InvoicesSettings(ProfileID);
            Sales = new SalesSettings(ProfileID);
            Purchase = new PurchaseSettings(ProfileID);
            Spending = new SpendingSettings(ProfileID);
        }
        public GeneralSettings General { get; set; }
        public InvoicesSettings Invoices { get; set; }
        public SpendingSettings Spending { get; set; }
        public SalesSettings Sales { get; set; }
        public PurchaseSettings Purchase { get; set; }
       

        public static string GetPropText(string propName)
        {
            UserSettingsTemplate ins;
            switch (propName)
            {
                case nameof(ins.General): return "اعدادات عامه";
                case nameof(ins.Invoices): return "اعدادات الفواتير";
                case nameof(ins.Sales): return "اعدادات البيع";
                case nameof(ins.Spending): return "اعدادات سندات الصرف";
                case nameof(ins.Purchase): return "اعدادات الشراء";
           //     case nameof(ins.General.DefualtRawStore): return "مخزن الافتراضي للخامات";
            //case nameof(ins.General.DefaultStore): return "المخزن الافتراضي";
                case nameof(ins.General.DefualtDrawer): return "الصندوق الافتراضيه";
                case nameof(ins.General.DefualtCustomer): return "العميل الافتراضي";
                case nameof(ins.General.DefaultVendor): return "المورد الافتراضي";
               // case nameof(ins.General.CanChangeStore): return "السماح بتغيير المخزن";
                case nameof(ins.General.CanChangeDrawer): return "السماح بتغيير الخزنه";
                case nameof(ins.General.CanChangeCustomer): return "السماح بتغيير العميل";
                case nameof(ins.General.CanChangeVendor): return "السماح بتغيير المورد";
                case nameof(ins.General.CanViewDocumentHistory): return "بامكانه عرض سجل التغييرات";
                case nameof(ins.Invoices.CanChangeTax): return "السماح بتغيير الضريبه";
                case nameof(ins.Invoices.CanDeleteItemsInInvoices): return "السماح بحذف الاصناف من الفاتوره";
                case nameof(ins.Sales.CanChangePaidInSales): return "السماح بتغيير المبلغ المدفوع";
                case nameof(ins.Sales.CanNotPostToStoreInSales): return "انشاء فواتير بدون صرف ";
                case nameof(ins.Sales.DefaultPayMethodInSales): return "نوع السداد الافتراضي";
                case nameof(ins.Sales.WhenSellingToACustomerExeededMaxCredit): return "عند البيع لعميل تجاوز حد الائتمان";
                case nameof(ins.Sales.CanChangeItemPriceInSales): return "السماح بتغيير سعر الصنف";
                case nameof(ins.Invoices.WhenSellingItemReachedReOrderLevel): return "عند صرف صنف وصل رصيده الي حد الطلب ";
                case nameof(ins.Invoices.WhenSellingItemWithQtyMoreThanAvailableQty): return "عند صرف كميه من صنف اكثر من المتاح";
                case nameof(ins.Sales.WhenSellingItemWithPriceLowerThanCostPrice): return "عند البيع بسعر اقل من سعر التكلفه";
                case nameof(ins.Sales.MaxDiscountInInvoice): return "اقصي خصم مسموح للفاتوره";
                case nameof(ins.Sales.MaxDiscountPerItem): return "اقصي خصم مسموح للصنف ";
                case nameof(ins.Sales.CanSellToVendors): return "السماح بالبيع للموردين";
                case nameof(ins.Sales.CanChangeSalesInvoiceDate): return "السماح بتغيير التاريخ";
                case nameof(ins.Sales.CanChangeQtyInSales): return "السماح بتغيير الكميه";
                case nameof(ins.Sales.HideCostInSales): return "اخفاء التكلفه من الفاتوره";
                case nameof(ins.Purchase.CanChangeItemPriceInPurchase): return "السماح بتغيير سعر الشراء";
                case nameof(ins.Purchase.CanBuyFromCustomers): return "السماح بالشراء من العملاء";
                case nameof(ins.Purchase.CanChangePurchaseInvoiceDate): return "السماح بتغيير التاريخ";

                case nameof(ins.Spending.CanChangePaidInSpending): return " السماح بتغيير المبلغ المدفوع";
                case nameof(ins.Spending.CanNotPostToStoreInSpending): return "انشاء فواتير بدون صرف ";
                case nameof(ins.Spending.DefaultPayMethodInSpending): return "نوع السداد الافتراضي";
                case nameof(ins.Spending.WhenSellingToACustomerExeededMaxCreditSpending): return "عند البيع لعميل تجاوز حد الائتمان";
                case nameof(ins.Spending.CanChangeItemPriceInSpending): return "السماح بتغيير سعر الصنف";
                case nameof(ins.Spending.WhenSellingItemWithPriceLowerThanCostPriceSpending): return "عند البيع بسعر اقل من سعر التكلفه";
                case nameof(ins.Spending.CanChangeSpendingInvoiceDate): return "السماح بتغيير التاريخ";
                default: return "$" + propName + "$";
            }

        }
        public static BaseEdit GetPropertyControl(string propName, object propertyValue)
        {
            UserSettingsTemplate ins;
            BaseEdit edit = null;
            switch (propName)
            {

                //السماح بتغيير الخزنه
                case nameof(ins.General.CanChangeDrawer):
                //السماح بتغيير العميل
                case nameof(ins.General.CanChangeCustomer):
                //السماح بتغيير المورد
                case nameof(ins.General.CanChangeVendor):
                //"بامكانه عرض سجل التغييرات
                case nameof(ins.General.CanViewDocumentHistory):
                //السماح بتغيير الضريبه
                case nameof(ins.Invoices.CanChangeTax):
                //السماح بحذف الاصناف من الفاتوره
                case nameof(ins.Invoices.CanDeleteItemsInInvoices):
                //السماح بتغيير المبلغ المدفوع
                case nameof(ins.Sales.CanChangePaidInSales):
                //السماح بتغيير المبلغ المدفوع
                case nameof(ins.Spending.CanChangePaidInSpending):
                //انشاء فواتير بدون صرف
                case nameof(ins.Spending.CanNotPostToStoreInSpending):
                //السماح بتغيير سعر الصنف
                case nameof(ins.Spending.CanChangeItemPriceInSpending):
                //السماح بتغيير التاريخ
                case nameof(ins.Spending.CanChangeSpendingInvoiceDate):
                //انشاء فواتير بدون صرف 
                case nameof(ins.Sales.CanNotPostToStoreInSales):
                //السماح بتغيير سعر الصنف
                case nameof(ins.Sales.CanChangeItemPriceInSales):
                //السماح بالبيع للموردين
                case nameof(ins.Sales.CanSellToVendors):
                //السماح بتغيير التاريخ
                case nameof(ins.Sales.CanChangeSalesInvoiceDate):
                //السماح بتغيير الكميه
                case nameof(ins.Sales.CanChangeQtyInSales):
                //اخفاء التكلفه من الفاتوره
                case nameof(ins.Sales.HideCostInSales):
                //السماح بتغيير سعر الشراء
                case nameof(ins.Purchase.CanChangeItemPriceInPurchase):
                //السماح بالشراء من العملاء
                case nameof(ins.Purchase.CanBuyFromCustomers):
                //السماح بتغيير التاريخ
                case nameof(ins.Purchase.CanChangePurchaseInvoiceDate):
                    edit = new ToggleSwitch();
                    ((ToggleSwitch)edit).Properties.OnText = "نعم";
                    ((ToggleSwitch)edit).Properties.OffText = "لا";
                    break;

                //الصندوق الافتراضيه
                case nameof(ins.General.DefualtDrawer):
                    edit = new LookUpEdit();
                    ((LookUpEdit)edit).IntializeData(Session.Accounts.Where(s => s.AccountType != "رئيسي" && s.FatherNumber == 1211), "AccountName", "ID");
                    break;
                //العميل الافتراضي
                case nameof(ins.General.DefualtCustomer):
                    edit = new LookUpEdit();
                    ((LookUpEdit)edit).IntializeData(Session.Accounts.Where(x=>x.AccountType != "رئيسي" && x.FatherNumber != 1211), "AccountName", "ID");
                    break;
                //المورد الافتراضي
                case nameof(ins.General.DefaultVendor):
                    edit = new LookUpEdit();
                    ((LookUpEdit)edit).IntializeData(Session.Accounts.Where(x => x.AccountType != "رئيسي" && x.FatherNumber != 1211), "AccountName", "ID");
                    break;
                //نوع السداد الافتراضي
                case nameof(ins.Sales.DefaultPayMethodInSales):
                    edit = new LookUpEdit();
                    ((LookUpEdit)edit).IntializeData(Master.PayMethodsList);
                    break;
                //عند البيع لعميل تجاوز حد الائتمان
                case nameof(ins.Sales.WhenSellingToACustomerExeededMaxCredit):
                //نوع السداد الافتراضي
                case nameof(ins.Spending.DefaultPayMethodInSpending):
                    edit = new LookUpEdit();
                    ((LookUpEdit)edit).IntializeData(Master.PayMethodsList);
                    break;

                //عند البيع لعميل تجاوز حد الائتمان
                case nameof(ins.Spending.WhenSellingToACustomerExeededMaxCreditSpending):
                //عند البيع لعميل تجاوز حد الائتمان
                case nameof(ins.Spending.WhenSellingItemWithPriceLowerThanCostPriceSpending):
                //عند البيع لعميل تجاوز حد الائتمان
                case nameof(ins.Sales.WhenSellingItemWithPriceLowerThanCostPrice):
                //عند صرف صنف وصل رصيده الي حد الطلب 
                case nameof(ins.Invoices.WhenSellingItemReachedReOrderLevel):
                //عند صرف كميه من صنف اكثر من المتاح
                case nameof(ins.Invoices.WhenSellingItemWithQtyMoreThanAvailableQty):
                    edit = new LookUpEdit();
                    ((LookUpEdit)edit).IntializeData(Master.WarningLevelsList);
                    break;
                //اقصي خصم مسموح للفاتوره
                case nameof(ins.Sales.MaxDiscountInInvoice):
                //اقصي خصم مسموح للصنف
                case nameof(ins.Sales.MaxDiscountPerItem):
                    edit = new SpinEdit();
                    ((SpinEdit)edit).Properties.Increment = 0.01m;
                    ((SpinEdit)edit).Properties.Mask.EditMask = "p";
                    ((SpinEdit)edit).Properties.Mask.UseMaskAsDisplayFormat = true;
                    ((SpinEdit)edit).Properties.MaxValue = 1;

                    break;
                default:
                    break;
            }

            if (edit != null)
            {
                edit.Name = propName;
                edit.Properties.NullText = "";
                edit.EditValue = propertyValue;
            }
            return edit;
        }
    }
    public class GeneralSettings
    {
        long ProfileID { get; set; }
        public GeneralSettings(long profileid)
        {
            ProfileID = profileid;
        }
        //الصندوق الافتراضيه
        [Category("شؤون الطلاب")]
        [DefaultValue("")]
        [DisplayName("الصندوق الافتراضيه")]
        public long DefualtDrawer { get { return Master.FromByteArray<long>(Master.GetPropertyValue(Master.GetCallerName(), ProfileID)); } }
        //العميل الافتراضي
        public long DefualtCustomer { get { return Master.FromByteArray<long>(Master.GetPropertyValue(Master.GetCallerName(), ProfileID)); } }
        //المورد الافتراضي
        public long DefaultVendor { get { return Master.FromByteArray<long>(Master.GetPropertyValue(Master.GetCallerName(), ProfileID)); } }
        //السماح بتغيير الخزنه
        public bool CanChangeDrawer { get { return Master.FromByteArray<bool>(Master.GetPropertyValue(Master.GetCallerName(), ProfileID)); } }
        //السماح بتغيير العميل
        public bool CanChangeCustomer { get { return Master.FromByteArray<bool>(Master.GetPropertyValue(Master.GetCallerName(), ProfileID)); } }
        //السماح بتغيير المورد
        public bool CanChangeVendor { get { return Master.FromByteArray<bool>(Master.GetPropertyValue(Master.GetCallerName(), ProfileID)); } }
        //"بامكانه عرض سجل التغييرات
        public bool CanViewDocumentHistory { get { return Master.FromByteArray<bool>(Master.GetPropertyValue(Master.GetCallerName(), ProfileID)); } }

    }
    public class InvoicesSettings
    {
        long ProfileID { get; set; }
        public InvoicesSettings(long profileid)
        {
            ProfileID = profileid;
        }
        //السماح بتغيير الضريبه
        public bool CanChangeTax { get { return Master.FromByteArray<bool>(Master.GetPropertyValue(Master.GetCallerName(), ProfileID)); } }
        //السماح بحذف الاصناف من الفاتوره
        public bool CanDeleteItemsInInvoices { get { return Master.FromByteArray<bool>(Master.GetPropertyValue(Master.GetCallerName(), ProfileID)); } }
        //عند صرف صنف وصل رصيده الي حد الطلب 
        public Master.WarningLevels WhenSellingItemReachedReOrderLevel { get { return Master.FromByteArray<Master.WarningLevels>(Master.GetPropertyValue(Master.GetCallerName(), ProfileID)); } }
        //عند صرف كميه من صنف اكثر من المتاح
        public Master.WarningLevels WhenSellingItemWithQtyMoreThanAvailableQty { get { return Master.FromByteArray<Master.WarningLevels>(Master.GetPropertyValue(Master.GetCallerName(), ProfileID)); } }

    }

    public class SalesSettings
    {
        long ProfileID { get; set; }
        public SalesSettings(long profileid)
        {
            ProfileID = profileid;

        }
        //السماح بتغيير المبلغ المدفوع
        public bool CanChangePaidInSales { get { return Master.FromByteArray<bool>(Master.GetPropertyValue(Master.GetCallerName(), ProfileID)); } }
        //انشاء فواتير بدون صرف 
        public bool CanNotPostToStoreInSales { get { return Master.FromByteArray<bool>(Master.GetPropertyValue(Master.GetCallerName(), ProfileID)); } }
        //نوع السداد الافتراضي
        public Master.PayMethods DefaultPayMethodInSales { get { return Master.FromByteArray<Master.PayMethods>(Master.GetPropertyValue(Master.GetCallerName(), ProfileID)); } }// طريقة البيع الافتراضية
        //عند البيع لعميل تجاوز حد الائتمان
        public Master.WarningLevels WhenSellingToACustomerExeededMaxCredit { get { return Master.FromByteArray<Master.WarningLevels>(Master.GetPropertyValue(Master.GetCallerName(), ProfileID)); } }
        //السماح بتغيير سعر الصنف
        public bool CanChangeItemPriceInSales { get { return Master.FromByteArray<bool>(Master.GetPropertyValue(Master.GetCallerName(), ProfileID)); } }
        //عند البيع بسعر اقل من سعر التكلفه
        public Master.WarningLevels WhenSellingItemWithPriceLowerThanCostPrice { get { return Master.FromByteArray<Master.WarningLevels>(Master.GetPropertyValue(Master.GetCallerName(), ProfileID)); } }
        //اقصي خصم مسموح للفاتوره
        public decimal MaxDiscountInInvoice { get { return Master.FromByteArray<decimal>(Master.GetPropertyValue(Master.GetCallerName(), ProfileID)); } }
        //اقصي خصم مسموح للصنف
        public decimal MaxDiscountPerItem { get { return Master.FromByteArray<decimal>(Master.GetPropertyValue(Master.GetCallerName(), ProfileID)); } }
        //السماح بالبيع للموردين
        public bool CanSellToVendors { get { return Master.FromByteArray<bool>(Master.GetPropertyValue(Master.GetCallerName(), ProfileID)); } }
        //السماح بتغيير التاريخ
        public bool CanChangeSalesInvoiceDate { get { return Master.FromByteArray<bool>(Master.GetPropertyValue(Master.GetCallerName(), ProfileID)); } }
        //السماح بتغيير الكميه
        public bool CanChangeQtyInSales { get { return Master.FromByteArray<bool>(Master.GetPropertyValue(Master.GetCallerName(), ProfileID)); } }
        //اخفاء التكلفه من الفاتوره
        public bool HideCostInSales { get { return Master.FromByteArray<bool>(Master.GetPropertyValue(Master.GetCallerName(), ProfileID)); } }

    }
    public class SpendingSettings
    {
        long ProfileID { get; set; }
        public SpendingSettings(long profileid)
        {
            ProfileID = profileid;

        }
        //  السماح بتغيير المبلغ المدفوع
        public bool CanChangePaidInSpending { get { return Master.FromByteArray<bool>(Master.GetPropertyValue(Master.GetCallerName(), ProfileID)); } }
        //انشاء فواتير بدون صرف 
        public bool CanNotPostToStoreInSpending { get { return Master.FromByteArray<bool>(Master.GetPropertyValue(Master.GetCallerName(), ProfileID)); } }
        //نوع السداد الافتراضي
        public Master.PayMethods DefaultPayMethodInSpending { get { return Master.FromByteArray<Master.PayMethods>(Master.GetPropertyValue(Master.GetCallerName(), ProfileID)); } }// طريقة البيع الافتراضية
        //عند البيع لعميل تجاوز حد الائتمان
        public Master.WarningLevels WhenSellingToACustomerExeededMaxCreditSpending { get { return Master.FromByteArray<Master.WarningLevels>(Master.GetPropertyValue(Master.GetCallerName(), ProfileID)); } }
        //السماح بتغيير سعر الصنف
        public bool CanChangeItemPriceInSpending { get { return Master.FromByteArray<bool>(Master.GetPropertyValue(Master.GetCallerName(), ProfileID)); } }
        //عند البيع بسعر اقل من سعر التكلفه
        public Master.WarningLevels WhenSellingItemWithPriceLowerThanCostPriceSpending { get { return Master.FromByteArray<Master.WarningLevels>(Master.GetPropertyValue(Master.GetCallerName(), ProfileID)); } }
        //اقصي خصم مسموح للفاتوره
      //  public decimal MaxDiscountInInvoice { get { return Master.FromByteArray<decimal>(Master.GetPropertyValue(Master.GetCallerName(), ProfileID)); } }
        //اقصي خصم مسموح للصنف
      //  public decimal MaxDiscountPerItem { get { return Master.FromByteArray<decimal>(Master.GetPropertyValue(Master.GetCallerName(), ProfileID)); } }
        //السماح بالبيع للموردين
    //    public bool CanSellToVendors { get { return Master.FromByteArray<bool>(Master.GetPropertyValue(Master.GetCallerName(), ProfileID)); } }
        //السماح بتغيير التاريخ
        public bool CanChangeSpendingInvoiceDate { get { return Master.FromByteArray<bool>(Master.GetPropertyValue(Master.GetCallerName(), ProfileID)); } }
        //السماح بتغيير الكميه
      //  public bool CanChangeQtyInSpending { get { return Master.FromByteArray<bool>(Master.GetPropertyValue(Master.GetCallerName(), ProfileID)); } }
        //اخفاء التكلفه من الفاتوره
      //  public bool HideCostInSpending { get { return Master.FromByteArray<bool>(Master.GetPropertyValue(Master.GetCallerName(), ProfileID)); } }

    }
    public class PurchaseSettings
    {
        long ProfileID { get; set; }
        public PurchaseSettings(long profileid)
        {
            ProfileID = profileid;

        }
        //السماح بتغيير سعر الشراء
        public bool CanChangeItemPriceInPurchase { get; set; }
        //السماح بالشراء من العملاء
        public bool CanBuyFromCustomers { get; set; }
        //السماح بتغيير التاريخ
        public bool CanChangePurchaseInvoiceDate { get; set; }

    }
}

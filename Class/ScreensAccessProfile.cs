using Altagr.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Altagr.Class
{
   public class ScreensAccessProfile
    {
        public static int MaxID = 1;

        public ScreensAccessProfile(string name, ScreensAccessProfile parent = null)
        {
            ScreenName = name;
            ScreenID = MaxID++;
            if (parent != null)
                ParentScreenID = parent.ScreenID;
            else ParentScreenID = 0;
            Actions = new List<Master.Actions>() {
                Master.Actions.Add ,
                Master.Actions.Edit ,
                Master.Actions.Delete ,
                Master.Actions.Print ,
                Master.Actions.Show ,
                Master.Actions.Open  ,
            };
        }

        public long ScreenID { get; set; }
        public long ParentScreenID { get; set; }
        public string ScreenName { get; set; }
        public string ScreenCaption { get; set; }
        public bool CanShow { get; set; }
        public bool CanOpen { get; set; }
        public bool CanAdd { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public bool CanPrint { get; set; }
        public List<Master.Actions> Actions { get; set; }
    }
    public static class Screens
    {
        //public static ScreensAccessProfile mainSettings = new ScreensAccessProfile("elm_MainSettings")
        //{
        //    Actions = new List<Master.Actions>() { Master.Actions.Show },
        //    ScreenCaption = "تهيْة النظام"
        //};
   

        public static ScreensAccessProfile Customers = new ScreensAccessProfile("elm_Accounts")
        {
            Actions = new List<Master.Actions>() { Master.Actions.Show },
            ScreenCaption = "الحسابات"
        };
        public static ScreensAccessProfile AddCustomer = new ScreensAccessProfile(nameof(frmAccounts), Customers)
        { ScreenCaption = "اضافه حساب" };

        public static ScreensAccessProfile Vendors = new ScreensAccessProfile("elm_Receiving")
        {
            Actions = new List<Master.Actions>() { Master.Actions.Show },
            ScreenCaption = "سندات"
        };
        public static ScreensAccessProfile AddVendor = new ScreensAccessProfile(nameof(frmReceiving), Vendors)
        { ScreenCaption = "سند قبض" };
        public static ScreensAccessProfile ViewVendors = new ScreensAccessProfile(nameof(frmSpending), Vendors)
        { ScreenCaption = "سند صرف" };

        //public static ScreensAccessProfile Stores = new ScreensAccessProfile("elm_Stores")
        //{
        //    Actions = new List<Master.Actions>() { Master.Actions.Show },
        //    ScreenCaption = "الافرع"
        //};
        //public static ScreensAccessProfile AddStore = new ScreensAccessProfile(nameof(frm_Stores), Stores)
        //{ ScreenCaption = "اضافه مخزن" };
        //public static ScreensAccessProfile ViewCustomers = new ScreensAccessProfile(nameof(frm_StoresList), Stores)
        //{ ScreenCaption = "عرض المخازن" };

        //public static ScreensAccessProfile Drawers = new ScreensAccessProfile("elm_Drawers")
        //{
        //    Actions = new List<Master.Actions>() { Master.Actions.Show },
        //    ScreenCaption = "الخزن"
        //};
        //public static ScreensAccessProfile AddDrawer = new ScreensAccessProfile(nameof(frm_Drawer), Drawers)
        //{ ScreenCaption = "اضافه خزنه" };
        //public static ScreensAccessProfile ViewDrawers = new ScreensAccessProfile(nameof(frm_DrawerList), Drawers)
        //{ ScreenCaption = "عرض الخزن" };

        public static ScreensAccessProfile Products = new ScreensAccessProfile("elm_Product")
        {
            Actions = new List<Master.Actions>() { Master.Actions.Show },
            ScreenCaption = "الاصناف"
        };
        public static ScreensAccessProfile AddProduct = new ScreensAccessProfile(nameof(frmProduct), Products)
        { ScreenCaption = "اضافه صنف" };
        public static ScreensAccessProfile ViewProducts = new ScreensAccessProfile(nameof(frmProductLists), Products)
        { ScreenCaption = "عرض الاصناف" };

        public static ScreensAccessProfile Purchases = new ScreensAccessProfile("elm_Purchases")
        {
            Actions = new List<Master.Actions>() { Master.Actions.Show },
            ScreenCaption = "المشتريات"
        };
        public static ScreensAccessProfile AddPurchaseInvoice = new ScreensAccessProfile(nameof(frmPurchaseInvoices), Purchases)
        { ScreenCaption = "اضافه فاتوره مشتريات" };
        public static ScreensAccessProfile vewPurchaseInvoice = new ScreensAccessProfile("frmPurchaseInvoicesList", Purchases)
        { ScreenCaption = "عرض فواتير المشتريات" };
        public static ScreensAccessProfile Sales = new ScreensAccessProfile("elm_Sales")
        {
            Actions = new List<Master.Actions>() { Master.Actions.Show },
            ScreenCaption = "المبيعات"
        };
        public static ScreensAccessProfile AddSalesInvoices = new ScreensAccessProfile(nameof(frmSalesInvoices), Sales)
        { ScreenCaption = "اضافه فاتوره مبيعات" };
        public static ScreensAccessProfile vewSalesInvoices = new ScreensAccessProfile("frmSalesInvoicesList", Sales)
        { ScreenCaption = "عرض فواتير المبيعات" };
        public static ScreensAccessProfile Reports = new ScreensAccessProfile("elm_Reports")
        {
            Actions = new List<Master.Actions>() { Master.Actions.Show },
            ScreenCaption = "تقارير"
        };
        public static ScreensAccessProfile vewReports = new ScreensAccessProfile(nameof(frmReports), Reports)
        { ScreenCaption = "عرض كشف حساب" };
        public static ScreensAccessProfile vewReportsProduct = new ScreensAccessProfile(nameof(frmReportsProduct), Reports)
        { ScreenCaption = "عرض  الاصناف في المخون " };
        public static ScreensAccessProfile SMS = new ScreensAccessProfile("elm_SMS")
        {
            Actions = new List<Master.Actions>() { Master.Actions.Show },
            ScreenCaption = "خدمة الرسائل القصيرة"
        };
        public static ScreensAccessProfile SMS_CustomersDirectory = new ScreensAccessProfile(nameof(frmSMS_CustomersDirectory), SMS)
        { ScreenCaption = "دليل حسابات الرسائل القصيرة " };
        public static ScreensAccessProfile SMS_SendMessage = new ScreensAccessProfile(nameof(frmSMS_SendMessage), SMS)
        { ScreenCaption = "رسال رسالة قصيرة" };
        public static ScreensAccessProfile Settings = new ScreensAccessProfile("elm_Settings")
        {
            Actions = new List<Master.Actions>() { Master.Actions.Show },
            ScreenCaption = "الاعدادت"
        };
        public static ScreensAccessProfile AddfrmCurrencies = new ScreensAccessProfile(nameof(frmCurrencies), Settings)
        { ScreenCaption = "العملات " };
        public static ScreensAccessProfile AddUserSettingProfile = new ScreensAccessProfile(nameof(frmUserSettingsProfile), Settings)
        { ScreenCaption = "اضافه نموذج اعدادات" };
      
        public static ScreensAccessProfile ViweUserSettingProfile = new ScreensAccessProfile(nameof(frmUserSettingsProfileList), Settings)
        { ScreenCaption = "عرض نماذج الاعدادت" };

        public static ScreensAccessProfile AddAccessProfile = new ScreensAccessProfile(nameof(frmAccessProfile), Settings)
        { ScreenCaption = "اضافه نموذج صلاحيه وصول" };
        public static ScreensAccessProfile ViweAccessProfile = new ScreensAccessProfile(nameof(frmAccessProfileList), Settings)
        { ScreenCaption = "عرض نماذج صلاحيات الوصول" };
        public static ScreensAccessProfile AddUser = new ScreensAccessProfile(nameof(frmUser), Settings)
        { ScreenCaption = "اضافه مستخدم" };
        public static ScreensAccessProfile ViewUsers = new ScreensAccessProfile(nameof(frmUserList), Settings)
        { ScreenCaption = "عرض المستخدمين" };


        public static List<ScreensAccessProfile> GetScreens
        {

            get
            {
                Type t = typeof(Screens);
                FieldInfo[] fields = t.GetFields(BindingFlags.Public | BindingFlags.Static);

                var list = new List<ScreensAccessProfile>();
                foreach (var item in fields)
                {
                    var obj = item.GetValue(null);
                    if (obj != null && obj.GetType() == typeof(ScreensAccessProfile))
                        list.Add((ScreensAccessProfile)obj);
                }

                return list;

            }
        }
    }
}

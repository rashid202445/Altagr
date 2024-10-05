using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altagr.Class
{
    public static class Session
    {
        public static class Defualts
        {
            public static int Drawer { get => 10; }
            public static int Customer { get => 1; }
            public static int Vendor { get => 2; }
            public static int Store { get => 1003; }
            public static int RawStore { get => 1003; }
            public static int DiscountAllowedAccountID { get => 1010; }
            public static int DiscountReceivedAccountID { get => 1009; }
            public static int SalesTax { get => 1019; }
            public static int PurchaseTax { get => 1020; }
            public static int PurchaseExpences { get => 1021; }
        }
        public static UserSettingsTemplate _userSettings;
        public static UserSettingsTemplate UserSettings
        {
            get
            {

                if (_userSettings == null)
                    _userSettings = new UserSettingsTemplate(1);
                return _userSettings;

            }
        }
        private static DAL.tblUser _user;
        public static DAL.tblUser User { get => _user; }

        public static void SetUser(DAL.tblUser user)
        {
            _user = user;
            using (DAL.dbDataContext db = new DAL.dbDataContext())
            {
                _screensAccesses = (from s in Class.Screens.GetScreens
                                    from d in db.tblUserAccessProfileDetails
                                    .Where(x => x.ProfileID == user.ScreenProfileID && x.ScreenID == s.ScreenID).DefaultIfEmpty()
                                    select new Class.ScreensAccessProfile(s.ScreenName)
                                    {
                                        CanAdd = (d == null) ? true : d.CanAdd,
                                        CanDelete = (d == null) ? true : d.CanDelete,
                                        CanEdit = (d == null) ? true : d.CanEdit,
                                        CanOpen = (d == null) ? true : d.CanOpen,
                                        CanPrint = (d == null) ? true : d.CanPrint,
                                        CanShow = (d == null) ? true : d.CanShow,
                                        Actions = s.Actions,
                                        ScreenName = s.ScreenName,
                                        ScreenCaption = s.ScreenCaption,
                                        ScreenID = s.ScreenID,
                                        ParentScreenID = s.ParentScreenID,
                                    }).ToList();
            }
        }
        private static BindingList<DAL.tblProducts> _products;
        public static BindingList<DAL.tblProducts> Products
        {
            get
            {

                if (_products == null)
                {

                    using (var db = new DAL.dbDataContext())
                    {
                        _products = new BindingList<DAL.tblProducts>(db.tblProducts.ToList());
                    }
                    DataBaseWatcher.Products = new TableEvents.SqlClient.SqlTableEvents<DAL.tblProducts>(Properties.Settings.Default.sejel_end_projectConnectionString);
                    DataBaseWatcher.Products.OnChanged += DataBaseWatcher.Products_Changed;
                    DataBaseWatcher.Products.Start();
                }
                return _products;
            }
        }
        private static BindingList<DAL.tblAccounts> _Accounts;
        public static BindingList<DAL.tblAccounts> Accounts
        {
            get
            {

                if (_Accounts == null)
                {

                    using (var db = new DAL.dbDataContext())
                    {
                        _Accounts = new BindingList<DAL.tblAccounts>(db.tblAccounts.ToList());
                    }
                    DataBaseWatcher.Accounts = new TableEvents.SqlClient.SqlTableEvents<DAL.tblAccounts>(Properties.Settings.Default.sejel_end_projectConnectionString);
                    DataBaseWatcher.Accounts.OnChanged += DataBaseWatcher.Accounts_Changed;
                    DataBaseWatcher.Accounts.Start();
                }
                return _Accounts;
            }
        }
        private static BindingList<string> _Response;
        public static BindingList<string> Response
        {
            get
            {

                if (_Response == null)
                {

                    _Response = new BindingList<string>();
                  //  _Response.Add("تشغيل الهوست");
                    DataBaseWatcher.Receiving = new TableEvents.SqlClient.SqlTableEvents<DAL.tblReceiving>(Properties.Settings.Default.sejel_end_projectConnectionString);
                    DataBaseWatcher.Receiving.OnChanged += DataBaseWatcher.Receiving_Changed;
                    DataBaseWatcher.Receiving.Start();
                }
                return _Response;
            }
        }
        private static BindingList<DAL.tblSMS_CustomersDirectory> _SMS_CustomersDirectory;
        public static BindingList<DAL.tblSMS_CustomersDirectory> SMS_CustomersDirectory
        {
            get
            {

                if (_SMS_CustomersDirectory == null)
                {

                    //using (var db = new DAL.dbDataContext())
                    //{
                    //    _SMS_CustomersDirectory = new BindingList<DAL.tblSMS_CustomersDirectory>(db.tblSMS_CustomersDirectories.ToList());
                    //}
                    //DataBaseWatcher.SMS_CustomersDirectorys = new TableEvents.SqlClient.SqlTableEvents<DAL.tblSMS_CustomersDirectory>(Properties.Settings.Default.sejel_end_projectConnectionString);
                    //DataBaseWatcher.SMS_CustomersDirectorys.OnChanged += DataBaseWatcher.SMS_CustomersDirectorys_Changed;
                    //DataBaseWatcher.SMS_CustomersDirectorys.Start();
                }
                return _SMS_CustomersDirectory;
            }
        }
        public static class GlobalSettings
        {
            public static Boolean ReadFormScaleBarcode { get => true; }

            public static string ScaleBarcodePrefix { get => "21"; }
            public static byte ProductCodeLength { get => 5; }
            public static byte BarcodeLength { get => 13; }
            public static byte ValueCodeLength { get => 5; }
            public static ReadValueMode ReadMode { get => ReadValueMode.Price; }
            public static Boolean IgnoreCheckDigit { get => true; }
            public static byte DivideValueBy { get => 2; }

            public enum ReadValueMode
            {
                Weight,
                Price,
            }
        }
        private static BindingList<ProductViewClass> productViewClasses;
        public static BindingList<ProductViewClass> ProductsView
        {
            get
            {
               // if (productViewClasses == null)
                {
                    using (var db = new DAL.dbDataContext())
                    {
                        var data = from pr in Session.Products //.ToList();
                                   join cg in db.tblLSTypeProducts on pr.categoryID equals cg.ID
                                   select new ProductViewClass

                                   {
                                       ID = pr.ID,
                                       ProductName = pr.ProductName,
                                       EnglishProductName = pr.EnglishProductName,
                                       CategoryName = cg.Name,
                                       Descreption = pr.ProductDesc,
                                       Status = (pr.Status as bool?) ?? false,
                                       Type = pr.Type,
                                       Notes= pr.Notes,
                                       Units = (from u in db.tblUnits
                                                where u.ProductID == pr.ID
                                                join un in db.tblLSUnits on u.UnitID equals un.ID
                                                select new ProductViewClass.ProductUOMView
                                                {
                                                    UnitID = u.ID,
                                                    UnitName = un.Name,
                                                    Factor = (u.packaging as decimal?) ?? 0,
                                                    PriceCost = (u.PriceCost as decimal?) ?? 0,
                                                    SpecialPrice = (u.SpecialPrice as decimal?) ?? 0,
                                                    DescountValue = (u.DescountValue as decimal?) ?? 0,
                                                    DescountPercent = (u.DescountPercent as decimal?) ?? 0,
                                                    Status = (u.Status as bool?)??false,
                                                    Barcode = u.Barcod,
                                                }).ToList()
                                   };
                        productViewClasses = new BindingList<ProductViewClass>(data.ToList());
                    }
                }
                return productViewClasses;
            }
        }
        public class ProductViewClass
        {
            public static ProductViewClass GetProduct(long id)
            {
                ProductViewClass obj;
                using (var db = new DAL.dbDataContext())
                {
                    var data = from pr in Session.Products
                               where pr.ID == id
                               join cg in db.tblLSTypeProducts on pr.categoryID equals cg.ID
                               select new ProductViewClass
                               {
                                   ID = pr.ID,
                                   ProductName = pr.ProductName,
                                   EnglishProductName = pr.EnglishProductName,
                                   CategoryName = cg.Name,
                                   Descreption = pr.ProductDesc,
                                   Status = (pr.Status as bool?) ?? false,
                                   Type = pr.Type,
                                   Notes = pr.Notes,
                                   Units = (from u in db.tblUnits
                                            where u.ProductID == pr.ID
                                            join un in db.tblLSUnits on u.UnitID equals un.ID
                                            select new ProductViewClass.ProductUOMView
                                            {
                                                UnitID = u.ID,
                                                UnitName = un.Name,
                                                Factor = (u.packaging as decimal?) ?? 0,
                                                PriceCost = (u.PriceCost as decimal?) ?? 0,
                                                SpecialPrice = (u.SpecialPrice as decimal?) ?? 0,
                                                DescountValue = (u.DescountValue as decimal?) ?? 0,
                                                DescountPercent = (u.DescountPercent as decimal?) ?? 0,
                                                Status = (u.Status as bool?) ?? false,
                                                Barcode = u.Barcod,
                                            }).ToList()

                               };
                    obj = data.First();
                };
                return obj;
            }
            
            public long ID { get; set; }
            public string ProductName { get; set; }
            public string EnglishProductName { get; set; }
            public string CategoryName { get; set; }
            public string Descreption { get; set; }
            public Boolean Status { get; set; }
            public long Type { get; set; }
            public string Notes { get; set; }
            public List<ProductUOMView> Units { get; set; }
            public class ProductUOMView
            {
                public long UnitID { get; set; }
                public string UnitName { get; set; }
                public decimal Factor { get; set; }
                public decimal PriceCost { get; set; }
               
                public decimal SpecialPrice { get; set; }
                public decimal DescountValue { get; set; }
                public decimal DescountPercent { get; set; }
                public string Barcode { get; set; }
                public Boolean Status { get; set; }
            }
        }
        private static BindingList<DAL.tblLSUnit> lSUnit;
        public static BindingList<DAL.tblLSUnit> LSUnit
        {
            get
            {

                if (lSUnit == null)
                {
                    using (var db = new DAL.dbDataContext())
                    {
                        lSUnit = new BindingList<DAL.tblLSUnit>(db.tblLSUnits.ToList());
                    }
                }
                return lSUnit;
            }

        }
        private static List<ScreensAccessProfile> _screensAccesses;
        public static List<ScreensAccessProfile> ScreensAccesses
        {

            get
            {

                //if (User.UserType == (byte)Master.UserType.Admin)
                //    return Screens.GetScreens;
                //else
                return _screensAccesses;
            }


        }

    }
}

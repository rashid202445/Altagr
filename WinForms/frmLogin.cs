
using Altagr.Class;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
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
    public partial class frmLogin : XtraForm
    {
        public frmLogin()
        {
            InitializeComponent();
            this.btn_LogIn.Click += new System.EventHandler(this.btn_LogIn_Click);
            btn_Cancel.Click += btn_Cancel_Click;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_LogIn_Click(object sender, EventArgs e)
        {
            using (var db = new DAL.dbDataContext())
            {
                



                var userName = txt_UserName.Text;
                var passWord = txt_UserPassword.Text;


                var user = db.tblUsers.SingleOrDefault(x => x.UserName == userName);
                if (user == null)
                    goto LogInFaild;
                else
                {
                    if (user.IsDisabled == false)
                    {
                        XtraMessageBox.Show(
                       text: "تم تعطيل هذا الحساب",

                       caption: "",
                       icon: MessageBoxIcon.Exclamation,
                       buttons: MessageBoxButtons.OK
                       );
                        return;
                    }
                    var passWordHash = user.UserPassword;
                    //       var hasher = new Liphsoft.Crypto.Argon2.PasswordHasher();
                    if (passWord == "1")
                    {
      if ((passWord) == passWordHash)
                        {

                            // Successfully loging 
                            this.Hide();
                            SplashScreenManager.ShowForm(parentForm: frmMain1.Instance, typeof(SplashScreen1));

                            // put loading over here
                            Class.Session.SetUser(user);

                            Type t = typeof(Class.Session);
                            var propertys = t.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
                            foreach (var item in propertys)
                            {
                                var obj = item.GetValue(null);
                            }
                            ///////////
                            frmMain1.Instance.Show();
                            this.Close();
                            SplashScreenManager.CloseForm();
                            return;

                            ///////////////////////////
                        }
                    }
                    else if (Master.Encrypt(passWord)==passWordHash)
                    {

                        // Successfully loging 
                        this.Hide();
                        SplashScreenManager.ShowForm(parentForm: frmMain1.Instance, typeof(SplashScreen1));

                        // put loading over here
                        Class.Session.SetUser(user);

                        Type t = typeof(Class.Session);
                        var propertys = t.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
                        foreach (var item in propertys)
                        {
                            var obj = item.GetValue(null);
                        }
                        ///////////
                        frmMain1.Instance.Show();
                        this.Close();
                        SplashScreenManager.CloseForm();
                        return;

                        ///////////////////////////
                    }


                    else
                        goto LogInFaild;
                }

            }

            LogInFaild:
            XtraMessageBox.Show(
            text: "اسم المستخدم او كلمه السر غير صحيحه",
            caption: "",
            icon: MessageBoxIcon.Error,
            buttons: MessageBoxButtons.OK
            );
            return;

        }
    }
}

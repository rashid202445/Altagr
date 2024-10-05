﻿using Altagr.Class;
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
    public partial class frmUser : frmMaster
    {
        DAL.tblUser user;
        public frmUser()
        {
            InitializeComponent();
            RefreshData();
            New();
        }

        public frmUser(int id)
        {
            InitializeComponent();
            RefreshData();
            using (var db = new DAL.dbDataContext())
            {
                user = db.tblUsers.SingleOrDefault(x => x.ID == id);
                GetData();
            }
        }

        public override void RefreshData()
        {
            using (var db = new DAL.dbDataContext())
            {
                lkp_ScreenProfileID.IntializeData(db.tblUserAccessProfileNames.Select(x => new { x.ID, x.Name }).ToList());
                lkp_SettingsProfileID.IntializeData(db.tblUserSettingsProfiles.Select(x => new { x.ID, x.Name }).ToList());
                lkp_UserType.IntializeData(Master.UserTypeList);
            }
            base.RefreshData();
        }
        public override void New()
        {
            user = new DAL.tblUser();
            user.IsDisabled = true;
            base.New();
        }
        public override void GetData()
        {
            txt_Name.Text = user.Name;
            txt_UserName.Text = user.UserName;
            txt_PassWord.Text = user.UserPassword;
            lkp_ScreenProfileID.EditValue = user.ScreenProfileID;
            lkp_SettingsProfileID.EditValue = user.SettingsProfileID;
            lkp_UserType.EditValue = user.UserType;
            toggleSwitch1.IsOn = user.IsDisabled;
            base.GetData();
        }
        public override void SetData()
        {

            if (user.UserPassword != txt_PassWord.Text)
            {
               
                txt_PassWord.Text = Master.Encrypt(txt_PassWord.Text);
            }

            user.Name = txt_Name.Text;
            user.UserPassword = txt_PassWord.Text;
            user.UserName = txt_UserName.Text.Trim();
            user.ScreenProfileID = Convert.ToInt32(lkp_ScreenProfileID.EditValue);
            user.SettingsProfileID = Convert.ToInt32(lkp_SettingsProfileID.EditValue);
            user.UserType = Convert.ToByte(lkp_UserType.EditValue);
            user.IsDisabled = toggleSwitch1.IsOn;
            user.EnterTime = DateTime.Now;
            user.UserID = Session.User.ID;
            base.SetData();
        }
        public override void Save()
        {
            using (var db = new DAL.dbDataContext())
            {

                if (user.ID == 0)
                {
                    db.tblUsers.InsertOnSubmit(user);
                }
                else
                {
                    try
                    {
                        // db.tblAccounts.

                        db.tblUsers.Attach(user);
                    }
                    catch
                    {
                        user = db.tblUsers.FirstOrDefault(e1 => e1.ID == user.ID);
                    }
                }
                SetData();
                db.SubmitChanges();
                base.Save();
            }
        }
        public override bool IsDataValid()
        {
            int NumberOfErrors = 0;

            using (var db = new DAL.dbDataContext())
            {
                if (db.tblUsers.Where(x => x.UserName.Trim() == txt_UserName.Text.Trim()
                       && x.ID != user.ID).Count() > 0)
                {
                    NumberOfErrors += 1;
                    txt_UserName.ErrorText = "هذا الاسم مسجل بالفعل";
                }
                if (db.tblUsers.Where(x => x.Name.Trim() == txt_Name.Text.Trim()
                       && x.ID != user.ID).Count() > 0)
                {
                    NumberOfErrors += 1;
                    txt_Name.ErrorText = "هذا الاسم مسجل بالفعل";
                }

            }
            NumberOfErrors += txt_Name.IsTextVailde() ? 0 : 1;
            NumberOfErrors += txt_PassWord.IsTextVailde() ? 0 : 1;
            NumberOfErrors += txt_UserName.IsTextVailde() ? 0 : 1;


            NumberOfErrors += lkp_ScreenProfileID.IsEditValueValidAndNotZero() ? 0 : 1;
            NumberOfErrors += lkp_SettingsProfileID.IsEditValueValidAndNotZero() ? 0 : 1;
            NumberOfErrors += lkp_UserType.IsEditValueValidAndNotZero() ? 0 : 1;

            return (NumberOfErrors == 0);
        }

    }
}

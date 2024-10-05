﻿using Altagr.Class;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
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
    public partial class frmAccessProfile : frmMaster
    {
        DAL.tblUserAccessProfileName profile;
        public frmAccessProfile()
        {
            InitializeComponent();
            New();
            GetData();
        }
        public frmAccessProfile(int id)
        {
            InitializeComponent();
            using (var db = new DAL.dbDataContext())
            {
                profile = db.tblUserAccessProfileNames.SingleOrDefault(x => x.ID == id);

            }
            textEdit1.Text = profile.Name;
            GetData();
        }
        public override void New()
        {
            profile = new DAL.tblUserAccessProfileName();

        }

        private void TreeList1_CustomNodeCellEdit(object sender, DevExpress.XtraTreeList.GetCustomNodeCellEditEventArgs e)
        {
            if (e.Node.Id >= 0)
            {
                var row = treeList1.GetRow(e.Node.Id) as Class.ScreensAccessProfile;
                if (row != null)
                {
                    if (e.Column.FieldName == nameof(ins.CanAdd) &&
                        row.Actions.Contains(Class.Master.Actions.Add) == false)
                    {
                        e.RepositoryItem = new DevExpress.XtraEditors.Repository.RepositoryItem();
                    }
                    else if (e.Column.FieldName == nameof(ins.CanDelete) &&
                       row.Actions.Contains(Class.Master.Actions.Delete) == false)
                    {
                        e.RepositoryItem = new DevExpress.XtraEditors.Repository.RepositoryItem();
                    }
                    else if (e.Column.FieldName == nameof(ins.CanEdit) &&
                     row.Actions.Contains(Class.Master.Actions.Edit) == false)
                    {
                        e.RepositoryItem = new DevExpress.XtraEditors.Repository.RepositoryItem();
                    }
                    else if (e.Column.FieldName == nameof(ins.CanOpen) &&
                     row.Actions.Contains(Class.Master.Actions.Open) == false)
                    {
                        e.RepositoryItem = new DevExpress.XtraEditors.Repository.RepositoryItem();
                    }
                    else if (e.Column.FieldName == nameof(ins.CanPrint) &&
                     row.Actions.Contains(Class.Master.Actions.Print) == false)
                    {
                        e.RepositoryItem = new DevExpress.XtraEditors.Repository.RepositoryItem();
                    }
                    else if (e.Column.FieldName == nameof(ins.CanShow) &&
                     row.Actions.Contains(Class.Master.Actions.Show) == false)
                    {
                        e.RepositoryItem = new DevExpress.XtraEditors.Repository.RepositoryItem();
                    }


                }
            }
        }
        Class.ScreensAccessProfile ins;
        public override void GetData()
        {
            List<Class.ScreensAccessProfile> data;
            using (DAL.dbDataContext db = new DAL.dbDataContext())
            {
                data = (from s in Class.Screens.GetScreens
                        from d in db.tblUserAccessProfileDetails
                        .Where(x => x.ProfileID == profile.ID && x.ScreenID == s.ScreenID).DefaultIfEmpty()
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

            treeList1.DataSource = data;

        }
        
        public override bool IsDataValid()
        {
            int flag = 0;
            if (textEdit1.Text.Trim() == string.Empty)
            {
                flag++;
                textEdit1.ErrorText = Class.Master. ErrorText;

            }

            return (flag == 0);
        }
        public override void Save()
        {
            var db = new DAL.dbDataContext();
            if (profile.ID == 0)
            {
                db.tblUserAccessProfileNames.InsertOnSubmit(profile);
            }
            else
            {
                db.tblUserAccessProfileNames.Attach(profile);
            }
            profile.Name = textEdit1.Text;
            profile.EnterTime = DateTime.Now;

           profile. UserID = Session.User.ID;

            db.SubmitChanges();
            db.tblUserAccessProfileDetails.DeleteAllOnSubmit(
            db.tblUserAccessProfileDetails.Where(x => x.ProfileID == profile.ID)) ;
            db.SubmitChanges();

            var data = treeList1.DataSource as List<ScreensAccessProfile>;
            var dbData = data.Select(s => new DAL.tblUserAccessProfileDetail
            {
                CanAdd = s.CanAdd,
                CanDelete = s.CanDelete,
                CanEdit = s.CanEdit,
                CanOpen = s.CanOpen,
                CanPrint = s.CanPrint,
                CanShow = s.CanShow,
                ProfileID = profile.ID,
                ScreenID = s.ScreenID,
                UserID = Session.User.ID,
                EnterTime = DateTime.Now

            }).ToList();
            db.tblUserAccessProfileDetails.InsertAllOnSubmit(dbData);
            db.SubmitChanges();
            base.Save();
        }
        RepositoryItemCheckEdit repoCheck;
        private void frmAccessProfile_Load(object sender, EventArgs e)
        {
            textEdit1.Text = profile.Name;
            treeList1.CustomNodeCellEdit += TreeList1_CustomNodeCellEdit;
            treeList1.KeyFieldName = nameof(ins.ScreenID);
            treeList1.ParentFieldName = nameof(ins.ParentScreenID);
            treeList1.Columns[nameof(ins.ScreenName)].Visible = false;
            treeList1.Columns[nameof(ins.ScreenName)].OptionsColumn.AllowEdit = false;
            treeList1.Columns[nameof(ins.ScreenCaption)].OptionsColumn.AllowEdit = false;
            treeList1.Columns[nameof(ins.CanAdd)].Caption = "اضافه";
            treeList1.Columns[nameof(ins.CanDelete)].Caption = "حذف";
            treeList1.Columns[nameof(ins.CanEdit)].Caption = "تعديل";
            treeList1.Columns[nameof(ins.CanOpen)].Caption = "فتح";
            treeList1.Columns[nameof(ins.CanPrint)].Caption = "طباعه";
            treeList1.Columns[nameof(ins.CanShow)].Caption = "اظهار";
            treeList1.BestFitColumns();

            repoCheck = new RepositoryItemCheckEdit();
            repoCheck.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.SvgRadio2;
            repoCheck.CheckBoxOptions.SvgColorChecked = DXSkinColors.ForeColors.Information;
            repoCheck.CheckBoxOptions.SvgColorUnchecked = DXSkinColors.ForeColors.DisabledText;

            treeList1.Columns[nameof(ins.CanAdd)].ColumnEdit =
          treeList1.Columns[nameof(ins.CanDelete)].ColumnEdit =
            treeList1.Columns[nameof(ins.CanEdit)].ColumnEdit =
            treeList1.Columns[nameof(ins.CanOpen)].ColumnEdit =
           treeList1.Columns[nameof(ins.CanPrint)].ColumnEdit =
            treeList1.Columns[nameof(ins.CanShow)].ColumnEdit = repoCheck;

            treeList1.Columns[nameof(ins.CanAdd)].Width =
         treeList1.Columns[nameof(ins.CanDelete)].Width =
           treeList1.Columns[nameof(ins.CanEdit)].Width =
           treeList1.Columns[nameof(ins.CanOpen)].Width =
          treeList1.Columns[nameof(ins.CanPrint)].Width =
           treeList1.Columns[nameof(ins.CanShow)].Width = 25;
        }
    }
}
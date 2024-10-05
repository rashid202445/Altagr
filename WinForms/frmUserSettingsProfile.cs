using Altagr.Class;
using DevExpress.Utils.Animation;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
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
    public partial class frmUserSettingsProfile : frmMaster
    {
        DAL.tblUserSettingsProfile profile;
        List<BaseEdit> editors;
        public frmUserSettingsProfile()
        {
            InitializeComponent();
            accordionControl1.ElementClick += AccordionControl1_ElementClick;
            New();
        }
        public frmUserSettingsProfile(long id)
        {
            InitializeComponent();
            accordionControl1.ElementClick += AccordionControl1_ElementClick;
            using (var db = new DAL.dbDataContext())
            {
                profile = db.tblUserSettingsProfiles.Single(x => x.ID == id);
                textEdit1.Text = profile.Name;
                GetData();

            }
        }
        private void AccordionControl1_ElementClick(object sender, DevExpress.XtraBars.Navigation.ElementClickEventArgs e)
        {
            var indx = accordionControl1.Elements.IndexOf(e.Element);
            xtraTabControl1.SelectedTabPageIndex = indx;
        }
        public override void New()
        {
             profile = new DAL.tblUserSettingsProfile();
              textEdit1.Text = profile.Name;
            base.New();
        }
        public override void GetData()
        {

            editors = new List<BaseEdit>();

            Class.UserSettingsTemplate settings = new Class.UserSettingsTemplate(profile.ID);
            accordionControl1.Elements.Clear();
            xtraTabControl1.TabPages.Clear();
            accordionControl1.AllowItemSelection = true;

            var catlog = settings.GetType().GetProperties();
            foreach (var item in catlog)
            {
                accordionControl1.Elements.Add(new DevExpress.XtraBars.Navigation.AccordionControlElement()
                {
                    Name = item.Name,
                    Text = Class.UserSettingsTemplate.GetPropText(item.Name),
                    Style = DevExpress.XtraBars.Navigation.ElementStyle.Item,
                });

                var page = new DevExpress.XtraTab.XtraTabPage()
                { Name = item.Name, Text = Class.UserSettingsTemplate.GetPropText(item.Name) };
                xtraTabControl1.TabPages.Add(page);

                LayoutControl lc = new LayoutControl();


                var props = item.GetValue(settings).GetType().GetProperties();
                foreach (var prop in props)
                {
                    var displayNameAttribute = (prop.CustomAttributes).SingleOrDefault(x => x.AttributeType == typeof(System.ComponentModel.DisplayNameAttribute));
                    var SettingText = "";
                    if (displayNameAttribute != null)
                        SettingText = displayNameAttribute.ConstructorArguments[0].Value.ToString();
                    //if (dt == null)
                    //{
                    //    changes.Add(new SettingInfo(propert.Name, propert.GetValue(settings), ((SettingLevelEnum.BranchLevel)), SettingText));
                    //    continue;
                    //}
                    BaseEdit edit = Class.UserSettingsTemplate.GetPropertyControl(prop.Name, prop.GetValue(item.GetValue(settings)));
                    var layoutItem = lc.AddItem("", edit);
                    layoutItem.TextVisible = true;
                    layoutItem.Text = Class.UserSettingsTemplate.GetPropText(prop.Name);
                    layoutItem.SizeConstraintsType = SizeConstraintsType.Custom;
                    layoutItem.MaxSize = new Size(700, 25);
                    layoutItem.MinSize = new Size(250, 25);
                    editors.Add(edit);
                }
                lc.Dock = DockStyle.Fill;
                page.Controls.Add(lc);
            }
        }
       
        public override bool IsDataValid()
        {
            int flag = 0;
            if (textEdit1.Text.Trim() == string.Empty)
            {
                flag++;
                textEdit1.ErrorText =Master. ErrorText;

            }

            editors.ForEach(e =>
            {
                if (e.GetType() == typeof(LookUpEdit) && ((LookUpEdit)e).Properties.DataSource.GetType() != typeof(List<Master.ValueAndID>))
                    flag += ((LookUpEdit)e).IsEditValueValidAndNotZero() ? 0 : 1;
                // else if (e.GetType() == typeof(LookUpEdit) && ((LookUpEdit)e).Properties.DataSource.GetType() != typeof(Master.ValueAndID))
                //{

                //}

            });
            return (flag == 0);
        }
        public override void Delete()
        {
            var db = new DAL.dbDataContext();
            if (profile.ID != 0)
            {
                db.tblUserSettingsProfileProperties.DeleteAllOnSubmit(
           db.tblUserSettingsProfileProperties.Where(x => x.ProfileID == profile.ID));
                db.SubmitChanges();
                db.tblUserSettingsProfiles.DeleteOnSubmit(profile);
                db.SubmitChanges();
            }
        }
        public override void Save()
        {
            var db = new DAL.dbDataContext();
            if (profile.ID == 0)
            {
                db.tblUserSettingsProfiles.InsertOnSubmit(profile);
            }
            else
            {
                db.tblUserSettingsProfiles.Attach(profile);
            }
            profile.Name = textEdit1.Text;
            profile.EnterTime = DateTime.Now;
            profile.UserID = Session.User.ID;
            db.SubmitChanges();
            db.tblUserSettingsProfileProperties.DeleteAllOnSubmit(
            db.tblUserSettingsProfileProperties.Where(x => x.ProfileID == profile.ID));
            db.SubmitChanges();
            editors.ForEach(e =>
            {
                db.tblUserSettingsProfileProperties.InsertOnSubmit(new DAL.tblUserSettingsProfileProperty()
                {
                    ProfileID = profile.ID,
                    PropertyName = e.Name,
                    PropertyValue = Master.ToByteArray<object>(e.EditValue),
                    UserID= Session.User.ID,
                    EnterTime=DateTime.Now
                });
            });
            db.SubmitChanges();

            base.Save();
        }

        private void frmUserSettingsProfile_Load(object sender, EventArgs e)
        {
            accordionControl1.AnimationType = DevExpress.XtraBars.Navigation.AnimationType.Simple;
            accordionControl1.Appearance.Item.Hovered.Font =
                new Font(accordionControl1.Appearance.Item.Hovered.Font, FontStyle.Bold);
            accordionControl1.Appearance.Item.Hovered.Options.UseFont = true;
            accordionControl1.Appearance.Item.Pressed.Font =
               new Font(accordionControl1.Appearance.Item.Pressed.Font, FontStyle.Bold);

            accordionControl1.Appearance.Item.Pressed.Options.UseFont = true;
            accordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Hidden;
            accordionControl1.OptionsMinimizing.AllowMinimizeMode = DevExpress.Utils.DefaultBoolean.False;
            xtraTabControl1.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            xtraTabControl1.Transition.AllowTransition = DevExpress.Utils.DefaultBoolean.True;
            xtraTabControl1.Transition.EasingMode = DevExpress.Data.Utils.EasingMode.EaseInOut;
            SlideFadeTransition trans = new SlideFadeTransition();
            trans.Parameters.EffectOptions = PushEffectOptions.FromBottom;
            xtraTabControl1.Transition.TransitionType = trans;
            xtraTabControl1.SelectedPageChanging += XtraTabControl1_SelectedPageChanging;
        }

        private void XtraTabControl1_SelectedPageChanging(object sender, DevExpress.XtraTab.TabPageChangingEventArgs e)
        {
            SlideFadeTransition trans = new SlideFadeTransition();
            var currenPage = xtraTabControl1.TabPages.IndexOf(e.Page);
            var PrevPage = xtraTabControl1.TabPages.IndexOf(e.PrevPage);
            if (currenPage > PrevPage)
                trans.Parameters.EffectOptions = PushEffectOptions.FromBottom;
            else
                trans.Parameters.EffectOptions = PushEffectOptions.FromTop;
            xtraTabControl1.Transition.TransitionType = trans;
        }
    }
}

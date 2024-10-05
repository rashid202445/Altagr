
namespace Altagr.WinForms
{
    partial class frmSMS_CustomersDirectory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lkp_AccountID = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.txt_MobileNumbers = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.mem_Notes = new DevExpress.XtraEditors.MemoEdit();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ts_notificationsReceiving = new DevExpress.XtraEditors.ToggleSwitch();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ts_notificationsSpending = new DevExpress.XtraEditors.ToggleSwitch();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ts_notificationsSales = new DevExpress.XtraEditors.ToggleSwitch();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ts_notificationsPurchase = new DevExpress.XtraEditors.ToggleSwitch();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.tgs_SendSMSWithoutBalance = new DevExpress.XtraEditors.ToggleSwitch();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkp_AccountID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MobileNumbers.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mem_Notes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ts_notificationsReceiving.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ts_notificationsSpending.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ts_notificationsSales.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ts_notificationsPurchase.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tgs_SendSMSWithoutBalance.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.tgs_SendSMSWithoutBalance);
            this.layoutControl1.Controls.Add(this.ts_notificationsPurchase);
            this.layoutControl1.Controls.Add(this.ts_notificationsSales);
            this.layoutControl1.Controls.Add(this.ts_notificationsSpending);
            this.layoutControl1.Controls.Add(this.ts_notificationsReceiving);
            this.layoutControl1.Controls.Add(this.txt_MobileNumbers);
            this.layoutControl1.Controls.Add(this.lkp_AccountID);
            this.layoutControl1.Controls.Add(this.mem_Notes);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 24);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(570, 164);
            this.layoutControl1.TabIndex = 4;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem5,
            this.layoutControlItem9,
            this.layoutControlItem10,
            this.layoutControlItem4,
            this.layoutControlItem8});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(570, 164);
            this.Root.TextVisible = false;
            // 
            // lkp_AccountID
            // 
            this.lkp_AccountID.Location = new System.Drawing.Point(245, 12);
            this.lkp_AccountID.Name = "lkp_AccountID";
            this.lkp_AccountID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkp_AccountID.Properties.NullText = "";
            this.lkp_AccountID.Size = new System.Drawing.Size(197, 20);
            this.lkp_AccountID.StyleController = this.layoutControl1;
            this.lkp_AccountID.TabIndex = 4;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.lkp_AccountID;
            this.layoutControlItem1.Location = new System.Drawing.Point(233, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(317, 24);
            this.layoutControlItem1.Text = "اسم الحساب";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(104, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 111);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(550, 33);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // txt_MobileNumbers
            // 
            this.txt_MobileNumbers.Location = new System.Drawing.Point(245, 36);
            this.txt_MobileNumbers.Name = "txt_MobileNumbers";
            this.txt_MobileNumbers.Size = new System.Drawing.Size(197, 20);
            this.txt_MobileNumbers.StyleController = this.layoutControl1;
            this.txt_MobileNumbers.TabIndex = 5;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txt_MobileNumbers;
            this.layoutControlItem2.Location = new System.Drawing.Point(233, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(317, 24);
            this.layoutControlItem2.Text = "رقم الهاتف";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(104, 13);
            // 
            // mem_Notes
            // 
            this.mem_Notes.Location = new System.Drawing.Point(245, 76);
            this.mem_Notes.Name = "mem_Notes";
            this.mem_Notes.Size = new System.Drawing.Size(313, 43);
            this.mem_Notes.StyleController = this.layoutControl1;
            this.mem_Notes.TabIndex = 6;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.mem_Notes;
            this.layoutControlItem3.Location = new System.Drawing.Point(233, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(317, 63);
            this.layoutControlItem3.Text = "ملاحظات";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(104, 13);
            // 
            // ts_notificationsReceiving
            // 
            this.ts_notificationsReceiving.Location = new System.Drawing.Point(12, 36);
            this.ts_notificationsReceiving.Name = "ts_notificationsReceiving";
            this.ts_notificationsReceiving.Properties.OffText = "لا";
            this.ts_notificationsReceiving.Properties.OnText = "نعم";
            this.ts_notificationsReceiving.Size = new System.Drawing.Size(113, 17);
            this.ts_notificationsReceiving.StyleController = this.layoutControl1;
            this.ts_notificationsReceiving.TabIndex = 11;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.ts_notificationsReceiving;
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(233, 24);
            this.layoutControlItem8.Text = "اشعار عند سند قبض";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(104, 13);
            // 
            // ts_notificationsSpending
            // 
            this.ts_notificationsSpending.Location = new System.Drawing.Point(12, 60);
            this.ts_notificationsSpending.Name = "ts_notificationsSpending";
            this.ts_notificationsSpending.Properties.OffText = "لا";
            this.ts_notificationsSpending.Properties.OnText = "نعم";
            this.ts_notificationsSpending.Size = new System.Drawing.Size(113, 17);
            this.ts_notificationsSpending.StyleController = this.layoutControl1;
            this.ts_notificationsSpending.TabIndex = 12;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.ts_notificationsSpending;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(233, 21);
            this.layoutControlItem5.Text = "اشعار عند سند صرف";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(104, 13);
            // 
            // ts_notificationsSales
            // 
            this.ts_notificationsSales.Location = new System.Drawing.Point(12, 81);
            this.ts_notificationsSales.Name = "ts_notificationsSales";
            this.ts_notificationsSales.Properties.OffText = "لا";
            this.ts_notificationsSales.Properties.OnText = "نعم";
            this.ts_notificationsSales.Size = new System.Drawing.Size(113, 17);
            this.ts_notificationsSales.StyleController = this.layoutControl1;
            this.ts_notificationsSales.TabIndex = 13;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.ts_notificationsSales;
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 69);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(233, 21);
            this.layoutControlItem9.Text = "اشعار عند  فاتورة بيع";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(104, 13);
            // 
            // ts_notificationsPurchase
            // 
            this.ts_notificationsPurchase.Location = new System.Drawing.Point(12, 102);
            this.ts_notificationsPurchase.Name = "ts_notificationsPurchase";
            this.ts_notificationsPurchase.Properties.OffText = "لا";
            this.ts_notificationsPurchase.Properties.OnText = "نعم";
            this.ts_notificationsPurchase.Size = new System.Drawing.Size(113, 17);
            this.ts_notificationsPurchase.StyleController = this.layoutControl1;
            this.ts_notificationsPurchase.TabIndex = 14;
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.ts_notificationsPurchase;
            this.layoutControlItem10.Location = new System.Drawing.Point(0, 90);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(233, 21);
            this.layoutControlItem10.Text = "اشعار عند  فاتورة شراء";
            this.layoutControlItem10.TextSize = new System.Drawing.Size(104, 13);
            // 
            // tgs_SendSMSWithoutBalance
            // 
            this.tgs_SendSMSWithoutBalance.Location = new System.Drawing.Point(12, 12);
            this.tgs_SendSMSWithoutBalance.Name = "tgs_SendSMSWithoutBalance";
            this.tgs_SendSMSWithoutBalance.Properties.OffText = "لا";
            this.tgs_SendSMSWithoutBalance.Properties.OnText = "نعم";
            this.tgs_SendSMSWithoutBalance.Size = new System.Drawing.Size(67, 17);
            this.tgs_SendSMSWithoutBalance.StyleController = this.layoutControl1;
            this.tgs_SendSMSWithoutBalance.TabIndex = 15;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.tgs_SendSMSWithoutBalance;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(233, 24);
            this.layoutControlItem4.Text = "إرسال الرسائل بدون رصيد الحساب";
            this.layoutControlItem4.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(157, 13);
            this.layoutControlItem4.TextToControlDistance = 5;
            // 
            // frmSMS_CustomersDirectory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 210);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmSMS_CustomersDirectory";
            this.Text = "دليل حسابات الرسائل القصيرة";
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkp_AccountID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MobileNumbers.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mem_Notes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ts_notificationsReceiving.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ts_notificationsSpending.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ts_notificationsSales.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ts_notificationsPurchase.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tgs_SendSMSWithoutBalance.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.TextEdit txt_MobileNumbers;
        private DevExpress.XtraEditors.LookUpEdit lkp_AccountID;
        private DevExpress.XtraEditors.MemoEdit mem_Notes;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.ToggleSwitch tgs_SendSMSWithoutBalance;
        private DevExpress.XtraEditors.ToggleSwitch ts_notificationsPurchase;
        private DevExpress.XtraEditors.ToggleSwitch ts_notificationsSales;
        private DevExpress.XtraEditors.ToggleSwitch ts_notificationsSpending;
        private DevExpress.XtraEditors.ToggleSwitch ts_notificationsReceiving;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}
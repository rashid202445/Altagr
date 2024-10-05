
namespace Altagr.WinForms
{
    partial class frmAccounts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAccounts));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.cmbAccountReference = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbAccountType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtAccountNumber = new DevExpress.XtraEditors.TextEdit();
            this.txtAccountName = new DevExpress.XtraEditors.TextEdit();
            this.LookFatherName = new DevExpress.XtraEditors.LookUpEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAccountReference.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAccountType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccountNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccountName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LookFatherName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.simpleButton1);
            this.layoutControl1.Controls.Add(this.treeList1);
            this.layoutControl1.Controls.Add(this.cmbAccountReference);
            this.layoutControl1.Controls.Add(this.cmbAccountType);
            this.layoutControl1.Controls.Add(this.txtAccountNumber);
            this.layoutControl1.Controls.Add(this.txtAccountName);
            this.layoutControl1.Controls.Add(this.LookFatherName);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(517, 404);
            this.layoutControl1.TabIndex = 4;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(347, 94);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(158, 22);
            this.simpleButton1.StyleController = this.layoutControl1;
            this.simpleButton1.TabIndex = 10;
            this.simpleButton1.Text = "أضافة معلومات الحساب";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // treeList1
            // 
            this.treeList1.Location = new System.Drawing.Point(12, 120);
            this.treeList1.Name = "treeList1";
            this.treeList1.ShowButtonMode = DevExpress.XtraTreeList.ShowButtonModeEnum.ShowForFocusedRow;
            this.treeList1.Size = new System.Drawing.Size(493, 272);
            this.treeList1.TabIndex = 9;
            // 
            // cmbAccountReference
            // 
            this.cmbAccountReference.Location = new System.Drawing.Point(12, 60);
            this.cmbAccountReference.Name = "cmbAccountReference";
            this.cmbAccountReference.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbAccountReference.Properties.Items.AddRange(new object[] {
            "الميزانية العمومية",
            "حساب الأرباح والخسائر"});
            this.cmbAccountReference.Size = new System.Drawing.Size(155, 20);
            this.cmbAccountReference.StyleController = this.layoutControl1;
            this.cmbAccountReference.TabIndex = 8;
            // 
            // cmbAccountType
            // 
            this.cmbAccountType.Location = new System.Drawing.Point(260, 60);
            this.cmbAccountType.Name = "cmbAccountType";
            this.cmbAccountType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbAccountType.Properties.Items.AddRange(new object[] {
            "رئيسي",
            "فرعي"});
            this.cmbAccountType.Size = new System.Drawing.Size(156, 20);
            this.cmbAccountType.StyleController = this.layoutControl1;
            this.cmbAccountType.TabIndex = 7;
            this.cmbAccountType.EditValueChanged += new System.EventHandler(this.LookFatherName_Leave);
            // 
            // txtAccountNumber
            // 
            this.txtAccountNumber.Location = new System.Drawing.Point(12, 36);
            this.txtAccountNumber.Name = "txtAccountNumber";
            this.txtAccountNumber.Properties.ReadOnly = true;
            this.txtAccountNumber.Size = new System.Drawing.Size(155, 20);
            this.txtAccountNumber.StyleController = this.layoutControl1;
            this.txtAccountNumber.TabIndex = 6;
            // 
            // txtAccountName
            // 
            this.txtAccountName.Location = new System.Drawing.Point(260, 36);
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.Size = new System.Drawing.Size(156, 20);
            this.txtAccountName.StyleController = this.layoutControl1;
            this.txtAccountName.TabIndex = 5;
            // 
            // LookFatherName
            // 
            this.LookFatherName.Location = new System.Drawing.Point(12, 12);
            this.LookFatherName.Name = "LookFatherName";
            this.LookFatherName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.LookFatherName.Properties.NullText = "";
            this.LookFatherName.Size = new System.Drawing.Size(404, 20);
            this.LookFatherName.StyleController = this.layoutControl1;
            this.LookFatherName.TabIndex = 4;
            this.LookFatherName.EditValueChanged += new System.EventHandler(this.LookFatherName_Leave);
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
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.emptySpaceItem2});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(517, 404);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.LookFatherName;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(497, 24);
            this.layoutControlItem1.Text = "الحساب الاب";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(77, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 72);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(497, 10);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtAccountName;
            this.layoutControlItem2.Location = new System.Drawing.Point(248, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(249, 24);
            this.layoutControlItem2.Text = "اسم الحساب";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(77, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtAccountNumber;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(248, 24);
            this.layoutControlItem3.Text = "رقم الحساب";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(77, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.cmbAccountType;
            this.layoutControlItem4.Location = new System.Drawing.Point(248, 48);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(249, 24);
            this.layoutControlItem4.Text = "نوع الحساب";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(77, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.cmbAccountReference;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(248, 24);
            this.layoutControlItem5.Text = "الحساب الختامي";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(77, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.treeList1;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 108);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(497, 276);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.simpleButton1;
            this.layoutControlItem7.Location = new System.Drawing.Point(335, 82);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(162, 26);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 82);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(335, 26);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.layoutControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(517, 404);
            this.panel1.TabIndex = 5;
            // 
            // frmAccounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 450);
            this.Controls.Add(this.panel1);
            this.IconOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("frmAccounts.IconOptions.SvgImage")));
            this.Name = "frmAccounts";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "الحسابات";
            this.Load += new System.EventHandler(this.frmAccounts_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAccountReference.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAccountType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccountNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccountName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LookFatherName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cmbAccountReference;
        private DevExpress.XtraEditors.ComboBoxEdit cmbAccountType;
        private DevExpress.XtraEditors.TextEdit txtAccountNumber;
        private DevExpress.XtraEditors.TextEdit txtAccountName;
        private DevExpress.XtraEditors.LookUpEdit LookFatherName;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private System.Windows.Forms.Panel panel1;
    }
}

namespace Altagr.WinForms
{
    partial class frmCurrencies
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCurrencies));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.txtMinPrice = new DevExpress.XtraEditors.CalcEdit();
            this.txtMaxPrice = new DevExpress.XtraEditors.CalcEdit();
            this.txtPrice = new DevExpress.XtraEditors.CalcEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.swhType = new DevExpress.XtraEditors.ToggleSwitch();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.txtEnglishCode = new DevExpress.XtraEditors.TextEdit();
            this.txtArabicCode = new DevExpress.XtraEditors.TextEdit();
            this.txtCurrencyName = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMinPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaxPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.swhType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEnglishCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArabicCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCurrencyName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Controls.Add(this.groupBox1);
            this.layoutControl1.Controls.Add(this.swhType);
            this.layoutControl1.Controls.Add(this.txtNotes);
            this.layoutControl1.Controls.Add(this.txtEnglishCode);
            this.layoutControl1.Controls.Add(this.txtArabicCode);
            this.layoutControl1.Controls.Add(this.txtCurrencyName);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 24);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(565, 404);
            this.layoutControl1.TabIndex = 4;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.layoutControl2);
            this.groupBox1.Location = new System.Drawing.Point(12, 142);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(541, 52);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.txtMinPrice);
            this.layoutControl2.Controls.Add(this.txtMaxPrice);
            this.layoutControl2.Controls.Add(this.txtPrice);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(3, 16);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl2.Root = this.layoutControlGroup1;
            this.layoutControl2.Size = new System.Drawing.Size(535, 33);
            this.layoutControl2.TabIndex = 0;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // txtMinPrice
            // 
            this.txtMinPrice.Location = new System.Drawing.Point(3, 3);
            this.txtMinPrice.Name = "txtMinPrice";
            this.txtMinPrice.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtMinPrice.Size = new System.Drawing.Size(92, 20);
            this.txtMinPrice.StyleController = this.layoutControl2;
            this.txtMinPrice.TabIndex = 9;
            // 
            // txtMaxPrice
            // 
            this.txtMaxPrice.Location = new System.Drawing.Point(181, 3);
            this.txtMaxPrice.Name = "txtMaxPrice";
            this.txtMaxPrice.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtMaxPrice.Size = new System.Drawing.Size(92, 20);
            this.txtMaxPrice.StyleController = this.layoutControl2;
            this.txtMaxPrice.TabIndex = 8;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(359, 3);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtPrice.Size = new System.Drawing.Size(91, 20);
            this.txtPrice.StyleController = this.layoutControl2;
            this.txtPrice.TabIndex = 7;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem11,
            this.layoutControlItem6,
            this.layoutControlItem8});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(535, 33);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.txtPrice;
            this.layoutControlItem11.ControlAlignment = System.Drawing.ContentAlignment.TopRight;
            this.layoutControlItem11.CustomizationFormText = "سعر التحويل";
            this.layoutControlItem11.Location = new System.Drawing.Point(356, 0);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(177, 31);
            this.layoutControlItem11.Text = "سعر التحويل";
            this.layoutControlItem11.TextSize = new System.Drawing.Size(79, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txtMaxPrice;
            this.layoutControlItem6.Location = new System.Drawing.Point(178, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(178, 31);
            this.layoutControlItem6.Text = "أعلى سعر تحويل";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(79, 13);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.txtMinPrice;
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(178, 31);
            this.layoutControlItem8.Text = "أدنئ سعر تحويل";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(79, 13);
            // 
            // swhType
            // 
            this.swhType.Location = new System.Drawing.Point(12, 121);
            this.swhType.Name = "swhType";
            this.swhType.Properties.OffText = "لا";
            this.swhType.Properties.OnText = "نعم";
            this.swhType.Size = new System.Drawing.Size(477, 17);
            this.swhType.StyleController = this.layoutControl1;
            this.swhType.TabIndex = 9;
            this.swhType.Toggled += new System.EventHandler(this.toggleSwitch1_Toggled);
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(12, 76);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(541, 41);
            this.txtNotes.TabIndex = 8;
            // 
            // txtEnglishCode
            // 
            this.txtEnglishCode.Location = new System.Drawing.Point(12, 36);
            this.txtEnglishCode.Name = "txtEnglishCode";
            this.txtEnglishCode.Size = new System.Drawing.Size(204, 20);
            this.txtEnglishCode.StyleController = this.layoutControl1;
            this.txtEnglishCode.TabIndex = 6;
            // 
            // txtArabicCode
            // 
            this.txtArabicCode.Location = new System.Drawing.Point(284, 36);
            this.txtArabicCode.Name = "txtArabicCode";
            this.txtArabicCode.Size = new System.Drawing.Size(205, 20);
            this.txtArabicCode.StyleController = this.layoutControl1;
            this.txtArabicCode.TabIndex = 5;
            // 
            // txtCurrencyName
            // 
            this.txtCurrencyName.Location = new System.Drawing.Point(12, 12);
            this.txtCurrencyName.Name = "txtCurrencyName";
            this.txtCurrencyName.Size = new System.Drawing.Size(477, 20);
            this.txtCurrencyName.StyleController = this.layoutControl1;
            this.txtCurrencyName.TabIndex = 4;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem7,
            this.layoutControlItem5,
            this.layoutControlItem9});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(565, 404);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtCurrencyName;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(545, 24);
            this.layoutControlItem1.Text = "اسم العملة";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(61, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtArabicCode;
            this.layoutControlItem2.Location = new System.Drawing.Point(272, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(273, 24);
            this.layoutControlItem2.Text = "الرمز العربي";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(61, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtEnglishCode;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(272, 24);
            this.layoutControlItem3.Text = "الرمز الأجنبي";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(61, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.swhType;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 109);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(545, 21);
            this.layoutControlItem4.Text = "عملة محلية";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(61, 13);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.groupBox1;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 130);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(545, 56);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtNotes;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(545, 61);
            this.layoutControlItem5.Text = "الملاحظة";
            this.layoutControlItem5.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(61, 13);
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(12, 198);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(541, 194);
            this.gridControl1.TabIndex = 12;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.gridControl1;
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 186);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(545, 198);
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            // 
            // frmCurrencies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 450);
            this.Controls.Add(this.layoutControl1);
            this.IconOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("frmCurrencies.IconOptions.SvgImage")));
            this.Name = "frmCurrencies";
            this.Text = "العملات";
            this.Load += new System.EventHandler(this.frmCurrencies_Load);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtMinPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaxPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.swhType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEnglishCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArabicCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCurrencyName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.ToggleSwitch swhType;
        private System.Windows.Forms.TextBox txtNotes;
        private DevExpress.XtraEditors.TextEdit txtEnglishCode;
        private DevExpress.XtraEditors.TextEdit txtArabicCode;
        private DevExpress.XtraEditors.TextEdit txtCurrencyName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraEditors.CalcEdit txtMinPrice;
        private DevExpress.XtraEditors.CalcEdit txtMaxPrice;
        private DevExpress.XtraEditors.CalcEdit txtPrice;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
    }
}
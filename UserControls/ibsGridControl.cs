using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using DevExpress.Utils;
using DevExpress.Utils.Design.DataAccess;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using DevExpress.Accessibility;
using DevExpress.Data;
using DevExpress.Data.Filtering;
using DevExpress.Data.Helpers;
using DevExpress.Data.Internal;
using DevExpress.LookAndFeel;
using DevExpress.UIAutomation;
using DevExpress.Utils.About;
using DevExpress.Utils.Controls;
using DevExpress.Utils.Design;
using DevExpress.Utils.DirectXPaint;
using DevExpress.Utils.DPI;
using DevExpress.Utils.Drawing;
using DevExpress.Utils.Drawing.Helpers;
using DevExpress.Utils.Gesture;
using DevExpress.Utils.Helpers;
using DevExpress.Utils.Internal;
using DevExpress.Utils.Menu;
using DevExpress.Utils.Paint;
using DevExpress.Utils.Serializing;
using DevExpress.Utils.WXPaint;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Annotations;
using DevExpress.XtraEditors.Container;
using DevExpress.XtraEditors.Filtering;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Senders;
using DevExpress.XtraGrid.Blending;
using DevExpress.XtraGrid.CodedUISupport;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Dragging;
using DevExpress.XtraGrid.FilterEditor;
using DevExpress.XtraGrid.Helpers;
using DevExpress.XtraGrid.Printing;
using DevExpress.XtraGrid.Registrator;
using DevExpress.XtraGrid.Repository;
using DevExpress.XtraGrid.Scrolling;
using DevExpress.XtraGrid.SearchControl;
using DevExpress.XtraGrid.ToolboxIcons;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Base.Handler;
using DevExpress.XtraGrid.Views.Base.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Items;
using DevExpress.XtraLayout;
using DevExpress.XtraPrinting;

namespace Altagr.UserControls
{
    //[Designer(typeof(ControlDesigner))]
    [DXToolboxItem(true)]
    [Designer("DevExpress.XtraGrid.Design.GridControlDesigner, DevExpress.XtraGrid.v22.2.Design", "System.ComponentModel.Design.IDesigner, System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
    [Docking(DockingBehavior.Ask)]
    [ComplexBindingProperties("DataSource", "DataMember")]
    [Description("A data-aware control that displays data in one of several views, enables editing data, provides data filtering, sorting, grouping and summary calculation features.")]
    [ToolboxTabName("DX.22.2: Data & Analytics")]
    //[LicenseProvider(typeof(DXWinLicenseProvider))]
    [DataAccessMetadata("All", SupportedProcessingModes = "All")]
    //[ToolboxBitmap(typeof(ToolboxIconsRootNS), "GridControl.bmp")]
    [Designer(typeof(ControlDesigner))]
    public class ibsGridControl : DevExpress.XtraGrid.GridControl
    {

    }
}

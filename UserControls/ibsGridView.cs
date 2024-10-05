using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DevExpress.Accessibility;
using DevExpress.Data;
using DevExpress.Data.Details;
using DevExpress.Data.Filtering;
using DevExpress.Data.Filtering.Helpers;
using DevExpress.Data.Helpers;
using DevExpress.Data.Summary;
using DevExpress.Export;
using DevExpress.Portable.Input;
using DevExpress.Skins;
using DevExpress.Utils;
using DevExpress.Utils.Controls;
using DevExpress.Utils.DirectXPaint;
using DevExpress.Utils.DPI;
using DevExpress.Utils.Drawing;
using DevExpress.Utils.Drawing.Animation;
using DevExpress.Utils.Editors;
using DevExpress.Utils.Gesture;
using DevExpress.Utils.Paint;
using DevExpress.Utils.Serializing;
using DevExpress.Utils.Serializing.Helpers;
using DevExpress.Utils.Text;
using DevExpress.Utils.Text.Internal;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Annotations;
using DevExpress.XtraEditors.Container;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.Helpers;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Selection;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraExport;
using DevExpress.XtraExport.Helpers;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms.Design;
using DevExpress.XtraGrid.Accessibility;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Dragging;
using DevExpress.XtraGrid.Drawing;
using DevExpress.XtraGrid.EditForm.Helpers;
using DevExpress.XtraGrid.Export;
using DevExpress.XtraGrid.FilterEditor;
using DevExpress.XtraGrid.Frames;
using DevExpress.XtraGrid.Helpers;
using DevExpress.XtraGrid.Helpers.Indexes;
using DevExpress.XtraGrid.Internal;
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Scrolling;
using DevExpress.XtraGrid.Tab;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Base.ViewInfo;
using DevExpress.XtraGrid.Views.Grid.Customization;
using DevExpress.XtraGrid.Views.Grid.Drawing;
using DevExpress.XtraGrid.Views.Grid.Handler;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Printing;
using DevExpress.XtraPrinting;
using DevExpress.XtraTab.ViewInfo;

namespace Altagr.UserControls
{
    //[Designer(typeof(ControlDesigner))]
    [DesignTimeVisible(false)]
    [ToolboxItem(false)]
    [Designer("DevExpress.XtraGrid.Design.GridViewComponentDesigner, DevExpress.XtraGrid.v22.2.Design", "System.ComponentModel.Design.IDesigner, System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
    [Designer(typeof(ControlDesigner))]
    public class ibsGridView : DevExpress.XtraGrid.Views.Grid.GridView
    {

    }
}

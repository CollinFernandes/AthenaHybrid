﻿#pragma checksum "..\..\..\..\..\..\FrontEnd\Controls\DashboardItem.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D36D868AA4F0D9BBDDC0F85DE7A173DF2FA52C8A"
//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using Athena_Hybrid.FrontEnd.Controls;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using Wpf.Ui;
using Wpf.Ui.Common;
using Wpf.Ui.Controls;
using Wpf.Ui.Converters;
using Wpf.Ui.Markup;
using Wpf.Ui.ValidationRules;


namespace Athena_Hybrid.FrontEnd.Controls {
    
    
    /// <summary>
    /// DashboardItem
    /// </summary>
    public partial class DashboardItem : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 65 "..\..\..\..\..\..\FrontEnd\Controls\DashboardItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border border;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\..\..\..\FrontEnd\Controls\DashboardItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Wpf.Ui.Controls.SymbolIcon HeaderIcon;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\..\..\..\FrontEnd\Controls\DashboardItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label HeaderText;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\..\..\..\FrontEnd\Controls\DashboardItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock SubtitleText;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.10.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Athena Hybrid;component/frontend/controls/dashboarditem.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\FrontEnd\Controls\DashboardItem.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.10.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.border = ((System.Windows.Controls.Border)(target));
            
            #line 65 "..\..\..\..\..\..\FrontEnd\Controls\DashboardItem.xaml"
            this.border.MouseEnter += new System.Windows.Input.MouseEventHandler(this.HoverIn);
            
            #line default
            #line hidden
            
            #line 65 "..\..\..\..\..\..\FrontEnd\Controls\DashboardItem.xaml"
            this.border.MouseLeave += new System.Windows.Input.MouseEventHandler(this.HoverOut);
            
            #line default
            #line hidden
            return;
            case 2:
            this.HeaderIcon = ((Wpf.Ui.Controls.SymbolIcon)(target));
            return;
            case 3:
            this.HeaderText = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.SubtitleText = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


﻿#pragma checksum "..\..\..\..\Controls\itemControl.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "59D389A0E1F1D2BDFFD90998478FB8F941A048F5"
//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using Athena_Locker.Controls;
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


namespace Athena_Locker.Controls {
    
    
    /// <summary>
    /// itemControl
    /// </summary>
    public partial class itemControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 67 "..\..\..\..\Controls\itemControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grid;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\..\Controls\itemControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border Border;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\..\Controls\itemControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Rarity;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\..\Controls\itemControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image cosmeticIcon;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\..\Controls\itemControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Description;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\..\Controls\itemControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Name;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\..\Controls\itemControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Wpf.Ui.Controls.Badge ConvertedIcon;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\..\Controls\itemControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Wpf.Ui.Controls.SymbolIcon favoriteIcon;
        
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
            System.Uri resourceLocater = new System.Uri("/Athena Locker;component/controls/itemcontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Controls\itemControl.xaml"
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
            this.grid = ((System.Windows.Controls.Grid)(target));
            
            #line 67 "..\..\..\..\Controls\itemControl.xaml"
            this.grid.MouseEnter += new System.Windows.Input.MouseEventHandler(this.grid_MouseEnter);
            
            #line default
            #line hidden
            
            #line 67 "..\..\..\..\Controls\itemControl.xaml"
            this.grid.MouseLeave += new System.Windows.Input.MouseEventHandler(this.grid_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Border = ((System.Windows.Controls.Border)(target));
            return;
            case 3:
            this.Rarity = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            this.cosmeticIcon = ((System.Windows.Controls.Image)(target));
            return;
            case 5:
            this.Description = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.Name = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.ConvertedIcon = ((Wpf.Ui.Controls.Badge)(target));
            return;
            case 8:
            this.favoriteIcon = ((Wpf.Ui.Controls.SymbolIcon)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


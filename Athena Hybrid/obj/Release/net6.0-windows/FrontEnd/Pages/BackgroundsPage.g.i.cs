﻿#pragma checksum "..\..\..\..\..\FrontEnd\Pages\BackgroundsPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3CA826915EFF305C730A5E4F082921DA4363F9BE"
//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using Athena_Hybrid.FrontEnd.Pages;
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


namespace Athena_Hybrid.FrontEnd.Pages {
    
    
    /// <summary>
    /// BackgroundsPage
    /// </summary>
    public partial class BackgroundsPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\..\..\FrontEnd\Pages\BackgroundsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WrapPanel publicBackgrounds;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\..\FrontEnd\Pages\BackgroundsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image previewImage;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\..\FrontEnd\Pages\BackgroundsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Wpf.Ui.Controls.TextBox TextBoxPath;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\..\FrontEnd\Pages\BackgroundsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox backgroundBox;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\..\FrontEnd\Pages\BackgroundsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Wpf.Ui.Controls.Button UseBackground;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\..\FrontEnd\Pages\BackgroundsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid notificationContainer;
        
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
            System.Uri resourceLocater = new System.Uri("/Athena Hybrid;component/frontend/pages/backgroundspage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\FrontEnd\Pages\BackgroundsPage.xaml"
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
            
            #line 9 "..\..\..\..\..\FrontEnd\Pages\BackgroundsPage.xaml"
            ((Athena_Hybrid.FrontEnd.Pages.BackgroundsPage)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.publicBackgrounds = ((System.Windows.Controls.WrapPanel)(target));
            return;
            case 3:
            this.previewImage = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            this.TextBoxPath = ((Wpf.Ui.Controls.TextBox)(target));
            
            #line 23 "..\..\..\..\..\FrontEnd\Pages\BackgroundsPage.xaml"
            this.TextBoxPath.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBoxPath_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.backgroundBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 24 "..\..\..\..\..\FrontEnd\Pages\BackgroundsPage.xaml"
            this.backgroundBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.backgroundBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.UseBackground = ((Wpf.Ui.Controls.Button)(target));
            
            #line 25 "..\..\..\..\..\FrontEnd\Pages\BackgroundsPage.xaml"
            this.UseBackground.Click += new System.Windows.RoutedEventHandler(this.UseBackground_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.notificationContainer = ((System.Windows.Controls.Grid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

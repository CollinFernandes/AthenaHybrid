﻿#pragma checksum "..\..\..\..\..\..\FrontEnd\Windows\KeyWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3E8853FDBAD3286B0A30DCBCB676E521803B1ECB"
//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using AdonisUI.Extensions;
using Athena_Hybrid.FrontEnd.Windows;
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


namespace Athena_Hybrid.FrontEnd.Windows {
    
    
    /// <summary>
    /// KeyWindow
    /// </summary>
    public partial class KeyWindow : Wpf.Ui.Controls.UiWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\..\..\..\..\FrontEnd\Windows\KeyWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox KeyBox;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\..\..\FrontEnd\Windows\KeyWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Wpf.Ui.Controls.Button ContinueBtn;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\..\..\FrontEnd\Windows\KeyWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Wpf.Ui.Controls.Button GetKeyBtn;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\..\..\FrontEnd\Windows\KeyWindow.xaml"
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
            System.Uri resourceLocater = new System.Uri("/Athena Hybrid;component/frontend/windows/keywindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\FrontEnd\Windows\KeyWindow.xaml"
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
            this.KeyBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.ContinueBtn = ((Wpf.Ui.Controls.Button)(target));
            
            #line 33 "..\..\..\..\..\..\FrontEnd\Windows\KeyWindow.xaml"
            this.ContinueBtn.Click += new System.Windows.RoutedEventHandler(this.ContinueBtn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.GetKeyBtn = ((Wpf.Ui.Controls.Button)(target));
            
            #line 35 "..\..\..\..\..\..\FrontEnd\Windows\KeyWindow.xaml"
            this.GetKeyBtn.Click += new System.Windows.RoutedEventHandler(this.GetKeyBtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.notificationContainer = ((System.Windows.Controls.Grid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


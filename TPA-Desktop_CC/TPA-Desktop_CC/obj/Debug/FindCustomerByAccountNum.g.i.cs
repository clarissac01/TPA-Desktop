﻿#pragma checksum "..\..\FindCustomerByAccountNum.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A172C20C24F9AC6633B1A29F0BDB7D00659BB248C1F27A9C1E81870EA61A7C70"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
using TPA_Desktop_CC;


namespace TPA_Desktop_CC {
    
    
    /// <summary>
    /// FindCustomerByAccountNum
    /// </summary>
    public partial class FindCustomerByAccountNum : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\FindCustomerByAccountNum.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label actiontxt;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\FindCustomerByAccountNum.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox accnumtxt;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\FindCustomerByAccountNum.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button a;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\FindCustomerByAccountNum.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\FindCustomerByAccountNum.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox listbox;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\FindCustomerByAccountNum.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button nextbutton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TPA-Desktop_CC;component/findcustomerbyaccountnum.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\FindCustomerByAccountNum.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.actiontxt = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.accnumtxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.a = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\FindCustomerByAccountNum.xaml"
            this.a.Click += new System.Windows.RoutedEventHandler(this.searchButton);
            
            #line default
            #line hidden
            return;
            case 4:
            this.label = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.listbox = ((System.Windows.Controls.ListBox)(target));
            
            #line 29 "..\..\FindCustomerByAccountNum.xaml"
            this.listbox.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.selectfromlistbox);
            
            #line default
            #line hidden
            return;
            case 6:
            this.nextbutton = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\FindCustomerByAccountNum.xaml"
            this.nextbutton.Click += new System.Windows.RoutedEventHandler(this.tonextwindow);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

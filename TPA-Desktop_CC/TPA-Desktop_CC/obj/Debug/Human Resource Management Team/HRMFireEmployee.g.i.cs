﻿#pragma checksum "..\..\..\Human Resource Management Team\HRMFireEmployee.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "EF704045EBBCA58825EC27492F2A36ABDC04CA74C80C7C5E6282F349FBFA4EB5"
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
using TPA_Desktop_CC.Human_Resource_Management_Team;


namespace TPA_Desktop_CC.Human_Resource_Management_Team {
    
    
    /// <summary>
    /// HRMFireEmployee
    /// </summary>
    public partial class HRMFireEmployee : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\..\Human Resource Management Team\HRMFireEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid datagrid;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\Human Resource Management Team\HRMFireEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label employeename;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Human Resource Management Team\HRMFireEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label notxt;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\Human Resource Management Team\HRMFireEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button violationbtn;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\Human Resource Management Team\HRMFireEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label scoretxt;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Human Resource Management Team\HRMFireEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button firebutton_Copy;
        
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
            System.Uri resourceLocater = new System.Uri("/TPA-Desktop_CC;component/human%20resource%20management%20team/hrmfireemployee.xa" +
                    "ml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Human Resource Management Team\HRMFireEmployee.xaml"
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
            this.datagrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.employeename = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.notxt = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            
            #line 28 "..\..\..\Human Resource Management Team\HRMFireEmployee.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.violationbtn = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\Human Resource Management Team\HRMFireEmployee.xaml"
            this.violationbtn.Click += new System.Windows.RoutedEventHandler(this.insertviolation);
            
            #line default
            #line hidden
            return;
            case 6:
            this.scoretxt = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.firebutton_Copy = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\..\Human Resource Management Team\HRMFireEmployee.xaml"
            this.firebutton_Copy.Click += new System.Windows.RoutedEventHandler(this.fire);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


﻿#pragma checksum "..\..\..\ATM\PinConfirmationATM.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B8BACF4A7B908D4235A455A44174D86A5DE4E8B15289EE6C0A654612045AA4DD"
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
    /// PinConfirmationATM
    /// </summary>
    public partial class PinConfirmationATM : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\ATM\PinConfirmationATM.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox pintxt;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\ATM\PinConfirmationATM.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button submit;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\ATM\PinConfirmationATM.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cancel;
        
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
            System.Uri resourceLocater = new System.Uri("/TPA-Desktop_CC;component/atm/pinconfirmationatm.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ATM\PinConfirmationATM.xaml"
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
            this.pintxt = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 2:
            this.submit = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\ATM\PinConfirmationATM.xaml"
            this.submit.Click += new System.Windows.RoutedEventHandler(this.submit_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.cancel = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\ATM\PinConfirmationATM.xaml"
            this.cancel.Click += new System.Windows.RoutedEventHandler(this.CANCEL);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


﻿#pragma checksum "..\..\..\Teller\TellerRate.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D429EB8011CDE6873416B5ADACA1D195A5BFF2D077190046613D69775700F561"
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


namespace TPA_Desktop_CC.Teller {
    
    
    /// <summary>
    /// TellerRate
    /// </summary>
    public partial class TellerRate : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\Teller\TellerRate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button star1;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\Teller\TellerRate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button star2;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\Teller\TellerRate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button star3;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\Teller\TellerRate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button star4;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\Teller\TellerRate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button star5;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\Teller\TellerRate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label employeename;
        
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
            System.Uri resourceLocater = new System.Uri("/TPA-Desktop_CC;component/teller/tellerrate.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Teller\TellerRate.xaml"
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
            
            #line 17 "..\..\..\Teller\TellerRate.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.star1 = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\Teller\TellerRate.xaml"
            this.star1.Click += new System.Windows.RoutedEventHandler(this.clickstar1);
            
            #line default
            #line hidden
            return;
            case 3:
            this.star2 = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\Teller\TellerRate.xaml"
            this.star2.Click += new System.Windows.RoutedEventHandler(this.clickstar2);
            
            #line default
            #line hidden
            return;
            case 4:
            this.star3 = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\Teller\TellerRate.xaml"
            this.star3.Click += new System.Windows.RoutedEventHandler(this.clickstar3);
            
            #line default
            #line hidden
            return;
            case 5:
            this.star4 = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\Teller\TellerRate.xaml"
            this.star4.Click += new System.Windows.RoutedEventHandler(this.clickstar4);
            
            #line default
            #line hidden
            return;
            case 6:
            this.star5 = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\..\Teller\TellerRate.xaml"
            this.star5.Click += new System.Windows.RoutedEventHandler(this.clickstar5);
            
            #line default
            #line hidden
            return;
            case 7:
            this.employeename = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


#pragma checksum "..\..\..\..\Views\RegisterHandlerView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4F0C4152B858299E1CE266F9EA30171D06F2FC4B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Datalagring_Casehandler.Views;
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


namespace Datalagring_Casehandler.Views {
    
    
    /// <summary>
    /// RegisterHandlerView
    /// </summary>
    public partial class RegisterHandlerView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\..\..\Views\RegisterHandlerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbFirstName;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\Views\RegisterHandlerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbLastName;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\Views\RegisterHandlerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnManagerSubmit;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\Views\RegisterHandlerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbManagerError;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\Views\RegisterHandlerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbManagerSuccess;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\Views\RegisterHandlerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbStatus;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\Views\RegisterHandlerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnStatusSubmit;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\Views\RegisterHandlerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbStatusError;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\Views\RegisterHandlerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbStatusSuccess;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Datalagring_Casehandler;component/views/registerhandlerview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\RegisterHandlerView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.tbFirstName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.tbLastName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.BtnManagerSubmit = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\..\Views\RegisterHandlerView.xaml"
            this.BtnManagerSubmit.Click += new System.Windows.RoutedEventHandler(this.BtnManagerSubmit_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.lbManagerError = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.lbManagerSuccess = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.tbStatus = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.BtnStatusSubmit = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\..\Views\RegisterHandlerView.xaml"
            this.BtnStatusSubmit.Click += new System.Windows.RoutedEventHandler(this.BtnStatusSubmit_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.lbStatusError = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.lbStatusSuccess = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


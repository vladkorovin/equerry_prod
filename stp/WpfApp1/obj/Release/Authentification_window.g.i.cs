﻿#pragma checksum "..\..\Authentification_window.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "088B5272AD402A8782FCCA9D0CF8989FC40F10699EFA2C90119A27A3BEE60775"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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
using WpfApp1;


namespace WpfApp1 {
    
    
    /// <summary>
    /// Authentification_window
    /// </summary>
    public partial class Authentification_window : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\Authentification_window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox LDAP_tb;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\Authentification_window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button login_bt;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\Authentification_window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox password_tb;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\Authentification_window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox windows_cb;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\Authentification_window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button update_bt;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp1;component/authentification_window.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Authentification_window.xaml"
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
            this.LDAP_tb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.login_bt = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\Authentification_window.xaml"
            this.login_bt.Click += new System.Windows.RoutedEventHandler(this.login_bt_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.password_tb = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 4:
            this.windows_cb = ((System.Windows.Controls.ComboBox)(target));
            
            #line 18 "..\..\Authentification_window.xaml"
            this.windows_cb.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.windows_cb_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.update_bt = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\Authentification_window.xaml"
            this.update_bt.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


﻿#pragma checksum "..\..\pick_req.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C296854E4AFF4FB71FA8DDE8ACFAC95DB0F28963A8D8BA2B125CB2CE1182B336"
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
using WpfApplication1;


namespace WpfApplication1 {
    
    
    /// <summary>
    /// pick_req
    /// </summary>
    public partial class pick_req : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 32 "..\..\pick_req.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox fio_tb;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\pick_req.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ldap_tb;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\pick_req.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox title_tb;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\pick_req.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_return;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\pick_req.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox req_list;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApplication1;component/pick_req.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\pick_req.xaml"
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
            
            #line 8 "..\..\pick_req.xaml"
            ((WpfApplication1.pick_req)(target)).Activated += new System.EventHandler(this.Window_Activated);
            
            #line default
            #line hidden
            
            #line 8 "..\..\pick_req.xaml"
            ((WpfApplication1.pick_req)(target)).Deactivated += new System.EventHandler(this.Window_Deactivated);
            
            #line default
            #line hidden
            return;
            case 2:
            this.fio_tb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.ldap_tb = ((System.Windows.Controls.TextBox)(target));
            
            #line 34 "..\..\pick_req.xaml"
            this.ldap_tb.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.ldap_tb_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.title_tb = ((System.Windows.Controls.TextBox)(target));
            
            #line 36 "..\..\pick_req.xaml"
            this.title_tb.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.ldap_tb_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btn_return = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\pick_req.xaml"
            this.btn_return.Click += new System.Windows.RoutedEventHandler(this.btn_return_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.req_list = ((System.Windows.Controls.ListBox)(target));
            
            #line 47 "..\..\pick_req.xaml"
            this.req_list.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.req_list_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

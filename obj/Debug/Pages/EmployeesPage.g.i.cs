﻿#pragma checksum "..\..\..\Pages\EmployeesPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "EC144195618A9D9D935672F6FCCA181A49FE1A05E56DC5C572296506CDCDF5B1"
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
using Vet.Pages;


namespace Vet.Pages {
    
    
    /// <summary>
    /// EmployeesPage
    /// </summary>
    public partial class EmployeesPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\Pages\EmployeesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tboxSearch;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\Pages\EmployeesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddEmp;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\Pages\EmployeesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDeleteEmp;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\Pages\EmployeesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSaveEmp;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\Pages\EmployeesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnGoBack;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\Pages\EmployeesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid EmployeesGrid;
        
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
            System.Uri resourceLocater = new System.Uri("/Vet;component/pages/employeespage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\EmployeesPage.xaml"
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
            this.tboxSearch = ((System.Windows.Controls.TextBox)(target));
            
            #line 21 "..\..\..\Pages\EmployeesPage.xaml"
            this.tboxSearch.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.tboxSearch_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnAddEmp = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\..\Pages\EmployeesPage.xaml"
            this.btnAddEmp.Click += new System.Windows.RoutedEventHandler(this.btnAddEmp_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnDeleteEmp = ((System.Windows.Controls.Button)(target));
            
            #line 52 "..\..\..\Pages\EmployeesPage.xaml"
            this.btnDeleteEmp.Click += new System.Windows.RoutedEventHandler(this.btnDeleteEmp_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnSaveEmp = ((System.Windows.Controls.Button)(target));
            
            #line 62 "..\..\..\Pages\EmployeesPage.xaml"
            this.btnSaveEmp.Click += new System.Windows.RoutedEventHandler(this.btnSaveEmp_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnGoBack = ((System.Windows.Controls.Button)(target));
            
            #line 72 "..\..\..\Pages\EmployeesPage.xaml"
            this.btnGoBack.Click += new System.Windows.RoutedEventHandler(this.btnGoBack_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.EmployeesGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


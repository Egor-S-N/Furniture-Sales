﻿#pragma checksum "..\..\..\Pages\CreateUpdateContractsPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9C0315E20B83AF5429F2D9920F3DAB55C8FAD0D82A7FEC90776947654FF09C0C"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using FurnitureSales.Pages;
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


namespace FurnitureSales.Pages {
    
    
    /// <summary>
    /// CreateUpdateContractsPage
    /// </summary>
    public partial class CreateUpdateContractsPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\Pages\CreateUpdateContractsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid ContractsGrid;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Pages\CreateUpdateContractsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DueDate;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\Pages\CreateUpdateContractsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddTypes;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\Pages\CreateUpdateContractsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button butAddToDataBase;
        
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
            System.Uri resourceLocater = new System.Uri("/FurnitureSales;component/pages/createupdatecontractspage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\CreateUpdateContractsPage.xaml"
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
            this.ContractsGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.DueDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 3:
            this.AddTypes = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\Pages\CreateUpdateContractsPage.xaml"
            this.AddTypes.Click += new System.Windows.RoutedEventHandler(this.AddTypes_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.butAddToDataBase = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\Pages\CreateUpdateContractsPage.xaml"
            this.butAddToDataBase.Click += new System.Windows.RoutedEventHandler(this.butAddToDataBase_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


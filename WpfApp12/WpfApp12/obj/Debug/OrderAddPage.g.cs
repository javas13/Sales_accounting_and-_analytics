﻿#pragma checksum "..\..\OrderAddPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4F10FCAF15E661F4814A796C74B625EDFEEC01CCCB5DA7C3747BBF95A5BF433A"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
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
using WpfApp12;


namespace WpfApp12 {
    
    
    /// <summary>
    /// OrderAddPage
    /// </summary>
    public partial class OrderAddPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\OrderAddPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WpfApp12.OrderAddPage OrderPage;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\OrderAddPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Findtxtbox;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\OrderAddPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView productListbox;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\OrderAddPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView productListbox2;
        
        #line default
        #line hidden
        
        
        #line 166 "..\..\OrderAddPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel dateStack;
        
        #line default
        #line hidden
        
        
        #line 174 "..\..\OrderAddPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox datetimetxt;
        
        #line default
        #line hidden
        
        
        #line 175 "..\..\OrderAddPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker datepic;
        
        #line default
        #line hidden
        
        
        #line 177 "..\..\OrderAddPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox HourCmb;
        
        #line default
        #line hidden
        
        
        #line 194 "..\..\OrderAddPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox MinuteCmb;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp12;component/orderaddpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\OrderAddPage.xaml"
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
            this.OrderPage = ((WpfApp12.OrderAddPage)(target));
            return;
            case 2:
            this.Findtxtbox = ((System.Windows.Controls.TextBox)(target));
            
            #line 26 "..\..\OrderAddPage.xaml"
            this.Findtxtbox.GotFocus += new System.Windows.RoutedEventHandler(this.Logintxtbox_GotFocus);
            
            #line default
            #line hidden
            
            #line 26 "..\..\OrderAddPage.xaml"
            this.Findtxtbox.LostFocus += new System.Windows.RoutedEventHandler(this.Findtxtbox_LostFocus);
            
            #line default
            #line hidden
            
            #line 26 "..\..\OrderAddPage.xaml"
            this.Findtxtbox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Findtxtbox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.productListbox = ((System.Windows.Controls.ListView)(target));
            return;
            case 4:
            this.productListbox2 = ((System.Windows.Controls.ListView)(target));
            return;
            case 5:
            
            #line 142 "..\..\OrderAddPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 154 "..\..\OrderAddPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 7:
            this.dateStack = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 8:
            this.datetimetxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.datepic = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 10:
            this.HourCmb = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 11:
            this.MinuteCmb = ((System.Windows.Controls.ComboBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

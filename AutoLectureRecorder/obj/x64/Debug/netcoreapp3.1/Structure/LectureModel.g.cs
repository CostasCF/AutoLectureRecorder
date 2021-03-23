﻿#pragma checksum "..\..\..\..\..\Structure\LectureModel.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6BA6E7D71972CEBF6E80C0AD83BF33E0C6F09357"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AutoLectureRecorder.Structure;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace AutoLectureRecorder.Structure {
    
    
    /// <summary>
    /// LectureModel
    /// </summary>
    public partial class LectureModel : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\..\..\..\Structure\LectureModel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBlockName;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\..\Structure\LectureModel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonDelete;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\..\Structure\LectureModel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.PackIcon ExitIcon;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\..\..\Structure\LectureModel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBlockLink;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\..\..\Structure\LectureModel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBlockStartTime;
        
        #line default
        #line hidden
        
        
        #line 99 "..\..\..\..\..\Structure\LectureModel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBlockEndTime;
        
        #line default
        #line hidden
        
        
        #line 108 "..\..\..\..\..\Structure\LectureModel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox CheckboxYoutube;
        
        #line default
        #line hidden
        
        
        #line 122 "..\..\..\..\..\Structure\LectureModel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox CheckboxEnabled;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/AutoLectureRecorder;component/structure/lecturemodel.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Structure\LectureModel.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.TextBlockName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.ButtonDelete = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\..\..\..\Structure\LectureModel.xaml"
            this.ButtonDelete.Click += new System.Windows.RoutedEventHandler(this.ButtonDelete_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ExitIcon = ((MaterialDesignThemes.Wpf.PackIcon)(target));
            return;
            case 4:
            this.TextBlockLink = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.TextBlockStartTime = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.TextBlockEndTime = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.CheckboxYoutube = ((System.Windows.Controls.CheckBox)(target));
            
            #line 114 "..\..\..\..\..\Structure\LectureModel.xaml"
            this.CheckboxYoutube.Checked += new System.Windows.RoutedEventHandler(this.CheckboxYoutube_Checked);
            
            #line default
            #line hidden
            
            #line 114 "..\..\..\..\..\Structure\LectureModel.xaml"
            this.CheckboxYoutube.Unchecked += new System.Windows.RoutedEventHandler(this.CheckboxYoutube_Unchecked);
            
            #line default
            #line hidden
            return;
            case 8:
            this.CheckboxEnabled = ((System.Windows.Controls.CheckBox)(target));
            
            #line 127 "..\..\..\..\..\Structure\LectureModel.xaml"
            this.CheckboxEnabled.Checked += new System.Windows.RoutedEventHandler(this.CheckboxEnabled_Checked);
            
            #line default
            #line hidden
            
            #line 127 "..\..\..\..\..\Structure\LectureModel.xaml"
            this.CheckboxEnabled.Unchecked += new System.Windows.RoutedEventHandler(this.CheckboxEnabled_Unchecked);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


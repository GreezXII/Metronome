﻿#pragma checksum "..\..\..\SettingsFrame.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "515B56249286C1ED1BD12CD9C55AC558CF7BACDC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Metronome;
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


namespace Metronome {
    
    
    /// <summary>
    /// SettingsFrame
    /// </summary>
    public partial class SettingsFrame : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\..\SettingsFrame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtAccentedBeatFilePath;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\SettingsFrame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSelectAccentedBeatFile;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\SettingsFrame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNormalBeatFilePath;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\SettingsFrame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSelectNormalBeatFile;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\SettingsFrame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnApplySettings;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.9.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Metronome;component/settingsframe.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\SettingsFrame.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.9.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.txtAccentedBeatFilePath = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.btnSelectAccentedBeatFile = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\SettingsFrame.xaml"
            this.btnSelectAccentedBeatFile.Click += new System.Windows.RoutedEventHandler(this.SelectFileDialog);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtNormalBeatFilePath = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.btnSelectNormalBeatFile = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\SettingsFrame.xaml"
            this.btnSelectNormalBeatFile.Click += new System.Windows.RoutedEventHandler(this.SelectFileDialog);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnApplySettings = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\..\SettingsFrame.xaml"
            this.btnApplySettings.Click += new System.Windows.RoutedEventHandler(this.btnApplySettings_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


﻿#pragma checksum "D:\KodServer\VisualStudioProjeleri\IsimSozlugu\IsimSozlugu\GeneralSettingsPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "81A85373AB275A2ED533AB250B52CADB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace IsimSozlugu {
    
    
    public partial class GeneralSettingsPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal Microsoft.Phone.Controls.Pivot pvGeneralSettings;
        
        internal Microsoft.Phone.Controls.PivotItem piBackground;
        
        internal System.Windows.Controls.StackPanel spBackgroundColor;
        
        internal System.Windows.Controls.TextBox lblBackgroundColor;
        
        internal System.Windows.Controls.Button btnBackgroundColor;
        
        internal System.Windows.Controls.TextBox lblBackgroundImage;
        
        internal System.Windows.Controls.Button btnBackgroundImage;
        
        internal System.Windows.Controls.Button btnRemoveBackgroundImage;
        
        internal System.Windows.Controls.TextBox txtSpace;
        
        internal System.Windows.Controls.Button btnResetSettings;
        
        internal Microsoft.Phone.Controls.PivotItem piFont;
        
        internal System.Windows.Controls.StackPanel spFont;
        
        internal System.Windows.Controls.TextBox lblFontFamily;
        
        internal System.Windows.Controls.Button btnFontFamily;
        
        internal System.Windows.Controls.TextBox lblFontSize;
        
        internal System.Windows.Controls.Button btnFontSize;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/IsimSozlugu;component/GeneralSettingsPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.pvGeneralSettings = ((Microsoft.Phone.Controls.Pivot)(this.FindName("pvGeneralSettings")));
            this.piBackground = ((Microsoft.Phone.Controls.PivotItem)(this.FindName("piBackground")));
            this.spBackgroundColor = ((System.Windows.Controls.StackPanel)(this.FindName("spBackgroundColor")));
            this.lblBackgroundColor = ((System.Windows.Controls.TextBox)(this.FindName("lblBackgroundColor")));
            this.btnBackgroundColor = ((System.Windows.Controls.Button)(this.FindName("btnBackgroundColor")));
            this.lblBackgroundImage = ((System.Windows.Controls.TextBox)(this.FindName("lblBackgroundImage")));
            this.btnBackgroundImage = ((System.Windows.Controls.Button)(this.FindName("btnBackgroundImage")));
            this.btnRemoveBackgroundImage = ((System.Windows.Controls.Button)(this.FindName("btnRemoveBackgroundImage")));
            this.txtSpace = ((System.Windows.Controls.TextBox)(this.FindName("txtSpace")));
            this.btnResetSettings = ((System.Windows.Controls.Button)(this.FindName("btnResetSettings")));
            this.piFont = ((Microsoft.Phone.Controls.PivotItem)(this.FindName("piFont")));
            this.spFont = ((System.Windows.Controls.StackPanel)(this.FindName("spFont")));
            this.lblFontFamily = ((System.Windows.Controls.TextBox)(this.FindName("lblFontFamily")));
            this.btnFontFamily = ((System.Windows.Controls.Button)(this.FindName("btnFontFamily")));
            this.lblFontSize = ((System.Windows.Controls.TextBox)(this.FindName("lblFontSize")));
            this.btnFontSize = ((System.Windows.Controls.Button)(this.FindName("btnFontSize")));
        }
    }
}

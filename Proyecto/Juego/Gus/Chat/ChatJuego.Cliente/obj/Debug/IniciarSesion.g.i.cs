﻿#pragma checksum "..\..\IniciarSesion.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "8FB1C1E1823EFF658BEC2301E4E2A800BA82E8C8B2F5B450E5E1950D117BD3C0"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using ChatJuego.Cliente;
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


namespace ChatJuego.Cliente {
    
    
    /// <summary>
    /// IniciarSesion
    /// </summary>
    public partial class IniciarSesion : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 40 "..\..\IniciarSesion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TBUsuario;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\IniciarSesion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox TBContrasenia;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\IniciarSesion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BotonIniciarSesion;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\IniciarSesion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BotonRegistrarseI;
        
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
            System.Uri resourceLocater = new System.Uri("/ChatJuego.Cliente;component/iniciarsesion.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\IniciarSesion.xaml"
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
            this.TBUsuario = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.TBContrasenia = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 54 "..\..\IniciarSesion.xaml"
            this.TBContrasenia.KeyDown += new System.Windows.Input.KeyEventHandler(this.TBContrasenia_KeyDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.BotonIniciarSesion = ((System.Windows.Controls.Button)(target));
            
            #line 66 "..\..\IniciarSesion.xaml"
            this.BotonIniciarSesion.Click += new System.Windows.RoutedEventHandler(this.BotonIniciarSesion_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.BotonRegistrarseI = ((System.Windows.Controls.Button)(target));
            
            #line 74 "..\..\IniciarSesion.xaml"
            this.BotonRegistrarseI.Click += new System.Windows.RoutedEventHandler(this.BotonRegistrarseI_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


﻿#pragma checksum "..\..\RegistroDeJugador.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "747B691929C52BCE76CA8FB20C0532F201EDFE635C4399504568D33FDC9F0EC1"
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
    /// RegistroDeJugador
    /// </summary>
    public partial class RegistroDeJugador : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\RegistroDeJugador.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TBCorreoR;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\RegistroDeJugador.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox TBContraseniaRegistro;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\RegistroDeJugador.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BotonRegistrarse;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\RegistroDeJugador.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox TBContraseniaRegistroConfirmacion;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\RegistroDeJugador.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TBUsuarioR;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\RegistroDeJugador.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BotonCancelarR;
        
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
            System.Uri resourceLocater = new System.Uri("/ChatJuego.Cliente;component/registrodejugador.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\RegistroDeJugador.xaml"
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
            
            #line 1 "..\..\RegistroDeJugador.xaml"
            ((ChatJuego.Cliente.RegistroDeJugador)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TBCorreoR = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.TBContraseniaRegistro = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 4:
            this.BotonRegistrarse = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\RegistroDeJugador.xaml"
            this.BotonRegistrarse.Click += new System.Windows.RoutedEventHandler(this.BotonRegistrarse_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.TBContraseniaRegistroConfirmacion = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 6:
            this.TBUsuarioR = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.BotonCancelarR = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\RegistroDeJugador.xaml"
            this.BotonCancelarR.Click += new System.Windows.RoutedEventHandler(this.BotonCancelar);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


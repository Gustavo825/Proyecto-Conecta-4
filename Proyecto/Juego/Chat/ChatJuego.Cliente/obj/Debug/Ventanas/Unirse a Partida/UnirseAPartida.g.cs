﻿#pragma checksum "..\..\..\..\Ventanas\Unirse a Partida\UnirseAPartida.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "7DBDE82FC5167AD4D80C48D5C5FA5A27201676658AF5A1D9FB6BD059EE884A01"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using ChatJuego.Cliente.Ventanas.Unirse_a_Partida;
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


namespace ChatJuego.Cliente.Ventanas.Unirse_a_Partida {
    
    
    /// <summary>
    /// UnirseAPartida
    /// </summary>
    public partial class UnirseAPartida : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\..\..\Ventanas\Unirse a Partida\UnirseAPartida.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ChatJuego.Cliente.Ventanas.Unirse_a_Partida.UnirseAPartida Ventana_UnirseAPartida;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\Ventanas\Unirse a Partida\UnirseAPartida.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Unirse_A_Partida;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\Ventanas\Unirse a Partida\UnirseAPartida.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Ingresar_Codigo;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\Ventanas\Unirse a Partida\UnirseAPartida.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TBUsuarioInvitacion;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\Ventanas\Unirse a Partida\UnirseAPartida.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Boton_Unirse_A_Partida;
        
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
            System.Uri resourceLocater = new System.Uri("/Conecta 4;component/ventanas/unirse%20a%20partida/unirseapartida.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Ventanas\Unirse a Partida\UnirseAPartida.xaml"
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
            this.Ventana_UnirseAPartida = ((ChatJuego.Cliente.Ventanas.Unirse_a_Partida.UnirseAPartida)(target));
            
            #line 1 "..\..\..\..\Ventanas\Unirse a Partida\UnirseAPartida.xaml"
            this.Ventana_UnirseAPartida.Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Unirse_A_Partida = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.Ingresar_Codigo = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            this.TBUsuarioInvitacion = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            
            #line 26 "..\..\..\..\Ventanas\Unirse a Partida\UnirseAPartida.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BotonDeUnirseAPartida_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Boton_Unirse_A_Partida = ((System.Windows.Controls.Image)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


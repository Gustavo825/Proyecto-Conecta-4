﻿#pragma checksum "..\..\..\..\Ventanas\Enviar Invitacion\EnviarInvitacion.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0F5E513C8B5C62818F26E77B69DF156AE0496CC9CB96BCB0300F5F5B68E09E03"
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
    /// EnviarInvitacion
    /// </summary>
    public partial class EnviarInvitacion : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\..\..\Ventanas\Enviar Invitacion\EnviarInvitacion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ChatJuego.Cliente.EnviarInvitacion Ventana_Envio_Invitacion;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\Ventanas\Enviar Invitacion\EnviarInvitacion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Envio_De_Invitacion;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\Ventanas\Enviar Invitacion\EnviarInvitacion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Ingrese_Usuario;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\Ventanas\Enviar Invitacion\EnviarInvitacion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TBUsuarioInvitacion;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\Ventanas\Enviar Invitacion\EnviarInvitacion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Boton_Enviar_Invitacion;
        
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
            System.Uri resourceLocater = new System.Uri("/Conecta 4;component/ventanas/enviar%20invitacion/enviarinvitacion.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Ventanas\Enviar Invitacion\EnviarInvitacion.xaml"
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
            this.Ventana_Envio_Invitacion = ((ChatJuego.Cliente.EnviarInvitacion)(target));
            
            #line 1 "..\..\..\..\Ventanas\Enviar Invitacion\EnviarInvitacion.xaml"
            this.Ventana_Envio_Invitacion.Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Envio_De_Invitacion = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.Ingrese_Usuario = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            this.TBUsuarioInvitacion = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            
            #line 27 "..\..\..\..\Ventanas\Enviar Invitacion\EnviarInvitacion.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BotonDeEnviarInvitacion_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Boton_Enviar_Invitacion = ((System.Windows.Controls.Image)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


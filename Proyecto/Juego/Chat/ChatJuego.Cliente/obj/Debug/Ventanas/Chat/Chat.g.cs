﻿#pragma checksum "..\..\..\..\Ventanas\Chat\Chat.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "40209001B4568972B288916F91CB2CCF7D5C874337C8F988F17B7FB33B727CCF"
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
    /// Chat
    /// </summary>
    public partial class Chat : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 26 "..\..\..\..\Ventanas\Chat\Chat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Jugadores_Conectados;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\Ventanas\Chat\Chat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Titulo;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\Ventanas\Chat\Chat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer Scroller;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\Ventanas\Chat\Chat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ItemsControl UsuariosConectados;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\..\Ventanas\Chat\Chat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer ScrollerContenido;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\Ventanas\Chat\Chat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ItemsControl PlantillaMensaje;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\..\..\Ventanas\Chat\Chat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ContenidoDelMensaje;
        
        #line default
        #line hidden
        
        
        #line 116 "..\..\..\..\Ventanas\Chat\Chat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BotonEnviar;
        
        #line default
        #line hidden
        
        
        #line 122 "..\..\..\..\Ventanas\Chat\Chat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Boton_Enviar;
        
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
            System.Uri resourceLocater = new System.Uri("/Conecta 4;component/ventanas/chat/chat.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Ventanas\Chat\Chat.xaml"
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
            this.Jugadores_Conectados = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.Titulo = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.Scroller = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            case 4:
            this.UsuariosConectados = ((System.Windows.Controls.ItemsControl)(target));
            return;
            case 6:
            this.ScrollerContenido = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            case 7:
            this.PlantillaMensaje = ((System.Windows.Controls.ItemsControl)(target));
            return;
            case 8:
            this.ContenidoDelMensaje = ((System.Windows.Controls.TextBox)(target));
            
            #line 115 "..\..\..\..\Ventanas\Chat\Chat.xaml"
            this.ContenidoDelMensaje.KeyDown += new System.Windows.Input.KeyEventHandler(this.ContenidoDelMensaje_KeyDown);
            
            #line default
            #line hidden
            return;
            case 9:
            this.BotonEnviar = ((System.Windows.Controls.Button)(target));
            
            #line 116 "..\..\..\..\Ventanas\Chat\Chat.xaml"
            this.BotonEnviar.Click += new System.Windows.RoutedEventHandler(this.BotonEnviar_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.Boton_Enviar = ((System.Windows.Controls.Image)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 5:
            
            #line 49 "..\..\..\..\Ventanas\Chat\Chat.xaml"
            ((System.Windows.Controls.Label)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.ClickEnLabelDeJugador_MouseLeftButtonDown);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}


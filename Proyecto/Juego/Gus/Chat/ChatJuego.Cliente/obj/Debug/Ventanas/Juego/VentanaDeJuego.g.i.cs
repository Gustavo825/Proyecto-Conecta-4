﻿#pragma checksum "..\..\..\..\Ventanas\Juego\VentanaDeJuego.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A00922B88539896EF0927F5F35B84DDDA9A282779D8D59F6F58D91C2A4D398DD"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using ChatJuego.Cliente.Ventanas.Juego;
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


namespace ChatJuego.Cliente.Ventanas.Juego {
    
    
    /// <summary>
    /// VentanaDeJuego
    /// </summary>
    public partial class VentanaDeJuego : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\..\..\Ventanas\Juego\VentanaDeJuego.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BotonSalir;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\Ventanas\Juego\VentanaDeJuego.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BotonChat;
        
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
            System.Uri resourceLocater = new System.Uri("/ChatJuego.Cliente;component/ventanas/juego/ventanadejuego.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Ventanas\Juego\VentanaDeJuego.xaml"
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
            this.BotonSalir = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\..\Ventanas\Juego\VentanaDeJuego.xaml"
            this.BotonSalir.Click += new System.Windows.RoutedEventHandler(this.BotonSalir_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.BotonChat = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\..\..\Ventanas\Juego\VentanaDeJuego.xaml"
            this.BotonChat.Click += new System.Windows.RoutedEventHandler(this.BotonChat_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

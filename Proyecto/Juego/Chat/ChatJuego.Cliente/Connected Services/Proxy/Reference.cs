﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChatJuego.Cliente.Proxy {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Mensaje", Namespace="http://schemas.datacontract.org/2004/07/ChatJuego.Host")]
    [System.SerializableAttribute()]
    public partial class Mensaje : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ContenidoMensajeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime TiempoDeEnvioField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UsuarioEmisorField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UsuarioReceptorField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ContenidoMensaje {
            get {
                return this.ContenidoMensajeField;
            }
            set {
                if ((object.ReferenceEquals(this.ContenidoMensajeField, value) != true)) {
                    this.ContenidoMensajeField = value;
                    this.RaisePropertyChanged("ContenidoMensaje");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime TiempoDeEnvio {
            get {
                return this.TiempoDeEnvioField;
            }
            set {
                if ((this.TiempoDeEnvioField.Equals(value) != true)) {
                    this.TiempoDeEnvioField = value;
                    this.RaisePropertyChanged("TiempoDeEnvio");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UsuarioEmisor {
            get {
                return this.UsuarioEmisorField;
            }
            set {
                if ((object.ReferenceEquals(this.UsuarioEmisorField, value) != true)) {
                    this.UsuarioEmisorField = value;
                    this.RaisePropertyChanged("UsuarioEmisor");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UsuarioReceptor {
            get {
                return this.UsuarioReceptorField;
            }
            set {
                if ((object.ReferenceEquals(this.UsuarioReceptorField, value) != true)) {
                    this.UsuarioReceptorField = value;
                    this.RaisePropertyChanged("UsuarioReceptor");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Jugador", Namespace="http://schemas.datacontract.org/2004/07/ChatJuego.Base_de_datos")]
    [System.SerializableAttribute()]
    public partial class Jugador : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int JugadorIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string contraseniaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string correoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private byte[] imagenUsuarioField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<float> puntajeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string usuarioField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int JugadorId {
            get {
                return this.JugadorIdField;
            }
            set {
                if ((this.JugadorIdField.Equals(value) != true)) {
                    this.JugadorIdField = value;
                    this.RaisePropertyChanged("JugadorId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string contrasenia {
            get {
                return this.contraseniaField;
            }
            set {
                if ((object.ReferenceEquals(this.contraseniaField, value) != true)) {
                    this.contraseniaField = value;
                    this.RaisePropertyChanged("contrasenia");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string correo {
            get {
                return this.correoField;
            }
            set {
                if ((object.ReferenceEquals(this.correoField, value) != true)) {
                    this.correoField = value;
                    this.RaisePropertyChanged("correo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public byte[] imagenUsuario {
            get {
                return this.imagenUsuarioField;
            }
            set {
                if ((object.ReferenceEquals(this.imagenUsuarioField, value) != true)) {
                    this.imagenUsuarioField = value;
                    this.RaisePropertyChanged("imagenUsuario");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<float> puntaje {
            get {
                return this.puntajeField;
            }
            set {
                if ((this.puntajeField.Equals(value) != true)) {
                    this.puntajeField = value;
                    this.RaisePropertyChanged("puntaje");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string usuario {
            get {
                return this.usuarioField;
            }
            set {
                if ((object.ReferenceEquals(this.usuarioField, value) != true)) {
                    this.usuarioField = value;
                    this.RaisePropertyChanged("usuario");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="EstadoDeEnvio", Namespace="http://schemas.datacontract.org/2004/07/ChatJuego.Servicios")]
    public enum EstadoDeEnvio : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Correcto = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        UsuarioNoEncontrado = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Fallido = 2,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="EstadoDeRegistro", Namespace="http://schemas.datacontract.org/2004/07/ChatJuego.Base_de_datos")]
    public enum EstadoDeRegistro : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Correcto = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        FallidoPorCorreo = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        FallidoPorUsuario = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Fallido = 3,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Proxy.IChatServicio", CallbackContract=typeof(ChatJuego.Cliente.Proxy.IChatServicioCallback))]
    public interface IChatServicio {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatServicio/InicializarChat")]
        void InicializarChat();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatServicio/InicializarChat")]
        System.Threading.Tasks.Task InicializarChatAsync();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatServicio/MandarMensaje")]
        void MandarMensaje(ChatJuego.Cliente.Proxy.Mensaje mensaje, ChatJuego.Cliente.Proxy.Jugador jugadorQueMandaMensaje);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatServicio/MandarMensaje")]
        System.Threading.Tasks.Task MandarMensajeAsync(ChatJuego.Cliente.Proxy.Mensaje mensaje, ChatJuego.Cliente.Proxy.Jugador jugadorQueMandaMensaje);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatServicio/MandarMensajePrivado")]
        void MandarMensajePrivado(ChatJuego.Cliente.Proxy.Mensaje mensaje, string nombreJugador, ChatJuego.Cliente.Proxy.Jugador jugadorQueMandaMensaje);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatServicio/MandarMensajePrivado")]
        System.Threading.Tasks.Task MandarMensajePrivadoAsync(ChatJuego.Cliente.Proxy.Mensaje mensaje, string nombreJugador, ChatJuego.Cliente.Proxy.Jugador jugadorQueMandaMensaje);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IChatServicioCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatServicio/RecibirMensaje")]
        void RecibirMensaje(ChatJuego.Cliente.Proxy.Jugador jugador, ChatJuego.Cliente.Proxy.Mensaje mensaje, string[] nombresDeJugadores);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatServicio/ActualizarJugadoresConectados")]
        void ActualizarJugadoresConectados(string[] nombresDeJugadores);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatServicio/MostrarPuntajes")]
        void MostrarPuntajes(ChatJuego.Cliente.Proxy.Jugador[] jugadores);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IChatServicioChannel : ChatJuego.Cliente.Proxy.IChatServicio, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ChatServicioClient : System.ServiceModel.DuplexClientBase<ChatJuego.Cliente.Proxy.IChatServicio>, ChatJuego.Cliente.Proxy.IChatServicio {
        
        public ChatServicioClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public ChatServicioClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public ChatServicioClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ChatServicioClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ChatServicioClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void InicializarChat() {
            base.Channel.InicializarChat();
        }
        
        public System.Threading.Tasks.Task InicializarChatAsync() {
            return base.Channel.InicializarChatAsync();
        }
        
        public void MandarMensaje(ChatJuego.Cliente.Proxy.Mensaje mensaje, ChatJuego.Cliente.Proxy.Jugador jugadorQueMandaMensaje) {
            base.Channel.MandarMensaje(mensaje, jugadorQueMandaMensaje);
        }
        
        public System.Threading.Tasks.Task MandarMensajeAsync(ChatJuego.Cliente.Proxy.Mensaje mensaje, ChatJuego.Cliente.Proxy.Jugador jugadorQueMandaMensaje) {
            return base.Channel.MandarMensajeAsync(mensaje, jugadorQueMandaMensaje);
        }
        
        public void MandarMensajePrivado(ChatJuego.Cliente.Proxy.Mensaje mensaje, string nombreJugador, ChatJuego.Cliente.Proxy.Jugador jugadorQueMandaMensaje) {
            base.Channel.MandarMensajePrivado(mensaje, nombreJugador, jugadorQueMandaMensaje);
        }
        
        public System.Threading.Tasks.Task MandarMensajePrivadoAsync(ChatJuego.Cliente.Proxy.Mensaje mensaje, string nombreJugador, ChatJuego.Cliente.Proxy.Jugador jugadorQueMandaMensaje) {
            return base.Channel.MandarMensajePrivadoAsync(mensaje, nombreJugador, jugadorQueMandaMensaje);
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Proxy.IInvitacionCorreoServicio", CallbackContract=typeof(ChatJuego.Cliente.Proxy.IInvitacionCorreoServicioCallback))]
    public interface IInvitacionCorreoServicio {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IInvitacionCorreoServicio/EnviarInvitacion", ReplyAction="http://tempuri.org/IInvitacionCorreoServicio/EnviarInvitacionResponse")]
        ChatJuego.Cliente.Proxy.EstadoDeEnvio EnviarInvitacion(ChatJuego.Cliente.Proxy.Jugador jugadorInvitado, string codigoPartida, ChatJuego.Cliente.Proxy.Jugador jugadorInvitador);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IInvitacionCorreoServicio/EnviarInvitacion", ReplyAction="http://tempuri.org/IInvitacionCorreoServicio/EnviarInvitacionResponse")]
        System.Threading.Tasks.Task<ChatJuego.Cliente.Proxy.EstadoDeEnvio> EnviarInvitacionAsync(ChatJuego.Cliente.Proxy.Jugador jugadorInvitado, string codigoPartida, ChatJuego.Cliente.Proxy.Jugador jugadorInvitador);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IInvitacionCorreoServicio/MandarCodigoDeRegistro", ReplyAction="http://tempuri.org/IInvitacionCorreoServicio/MandarCodigoDeRegistroResponse")]
        ChatJuego.Cliente.Proxy.EstadoDeEnvio MandarCodigoDeRegistro(string codigoDeRegistro, string correo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IInvitacionCorreoServicio/MandarCodigoDeRegistro", ReplyAction="http://tempuri.org/IInvitacionCorreoServicio/MandarCodigoDeRegistroResponse")]
        System.Threading.Tasks.Task<ChatJuego.Cliente.Proxy.EstadoDeEnvio> MandarCodigoDeRegistroAsync(string codigoDeRegistro, string correo);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IInvitacionCorreoServicioCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IInvitacionCorreoServicio/RecibirMensaje")]
        void RecibirMensaje(ChatJuego.Cliente.Proxy.Jugador jugador, ChatJuego.Cliente.Proxy.Mensaje mensaje, string[] nombresDeJugadores);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IInvitacionCorreoServicio/ActualizarJugadoresConectados")]
        void ActualizarJugadoresConectados(string[] nombresDeJugadores);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IInvitacionCorreoServicio/MostrarPuntajes")]
        void MostrarPuntajes(ChatJuego.Cliente.Proxy.Jugador[] jugadores);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IInvitacionCorreoServicioChannel : ChatJuego.Cliente.Proxy.IInvitacionCorreoServicio, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class InvitacionCorreoServicioClient : System.ServiceModel.DuplexClientBase<ChatJuego.Cliente.Proxy.IInvitacionCorreoServicio>, ChatJuego.Cliente.Proxy.IInvitacionCorreoServicio {
        
        public InvitacionCorreoServicioClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public InvitacionCorreoServicioClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public InvitacionCorreoServicioClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public InvitacionCorreoServicioClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public InvitacionCorreoServicioClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public ChatJuego.Cliente.Proxy.EstadoDeEnvio EnviarInvitacion(ChatJuego.Cliente.Proxy.Jugador jugadorInvitado, string codigoPartida, ChatJuego.Cliente.Proxy.Jugador jugadorInvitador) {
            return base.Channel.EnviarInvitacion(jugadorInvitado, codigoPartida, jugadorInvitador);
        }
        
        public System.Threading.Tasks.Task<ChatJuego.Cliente.Proxy.EstadoDeEnvio> EnviarInvitacionAsync(ChatJuego.Cliente.Proxy.Jugador jugadorInvitado, string codigoPartida, ChatJuego.Cliente.Proxy.Jugador jugadorInvitador) {
            return base.Channel.EnviarInvitacionAsync(jugadorInvitado, codigoPartida, jugadorInvitador);
        }
        
        public ChatJuego.Cliente.Proxy.EstadoDeEnvio MandarCodigoDeRegistro(string codigoDeRegistro, string correo) {
            return base.Channel.MandarCodigoDeRegistro(codigoDeRegistro, correo);
        }
        
        public System.Threading.Tasks.Task<ChatJuego.Cliente.Proxy.EstadoDeEnvio> MandarCodigoDeRegistroAsync(string codigoDeRegistro, string correo) {
            return base.Channel.MandarCodigoDeRegistroAsync(codigoDeRegistro, correo);
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Proxy.IServidor", CallbackContract=typeof(ChatJuego.Cliente.Proxy.IServidorCallback))]
    public interface IServidor {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServidor/Conectarse", ReplyAction="http://tempuri.org/IServidor/ConectarseResponse")]
        bool Conectarse(ChatJuego.Cliente.Proxy.Jugador jugador);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServidor/Conectarse", ReplyAction="http://tempuri.org/IServidor/ConectarseResponse")]
        System.Threading.Tasks.Task<bool> ConectarseAsync(ChatJuego.Cliente.Proxy.Jugador jugador);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServidor/RegistroDeJugador", ReplyAction="http://tempuri.org/IServidor/RegistroDeJugadorResponse")]
        ChatJuego.Cliente.Proxy.EstadoDeRegistro RegistroDeJugador(string usuario, string contrasenia, string correo, byte[] imagenDeJugador);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServidor/RegistroDeJugador", ReplyAction="http://tempuri.org/IServidor/RegistroDeJugadorResponse")]
        System.Threading.Tasks.Task<ChatJuego.Cliente.Proxy.EstadoDeRegistro> RegistroDeJugadorAsync(string usuario, string contrasenia, string correo, byte[] imagenDeJugador);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServidor/ObtenerBytesDeImagenDeJugador", ReplyAction="http://tempuri.org/IServidor/ObtenerBytesDeImagenDeJugadorResponse")]
        byte[] ObtenerBytesDeImagenDeJugador(string usuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServidor/ObtenerBytesDeImagenDeJugador", ReplyAction="http://tempuri.org/IServidor/ObtenerBytesDeImagenDeJugadorResponse")]
        System.Threading.Tasks.Task<byte[]> ObtenerBytesDeImagenDeJugadorAsync(string usuario);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServidor/Desconectarse")]
        void Desconectarse();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServidor/Desconectarse")]
        System.Threading.Tasks.Task DesconectarseAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServidorCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServidor/RecibirMensaje")]
        void RecibirMensaje(ChatJuego.Cliente.Proxy.Jugador jugador, ChatJuego.Cliente.Proxy.Mensaje mensaje, string[] nombresDeJugadores);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServidor/ActualizarJugadoresConectados")]
        void ActualizarJugadoresConectados(string[] nombresDeJugadores);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServidor/MostrarPuntajes")]
        void MostrarPuntajes(ChatJuego.Cliente.Proxy.Jugador[] jugadores);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServidorChannel : ChatJuego.Cliente.Proxy.IServidor, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServidorClient : System.ServiceModel.DuplexClientBase<ChatJuego.Cliente.Proxy.IServidor>, ChatJuego.Cliente.Proxy.IServidor {
        
        public ServidorClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public ServidorClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public ServidorClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ServidorClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ServidorClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public bool Conectarse(ChatJuego.Cliente.Proxy.Jugador jugador) {
            return base.Channel.Conectarse(jugador);
        }
        
        public System.Threading.Tasks.Task<bool> ConectarseAsync(ChatJuego.Cliente.Proxy.Jugador jugador) {
            return base.Channel.ConectarseAsync(jugador);
        }
        
        public ChatJuego.Cliente.Proxy.EstadoDeRegistro RegistroDeJugador(string usuario, string contrasenia, string correo, byte[] imagenDeJugador) {
            return base.Channel.RegistroDeJugador(usuario, contrasenia, correo, imagenDeJugador);
        }
        
        public System.Threading.Tasks.Task<ChatJuego.Cliente.Proxy.EstadoDeRegistro> RegistroDeJugadorAsync(string usuario, string contrasenia, string correo, byte[] imagenDeJugador) {
            return base.Channel.RegistroDeJugadorAsync(usuario, contrasenia, correo, imagenDeJugador);
        }
        
        public byte[] ObtenerBytesDeImagenDeJugador(string usuario) {
            return base.Channel.ObtenerBytesDeImagenDeJugador(usuario);
        }
        
        public System.Threading.Tasks.Task<byte[]> ObtenerBytesDeImagenDeJugadorAsync(string usuario) {
            return base.Channel.ObtenerBytesDeImagenDeJugadorAsync(usuario);
        }
        
        public void Desconectarse() {
            base.Channel.Desconectarse();
        }
        
        public System.Threading.Tasks.Task DesconectarseAsync() {
            return base.Channel.DesconectarseAsync();
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Proxy.ITablaDePuntajes", CallbackContract=typeof(ChatJuego.Cliente.Proxy.ITablaDePuntajesCallback))]
    public interface ITablaDePuntajes {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ITablaDePuntajes/RecuperarPuntajesDeJugadores")]
        void RecuperarPuntajesDeJugadores();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ITablaDePuntajes/RecuperarPuntajesDeJugadores")]
        System.Threading.Tasks.Task RecuperarPuntajesDeJugadoresAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITablaDePuntajesCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ITablaDePuntajes/RecibirMensaje")]
        void RecibirMensaje(ChatJuego.Cliente.Proxy.Jugador jugador, ChatJuego.Cliente.Proxy.Mensaje mensaje, string[] nombresDeJugadores);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ITablaDePuntajes/ActualizarJugadoresConectados")]
        void ActualizarJugadoresConectados(string[] nombresDeJugadores);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ITablaDePuntajes/MostrarPuntajes")]
        void MostrarPuntajes(ChatJuego.Cliente.Proxy.Jugador[] jugadores);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITablaDePuntajesChannel : ChatJuego.Cliente.Proxy.ITablaDePuntajes, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TablaDePuntajesClient : System.ServiceModel.DuplexClientBase<ChatJuego.Cliente.Proxy.ITablaDePuntajes>, ChatJuego.Cliente.Proxy.ITablaDePuntajes {
        
        public TablaDePuntajesClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public TablaDePuntajesClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public TablaDePuntajesClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public TablaDePuntajesClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public TablaDePuntajesClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void RecuperarPuntajesDeJugadores() {
            base.Channel.RecuperarPuntajesDeJugadores();
        }
        
        public System.Threading.Tasks.Task RecuperarPuntajesDeJugadoresAsync() {
            return base.Channel.RecuperarPuntajesDeJugadoresAsync();
        }
    }
}

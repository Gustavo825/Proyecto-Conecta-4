�J
cC:\Users\UV\Desktop\Proyecto-Conecta-4\Proyecto\Juego\Chat\ChatJuego\Base de datos\Autenticacion.cs
	namespace 	
	ChatJuego
 
. 
Base_de_datos !
{ 
public 

class 
Autenticacion 
{		 
public 
Autenticacion 
( 
) 
{ 	
} 	
public 
EstadoDeRegistro 
	Registrar  )
() *
string* 0
usuarioARegistrar1 B
,B C
stringD J!
contraseniaARegistrarK `
,` a
stringb h
correoARegistrari y
,y z
byte{ 
[	 �
]
� �
imagenDeJugador
� �
)
� �
{ 	
EstadoDeRegistro 
estado #
=$ %
EstadoDeRegistro& 6
.6 7
Fallido7 >
;> ?
using 
( 
var 
contexto 
=  !
new" %
JugadorContexto& 5
(5 6
)6 7
)7 8
{ 
var 
	jugadores 
= 
(  !
from! %
jugador& -
in. 0
contexto1 9
.9 :
	jugadores: C
where! &
jugador' .
.. /
usuario/ 6
==7 9
usuarioARegistrar: K
select! '
jugador( /
)/ 0
.0 1
Count1 6
(6 7
)7 8
;8 9
if 
( 
	jugadores 
> 
$num  !
)! "
{   
estado!! 
=!! 
EstadoDeRegistro!! -
.!!- .
FallidoPorUsuario!!. ?
;!!? @
return"" 
estado"" !
;""! "
}## 
	jugadores$$ 
=$$ 
($$ 
from$$ !
jugador$$" )
in$$* ,
contexto$$- 5
.$$5 6
	jugadores$$6 ?
where%%! &
jugador%%' .
.%%. /
correo%%/ 5
==%%6 8
correoARegistrar%%9 I
select&&! '
jugador&&( /
)&&/ 0
.&&0 1
Count&&1 6
(&&6 7
)&&7 8
;&&8 9
if'' 
('' 
	jugadores'' 
>'' 
$num''  !
)''! "
{(( 
estado)) 
=)) 
EstadoDeRegistro)) -
.))- .
FallidoPorCorreo)). >
;))> ?
return** 
estado** !
;**! "
}++ 
var,, 
jugadorRegistrado,, %
=,,& '
contexto,,( 0
.,,0 1
	jugadores,,1 :
.,,: ;
Add,,; >
(,,> ?
new,,? B
Jugador,,C J
(,,J K
),,K L
{,,M N
usuario,,O V
=,,W X
usuarioARegistrar,,Y j
,,,j k
contrasenia,,l w
=,,x y
CifrarContrasenia	,,z �
(
,,� �#
contraseniaARegistrar
,,� �
)
,,� �
,
,,� �
correo
,,� �
=
,,� �
correoARegistrar
,,� �
,
,,� �
puntaje
,,� �
=
,,� �
$num
,,� �
,
,,� �
imagenUsuario
,,� �
=
,,� �
imagenDeJugador
,,� �
}
,,� �
)
,,� �
;
,,� �
contexto-- 
.-- 
SaveChanges-- $
(--$ %
)--% &
;--& '
estado.. 
=.. 
EstadoDeRegistro.. )
...) *
Correcto..* 2
;..2 3
return// 
estado// 
;// 
}00 
}11 	
public99 !
EstadoDeAutenticacion99 $
IniciarSesion99% 2
(992 3
string993 9
usuario99: A
,99A B
string99C I
contrasenia99J U
)99U V
{:: 	!
EstadoDeAutenticacion;; !
estado;;" (
=;;) *!
EstadoDeAutenticacion;;+ @
.;;@ A
Failed;;A G
;;;G H
string<< 
contraseniaCifrada<< %
=<<& '
CifrarContrasenia<<( 9
(<<9 :
contrasenia<<: E
)<<E F
;<<F G
using== 
(== 
var== 
contexto== 
===  !
new==" %
JugadorContexto==& 5
(==5 6
)==6 7
)==7 8
{>> 
var?? 
	jugadores?? 
=?? 
(??  !
from??! %
jugador??& -
in??. 0
contexto??1 9
.??9 :
	jugadores??: C
where@@! &
jugador@@' .
.@@. /
usuario@@/ 6
==@@7 9
usuario@@: A
&&@@B D
jugador@@E L
.@@L M
contrasenia@@M X
==@@Y [
contraseniaCifrada@@\ n
selectAA! '
jugadorAA( /
)AA/ 0
.AA0 1
CountAA1 6
(AA6 7
)AA7 8
;AA8 9
ifBB 
(BB 
	jugadoresBB 
>BB 
$numBB  !
)BB! "
{CC 
estadoDD 
=DD !
EstadoDeAutenticacionDD 2
.DD2 3
CorrectoDD3 ;
;DD; <
}EE 
}FF 
returnGG 
estadoGG 
;GG 
}HH 	
privateOO 
stringOO 
CifrarContraseniaOO (
(OO( )
stringOO) /
contraseniaOO0 ;
)OO; <
{PP 	
usingQQ 
(QQ 
SHA256QQ 

sha256HashQQ $
=QQ% &
SHA256QQ' -
.QQ- .
CreateQQ. 4
(QQ4 5
)QQ5 6
)QQ6 7
{RR 
byteSS 
[SS 
]SS 
bytesSS 
=SS 

sha256HashSS )
.SS) *
ComputeHashSS* 5
(SS5 6
EncodingSS6 >
.SS> ?
UTF8SS? C
.SSC D
GetBytesSSD L
(SSL M
contraseniaSSM X
)SSX Y
)SSY Z
;SSZ [
StringBuilderTT 
builderTT %
=TT& '
newTT( +
StringBuilderTT, 9
(TT9 :
)TT: ;
;TT; <
forUU 
(UU 
intUU 
iUU 
=UU 
$numUU 
;UU 
iUU  !
<UU" #
bytesUU$ )
.UU) *
LengthUU* 0
;UU0 1
iUU2 3
++UU3 5
)UU5 6
{VV 
builderWW 
.WW 
AppendWW "
(WW" #
bytesWW# (
[WW( )
iWW) *
]WW* +
.WW+ ,
ToStringWW, 4
(WW4 5
$strWW5 9
)WW9 :
)WW: ;
;WW; <
}XX 
returnYY 
builderYY 
.YY 
ToStringYY '
(YY' (
)YY( )
;YY) *
}ZZ 
}[[ 	
internalcc 
EstadoDeEliminacioncc $
EliminarJugadorcc% 4
(cc4 5
stringcc5 ;
usuariocc< C
,ccC D
stringccE K
contraseniaccL W
)ccW X
{dd 	
EstadoDeEliminacionee 
estadoee  &
=ee' (
EstadoDeEliminacionee) <
.ee< =
Fallidoee= D
;eeD E
usingff 
(ff 
varff 
contextoff 
=ff  !
newff" %
JugadorContextoff& 5
(ff5 6
)ff6 7
)ff7 8
{gg 
stringhh 
contraseniaCifradahh )
=hh* +
CifrarContraseniahh, =
(hh= >
contraseniahh> I
)hhI J
;hhJ K
varii 
	jugadoresii 
=ii 
(ii  !
fromii! %
jugadorii& -
inii. 0
contextoii1 9
.ii9 :
	jugadoresii: C
wherejj! &
jugadorjj' .
.jj. /
usuariojj/ 6
==jj7 9
usuariojj: A
&&jjB D
jugadorjjE L
.jjL M
contraseniajjM X
==jjY [
contraseniaCifradajj\ n
selectkk! '
jugadorkk( /
)kk/ 0
.kk0 1
Countkk1 6
(kk6 7
)kk7 8
;kk8 9
ifll 
(ll 
	jugadoresll 
>ll 
$numll  !
)ll! "
{mm 
contextonn 
.nn 
	jugadoresnn &
.nn& '
Removenn' -
(nn- .
contextonn. 6
.nn6 7
	jugadoresnn7 @
.nn@ A
SinglennA G
(nnG H
annH I
=>nnJ L
annM N
.nnN O
usuarionnO V
==nnW Y
usuarionnZ a
&&nnb d
anne f
.nnf g
contrasenianng r
==nns u
contraseniaCifrada	nnv �
)
nn� �
)
nn� �
;
nn� �
contextooo 
.oo 
SaveChangesoo (
(oo( )
)oo) *
;oo* +
estadopp 
=pp 
EstadoDeEliminacionpp 0
.pp0 1
Correctopp1 9
;pp9 :
}qq 
elserr 
estadoss 
=ss 
EstadoDeEliminacionss 0
.ss0 1
Fallidoss1 8
;ss8 9
}tt 
returnuu 
estadouu 
;uu 
}vv 	
}ww 
public|| 

enum|| !
EstadoDeAutenticacion|| %
{}} 
Correcto~~ 
=~~ 
$num~~ 
,~~ 
Failed 
}
�� 
}�� �	
WC:\Users\UV\Desktop\Proyecto-Conecta-4\Proyecto\Juego\Chat\ChatJuego\Dominio\Partida.cs
	namespace 	
	ChatJuego
 
. 
Dominio 
{ 
public 

class 
Partida 
{ 
public 
string 
codigoDePartida %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
public 
Jugador 
[ 
] 
	jugadores "
=# $
new% (
Jugador) 0
[0 1
$num1 2
]2 3
;3 4
public

 
Partida

 
(

 
string

 
codigoPartida

 +
,

+ ,
Jugador

- 4
jugadorInvitador

5 E
)

E F
{ 	
this 
. 
codigoDePartida  
=! "
codigoPartida# 0
;0 1
this 
. 
	jugadores 
[ 
$num 
] 
= 
jugadorInvitador  0
;0 1
} 	
} 
} ��
ZC:\Users\UV\Desktop\Proyecto-Conecta-4\Proyecto\Juego\Chat\ChatJuego\Servicios\Servicio.cs
	namespace 	
	ChatJuego
 
. 
Host 
{ 
[ 
ServiceBehavior 
( 
ConcurrencyMode $
=% &
ConcurrencyMode' 6
.6 7
Single7 =
,= >
InstanceContextMode? R
=S T
InstanceContextModeU h
.h i
Singlei o
)o p
]p q
public 

class 
Servicio 
: 
IChatServicio )
,) *%
IInvitacionCorreoServicio+ D
,D E
ITablaDePuntajesF V
,V W
	IServidorX a
{ 
public 
static 

Dictionary  
<  !
IJugadorCallBack! 1
,1 2
Jugador3 :
>: ;
	jugadores< E
=F G
newH K

DictionaryL V
<V W
IJugadorCallBackW g
,g h
Jugadori p
>p q
(q r
)r s
;s t
public 
static 
List 
< 
Partida "
>" #
partidas$ ,
=- .
new/ 2
List3 7
<7 8
Partida8 ?
>? @
(@ A
)A B
;B C
private 
const 
string 
CORREO #
=$ %
$str& G
;G H
private 
const 
string 
SMTP_SERVIDOR *
=+ ,
$str- =
;= >
private 
const 
int 
PUERTO  
=! "
$num# &
;& '
private 
const 
string 
CONTRASENIA (
=) *
$str+ >
;> ?
public "
EstadoDeInicioDeSesion %

Conectarse& 0
(0 1
Jugador1 8
jugador9 @
)@ A
{ 	
Autenticacion 
autenticacion '
=( )
new* -
Autenticacion. ;
(; <
)< =
;= >!
EstadoDeAutenticacion !
estado" (
=) *
autenticacion+ 8
.8 9
IniciarSesion9 F
(F G
jugadorG N
.N O
usuarioO V
,V W
jugadorX _
._ `
contrasenia` k
)k l
;l m
if   
(   
estado   
==   !
EstadoDeAutenticacion   /
.  / 0
Correcto  0 8
)  8 9
{!! 
foreach"" 
("" 
var"" 
jugadorIniciado"" ,
in""- /
	jugadores""0 9
.""9 :
Values"": @
)""@ A
{## 
if$$ 
($$ 
jugador$$ 
.$$  
usuario$$  '
==$$( *
jugadorIniciado$$+ :
.$$: ;
usuario$$; B
)$$B C
{%% 
return'' "
EstadoDeInicioDeSesion'' 5
.''5 6(
FallidoPorUsuarioYaConectado''6 R
;''R S
}(( 
})) 
var** 
conexion** 
=** 
OperationContext** /
.**/ 0
Current**0 7
.**7 8
GetCallbackChannel**8 J
<**J K
IJugadorCallBack**K [
>**[ \
(**\ ]
)**] ^
;**^ _
Console++ 
.++ 
	WriteLine++ !
(++! "
$str++" :
,++: ;
jugador++< C
.++C D
usuario++D K
)++K L
;++L M
	jugadores,, 
.,, 
Add,, 
(,, 
conexion,, &
,,,& '
jugador,,( /
),,/ 0
;,,0 1
return-- "
EstadoDeInicioDeSesion-- -
.--- .
Correcto--. 6
;--6 7
}.. 
else// 
return00 "
EstadoDeInicioDeSesion00 -
.00- .
Fallido00. 5
;005 6
}11 	
public66 
void66 
Desconectarse66 !
(66! "
)66" #
{77 	
var88 
conexion88 
=88 
OperationContext88 +
.88+ ,
Current88, 3
.883 4
GetCallbackChannel884 F
<88F G
IJugadorCallBack88G W
>88W X
(88X Y
)88Y Z
;88Z [
Console99 
.99 
	WriteLine99 
(99 
$str99 9
,999 :
	jugadores99; D
[99D E
conexion99E M
]99M N
.99N O
usuario99O V
)99V W
;99W X
	jugadores:: 
.:: 
Remove:: 
(:: 
conexion:: %
)::% &
;::& '
string;; 
[;; 
];; 
nombresDeJugadores;; '
=;;( )
new;;* -
string;;. 4
[;;4 5
	jugadores;;5 >
.;;> ?
Count;;? D
(;;D E
);;E F
];;F G
;;;G H
var<< 
i<< 
=<< 
$num<< 
;<< 
foreach== 
(== 
Jugador== 
nombre== #
in==$ &
	jugadores==' 0
.==0 1
Values==1 7
)==7 8
{>> 
nombresDeJugadores?? "
[??" #
i??# $
]??$ %
=??& '
nombre??( .
.??. /
usuario??/ 6
;??6 7
i@@ 
++@@ 
;@@ 
}AA 
foreachBB 
(BB 
varBB 

conexionesBB #
inBB$ &
	jugadoresBB' 0
.BB0 1
KeysBB1 5
)BB5 6
{CC 
ifDD 
(DD 

conexionesDD 
==DD !
conexionDD" *
)DD* +
continueEE 
;EE 

conexionesFF 
.FF )
ActualizarJugadoresConectadosFF 8
(FF8 9
nombresDeJugadoresFF9 K
)FFK L
;FFL M
}GG 
}HH 	
publicRR 
EstadoDeEnvioRR 
EnviarInvitacionRR -
(RR- .
JugadorRR. 5
jugadorInvitadoRR6 E
,RRE F
stringRRG M
codigoPartidaRRN [
,RR[ \
JugadorRR] d
jugadorInvitadorRRe u
)RRu v
{SS 	
EstadoDeEnvioTT 
estadoTT  
=TT! "
EstadoDeEnvioTT# 0
.TT0 1
FallidoTT1 8
;TT8 9
usingUU 
(UU 
varUU 
contextoUU 
=UU  !
newUU" %
JugadorContextoUU& 5
(UU5 6
)UU6 7
)UU7 8
{VV 
varWW 
	jugadoresWW 
=WW 
(WW  !
fromWW! %
jugadorWW& -
inWW. 0
contextoWW1 9
.WW9 :
	jugadoresWW: C
whereXX! &
jugadorXX' .
.XX. /
usuarioXX/ 6
==XX7 9
jugadorInvitadoXX: I
.XXI J
usuarioXXJ Q
selectYY! '
jugadorYY( /
)YY/ 0
.YY0 1
CountYY1 6
(YY6 7
)YY7 8
;YY8 9
ifZZ 
(ZZ 
	jugadoresZZ 
==ZZ  
$numZZ! "
)ZZ" #
{[[ 
estado\\ 
=\\ 
EstadoDeEnvio\\ *
.\\* +
UsuarioNoEncontrado\\+ >
;\\> ?
return]] 
estado]] !
;]]! "
}^^ 
jugadorInvitado__ 
.__  
correo__  &
=__' (
(__) *
from__* .
jugador__/ 6
in__7 9
contexto__: B
.__B C
	jugadores__C L
where``* /
jugador``0 7
.``7 8
usuario``8 ?
==``@ B
jugadorInvitado``C R
.``R S
usuario``S Z
selectaa* 0
jugadoraa1 8
.aa8 9
correoaa9 ?
)aa? @
.aa@ A
SingleaaA G
(aaG H
)aaH I
;aaI J
trybb 
{cc 

SmtpClientdd 
smtpClientedd *
=dd+ ,
newdd- 0

SmtpClientdd1 ;
(dd; <
SMTP_SERVIDORdd< I
,ddI J
PUERTOddK Q
)ddQ R
;ddR S
smtpClienteee 
.ee  
	EnableSslee  )
=ee* +
trueee, 0
;ee0 1
smtpClienteff 
.ff  
DeliveryMethodff  .
=ff/ 0
SmtpDeliveryMethodff1 C
.ffC D
NetworkffD K
;ffK L
smtpClientegg 
.gg  !
UseDefaultCredentialsgg  5
=gg6 7
falsegg8 =
;gg= >
smtpClientehh 
.hh  
Credentialshh  +
=hh, -
newhh. 1
NetworkCredentialhh2 C
(hhC D
CORREOhhD J
,hhJ K
CONTRASENIAhhL W
)hhW X
;hhX Y
stringii 
jugadorQueInvitaii +
=ii, -
$strii. 0
;ii0 1
jugadorQueInvitajj $
=jj% &
jugadorInvitadorjj' 7
.jj7 8
usuariojj8 ?
;jj? @
usingkk 
(kk 
MailMessagekk &
mensajekk' .
=kk/ 0
newkk1 4
MailMessagekk5 @
(kk@ A
)kkA B
)kkB C
{ll 
mensajemm 
.mm  
Frommm  $
=mm% &
newmm' *
MailAddressmm+ 6
(mm6 7
CORREOmm7 =
)mm= >
;mm> ?
mensajenn 
.nn  
Subjectnn  '
=nn( )
$strnn* :
+nn; <
jugadorQueInvitann= M
;nnM N
mensajeoo 
.oo  
Bodyoo  $
=oo% &
$stroo' P
+ooQ R
codigoPartidaooS `
;oo` a
mensajepp 
.pp  

IsBodyHtmlpp  *
=pp+ ,
falsepp- 2
;pp2 3
mensajeqq 
.qq  
Toqq  "
.qq" #
Addqq# &
(qq& '
jugadorInvitadoqq' 6
.qq6 7
correoqq7 =
)qq= >
;qq> ?
smtpClienterr #
.rr# $
Sendrr$ (
(rr( )
mensajerr) 0
)rr0 1
;rr1 2
estadoss 
=ss  
EstadoDeEnvioss! .
.ss. /
Correctoss/ 7
;ss7 8
partidastt  
.tt  !
Addtt! $
(tt$ %
newtt% (
Partidatt) 0
(tt0 1
codigoPartidatt1 >
,tt> ?
jugadorInvitadortt@ P
)ttP Q
)ttQ R
;ttR S
}uu 
}ww 
catchxx 
(xx 
	Exceptionxx  
	exceptionxx! *
)xx* +
whenxx, 0
(xx1 2
	exceptionxx2 ;
isxx< >
SmtpExceptionxx? L
||xxM O
	exceptionxxP Y
isxxZ \%
InvalidOperationExceptionxx] v
||yy 
	exceptionyy 
isyy 
FormatExceptionyy -
||yy. 0
	exceptionyy1 :
isyy; =!
ArgumentNullExceptionyy> S
)yyS T
{zz 
estado{{ 
={{ 
EstadoDeEnvio{{ *
.{{* +
Fallido{{+ 2
;{{2 3
Console|| 
.|| 
	WriteLine|| %
(||% &
	exception||& /
.||/ 0

StackTrace||0 :
)||: ;
;||; <
}}} 
}~~ 
return 
estado 
; 
}
�� 	
public
�� 
void
�� 
InicializarChat
�� #
(
��# $
)
��$ %
{
�� 	
var
�� 
conexion
�� 
=
�� 
OperationContext
�� +
.
��+ ,
Current
��, 3
.
��3 4 
GetCallbackChannel
��4 F
<
��F G
IJugadorCallBack
��G W
>
��W X
(
��X Y
)
��Y Z
;
��Z [
string
�� 
[
�� 
]
��  
nombresDeJugadores
�� '
=
��( )
new
��* -
string
��. 4
[
��4 5
	jugadores
��5 >
.
��> ?
Count
��? D
(
��D E
)
��E F
]
��F G
;
��G H
var
�� 
i
�� 
=
�� 
$num
�� 
;
�� 
foreach
�� 
(
�� 
Jugador
�� 
nombre
�� #
in
��$ &
	jugadores
��' 0
.
��0 1
Values
��1 7
)
��7 8
{
��  
nombresDeJugadores
�� "
[
��" #
i
��# $
]
��$ %
=
��& '
nombre
��( .
.
��. /
usuario
��/ 6
;
��6 7
i
�� 
++
�� 
;
�� 
}
�� 
foreach
�� 
(
�� 
var
�� 

conexiones
�� #
in
��$ &
	jugadores
��' 0
.
��0 1
Keys
��1 5
)
��5 6
{
�� 

conexiones
�� 
.
�� +
ActualizarJugadoresConectados
�� 8
(
��8 9 
nombresDeJugadores
��9 K
)
��K L
;
��L M
}
�� 
}
�� 	
public
�� 
void
�� 
MandarMensaje
�� !
(
��! "
Mensaje
��" )
mensaje
��* 1
,
��1 2
Jugador
��3 :$
jugadorQueMandaMensaje
��; Q
)
��Q R
{
�� 	
Console
�� 
.
�� 
	WriteLine
�� 
(
�� 
$str
�� '
,
��' ($
jugadorQueMandaMensaje
��) ?
.
��? @
usuario
��@ G
,
��G H
mensaje
��I P
.
��P Q
ContenidoMensaje
��Q a
)
��a b
;
��b c
string
�� 
[
�� 
]
��  
nombresDeJugadores
�� '
=
��( )
new
��* -
string
��. 4
[
��4 5
	jugadores
��5 >
.
��> ?
Count
��? D
(
��D E
)
��E F
]
��F G
;
��G H
var
�� 
i
�� 
=
�� 
$num
�� 
;
�� 
foreach
�� 
(
�� 
Jugador
�� 
nombre
�� #
in
��$ &
	jugadores
��' 0
.
��0 1
Values
��1 7
)
��7 8
{
��  
nombresDeJugadores
�� "
[
��" #
i
��# $
]
��$ %
=
��& '
nombre
��( .
.
��. /
usuario
��/ 6
;
��6 7
i
�� 
++
�� 
;
�� 
}
�� 
foreach
�� 
(
�� 
var
�� 

conexiones
�� #
in
��$ &
	jugadores
��' 0
.
��0 1
Keys
��1 5
)
��5 6
{
�� 
if
�� 
(
�� 
	jugadores
�� 
[
�� 

conexiones
�� (
]
��( )
.
��) *
usuario
��* 1
==
��2 4$
jugadorQueMandaMensaje
��5 K
.
��K L
usuario
��L S
)
��S T
continue
�� 
;
�� 

conexiones
�� 
.
�� 
RecibirMensaje
�� )
(
��) *$
jugadorQueMandaMensaje
��* @
,
��@ A
mensaje
��B I
,
��I J 
nombresDeJugadores
��K ]
)
��] ^
;
��^ _
}
�� 
}
�� 	
public
�� 
void
�� "
MandarMensajePrivado
�� (
(
��( )
Mensaje
��) 0
mensaje
��1 8
,
��8 9
string
��: @
nombreJugador
��A N
,
��N O
Jugador
��P W$
jugadorQueMandaMensaje
��X n
)
��n o
{
�� 	
Console
�� 
.
�� 
	WriteLine
�� 
(
�� 
$str
�� '
,
��' ($
jugadorQueMandaMensaje
��) ?
.
��? @
usuario
��@ G
,
��G H
mensaje
��I P
.
��P Q
ContenidoMensaje
��Q a
)
��a b
;
��b c
string
�� 
[
�� 
]
��  
nombresDeJugadores
�� '
=
��( )
new
��* -
string
��. 4
[
��4 5
	jugadores
��5 >
.
��> ?
Count
��? D
(
��D E
)
��E F
]
��F G
;
��G H
var
�� 
i
�� 
=
�� 
$num
�� 
;
�� 
foreach
�� 
(
�� 
Jugador
�� 
nombre
�� #
in
��$ &
	jugadores
��' 0
.
��0 1
Values
��1 7
)
��7 8
{
��  
nombresDeJugadores
�� "
[
��" #
i
��# $
]
��$ %
=
��& '
nombre
��( .
.
��. /
usuario
��/ 6
;
��6 7
i
�� 
++
�� 
;
�� 
}
�� 
foreach
�� 
(
�� 
var
�� 

conexiones
�� #
in
��$ &
	jugadores
��' 0
.
��0 1
Keys
��1 5
)
��5 6
{
�� 
if
�� 
(
�� 
	jugadores
�� 
[
�� 

conexiones
�� (
]
��( )
.
��) *
usuario
��* 1
==
��2 4$
jugadorQueMandaMensaje
��5 K
.
��K L
usuario
��L S
)
��S T
continue
�� 
;
�� 
if
�� 
(
�� 
	jugadores
�� 
[
�� 

conexiones
�� (
]
��( )
.
��) *
usuario
��* 1
==
��2 4
nombreJugador
��5 B
)
��B C
{
�� 

conexiones
�� 
.
�� 
RecibirMensaje
�� -
(
��- .$
jugadorQueMandaMensaje
��. D
,
��D E
mensaje
��F M
,
��M N 
nombresDeJugadores
��O a
)
��a b
;
��b c
break
�� 
;
�� 
}
�� 
}
�� 
}
�� 	
public
�� 
void
�� *
RecuperarPuntajesDeJugadores
�� 0
(
��0 1
)
��1 2
{
�� 	
var
�� 
conexion
�� 
=
�� 
OperationContext
�� +
.
��+ ,
Current
��, 3
.
��3 4 
GetCallbackChannel
��4 F
<
��F G
IJugadorCallBack
��G W
>
��W X
(
��X Y
)
��Y Z
;
��Z [
using
�� 
(
�� 
var
�� 
contexto
�� 
=
��  !
new
��" %
JugadorContexto
��& 5
(
��5 6
)
��6 7
)
��7 8
{
�� 
var
�� 
	jugadores
�� 
=
�� 
(
��  !
from
��! %
jugador
��& -
in
��. 0
contexto
��1 9
.
��9 :
	jugadores
��: C
select
��! '
jugador
��( /
)
��/ 0
.
��0 1
ToList
��1 7
(
��7 8
)
��8 9
.
��9 :
OrderByDescending
��: K
(
��K L
x
��L M
=>
��N P
x
��Q R
.
��R S
puntaje
��S Z
)
��Z [
;
��[ \
var
�� 
jugadoresArreglo
�� $
=
��% &
new
��' *
Jugador
��+ 2
[
��2 3
	jugadores
��3 <
.
��< =
Count
��= B
(
��B C
)
��C D
]
��D E
;
��E F
int
�� 
i
�� 
=
�� 
$num
�� 
;
�� 
foreach
�� 
(
�� 
Jugador
��  
jugador
��! (
in
��) +
	jugadores
��, 5
)
��5 6
{
�� 
jugador
�� 
.
�� 
imagenUsuario
�� )
=
��* +
null
��, 0
;
��0 1
jugadoresArreglo
�� $
[
��$ %
i
��% &
]
��& '
=
��( )
jugador
��* 1
;
��1 2
i
�� 
++
�� 
;
�� 
}
�� 
conexion
�� 
.
�� 
MostrarPuntajes
�� (
(
��( )
jugadoresArreglo
��) 9
)
��9 :
;
��: ;
}
�� 
}
�� 	
public
�� 
EstadoDeRegistro
�� 
RegistroDeJugador
��  1
(
��1 2
string
��2 8
usuario
��9 @
,
��@ A
string
��B H
contrasenia
��I T
,
��T U
string
��V \
correo
��] c
,
��c d
byte
��e i
[
��i j
]
��j k
imagenDeJugador
��l {
)
��{ |
{
�� 	
Autenticacion
�� 
autenticacion
�� '
=
��( )
new
��* -
Autenticacion
��. ;
(
��; <
)
��< =
;
��= >
EstadoDeRegistro
�� 
estadoDeRegistro
�� -
=
��. /
autenticacion
��0 =
.
��= >
	Registrar
��> G
(
��G H
usuario
��H O
,
��O P
contrasenia
��Q \
,
��\ ]
correo
��^ d
,
��d e
imagenDeJugador
��f u
)
��u v
;
��v w
return
�� 
estadoDeRegistro
�� #
;
��# $
}
�� 	
public
�� 
EstadoDeEnvio
�� $
MandarCodigoDeRegistro
�� 3
(
��3 4
string
��4 :
codigoDeRegistro
��; K
,
��K L
string
��M S
correoDeRegistro
��T d
)
��d e
{
�� 	
EstadoDeEnvio
�� 
estado
��  
=
��! "
EstadoDeEnvio
��# 0
.
��0 1
Fallido
��1 8
;
��8 9
try
�� 
{
�� 

SmtpClient
�� 
smtpCliente
�� &
=
��' (
new
��) ,

SmtpClient
��- 7
(
��7 8
SMTP_SERVIDOR
��8 E
,
��E F
PUERTO
��G M
)
��M N
;
��N O
smtpCliente
�� 
.
�� 
	EnableSsl
�� %
=
��& '
true
��( ,
;
��, -
smtpCliente
�� 
.
�� 
DeliveryMethod
�� *
=
��+ , 
SmtpDeliveryMethod
��- ?
.
��? @
Network
��@ G
;
��G H
smtpCliente
�� 
.
�� #
UseDefaultCredentials
�� 1
=
��2 3
false
��4 9
;
��9 :
smtpCliente
�� 
.
�� 
Credentials
�� '
=
��( )
new
��* -
NetworkCredential
��. ?
(
��? @
CORREO
��@ F
,
��F G
CONTRASENIA
��H S
)
��S T
;
��T U
using
�� 
(
�� 
MailMessage
�� "
mensaje
��# *
=
��+ ,
new
��- 0
MailMessage
��1 <
(
��< =
)
��= >
)
��> ?
{
�� 
mensaje
�� 
.
�� 
From
��  
=
��! "
new
��# &
MailAddress
��' 2
(
��2 3
CORREO
��3 9
)
��9 :
;
��: ;
mensaje
�� 
.
�� 
Subject
�� #
=
��$ %
$str
��& K
;
��K L
mensaje
�� 
.
�� 
Body
��  
=
��! "
$str
��# [
+
��\ ]
codigoDeRegistro
��^ n
;
��n o
mensaje
�� 
.
�� 

IsBodyHtml
�� &
=
��' (
false
��) .
;
��. /
mensaje
�� 
.
�� 
To
�� 
.
�� 
Add
�� "
(
��" #
correoDeRegistro
��# 3
)
��3 4
;
��4 5
smtpCliente
�� 
.
��  
Send
��  $
(
��$ %
mensaje
��% ,
)
��, -
;
��- .
estado
�� 
=
�� 
EstadoDeEnvio
�� *
.
��* +
Correcto
��+ 3
;
��3 4
}
�� 
}
�� 
catch
�� 
(
�� 
	Exception
�� 
	exception
�� &
)
��& '
when
��( ,
(
��- .
	exception
��. 7
is
��8 :
SmtpException
��; H
||
��I K
	exception
��L U
is
��V X'
InvalidOperationException
��Y r
||
�� 
	exception
�� 
is
�� 
FormatException
�� +
||
��, .
	exception
��/ 8
is
��9 ;#
ArgumentNullException
��< Q
)
��Q R
{
�� 
estado
�� 
=
�� 
EstadoDeEnvio
�� &
.
��& '
Fallido
��' .
;
��. /
Console
�� 
.
�� 
	WriteLine
�� !
(
��! "
	exception
��" +
.
��+ ,

StackTrace
��, 6
)
��6 7
;
��7 8
}
�� 
return
�� 
estado
�� 
;
�� 
}
�� 	
public
�� 
byte
�� 
[
�� 
]
�� +
ObtenerBytesDeImagenDeJugador
�� 3
(
��3 4
string
��4 :
usuario
��; B
)
��B C
{
�� 	
using
�� 
(
�� 
var
�� 
contexto
�� 
=
��  !
new
��" %
JugadorContexto
��& 5
(
��5 6
)
��6 7
)
��7 8
{
�� 
var
�� 
bytesDeImagen
�� !
=
��" #
(
��$ %
from
��% )
jugador
��* 1
in
��2 4
contexto
��5 =
.
��= >
	jugadores
��> G
where
��% *
jugador
��+ 2
.
��2 3
usuario
��3 :
==
��; =
usuario
��> E
select
��% +
jugador
��, 3
.
��3 4
imagenUsuario
��4 A
)
��A B
.
��B C
ToArray
��C J
(
��J K
)
��K L
;
��L M
if
�� 
(
�� 
bytesDeImagen
�� !
.
��! "
Length
��" (
>
��) *
$num
��+ ,
)
��, -
return
�� 
bytesDeImagen
�� (
[
��( )
$num
��) *
]
��* +
;
��+ ,
else
�� 
return
�� 
null
�� 
;
��  
}
�� 
}
�� 	
public
�� !
EstadoDeEliminacion
�� "
EliminarJugador
��# 2
(
��2 3
Jugador
��3 :
jugador
��; B
)
��B C
{
�� 	
Autenticacion
�� 
autenticacion
�� '
=
��( )
new
��* -
Autenticacion
��. ;
(
��; <
)
��< =
;
��= >
return
�� 
autenticacion
��  
.
��  !
EliminarJugador
��! 0
(
��0 1
jugador
��1 8
.
��8 9
usuario
��9 @
,
��@ A
jugador
��B I
.
��I J
contrasenia
��J U
)
��U V
;
��V W
}
�� 	
public
�� "
EstadoUnirseAPartida
�� #
UnirseAPartida
��$ 2
(
��2 3
Jugador
��3 :
jugador
��; B
,
��B C
string
��D J
codigoDePartida
��K Z
)
��Z [
{
�� 	
bool
�� 
encontroPartida
��  
=
��! "
false
��# (
;
��( )
foreach
�� 
(
�� 
Partida
�� 
partida
�� $
in
��% '
partidas
��( 0
)
��0 1
{
�� 
if
�� 
(
�� 
partida
�� 
.
�� 
codigoDePartida
�� +
==
��, .
codigoDePartida
��/ >
)
��> ?
{
�� 
encontroPartida
�� #
=
��$ %
true
��& *
;
��* +
if
�� 
(
�� 
partida
�� 
.
��  
	jugadores
��  )
[
��) *
$num
��* +
]
��+ ,
!=
��- /
null
��0 4
)
��4 5
{
�� 
return
�� "
EstadoUnirseAPartida
�� 3
.
��3 4)
FallidoPorMaximoDeJugadores
��4 O
;
��O P
}
�� 
else
�� 
{
�� 
partida
�� 
.
��  
	jugadores
��  )
[
��) *
$num
��* +
]
��+ ,
=
��- .
jugador
��/ 6
;
��6 7
break
�� 
;
�� 
}
�� 
}
�� 
}
�� 
if
�� 
(
�� 
!
�� 
encontroPartida
��  
)
��  !
return
�� "
EstadoUnirseAPartida
�� +
.
��+ ,+
FallidoPorPartidaNoEncontrada
��, I
;
��I J
return
�� "
EstadoUnirseAPartida
�� '
.
��' (
Correcto
��( 0
;
��0 1
}
�� 	
public
�� 
void
��  
InicializarPartida
�� &
(
��& '
string
��' -
codigoDePartida
��. =
)
��= >
{
�� 	
foreach
�� 
(
�� 
Partida
�� 
partida
�� $
in
��% '
partidas
��( 0
)
��0 1
{
�� 
if
�� 
(
�� 
partida
�� 
.
�� 
codigoDePartida
�� +
==
��, .
codigoDePartida
��/ >
)
��> ?
{
�� 
foreach
�� 
(
�� 
var
��  

conexiones
��! +
in
��, .
	jugadores
��/ 8
.
��8 9
Keys
��9 =
)
��= >
{
�� 
if
�� 
(
�� 
	jugadores
�� %
[
��% &

conexiones
��& 0
]
��0 1
.
��1 2
usuario
��2 9
==
��: <
partida
��= D
.
��D E
	jugadores
��E N
[
��N O
$num
��O P
]
��P Q
.
��Q R
usuario
��R Y
)
��Y Z
{
�� 

conexiones
�� &
.
��& '
IniciarPartida
��' 5
(
��5 6
partida
��6 =
.
��= >
	jugadores
��> G
[
��G H
$num
��H I
]
��I J
.
��J K
usuario
��K R
)
��R S
;
��S T
}
�� 
if
�� 
(
�� 
	jugadores
�� %
[
��% &

conexiones
��& 0
]
��0 1
.
��1 2
usuario
��2 9
==
��: <
partida
��= D
.
��D E
	jugadores
��E N
[
��N O
$num
��O P
]
��P Q
.
��Q R
usuario
��R Y
)
��Y Z
{
�� 

conexiones
�� &
.
��& '
IniciarPartida
��' 5
(
��5 6
partida
��6 =
.
��= >
	jugadores
��> G
[
��G H
$num
��H I
]
��I J
.
��J K
usuario
��K R
)
��R S
;
��S T
}
�� 
}
�� 
break
�� 
;
�� 
}
�� 
}
�� 
}
�� 	
public
�� 
void
�� 
EliminarPartida
�� #
(
��# $
string
��$ *
codigoDePartida
��+ :
,
��: ;
string
��< B 
usuarioQueFinaliza
��C U
,
��U V
EstadoPartida
��W d
estadoPartida
��e r
)
��r s
{
�� 	
foreach
�� 
(
�� 
Partida
�� 
partida
�� $
in
��% '
partidas
��( 0
)
��0 1
{
�� 
if
�� 
(
�� 
partida
�� 
.
�� 
codigoDePartida
�� +
==
��, .
codigoDePartida
��/ >
)
��> ?
{
�� 
if
�� 
(
�� 
partida
�� 
.
��  
	jugadores
��  )
[
��) *
$num
��* +
]
��+ ,
!=
��- /
null
��0 4
&&
��5 7 
usuarioQueFinaliza
��8 J
==
��K M
partida
��N U
.
��U V
	jugadores
��V _
[
��_ `
$num
��` a
]
��a b
.
��b c
usuario
��c j
)
��j k
{
�� 
foreach
�� 
(
��  !
var
��! $

conexiones
��% /
in
��0 2
	jugadores
��3 <
.
��< =
Keys
��= A
)
��A B
{
�� 
if
�� 
(
��  
	jugadores
��  )
[
��) *

conexiones
��* 4
]
��4 5
.
��5 6
usuario
��6 =
==
��> @
partida
��A H
.
��H I
	jugadores
��I R
[
��R S
$num
��S T
]
��T U
.
��U V
usuario
��V ]
)
��] ^
{
�� 

conexiones
��  *
.
��* +"
DesconectarDePartida
��+ ?
(
��? @
estadoPartida
��@ M
)
��M N
;
��N O
}
�� 
}
�� 
}
�� 
else
�� 
if
�� 
(
�� 
partida
�� $
.
��$ %
	jugadores
��% .
[
��. /
$num
��/ 0
]
��0 1
!=
��2 4
null
��5 9
&&
��: < 
usuarioQueFinaliza
��= O
==
��P R
partida
��S Z
.
��Z [
	jugadores
��[ d
[
��d e
$num
��e f
]
��f g
.
��g h
usuario
��h o
)
��o p
{
�� 
foreach
�� 
(
��  !
var
��! $

conexiones
��% /
in
��0 2
	jugadores
��3 <
.
��< =
Keys
��= A
)
��A B
{
�� 
if
�� 
(
��  
	jugadores
��  )
[
��) *

conexiones
��* 4
]
��4 5
.
��5 6
usuario
��6 =
==
��> @
partida
��A H
.
��H I
	jugadores
��I R
[
��R S
$num
��S T
]
��T U
.
��U V
usuario
��V ]
)
��] ^
{
�� 

conexiones
��  *
.
��* +"
DesconectarDePartida
��+ ?
(
��? @
estadoPartida
��@ M
)
��M N
;
��N O
}
�� 
}
�� 
}
�� 
partidas
�� 
.
�� 
Remove
�� #
(
��# $
partida
��$ +
)
��+ ,
;
��, -
break
�� 
;
�� 
}
�� 
}
�� 
}
�� 	
public
�� 
void
�� '
EliminarPartidaConGanador
�� -
(
��- .
string
��. 4
codigoDePartida
��5 D
,
��D E
string
��F L 
usuarioQueFinaliza
��M _
,
��_ `
EstadoPartida
��a n
estadoPartida
��o |
,
��| }
float��~ �
puntaje��� �
,��� �
string��� �
ganador��� �
)��� �
{
�� 	
foreach
�� 
(
�� 
Partida
�� 
partida
�� $
in
��% '
partidas
��( 0
)
��0 1
{
�� 
if
�� 
(
�� 
partida
�� 
.
�� 
codigoDePartida
�� +
==
��, .
codigoDePartida
��/ >
)
��> ?
{
�� 
var
�� "
estadoAgregarPuntaje
�� ,
=
��- .$
AgregarPuntajeAJugador
��/ E
(
��E F
ganador
��F M
,
��M N
puntaje
��O V
)
��V W
;
��W X
if
�� 
(
�� "
estadoAgregarPuntaje
�� ,
==
��- /%
EstadoAgregarPuntuacion
��0 G
.
��G H
Correcto
��H P
)
��P Q
Console
�� 
.
��  
	WriteLine
��  )
(
��) *
$str
��* <
)
��< =
;
��= >
else
�� 
Console
�� 
.
��  
	WriteLine
��  )
(
��) *
$str
��* ?
)
��? @
;
��@ A
if
�� 
(
�� 
partida
�� 
.
��  
	jugadores
��  )
[
��) *
$num
��* +
]
��+ ,
!=
��- /
null
��0 4
&&
��5 7 
usuarioQueFinaliza
��8 J
==
��K M
partida
��N U
.
��U V
	jugadores
��V _
[
��_ `
$num
��` a
]
��a b
.
��b c
usuario
��c j
)
��j k
{
�� 
foreach
�� 
(
��  !
var
��! $

conexiones
��% /
in
��0 2
	jugadores
��3 <
.
��< =
Keys
��= A
)
��A B
{
�� 
if
�� 
(
��  
	jugadores
��  )
[
��) *

conexiones
��* 4
]
��4 5
.
��5 6
usuario
��6 =
==
��> @
partida
��A H
.
��H I
	jugadores
��I R
[
��R S
$num
��S T
]
��T U
.
��U V
usuario
��V ]
)
��] ^
{
�� 
if
��  "
(
��# $
	jugadores
��$ -
[
��- .

conexiones
��. 8
]
��8 9
.
��9 :
usuario
��: A
!=
��B D
ganador
��E L
&&
��M O
estadoPartida
��P ]
==
��^ `
EstadoPartida
��a n
.
��n o!
FinDePartidaGanada��o �
)��� �

conexiones
��$ .
.
��. /"
DesconectarDePartida
��/ C
(
��C D
EstadoPartida
��D Q
.
��Q R!
FinDePartidaPerdida
��R e
)
��e f
;
��f g
else
��  $

conexiones
��$ .
.
��. /"
DesconectarDePartida
��/ C
(
��C D
estadoPartida
��D Q
)
��Q R
;
��R S
}
�� 
}
�� 
}
�� 
else
�� 
if
�� 
(
�� 
partida
�� $
.
��$ %
	jugadores
��% .
[
��. /
$num
��/ 0
]
��0 1
!=
��2 4
null
��5 9
&&
��: < 
usuarioQueFinaliza
��= O
==
��P R
partida
��S Z
.
��Z [
	jugadores
��[ d
[
��d e
$num
��e f
]
��f g
.
��g h
usuario
��h o
)
��o p
{
�� 
foreach
�� 
(
��  !
var
��! $

conexiones
��% /
in
��0 2
	jugadores
��3 <
.
��< =
Keys
��= A
)
��A B
{
�� 
if
�� 
(
��  
	jugadores
��  )
[
��) *

conexiones
��* 4
]
��4 5
.
��5 6
usuario
��6 =
==
��> @
partida
��A H
.
��H I
	jugadores
��I R
[
��R S
$num
��S T
]
��T U
.
��U V
usuario
��V ]
)
��] ^
{
�� 
if
��  "
(
��# $
	jugadores
��$ -
[
��- .

conexiones
��. 8
]
��8 9
.
��9 :
usuario
��: A
!=
��B D
ganador
��E L
&&
��M O
estadoPartida
��P ]
==
��^ `
EstadoPartida
��a n
.
��n o!
FinDePartidaGanada��o �
)��� �

conexiones
��$ .
.
��. /"
DesconectarDePartida
��/ C
(
��C D
EstadoPartida
��D Q
.
��Q R!
FinDePartidaPerdida
��R e
)
��e f
;
��f g
else
��  $

conexiones
��$ .
.
��. /"
DesconectarDePartida
��/ C
(
��C D
estadoPartida
��D Q
)
��Q R
;
��R S
}
�� 
}
�� 
}
�� 
partidas
�� 
.
�� 
Remove
�� #
(
��# $
partida
��$ +
)
��+ ,
;
��, -
break
�� 
;
�� 
}
�� 
}
�� 
}
�� 	
public
�� %
EstadoAgregarPuntuacion
�� &$
AgregarPuntajeAJugador
��' =
(
��= >
string
��> D
usuario
��E L
,
��L M
float
��N S
puntaje
��T [
)
��[ \
{
�� 	
foreach
�� 
(
�� 
var
�� 

conexiones
�� #
in
��$ &
	jugadores
��' 0
.
��0 1
Keys
��1 5
)
��5 6
{
�� 
if
�� 
(
�� 
	jugadores
�� 
[
�� 

conexiones
�� (
]
��( )
.
��) *
usuario
��* 1
==
��2 4
usuario
��5 <
)
��< =
{
�� 
using
�� 
(
�� 
var
�� 
contexto
�� '
=
��( )
new
��* -
JugadorContexto
��. =
(
��= >
)
��> ?
)
��? @
{
�� 
float
�� 
puntajeDelJugador
�� /
=
��0 1
(
��2 3
from
��3 7
jugador
��8 ?
in
��@ B
contexto
��C K
.
��K L
	jugadores
��L U
where
��3 8
jugador
��9 @
.
��@ A
usuario
��A H
==
��I K
usuario
��L S
select
��3 9
jugador
��: A
.
��A B
puntaje
��B I
)
��I J
.
��J K
First
��K P
(
��P Q
)
��Q R
.
��R S
Value
��S X
;
��X Y
puntajeDelJugador
�� )
+=
��* ,
puntaje
��- 4
;
��4 5
var
�� 
	jugadorBD
�� %
=
��& '
contexto
��( 0
.
��0 1
	jugadores
��1 :
.
��: ;
Where
��; @
(
��@ A
j
��A B
=>
��C E
j
��F G
.
��G H
usuario
��H O
==
��P R
usuario
��S Z
)
��Z [
.
��[ \
FirstOrDefault
��\ j
(
��j k
)
��k l
;
��l m
Jugador
�� 
copia
��  %
=
��& '
new
��( +
Jugador
��, 3
(
��3 4
)
��4 5
{
��6 7
usuario
��8 ?
=
��@ A
	jugadorBD
��B K
.
��K L
usuario
��L S
,
��S T
contrasenia
��U `
=
��a b
	jugadorBD
��c l
.
��l m
contrasenia
��m x
,
��x y
correo��z �
=��� �
	jugadorBD��� �
.��� �
correo��� �
,��� �
imagenUsuario��� �
=��� �
	jugadorBD��� �
.��� �
imagenUsuario��� �
,��� �
	JugadorId��� �
=��� �
	jugadorBD��� �
.��� �
	JugadorId��� �
,��� �
puntaje��� �
=��� �!
puntajeDelJugador��� �
}��� �
;��� �
if
�� 
(
�� 
	jugadorBD
�� %
!=
��& (
null
��) -
)
��- .
{
�� 
contexto
�� $
.
��$ %
Entry
��% *
(
��* +
	jugadorBD
��+ 4
)
��4 5
.
��5 6
CurrentValues
��6 C
.
��C D
	SetValues
��D M
(
��M N
copia
��N S
)
��S T
;
��T U
}
�� 
try
�� 
{
�� 
contexto
�� $
.
��$ %
SaveChanges
��% 0
(
��0 1
)
��1 2
;
��2 3
}
�� 
catch
�� 
(
�� 
	Exception
�� (
	exception
��) 2
)
��2 3
when
��4 8
(
��9 :
	exception
��: C
is
��D F
SmtpException
��G T
||
��U W
	exception
��X a
is
��b d'
InvalidOperationException
��e ~
||
�� 
	exception
�� %
is
��& (
FormatException
��) 8
||
��9 ;
	exception
��< E
is
��F H#
ArgumentNullException
��I ^
)
��^ _
{
�� 
Console
�� #
.
��# $
	WriteLine
��$ -
(
��- .
	exception
��. 7
.
��7 8

StackTrace
��8 B
)
��B C
;
��C D
return
�� "%
EstadoAgregarPuntuacion
��# :
.
��: ;
Fallido
��; B
;
��B C
}
�� 
}
�� 
return
�� %
EstadoAgregarPuntuacion
�� 2
.
��2 3
Correcto
��3 ;
;
��; <
}
�� 
}
�� 
return
�� %
EstadoAgregarPuntuacion
�� *
.
��* +
Fallido
��+ 2
;
��2 3
}
�� 	
public
�� 
void
�� %
InsertarFichaEnOponente
�� +
(
��+ ,
int
��, /
columna
��0 7
,
��7 8
string
��9 ?
codigoDePartida
��@ O
,
��O P
string
��Q W
oponente
��X `
)
��` a
{
�� 	
foreach
�� 
(
�� 
Partida
�� 
partida
�� $
in
��% '
partidas
��( 0
)
��0 1
{
�� 
if
�� 
(
�� 
partida
�� 
.
�� 
codigoDePartida
�� +
==
��, .
codigoDePartida
��/ >
)
��> ?
{
�� 
if
�� 
(
�� 
partida
�� 
.
��  
	jugadores
��  )
[
��) *
$num
��* +
]
��+ ,
.
��, -
usuario
��- 4
==
��5 7
oponente
��8 @
)
��@ A
{
�� 
foreach
�� 
(
��  !
var
��! $

conexiones
��% /
in
��0 2
	jugadores
��3 <
.
��< =
Keys
��= A
)
��A B
{
�� 
if
�� 
(
��  
	jugadores
��  )
[
��) *

conexiones
��* 4
]
��4 5
.
��5 6
usuario
��6 =
==
��> @
oponente
��A I
)
��I J
{
�� 

conexiones
��  *
.
��* +$
InsertarFichaEnTablero
��+ A
(
��A B
columna
��B I
)
��I J
;
��J K
}
�� 
}
�� 
}
�� 
else
�� 
{
�� 
foreach
�� 
(
��  !
var
��! $

conexiones
��% /
in
��0 2
	jugadores
��3 <
.
��< =
Keys
��= A
)
��A B
{
�� 
if
�� 
(
��  
	jugadores
��  )
[
��) *

conexiones
��* 4
]
��4 5
.
��5 6
usuario
��6 =
==
��> @
partida
��A H
.
��H I
	jugadores
��I R
[
��R S
$num
��S T
]
��T U
.
��U V
usuario
��V ]
)
��] ^
{
�� 

conexiones
��  *
.
��* +$
InsertarFichaEnTablero
��+ A
(
��A B
columna
��B I
)
��I J
;
��J K
}
�� 
}
�� 
}
�� 
}
�� 
}
�� 
}
�� 	
}
�� 
}�� �
bC:\Users\UV\Desktop\Proyecto-Conecta-4\Proyecto\Juego\Chat\ChatJuego\Servicios\IJugadorCallBack.cs
	namespace 	
	ChatJuego
 
. 
Host 
{ 
[ 
ServiceContract 
] 
public		 

	interface		 
IJugadorCallBack		 %
{

 
[ 	
OperationContract	 
( 
IsOneWay #
=$ %
true& *
)* +
]+ ,
void 
RecibirMensaje 
( 
Jugador #
jugador$ +
,+ ,
Mensaje- 4
mensaje5 <
,< =
string= C
[C D
]D E
nombresDeJugadoresF X
)X Y
;Y Z
[ 	
OperationContract	 
( 
IsOneWay #
=$ %
true& *
)* +
]+ ,
void )
ActualizarJugadoresConectados *
(* +
string+ 1
[1 2
]2 3
nombresDeJugadores4 F
)F G
;G H
[ 	
OperationContract	 
( 
IsOneWay #
=$ %
true& *
)* +
]+ ,
void 
MostrarPuntajes 
( 
Jugador $
[$ %
]% &
	jugadores' 0
)0 1
;1 2
[ 	
OperationContract	 
( 
IsOneWay #
=$ %
true& *
)* +
]+ ,
void 
IniciarPartida 
( 
string "
nombreOponente# 1
)1 2
;2 3
[ 	
OperationContract	 
( 
IsOneWay #
=$ %
true& *
)* +
]+ ,
void  
DesconectarDePartida !
(! "
EstadoPartida" /
estadoPartida0 =
)= >
;> ?
[ 	
OperationContract	 
( 
IsOneWay #
=$ %
true& *
)* +
]+ ,
void "
InsertarFichaEnTablero #
(# $
int$ '
columna( /
)/ 0
;0 1
} 
} �
_C:\Users\UV\Desktop\Proyecto-Conecta-4\Proyecto\Juego\Chat\ChatJuego\Servicios\IChatServicio.cs
	namespace 	
	ChatJuego
 
. 
Host 
{ 
[ 
ServiceContract 
( 
CallbackContract %
=& '
typeof( .
(. /
IJugadorCallBack/ ?
)? @
)@ A
]A B
public 

	interface 
IChatServicio "
{ 
[

 	
OperationContract

	 
(

 
IsOneWay

 #
=

$ %
true

& *
)

* +
]

+ ,
void 
InicializarChat 
( 
) 
; 
[ 	
OperationContract	 
( 
IsOneWay #
=$ %
true& *
)* +
]+ ,
void 
MandarMensaje 
( 
Mensaje "
mensaje# *
,* +
Jugador, 3"
jugadorQueMandaMensaje4 J
)J K
;K L
[ 	
OperationContract	 
( 
IsOneWay #
=$ %
true& *
)* +
]+ ,
void  
MandarMensajePrivado !
(! "
Mensaje" )
mensaje* 1
,1 2
string3 9
nombreJugador: G
,G H
JugadorI P"
jugadorQueMandaMensajeQ g
)g h
;h i
} 
} �
WC:\Users\UV\Desktop\Proyecto-Conecta-4\Proyecto\Juego\Chat\ChatJuego\Dominio\Mensaje.cs
	namespace 	
	ChatJuego
 
. 
Host 
{ 
public 

class 
Mensaje 
{ 
private 
DateTime 
tiempoDeEnvio &
;& '
private 
string 
usuarioEmisor $
;$ %
private		 
string		 
usuarioReceptor		 &
;		& '
private

 
string

 
contenidoMensaje

 '
;

' (
public 
DateTime 
TiempoDeEnvio %
{& '
get( +
=>, .
tiempoDeEnvio/ <
;< =
set> A
=>B D
tiempoDeEnvioE R
=S T
valueU Z
;Z [
}\ ]
public 
string 
UsuarioEmisor #
{$ %
get& )
=>* ,
usuarioEmisor- :
;: ;
set< ?
=>@ B
usuarioEmisorC P
=Q R
valueS X
;X Y
}Z [
public 
string 
UsuarioReceptor %
{& '
get( +
=>, .
usuarioReceptor/ >
;> ?
set@ C
=>D F
usuarioReceptorG V
=W X
valueY ^
;^ _
}` a
public 
string 
ContenidoMensaje &
{' (
get) ,
=>- /
contenidoMensaje0 @
;@ A
setB E
=>F H
contenidoMensajeI Y
=Z [
value\ a
;a b
}c d
} 
} �	
QC:\Users\UV\Desktop\Proyecto-Conecta-4\Proyecto\Juego\Chat\ChatJuego\Host\Host.cs
	namespace 	
	ChatJuego
 
. 
Host 
{ 
class 	
Host
 
{ 
static 
void 
Main 
( 
string 
[  
]  !
args" &
)& '
{ 	
JugadorContexto 
contextoDelJugador .
=/ 0
new1 4
JugadorContexto5 D
(D E
)E F
;F G
ServiceHost 
host 
= 
new "
ServiceHost# .
(. /
typeof/ 5
(5 6
Servicio6 >
)> ?
)? @
;@ A
host 
. 
Open 
( 
) 
; 
Console 
. 
	WriteLine 
( 
$str 2
)2 3
;3 4
Console 
. 
ReadLine 
( 
) 
; 
host 
. 
Close 
( 
) 
; 
} 	
} 
} �
_C:\Users\UV\Desktop\Proyecto-Conecta-4\Proyecto\Juego\Chat\ChatJuego\Properties\AssemblyInfo.cs
[ 
assembly 	
:	 

AssemblyTitle 
( 
$str $
)$ %
]% &
[		 
assembly		 	
:			 

AssemblyDescription		 
(		 
$str		 !
)		! "
]		" #
[

 
assembly

 	
:

	 
!
AssemblyConfiguration

  
(

  !
$str

! #
)

# $
]

$ %
[ 
assembly 	
:	 

AssemblyCompany 
( 
$str 
) 
] 
[ 
assembly 	
:	 

AssemblyProduct 
( 
$str &
)& '
]' (
[ 
assembly 	
:	 

AssemblyCopyright 
( 
$str 0
)0 1
]1 2
[ 
assembly 	
:	 

AssemblyTrademark 
( 
$str 
)  
]  !
[ 
assembly 	
:	 

AssemblyCulture 
( 
$str 
) 
] 
[ 
assembly 	
:	 


ComVisible 
( 
false 
) 
] 
[ 
assembly 	
:	 

Guid 
( 
$str 6
)6 7
]7 8
[## 
assembly## 	
:##	 

AssemblyVersion## 
(## 
$str## $
)##$ %
]##% &
[$$ 
assembly$$ 	
:$$	 

AssemblyFileVersion$$ 
($$ 
$str$$ (
)$$( )
]$$) *�
kC:\Users\UV\Desktop\Proyecto-Conecta-4\Proyecto\Juego\Chat\ChatJuego\Servicios\IInvitacionCorreoServicio.cs
	namespace 	
	ChatJuego
 
. 
	Servicios 
{ 
[ 
ServiceContract 
( 
CallbackContract %
=& '
typeof( .
(. /
IJugadorCallBack/ ?
)? @
)@ A
]A B
public 

	interface %
IInvitacionCorreoServicio .
{ 
[ 	
OperationContract	 
( 
IsOneWay #
=$ %
false& +
)+ ,
], -
EstadoDeEnvio 
EnviarInvitacion &
(& '
Jugador' .
jugadorInvitado/ >
,> ?
string@ F
codigoPartidaG T
,T U
JugadorV ]
jugadorInvitador^ n
)n o
;o p
[ 	
OperationContract	 
( 
IsOneWay #
=$ %
false& +
)+ ,
], -
EstadoDeEnvio "
MandarCodigoDeRegistro ,
(, -
string- 3
codigoDeRegistro4 D
,D E
stringF L
correoM S
)S T
;T U
} 
public 

enum 
EstadoDeEnvio 
{ 
Correcto 
= 
$num 
, 
UsuarioNoEncontrado 
, 
Fallido 
} 
} �
bC:\Users\UV\Desktop\Proyecto-Conecta-4\Proyecto\Juego\Chat\ChatJuego\Servicios\ITablaDePuntajes.cs
	namespace 	
	ChatJuego
 
. 
	Servicios 
{ 
[ 
ServiceContract 
( 
CallbackContract %
=& '
typeof( .
(. /
IJugadorCallBack/ ?
)? @
)@ A
]A B
public 

	interface 
ITablaDePuntajes %
{ 
[		 	
OperationContract			 
(		 
IsOneWay		 #
=		$ %
true		& *
)		* +
]		+ ,
void

 (
RecuperarPuntajesDeJugadores

 )
(

) *
)

* +
;

+ ,
} 
} �/
[C:\Users\UV\Desktop\Proyecto-Conecta-4\Proyecto\Juego\Chat\ChatJuego\Servicios\IServidor.cs
	namespace 	
	ChatJuego
 
. 
	Servicios 
{ 
[ 
ServiceContract 
( 
CallbackContract %
=& '
typeof( .
(. /
IJugadorCallBack/ ?
)? @
)@ A
]A B
public 

	interface 
	IServidor 
{		 
[ 	
OperationContract	 
( 
IsOneWay #
=$ %
false& +
)+ ,
], -"
EstadoDeInicioDeSesion 

Conectarse )
() *
Jugador* 1
jugador2 9
)9 :
;: ;
[ 	
OperationContract	 
( 
IsOneWay #
=$ %
false& +
)+ ,
], -
EstadoDeEliminacion 
EliminarJugador +
(+ ,
Jugador, 3
jugador4 ;
); <
;< =
[ 	
OperationContract	 
( 
IsOneWay #
=$ %
false& +
)+ ,
], -
EstadoDeRegistro 
RegistroDeJugador *
(* +
string+ 1
usuario2 9
,9 :
string; A
contraseniaB M
,M N
stringO U
correoV \
,\ ]
byte^ b
[b c
]c d
imagenDeJugadore t
)t u
;u v
[ 	
OperationContract	 
( 
IsOneWay #
=$ %
false& +
)+ ,
], -
byte 
[ 
] )
ObtenerBytesDeImagenDeJugador ,
(, -
string- 3
usuario4 ;
); <
;< =
[ 	
OperationContract	 
( 
IsOneWay #
=$ %
true& *
)* +
]+ ,
void 
Desconectarse 
( 
) 
; 
[ 	
OperationContract	 
( 
IsOneWay #
=$ %
false& +
)+ ,
], - 
EstadoUnirseAPartida 
UnirseAPartida +
(+ ,
Jugador, 3
jugador4 ;
,; <
string= C
codigoDePartidaD S
)S T
;T U
[ 	
OperationContract	 
( 
IsOneWay #
=$ %
true& *
)* +
]+ ,
void 
EliminarPartida 
( 
string #
codigoDePartida$ 3
,3 4
string5 ;
usuarioQueFinaliza< N
,N O
EstadoPartidaP ]
estadoPartida^ k
)k l
;l m
[   	
OperationContract  	 
(   
IsOneWay   #
=  $ %
true  & *
)  * +
]  + ,
void!! %
EliminarPartidaConGanador!! &
(!!& '
string!!' -
codigoDePartida!!. =
,!!= >
string!!? E
usuarioQueFinaliza!!F X
,!!X Y
EstadoPartida!!Z g
estadoPartida!!h u
,!!u v
float!!w |
puntaje	!!} �
,
!!� �
string
!!� �
ganador
!!� �
)
!!� �
;
!!� �
[## 	
OperationContract##	 
(## 
IsOneWay## #
=##$ %
true##& *
)##* +
]##+ ,
void$$ 
InicializarPartida$$ 
($$  
string$$  &
codigoDePartida$$' 6
)$$6 7
;$$7 8
[&& 	
OperationContract&&	 
(&& 
IsOneWay&& #
=&&$ %
false&&& +
)&&+ ,
]&&, -#
EstadoAgregarPuntuacion'' "
AgregarPuntajeAJugador''  6
(''6 7
string''7 =
usuario''> E
,''E F
float''G L
puntaje''M T
)''T U
;''U V
[)) 	
OperationContract))	 
()) 
IsOneWay)) #
=))$ %
true))& *
)))* +
]))+ ,
void** #
InsertarFichaEnOponente** $
(**$ %
int**% (
columna**) 0
,**0 1
string**2 8
codigoDePartida**9 H
,**H I
string**J P
oponente**Q Y
)**Y Z
;**Z [
},, 
public.. 

enum.. 
EstadoDeRegistro..  
{// 
Correcto00 
=00 
$num00 
,00 
FallidoPorCorreo11 
,11 
FallidoPorUsuario22 
,22 
Fallido33 
}44 
public66 

enum66 
EstadoDeEliminacion66 #
{77 
Correcto88 
=88 
$num88 
,88 
Fallido99 
}:: 
public<< 

enum<< "
EstadoDeInicioDeSesion<< &
{== 
Correcto>> 
=>> 
$num>> 
,>> (
FallidoPorUsuarioYaConectado?? $
,??$ %
Fallido@@ 
}AA 
publicCC 

enumCC  
EstadoUnirseAPartidaCC $
{DD 
CorrectoEE 
=EE 
$numEE 
,EE )
FallidoPorPartidaNoEncontradaFF %
,FF% &'
FallidoPorMaximoDeJugadoresGG #
}HH 
publicJJ 

enumJJ 
EstadoPartidaJJ 
{KK 
FinDePartidaGanadaLL 
=LL 
$numLL 
,LL 
FinDePartidaSalirMM 
,MM /
#FinDePartidaPorTiempoDeEsperaLimiteNN +
,NN+ ,
FinDePartidaPerdidaOO 
,OO !
FinDePartidaPorEmpatePP 
}QQ 
publicSS 

enumSS #
EstadoAgregarPuntuacionSS '
{TT 
CorrectoUU 
=UU 
$numUU 
,UU 
FallidoVV 
}WW 
}XX 
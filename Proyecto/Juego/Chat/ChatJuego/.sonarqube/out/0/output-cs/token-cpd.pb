ºJ
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
[	 €
]
€ 
imagenDeJugador
‚ ‘
)
‘ ’
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
CifrarContrasenia	,,z ‹
(
,,‹ Œ#
contraseniaARegistrar
,,Œ ¡
)
,,¡ ¢
,
,,¢ £
correo
,,¤ ª
=
,,« ¬
correoARegistrar
,,­ ½
,
,,½ ¾
puntaje
,,¿ Æ
=
,,Ç È
$num
,,É Ê
,
,,Ë Ì
imagenUsuario
,,Í Ú
=
,,Û Ü
imagenDeJugador
,,İ ì
}
,,í î
)
,,î ï
;
,,ï ğ
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
contraseniaCifrada	nnv ˆ
)
nnˆ ‰
)
nn‰ Š
;
nnŠ ‹
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
€€ 
}„„ ƒ	
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
} ÿî
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
 	
public
†† 
void
†† 
InicializarChat
†† #
(
††# $
)
††$ %
{
‡‡ 	
var
ˆˆ 
conexion
ˆˆ 
=
ˆˆ 
OperationContext
ˆˆ +
.
ˆˆ+ ,
Current
ˆˆ, 3
.
ˆˆ3 4 
GetCallbackChannel
ˆˆ4 F
<
ˆˆF G
IJugadorCallBack
ˆˆG W
>
ˆˆW X
(
ˆˆX Y
)
ˆˆY Z
;
ˆˆZ [
string
‰‰ 
[
‰‰ 
]
‰‰  
nombresDeJugadores
‰‰ '
=
‰‰( )
new
‰‰* -
string
‰‰. 4
[
‰‰4 5
	jugadores
‰‰5 >
.
‰‰> ?
Count
‰‰? D
(
‰‰D E
)
‰‰E F
]
‰‰F G
;
‰‰G H
var
ŠŠ 
i
ŠŠ 
=
ŠŠ 
$num
ŠŠ 
;
ŠŠ 
foreach
‹‹ 
(
‹‹ 
Jugador
‹‹ 
nombre
‹‹ #
in
‹‹$ &
	jugadores
‹‹' 0
.
‹‹0 1
Values
‹‹1 7
)
‹‹7 8
{
ŒŒ  
nombresDeJugadores
 "
[
" #
i
# $
]
$ %
=
& '
nombre
( .
.
. /
usuario
/ 6
;
6 7
i
 
++
 
;
 
}
 
foreach
 
(
 
var
 

conexiones
 #
in
$ &
	jugadores
' 0
.
0 1
Keys
1 5
)
5 6
{
‘‘ 

conexiones
’’ 
.
’’ +
ActualizarJugadoresConectados
’’ 8
(
’’8 9 
nombresDeJugadores
’’9 K
)
’’K L
;
’’L M
}
““ 
}
”” 	
public
›› 
void
›› 
MandarMensaje
›› !
(
››! "
Mensaje
››" )
mensaje
››* 1
,
››1 2
Jugador
››3 :$
jugadorQueMandaMensaje
››; Q
)
››Q R
{
œœ 	
Console
 
.
 
	WriteLine
 
(
 
$str
 '
,
' ($
jugadorQueMandaMensaje
) ?
.
? @
usuario
@ G
,
G H
mensaje
I P
.
P Q
ContenidoMensaje
Q a
)
a b
;
b c
string
 
[
 
]
  
nombresDeJugadores
 '
=
( )
new
* -
string
. 4
[
4 5
	jugadores
5 >
.
> ?
Count
? D
(
D E
)
E F
]
F G
;
G H
var
ŸŸ 
i
ŸŸ 
=
ŸŸ 
$num
ŸŸ 
;
ŸŸ 
foreach
   
(
   
Jugador
   
nombre
   #
in
  $ &
	jugadores
  ' 0
.
  0 1
Values
  1 7
)
  7 8
{
¡¡  
nombresDeJugadores
¢¢ "
[
¢¢" #
i
¢¢# $
]
¢¢$ %
=
¢¢& '
nombre
¢¢( .
.
¢¢. /
usuario
¢¢/ 6
;
¢¢6 7
i
££ 
++
££ 
;
££ 
}
¤¤ 
foreach
¥¥ 
(
¥¥ 
var
¥¥ 

conexiones
¥¥ #
in
¥¥$ &
	jugadores
¥¥' 0
.
¥¥0 1
Keys
¥¥1 5
)
¥¥5 6
{
¦¦ 
if
§§ 
(
§§ 
	jugadores
§§ 
[
§§ 

conexiones
§§ (
]
§§( )
.
§§) *
usuario
§§* 1
==
§§2 4$
jugadorQueMandaMensaje
§§5 K
.
§§K L
usuario
§§L S
)
§§S T
continue
¨¨ 
;
¨¨ 

conexiones
©© 
.
©© 
RecibirMensaje
©© )
(
©©) *$
jugadorQueMandaMensaje
©©* @
,
©©@ A
mensaje
©©B I
,
©©I J 
nombresDeJugadores
©©K ]
)
©©] ^
;
©©^ _
}
ªª 
}
«« 	
public
³³ 
void
³³ "
MandarMensajePrivado
³³ (
(
³³( )
Mensaje
³³) 0
mensaje
³³1 8
,
³³8 9
string
³³: @
nombreJugador
³³A N
,
³³N O
Jugador
³³P W$
jugadorQueMandaMensaje
³³X n
)
³³n o
{
´´ 	
Console
µµ 
.
µµ 
	WriteLine
µµ 
(
µµ 
$str
µµ '
,
µµ' ($
jugadorQueMandaMensaje
µµ) ?
.
µµ? @
usuario
µµ@ G
,
µµG H
mensaje
µµI P
.
µµP Q
ContenidoMensaje
µµQ a
)
µµa b
;
µµb c
string
¶¶ 
[
¶¶ 
]
¶¶  
nombresDeJugadores
¶¶ '
=
¶¶( )
new
¶¶* -
string
¶¶. 4
[
¶¶4 5
	jugadores
¶¶5 >
.
¶¶> ?
Count
¶¶? D
(
¶¶D E
)
¶¶E F
]
¶¶F G
;
¶¶G H
var
·· 
i
·· 
=
·· 
$num
·· 
;
·· 
foreach
¸¸ 
(
¸¸ 
Jugador
¸¸ 
nombre
¸¸ #
in
¸¸$ &
	jugadores
¸¸' 0
.
¸¸0 1
Values
¸¸1 7
)
¸¸7 8
{
¹¹  
nombresDeJugadores
ºº "
[
ºº" #
i
ºº# $
]
ºº$ %
=
ºº& '
nombre
ºº( .
.
ºº. /
usuario
ºº/ 6
;
ºº6 7
i
»» 
++
»» 
;
»» 
}
¼¼ 
foreach
½½ 
(
½½ 
var
½½ 

conexiones
½½ #
in
½½$ &
	jugadores
½½' 0
.
½½0 1
Keys
½½1 5
)
½½5 6
{
¾¾ 
if
¿¿ 
(
¿¿ 
	jugadores
¿¿ 
[
¿¿ 

conexiones
¿¿ (
]
¿¿( )
.
¿¿) *
usuario
¿¿* 1
==
¿¿2 4$
jugadorQueMandaMensaje
¿¿5 K
.
¿¿K L
usuario
¿¿L S
)
¿¿S T
continue
ÀÀ 
;
ÀÀ 
if
ÁÁ 
(
ÁÁ 
	jugadores
ÁÁ 
[
ÁÁ 

conexiones
ÁÁ (
]
ÁÁ( )
.
ÁÁ) *
usuario
ÁÁ* 1
==
ÁÁ2 4
nombreJugador
ÁÁ5 B
)
ÁÁB C
{
ÂÂ 

conexiones
ÃÃ 
.
ÃÃ 
RecibirMensaje
ÃÃ -
(
ÃÃ- .$
jugadorQueMandaMensaje
ÃÃ. D
,
ÃÃD E
mensaje
ÃÃF M
,
ÃÃM N 
nombresDeJugadores
ÃÃO a
)
ÃÃa b
;
ÃÃb c
break
ÄÄ 
;
ÄÄ 
}
ÅÅ 
}
ÆÆ 
}
ÇÇ 	
public
ÌÌ 
void
ÌÌ *
RecuperarPuntajesDeJugadores
ÌÌ 0
(
ÌÌ0 1
)
ÌÌ1 2
{
ÍÍ 	
var
ÎÎ 
conexion
ÎÎ 
=
ÎÎ 
OperationContext
ÎÎ +
.
ÎÎ+ ,
Current
ÎÎ, 3
.
ÎÎ3 4 
GetCallbackChannel
ÎÎ4 F
<
ÎÎF G
IJugadorCallBack
ÎÎG W
>
ÎÎW X
(
ÎÎX Y
)
ÎÎY Z
;
ÎÎZ [
using
ÏÏ 
(
ÏÏ 
var
ÏÏ 
contexto
ÏÏ 
=
ÏÏ  !
new
ÏÏ" %
JugadorContexto
ÏÏ& 5
(
ÏÏ5 6
)
ÏÏ6 7
)
ÏÏ7 8
{
ĞĞ 
var
ÑÑ 
	jugadores
ÑÑ 
=
ÑÑ 
(
ÑÑ  !
from
ÑÑ! %
jugador
ÑÑ& -
in
ÑÑ. 0
contexto
ÑÑ1 9
.
ÑÑ9 :
	jugadores
ÑÑ: C
select
ÒÒ! '
jugador
ÒÒ( /
)
ÒÒ/ 0
.
ÒÒ0 1
ToList
ÒÒ1 7
(
ÒÒ7 8
)
ÒÒ8 9
.
ÒÒ9 :
OrderByDescending
ÒÒ: K
(
ÒÒK L
x
ÒÒL M
=>
ÒÒN P
x
ÒÒQ R
.
ÒÒR S
puntaje
ÒÒS Z
)
ÒÒZ [
;
ÒÒ[ \
var
ÓÓ 
jugadoresArreglo
ÓÓ $
=
ÓÓ% &
new
ÓÓ' *
Jugador
ÓÓ+ 2
[
ÓÓ2 3
	jugadores
ÓÓ3 <
.
ÓÓ< =
Count
ÓÓ= B
(
ÓÓB C
)
ÓÓC D
]
ÓÓD E
;
ÓÓE F
int
ÔÔ 
i
ÔÔ 
=
ÔÔ 
$num
ÔÔ 
;
ÔÔ 
foreach
ÕÕ 
(
ÕÕ 
Jugador
ÕÕ  
jugador
ÕÕ! (
in
ÕÕ) +
	jugadores
ÕÕ, 5
)
ÕÕ5 6
{
ÖÖ 
jugador
×× 
.
×× 
imagenUsuario
×× )
=
××* +
null
××, 0
;
××0 1
jugadoresArreglo
ØØ $
[
ØØ$ %
i
ØØ% &
]
ØØ& '
=
ØØ( )
jugador
ØØ* 1
;
ØØ1 2
i
ÙÙ 
++
ÙÙ 
;
ÙÙ 
}
ÚÚ 
conexion
ÛÛ 
.
ÛÛ 
MostrarPuntajes
ÛÛ (
(
ÛÛ( )
jugadoresArreglo
ÛÛ) 9
)
ÛÛ9 :
;
ÛÛ: ;
}
İİ 
}
ŞŞ 	
public
èè 
EstadoDeRegistro
èè 
RegistroDeJugador
èè  1
(
èè1 2
string
èè2 8
usuario
èè9 @
,
èè@ A
string
èèB H
contrasenia
èèI T
,
èèT U
string
èèV \
correo
èè] c
,
èèc d
byte
èèe i
[
èèi j
]
èèj k
imagenDeJugador
èèl {
)
èè{ |
{
éé 	
Autenticacion
êê 
autenticacion
êê '
=
êê( )
new
êê* -
Autenticacion
êê. ;
(
êê; <
)
êê< =
;
êê= >
EstadoDeRegistro
ëë 
estadoDeRegistro
ëë -
=
ëë. /
autenticacion
ëë0 =
.
ëë= >
	Registrar
ëë> G
(
ëëG H
usuario
ëëH O
,
ëëO P
contrasenia
ëëQ \
,
ëë\ ]
correo
ëë^ d
,
ëëd e
imagenDeJugador
ëëf u
)
ëëu v
;
ëëv w
return
ìì 
estadoDeRegistro
ìì #
;
ìì# $
}
íí 	
public
õõ 
EstadoDeEnvio
õõ $
MandarCodigoDeRegistro
õõ 3
(
õõ3 4
string
õõ4 :
codigoDeRegistro
õõ; K
,
õõK L
string
õõM S
correoDeRegistro
õõT d
)
õõd e
{
öö 	
EstadoDeEnvio
÷÷ 
estado
÷÷  
=
÷÷! "
EstadoDeEnvio
÷÷# 0
.
÷÷0 1
Fallido
÷÷1 8
;
÷÷8 9
try
øø 
{
ùù 

SmtpClient
úú 
smtpCliente
úú &
=
úú' (
new
úú) ,

SmtpClient
úú- 7
(
úú7 8
SMTP_SERVIDOR
úú8 E
,
úúE F
PUERTO
úúG M
)
úúM N
;
úúN O
smtpCliente
ûû 
.
ûû 
	EnableSsl
ûû %
=
ûû& '
true
ûû( ,
;
ûû, -
smtpCliente
üü 
.
üü 
DeliveryMethod
üü *
=
üü+ , 
SmtpDeliveryMethod
üü- ?
.
üü? @
Network
üü@ G
;
üüG H
smtpCliente
ıı 
.
ıı #
UseDefaultCredentials
ıı 1
=
ıı2 3
false
ıı4 9
;
ıı9 :
smtpCliente
şş 
.
şş 
Credentials
şş '
=
şş( )
new
şş* -
NetworkCredential
şş. ?
(
şş? @
CORREO
şş@ F
,
şşF G
CONTRASENIA
şşH S
)
şşS T
;
şşT U
using
ÿÿ 
(
ÿÿ 
MailMessage
ÿÿ "
mensaje
ÿÿ# *
=
ÿÿ+ ,
new
ÿÿ- 0
MailMessage
ÿÿ1 <
(
ÿÿ< =
)
ÿÿ= >
)
ÿÿ> ?
{
€€ 
mensaje
 
.
 
From
  
=
! "
new
# &
MailAddress
' 2
(
2 3
CORREO
3 9
)
9 :
;
: ;
mensaje
‚‚ 
.
‚‚ 
Subject
‚‚ #
=
‚‚$ %
$str
‚‚& K
;
‚‚K L
mensaje
ƒƒ 
.
ƒƒ 
Body
ƒƒ  
=
ƒƒ! "
$str
ƒƒ# [
+
ƒƒ\ ]
codigoDeRegistro
ƒƒ^ n
;
ƒƒn o
mensaje
„„ 
.
„„ 

IsBodyHtml
„„ &
=
„„' (
false
„„) .
;
„„. /
mensaje
…… 
.
…… 
To
…… 
.
…… 
Add
…… "
(
……" #
correoDeRegistro
……# 3
)
……3 4
;
……4 5
smtpCliente
†† 
.
††  
Send
††  $
(
††$ %
mensaje
††% ,
)
††, -
;
††- .
estado
‡‡ 
=
‡‡ 
EstadoDeEnvio
‡‡ *
.
‡‡* +
Correcto
‡‡+ 3
;
‡‡3 4
}
ˆˆ 
}
‰‰ 
catch
ŠŠ 
(
ŠŠ 
	Exception
ŠŠ 
	exception
ŠŠ &
)
ŠŠ& '
when
ŠŠ( ,
(
ŠŠ- .
	exception
ŠŠ. 7
is
ŠŠ8 :
SmtpException
ŠŠ; H
||
ŠŠI K
	exception
ŠŠL U
is
ŠŠV X'
InvalidOperationException
ŠŠY r
||
‹‹ 
	exception
‹‹ 
is
‹‹ 
FormatException
‹‹ +
||
‹‹, .
	exception
‹‹/ 8
is
‹‹9 ;#
ArgumentNullException
‹‹< Q
)
‹‹Q R
{
ŒŒ 
estado
 
=
 
EstadoDeEnvio
 &
.
& '
Fallido
' .
;
. /
Console
 
.
 
	WriteLine
 !
(
! "
	exception
" +
.
+ ,

StackTrace
, 6
)
6 7
;
7 8
}
 
return
 
estado
 
;
 
}
’’ 	
public
™™ 
byte
™™ 
[
™™ 
]
™™ +
ObtenerBytesDeImagenDeJugador
™™ 3
(
™™3 4
string
™™4 :
usuario
™™; B
)
™™B C
{
šš 	
using
›› 
(
›› 
var
›› 
contexto
›› 
=
››  !
new
››" %
JugadorContexto
››& 5
(
››5 6
)
››6 7
)
››7 8
{
œœ 
var
 
bytesDeImagen
 !
=
" #
(
$ %
from
% )
jugador
* 1
in
2 4
contexto
5 =
.
= >
	jugadores
> G
where
% *
jugador
+ 2
.
2 3
usuario
3 :
==
; =
usuario
> E
select
ŸŸ% +
jugador
ŸŸ, 3
.
ŸŸ3 4
imagenUsuario
ŸŸ4 A
)
ŸŸA B
.
ŸŸB C
ToArray
ŸŸC J
(
ŸŸJ K
)
ŸŸK L
;
ŸŸL M
if
   
(
   
bytesDeImagen
   !
.
  ! "
Length
  " (
>
  ) *
$num
  + ,
)
  , -
return
¡¡ 
bytesDeImagen
¡¡ (
[
¡¡( )
$num
¡¡) *
]
¡¡* +
;
¡¡+ ,
else
¢¢ 
return
££ 
null
££ 
;
££  
}
¤¤ 
}
¥¥ 	
public
¬¬ !
EstadoDeEliminacion
¬¬ "
EliminarJugador
¬¬# 2
(
¬¬2 3
Jugador
¬¬3 :
jugador
¬¬; B
)
¬¬B C
{
­­ 	
Autenticacion
®® 
autenticacion
®® '
=
®®( )
new
®®* -
Autenticacion
®®. ;
(
®®; <
)
®®< =
;
®®= >
return
¯¯ 
autenticacion
¯¯  
.
¯¯  !
EliminarJugador
¯¯! 0
(
¯¯0 1
jugador
¯¯1 8
.
¯¯8 9
usuario
¯¯9 @
,
¯¯@ A
jugador
¯¯B I
.
¯¯I J
contrasenia
¯¯J U
)
¯¯U V
;
¯¯V W
}
°° 	
public
¸¸ "
EstadoUnirseAPartida
¸¸ #
UnirseAPartida
¸¸$ 2
(
¸¸2 3
Jugador
¸¸3 :
jugador
¸¸; B
,
¸¸B C
string
¸¸D J
codigoDePartida
¸¸K Z
)
¸¸Z [
{
¹¹ 	
bool
ºº 
encontroPartida
ºº  
=
ºº! "
false
ºº# (
;
ºº( )
foreach
»» 
(
»» 
Partida
»» 
partida
»» $
in
»»% '
partidas
»»( 0
)
»»0 1
{
¼¼ 
if
½½ 
(
½½ 
partida
½½ 
.
½½ 
codigoDePartida
½½ +
==
½½, .
codigoDePartida
½½/ >
)
½½> ?
{
¾¾ 
encontroPartida
¿¿ #
=
¿¿$ %
true
¿¿& *
;
¿¿* +
if
ÀÀ 
(
ÀÀ 
partida
ÀÀ 
.
ÀÀ  
	jugadores
ÀÀ  )
[
ÀÀ) *
$num
ÀÀ* +
]
ÀÀ+ ,
!=
ÀÀ- /
null
ÀÀ0 4
)
ÀÀ4 5
{
ÁÁ 
return
ÂÂ "
EstadoUnirseAPartida
ÂÂ 3
.
ÂÂ3 4)
FallidoPorMaximoDeJugadores
ÂÂ4 O
;
ÂÂO P
}
ÃÃ 
else
ÄÄ 
{
ÅÅ 
partida
ÆÆ 
.
ÆÆ  
	jugadores
ÆÆ  )
[
ÆÆ) *
$num
ÆÆ* +
]
ÆÆ+ ,
=
ÆÆ- .
jugador
ÆÆ/ 6
;
ÆÆ6 7
break
ÇÇ 
;
ÇÇ 
}
ÈÈ 
}
ÉÉ 
}
ÊÊ 
if
ËË 
(
ËË 
!
ËË 
encontroPartida
ËË  
)
ËË  !
return
ÌÌ "
EstadoUnirseAPartida
ÌÌ +
.
ÌÌ+ ,+
FallidoPorPartidaNoEncontrada
ÌÌ, I
;
ÌÌI J
return
ÍÍ "
EstadoUnirseAPartida
ÍÍ '
.
ÍÍ' (
Correcto
ÍÍ( 0
;
ÍÍ0 1
}
ÎÎ 	
public
ÔÔ 
void
ÔÔ  
InicializarPartida
ÔÔ &
(
ÔÔ& '
string
ÔÔ' -
codigoDePartida
ÔÔ. =
)
ÔÔ= >
{
ÕÕ 	
foreach
ÖÖ 
(
ÖÖ 
Partida
ÖÖ 
partida
ÖÖ $
in
ÖÖ% '
partidas
ÖÖ( 0
)
ÖÖ0 1
{
×× 
if
ØØ 
(
ØØ 
partida
ØØ 
.
ØØ 
codigoDePartida
ØØ +
==
ØØ, .
codigoDePartida
ØØ/ >
)
ØØ> ?
{
ÙÙ 
foreach
ÚÚ 
(
ÚÚ 
var
ÚÚ  

conexiones
ÚÚ! +
in
ÚÚ, .
	jugadores
ÚÚ/ 8
.
ÚÚ8 9
Keys
ÚÚ9 =
)
ÚÚ= >
{
ÛÛ 
if
ÜÜ 
(
ÜÜ 
	jugadores
ÜÜ %
[
ÜÜ% &

conexiones
ÜÜ& 0
]
ÜÜ0 1
.
ÜÜ1 2
usuario
ÜÜ2 9
==
ÜÜ: <
partida
ÜÜ= D
.
ÜÜD E
	jugadores
ÜÜE N
[
ÜÜN O
$num
ÜÜO P
]
ÜÜP Q
.
ÜÜQ R
usuario
ÜÜR Y
)
ÜÜY Z
{
İİ 

conexiones
ŞŞ &
.
ŞŞ& '
IniciarPartida
ŞŞ' 5
(
ŞŞ5 6
partida
ŞŞ6 =
.
ŞŞ= >
	jugadores
ŞŞ> G
[
ŞŞG H
$num
ŞŞH I
]
ŞŞI J
.
ŞŞJ K
usuario
ŞŞK R
)
ŞŞR S
;
ŞŞS T
}
ßß 
if
àà 
(
àà 
	jugadores
àà %
[
àà% &

conexiones
àà& 0
]
àà0 1
.
àà1 2
usuario
àà2 9
==
àà: <
partida
àà= D
.
ààD E
	jugadores
ààE N
[
ààN O
$num
ààO P
]
ààP Q
.
ààQ R
usuario
ààR Y
)
ààY Z
{
áá 

conexiones
ââ &
.
ââ& '
IniciarPartida
ââ' 5
(
ââ5 6
partida
ââ6 =
.
ââ= >
	jugadores
ââ> G
[
ââG H
$num
ââH I
]
ââI J
.
ââJ K
usuario
ââK R
)
ââR S
;
ââS T
}
ãã 
}
ää 
break
åå 
;
åå 
}
ææ 
}
çç 
}
èè 	
public
ğğ 
void
ğğ 
EliminarPartida
ğğ #
(
ğğ# $
string
ğğ$ *
codigoDePartida
ğğ+ :
,
ğğ: ;
string
ğğ< B 
usuarioQueFinaliza
ğğC U
,
ğğU V
EstadoPartida
ğğW d
estadoPartida
ğğe r
)
ğğr s
{
ññ 	
foreach
òò 
(
òò 
Partida
òò 
partida
òò $
in
òò% '
partidas
òò( 0
)
òò0 1
{
óó 
if
ôô 
(
ôô 
partida
ôô 
.
ôô 
codigoDePartida
ôô +
==
ôô, .
codigoDePartida
ôô/ >
)
ôô> ?
{
õõ 
if
öö 
(
öö 
partida
öö 
.
öö  
	jugadores
öö  )
[
öö) *
$num
öö* +
]
öö+ ,
!=
öö- /
null
öö0 4
&&
öö5 7 
usuarioQueFinaliza
öö8 J
==
ööK M
partida
ööN U
.
ööU V
	jugadores
ööV _
[
öö_ `
$num
öö` a
]
ööa b
.
ööb c
usuario
ööc j
)
ööj k
{
÷÷ 
foreach
øø 
(
øø  !
var
øø! $

conexiones
øø% /
in
øø0 2
	jugadores
øø3 <
.
øø< =
Keys
øø= A
)
øøA B
{
ùù 
if
úú 
(
úú  
	jugadores
úú  )
[
úú) *

conexiones
úú* 4
]
úú4 5
.
úú5 6
usuario
úú6 =
==
úú> @
partida
úúA H
.
úúH I
	jugadores
úúI R
[
úúR S
$num
úúS T
]
úúT U
.
úúU V
usuario
úúV ]
)
úú] ^
{
ûû 

conexiones
üü  *
.
üü* +"
DesconectarDePartida
üü+ ?
(
üü? @
estadoPartida
üü@ M
)
üüM N
;
üüN O
}
ıı 
}
şş 
}
ÿÿ 
else
€€ 
if
€€ 
(
€€ 
partida
€€ $
.
€€$ %
	jugadores
€€% .
[
€€. /
$num
€€/ 0
]
€€0 1
!=
€€2 4
null
€€5 9
&&
€€: < 
usuarioQueFinaliza
€€= O
==
€€P R
partida
€€S Z
.
€€Z [
	jugadores
€€[ d
[
€€d e
$num
€€e f
]
€€f g
.
€€g h
usuario
€€h o
)
€€o p
{
 
foreach
‚‚ 
(
‚‚  !
var
‚‚! $

conexiones
‚‚% /
in
‚‚0 2
	jugadores
‚‚3 <
.
‚‚< =
Keys
‚‚= A
)
‚‚A B
{
ƒƒ 
if
„„ 
(
„„  
	jugadores
„„  )
[
„„) *

conexiones
„„* 4
]
„„4 5
.
„„5 6
usuario
„„6 =
==
„„> @
partida
„„A H
.
„„H I
	jugadores
„„I R
[
„„R S
$num
„„S T
]
„„T U
.
„„U V
usuario
„„V ]
)
„„] ^
{
…… 

conexiones
††  *
.
††* +"
DesconectarDePartida
††+ ?
(
††? @
estadoPartida
††@ M
)
††M N
;
††N O
}
‡‡ 
}
ˆˆ 
}
‰‰ 
partidas
ŠŠ 
.
ŠŠ 
Remove
ŠŠ #
(
ŠŠ# $
partida
ŠŠ$ +
)
ŠŠ+ ,
;
ŠŠ, -
break
‹‹ 
;
‹‹ 
}
ŒŒ 
}
 
}
 	
public
˜˜ 
void
˜˜ '
EliminarPartidaConGanador
˜˜ -
(
˜˜- .
string
˜˜. 4
codigoDePartida
˜˜5 D
,
˜˜D E
string
˜˜F L 
usuarioQueFinaliza
˜˜M _
,
˜˜_ `
EstadoPartida
˜˜a n
estadoPartida
˜˜o |
,
˜˜| }
float˜˜~ ƒ
puntaje˜˜„ ‹
,˜˜‹ Œ
string˜˜ “
ganador˜˜” ›
)˜˜› œ
{
™™ 	
foreach
šš 
(
šš 
Partida
šš 
partida
šš $
in
šš% '
partidas
šš( 0
)
šš0 1
{
›› 
if
œœ 
(
œœ 
partida
œœ 
.
œœ 
codigoDePartida
œœ +
==
œœ, .
codigoDePartida
œœ/ >
)
œœ> ?
{
 
var
 "
estadoAgregarPuntaje
 ,
=
- .$
AgregarPuntajeAJugador
/ E
(
E F
ganador
F M
,
M N
puntaje
O V
)
V W
;
W X
if
ŸŸ 
(
ŸŸ "
estadoAgregarPuntaje
ŸŸ ,
==
ŸŸ- /%
EstadoAgregarPuntuacion
ŸŸ0 G
.
ŸŸG H
Correcto
ŸŸH P
)
ŸŸP Q
Console
   
.
    
	WriteLine
    )
(
  ) *
$str
  * <
)
  < =
;
  = >
else
¡¡ 
Console
¢¢ 
.
¢¢  
	WriteLine
¢¢  )
(
¢¢) *
$str
¢¢* ?
)
¢¢? @
;
¢¢@ A
if
££ 
(
££ 
partida
££ 
.
££  
	jugadores
££  )
[
££) *
$num
££* +
]
££+ ,
!=
££- /
null
££0 4
&&
££5 7 
usuarioQueFinaliza
££8 J
==
££K M
partida
££N U
.
££U V
	jugadores
££V _
[
££_ `
$num
££` a
]
££a b
.
££b c
usuario
££c j
)
££j k
{
¤¤ 
foreach
¥¥ 
(
¥¥  !
var
¥¥! $

conexiones
¥¥% /
in
¥¥0 2
	jugadores
¥¥3 <
.
¥¥< =
Keys
¥¥= A
)
¥¥A B
{
¦¦ 
if
§§ 
(
§§  
	jugadores
§§  )
[
§§) *

conexiones
§§* 4
]
§§4 5
.
§§5 6
usuario
§§6 =
==
§§> @
partida
§§A H
.
§§H I
	jugadores
§§I R
[
§§R S
$num
§§S T
]
§§T U
.
§§U V
usuario
§§V ]
)
§§] ^
{
¨¨ 
if
©©  "
(
©©# $
	jugadores
©©$ -
[
©©- .

conexiones
©©. 8
]
©©8 9
.
©©9 :
usuario
©©: A
!=
©©B D
ganador
©©E L
&&
©©M O
estadoPartida
©©P ]
==
©©^ `
EstadoPartida
©©a n
.
©©n o!
FinDePartidaGanada©©o 
)©© ‚

conexiones
ªª$ .
.
ªª. /"
DesconectarDePartida
ªª/ C
(
ªªC D
EstadoPartida
ªªD Q
.
ªªQ R!
FinDePartidaPerdida
ªªR e
)
ªªe f
;
ªªf g
else
««  $

conexiones
¬¬$ .
.
¬¬. /"
DesconectarDePartida
¬¬/ C
(
¬¬C D
estadoPartida
¬¬D Q
)
¬¬Q R
;
¬¬R S
}
­­ 
}
®® 
}
¯¯ 
else
°° 
if
°° 
(
°° 
partida
°° $
.
°°$ %
	jugadores
°°% .
[
°°. /
$num
°°/ 0
]
°°0 1
!=
°°2 4
null
°°5 9
&&
°°: < 
usuarioQueFinaliza
°°= O
==
°°P R
partida
°°S Z
.
°°Z [
	jugadores
°°[ d
[
°°d e
$num
°°e f
]
°°f g
.
°°g h
usuario
°°h o
)
°°o p
{
±± 
foreach
²² 
(
²²  !
var
²²! $

conexiones
²²% /
in
²²0 2
	jugadores
²²3 <
.
²²< =
Keys
²²= A
)
²²A B
{
³³ 
if
´´ 
(
´´  
	jugadores
´´  )
[
´´) *

conexiones
´´* 4
]
´´4 5
.
´´5 6
usuario
´´6 =
==
´´> @
partida
´´A H
.
´´H I
	jugadores
´´I R
[
´´R S
$num
´´S T
]
´´T U
.
´´U V
usuario
´´V ]
)
´´] ^
{
µµ 
if
¶¶  "
(
¶¶# $
	jugadores
¶¶$ -
[
¶¶- .

conexiones
¶¶. 8
]
¶¶8 9
.
¶¶9 :
usuario
¶¶: A
!=
¶¶B D
ganador
¶¶E L
&&
¶¶M O
estadoPartida
¶¶P ]
==
¶¶^ `
EstadoPartida
¶¶a n
.
¶¶n o!
FinDePartidaGanada¶¶o 
)¶¶ ‚

conexiones
··$ .
.
··. /"
DesconectarDePartida
··/ C
(
··C D
EstadoPartida
··D Q
.
··Q R!
FinDePartidaPerdida
··R e
)
··e f
;
··f g
else
¸¸  $

conexiones
¹¹$ .
.
¹¹. /"
DesconectarDePartida
¹¹/ C
(
¹¹C D
estadoPartida
¹¹D Q
)
¹¹Q R
;
¹¹R S
}
ºº 
}
»» 
}
¼¼ 
partidas
½½ 
.
½½ 
Remove
½½ #
(
½½# $
partida
½½$ +
)
½½+ ,
;
½½, -
break
¾¾ 
;
¾¾ 
}
¿¿ 
}
ÀÀ 
}
ÁÁ 	
public
ÉÉ %
EstadoAgregarPuntuacion
ÉÉ &$
AgregarPuntajeAJugador
ÉÉ' =
(
ÉÉ= >
string
ÉÉ> D
usuario
ÉÉE L
,
ÉÉL M
float
ÉÉN S
puntaje
ÉÉT [
)
ÉÉ[ \
{
ÊÊ 	
foreach
ËË 
(
ËË 
var
ËË 

conexiones
ËË #
in
ËË$ &
	jugadores
ËË' 0
.
ËË0 1
Keys
ËË1 5
)
ËË5 6
{
ÌÌ 
if
ÍÍ 
(
ÍÍ 
	jugadores
ÍÍ 
[
ÍÍ 

conexiones
ÍÍ (
]
ÍÍ( )
.
ÍÍ) *
usuario
ÍÍ* 1
==
ÍÍ2 4
usuario
ÍÍ5 <
)
ÍÍ< =
{
ÎÎ 
using
ÏÏ 
(
ÏÏ 
var
ÏÏ 
contexto
ÏÏ '
=
ÏÏ( )
new
ÏÏ* -
JugadorContexto
ÏÏ. =
(
ÏÏ= >
)
ÏÏ> ?
)
ÏÏ? @
{
ĞĞ 
float
ÑÑ 
puntajeDelJugador
ÑÑ /
=
ÑÑ0 1
(
ÑÑ2 3
from
ÑÑ3 7
jugador
ÑÑ8 ?
in
ÑÑ@ B
contexto
ÑÑC K
.
ÑÑK L
	jugadores
ÑÑL U
where
ÒÒ3 8
jugador
ÒÒ9 @
.
ÒÒ@ A
usuario
ÒÒA H
==
ÒÒI K
usuario
ÒÒL S
select
ÓÓ3 9
jugador
ÓÓ: A
.
ÓÓA B
puntaje
ÓÓB I
)
ÓÓI J
.
ÓÓJ K
First
ÓÓK P
(
ÓÓP Q
)
ÓÓQ R
.
ÓÓR S
Value
ÓÓS X
;
ÓÓX Y
puntajeDelJugador
ÕÕ )
+=
ÕÕ* ,
puntaje
ÕÕ- 4
;
ÕÕ4 5
var
ÖÖ 
	jugadorBD
ÖÖ %
=
ÖÖ& '
contexto
ÖÖ( 0
.
ÖÖ0 1
	jugadores
ÖÖ1 :
.
ÖÖ: ;
Where
ÖÖ; @
(
ÖÖ@ A
j
ÖÖA B
=>
ÖÖC E
j
ÖÖF G
.
ÖÖG H
usuario
ÖÖH O
==
ÖÖP R
usuario
ÖÖS Z
)
ÖÖZ [
.
ÖÖ[ \
FirstOrDefault
ÖÖ\ j
(
ÖÖj k
)
ÖÖk l
;
ÖÖl m
Jugador
×× 
copia
××  %
=
××& '
new
××( +
Jugador
××, 3
(
××3 4
)
××4 5
{
××6 7
usuario
××8 ?
=
××@ A
	jugadorBD
××B K
.
××K L
usuario
××L S
,
××S T
contrasenia
××U `
=
××a b
	jugadorBD
××c l
.
××l m
contrasenia
××m x
,
××x y
correo××z €
=×× ‚
	jugadorBD××ƒ Œ
.××Œ 
correo×× “
,××“ ”
imagenUsuario××• ¢
=××£ ¤
	jugadorBD××¥ ®
.××® ¯
imagenUsuario××¯ ¼
,××¼ ½
	JugadorId××¾ Ç
=××È É
	jugadorBD××Ê Ó
.××Ó Ô
	JugadorId××Ô İ
,××İ Ş
puntaje××ß æ
=××ç è!
puntajeDelJugador××é ú
}××û ü
;××ü ı
if
ØØ 
(
ØØ 
	jugadorBD
ØØ %
!=
ØØ& (
null
ØØ) -
)
ØØ- .
{
ÙÙ 
contexto
ÚÚ $
.
ÚÚ$ %
Entry
ÚÚ% *
(
ÚÚ* +
	jugadorBD
ÚÚ+ 4
)
ÚÚ4 5
.
ÚÚ5 6
CurrentValues
ÚÚ6 C
.
ÚÚC D
	SetValues
ÚÚD M
(
ÚÚM N
copia
ÚÚN S
)
ÚÚS T
;
ÚÚT U
}
ÛÛ 
try
ÜÜ 
{
İİ 
contexto
ŞŞ $
.
ŞŞ$ %
SaveChanges
ŞŞ% 0
(
ŞŞ0 1
)
ŞŞ1 2
;
ŞŞ2 3
}
ßß 
catch
àà 
(
àà 
	Exception
àà (
	exception
àà) 2
)
àà2 3
when
àà4 8
(
àà9 :
	exception
àà: C
is
ààD F
SmtpException
ààG T
||
ààU W
	exception
ààX a
is
ààb d'
InvalidOperationException
ààe ~
||
áá 
	exception
áá %
is
áá& (
FormatException
áá) 8
||
áá9 ;
	exception
áá< E
is
ááF H#
ArgumentNullException
ááI ^
)
áá^ _
{
ââ 
Console
ãã #
.
ãã# $
	WriteLine
ãã$ -
(
ãã- .
	exception
ãã. 7
.
ãã7 8

StackTrace
ãã8 B
)
ããB C
;
ããC D
return
ää "%
EstadoAgregarPuntuacion
ää# :
.
ää: ;
Fallido
ää; B
;
ääB C
}
ææ 
}
çç 
return
èè %
EstadoAgregarPuntuacion
èè 2
.
èè2 3
Correcto
èè3 ;
;
èè; <
}
éé 
}
êê 
return
ëë %
EstadoAgregarPuntuacion
ëë *
.
ëë* +
Fallido
ëë+ 2
;
ëë2 3
}
ìì 	
public
ôô 
void
ôô %
InsertarFichaEnOponente
ôô +
(
ôô+ ,
int
ôô, /
columna
ôô0 7
,
ôô7 8
string
ôô9 ?
codigoDePartida
ôô@ O
,
ôôO P
string
ôôQ W
oponente
ôôX `
)
ôô` a
{
õõ 	
foreach
öö 
(
öö 
Partida
öö 
partida
öö $
in
öö% '
partidas
öö( 0
)
öö0 1
{
÷÷ 
if
øø 
(
øø 
partida
øø 
.
øø 
codigoDePartida
øø +
==
øø, .
codigoDePartida
øø/ >
)
øø> ?
{
ùù 
if
úú 
(
úú 
partida
úú 
.
úú  
	jugadores
úú  )
[
úú) *
$num
úú* +
]
úú+ ,
.
úú, -
usuario
úú- 4
==
úú5 7
oponente
úú8 @
)
úú@ A
{
ûû 
foreach
üü 
(
üü  !
var
üü! $

conexiones
üü% /
in
üü0 2
	jugadores
üü3 <
.
üü< =
Keys
üü= A
)
üüA B
{
ıı 
if
şş 
(
şş  
	jugadores
şş  )
[
şş) *

conexiones
şş* 4
]
şş4 5
.
şş5 6
usuario
şş6 =
==
şş> @
oponente
şşA I
)
şşI J
{
ÿÿ 

conexiones
€€  *
.
€€* +$
InsertarFichaEnTablero
€€+ A
(
€€A B
columna
€€B I
)
€€I J
;
€€J K
}
 
}
‚‚ 
}
ƒƒ 
else
„„ 
{
…… 
foreach
†† 
(
††  !
var
††! $

conexiones
††% /
in
††0 2
	jugadores
††3 <
.
††< =
Keys
††= A
)
††A B
{
‡‡ 
if
ˆˆ 
(
ˆˆ  
	jugadores
ˆˆ  )
[
ˆˆ) *

conexiones
ˆˆ* 4
]
ˆˆ4 5
.
ˆˆ5 6
usuario
ˆˆ6 =
==
ˆˆ> @
partida
ˆˆA H
.
ˆˆH I
	jugadores
ˆˆI R
[
ˆˆR S
$num
ˆˆS T
]
ˆˆT U
.
ˆˆU V
usuario
ˆˆV ]
)
ˆˆ] ^
{
‰‰ 

conexiones
ŠŠ  *
.
ŠŠ* +$
InsertarFichaEnTablero
ŠŠ+ A
(
ŠŠA B
columna
ŠŠB I
)
ŠŠI J
;
ŠŠJ K
}
‹‹ 
}
ŒŒ 
}
 
}
 
}
 
}
 	
}
‘‘ 
}’’ …
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
} ñ
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
} â
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
} ×	
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
} Š
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
]$$) *œ
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
} ˆ
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
} ã/
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
puntaje	!!} „
,
!!„ …
string
!!† Œ
ganador
!! ”
)
!!” •
;
!!• –
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
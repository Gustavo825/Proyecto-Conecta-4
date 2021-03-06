ēJ
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
[	 
]
 
imagenDeJugador
 
)
 
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
CifrarContrasenia	,,z 
(
,, #
contraseniaARegistrar
,, Ą
)
,,Ą ĸ
,
,,ĸ Ŗ
correo
,,¤ Ē
=
,,Ģ Ŧ
correoARegistrar
,,­ Ŋ
,
,,Ŋ ž
puntaje
,,ŋ Æ
=
,,Į Č
$num
,,É Ę
,
,,Ë Ė
imagenUsuario
,,Í Ú
=
,,Û Ü
imagenDeJugador
,,Ũ ė
}
,,í î
)
,,î ī
;
,,ī đ
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
contraseniaCifrada	nnv 
)
nn 
)
nn 
;
nn 
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
 
} 	
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
} ˙î
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
 
void
 
InicializarChat
 #
(
# $
)
$ %
{
 	
var
 
conexion
 
=
 
OperationContext
 +
.
+ ,
Current
, 3
.
3 4 
GetCallbackChannel
4 F
<
F G
IJugadorCallBack
G W
>
W X
(
X Y
)
Y Z
;
Z [
string
 
[
 
]
  
nombresDeJugadores
 '
=
( )
new
* -
string
. 4
[
4 5
	jugadores
5 >
.
> ?
Count
? D
(
D E
)
E F
]
F G
;
G H
var
 
i
 
=
 
$num
 
;
 
foreach
 
(
 
Jugador
 
nombre
 #
in
$ &
	jugadores
' 0
.
0 1
Values
1 7
)
7 8
{
  
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
 

conexiones
 
.
 +
ActualizarJugadoresConectados
 8
(
8 9 
nombresDeJugadores
9 K
)
K L
;
L M
}
 
}
 	
public
 
void
 
MandarMensaje
 !
(
! "
Mensaje
" )
mensaje
* 1
,
1 2
Jugador
3 :$
jugadorQueMandaMensaje
; Q
)
Q R
{
 	
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
 
i
 
=
 
$num
 
;
 
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
ĄĄ  
nombresDeJugadores
ĸĸ "
[
ĸĸ" #
i
ĸĸ# $
]
ĸĸ$ %
=
ĸĸ& '
nombre
ĸĸ( .
.
ĸĸ. /
usuario
ĸĸ/ 6
;
ĸĸ6 7
i
ŖŖ 
++
ŖŖ 
;
ŖŖ 
}
¤¤ 
foreach
ĨĨ 
(
ĨĨ 
var
ĨĨ 

conexiones
ĨĨ #
in
ĨĨ$ &
	jugadores
ĨĨ' 0
.
ĨĨ0 1
Keys
ĨĨ1 5
)
ĨĨ5 6
{
ĻĻ 
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
ŠŠ 
.
ŠŠ 
RecibirMensaje
ŠŠ )
(
ŠŠ) *$
jugadorQueMandaMensaje
ŠŠ* @
,
ŠŠ@ A
mensaje
ŠŠB I
,
ŠŠI J 
nombresDeJugadores
ŠŠK ]
)
ŠŠ] ^
;
ŠŠ^ _
}
ĒĒ 
}
ĢĢ 	
public
ŗŗ 
void
ŗŗ "
MandarMensajePrivado
ŗŗ (
(
ŗŗ( )
Mensaje
ŗŗ) 0
mensaje
ŗŗ1 8
,
ŗŗ8 9
string
ŗŗ: @
nombreJugador
ŗŗA N
,
ŗŗN O
Jugador
ŗŗP W$
jugadorQueMandaMensaje
ŗŗX n
)
ŗŗn o
{
´´ 	
Console
ĩĩ 
.
ĩĩ 
	WriteLine
ĩĩ 
(
ĩĩ 
$str
ĩĩ '
,
ĩĩ' ($
jugadorQueMandaMensaje
ĩĩ) ?
.
ĩĩ? @
usuario
ĩĩ@ G
,
ĩĩG H
mensaje
ĩĩI P
.
ĩĩP Q
ContenidoMensaje
ĩĩQ a
)
ĩĩa b
;
ĩĩb c
string
ļļ 
[
ļļ 
]
ļļ  
nombresDeJugadores
ļļ '
=
ļļ( )
new
ļļ* -
string
ļļ. 4
[
ļļ4 5
	jugadores
ļļ5 >
.
ļļ> ?
Count
ļļ? D
(
ļļD E
)
ļļE F
]
ļļF G
;
ļļG H
var
ˇˇ 
i
ˇˇ 
=
ˇˇ 
$num
ˇˇ 
;
ˇˇ 
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
šš  
nombresDeJugadores
ēē "
[
ēē" #
i
ēē# $
]
ēē$ %
=
ēē& '
nombre
ēē( .
.
ēē. /
usuario
ēē/ 6
;
ēē6 7
i
ģģ 
++
ģģ 
;
ģģ 
}
ŧŧ 
foreach
ŊŊ 
(
ŊŊ 
var
ŊŊ 

conexiones
ŊŊ #
in
ŊŊ$ &
	jugadores
ŊŊ' 0
.
ŊŊ0 1
Keys
ŊŊ1 5
)
ŊŊ5 6
{
žž 
if
ŋŋ 
(
ŋŋ 
	jugadores
ŋŋ 
[
ŋŋ 

conexiones
ŋŋ (
]
ŋŋ( )
.
ŋŋ) *
usuario
ŋŋ* 1
==
ŋŋ2 4$
jugadorQueMandaMensaje
ŋŋ5 K
.
ŋŋK L
usuario
ŋŋL S
)
ŋŋS T
continue
ĀĀ 
;
ĀĀ 
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
ĮĮ 	
public
ĖĖ 
void
ĖĖ *
RecuperarPuntajesDeJugadores
ĖĖ 0
(
ĖĖ0 1
)
ĖĖ1 2
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
ĪĪ 
(
ĪĪ 
var
ĪĪ 
contexto
ĪĪ 
=
ĪĪ  !
new
ĪĪ" %
JugadorContexto
ĪĪ& 5
(
ĪĪ5 6
)
ĪĪ6 7
)
ĪĪ7 8
{
ĐĐ 
var
ŅŅ 
	jugadores
ŅŅ 
=
ŅŅ 
(
ŅŅ  !
from
ŅŅ! %
jugador
ŅŅ& -
in
ŅŅ. 0
contexto
ŅŅ1 9
.
ŅŅ9 :
	jugadores
ŅŅ: C
select
ŌŌ! '
jugador
ŌŌ( /
)
ŌŌ/ 0
.
ŌŌ0 1
ToList
ŌŌ1 7
(
ŌŌ7 8
)
ŌŌ8 9
.
ŌŌ9 :
OrderByDescending
ŌŌ: K
(
ŌŌK L
x
ŌŌL M
=>
ŌŌN P
x
ŌŌQ R
.
ŌŌR S
puntaje
ŌŌS Z
)
ŌŌZ [
;
ŌŌ[ \
var
ĶĶ 
jugadoresArreglo
ĶĶ $
=
ĶĶ% &
new
ĶĶ' *
Jugador
ĶĶ+ 2
[
ĶĶ2 3
	jugadores
ĶĶ3 <
.
ĶĶ< =
Count
ĶĶ= B
(
ĶĶB C
)
ĶĶC D
]
ĶĶD E
;
ĶĶE F
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
ŲŲ 
++
ŲŲ 
;
ŲŲ 
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
ŨŨ 
}
ŪŪ 	
public
čč 
EstadoDeRegistro
čč 
RegistroDeJugador
čč  1
(
čč1 2
string
čč2 8
usuario
čč9 @
,
čč@ A
string
ččB H
contrasenia
ččI T
,
ččT U
string
ččV \
correo
čč] c
,
ččc d
byte
čče i
[
čči j
]
ččj k
imagenDeJugador
ččl {
)
čč{ |
{
éé 	
Autenticacion
ęę 
autenticacion
ęę '
=
ęę( )
new
ęę* -
Autenticacion
ęę. ;
(
ęę; <
)
ęę< =
;
ęę= >
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
ėė 
estadoDeRegistro
ėė #
;
ėė# $
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
ųų 

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
ũũ 
.
ũũ #
UseDefaultCredentials
ũũ 1
=
ũũ2 3
false
ũũ4 9
;
ũũ9 :
smtpCliente
ūū 
.
ūū 
Credentials
ūū '
=
ūū( )
new
ūū* -
NetworkCredential
ūū. ?
(
ūū? @
CORREO
ūū@ F
,
ūūF G
CONTRASENIA
ūūH S
)
ūūS T
;
ūūT U
using
˙˙ 
(
˙˙ 
MailMessage
˙˙ "
mensaje
˙˙# *
=
˙˙+ ,
new
˙˙- 0
MailMessage
˙˙1 <
(
˙˙< =
)
˙˙= >
)
˙˙> ?
{
 
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
 
.
 
Subject
 #
=
$ %
$str
& K
;
K L
mensaje
 
.
 
Body
  
=
! "
$str
# [
+
\ ]
codigoDeRegistro
^ n
;
n o
mensaje
 
.
 

IsBodyHtml
 &
=
' (
false
) .
;
. /
mensaje
 
.
 
To
 
.
 
Add
 "
(
" #
correoDeRegistro
# 3
)
3 4
;
4 5
smtpCliente
 
.
  
Send
  $
(
$ %
mensaje
% ,
)
, -
;
- .
estado
 
=
 
EstadoDeEnvio
 *
.
* +
Correcto
+ 3
;
3 4
}
 
}
 
catch
 
(
 
	Exception
 
	exception
 &
)
& '
when
( ,
(
- .
	exception
. 7
is
8 :
SmtpException
; H
||
I K
	exception
L U
is
V X'
InvalidOperationException
Y r
||
 
	exception
 
is
 
FormatException
 +
||
, .
	exception
/ 8
is
9 ;#
ArgumentNullException
< Q
)
Q R
{
 
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
 	
public
 
byte
 
[
 
]
 +
ObtenerBytesDeImagenDeJugador
 3
(
3 4
string
4 :
usuario
; B
)
B C
{
 	
using
 
(
 
var
 
contexto
 
=
  !
new
" %
JugadorContexto
& 5
(
5 6
)
6 7
)
7 8
{
 
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
% +
jugador
, 3
.
3 4
imagenUsuario
4 A
)
A B
.
B C
ToArray
C J
(
J K
)
K L
;
L M
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
ĄĄ 
bytesDeImagen
ĄĄ (
[
ĄĄ( )
$num
ĄĄ) *
]
ĄĄ* +
;
ĄĄ+ ,
else
ĸĸ 
return
ŖŖ 
null
ŖŖ 
;
ŖŖ  
}
¤¤ 
}
ĨĨ 	
public
ŦŦ !
EstadoDeEliminacion
ŦŦ "
EliminarJugador
ŦŦ# 2
(
ŦŦ2 3
Jugador
ŦŦ3 :
jugador
ŦŦ; B
)
ŦŦB C
{
­­ 	
Autenticacion
ŽŽ 
autenticacion
ŽŽ '
=
ŽŽ( )
new
ŽŽ* -
Autenticacion
ŽŽ. ;
(
ŽŽ; <
)
ŽŽ< =
;
ŽŽ= >
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
šš 	
bool
ēē 
encontroPartida
ēē  
=
ēē! "
false
ēē# (
;
ēē( )
foreach
ģģ 
(
ģģ 
Partida
ģģ 
partida
ģģ $
in
ģģ% '
partidas
ģģ( 0
)
ģģ0 1
{
ŧŧ 
if
ŊŊ 
(
ŊŊ 
partida
ŊŊ 
.
ŊŊ 
codigoDePartida
ŊŊ +
==
ŊŊ, .
codigoDePartida
ŊŊ/ >
)
ŊŊ> ?
{
žž 
encontroPartida
ŋŋ #
=
ŋŋ$ %
true
ŋŋ& *
;
ŋŋ* +
if
ĀĀ 
(
ĀĀ 
partida
ĀĀ 
.
ĀĀ  
	jugadores
ĀĀ  )
[
ĀĀ) *
$num
ĀĀ* +
]
ĀĀ+ ,
!=
ĀĀ- /
null
ĀĀ0 4
)
ĀĀ4 5
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
ĮĮ 
;
ĮĮ 
}
ČČ 
}
ÉÉ 
}
ĘĘ 
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
ĖĖ "
EstadoUnirseAPartida
ĖĖ +
.
ĖĖ+ ,+
FallidoPorPartidaNoEncontrada
ĖĖ, I
;
ĖĖI J
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
ŲŲ 
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
ŨŨ 

conexiones
ŪŪ &
.
ŪŪ& '
IniciarPartida
ŪŪ' 5
(
ŪŪ5 6
partida
ŪŪ6 =
.
ŪŪ= >
	jugadores
ŪŪ> G
[
ŪŪG H
$num
ŪŪH I
]
ŪŪI J
.
ŪŪJ K
usuario
ŪŪK R
)
ŪŪR S
;
ŪŪS T
}
ßß 
if
āā 
(
āā 
	jugadores
āā %
[
āā% &

conexiones
āā& 0
]
āā0 1
.
āā1 2
usuario
āā2 9
==
āā: <
partida
āā= D
.
āāD E
	jugadores
āāE N
[
āāN O
$num
āāO P
]
āāP Q
.
āāQ R
usuario
āāR Y
)
āāY Z
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
įį 
}
čč 	
public
đđ 
void
đđ 
EliminarPartida
đđ #
(
đđ# $
string
đđ$ *
codigoDePartida
đđ+ :
,
đđ: ;
string
đđ< B 
usuarioQueFinaliza
đđC U
,
đđU V
EstadoPartida
đđW d
estadoPartida
đđe r
)
đđr s
{
ņņ 	
foreach
ōō 
(
ōō 
Partida
ōō 
partida
ōō $
in
ōō% '
partidas
ōō( 0
)
ōō0 1
{
ķķ 
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
ųų 
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
ũũ 
}
ūū 
}
˙˙ 
else
 
if
 
(
 
partida
 $
.
$ %
	jugadores
% .
[
. /
$num
/ 0
]
0 1
!=
2 4
null
5 9
&&
: < 
usuarioQueFinaliza
= O
==
P R
partida
S Z
.
Z [
	jugadores
[ d
[
d e
$num
e f
]
f g
.
g h
usuario
h o
)
o p
{
 
foreach
 
(
  !
var
! $

conexiones
% /
in
0 2
	jugadores
3 <
.
< =
Keys
= A
)
A B
{
 
if
 
(
  
	jugadores
  )
[
) *

conexiones
* 4
]
4 5
.
5 6
usuario
6 =
==
> @
partida
A H
.
H I
	jugadores
I R
[
R S
$num
S T
]
T U
.
U V
usuario
V ]
)
] ^
{
 

conexiones
  *
.
* +"
DesconectarDePartida
+ ?
(
? @
estadoPartida
@ M
)
M N
;
N O
}
 
}
 
}
 
partidas
 
.
 
Remove
 #
(
# $
partida
$ +
)
+ ,
;
, -
break
 
;
 
}
 
}
 
}
 	
public
 
void
 '
EliminarPartidaConGanador
 -
(
- .
string
. 4
codigoDePartida
5 D
,
D E
string
F L 
usuarioQueFinaliza
M _
,
_ `
EstadoPartida
a n
estadoPartida
o |
,
| }
float~ 
puntaje 
, 
string 
ganador 
) 
{
 	
foreach
 
(
 
Partida
 
partida
 $
in
% '
partidas
( 0
)
0 1
{
 
if
 
(
 
partida
 
.
 
codigoDePartida
 +
==
, .
codigoDePartida
/ >
)
> ?
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
 
(
 "
estadoAgregarPuntaje
 ,
==
- /%
EstadoAgregarPuntuacion
0 G
.
G H
Correcto
H P
)
P Q
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
ĄĄ 
Console
ĸĸ 
.
ĸĸ  
	WriteLine
ĸĸ  )
(
ĸĸ) *
$str
ĸĸ* ?
)
ĸĸ? @
;
ĸĸ@ A
if
ŖŖ 
(
ŖŖ 
partida
ŖŖ 
.
ŖŖ  
	jugadores
ŖŖ  )
[
ŖŖ) *
$num
ŖŖ* +
]
ŖŖ+ ,
!=
ŖŖ- /
null
ŖŖ0 4
&&
ŖŖ5 7 
usuarioQueFinaliza
ŖŖ8 J
==
ŖŖK M
partida
ŖŖN U
.
ŖŖU V
	jugadores
ŖŖV _
[
ŖŖ_ `
$num
ŖŖ` a
]
ŖŖa b
.
ŖŖb c
usuario
ŖŖc j
)
ŖŖj k
{
¤¤ 
foreach
ĨĨ 
(
ĨĨ  !
var
ĨĨ! $

conexiones
ĨĨ% /
in
ĨĨ0 2
	jugadores
ĨĨ3 <
.
ĨĨ< =
Keys
ĨĨ= A
)
ĨĨA B
{
ĻĻ 
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
ŠŠ  "
(
ŠŠ# $
	jugadores
ŠŠ$ -
[
ŠŠ- .

conexiones
ŠŠ. 8
]
ŠŠ8 9
.
ŠŠ9 :
usuario
ŠŠ: A
!=
ŠŠB D
ganador
ŠŠE L
&&
ŠŠM O
estadoPartida
ŠŠP ]
==
ŠŠ^ `
EstadoPartida
ŠŠa n
.
ŠŠn o!
FinDePartidaGanadaŠŠo 
)ŠŠ 

conexiones
ĒĒ$ .
.
ĒĒ. /"
DesconectarDePartida
ĒĒ/ C
(
ĒĒC D
EstadoPartida
ĒĒD Q
.
ĒĒQ R!
FinDePartidaPerdida
ĒĒR e
)
ĒĒe f
;
ĒĒf g
else
ĢĢ  $

conexiones
ŦŦ$ .
.
ŦŦ. /"
DesconectarDePartida
ŦŦ/ C
(
ŦŦC D
estadoPartida
ŦŦD Q
)
ŦŦQ R
;
ŦŦR S
}
­­ 
}
ŽŽ 
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
ąą 
foreach
˛˛ 
(
˛˛  !
var
˛˛! $

conexiones
˛˛% /
in
˛˛0 2
	jugadores
˛˛3 <
.
˛˛< =
Keys
˛˛= A
)
˛˛A B
{
ŗŗ 
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
ĩĩ 
if
ļļ  "
(
ļļ# $
	jugadores
ļļ$ -
[
ļļ- .

conexiones
ļļ. 8
]
ļļ8 9
.
ļļ9 :
usuario
ļļ: A
!=
ļļB D
ganador
ļļE L
&&
ļļM O
estadoPartida
ļļP ]
==
ļļ^ `
EstadoPartida
ļļa n
.
ļļn o!
FinDePartidaGanadaļļo 
)ļļ 

conexiones
ˇˇ$ .
.
ˇˇ. /"
DesconectarDePartida
ˇˇ/ C
(
ˇˇC D
EstadoPartida
ˇˇD Q
.
ˇˇQ R!
FinDePartidaPerdida
ˇˇR e
)
ˇˇe f
;
ˇˇf g
else
¸¸  $

conexiones
šš$ .
.
šš. /"
DesconectarDePartida
šš/ C
(
ššC D
estadoPartida
ššD Q
)
ššQ R
;
ššR S
}
ēē 
}
ģģ 
}
ŧŧ 
partidas
ŊŊ 
.
ŊŊ 
Remove
ŊŊ #
(
ŊŊ# $
partida
ŊŊ$ +
)
ŊŊ+ ,
;
ŊŊ, -
break
žž 
;
žž 
}
ŋŋ 
}
ĀĀ 
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
ĘĘ 	
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
ĖĖ 
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
ĪĪ 
(
ĪĪ 
var
ĪĪ 
contexto
ĪĪ '
=
ĪĪ( )
new
ĪĪ* -
JugadorContexto
ĪĪ. =
(
ĪĪ= >
)
ĪĪ> ?
)
ĪĪ? @
{
ĐĐ 
float
ŅŅ 
puntajeDelJugador
ŅŅ /
=
ŅŅ0 1
(
ŅŅ2 3
from
ŅŅ3 7
jugador
ŅŅ8 ?
in
ŅŅ@ B
contexto
ŅŅC K
.
ŅŅK L
	jugadores
ŅŅL U
where
ŌŌ3 8
jugador
ŌŌ9 @
.
ŌŌ@ A
usuario
ŌŌA H
==
ŌŌI K
usuario
ŌŌL S
select
ĶĶ3 9
jugador
ĶĶ: A
.
ĶĶA B
puntaje
ĶĶB I
)
ĶĶI J
.
ĶĶJ K
First
ĶĶK P
(
ĶĶP Q
)
ĶĶQ R
.
ĶĶR S
Value
ĶĶS X
;
ĶĶX Y
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
correo××z 
=×× 
	jugadorBD×× 
.×× 
correo×× 
,×× 
imagenUsuario×× ĸ
=××Ŗ ¤
	jugadorBD××Ĩ Ž
.××Ž ¯
imagenUsuario××¯ ŧ
,××ŧ Ŋ
	JugadorId××ž Į
=××Č É
	jugadorBD××Ę Ķ
.××Ķ Ô
	JugadorId××Ô Ũ
,××Ũ Ū
puntaje××ß æ
=××į č!
puntajeDelJugador××é ú
}××û ü
;××ü ũ
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
ŲŲ 
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
ŨŨ 
contexto
ŪŪ $
.
ŪŪ$ %
SaveChanges
ŪŪ% 0
(
ŪŪ0 1
)
ŪŪ1 2
;
ŪŪ2 3
}
ßß 
catch
āā 
(
āā 
	Exception
āā (
	exception
āā) 2
)
āā2 3
when
āā4 8
(
āā9 :
	exception
āā: C
is
āāD F
SmtpException
āāG T
||
āāU W
	exception
āāX a
is
āāb d'
InvalidOperationException
āāe ~
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
įį 
return
čč %
EstadoAgregarPuntuacion
čč 2
.
čč2 3
Correcto
čč3 ;
;
čč; <
}
éé 
}
ęę 
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
ėė 	
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
ųų 
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
ũũ 
if
ūū 
(
ūū  
	jugadores
ūū  )
[
ūū) *

conexiones
ūū* 4
]
ūū4 5
.
ūū5 6
usuario
ūū6 =
==
ūū> @
oponente
ūūA I
)
ūūI J
{
˙˙ 

conexiones
  *
.
* +$
InsertarFichaEnTablero
+ A
(
A B
columna
B I
)
I J
;
J K
}
 
}
 
}
 
else
 
{
 
foreach
 
(
  !
var
! $

conexiones
% /
in
0 2
	jugadores
3 <
.
< =
Keys
= A
)
A B
{
 
if
 
(
  
	jugadores
  )
[
) *

conexiones
* 4
]
4 5
.
5 6
usuario
6 =
==
> @
partida
A H
.
H I
	jugadores
I R
[
R S
$num
S T
]
T U
.
U V
usuario
V ]
)
] ^
{
 

conexiones
  *
.
* +$
InsertarFichaEnTablero
+ A
(
A B
columna
B I
)
I J
;
J K
}
 
}
 
}
 
}
 
}
 
}
 	
}
 
} 
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
} ņ
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
} 
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
]$$) *
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
} 
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
puntaje	!!} 
,
!! 
string
!! 
ganador
!! 
)
!! 
;
!! 
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
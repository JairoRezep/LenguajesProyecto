Este es nuestro juego para el proyecto final para la materia de lenguajes de programacion.

Los integrantes del grupo son: Emilio Aldean, Jairo Perez, Jesus Jimenez.

--- SOBRE EL JUEGO ---

Es un juego plataformero simple el cual consiste de 3 niveles. Para pasar al siguiente nivel se deberan superar ciertos obstaculos para obtener una cantidad minima de 30 monedas. El jugador cuenta con 5 vidas, las cuales se pueden perder a causa de los obstaculos que se mencionaran mas adelante. El personaje cuenta con distintas herramientas que le permitiran al jugador superar estos obstaculos para poder obtener la cantidad de monedas necesaria antes de que se quede sin vidas.

Los obstaculos que se presentan son 3 principalmente:
   - El primero consiste en unos golems azules, que protegen codiciosamente las monedas. Ellos nos atacaran apenas entremos en su rango y su ataque es tan potente que probablemente solo se necesiten uno o dos de estos para acabar con una de las vidas del personaje.
   - El segundo consiste en huecos por los cuales el jugador puede caer y perder una vida.
   - Y el tercer obstaculo son unas monedas rojas, las cuales nos quitaran monedas en lugar de sumarnos al recogerlas, aunque estas solo estan presentes en el 3er nivel.

Las herramientas que el jugador tiene para superar los obstaculos son:
   - La primera es bastante sencilla y es la capacidad para saltar. El jugador puede hacer que el personaje salte una vez cada vez que toque el piso utilizando la tecla space. Le es permitido maniobrar un poco en el aire utilizando las teclas A y D. Mismas con las que el jugador puede moverse a los lados cuando esta en tierra.
   - La segunda es la capacidad de atacar. El jugador puede atacar a los golems para destruirlos. Usualmente toma 2 golpes pero podria tomar mas. El jugador puede atacar con click izquierdo o con la tecla E. El personaje tiene la capacidad de atacar mientras esta en el aire.

Si el jugador llegara a perder las 5 vidas antes de completar un nivel, a este se le presentara un menu que diga "Game Over". En dicho menu tendra 2 opciones: Renunciar al juego dandole a Quit, o reintentar el nivel dandole a Retry. Si le das a la segunda opcion se reiniciara ese nivel con las 5 vidas y con el contador de monedas en 0.

--- PREFABS ---

En el proyecto se utilizaron varios Prefabs que fueron construidos por nosotros. Dentro de estos estan:
   - El personaje principal 
   - El golem azul
   - Las monedas amarillas y rojas
   - Los generadores de terreno

--- SCRIPTS ---

El juego contiene varios scripts que manejan la logica del juego. Sin embargo, hay unos scripts principales que se encargan de manejar la mayoria de esta logica. Estos son:

   -GameManager.cs : Como su nombre sugiere, este es el script que va a manejar practicamente toda la logica de nuestro juego. Este script se encargara de llevar la cuenta de las monedas que lleva acumuladas el jugador en un determinado nivel, la cantidad de vidas restante, spawnear enemigos, spawnear items, actualizar interfaces... Sirve como modulo central para practicamente todos los otros scripts del juego.

   -player.cs : Este es el script que se encarga de gestionar todo el movimiento del jugador, asi como sus acciones (saltar, atacar) y coordina las animaciones correspondientes para cada caso.

   -GenerateTerrain.cs : Este es uno de los scripts mas importantes porque es el que se encarga de generar terreno aleatoriamente. No estamos insertando gameobjects arbitrariamente, sino estamos ingresando cada uno de los componentes de lo que seria una plataforma normal en un grid de tilemaps. Es codigo hecho cuidadosamente para evitar puntos muertos y siempre darle un camino al jugador para que pueda superar terreno generado aleatoriamente.

No se utilizo ningun tipo de algoritmo o patron de diseno complejo. Todos los scripts fueron escritos e ideados por nosotros.

--- ASSETS PRINCIPALES ---

Los assets en su mayoria fueron conseguidos de forma gratuita en linea. Tanto el fondo, como los sprites y animaciones del personaje y terreno fueron conseguidos desta forma. La cancion utilizada tiene derechos de autor y se llama "One Last Adventure" de Evan Call. El sprite del Golem y sus animaciones fueron comprados por el maravilloso precio de $0.50 USD. 

--- MOTOR DE VIDEOJUEGOS ---

Este juego fue hecho utilizando la version 6.0.21f de Unity.

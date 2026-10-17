# Taller N° 10: Jefe Final (Boss Fight), Nivel 2 y Victoria

Proyecto 2D desarrollado en **Unity 6** que cierra el videojuego con un segundo nivel, una pelea contra un Jefe Final y una pantalla de victoria con opciones para reiniciar o volver al menú.

## Objetivo

- Crear la escena **Nivel2** y un portal de transición desde **Nivel1**.
- Diseñar la arena de combate contra el Jefe Final (`BossController.cs`).
- Configurar la barra de vida roja del Boss (`BarraVidaBoss`).
- Crear el panel de victoria (`PanelVictoria`) con botones conectados mediante `OnClick()`.
- Compilar el juego como ejecutable `.exe` para Windows.

## Características

### 1. Nivel 2 y portal de transición

- La escena `Nivel2` es un duplicado de `Nivel1`, registrada en **Build Profiles** con el índice 2.
- En `Nivel1` existe el portal `PuertaNivel2` con **Box Collider 2D (Is Trigger)** y el script `LevelDoor.cs`, que carga `Nivel2` cuando el jugador lo atraviesa.
- En `Nivel2` se eliminaron los enemigos pequeños para dejar la arena despejada.

### 2. Jefe Final (`BossController.cs`)

| Configuración | Valor |
|---|---|
| Escala | X = 2.5, Y = 2.5 |
| Tag / Layer | Enemy / Enemy |
| Rigidbody 2D | Freeze Rotation Z |
| Collider | Box Collider 2D |
| Vida máxima | 10 |
| Velocidad | 2 |

Comportamiento del Boss:

- **Persigue** al jugador moviéndose en el eje X con `Rigidbody2D.MovePosition`.
- **Gira el sprite** para mirar siempre hacia el jugador.
- **Recibe daño** mediante `TakeDamage(int dano)`, llamado desde `AtaqueJugador.cs`, y actualiza la barra de vida.
- **Fase de Furia:** al bajar al 50% de vida cambia a color rojo y aumenta su velocidad un 80%.
- **Muerte:** al llegar a 0 de vida activa `panelVictoriaUI`, pausa el juego con `Time.timeScale = 0f` y se destruye.

### 3. Barra de vida (`BarraVidaBoss`)

- Slider dentro del Canvas, anclado arriba al centro.
- Relleno de color rojo y sin Handle.
- Se actualiza con cada espadazo recibido por el Boss.

### 4. Pantalla de victoria (`PanelVictoria`)

- Panel dentro del Canvas con el texto **"¡JUEGO COMPLETADO!"**, oculto al iniciar.
- Dos botones conectados con `OnClick()`:

| Botón | Función |
|---|---|
| Jugar de Nuevo | `PauseMenu.Reiniciar()` |
| Menú Principal | `PauseMenu.IrAlMenu()` |

Ambas funciones restablecen `Time.timeScale = 1f` antes de cambiar de escena.

## Estructura de scripts

```
Assets/
└── Scripts/
    ├── BossController.cs     # Jefe final: persecución, barra, furia y victoria
    ├── LevelDoor.cs          # Portal que carga Nivel2
    ├── PauseMenu.cs          # Reiniciar() e IrAlMenu()
    └── AtaqueJugador.cs      # Ataque del jugador, daña al Boss con TakeDamage

JUEGO COMPILADO EXE/          # Juego compilado para Windows (.exe + _Data)
VIDEOTALLER10                 # Video demostrativo del taller
```

## Cómo ejecutar el proyecto

1. Clonar el repositorio:
   ```bash
   git clone https://github.com/edwincusin/TALLER-N-10-Jefe-Final-Nivel-2-Victoria.git
   ```
2. Abrir el proyecto con **Unity 6** desde Unity Hub.
3. Abrir la escena `Nivel1` y pulsar **Play**.
4. Cruzar el portal para llegar a `Nivel2` y enfrentar al Boss.

### Controles

| Tecla | Acción |
|---|---|
| `A` / `D` o flechas | Mover al personaje |
| `Espacio` | Saltar |
| `Z` o clic izquierdo | Atacar con la espada |

## Compilación

El juego se compiló desde **Build Profiles** (`Ctrl + Shift + B`) para la plataforma **Windows**, con las escenas en este orden: Menú (0), Nivel1 (1) y Nivel2 (2).

📁 La carpeta **`JUEGO COMPILADO EXE`** está adjunta en este repositorio. Contiene el ejecutable (`.exe`) y su carpeta `_Data`, listos para jugar sin abrir Unity. Para ejecutarlo, descarga la carpeta completa y abre el archivo `.exe` (el `.exe` y la carpeta `_Data` deben estar juntos).

## Video demostrativo

El video de demostración (máx. 10 segundos) muestra:

- Al personaje atravesando el portal de Nivel1 a Nivel2.
- Los espadazos al Boss, con la barra roja vaciándose y la entrada en Fase de Furia.
- La derrota del Boss y el botón **"Menú Principal"** en la pantalla de victoria.

**Dónde se compartió:**

- 📱 En el **grupo de WhatsApp del curso**.
- 🐙 En este **repositorio de GitHub**, con el nombre de archivo **`VIDEOTALLER10`**.

**Archivos adjuntos en el repositorio:**

| Elemento | Descripción |
|---|---|
| `VIDEOTALLER10` | Video demostrativo del taller |
| `JUEGO COMPILADO EXE/` | Carpeta con el juego compilado (`.exe` y `_Data`) |


- **Taller:** N° 10, Jefe Final (Boss Fight), Nivel 2 y Victoria
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    [Header("Vida")]
    public int vidaMaxima = 10;
    private int vidaActual;

    [Header("Interfaz")]
    public Slider barraVidaUI;
    public GameObject panelVictoriaUI;

    [Header("Movimiento")]
    public float velocidad = 2f;
    public Transform jugador;
    private Rigidbody2D cuerpoRigido;

    [Header("Fase de Furia")]
    public float multiplicadorFuria = 1.8f;
    public Color colorFuria = Color.red;
    private bool enFuria = false;
    private SpriteRenderer spriteBoss;


    void Start()
    {
        // Obtiene los componentes y busca al jugador si no fue asignado
        cuerpoRigido = GetComponent<Rigidbody2D>();
        spriteBoss = GetComponent<SpriteRenderer>();

        if (jugador == null)
        {
            GameObject objetoJugador = GameObject.FindGameObjectWithTag("Jugador");
            if (objetoJugador != null)
            {
                jugador = objetoJugador.transform;
            }
        }

        // Inicia con la vida llena y configura la barra
        vidaActual = vidaMaxima;

        if (barraVidaUI != null)
        {
            barraVidaUI.maxValue = vidaMaxima;
            barraVidaUI.value = vidaActual;
        }

        // Oculta el panel de victoria hasta que el Boss muera
        if (panelVictoriaUI != null)
        {
            panelVictoriaUI.SetActive(false);
        }
    }


    void Update()
    {
        if (jugador == null) return;

        // Persigue al jugador moviéndose solo en el eje X
        float direccion = Mathf.Sign(jugador.position.x - transform.position.x);
        float nuevaX = cuerpoRigido.position.x + direccion * velocidad * Time.deltaTime;
        cuerpoRigido.MovePosition(new Vector2(nuevaX, cuerpoRigido.position.y));

        // Gira el sprite para mirar al jugador
        if (spriteBoss != null)
        {
            spriteBoss.flipX = direccion < 0;
        }
    }


    public void TakeDamage(int dano)
    {
        // Resta vida y actualiza la barra
        vidaActual -= dano;

        if (barraVidaUI != null)
        {
            barraVidaUI.value = vidaActual;
        }

        // Activa la furia al bajar al 50% de vida
        if (vidaActual <= vidaMaxima / 2 && !enFuria)
        {
            ActivarFuria();
        }

        // Muere al llegar a 0 de vida
        if (vidaActual <= 0)
        {
            Die();
        }
    }


    void ActivarFuria()
    {
        // Cambia el color a rojo y aumenta la velocidad un 80%
        enFuria = true;

        if (spriteBoss != null)
        {
            spriteBoss.color = colorFuria;
        }

        velocidad = velocidad * multiplicadorFuria;
    }


    void Die()
    {
        // Muestra la victoria, congela el juego y destruye al Boss
        if (panelVictoriaUI != null)
        {
            panelVictoriaUI.SetActive(true);
        }

        Time.timeScale = 0f;
        Destroy(gameObject);
    }
}
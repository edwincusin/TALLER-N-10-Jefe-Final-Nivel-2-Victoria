using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalNivel2 : MonoBehaviour
{
    [Header("Destino")]
    public string nombreSiguienteEscena = "Nivel_2";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Jugador") || other.gameObject.name == "Personaje")
        {
            SceneManager.LoadScene(nombreSiguienteEscena);
        }
    }

}

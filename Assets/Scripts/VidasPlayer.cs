using UnityEngine;
using UnityEngine.UI;

public class VidasPlayer : MonoBehaviour
{
    [Header("Configuración de UI")]
    public Image[] corazones;        // Array de imágenes que representan las vidas
    public Sprite corazonRojo;       // Corazón lleno (vida)
    public Sprite corazonGris;       // Corazón vacío (sin vida)
    public GameObject gameOverImage; // Pantalla de Game Over

    private int vidaActual; // Vida actual del jugador

    // Se indica que la variable puedePerderVida es pública para permitir acceso desde otros scripts
    public static int puedePerderVida = 1;

    void Start()
    {
        vidaActual = corazones.Length; // Inicializa las vidas con la cantidad de corazones que tenga el array
        if (gameOverImage != null)
        {
            gameOverImage.SetActive(false); // Se asegura que la pantalla de Game Over no se muestre al inicio
        }
        ActualizarUI(); // Actualiza la UI para reflejar el estado inicial de las vidas
    }

    void Update()
    {
        // Esto es solo para pruebas, puedes eliminarlo o modificarlo.
        if (Input.GetKeyDown(KeyCode.K))
        {
            TomarDaño(1);  // Reduce la vida al presionar la tecla K
        }
    }

    public void TomarDaño(int daño)
    {
        if (vidaActual > 0 && puedePerderVida == 1)
        {
            puedePerderVida = 0; // Se previene que el jugador pierda vida varias veces sin esperar
            vidaActual -= daño;  // Reduce las vidas en base al daño recibido
            if (vidaActual < 0)
                vidaActual = 0; // Si la vida es negativa, se ajusta a cero

            ActualizarUI(); // Actualiza la UI con el nuevo valor de vida

            if (vidaActual == 0) // Si el jugador se queda sin vida
            {
                GameOver(); // Llama a GameOver
            }
        }
    }

    private void ActualizarUI()
    {
        // Actualiza la UI de acuerdo con la vida del jugador
        for (int i = 0; i < corazones.Length; i++)
        {
            corazones[i].sprite = (i < vidaActual) ? corazonRojo : corazonGris; // Muestra los corazones en rojo o gris
        }
    }

    private void GameOver()
    {
        // Cuando el jugador pierde todas las vidas, se muestra Game Over
        Debug.Log("Game Over");
        if (gameOverImage != null)
        {
            gameOverImage.SetActive(true);  // Muestra la pantalla de Game Over
        }
        gameObject.SetActive(false); // Desactiva el objeto del jugador
    }
}

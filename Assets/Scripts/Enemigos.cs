using UnityEngine;

public class Enemigos : MonoBehaviour
{
    [Header("Configuración del Enemigo")]
    public int vidaEnemigo = 1;
    private float frecAtaque = 2.5f;
    private float tiempoSigAtaque = 0;
    private float iniciaConteo;

    void Start()
    {
        vidaEnemigo = 1;  // Inicializa la vida del enemigo
    }

    void Update()
    {
        // Si el tiempo para el siguiente ataque es mayor que 0, reduce el tiempo
        if (tiempoSigAtaque > 0)
        {
            tiempoSigAtaque -= Time.deltaTime;
        }
        else
        {
            // Cuando el tiempo de ataque es 0, se permite que el jugador pierda vida
            tiempoSigAtaque = 0;
            VidasPlayer.puedePerderVida = 1;
        }
    }

    // Cuando el enemigo entra en contacto con el jugador, se aplica el daño
    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.CompareTag("Player")) // Compara si el objeto tocado es el jugador
        {
            // Reinicia el tiempo de ataque y marca el tiempo de inicio del siguiente ataque
            tiempoSigAtaque = frecAtaque;
            iniciaConteo = Time.time;

            Debug.Log("El enemigo ha tocado al jugador.");

            // Obtiene el script de VidasPlayer del jugador y le aplica daño
            VidasPlayer vidas = obj.transform.GetComponentInChildren<VidasPlayer>();
            if (vidas != null)
            {
                vidas.TomarDaño(1); // Aplica 1 punto de daño al jugador
            }
        }
    }

    // Método para que el enemigo reciba daño
    public void TomarDaño(int daño)
    {
        vidaEnemigo -= daño;  // Resta la vida del enemigo
        if (vidaEnemigo <= 0)  // Si la vida llega a 0 o menos, destruye al enemigo
        {
            Destroy(gameObject);  // Elimina el objeto enemigo
        }
    }
}

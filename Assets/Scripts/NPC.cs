using UnityEngine;

public class NPC : MonoBehaviour
{
    public GameObject txtDialogo;
    public Sprite primerDialogo;
    public Sprite segundoDialogo;

    private bool dialogoActivo = false;

    void Start()
    {
        txtDialogo.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            txtDialogo.SetActive(true);
            dialogoActivo = true;

            // Mostramos primer o segundo diálogo al azar (o puedes hacerlo secuencial)
            if (Random.value > 0.5f)
            {
                txtDialogo.GetComponent<SpriteRenderer>().sprite = primerDialogo;
                Debug.Log("Se mostró el primer diálogo");
            }
            else
            {
                txtDialogo.GetComponent<SpriteRenderer>().sprite = segundoDialogo;
                Debug.Log("Se mostró el segundo diálogo");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            txtDialogo.SetActive(false);
            dialogoActivo = false;
            Debug.Log("Saliste del área del NPC, diálogo cerrado");
        }
    }

    void Update()
    {
        // Cerrar el cuadro si presionas cualquier tecla mientras está activo
        if (dialogoActivo && Input.anyKeyDown)
        {
            txtDialogo.SetActive(false);
            dialogoActivo = false;
            Debug.Log("Diálogo cerrado por tecla");
        }
    }
}

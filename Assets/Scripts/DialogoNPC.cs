using UnityEngine;

public class DialogoNPC : MonoBehaviour
{
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            this.gameObject.SetActive(false);
            Debug.Log("Cuadro de texto cerrado desde DialogoNPC");
        }
    }
}


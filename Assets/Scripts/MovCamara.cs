using UnityEngine;

public class MovCamara : MonoBehaviour
{



    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "Portal1")
        {

            Vector3 posicionPlayer = new Vector3(27.8f, 5.5f, 0);
            this.transform.position = posicionPlayer;
        }
        if (obj.gameObject.tag == "Portal11")
        {

            Vector3 posicionPlayer = new Vector3(25.2f, 34f, 0);
            this.transform.position = posicionPlayer;
        }
        if (obj.gameObject.tag == "Portal2")
        {

            Vector3 posicionPlayer = new Vector3(72.6f, 1f, 0);
            this.transform.position = posicionPlayer;
        }
        if (obj.gameObject.tag == "Portal22")
        {

            Vector3 posicionPlayer = new Vector3(41.7f, 34.7f, 0);
            this.transform.position = posicionPlayer;
        }
        if (obj.gameObject.tag == "Portal3")
        {

            Vector3 posicionPlayer = new Vector3(70.4f, 27.42f, 0);
            this.transform.position = posicionPlayer;
        }
        if (obj.gameObject.tag == "Portal33")
        {

            Vector3 posicionPlayer = new Vector3(36.8f, 30.2f, 0);
            this.transform.position = posicionPlayer;
        }
        if (obj.gameObject.tag == "Portal4")
        {

            Vector3 posicionPlayer = new Vector3(34.58f, 52.5f, 0);
            this.transform.position = posicionPlayer;
        }
        if (obj.gameObject.tag == "Portal44")
        {

            Vector3 posicionPlayer = new Vector3(37.13f, 23.7f, 0);
            this.transform.position = posicionPlayer;
        }
    }
}

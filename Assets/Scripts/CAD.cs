using UnityEngine;

public class CAD : MonoBehaviour
{
    public Transform puntoEmision;
    public float tiempoSigAtaque;
    public float tiempoEntreAtaques;
    private Animator anim;
    public static int dirDisparo = 0;
    public static bool disparando = false;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tiempoSigAtaque < 0.05f && tiempoEntreAtaques > 0)
        {
            disparando = false;
        }
        if (tiempoSigAtaque > 0)
        {
            tiempoSigAtaque -= Time.deltaTime;
        }


        if (Input.GetButtonDown("Fire2") && tiempoSigAtaque <= 0)
        {
            disparando = true;
            activaCapa("Ataque");
            Golpe();
            tiempoSigAtaque = tiempoEntreAtaques;
        }
    }


    private void Golpe()
    {
        if (MovPlayer.dirAtaque == 1)
        {
            anim.SetTrigger("ShootIdle");
        }
        if (MovPlayer.dirAtaque == 2)
        {
            anim.SetTrigger("ShootArr");
        }
        if (MovPlayer.dirAtaque == 3)
        {
            anim.SetTrigger("ShooterD");
        }
        if (MovPlayer.dirAtaque == 4)
        {
            anim.SetTrigger("ShooterIz");
        }

    }


    private void activaCapa(string nombre)
    {
        for (int i = 0; i < anim.layerCount; i++)
        {
            anim.SetLayerWeight(i, 0);//Layers en 0 con weight

        }
        anim.SetLayerWeight(anim.GetLayerIndex(nombre), 1);
    }
}

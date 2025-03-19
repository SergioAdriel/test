using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class CCC : MonoBehaviour
{
    public Transform ControladorGolpe;
    public float radioGolpe;
    public int dañoGolpe;
    public float tiempoSigAtaque;
    public float tiempoEntreAtaques;
    private Animator anim;
    public static bool atacando;
    
    void Start()
    {
     anim = GetComponent<Animator>();   
    }

    void Update()
    { if (tiempoSigAtaque < 0.05f &&tiempoEntreAtaques > 0)
        {
            atacando = false;
        }
      if (tiempoSigAtaque > 0)
        {
            tiempoSigAtaque -= Time.deltaTime;
        }


    if (Input.GetButtonDown("Fire1") && tiempoSigAtaque <=0)
        {
            atacando=true;
            activaCapa("Ataque");
            Golpe();
            tiempoSigAtaque = tiempoEntreAtaques;
        }
        
    }
    private void Golpe()
    {
        if (MovPlayer.dirAtaque == 1)
        {
            anim.SetTrigger("GolpIdle");
        }if (MovPlayer.dirAtaque == 2)
        {
            anim.SetTrigger("GolAtras");
        }if (MovPlayer.dirAtaque == 3)
        {
            anim.SetTrigger("GolpD");
        }if (MovPlayer.dirAtaque == 4)
        {
            anim.SetTrigger("GolpIz");
        }

    }
    /*private void VerificaGolpe()
    {
        Collider2D[] objs = Physics2D.OverlapCircleAll(ControladorGolpe.position, radioGolpe);
        foreach (Collider2D colisionador in objs)
        {
            if (colisionador.CompareTag("enemigo"))
            {
               colisionador.transform.GetComponent<Enemigos>.TomarDaño(dañoGolpe);
            }
        }
    }*/
    private void activaCapa(string nombre)
    {
        for (int i = 0; i < anim.layerCount; i++)
        {
            anim.SetLayerWeight(i, 0);//Layers en 0 con weight

        }
        anim.SetLayerWeight(anim.GetLayerIndex(nombre), 1);
    }
}

using UnityEngine;
using System.Collections;
using System;

public class MovPlayer : MonoBehaviour
{
    private Vector2 dirMov;
    public float velMov;
    public Rigidbody2D rb;
    public Animator anim;
    private string capaIdle = "Idle";
    private string capaCaminar = "Caminar";
    private string capaAtaque = "Ataque";
    private bool PlayerMoviendose = false;
    private float ultimoMovX, ultimoMovY;
    private int vidaPersonaje = 3;
    public static int dirAtaque = 0; //1- Front, 2- Back, 3- Left, 4- Right

    void FixedUpdate()
    {
        Movimiento();
        if (CCC.atacando == false && CAD.disparando == false)
        {
            AnimacionPlayer();
        }
    }

    private void Movimiento()
    {
        float movX = Input.GetAxisRaw("Horizontal");
        float movY = Input.GetAxisRaw("Vertical");
        dirMov = new Vector2(movX, movY).normalized;
        rb.linearVelocity = new Vector2(dirMov.x * velMov, dirMov.y * velMov);

        if (movX == -1)
        {
            dirAtaque = 3;
        }

        if (movX == 1)
        {
            dirAtaque = 4;
        }

        if (movY == -1)
        {
            dirAtaque = 1;
        }

        if (movY == 1)
        {
            dirAtaque = 2;
        }

        if (movX == 0 && movY == 0)
        {
            PlayerMoviendose = false;
        }
        else
        {
            PlayerMoviendose = true;
            ultimoMovX = movX;
            ultimoMovY = movY;
        }
        ActualizarCapa();
    }

    private void AnimacionPlayer()
    {
        anim.SetFloat("movX", ultimoMovX);
        anim.SetFloat("movY", ultimoMovY);
    }

    private void ActualizarCapa()
    {
        if (CCC.atacando == false && CAD.disparando == false)
        {
            if (PlayerMoviendose)
            {
                activaCapa(capaCaminar);
                Debug.Log("Caminando");
            }
            else
            {
                activaCapa(capaIdle);
                Debug.Log("Idle");
            }
        }
        else
        {
            activaCapa("Ataque");
        }
    }

    private void activaCapa(string nombre)
    {
        for (int i = 0; i < anim.layerCount; i++)
        {
            anim.SetLayerWeight(i, 0); // Layers en 0 con weight
        }
        anim.SetLayerWeight(anim.GetLayerIndex(nombre), 1);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MacheteDaño : Interactable
{
    [SerializeField]
    private int daño;

    public FPSplayer DañoJugador;
    
    void Start()
    {
        DañoJugador = FindObjectOfType<FPSplayer>();
    }
    public override void Interact()
    {
        base.Interact();
         GetComponent<Enemy>().VidaActualEnemigo-=DañoJugador.daño;   
    }
}

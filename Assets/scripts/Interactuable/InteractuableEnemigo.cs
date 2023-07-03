using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractuableEnemigo : Interactable
{   
   
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

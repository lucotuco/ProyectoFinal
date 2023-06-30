using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractuableEnemigo : Interactable
{   
    [SerializeField]
    private int daño;

    public override void Interact()
    {
        base.Interact();
        
        GetComponent<Enemy>().VidaActualEnemigo-=daño;
        
    }
}

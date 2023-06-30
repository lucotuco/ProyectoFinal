using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueMachete : MonoBehaviour
{
    
    public GameObject machete;
    
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            gameObject.GetComponent<Animator>().SetTrigger("MacheteAccion"); 
            //Filo.GetComponent<BoxCollider>().isTrigger= true;
            //StartCoroutine(FinAtaque());
        }
    }

    IEnumerator FinAtaque()
    {
        yield return new WaitForSeconds(0.6f);
        //Filo.GetComponent<BoxCollider>().isTrigger= false;
    }
}

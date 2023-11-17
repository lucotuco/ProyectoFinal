using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptTexto : MonoBehaviour
{
    public GameObject texto;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            texto.SetActive(true);  
            Invoke("salidaTexto", 2f);
        } 
    }
    void salidaTexto()
    {
        texto.SetActive(false);
    }
}
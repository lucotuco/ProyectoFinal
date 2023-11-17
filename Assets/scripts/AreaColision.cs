using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AreaColision : MonoBehaviour
{
    public GameObject texto;
              

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
           
            texto.SetActive(true);  
        } 
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
           
            texto.SetActive(false);  
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        texto.SetActive(false);   
    }
}

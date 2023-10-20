using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManuPausa : MonoBehaviour
{
    
    public GameObject Menu;
    public bool isPause;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Menu"))
        {
            PauseUnpause();
        }   
    }

    public void PauseUnpause()
    {
        Debug.Log("S");
        if(isPause)
        {
            isPause=false;
            Menu.SetActive(true);
        }
        else
        {
            isPause=true;
            Menu.SetActive(false);
        }
    }
}

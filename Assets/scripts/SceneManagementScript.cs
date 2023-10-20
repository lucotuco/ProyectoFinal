using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagementScript : MonoBehaviour
{
    public GameObject objectToDisable;
    public static bool isObjectActive=true;

private void Star()
{
    Debug.Log(isObjectActive);
    if(isObjectActive==false)
    {
        Debug.Log("sap");
        objectToDisable.SetActive(false);
    }
      
}  
    
}

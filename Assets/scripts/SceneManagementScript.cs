using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagementScript : MonoBehaviour
{
    public GameObject objectToDeactivate;
    public GameObject objectToActivate1;
    public GameObject objectToDeactivate2;
    public GameObject objectToDeactivate3;
    public GameObject objectToActivate;
    public static int loadCount = 0;

    private void Awake()
    {
        if (loadCount >= 1)
        {
            if (objectToDeactivate != null)
            {
                objectToActivate1.SetActive(true);
                objectToDeactivate2.SetActive(false);
                objectToDeactivate3.SetActive(false);
                objectToDeactivate.SetActive(false);
                objectToActivate.SetActive(true);
            }
        }

        loadCount++;
    }
}

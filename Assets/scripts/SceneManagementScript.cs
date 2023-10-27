using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagementScript : MonoBehaviour
{
    public GameObject objectToDeactivate;
    public GameObject objectToActivate;
    public static int loadCount = 0;

    private void Awake()
    {
        if (loadCount >= 1)
        {
            if (objectToDeactivate != null)
            {
                objectToDeactivate.SetActive(false);
                objectToActivate.SetActive(true);
            }
        }

        loadCount++;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPositionManager : MonoBehaviour
{
    public static ObjectPositionManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveObjectPosition(string objectName, Vector3 position)
    {
        PlayerPrefs.SetFloat(objectName + "_x", position.x);
        PlayerPrefs.SetFloat(objectName + "_y", position.y);
        PlayerPrefs.SetFloat(objectName + "_z", position.z);
    }

    public Vector3 LoadObjectPosition(string objectName)
    {
        float x = PlayerPrefs.GetFloat(objectName + "_x", 0f);
        float y = PlayerPrefs.GetFloat(objectName + "_y", 0f);
        float z = PlayerPrefs.GetFloat(objectName + "_z", 0f);
        return new Vector3(x, y, z);
    }
}

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
        
    }

    public void SaveObjectPosition(string objectName, Vector3 position)
    {
        PlayerPrefs.SetFloat(objectName + "_x", position.x);
        PlayerPrefs.SetFloat(objectName + "_y", position.y);
        PlayerPrefs.SetFloat(objectName + "_z", position.z);
    }

    public Vector3 LoadObjectPosition(string objectName)
    {
        float x = PlayerPrefs.GetFloat(objectName + "_x", -7.909999847412109f);
        float y = PlayerPrefs.GetFloat(objectName + "_y", 3.309000015258789f);
        float z = PlayerPrefs.GetFloat(objectName + "_z", -35.77855682373047f);
        return new Vector3(x, y, z);
    }
}
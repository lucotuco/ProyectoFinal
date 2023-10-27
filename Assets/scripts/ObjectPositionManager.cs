using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPositionManager : MonoBehaviour
{
    public static ObjectPositionManager instance;

    private Dictionary<string, Vector3> objectPositions = new Dictionary<string, Vector3>();

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
        if (!objectPositions.ContainsKey(objectName))
        {
            objectPositions.Add(objectName, position);
        }
        else
        {
            objectPositions[objectName] = position;
        }
    }

    public Vector3 LoadObjectPosition(string objectName)
    {
        if (objectPositions.ContainsKey(objectName))
        {
            return objectPositions[objectName];
        }
        return Vector3.zero;
    }
}
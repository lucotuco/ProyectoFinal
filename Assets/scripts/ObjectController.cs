using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectController : MonoBehaviour
{
    private Transform myTransform;
    private Vector3 initialPosition;

    private void Start()
    {
        myTransform = transform;
        initialPosition = ObjectPositionManager.instance.LoadObjectPosition(gameObject.name);
        Debug.Log(initialPosition);
        myTransform.position = initialPosition;
    }

    // Llamado antes de cambiar de escena
    private void OnDestroy()
    {
        Debug.Log(myTransform.position);
        ObjectPositionManager.instance.SaveObjectPosition(gameObject.name, myTransform.position);
    }
}

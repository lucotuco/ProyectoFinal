using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectController : MonoBehaviour
{
    private Transform myTransform;
    private Vector3 initialPosition;
    public GameObject canvas;

    private void Start()
    {
        myTransform = transform;
        initialPosition = ObjectPositionManager.instance.LoadObjectPosition(gameObject.name);
        myTransform.position = initialPosition;
    }

    // Llamado antes de cambiar de escena
    private void OnDestroy()
    {
        Debug.Log(myTransform.position);
        ObjectPositionManager.instance.SaveObjectPosition(gameObject.name, myTransform.position);
    }
    public void llamdaBoton()
    {
        myTransform = transform;
        Debug.Log("sas");
        initialPosition = ObjectPositionManager.instance.LoadObjectPosition(gameObject.name);
        myTransform.position = initialPosition;
        canvas.SetActive(false);
    }
}

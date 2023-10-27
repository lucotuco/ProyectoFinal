using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectController : MonoBehaviour
{ 
    public GameObject canvas;
    private Transform myTransform;
    private Vector3 initialPosition = new Vector3(-7.9f, 3.29f, -35.8f); 

    private void Start()
    {
        myTransform = transform;
        myTransform.position = initialPosition;
    }

    private void OnDestroy()
{
    if (ObjectPositionManager.instance != null)
    {
        ObjectPositionManager.instance.SaveObjectPosition(gameObject.name, myTransform.position);
    }
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

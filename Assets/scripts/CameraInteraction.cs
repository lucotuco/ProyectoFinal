using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInteraction : MonoBehaviour
{
    private new Transform camera;
    public float rayDistance;
    // Start is called before the first frame update
    void Start()
    {
        camera=transform.Find("Camera");
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.DrawLine(camera.position, camera.forward * rayDistance, Color.red);

        if(Input.GetButtonDown("Interactable"))
        {
            RaycastHit hit;
        if(Physics.Raycast(camera.position,camera.forward,out hit, rayDistance, LayerMask.GetMask("Interactable")))
        {
           // Debug.Log(hit.transform.name);
           hit.transform.GetComponent<Interactable>().Interact();
        } 
        }
        if(Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
        if(Physics.Raycast(camera.position,camera.forward,out hit, rayDistance, LayerMask.GetMask("Interactable")))
        {
           // Debug.Log(hit.transform.name);
           hit.transform.GetComponent<Interactable>().Interact();
        } 
        }
        
    }
}

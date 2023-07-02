using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInteraction : MonoBehaviour
{
    private new Transform camera;
    public float rayDistance;
    public GameObject machete;
    // Start is called before the first frame update
    void Start()
    {
        camera=transform.Find("Camera");
        gameObject.GetComponent<GameObject>();
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
            machete.GetComponent<Animator>().SetTrigger("MacheteAccion");
            
        if(Physics.Raycast(camera.position,camera.forward,out hit, rayDistance, LayerMask.GetMask("Interactable")))
        {
            StartCoroutine(FinAtaque(hit));
        } 
        }
        
        
    }
    IEnumerator FinAtaque(RaycastHit hit)
    {
        Debug.Log("Ataque");
        hit.transform.GetComponent<Interactable>().Interact();
        yield return new WaitForSeconds(0.2f);
        //Filo.GetComponent<BoxCollider>().isTrigger= false;
    }
}

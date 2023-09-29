using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraInteraction : MonoBehaviour
{
    public new Transform camera;
    public float rayDistance;
    public GameObject machete;
    public Scene scene;
    public string EscenaActual;
    public pickable pickeable; 
    public FPSplayer jugador;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
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
        
        if(EscenaActual=="Escena2")
        {
            
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
        
        
        
    }

   
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        //Debug.Log("Loaded scene: " + scene.name);
        if(scene.name=="Escena2")
        {
            Debug.Log("entreeeeeeeeeeeeee2");
            EscenaActual=scene.name;
            machete = GameObject.Find("MAchetePivot");
        }
        if(scene.name=="Escena1" && pickeable != null && pickeable.volvio==1)
        {
            jugador.transform.position=pickeable.posicionJugador;
            Debug.Log("zaza");
        }
        

    }

    IEnumerator FinAtaque(RaycastHit hit)
    {
        Debug.Log("Ataque");
        hit.transform.GetComponent<Interactable>().Interact();
        yield return new WaitForSeconds(0.45f);
        //Filo.GetComponent<BoxCollider>().isTrigger= false;
    }
}

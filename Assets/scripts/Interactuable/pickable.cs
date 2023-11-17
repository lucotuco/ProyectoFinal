using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pickable : Interactable
{   
    public Transform myTransform;
    public GameObject jugador;
    public GameObject jugadora;
    public GameObject texto;
    public Animator AnimacionCanvas;
    public string sceneName;
    public Vector3 posicionJugador;
    public int volvio;
    public GameObject textoCanvas;
    public override void Interact()
    {
        base.Interact();
        StartCoroutine(PrimeraAccion());
    }

    
    IEnumerator PrimeraAccion()
    {
        
        texto.SetActive(false);
        jugador.SetActive(false);
        jugadora.SetActive(true);
        volvio=1;
        Invoke("AnimacionCanvass",2f);
        yield return StartCoroutine(SegundaAccion()); // Esperar a que se complete la segunda acción   
    }

    void AnimacionCanvass()
    {
        AnimacionCanvas.SetBool("Activa", true);
        textoCanvas.SetActive(true);
    }

    IEnumerator SegundaAccion()
    {
        
        yield return new WaitForSeconds(4.21f);
        SceneManager.LoadScene(sceneName);
    }
}

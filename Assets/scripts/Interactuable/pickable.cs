using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pickable : Interactable
{
    public GameObject jugador;
    public GameObject jugadora;
    public GameObject texto;
    public string sceneName;
    public override void Interact()
    {
        base.Interact();
        StartCoroutine(PrimeraAccion());
    }
IEnumerator PrimeraAccion()
    {
        yield return new WaitForSeconds(0); // Esperar durante 2 segundos
        texto.SetActive(false);
        jugador.SetActive(false);
        jugadora.SetActive(true);
        yield return StartCoroutine(SegundaAccion()); // Esperar a que se complete la segunda acción

       
    }

    IEnumerator SegundaAccion()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(sceneName);
    }
}

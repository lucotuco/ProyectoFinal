using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pickable : Interactable
{
    public string sceneName;
    public override void Interact()
    {
        base.Interact();
        
        SceneManager.LoadScene(sceneName);
    }
}

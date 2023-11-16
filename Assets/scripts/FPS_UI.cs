using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FPS_UI : MonoBehaviour
{
    public static FPS_UI s;
    public Scene scene;
    public string EscenaActual;
    public Text ammoText;
    private FPS_ShootController _playerFPS;
    public Text mostrarenemigos;
    public int EnemigosMatados;
    public GameObject imagenInicio;
    

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
        
        

    }

    private void Awake()
    {
        StartCoroutine(arranca());
        mostrarenemigos.text="0/19";
        s = this;
        _playerFPS = FindObjectOfType<FPS_ShootController>();
       
    }

    IEnumerator arranca()
    {   
        
        imagenInicio.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        imagenInicio.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        if(scene.name=="Escena3")
        {
            FPS_FireWeapon fw = _playerFPS.GetCurrentWeapon().GetComponent<FPS_FireWeapon>();
        if (fw != null) {
            UpdateAmmoText(fw.GetCurrentBullets(), fw.GetCartridgeSize());
        }
        else UpdateAmmoText(0, 0);
        }
        if(scene.name=="Escena2")
        {
          
        }
         
      
    }

    public void actulizarKills()
    {
        EnemigosMatados++;

        mostrarenemigos.text=EnemigosMatados + "/ 19";
    }

    public void UpdateAmmoText(int currentBullets, int cartridgeSize) {
        string s = (cartridgeSize > 0) ? (currentBullets + " / " + cartridgeSize) : "";
        ammoText.text = s;
    }
}
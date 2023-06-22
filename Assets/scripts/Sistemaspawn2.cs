using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sistemaspawn2 : MonoBehaviour
{
    public GameObject siguienteSpawn;
    public GameObject Enemigo;
    public int CantEnemigosActual= 1;
    public Transform[] AreaSpawn;
    public FPSplayer EnemigosMatados;
    public int CantMatados=0;

    // Start is called before the first frame update
    void Start()
    {
        siguienteSpawn.SetActive(false);
        StartCoroutine(SpawnerEnemigos());
    }
    void Update()
    {
        if(CantMatados==3)
        {
            siguienteSpawn.SetActive(true);
        }
        
    }
    IEnumerator SpawnerEnemigos()
    {
        while(CantEnemigosActual<3 )
        {
            int randomNum = Random.Range(0, AreaSpawn.Length);
            Instantiate(Enemigo, AreaSpawn[randomNum].transform.position, AreaSpawn[randomNum].transform.rotation);
            yield return new WaitForSeconds(5f);
            CantEnemigosActual++;
        }
    }
    
}
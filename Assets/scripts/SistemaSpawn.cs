using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaSpawn : MonoBehaviour
{   
    public GameObject siguienteSpawn;
    public GameObject[] Enemigo;
    public int CantEnemigosActual= 1;
    public int EnemyType;
    public int ContadorOleadas;
    public int EnemigosXoleada;
    public bool Spawneando;
    public Transform[] AreaSpawn;
    public FPSplayer EnemigosMatados;
    public int CantMatados=0;
    public int sapwnpos;

    // Start is called before the first frame update
    void Start()
    {   
        ContadorOleadas=0;
        EnemigosXoleada=2;
        Spawneando=false;
        siguienteSpawn.SetActive(false);
        EnemyType=0;
    }
    void Update()
    {
        if(Spawneando == false && CantEnemigosActual ==0 && ContadorOleadas!= 5)
        {
            Debug.Log("Spawneando");
            StartCoroutine(SpawnerWave());
        }
        
        if(ContadorOleadas==5)
        {
            siguienteSpawn.SetActive(true);
        }
        
    }
    IEnumerator SpawnerWave()
    {
        Spawneando=true;
        yield return new WaitForSeconds(3);
        if(ContadorOleadas==3)
        {
            EnemigosXoleada=1;
        }
        for(int i=0; i<EnemigosXoleada; i++)
        {
            SapawnEnemy(ContadorOleadas);
        }
        ContadorOleadas+=1;
        EnemigosXoleada+=3;
        Spawneando=false;
        yield break;
    }
    
    void SapawnEnemy(int ContadorOleadas)
    {
        switch (ContadorOleadas)
        {
            case 1:
                EnemyType=0;
                 sapwnpos = Random.Range(0, AreaSpawn.Length);
                Instantiate(Enemigo[EnemyType], AreaSpawn[sapwnpos].transform.position, AreaSpawn[sapwnpos].transform.rotation);
                CantEnemigosActual++;
                break;
            case 3:
                EnemyType=1;
                 sapwnpos = Random.Range(0, AreaSpawn.Length);
                Instantiate(Enemigo[EnemyType], AreaSpawn[sapwnpos].transform.position, AreaSpawn[sapwnpos].transform.rotation);
                CantEnemigosActual++;
                break;

            case 4:
                siguienteSpawn.SetActive(true);
                break;
           default:
                EnemyType=0;
                 sapwnpos = Random.Range(0, AreaSpawn.Length);
                Instantiate(Enemigo[EnemyType], AreaSpawn[sapwnpos].transform.position, AreaSpawn[sapwnpos].transform.rotation);
                CantEnemigosActual++;
                break;
        }
        
    }
}

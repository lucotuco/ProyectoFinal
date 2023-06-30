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

    // Start is called before the first frame update
    void Start()
    {   
        ContadorOleadas=0;
        EnemigosXoleada=3;
        Spawneando=false;
        siguienteSpawn.SetActive(false);
        EnemyType=0;
    }
    void Update()
    {
        if(Spawneando== false && CantEnemigosActual==0)
        {
            Debug.Log("Spawneando");
            StartCoroutine(SpawnerWave(EnemigosXoleada));
        }
        
        if(CantMatados==3)
        {
            siguienteSpawn.SetActive(true);
        }
        
    }
    IEnumerator SpawnerWave(int EnemigosXoleada)
    {
        Spawneando=true;
        yield return new WaitForSeconds(3);
        for(int i=0; i<EnemigosXoleada; i++)
        {
            SapawnEnemy(ContadorOleadas);
        }
        ContadorOleadas+=1;
        EnemigosXoleada=EnemigosXoleada +3;
        Spawneando=false;
        yield break;
    }
    
    void SapawnEnemy(int ContadorOleadas)
    {
        int sapwnpos = Random.Range(0, AreaSpawn.Length);
        Instantiate(Enemigo[EnemyType], AreaSpawn[sapwnpos].transform.position, AreaSpawn[sapwnpos].transform.rotation);
        CantEnemigosActual++;
    }
}

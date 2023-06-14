using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    NavMeshAgent agente;

    public FPSplayer _jugador;
    public SistemaSpawn CantEnemigosMatados;
    public SistemaSpawn EnemigosActual;
    public int VidaActualEnemigo;
    public int VidaEnemigo = 100;
    public Slider barraVida;
    //private Animator _ac;
    
    void Awake()
    {
        agente = GetComponent<NavMeshAgent>();
        _jugador= FindObjectOfType<FPSplayer>();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        VidaActualEnemigo=VidaEnemigo;
        EnemigosActual = FindObjectOfType<SistemaSpawn>();
        CantEnemigosMatados=FindObjectOfType<SistemaSpawn>();
    }

    // Update is called once per frame
    void Update()
    {
        barraVida.value = VidaActualEnemigo;
        agente.SetDestination(_jugador.transform.position);
        if(VidaActualEnemigo==0)
        {
            Destroy(gameObject);
            EnemigosActual.CantEnemigosActual=EnemigosActual.CantEnemigosActual-1;
            CantEnemigosMatados.CantMatados=CantEnemigosMatados.CantMatados+1;
        }
    }




    
}
    /*public void Damage(int dmg) {
        if(health > 0) { 
            health -= dmg;

            if (health <= 0) {
                _ac.Play("Death");
            }
        }
    }
*/

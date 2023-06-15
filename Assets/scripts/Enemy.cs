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
    [SerializeField] public int VidaActualEnemigo;
    public int VidaEnemigo = 100;
    public Slider barraVida;
    public Animator AnimacionAtaque;
    public bool EstaAtacando    = false;
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
        RevisarAtaque();
        RevisarVidaJugador();
        barraVida.value = VidaActualEnemigo;
        
        if(VidaActualEnemigo==0)
        {
            Destroy(gameObject);
            EnemigosActual.CantEnemigosActual=EnemigosActual.CantEnemigosActual-1;
            CantEnemigosMatados.CantMatados=CantEnemigosMatados.CantMatados+1;
        }
        
    }


    void RevisarVidaJugador ()
    {
    
        agente.SetDestination(_jugador.transform.position);
    }


    void RevisarAtaque()
    {
        float distanciaJugador= Vector3.Distance(_jugador.transform.position, transform.position);
        if(distanciaJugador<=3f && EstaAtacando == false)
        {
            Debug.Log("eSYOY ATACADNO:)");
            Ataca();
        }
    }

    void Ataca()
    {
        EstaAtacando= true;
        Debug.Log(EstaAtacando);
        AnimacionAtaque.SetTrigger("Ataca");
        EstaAtacando= false;
        Debug.Log(EstaAtacando);
        AnimacionAtaque.SetTrigger("Ataca");
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

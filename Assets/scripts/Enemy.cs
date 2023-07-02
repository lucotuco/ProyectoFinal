using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] public int VidaActualEnemigo;
    NavMeshAgent agente;
    public Transform Jugador;
    public FPSplayer _jugador;
    public SistemaSpawn CantEnemigosMatados;
    public SistemaSpawn EnemigosActual;
    public int VidaEnemigo = 100;
    public Slider barraVida;
    public Animator AnimacionAtaque;
    public bool EstaAtacando;
    public FPSplayer vidaJugador;
    public int daño=40;
    
    void Awake()
    {
        agente = GetComponent<NavMeshAgent>();
        _jugador = FindObjectOfType<FPSplayer>();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        Jugador = GetComponent<Transform>();
        vidaJugador = FindObjectOfType<FPSplayer>();
        AnimacionAtaque = GetComponent<Animator>();
        VidaActualEnemigo=VidaEnemigo;
        EnemigosActual = FindObjectOfType<SistemaSpawn>();
        CantEnemigosMatados=FindObjectOfType<SistemaSpawn>();
        
    }

    // Update is called once per frame
    void Update()
    {   
        RevisarVidaJugador();
        RevisarAtaque();
        
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
        if(vidaJugador.VidaActualJug!=0)
        {
            Vector3 PosJugador= new Vector3(Jugador.position.x, transform.position.y, Jugador.position.z);
            transform.LookAt(PosJugador);
            agente.SetDestination(_jugador.transform.position);
        }
       
    }


    void RevisarAtaque()
    {
        if(EstaAtacando ==  true) 
        {
            return;
        }
        float distanciaJugador= Vector3.Distance(_jugador.transform.position, transform.position);
        if(distanciaJugador<=3 && EstaAtacando == false)
        {
            EstaAtacando= true;
            Ataca();
            //Debug.Log("esta atacando");
            
        }
        else
        {
            //Debug.Log("entro al else");
            AnimacionAtaque.SetBool("Ataca", false); 
            EstaAtacando = false;
        }
        //Debug.Log(EstaAtacando);
    }

    void Ataca()
    {
        AnimacionAtaque.SetBool("Ataca", true);
        vidaJugador.RecibirDaño(daño);
        
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

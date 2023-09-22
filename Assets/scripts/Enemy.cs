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
    [SerializeField] public bool EstaAtacando;
    public FPSplayer vidaJugador;
    public int daño;
    public float distanciaAtaque;
    public float distanciaJugador;
    public float AttackCooldown;
    float lastAtackTime;
    public bool caminando;
    
    void Awake()
    {
        agente = GetComponent<NavMeshAgent>();
        _jugador = FindObjectOfType<FPSplayer>();
        Jugador = GetComponent<Transform>();
        vidaJugador = FindObjectOfType<FPSplayer>();
        AnimacionAtaque = GetComponent<Animator>(); 
        EnemigosActual = FindObjectOfType<SistemaSpawn>();
        CantEnemigosMatados=FindObjectOfType<SistemaSpawn>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SeDespierta());
        AttackCooldown=1;      
        VidaActualEnemigo=VidaEnemigo;
    }

    // Update is called once per frame
    void Update()
    {   
        
        RevisarVidaJugador();
        RevisarAtaque();
        RevisarVidaEnemigo();
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "bala")
        {
            Debug.Log("entro");
        }        
    }

    IEnumerator SeDespierta()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("Corrutine"); 
        
        AnimacionAtaque.SetBool("caminando", true);
        caminando=true;
        //vidaJugador.RecibirDaño(daño,EstaAtacando);
        //Filo.GetComponent<BoxCollider>().isTrigger= false;
    }

    public void Damage(int dmg) {
        if(VidaActualEnemigo > 0) { 
            VidaActualEnemigo -= dmg;

            if (VidaActualEnemigo <= 0) {
                //_ac.Play("Death");
                Destroy(gameObject);
                /*EnemigosActual.CantEnemigosActual=EnemigosActual.CantEnemigosActual-1;
                CantEnemigosMatados.CantMatados=CantEnemigosMatados.CantMatados+1;*/
            }
        }
    }
    
    void RevisarVidaEnemigo()
    {
        barraVida.value = VidaActualEnemigo;
        if(VidaActualEnemigo<=0 && caminando)
        {
            FindObjectOfType<FPS_UI>().actulizarKills();
            Destroy(gameObject);
            EnemigosActual.CantEnemigosActual=EnemigosActual.CantEnemigosActual-1;
            CantEnemigosMatados.CantMatados=CantEnemigosMatados.CantMatados+1;
        }
    }

    void RevisarVidaJugador ()
    {
        if(vidaJugador.VidaActualJug>0 && caminando)
        {
            Vector3 PosJugador= new Vector3(Jugador.position.x, transform.position.y, Jugador.position.z);
            transform.LookAt(PosJugador);
            agente.SetDestination(_jugador.transform.position);
        }
       
    }


    void RevisarAtaque()
    {
        distanciaJugador= Vector3.Distance(_jugador.transform.position, transform.position);
        if(distanciaJugador<=distanciaAtaque )
        {
            
        if((Time.time - lastAtackTime) > AttackCooldown)
        {   
            Debug.Log("lol");   
            //StartCoroutine(Ataca());
            AnimacionAtaque.SetBool("Ataca", true);
            //vidaJugador.RecibirDaño(daño);
            lastAtackTime = Time.time;
            
        }
        
        }
        
        else
        {
            Debug.Log("suesi2"); 
            AnimacionAtaque.SetBool("Ataca", false); 
        }   
    }

    public void EventoAtaque()
    {
        if(distanciaJugador<=distanciaAtaque ){
            
        }
        vidaJugador.RecibirDaño(daño);
    }

    IEnumerator Ataca()
    {
        AnimacionAtaque.SetBool("Ataca", true);
        Debug.Log("Corrutine");
        yield return new WaitForSeconds(0.2f);
        //vidaJugador.RecibirDaño(daño,EstaAtacando);
        //Filo.GetComponent<BoxCollider>().isTrigger= false;
    }
 
}


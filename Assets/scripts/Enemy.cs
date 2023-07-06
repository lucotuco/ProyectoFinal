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
    
    void Awake()
    {
        agente = GetComponent<NavMeshAgent>();
        _jugador = FindObjectOfType<FPSplayer>();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        AttackCooldown=1;
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
        RevisarVidaEnemigo();
    }

    void RevisarVidaEnemigo()
    {
        barraVida.value = VidaActualEnemigo;
        if(VidaActualEnemigo<=0)
        {
            Destroy(gameObject);
            EnemigosActual.CantEnemigosActual=EnemigosActual.CantEnemigosActual-1;
            CantEnemigosMatados.CantMatados=CantEnemigosMatados.CantMatados+1;
        }
    }

    void RevisarVidaJugador ()
    {
        if(vidaJugador.VidaActualJug>0)
        {
            Vector3 PosJugador= new Vector3(Jugador.position.x, transform.position.y, Jugador.position.z);
            transform.LookAt(PosJugador);
            agente.SetDestination(_jugador.transform.position);
        }
       
    }


    void RevisarAtaque()
    {
        distanciaJugador= Vector3.Distance(_jugador.transform.position, transform.position);
        
        if(distanciaJugador<=distanciaAtaque)
        {
        if (Time.time - lastAtackTime < AttackCooldown) return;

            //StartCoroutine(Ataca());
            AnimacionAtaque.SetBool("Ataca", true);
            vidaJugador.RecibirDaño(daño);
            lastAtackTime = Time.time;
        }
        else
        {
            //Debug.Log("entro al else");
            //EstaAtacando = false;
            AnimacionAtaque.SetBool("Ataca", false); 
        }
        
        
        
        
    }
    IEnumerator Ataca()
    {
        AnimacionAtaque.SetBool("Ataca", true);
        Debug.Log("Corrutine");
        yield return new WaitForSeconds(0.2f);
        //vidaJugador.RecibirDaño(daño,EstaAtacando);
        //Filo.GetComponent<BoxCollider>().isTrigger= false;
    }
    void Atacas()
    {
        AnimacionAtaque.SetBool("Ataca", true);
        //vidaJugador.RecibirDaño(daño,EstaAtacando);
        
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

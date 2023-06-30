using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSplayer : MonoBehaviour
{
    private Rigidbody _rb;
    private CapsuleCollider col;
    public bool Shooting;
    #region Camera;
    public Camera _cam;
    private Vector3 camFwd;
    #endregion
    public SistemaSpawn EnemigosActual;
    public float velocidadJugador;
    public int VidaJugador = 100;
    public int VidaActualJug;
    public float velocidadCorrer=10f;
    public Slider BarraVida;

    #region Movement
    [Range(1.0f, 10.0f)]
    public float walk_speed;
    [Range(1.0f, 10.0f)]
    public float backwards_walk_speed;
    [Range(1.0f, 10.0f)]
    public float strafe_speed;

    [Range(2.0f, 10.0f)]
    public float jump_force;
    #endregion
    public PistolController pistol;


    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        EnemigosActual = FindObjectOfType<SistemaSpawn>();
        _rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
    }
    bool isGrounded= false;

    void Start()
    {
        VidaActualJug= VidaJugador;
        //Debug.Log(VidaJugador);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "PuedeSaltar")
        {
            isGrounded= true;
        }
        /*if(collision.gameObject.tag == "Enemigo")
        {
            Destroy(collision.transform.gameObject);
            EnemigosActual.CantEnemigosActual=EnemigosActual.CantEnemigosActual-1;
            CantMatados++;
            Debug.Log(EnemigosActual.CantEnemigosActual);
        }*/
        
    }
   
    public void RecibirDaño(int damage)
    {
        
        VidaActualJug= VidaActualJug-damage;
    }

    private void Update()
    {
        BarraVida.GetComponent<Slider>().value=VidaActualJug;
        chequearVida(VidaActualJug);

        bool jump = Input.GetButtonDown("Jump");
        
        if(Input.GetKey(KeyCode.LeftShift))
        {
            velocidadJugador= velocidadCorrer;
        }
        else
        {
            velocidadJugador= walk_speed;
        }

        // Jump 
        if (jump && isGrounded)
        {
            _rb.AddForce(Vector3.up * jump_force, ForceMode.Impulse);
        
            isGrounded= false;
        }
        // Disparo Arma SIN TERMINAR
        /*ItemsControl();
        Shooting = Input.GetKeyDown(KeyCode.Mouse0);*/
    }

    public bool chequearVida(int VidaActualJug)
    {   
        if(VidaActualJug<=0)
        {
            Debug.Log("muerto");
            return true;
        }
        else
        {
            Debug.Log("no muerto");
            return false;
        }
    }
    void FixedUpdate()
    {
        // Gets the input
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        // Calculate camera relative directions to move:
        camFwd = Vector3.Scale(_cam.transform.forward, new Vector3(1, 1, 1)).normalized;
        Vector3 camFlatFwd = Vector3.Scale(_cam.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 flatRight = new Vector3(_cam.transform.right.x, 0, _cam.transform.right.z);

        Vector3 m_CharForward = Vector3.Scale(camFlatFwd, new Vector3(1, 0, 1)).normalized;
        Vector3 m_CharRight = Vector3.Scale(flatRight, new Vector3(1, 0, 1)).normalized;


        // Draws a ray to show the direction the player is aiming at
        //Debug.DrawLine(transform.position, transform.position + camFwd * 5f, Color.red);

        float w_speed = (v > 0) ? velocidadJugador : backwards_walk_speed;
        Vector3 move = v * m_CharForward * w_speed + h * m_CharRight * strafe_speed;
        transform.position += move * Time.deltaTime;    // Move the actual player

        
    }

    public void ItemsControl()
    {
        if(pistol != null )
        {   
            if(Shooting)
            {
                pistol.Shoot(); 
            }
        }
    }
    
}

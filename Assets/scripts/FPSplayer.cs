using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public int VidaJugador = 1000;
    public int VidaActualJug;
    public float velocidadCorrer=10f;
    public Slider BarraVida;
    public Enemy Enemigo;
    [SerializeField] public int daño;
    public CameraInteraction LaEscenaActual;

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


    
    public float speedH;
    public float speedV;
    float ejeV, ejeH;

    public float rotmax;
    public float rotMin;

    //Para Controlar La al Player
    CharacterController cc;

    public float jump;
    public float gravity;
    public GameObject imagenMuerte;

    Vector3 mov = Vector3.zero;


    void Awake()
    {
        imagenMuerte.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        EnemigosActual = FindObjectOfType<SistemaSpawn>();
        _rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
        Enemigo = FindObjectOfType<Enemy>();
        LaEscenaActual = FindObjectOfType<CameraInteraction>();
    }
    bool isGrounded= false;

    void Start()
    {
         cc = GetComponent<CharacterController>();
        VidaActualJug= VidaJugador;
    }
    
    private void Update()
    {
        lol();
        if(LaEscenaActual.EscenaActual=="Escena2")
        {
            BarraVida.GetComponent<Slider>().value=VidaActualJug;
        }
        
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
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "PuedeSaltar")
        {
            isGrounded= true;
        }        
    }
   
    public void RecibirDaño(int damage)
    {
        VidaActualJug= VidaActualJug-damage;
    }

    public bool chequearVida(int VidaActualJug)
    {   
        if(VidaActualJug<=0)
        {
            //Debug.Log("muerto");
            imagenMuerte.SetActive(true);
            StartCoroutine(Respawnea());

            return true;
        }
        else
        {
            //Debug.Log("no muerto");
            return false;
        }
    }

    IEnumerator Respawnea()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("Respawnea");
        SceneManager.LoadScene("Escena2");
        //vidaJugador.RecibirDaño(daño,EstaAtacando);
        //Filo.GetComponent<BoxCollider>().isTrigger= false;
    }

    public void lol()
    {
        ejeH = speedH * Input.GetAxis("Mouse X");
        ejeV += speedV * Input.GetAxis("Mouse Y");

        _cam.transform.localEulerAngles = new Vector3(-ejeV, 0, 0);
        transform.Rotate(0, ejeH, 0);
        ejeV = Mathf.Clamp(ejeV, rotMin, rotmax);


        //Para Controlar el Movimiento
        if (cc.isGrounded)
        {
            mov = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

            mov = transform.TransformDirection(mov) * velocidadJugador;

            if (Input.GetKey(KeyCode.Space))
            {
                mov.y = jump;
            }
        }

        mov.y -= gravity * Time.deltaTime;
        cc.Move(mov * Time.deltaTime);
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

    

    public Vector3 GetForwardDirection() {
        return _cam.transform.forward;
    }
    
}

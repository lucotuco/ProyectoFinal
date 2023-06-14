using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento_Personaje : MonoBehaviour
{    /* [SerializeField] private float velocidadMovimiento;
   [SerializeField] private float velocidadRotacion;
   [SerializeField] private CharacterController characterController;
   [SerializeField] private Transform transformPersonaje;
   [SerializeField] private Camera camaraPersonaje;

    private Vector3 movimiento;
    private float rotacionX;*/
    Rigidbody Rb;
    Vector2 inputMov;
    public float velCamina = 10f;
    public float vel;
    

    void start()
    {
        Rb =GetComponent<Rigidbody>();
    }

    void Update()
    {

        inputMov.x=Input.GetAxis("Horizontal");
        inputMov.y=Input.GetAxis("Vertical");
        
        /*MovimientoDeCamara();
        MovimientoPersonaje();*/

    }
    
     void FixedUpdate()
    {
        vel = velCamina;
        Rb.velocity = transform.forward * vel * inputMov.y;

    }
/*
    void MovimientoPersonaje()
    {
        float movX= Input.GetAxis("Horizontal");
        float movZ= Input.GetAxis("Vertical");

        movimiento = transform.right * movX + transform.forward * movZ;
        characterController.SimpleMove(movimiento * velocidadMovimiento);
    }

    void MovimientoDeCamara()
    {
        float ratonX = Input.GetAxis("Mouse X") * velocidadRotacion;
        float ratonY = Input.GetAxis("Mouse Y") * velocidadRotacion; 

        rotacionX -= ratonY     ;
        rotacionX = Mathf.Clamp(rotacionX, -90f, 90f);

        camaraPersonaje.transform.rotation = Quaternion.Euler(rotacionX, 0, 0);
        transformPersonaje.Rotate(Vector3.up *ratonX);
    }*/
}

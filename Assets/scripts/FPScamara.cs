using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPScamara : MonoBehaviour
{
    
    
    public Transform PosJugador;
    public Transform posPP;
    //Camara TP
    public float rotSpeed;
    public float rotMin, rotMax;
    float mouseX, mouseY;
    public Transform target, player;
    
    
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Cam()
    {
        mouseX += rotSpeed * Input.GetAxis("Mouse X");
        mouseY -= rotSpeed * Input.GetAxis("Mouse Y");
        mouseY = Mathf.Clamp(mouseY, rotMin, rotMax);

        target.rotation = Quaternion.Euler(mouseY, mouseX, 0.0f);
        player.rotation = Quaternion.Euler(0.0f, mouseX, 0.0f);
    }

    void LateUpdate()
    {
        Cam();
        
    }   

}

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FPScamara : MonoBehaviour
{
    public Animator _anim;
    public Camera _cam;
    
    void Start()
    {
        _anim= GetComponent<Animator>();
    }
    [Range(0.1f, 2.0f)]
    public float sensitivity;
    public bool invertXAxis;
    public bool invertYAxis;
    public float rotMin;
    public float rotMax;

    void FixedUpdate()
    {
        //lee el mouse
        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");

        v = Mathf.Clamp(v,rotMin,rotMax);

        // Settings
        h = (invertXAxis) ? (-h) : h;
        v = (invertYAxis) ? (-v) : v;

        // Orbit the camera around the character
        if (h != 0)
        {   // Horizontal movement 
            transform.Rotate(Vector3.up, h * 90 * sensitivity * Time.deltaTime);
            
        }
        if (v != 0)
        {   // Vertical movement
            _cam.transform.RotateAround(transform.position, transform.right, v * 90 * sensitivity * Time.deltaTime);
        }


        // Fix Z-rotation issues
        Vector3 ea = _cam.transform.rotation.eulerAngles;
        _cam.transform.rotation = Quaternion.Euler(new Vector3(ea.x, ea.y, 0));
    }

    public Vector3 GetForwardDirection() {
        return _cam.transform.forward;
    }
}*/

using System.Collections;
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

    void FixedUpdate()
    {
        //lee el mouse
        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");

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
}

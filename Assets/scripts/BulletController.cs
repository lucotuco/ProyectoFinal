using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public float power = 50f;

    public float lifeTime = 3f;

    float deltatime= 0f;
    Rigidbody bulletRb;
    Collider collision;

    // Start is called before the first frame update
    void Start()
    {
        bulletRb = GetComponent<Rigidbody>();
        collision= GetComponent<Collider>();    
        bulletRb.velocity = this.transform.forward * power;
         
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemigo")
        {
            Destroy(collision.transform.gameObject);
            Debug.Log("sadsa");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        deltatime += Time.deltaTime;

        if(deltatime>= lifeTime)
        {
            Destroy(this.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    [SerializeField]
    public float power = 30f;

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

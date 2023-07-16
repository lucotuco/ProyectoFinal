using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float lifetime = 3.0f;
    private int damage;
    private float power = 50f;
    private Vector3 direction;
    


    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyBullet", lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += direction * power * Time.deltaTime;
    }

    public void SetDirection(Vector3 dir)
    {
        direction = dir.normalized;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemigo")
        {
            DestroyBullet();
            Enemy e = collision.transform.gameObject.GetComponent<Enemy>();
            e.Damage(damage);
            //Destroy(collision.transform.gameObject);
            Debug.Log("le pego:)");
        }
    }
    public void SetDamage(int dmg) {
        damage = dmg;
    }

    private void DestroyBullet() { Destroy(this.gameObject); }


    /*void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.gameObject.layer == 9) {
            Enemy e = collision.transform.gameObject.GetComponent<Enemy>();
            e.Damage(damage);
        }

        DestroyBullet();
    }*/
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_FireWeapon : FPS_Weapon
{
    [Tooltip("Time (in seconds) that player has to wait between reloading and shooting.")]
    [Range(0.2f, 3.0f)]
    public float reloadTime;

    [Tooltip("Bullet amount in one cartridge.")]
    public int cartridgeSize;
    private int currentBullets;

    public Transform shootSrc;
    
    public GameObject bulletPrefab;

    public AudioClip reloadSnd;


    protected new void Awake()
    {
        base.Awake();
        currentBullets = cartridgeSize;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(currentBullets);
        //FPS_UI.s.UpdateAmmoText(currentBullets, cartridgeSize);
    }

    public override void Fire()
    {
        if (canShoot)
        {   
           //Debug.Log(_player.GetForwardDirection());

            //Vector3 shootDir = shootSrc.position/*.forward*/;
            //Debug.Log(shootDir);
            Vector3 shootPos = shootSrc.position;
            // Create the bullet, sets the damage it will cause, and add some velocity to it
            GameObject go = Instantiate(bulletPrefab, shootPos, transform.rotation);
            Debug.Log(go);
            Rigidbody rb = go.GetComponent<Rigidbody>();
            go.GetComponent<Bullet>().SetDamage(damage);

            rb.velocity = (transform.forward * 10.0f);

            Debug.Log("Firing " + transform.name);

            // Plays weapon's shooting animation
            //_ac.Play("Shoot");

            currentBullets--;

            //_as.Stop();
            //_as.clip = shootSnd;
            //_as.Play();

            if (currentBullets > 0)
            {
                // Enables shooting again depending on cadence value
                canShoot = false;
                Invoke("EnableShoot", 1f / cadence);
            }
            else
            {
                Reload();
            }
        }
    }


    public override void Reload()
    {

        if (currentBullets < cartridgeSize)
        {
            Debug.Log("pucha");
            canShoot = false;
            Invoke("EnableShoot", reloadTime);

            currentBullets = cartridgeSize;

            //_as.Stop();
            //_as.clip = reloadSnd;
            //_as.Play();
        }
    }

    public int GetCartridgeSize() { return cartridgeSize; }
    public int GetCurrentBullets() { return currentBullets; }
}

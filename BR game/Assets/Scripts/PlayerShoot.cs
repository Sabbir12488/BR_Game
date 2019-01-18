using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

 

 

    public Transform firepoint;
    public GameObject bulletPrefab;
    
    public float firerate = 0.2f;
    private float fireCountdown = 0f;
   

    private void Start()
    {
        
    }

    void Update()
    {

        if (PauseMenuScript.GameIsPaused == true)
        {
            return;
        }

        if (AmmoCounter.reloading == true)
        {

            return;
        }
        else
        {
            


            if (AmmoCounter.NumberOfLoads < 0)
            {

                return;
            }
            else
            {

                if (AmmoCounter.NoAmmo == true)
                {
                    return; 
                }
                else
                {
                    if (Input.GetButtonDown("Fire1") && fireCountdown <= 0f)
                    {
                        
                        Shoot();
                        fireCountdown = 0.5f / firerate;

                    }

                    fireCountdown -= Time.deltaTime;






                }

            }
        }
    }

    void Shoot()
    {
        AmmoCounter.currentAmmo -= 1;
        Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
    }

}

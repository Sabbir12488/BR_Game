using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

 

<<<<<<< HEAD
 

    public Transform firepoint;
    public GameObject bulletPrefab;
    
    public float firerate = 0.2f;
    private float fireCountdown = 0f;
   
=======
 public int DamageAmount = 5;
    public float TargetDistance;
    public float AllowedRange = 15.0f; 
<<<<<<< HEAD
>>>>>>> parent of a70b962... Ammo almost working.
=======
>>>>>>> parent of a70b962... Ammo almost working.


  void Update()
    {
<<<<<<< HEAD
<<<<<<< HEAD

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

                // shooting goes here. We need a prefab version.
                if (Input.GetButtonDown("Fire1"))
                {
                    if (Input.GetButtonDown("Fire1") && fireCountdown <= 0f)
                    {
                        
                        Shoot();
                        fireCountdown = 0.5f / firerate;

                    }

                    fireCountdown -= Time.deltaTime;

<<<<<<< HEAD



=======
                    RaycastHit Shot;
                    if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot))
                    {
                        TargetDistance = Shot.distance;
                        if (TargetDistance < AllowedRange)
                        {
                            Shot.transform.SendMessage("DeductPoints", DamageAmount, SendMessageOptions.DontRequireReceiver);
                        }
                    }
>>>>>>> parent of d78cfbd... The ammo works




=======
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit Shot;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot))
            {
                TargetDistance = Shot.distance;
                if (TargetDistance < AllowedRange)
                {
                    Shot.transform.SendMessage("DeductPoints", DamageAmount, SendMessageOptions.DontRequireReceiver);
>>>>>>> parent of a70b962... Ammo almost working.
=======
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit Shot;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot))
            {
                TargetDistance = Shot.distance;
                if (TargetDistance < AllowedRange)
                {
                    Shot.transform.SendMessage("DeductPoints", DamageAmount, SendMessageOptions.DontRequireReceiver);
>>>>>>> parent of a70b962... Ammo almost working.
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

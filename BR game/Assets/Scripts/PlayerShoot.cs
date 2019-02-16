using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{


    public Transform firepoint;
    public GameObject bulletPrefab;

    public float firerate = 0.2f;
    private float fireCountdown = 0f;
    public int DamageAmount = 5;
    public float TargetDistance;
    public float AllowedRange = 15.0f;


    void Update()
    {

        if (AmmoCounter.reloading == true)
        {

            return;
        }
        else
        {

        }

        if (AmmoCounter.NumberOfLoads < 0)
        {

            return;
        }
        else
        {
        }
        // shooting goes here. We need a prefab version.
        /*
        if (Input.GetButtonDown("Fire1"))
        {
            if (Input.GetButtonDown("Fire1") && fireCountdown <= 0f)
            {


                fireCountdown = 0.5f / firerate;

            }


            fireCountdown -= Time.deltaTime;
        }*/ 
        if (Input.GetButtonDown("Fire1") && fireCountdown <= 0f)
        {
            
            RaycastHit Shot;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot))
            {
                TargetDistance = Shot.distance;
                if (TargetDistance < AllowedRange)
                {
                    Shot.transform.SendMessage("DeductPoints", DamageAmount, SendMessageOptions.DontRequireReceiver);


                }


            }

        }
    }
}

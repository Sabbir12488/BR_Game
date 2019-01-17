using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

 

 public int DamageAmount = 5;
    public float TargetDistance;
    public float AllowedRange = 15.0f;
    public GameObject bullets;
    public GameObject player; 

    private void Start()
    {
        
    }

    void Update()
    {
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
    }


}

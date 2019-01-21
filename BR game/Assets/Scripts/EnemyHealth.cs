using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public int Enemyhealth = 30;
    public int DamageTaken = 0; 

    private void Start()
    {
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        DamageTaken = BulletMoveScript.DamageToBadGuys; 
=======
        Debug.Log(Enemyhealth); 
=======
>>>>>>> parent of a70b962... Ammo almost working.
=======
>>>>>>> parent of a70b962... Ammo almost working.
        Enemyhealth -= DamageAmount;
>>>>>>> parent of d78cfbd... The ammo works
    }

    void Update()
    {
        if (Enemyhealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullets")
        {
            Enemyhealth -= DamageTaken; 
        }
    }
}

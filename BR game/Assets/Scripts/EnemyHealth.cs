using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public int Enemyhealth = 30;
    public int DamageTaken = 0;


    private void Start()
    {

        DamageTaken = BulletMoveScript.DamageToBadGuys;

        Debug.Log(Enemyhealth);

        Enemyhealth -= DamageTaken;
    }

    private void Update()
    {
        if(Enemyhealth <= 0)
        {
            Destroy(gameObject); 
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullets") { 

            Enemyhealth -= DamageTaken;
        }
    }

   
}

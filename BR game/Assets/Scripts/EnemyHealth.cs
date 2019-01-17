using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public int Enemyhealth = 30;

    void DeductPoints(int DamageAmount)
    {
        Debug.Log(Enemyhealth); 
        Enemyhealth -= DamageAmount;
    }

    void Update()
    {
        if (Enemyhealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}

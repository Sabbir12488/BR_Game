using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoveScript : MonoBehaviour {

    public int BulletMovementSpeed = 4;
    public static int DamageToBadGuys = 10;
    public Rigidbody rb; 

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 3f); 
	}
	
	// Update is called once per frame
	void Update () {
        rb.AddForce(0, 0, BulletMovementSpeed, ForceMode.Impulse); 

        

	}

    private void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.tag == "Enemies")
        {
            Destroy(gameObject); 
        } 
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Profile : MonoBehaviour {

    public float health = 100f;
    public float shield = 100f;
    public bool takenDamage = false;
    public Text deathscreen;
    public float addedDamaged; 

    [SerializeField]private Image healthImage;
    [SerializeField]private Image shieldImage;

    // Use this for initialization
    void Start () {
        deathscreen.enabled = false; 
	}
	
	// Update is called once per frame
	void Update () {
        healthImage.fillAmount = health / 100;
        shieldImage.fillAmount = shield / 100;
        addedDamaged = GetComponent<playerMovement>().moveSpeed; 

        // make it somehow how fast the player is it self and not the the speed it is meant to be going at. 


        
        if(health <= 0)
        {
            Die(); 
        }

	}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemies")
        {
            takenDamage = true;
            takenDamage = false;
            shield -= addedDamaged * 8/10;

        }
        if(collision.gameObject.tag == "Bullets")
        {
            takenDamage = true;
            takenDamage = false;
            shield -= addedDamaged * 7 / 10;

        }
        if (takenDamage = true && shield <= 0)
        {
            if(collision.gameObject.tag == "Enemies")
            {
                health -= addedDamaged * 8 / 10; ; 
            }
            if(collision.gameObject.tag == "Bullets")
            {
                health -= addedDamaged * 7 / 10; ;
            }

           
        }


    }

    void Die()
    {
        deathscreen.enabled = true; 
        Destroy(gameObject); 
    }
}

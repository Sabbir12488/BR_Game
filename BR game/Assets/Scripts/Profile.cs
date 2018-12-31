using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Profile : MonoBehaviour {

    public float health = 100f;
    public float shield = 100f;
    public bool takenDamage = false;
    public Text deathscreen; 

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
            shield -= 10;

            Debug.Log(shield); 
           
        }
        if(collision.gameObject.tag == "Bullets")
        {
            takenDamage = true;
            takenDamage = false;
            shield -= 5; 
     
        }
        if (takenDamage = true && shield <= 0)
        {
            if(collision.gameObject.tag == "Enemies")
            {
                health -= 40; 
            }
            if(collision.gameObject.tag == "Bullets")
            {
                health -= 10;
            }

           
        }


    }

    void Die()
    {
        deathscreen.enabled = true; 
        Destroy(gameObject); 
    }
}

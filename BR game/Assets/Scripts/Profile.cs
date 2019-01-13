using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Profile : MonoBehaviour {

// <<<<<<< HEAD
   
    //public bool takenDamage = false;
    //public Text deathscreen;
    //public float addedDamaged; 

    [Header("Health Variables")]

    public float health = 100;
    [SerializeField] private Image healthImage;
    [SerializeField] private Text healthText;
// >>>>>>> 1c0c7e783668a74a5ee408f682bce743961cd53f

    [Space]

    [Header("Shield Variables")]
    //-- <<>> --//
    public float shield = 100;
    [SerializeField] private Image shieldImage;

    [Space]

    [Header("Battey Variables")]
    //-- <<>> --//
    public float battery = 100f;
    public float batteryDrainRate = 10f;
    [SerializeField] private Image batteryImage;
    
    [Space]

    [Header("DeathScreenAndOthers")]
        public Text deathscreen;
    public bool takenDamage;
    public float addedDamaged; 

// <<<<<<< HEAD
    // Use this for initialization
    void Start () {
        deathscreen.enabled = false; 
	}
	
	// Update is called once per frame

	void Update () {

        // Health
        healthImage.fillAmount = health / 100;
        healthText.text = health.ToString("0");

        addedDamaged = GetComponent<PlayerController>().speed; 
    
             // make it somehow how fast the player is it self and not the the speed it is meant to be going at. 

        // Shield
        shieldImage.fillAmount = shield / 100;

        // Battery
        batteryImage.fillAmount = battery / 100;

        // Battery Draining
        if (battery > 0)
        {
            battery -= Time.deltaTime / batteryDrainRate * 3;
        }
        if(battery <= 0)
        {

            if(battery <= 0 && shield <= 0)
            {
                Die(); 
            }
            shield = 0;


            battery = 100; 
            
            
        }

        if (health <= 0)
        {
            Die(); 
        }

	}
    private void OnCollisionEnter(Collision collision) // fix a bug that is here
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
        //deathscreen.enabled = true; 
        //Destroy(gameObject); 

        if(health <= 0)
        {
            health = 0f;
        }
	}

    public void TakeDamage(float DamageAmount)
    {
        if (health <= 100 && health > 0)
            health -= DamageAmount;
        if (health <= 0)
            Debug.Log("Oh nooo, I am DEAD");

    }
}

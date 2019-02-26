using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Profile : MonoBehaviour {
 
    //public bool takenDamage = false;
    //public Text deathscreen;
    //public float addedDamaged; 

    [Header("Health Variables")]

    public float health = 100;
    [SerializeField] private Image healthImage;
    [SerializeField] private Text healthText;


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
    

    void Start () {
        //deathscreen.enabled = false; 
	}
	

	void Update () {

        // Health
        healthImage.fillAmount = health / 100;
        healthText.text = health.ToString("0");

        //addedDamaged = GetComponent<playerMovement>().moveSpeed; 

             // make it somehow how fast the player is it self and not the the speed it is meant to be going at. 

        // Shield
        shieldImage.fillAmount = shield / 100;

        // Battery
        batteryImage.fillAmount = battery / 100;

        // Battery Draining
        if (battery > 0)
        {
            battery -= Time.deltaTime / batteryDrainRate;
        }

        if (health <= 0)
        {
            Die(); 
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

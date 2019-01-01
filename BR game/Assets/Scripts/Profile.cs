using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Profile : MonoBehaviour {

    [Header("Health Variables")]
    //-- <<>> --//
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
    

	void Update () {

        // Health
        healthImage.fillAmount = health / 100;
        healthText.text = health.ToString("0");

        // Shield
        shieldImage.fillAmount = shield / 100;

        // Battery
        batteryImage.fillAmount = battery / 100;

        // Battery Draining
        if(battery > 0)
        {
            battery -= Time.deltaTime / batteryDrainRate;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Profile : MonoBehaviour {

    public float health = 100f;
    public float shileld = 100f;

    [SerializeField]private Image healthImage;
    [SerializeField]private Image shieldImage;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        healthImage.fillAmount = health / 100;
        shieldImage.fillAmount = shileld / 100;
	}
}

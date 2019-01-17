using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class AmmoCounter : MonoBehaviour {

    public float Maxammo = 5;
    public int Loads = 5; 
    public static float currentAmmo = 5;
    public static int NumberOfLoads = 10; 
    public Text displayAmmoCounter;
    public static bool reloading = false; 

    

	// Use this for initialization
	void Start () {
        Maxammo = currentAmmo;
        NumberOfLoads = Loads; 

        displayAmmoCounter.text = "";
        displayAmmoCounter.text = currentAmmo.ToString() + " <b>l " + NumberOfLoads.ToString() + " </b> ";
    }
	
	// Update is called once per frame
	void Update () {
        displayAmmoCounter.text = currentAmmo.ToString() + " <b>l " + NumberOfLoads.ToString() + " </b> ";

        if (currentAmmo == 0)
        {

            StartCoroutine(Reloading());
            currentAmmo = 0.000001f; 
            NumberOfLoads -= 1; 
       
        }
        if(currentAmmo <= 0)
        {
            currentAmmo = 0;
            displayAmmoCounter.text = currentAmmo.ToString() + " <b>l " + NumberOfLoads.ToString() + " </b> ";
        }
      
        
        if (Input.GetButtonDown("Fire1"))
        {
            currentAmmo -= 1;

        }
    }
    IEnumerator Reloading()
    {

        
        reloading = true; 
        yield return new WaitForSeconds(3);
        currentAmmo = Maxammo;
       
        reloading = false;

        yield break; 
        
    }
}

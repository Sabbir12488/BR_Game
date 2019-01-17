using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class AmmoCounter : MonoBehaviour {

    public float Maxammo = 5;
    public int Loads = 2; 
    public static float currentAmmo = 5;
    public static int NumberOfLoads = 10; 
    public Text displayAmmoCounter;
    public static bool reloading = false;
    public static bool NoAmmo = false; 


    

	// Use this for initialization
	void Start () {
        currentAmmo = Maxammo; 
        NumberOfLoads = Loads;
        Debug.Log(NumberOfLoads); 
        displayAmmoCounter.text = "";
        displayAmmoCounter.text = currentAmmo.ToString() + " <b>l " + NumberOfLoads.ToString() + " </b> ";
    }
	
	// Update is called once per frame
	void Update () {

      if(PauseMenuScript.GameIsPaused == true)
        {
            return; 
        }

        displayAmmoCounter.text = currentAmmo.ToString() + " <b>l " + NumberOfLoads.ToString() + " </b> ";



        if (currentAmmo == 0 && NumberOfLoads == 0)
        {
            NoAmmo = true; 
        }
        else
        {
            if (reloading == false)
            {

                if (Input.GetButtonDown("Fire1"))
                {
                    currentAmmo -= 1;

                }
            }
            else
            {
                return;
            }
            if (currentAmmo == 0)
            {

                StartCoroutine(Reloading());

            }
        }

        if(NumberOfLoads < 0)
        {
            NumberOfLoads = 0;
            displayAmmoCounter.text = currentAmmo.ToString() + " <b>l " + NumberOfLoads.ToString() + " </b> ";
        }

        
        if(currentAmmo <= 0)
        {
            currentAmmo = 0;
            displayAmmoCounter.text = currentAmmo.ToString() + " <b>l " + NumberOfLoads.ToString() + " </b> ";
        }

    }
    IEnumerator Reloading()
    {
        

        reloading = true;
    
        NumberOfLoads -= 1;

        if(NumberOfLoads > -1)
        {
            currentAmmo = Maxammo;

        }
        
        yield return new WaitForSeconds(3);

        
        reloading = false;

        yield break; 
        
    }
}

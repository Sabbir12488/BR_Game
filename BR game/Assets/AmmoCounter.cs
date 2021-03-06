﻿using System.Collections;
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
    public bool NoAmmo = false; 


    

	// Use this for initialization
	void Start () {
        currentAmmo = Maxammo; 
        NumberOfLoads = Loads; 

        displayAmmoCounter.text = "";
        displayAmmoCounter.text = currentAmmo.ToString() + " <b>l " + NumberOfLoads.ToString() + " </b> ";
    }

    // Update is called once per frame
    void Update() {

        if(NoAmmo == true)
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

            if (currentAmmo == 0)
            {

                StartCoroutine(Reloading());

                displayAmmoCounter.text = 0 + " <b>l " + 0 + " </b> ";

                displayAmmoCounter.text = 0 + " <b>l " + 0 + " </b> ";


            }

            if (currentAmmo == 0)
            {

                StartCoroutine(Reloading());

            }
            if (currentAmmo <= 0)
            {
                currentAmmo = 0;
                displayAmmoCounter.text = currentAmmo.ToString() + " <b>l " + NumberOfLoads.ToString() + " </b> ";
            }


            if (Input.GetButtonDown("Fire1"))
            {
                currentAmmo -= 1;

            }

        }
    }
        IEnumerator Reloading()
        {

            reloading = true;
            currentAmmo = Maxammo;
            NumberOfLoads -= 1;

            yield return new WaitForSeconds(3);


            reloading = false;

            yield break;

        }


   }   

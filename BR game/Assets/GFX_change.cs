using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GFX_change : MonoBehaviour {

    public bool tank = false;
    public Animator anim;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.E))
        {
            tank = true;
            anim.SetBool("tank", true);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            tank = false;
            anim.SetBool("tank", false);
        }

    }
    void GFXChange()
    {
        if (tank == false)
        {
            tank = true;
            anim.SetBool("tank", true);
        }
        if (tank == true)
        {
            tank = false;
            anim.SetBool("tank", false);
        }
    }
}




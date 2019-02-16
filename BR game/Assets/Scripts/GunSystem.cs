using UnityEngine;

public class GunSystem : MonoBehaviour {

    public float damage = 20f;
    public float range = 100f;
    public float fireRate = 15f;
    public float impactForce = 30f;
    public GameObject impactEffect;
    public Animator anim;
    public ParticleSystem muzzleFlash;

    private bool ads;

    public Camera fpsCam;

    private float nextTimeToFire = 0f;

	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            anim.SetBool("Fire", true);

            Shoot();
        }
        else
        {
            anim.SetBool("Fire", false);
        }
        if (Input.GetButton("Fire2"))
        {
            anim.SetBool("ADS", true);
            ads = true;
        }
        if (Input.GetButtonUp("Fire2"))
        {
            anim.SetBool("ADS", false);
            ads = false;
        }

        if (Input.GetButton("Fire2") && Input.GetButton("Fire1"))
        {
            anim.SetBool("ADS Fire", true);
        }
        else
        {
            anim.SetBool("ADS Fire", false);
        }


    }

    void Shoot()
    {
        muzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            //Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();

            if (target != null)
            {
                target.TakeDamage(damage);
            }

            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 1f);
        }
    }
}

using UnityEngine;

public class GunSystem : MonoBehaviour {

    #region Variables

    [Header("Main Options")]
    public float damage = 20f;
    public float bulletSpeed;
    public float fireRate = 15f;
    public float bulletDestroyTime = 4f;

    [Header("Gun Type")]
    public bool semiAutoFire;
    public bool autoFire;

    [Header("Things")]
    public GameObject impactEffect;
    public ParticleSystem muzzleFlash;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public destroy_bullet destroyBullet;
    


    // privet veriables
    private float nextTimeToFire = 0f;

    #endregion

    #region Main Things

    void Update () {

        destroy_bullet.destroyTime = bulletDestroyTime;

        if (semiAutoFire == true)
            autoFire = false;
        if (autoFire == true)
            semiAutoFire = false;

        if(semiAutoFire == true && autoFire == true || semiAutoFire == false && autoFire == false)
            return;

        // Auto Fire
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && autoFire == true)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }

        // Semi auto fire
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire && semiAutoFire == true)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    #endregion

    #region shooting

    void Shoot()
    {
        muzzleFlash.Play();

        GameObject bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed * Time.deltaTime;

        /*RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            //Debug.Log(hit.transform.name);

            Profile target = hit.transform.GetComponent<Profile>();

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
        }*/
    }
    #endregion
}

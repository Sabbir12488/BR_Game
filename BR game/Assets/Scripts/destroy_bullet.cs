using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_bullet : MonoBehaviour {

    public static float destroyTime;

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject)
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        Destroy(gameObject, destroyTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorForFlyingForMK : MonoBehaviour {

    private Vector3 velocity = Vector3.zero;
    private Rigidbody rb;
    private Vector3 rotation = Vector3.zero; 

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }
    // gets a movement vector

    public void Move(Vector3 _velocity)
    {
        velocity = _velocity; 
    }
    public void Rotate(Vector3 _rotation)
    {
        rotation = _rotation; 
    }

    void FixedUpdate()
    {
        PreformMovement();
        PreformRotation(); 
        
    }


    void PreformMovement()
    {
        if( velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.deltaTime); 
        }
    }

    void PreformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation)); 
    } 
}

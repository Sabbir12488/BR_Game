using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    public float speed = 5f;
    [SerializeField]
    private float lookSensitivity = 3;
    public float currentSpeed = 2; 
    

    private PlayerMotor motor;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        motor = GetComponent<PlayerMotor>();
    }
    void Update()
    {
      
        
        float _xMov = Input.GetAxisRaw("Horizontal");
        float _zMov = Input.GetAxisRaw("Vertical");

        Vector3 _moveHorizontal = transform.right * _xMov;
        Vector3 _moveVertical = transform.forward * _zMov;

        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * speed;

        motor.Move(_velocity);
        // moving
        float _YRot = Input.GetAxisRaw("Mouse X");

        // turning
        Vector3 _rotation = new Vector3(0f, _YRot, 0f) * lookSensitivity;

        motor.Rotate(_rotation);
    

    float _XRot = Input.GetAxisRaw("Mouse Y");

        // turning
        Vector3 _cameraRotation = new Vector3(_XRot, 0,0) * lookSensitivity;

        motor.RotateCamera(_cameraRotation); 
    }

}
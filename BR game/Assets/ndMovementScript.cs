using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ndMovementScript : MonoBehaviour {

    [Header("VariablesToChange")]
    [SerializeField]
    private float speed = 5f;
    [Space]
    [SerializeField]
    private float lookSensitivity = 3f; 
    private MotorForFlyingForMK motor; 

	// Use this for initialization
	void Start () {
        motor = GetComponent<MotorForFlyingForMK>(); 
	}
	
	// Update is called once per frame
	void Update () {

        float _xMov = Input.GetAxisRaw("Horizontal");
        float _zMov = Input.GetAxisRaw("Vertical");

        Vector3 _moveHorizontal = transform.right * _xMov;
        Vector3 _moveVertical = transform.forward * _zMov;

        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * speed;

        motor.Move(_velocity);

        // rotations
        // only for turning
        float _yRot = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0f, _yRot, 0f) * lookSensitivity;

        motor.Rotate(_rotation); 

    }
}

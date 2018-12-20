using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

    [SerializeField] private string horizonlatInputName, verticalInputName;

    public float moveSpeed;
    public float slopeForce;
    public float slopeForceRayLength;

    private CharacterController controller;

    public AnimationCurve jumpFallOff;
    public float jumpMultiplier;
    public KeyCode jumpKey;

    private bool isJumping;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        // moving forward and backward moving right and left
        float verInput = Input.GetAxis(verticalInputName);
        float horizInput = Input.GetAxis(horizonlatInputName);

        Vector3 forwardMove = transform.forward * verInput;  
        //Vector3 rightMove = transform.right * horizInput;   

        controller.SimpleMove(Vector3.ClampMagnitude(forwardMove /*+ rightMove*/, 1f) * moveSpeed);

        if((verInput != 0 || horizInput  != 0) && OnSlope())
        {
            controller.Move(Vector3.down * controller.height / 2 * slopeForce * Time.deltaTime);
        }

        // Jumping
        JumpInput();

    }

    bool OnSlope()
    {
        if (isJumping)
            return false;

        RaycastHit hit;

        if(Physics.Raycast(transform.position, Vector3.down, out hit, controller.height / 2 * slopeForceRayLength))       
            if(hit.normal != Vector3.up)          
                return true;
     
        return false;
    }

    void JumpInput()
    {
        if (Input.GetKeyDown(jumpKey) && !isJumping)
        {
            isJumping = true;
            StartCoroutine(JumpEvent());
        }
    }

    IEnumerator JumpEvent()
    {
        controller.slopeLimit = 90f;
        float timeInAir = 0f;
        do
        {
            float jumpForce = jumpFallOff.Evaluate(timeInAir);
            controller.Move(Vector3.up * jumpForce * jumpMultiplier * Time.deltaTime);
            timeInAir += Time.deltaTime;
                
            yield return null;
        } while (!controller.isGrounded && controller.collisionFlags != CollisionFlags.Above);

        controller.slopeLimit = 45f;
        isJumping = false;
    }
}

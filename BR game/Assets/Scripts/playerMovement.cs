using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

    [SerializeField] private string horizonlatInputName, verticalInputName;

    public float moveSpeed;
    //public float runSpeed;
    public float slopeForce;
    public float slopeForceRayLength;

    private CharacterController controller;

    public AnimationCurve jumpFallOff;
    public float jumpMultiplier;
    public KeyCode jumpKey;
    //public KeyCode runKey;
    private bool isJumping;
    public Transform groundChack;

    bool isGrounded;

    [Space]
    public float maxFallForce;
    public float baseFallDamage;
    public float fallForce;

    private Profile profile;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        profile = GetComponent<Profile>();
    }

    private void Update()
    {
        /*if (Input.GetKey(runKey))
        {
            moveSpeed = runSpeed;
        }else if (Input.GetKeyUp(runKey))
        {
            moveSpeed = 6f;
        }*/

        PlayerMovement();

        if(!isGrounded)
        {
            float vY = Mathf.Abs(controller.velocity.y);
            fallForce = vY;
        }

        if (isGrounded)
        {
            if(fallForce > maxFallForce)
            {
                float damage = Mathf.RoundToInt(fallForce * baseFallDamage);
                fallForce = 0;
                Debug.Log("took " + damage.ToString() + " of damage");
                profile.TakeDamage(damage);
            }
        }

        isGrounded = Physics.CheckSphere(groundChack.transform.position, 0.1f);
    }

    void PlayerMovement()
    {
        
        // moving forward and backward moving right and left
        float verInput = Input.GetAxis(verticalInputName);
        float horizInput = Input.GetAxis(horizonlatInputName);

        // battery drains fastet when the player moves
        if(verInput < 0 || verInput > 0)
        {
            profile.batteryDrainRate = 3.5f;
        }
        else
        {
            profile.batteryDrainRate = 10f;
        }

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
        if (Input.GetKeyDown(jumpKey) && !isJumping && isGrounded)
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

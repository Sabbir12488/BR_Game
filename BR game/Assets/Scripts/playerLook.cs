using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class playerLook : MonoBehaviour {

    [SerializeField] private string mouseXInputName, mouseYInputName;
    [SerializeField] private float mouseSensitivity;

    [SerializeField] private Transform playerBody;

    public Camera cam;

    private Interactable focus;

    private float xAxisClamp;

    private void Awake()
    {
        LockCursor();
        xAxisClamp = 0f;
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {       

        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        CameraRotation();

        /// for test start
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(Time.timeScale == 0f)
            {
                Time.timeScale = 1f;
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                Time.timeScale = 0f;
                //Cursor.lockState = CursorLockMode.None;
            }
        }
        /// for test ends

        if (Input.GetKeyDown(KeyCode.E))
        {
            // creats a ray
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 100))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if(interactable != null)
                {
                    SetFocus(interactable);
                }
            }
        }
    }

    void SetFocus(Interactable newFocus)
    {
        if(newFocus != focus)
        {
            if(focus != null)
            {
                focus.OnDefocused();
            }           
            focus = newFocus;
        }
       
        newFocus.OnFocused(transform);
    }

    void CameraRotation()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;


        float mouseX = Input.GetAxis(mouseXInputName) * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis(mouseYInputName) * mouseSensitivity * Time.deltaTime;

        xAxisClamp += mouseY;

        if(xAxisClamp > 90f)
        {
            xAxisClamp = 90f;
            mouseY = 0f;
            ClampXAxisRotationToValue(270f);
        }else if(xAxisClamp < -90)
        {
            xAxisClamp = -90f;
            mouseY = 0f;
            ClampXAxisRotationToValue(90f);
        }

        transform.Rotate(Vector3.left * mouseY);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    void ClampXAxisRotationToValue(float _value)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = _value;
        transform.eulerAngles = eulerRotation;
    }
}

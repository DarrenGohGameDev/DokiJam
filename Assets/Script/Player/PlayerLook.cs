using System;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float sensitivity = 10f;
    public Transform playerCamera;

    Vector2 rotation = Vector2.zero;

    private bool mouseLooking = true;

    public static Action<bool> enablePlayerMouseLook;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(mouseLooking)
        {
            rotation.y += Input.GetAxis("Mouse X") * sensitivity;
            rotation.x += -Input.GetAxis("Mouse Y") * sensitivity;
            rotation.x = Mathf.Clamp(rotation.x, -90f, 90f);
            playerCamera.transform.rotation = Quaternion.Euler(rotation.x, rotation.y, 0f);
        }
    }

    private void OnEnable()
    {
        enablePlayerMouseLook += SetPlayerMouseLook;
    }

    private void OnDisable()
    {
        enablePlayerMouseLook -= SetPlayerMouseLook;
    }

    private void SetPlayerMouseLook(bool set)
    {
        mouseLooking = set;
    }
}

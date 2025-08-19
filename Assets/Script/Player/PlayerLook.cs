using System;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float sensitivity = 10f;
    public Transform playerCamera;

    Vector2 rotation = Vector2.zero;

    private bool mouseLooking = true;

    public static Action<bool> enablePlayerMouseLook;

    private bool playerInventoryIsOpen = false;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TogglePlayerCursorVisible();
        }
    }

    private void OnEnable()
    {
        enablePlayerMouseLook += SetPlayerMouseLook;
        PlayerManager.instance.playerInventoryIsOpen += PlayerIsLookingAtInventory;
    }

    private void OnDisable()
    {
        enablePlayerMouseLook -= SetPlayerMouseLook;
        PlayerManager.instance.playerInventoryIsOpen -= PlayerIsLookingAtInventory;
    }

    public void SetPlayerMouseLook(bool set)
    {
        mouseLooking = set;
        Cursor.visible = !set;
    }

    private void PlayerIsLookingAtInventory(bool value)
    {
        playerInventoryIsOpen = value;
    }

    private void TogglePlayerCursorVisible()
    {
        Cursor.visible = Cursor.visible ? false:true;
    }
}

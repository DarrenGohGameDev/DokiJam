using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupUiManager : MonoBehaviour
{
    [SerializeField] private Popup popupObj;

    public static Action<bool,string> togglePopup;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            togglePopup?.Invoke(true,"test text");
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            togglePopup?.Invoke(false, "");
        }
    }

    private void OnEnable()
    {
        togglePopup += popupObj.TogglePopup;
    }

    private void OnDisable()
    {
        togglePopup -= popupObj.TogglePopup;
    }
}

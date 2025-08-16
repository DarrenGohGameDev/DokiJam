using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PopupUiManager : MonoBehaviour
{
    [SerializeField] private Popup popupObj;

    [SerializeField] private Button closePopupButton;

    public static Action<bool,string> togglePopup;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        togglePopup += popupObj.TogglePopup;
        closePopupButton.onClick.AddListener(ClosePopup);
    }

    private void OnDisable()
    {
        togglePopup -= popupObj.TogglePopup;
        closePopupButton.onClick.RemoveListener(ClosePopup);
    }

    private void ClosePopup()
    {
        popupObj.TogglePopup(false, "");
        if(GameManager.instance.gameState == GameManager.GameState.EndGame)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

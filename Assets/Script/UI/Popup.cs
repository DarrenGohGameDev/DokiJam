using UnityEngine;
using TMPro;

public class Popup : MonoBehaviour
{
    [SerializeField] private CanvasGroup popupCanvasGroup;

    [SerializeField] private TextMeshProUGUI popupText;

    [SerializeField] float fadeAnimationSpeed = 1;

    private PopupState currentPopupState = PopupState.Hide;

    private enum PopupState
    {
        Hide = 0,
        Show = 1,
    }

    private void Awake()
    {
        ResetPopup();
    }

    void Update()
    {
        if(popupCanvasGroup.alpha != (int)currentPopupState)
        {
            PopupFadeAnimation();
        }
    }

    public void TogglePopup(bool toggle, string text)
    {
        currentPopupState = toggle ? PopupState.Show : PopupState.Hide;

        PlayerLook.enablePlayerMouseLook?.Invoke(!toggle);

        popupCanvasGroup.blocksRaycasts = toggle;
        popupCanvasGroup.interactable = toggle;

        PlayerLook.enablePlayerMouseLook?.Invoke(!toggle);


        SoundManager.instance.PlayPopupSfx();
        if (text == "")
            return;
        ChangePopupText(text);
    }

    private void ChangePopupText(string text)
    {
        popupText.text = text;
    }

    private void ResetPopup()
    {
        popupCanvasGroup.alpha = 0;
        currentPopupState = PopupState.Hide;
        ChangePopupText("");
    }

    private void PopupFadeAnimation()
    {
        popupCanvasGroup.alpha = Mathf.MoveTowards(popupCanvasGroup.alpha, (int)currentPopupState, Time.deltaTime * fadeAnimationSpeed);
        popupText.alpha = Mathf.MoveTowards(popupText.alpha, (int)currentPopupState, Time.deltaTime * fadeAnimationSpeed);
    }
}

using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private CanvasGroup tutorialCanvasGroup;

    [SerializeField] float fadeAnimationSpeed = 1;

    private TutorialState currentTutorialState = TutorialState.Hide;

    [SerializeField] private Button howToPlayButton;

    private enum TutorialState
    {
        Hide = 0,
        Show = 1,
    }

    private void Awake()
    {
        ResetTutorialUi();
    }
    private void OnEnable()
    {
        howToPlayButton.onClick.AddListener(ToggleHowToPlayTab);
    }

    private void OnDisable()
    {
        howToPlayButton.onClick.RemoveListener(ToggleHowToPlayTab);
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.W))
        {
            ToggleTutorial();
        }

        if (tutorialCanvasGroup.alpha != (int)currentTutorialState)
        {
            TutorialFadeAnimation();
           
        }
    }

    private void ToggleHowToPlayTab()
    {
        PopupUiManager.togglePopup?.Invoke(true,
            $"\n Q - Open potion tab " +
            $"\n W - Open Potion Guide " +
            $"\n E - Open Ingredient tab " +
            $"\n Space - Show / Hide your cursor" +
            $"\n mix and match ingredient in the MAGICAL WASHING MACHINE to make a potion " +
            $"\n Once you have a potion drag it from the tab and give it to Dragoon to complete an order !");
    }

    public void ToggleTutorial()
    {
        currentTutorialState = currentTutorialState == TutorialState.Hide ? TutorialState.Show : TutorialState.Hide;
    }

    private void ResetTutorialUi()
    {
        tutorialCanvasGroup.alpha = 0;
        currentTutorialState = TutorialState.Hide;
        tutorialCanvasGroup.blocksRaycasts = false;
    }

    private void TutorialFadeAnimation()
    {
        tutorialCanvasGroup.alpha = Mathf.MoveTowards(tutorialCanvasGroup.alpha, (int)currentTutorialState, Time.deltaTime * fadeAnimationSpeed);
        tutorialCanvasGroup.blocksRaycasts = tutorialCanvasGroup.alpha != (int)currentTutorialState ? true : false;
    }
}

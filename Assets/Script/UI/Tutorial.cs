using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private CanvasGroup tutorialCanvasGroup;

    [SerializeField] float fadeAnimationSpeed = 1;

    private TutorialState currentTutorialState = TutorialState.Hide;

    private enum TutorialState
    {
        Hide = 0,
        Show = 1,
    }

    private void Awake()
    {
        ResetTutorialUi();
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

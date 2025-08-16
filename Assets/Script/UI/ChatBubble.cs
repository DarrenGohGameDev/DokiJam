using Unity.VisualScripting;
using UnityEngine;

public class ChatBubble : MonoBehaviour
{
    [SerializeField] private CanvasGroup chatBubbleCanvasGroup;

    [SerializeField] private Vector3 chatBubbleMaxSize;

    [SerializeField] private float scaleAnimationSpeed = 10f;

    private ChatBubbleState currentChatBubbleState = ChatBubbleState.Hide;

    private enum ChatBubbleState
    {
        Hide = 0,
        Show = 1,
    }

    private void Awake()
    {
        ResetChatBubble();
    }

    private void Update()
    {
        ToggleChatBubbleAnimation();
    }

    public void ToggleChatBubble(bool toggle)
    {
        currentChatBubbleState = toggle ? ChatBubbleState.Show : ChatBubbleState.Hide;
    }

    private void ToggleChatBubbleAnimation()
    {
        chatBubbleCanvasGroup.gameObject.transform.localScale = currentChatBubbleState == ChatBubbleState.Show ? 
            Vector3.MoveTowards(chatBubbleCanvasGroup.gameObject.transform.localScale, chatBubbleMaxSize, Time.deltaTime * scaleAnimationSpeed):
            Vector3.MoveTowards(chatBubbleCanvasGroup.gameObject.transform.localScale, Vector3.zero, Time.deltaTime * scaleAnimationSpeed);
    }

    private void ResetChatBubble()
    {
        chatBubbleCanvasGroup.gameObject.transform.localScale = Vector3.zero;
    }
}

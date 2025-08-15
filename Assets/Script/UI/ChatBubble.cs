using UnityEngine;

public class ChatBubble : MonoBehaviour
{
    [SerializeField] private SpriteRenderer chatBubbleSpriteRenderer;

    public void ToggleChatBubble(bool toggle)
    {
        chatBubbleSpriteRenderer.color = toggle ? Color.white : Color.clear;
    }
}

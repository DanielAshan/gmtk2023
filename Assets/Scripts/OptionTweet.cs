using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionTweet : MonoBehaviour
{
    [SerializeField] private RawImage profilePicture;
    [SerializeField] private TextMeshProUGUI userName;
    [SerializeField] private TextMeshProUGUI userHandle;
    [SerializeField] private TextMeshProUGUI tweetText;

    private bool isEmpty = true;
    private Button button;
    private void Awake() {
        userName.text = "";
        userHandle.text = "";
        tweetText.text = "SELECT TWEET";
        this.button = GetComponent<Button>();
    }

    public void SetTweetData(Texture pfp, string name, string handle, string text)
    {
        profilePicture.texture = pfp;
        userName.text = name;
        userHandle.text = handle;
        tweetText.text = text;
        isEmpty = false;
    }

    public void DisableTweet()
    {
        button.interactable = false;
    }

    public void EnableTweet()
    {
        button.interactable = true;
    }

    public bool IsEmpty()
    {
        return isEmpty;
    }
}

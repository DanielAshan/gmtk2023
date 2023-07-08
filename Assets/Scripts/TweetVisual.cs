using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class TweetVisual : MonoBehaviour
{
    [SerializeField] private RawImage profilePicture;
    [SerializeField] private TextMeshProUGUI userName;
    [SerializeField] private TextMeshProUGUI userHandle;
    [SerializeField] private TextMeshProUGUI tweetText;

    private Tweet tweet;
    private Button button;
    private void Awake() {
        tweet = new Tweet();
        UpdateTweetVisual();
        this.button = GetComponent<Button>();
        button.interactable = tweet.GetShouldBeInteractable();
        button.onClick.AddListener(HandleButtonOnClick);
    }

    public void SetTweetData(Texture pfp, string name, string handle, string text) => tweet.SetTweetData(pfp, name, handle, text);
    public bool IsEmpty() => tweet.IsEmpty();
    public bool GetShouldBeInteractable() => tweet.GetShouldBeInteractable();

    public void DisableTweet()
    {
        button.interactable = false;
    }

    public void EnableTweet()
    {
        button.interactable = true;
    }

    public void SetTweet(Tweet tweet)
    {
        this.tweet = tweet;
        UpdateTweetVisual();
    }    

    public bool IsInteractable()
    {
        return button.interactable;
    }

    public void HandleButtonOnClick()
    {
        if (tweet.IsEmpty())
        {
            return;
        }

        if (tweet.GetSelected())
        {
            SelectableTweetsManager.Instance.AddTweetToSelectable(tweet);
        }
        else
        {
            TimelineManager.Instance.AddTweetToSlot(tweet);
        }
        
    }

    private void UpdateTweetVisual()
    {
        if (tweet.GetUserPFP() != null)
        {
            profilePicture.texture = tweet.GetUserPFP();
        }
        userName.text = tweet.GetUserName();
        userHandle.text = tweet.GetUserHandle();
        tweetText.text = tweet.GetTweetText();
    }
}

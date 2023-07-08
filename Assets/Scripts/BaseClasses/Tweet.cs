using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tweet 
{
    private Texture profilePicture;
    private string userName;
    private string userHandle;
    private string tweetText;
    private bool isEmpty = true;
    private bool shouldBeInteractable = true;


    public Tweet(Texture profilePicture, string username, string userHandle, string tweetText)
    {
        this.profilePicture = profilePicture;
        this.userName = username;
        this.userHandle = "@" + userHandle;
        this.tweetText = tweetText;
        this.isEmpty = false;
    }

    public Tweet(string username, string userHandle, string tweetText)
    {
        this.profilePicture = null;
        this.userName = username;
        this.userHandle = "@" + userHandle;
        this.tweetText = tweetText;
        this.isEmpty = false;
    }

    public Tweet()
    {
        this.userName = "";
        this.userHandle = "";
        this.tweetText = "SELECT TWEET";
    } 

    public void SetTweetData(Texture profilePicture, string username, string userHandle, string tweetText)
    {
        this.profilePicture = profilePicture;
        this.userName = username;
        this.userHandle = "@" + userHandle;
        this.tweetText = tweetText;
        this.isEmpty = false;
    }

    public bool IsEmpty()
    {
        return isEmpty;
    }

    public void SetShouldBeInteractable(bool should)
    {
        shouldBeInteractable = should;
    }

    public bool GetShouldBeInteractable()
    {
        return shouldBeInteractable;
    }
    public Texture GetUserPFP()
    {
        return profilePicture;
    }

    public string GetUserName()
    {
        return userName;
    }

    public string GetUserHandle()
    {
        return userHandle;
    }
    public string GetTweetText()
    {
        return tweetText;
    }
}

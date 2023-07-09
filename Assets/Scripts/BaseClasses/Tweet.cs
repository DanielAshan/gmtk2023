using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tweet 
{
    private string pfpResourcePath;
    private string userName;
    private string userHandle;
    private string tweetText;
    private string[] traits;
    private bool isEmpty = true;
    private bool shouldBeInteractable = true;
    private bool isSelected = false;
    private int selectedIndex = -1;
    private int agendaScore;

    public Tweet(string pfpPath, string username, string userHandle, string tweetText, string[] traits, int agendaScore)
    {
        this.pfpResourcePath = pfpPath;
        this.traits = traits;
        this.userName = username;
        this.userHandle = "@" + userHandle;
        this.tweetText = tweetText;
        this.agendaScore = agendaScore;
        this.isEmpty = false;
    }

    public Tweet(string pfpPath, string username, string userHandle, string tweetText, int agendaScore)
    {
        this.pfpResourcePath = pfpPath;
        this.userName = username;
        this.userHandle = "@" + userHandle;
        this.tweetText = tweetText;
        this.agendaScore = agendaScore;
        this.isEmpty = false;
    }

    public Tweet(string pfpPath, string username, string userHandle, string tweetText)
    {
        this.pfpResourcePath = pfpPath;
        this.userName = username;
        this.userHandle = "@" + userHandle;
        this.tweetText = tweetText;
        this.isEmpty = false;
    }


    public Tweet(string username, string userHandle, string tweetText, int agendaScore)
    {
        this.pfpResourcePath = "";
        this.userName = username;
        this.userHandle = "@" + userHandle;
        this.tweetText = tweetText;
        this.agendaScore = agendaScore;
        this.isEmpty = false;
    }

    public Tweet()
    {
        this.userName = "";
        this.userHandle = "";
        this.tweetText = "SELECT TWEET";
    } 

    public void SetTweetData(string pfpPath, string username, string userHandle, string tweetText, int agendaScore)
    {
        this.pfpResourcePath = pfpPath;
        this.userName = username;
        this.userHandle = "@" + userHandle;
        this.tweetText = tweetText;
        this.agendaScore = agendaScore;
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
    public string GetUserPFP()
    {
        return pfpResourcePath;
    }

    public Texture GetUserPFPAsTexture()
    {
        return Resources.Load(pfpResourcePath) as Texture2D;;
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

    public void SetSelected(bool selected)
    {
        isSelected = selected;
    }

    public bool GetSelected()
    {
        return isSelected;
    }

    public void SetSelectedIndex(int index)
    {
        this.selectedIndex = index;
    }

    public int GetSelectedIndex()
    {
        return selectedIndex;
    }

    public int GetAgendaScore()
    {
        return agendaScore;
    }

    public void SetTraits(string[] traits)
    {
        this.traits = traits;
    }

    public string[] GetTraits()
    {
        return traits;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tweet 
{
    public Texture profilePicture;
    public string userName;
    public string userHandle;
    public string tweetText;

    public Tweet(Texture profilePicture, string username, string userHandle, string tweetText)
    {
        this.profilePicture = profilePicture;
        this.userName = username;
        this.userHandle = "@" + userHandle;
        this.tweetText = tweetText;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JLo : MonoBehaviour
{
    public TextAsset targetJsonFile;
    public TextAsset tweetsJsonFile;

    void Start()
    {
        Targets targetsInJson = JsonUtility.FromJson<Targets>(targetJsonFile.text);

        foreach (Target target in targetsInJson.targets)
        {
            Debug.Log(target.name);
            Debug.Log(target.desc);
        }

        Debug.Log("LOADING TWEETS NOW");

        LoadTweets();
    }

    void LoadTweets()
    {
        Tweets tweetsInJson = JsonUtility.FromJson<Tweets>(tweetsJsonFile.text);

        foreach (Twit tweet in tweetsInJson.tweets)
        {
            // Debug.Log(tweet.name);
            Debug.Log(tweet.content);
        }
    }

}

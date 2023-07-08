using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Testing : MonoBehaviour
{
    [SerializeField] Transform  tweetContainerTransform;
    [SerializeField] GameObject tweetPrefab;
    [SerializeField] Texture pfp;
    private List<Tweet> tweetsToGenerate;
    // Start is called before the first frame update
    private void Awake() {
        tweetsToGenerate = new List<Tweet>();
        tweetsToGenerate.Add(new Tweet(pfp, "Todd Howard", "notaliar", "I like to tweet very much"));
        tweetsToGenerate.Add(new Tweet(pfp, "Todd Howard", "notaliar", "Starfield will have minimum 60 fps on ultra on Celeron #starfield"));
        tweetsToGenerate.Add(new Tweet(pfp, "Todd Howard", "secondtodd", "Skyrim should run on your bed clock"));
        tweetsToGenerate.Add(new Tweet(pfp, "Rahid", "otaku_in_closet", "It's not like I like anime bbbbbba-ka!!!! #anime #catgirlsforall"));
        tweetsToGenerate.Add(new Tweet(pfp, "Shockwellenreiter", "bicyc", "Cycling in the nineties!!! #cycplus"));
    }

    private void Start() {
        GenerateTweetsSelect();
    }
    public void GenerateTweetsSelect()
    {
        foreach(Tweet tweet in tweetsToGenerate)
        {
            Transform newObject = Instantiate(tweetPrefab, tweetContainerTransform).transform;
            OptionTweet newTweet = newObject.GetComponent<OptionTweet>();
            newTweet.profilePicture.texture = pfp;
            newTweet.userName.text = tweet.userName;
            newTweet.userHandle.text = tweet.userHandle;
            newTweet.tweetText.text = tweet.tweetText;

        }
    }
}

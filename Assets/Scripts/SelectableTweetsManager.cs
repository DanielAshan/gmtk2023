using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableTweetsManager : MonoBehaviour
{
    public static SelectableTweetsManager Instance { get; private set;}
    [SerializeField] Transform  tweetContainerTransform;
    [SerializeField] GameObject tweetPrefab;
    [SerializeField] Texture pfp;
    private List<Tweet> tweetsToGenerate;
    private List<Transform> selectableTweets;
    // Start is called before the first frame update
    private void Awake() {
        if ( Instance != null)
        {
            Debug.LogError("There's more than once SelectableTweetsManager! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
        selectableTweets = new List<Transform>();
        tweetsToGenerate = new List<Tweet>();
        tweetsToGenerate.Add(new Tweet(pfp, "Todd Howard", "notaliar", "I like to tweet very much"));
        tweetsToGenerate.Add(new Tweet(pfp, "Todd Howard", "notaliar", "Starfield will have minimum 60 fps on ultra on Celeron #starfield"));
        tweetsToGenerate.Add(new Tweet(pfp, "Todd Howard", "secondtodd", "Skyrim should run on your bed clock"));
        tweetsToGenerate.Add(new Tweet(pfp, "Rahid", "otaku_in_closet", "It's not like I like anime bbbbbba-ka!!!! #anime #catgirlsforall"));
        tweetsToGenerate.Add(new Tweet(pfp, "Shockwellenreiter", "bicyc", "Cycling in the nineties!!! #cycplus"));
    }

    private void Start() {
        GenerateSelectableTweets();
    }
    public void GenerateSelectableTweets()
    {
        foreach(Tweet tweet in tweetsToGenerate)
        {
            Transform newObject = Instantiate(tweetPrefab, tweetContainerTransform).transform;
            TweetVisual newTweet = newObject.GetComponent<TweetVisual>();
            newTweet.SetTweet(tweet);
            selectableTweets.Add(newObject);
        }
    }

    public void AddTweetToSelectable(Transform tweetObject)
    {

    }

    public void RemoveTweetFromSelectable(Transform tweetObject)
    {

    }
}

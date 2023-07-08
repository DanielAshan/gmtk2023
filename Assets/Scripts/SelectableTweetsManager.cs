using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableTweetsManager : MonoBehaviour
{
    public static SelectableTweetsManager Instance { get; private set;}
    [SerializeField] Transform  tweetContainerTransform;
    [SerializeField] GameObject tweetPrefab;
    [SerializeField] Texture pfp;
    private List<Tweet> selectableTweets;
    private List<Transform> tweetVisuals;
    // Start is called before the first frame update
    private void Awake() {
        if ( Instance != null)
        {
            Debug.LogError("There's more than once SelectableTweetsManager! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
        tweetVisuals = new List<Transform>();
        selectableTweets = new List<Tweet>();
    }

    public void StartSelectableTweetsManager( List<Tweet> listOfTweets) {
        selectableTweets = listOfTweets;
        VisualiseTweets();
    }

    public void CleanSelectableTweetsManager()
    {
        CleanVisuals();
        tweetVisuals = new List<Transform>();
        selectableTweets = new List<Tweet>();
    }
    public void VisualiseTweets()
    {
        CleanVisuals();

        foreach(Tweet tweet in selectableTweets)
        {
            Transform newObject = Instantiate(tweetPrefab, tweetContainerTransform).transform;
            TweetVisual newTweet = newObject.GetComponent<TweetVisual>();
            newTweet.SetTweet(tweet);
            tweetVisuals.Add(newObject);
        }
    }

    private void CleanVisuals()
    {
        foreach (Transform tweet in tweetVisuals)
        {
            Destroy(tweet.gameObject);
        }

        tweetVisuals = new List<Transform>();
    }
    public void AddTweetToSelectable(Tweet tweet)
    {
        selectableTweets.Add(tweet);
        TimelineManager.Instance.RemoteTweetFromSlot(tweet.GetSelectedIndex());
        tweet.SetSelected(false);
        tweet.SetSelectedIndex(-1);
        VisualiseTweets();
    }

    public void RemoveTweetFromSelectable(Tweet tweet)
    {
        selectableTweets.Remove(tweet);
        VisualiseTweets();
    }
}

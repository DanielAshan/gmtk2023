using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineManager : MonoBehaviour
{
    public static TimelineManager Instance { get; private set;}
    [SerializeField] Transform timelineContainerTransform;
    [SerializeField] Texture pfp;
    [SerializeField] GameObject tweetPrefab;
    public Tweet[] tweetsOnTimeline;
    public List<Transform> tweetsVisualised;
    public TweetVisual[] tweetSlots;
    private Tweet[] nonInteracableTweets;

    private void Awake() {
        if ( Instance != null)
        {
            Debug.LogError("There's more than once TimelineManager! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
        tweetsOnTimeline = new Tweet[6];
        tweetsVisualised = new List<Transform>();
        nonInteracableTweets = new Tweet[3];
    }
    void Start()
    {
        GenerateNonInteractableTweets();
        GenerateInitialTimelineData();
        VisualiseTweets();
    }

    public void GenerateNonInteractableTweets()
    {
        nonInteracableTweets[0] = new Tweet(pfp, "Todd Howard", "notaliar", "I like to tweet very much");
        nonInteracableTweets[1] = new Tweet(pfp, "Todd Howard", "notaliar", "Starfield will have minimum 60 fps on ultra on Celeron #starfield");
        nonInteracableTweets[2] = new Tweet(pfp, "Rahid", "otakudupaku", "Sakura is my favorite character in Boruto: Shippuuden");
    }

    public void GenerateInitialTimelineData()
    {
        for (int i = 0; i < 6; i++)
        {
            if ( i % 2 == 0)
            {
                // Add slot
                tweetsOnTimeline[i] = new Tweet();
            }
            else
            {
                // Add nonInteractableTweet
                tweetsOnTimeline[i] = nonInteracableTweets[ i / 2];
                tweetsOnTimeline[i].SetShouldBeInteractable(false);
            }
        }
    }

    public void VisualiseTweets()
    {
        foreach (Transform tweet in tweetsVisualised)
        {
            Destroy(tweet.gameObject);
        }

        tweetsVisualised = new List<Transform>();

        foreach (Tweet tweet in tweetsOnTimeline)
        {
            Transform newTweet = Instantiate(tweetPrefab, timelineContainerTransform).transform;
            TweetVisual newTweetVisual = newTweet.GetComponent<TweetVisual>();
            newTweetVisual.SetTweet(tweet);
            if ( !newTweetVisual.GetShouldBeInteractable() )
            {
                newTweetVisual.DisableTweet();
            }
            tweetsVisualised.Add(newTweet);
        }
    }

    public void AddTweetToSlot(Tweet tweet)
    {
        int emptyIndex = FindFirstEmptySlot();
        if ( emptyIndex == -1 )
        {
            // No empty slot to add a tweet
            Debug.Log("No empty slots on timeline");
            return;
        }        
        tweetsOnTimeline[emptyIndex] = tweet;
        tweet.SetSelected(true);
        tweet.SetSelectedIndex(emptyIndex);
        SelectableTweetsManager.Instance.RemoveTweetFromSelectable(tweet);
        VisualiseTweets();        
    }

    public void RemoteTweetFromSlot(int index)
    {
        tweetsOnTimeline[index] = new Tweet();
        VisualiseTweets();
    }

    public int FindFirstEmptySlot()
    {
        for (int i = 0; i < tweetsOnTimeline.Length; i++)
        {
            Tweet tweet = tweetsOnTimeline[i];
            if (tweet.IsEmpty() == true && tweet.GetShouldBeInteractable() == true) 
            {
                return i;
            }
        }

        // No empty slots
        return -1;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimelineManager : MonoBehaviour
{
    public static TimelineManager Instance { get; private set;}
    [SerializeField] Transform timelineContainerTransform;
    [SerializeField] Transform endTurnGameObject;
    [SerializeField] GameObject tweetPrefab;
    public Tweet[] tweetsOnTimeline;
    public List<Transform> tweetsVisualised;
    public TweetVisual[] tweetSlots;
    private List<Tweet> nonInteractableTweets;
    private Button endTurnButton;

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
        nonInteractableTweets = new List<Tweet>();
        endTurnButton = endTurnGameObject.GetComponent<Button>();
        endTurnButton.interactable = false;
        endTurnButton.GetComponent<Image>().color = Color.red;
    }
    public void StartTimelineManager()
    {
        
        GenerateInitialTimelineData();
        VisualiseTweets();
    }

    public void CleanTimelineManager()
    {
        CleanVisuals();
        tweetsOnTimeline = new Tweet[6];
        tweetsVisualised = new List<Transform>();
        nonInteractableTweets = new List<Tweet>();
        endTurnButton.interactable = false;
        endTurnButton.GetComponent<Image>().color = Color.red;
    }

    public void SetNonInteractableTweets(List<Tweet> tweets)
    {
        nonInteractableTweets = tweets;
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
                tweetsOnTimeline[i] = nonInteractableTweets[ i / 2];
                tweetsOnTimeline[i].SetShouldBeInteractable(false);
            }
        }
    }

    public void VisualiseTweets()
    {
        CleanVisuals();

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

    private void CleanVisuals()
    {
        foreach (Transform tweet in tweetsVisualised)
        {
            Destroy(tweet.gameObject);
        }

        tweetsVisualised = new List<Transform>();
    }
    public void AddTweetToSlot(Tweet tweet)
    {
        Debug.Log("Called add Tweet to Slot");
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

        // Check if this was the last slot, if yes, enable end turn button
        if ( FindFirstEmptySlot() == -1)
        {
            endTurnButton.interactable = true;
            endTurnButton.GetComponent<Image>().color = Color.green;
        }
    }

    public void RemoteTweetFromSlot(int index)
    {
        tweetsOnTimeline[index] = new Tweet();
        VisualiseTweets();

        endTurnButton.interactable = false;
        endTurnButton.GetComponent<Image>().color = Color.red;
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

    public List<Tweet> GetListOfTimelineTweets()
    {
        List<Tweet> listOfTweets = new List<Tweet>();
         for (int i = 0; i < tweetsOnTimeline.Length; i++)
        {
            Tweet tweet = tweetsOnTimeline[i];
            if (tweet.GetShouldBeInteractable() == true) 
            {
                listOfTweets.Add(tweet);
            }
        }

        return listOfTweets;
    }
}

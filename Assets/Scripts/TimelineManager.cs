using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineManager : MonoBehaviour
{
    [SerializeField] Transform timelineContainerTransform;
    [SerializeField] Texture pfp;
    [SerializeField] GameObject tweetPrefab;
    public OptionTweet[] tweetsOnTimeline;
    public OptionTweet[] tweetSlots;
    private Tweet[] nonInteracableTweets;

    private void Awake() {
        tweetsOnTimeline = new OptionTweet[6];
        nonInteracableTweets = new Tweet[3];
    }
    void Start()
    {
        GenerateNonInteractableTweets();
        GenerateTimeline();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateNonInteractableTweets()
    {
        nonInteracableTweets[0] = new Tweet(pfp, "Todd Howard", "notaliar", "I like to tweet very much");
        nonInteracableTweets[1] = new Tweet(pfp, "Todd Howard", "notaliar", "Starfield will have minimum 60 fps on ultra on Celeron #starfield");
        nonInteracableTweets[2] = new Tweet(pfp, "Rahid", "otakudupaku", "Sakura is my favorite character in Boruto: Shippuuden");
    }

    public void GenerateTimeline()
    {
        for (int i = 0; i < 6; i++)
        {
            if ( i % 2 == 0)
            {
                // Add slot
                tweetsOnTimeline[i] = Instantiate(tweetPrefab, timelineContainerTransform).GetComponent<OptionTweet>();
            }
            else
            {
                // Add nonInteractableTweet
                tweetsOnTimeline[i] = Instantiate(tweetPrefab, timelineContainerTransform).GetComponent<OptionTweet>();
                tweetsOnTimeline[i].DisableTweet();
                Tweet tweet = nonInteracableTweets[ i / 2];
                tweetsOnTimeline[i].SetTweetData(tweet.profilePicture, tweet.userName, tweet.userHandle, tweet.tweetText);
            }
        }
    }

    public void AddTweetToSlot()
    {

    }

    public int FindFirstEmptySlot()
    {
        return 1;
    }

}

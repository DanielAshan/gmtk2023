using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineTweetDB
{
    
    private List<Tweet> tweets;

    private List<Tweet> usedTweets;
    
    public void StartDB() {
        tweets = new List<Tweet>();
        usedTweets = new List<Tweet>();

        MockTweetDB mockDB = new MockTweetDB();
        mockDB.StartDB();
        List<MockTweet> mocks = mockDB.GetAllMockTweets();
        foreach (MockTweet mock in mocks)
        {
            Tweet newTweet = new Tweet(
                    mock.avatarResourcePath,
                    mock.name,
                    mock.handle,
                    mock.content
                );
            newTweet.SetShouldBeInteractable(false);
            tweets.Add(newTweet);
        }
    }

    private Tweet PopTimelineTweet()
    {
        Tweet poppedTweet = tweets[tweets.Count - 1];
        tweets.Remove(poppedTweet);
        usedTweets.Add(poppedTweet);
        
        return poppedTweet;
    }
    public List<Tweet> GetNumberofTimelineTweets(int number)
    {
        List<Tweet> list = new List<Tweet>();
        // Check if we have enought tweets
        if (tweets.Count < number)
        {
            // Not enough tweets
            // Remove leftovers and reload DB
            while(tweets.Count > 0)
            {
                Tweet tweet = PopTimelineTweet();
            }

            ReloadTweets();

        }

        // Enough Tweets - proceed
        for (int i = 0; i < number; i++)
        {
            list.Add(PopTimelineTweet());
        }

        return list;
    }

    public List<Tweet> GetAllTimelineTweets()
    {
        List<Tweet> list = new List<Tweet>();
        foreach (Tweet tweet in tweets )
        {
            list.Add(tweet);
        }

        foreach (Tweet tweet in usedTweets )
        {
            list.Add(tweet);
        }

        return list;
    }

    public void ReloadTweets()
    {
        tweets = usedTweets;
        tweets.Reverse();
        usedTweets = new List<Tweet>();
    }

    public void DebugLogAllTweets()
    {
        List<Tweet> list = GetAllTimelineTweets();

        foreach(Tweet tweet in list)
        {
            Debug.Log($"UserProfile name{tweet.GetUserName()}, handle:{tweet.GetUserHandle()}");
        }
    }
}

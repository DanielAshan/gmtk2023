using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SelectableTweetDB
{
    private List<Tweet> tweets;

    private List<Tweet> usedTweets;

    public void StartDB()
    {
        tweets = new List<Tweet>();
        usedTweets = new List<Tweet>();

        TwitDB twitDB = new TwitDB();
        twitDB.StartDB();
        // Generate 4 random twits
        List<Twit> twits = twitDB.GetAllTwits();

        foreach (Twit twit in twits)
        {
            Tweet newTweet = new Tweet(
                twit.profile_pic,
                twit.username,
                twit.handle,
                twit.content,
                twit.triggered_traits,
                twit.agenda_score
            );
            newTweet.SetShouldBeInteractable(true);
            tweets.Add(newTweet);
        }
    }

    private Tweet PopSelectableTweet()
    {
        Tweet poppedTweet = tweets[tweets.Count -1];
        tweets.Remove(poppedTweet);
        usedTweets.Add(poppedTweet);

        return poppedTweet;
    }

    public List<Tweet> GetNumberOfSelectableTweets (int number)
    {
        List<Tweet> list = new List<Tweet>();
        if (tweets.Count < number)
        {
            while (tweets.Count > 0)
            {
                Tweet tweet = PopSelectableTweet();
            }

            ReloadTweets();
        }

        for (int i = 0; i < number; i++)
        {
            list.Add(PopSelectableTweet());
        }

        return list;
    }

    public List<Tweet> GetAllSelectableTweets()
    {
        List<Tweet> list = new List<Tweet>();
        foreach (Tweet tweet in tweets)
        {
            list.Add(tweet);
        }

        foreach (Tweet tweet in usedTweets)
        {
            list.Add(tweet);
        }

        return list;
    }

    public Tweet GetSpecificTweet(string[] matchingTraitStrings, int matchingScoreVal = 2)
    {
        if (tweets.Count == 0)
        {
            ReloadTweets();
        }

        foreach (Tweet tweet in tweets)
        {
            foreach (string trait in tweet.GetTraits())
            {
                if (tweet.GetAgendaScore() == matchingScoreVal && 
                    matchingTraitStrings.Any(s => trait.Contains(s)))
                    {
                        tweets.Remove(tweet);
                        usedTweets.Add(tweet);
                        return tweet;
                    }
            }
        }
        throw new System.Exception("GetSpecificTwit couldn't find requested twit.");
    }

    public void ReloadTweets()
    {
        tweets = usedTweets;
        tweets.Reverse();
        usedTweets = new List<Tweet>();
    }

    public void DebugLogAllTweets()
    {
        List<Tweet> list = GetAllSelectableTweets();

        foreach (Tweet tweet in list)
        {
            Debug.Log(tweet.GetUserName());
            Debug.Log(tweet.GetTraits());
        }
    }
}
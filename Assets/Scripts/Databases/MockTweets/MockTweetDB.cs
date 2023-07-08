using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MockTweetDB
{
    private MockTweets loadedMockTweets;

    private List<MockTweet> shuffledMockTweets;

    public void StartDB()
    {
        shuffledMockTweets = LoadAndRandomizeMockTweets();
    }

    private List<MockTweet> LoadAndRandomizeMockTweets()
    {
        loadedMockTweets = JLo.Instance.LoadMockTweets();

        List<MockTweet> mockTweetsToShuffle = loadedMockTweets.mocktweets;

        var count = mockTweetsToShuffle.Count;
        var last = count;
        for (var i = 0; i < last; ++i)
        {
            var r = UnityEngine.Random.Range(i, count);
            var tmp = mockTweetsToShuffle[i];
            mockTweetsToShuffle[i] = mockTweetsToShuffle[r];
            mockTweetsToShuffle[r] = tmp;
        }

        return mockTweetsToShuffle;
    }
    public List<MockTweet> GetAllMockTweets()
    {
        return shuffledMockTweets;
    }
    
    public List<MockTweet> GetNumOfMockTweets(int numOfMockTweets)
    {
        List<MockTweet> listOfRequestedMockTweets = new List<MockTweet>();

        for (int i = 0; i < numOfMockTweets; i++)
        {
            listOfRequestedMockTweets.Add(shuffledMockTweets[i]);
            Debug.Log(shuffledMockTweets[i].content);
        }

        return listOfRequestedMockTweets;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MockTweetDB : MonoBehaviour
{
    public JLo jloader;

    private MockTweets loadedMockTweets;

    private List<MockTweet> shuffledMockTweets;

    private void Awake()
    {
        shuffledMockTweets = LoadAndRandomizeMockTweets();
    }

    private List<MockTweet> LoadAndRandomizeMockTweets()
    {
        loadedMockTweets = jloader.LoadMockTweets();

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

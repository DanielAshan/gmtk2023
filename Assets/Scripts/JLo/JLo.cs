using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JLo : MonoBehaviour
{
    public TextAsset targetJsonFile;
    public TextAsset tweetsJsonFile;
    public TextAsset mockTweetsJsonFile;

    public Targets LoadTargets()
    {
        Targets targetsInJson = JsonUtility.FromJson<Targets>(targetJsonFile.text);

        return targetsInJson;
    }

    public Tweets LoadTweets()
    {
        Tweets tweetsInJson = JsonUtility.FromJson<Tweets>(tweetsJsonFile.text);

        return tweetsInJson;
    }

    public MockTweets LoadMockTweets()
    {
        MockTweets mockTweetsInJson = JsonUtility.FromJson<MockTweets>(mockTweetsJsonFile.text);
        
        return mockTweetsInJson;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JLo : MonoBehaviour
{
    public TextAsset targetJsonFile;
    public TextAsset twitsJsonFile;
    public TextAsset mockTweetsJsonFile;

    public Targets LoadTargets()
    {
        Targets targetsInJson = JsonUtility.FromJson<Targets>(targetJsonFile.text);

        return targetsInJson;
    }

    public Twits LoadTwits()
    {
        Twits twitsInJson = JsonUtility.FromJson<Twits>(twitsJsonFile.text);

        return twitsInJson;
    }

    public MockTweets LoadMockTweets()
    {
        MockTweets mockTweetsInJson = JsonUtility.FromJson<MockTweets>(mockTweetsJsonFile.text);
        
        return mockTweetsInJson;
    }

}

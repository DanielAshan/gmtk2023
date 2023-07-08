using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JLo: MonoBehaviour
{
    public static JLo Instance { get; private set;}
    public TextAsset targetJsonFile;
    public TextAsset twitsJsonFile;
    public TextAsset mockTweetsJsonFile;
    public TextAsset traitsJsonFile;

    private void Awake() {
        if ( Instance != null)
        {
            Debug.LogError("There's more than once GameManager! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    
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

    public Traits LoadTraits()
    {
        Traits traitsInJson = JsonUtility.FromJson<Traits>(traitsJsonFile.text);

        return traitsInJson;
    }

}

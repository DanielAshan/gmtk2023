using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JLo: MonoBehaviour
{
    public static JLo Instance { get; private set;}
    public TextAsset targetJsonFile;
    public TextAsset tweetsJsonFile;

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

    public Tweets LoadTweets()
    {
        Tweets tweetsInJson = JsonUtility.FromJson<Tweets>(tweetsJsonFile.text);

        return tweetsInJson;
    }

}

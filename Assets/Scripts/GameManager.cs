using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set;}
    [SerializeField] Texture pfp;

    private int turnCounter = 0;

    private UserProfile currentTarget;

    private void Awake() {
        if ( Instance != null)
        {
            Debug.LogError("There's more than once GameManager! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start() {
        StartTurn();
    }
    public void StartRound()
    {
        // Set target

        // Start turn -> load tweets to use
        StartTurn();
    }
    public void StartTurn()
    {
        // Prepare new selectable tweets;
        List<Tweet> selectableTweets = new List<Tweet>();
        selectableTweets.Add(new Tweet(pfp, "Todd Howard", "notaliar", "I like to tweet very much"));
        selectableTweets.Add(new Tweet(pfp, "Todd Howard", "notaliar", "Starfield will have minimum 60 fps on ultra on Celeron #starfield"));
        selectableTweets.Add(new Tweet(pfp, "Todd Howard", "secondtodd", "Skyrim should run on your bed clock"));
        selectableTweets.Add(new Tweet(pfp, "Rahid", "otaku_in_closet", "It's not like I like anime bbbbbba-ka!!!! #anime #catgirlsforall"));
        selectableTweets.Add(new Tweet(pfp, "Shockwellenreiter", "bicyc", "Cycling in the nineties!!! #cycplus"));

        SelectableTweetsManager.Instance.StartSelectableTweetsManager(selectableTweets);

        // Prepare timeline
        // Get mock Tweets
        List<Tweet> nonInteractableTweets = new List<Tweet>();
        nonInteractableTweets.Add(new Tweet(pfp, "Todd Howard", "notaliar", "I like to tweet very much"));
        nonInteractableTweets.Add(new Tweet(pfp, "Todd Howard", "notaliar", "Starfield will have minimum 60 fps on ultra on Celeron #starfield"));
        nonInteractableTweets.Add(new Tweet(pfp, "Rahid", "otakudupaku", "Sakura is my favorite character in Boruto: Shippuuden"));

        // Set mock tweets
        TimelineManager.Instance.SetNonInteractableTweets(nonInteractableTweets);

        // Start timeline manager
        TimelineManager.Instance.StartTimelineManager();
    }

    public void InstantiateNewTarget()
    {
        // Get new target from database

        // Set target data
    }
    public void EndTurn()
    {
        // Add points to meters    
    
        turnCounter++;
        Debug.Log($"Turn counter: {turnCounter}");

        // Clean Timeline and selectable data
        TimelineManager.Instance.CleanTimelineManager();
        SelectableTweetsManager.Instance.CleanSelectableTweetsManager();
        if (turnCounter == 3)
        {
            EndRound();
        }
        else
        {
            StartTurn();
        }
    }

    public void EndRound()
    {
        // Check if all targets done
        Debug.Log("Round ended");
        // Check different agendaLevels, set flags

        // If some stuff like enough targets done -> end game 

        // Else start new round
        StartRound();

    }

    public void EndGame()
    {
        // Prepare outcome?
    }
}

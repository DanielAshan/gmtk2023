using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set;}
    [SerializeField] Texture pfp;

    private int turnCounter = 0;
    private int targetCounter = 0;

    private UserProfile currentTarget;

    private void Awake() {
        if ( Instance != null)
        {
            Debug.LogError("There's more than once GameManager! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
        currentTarget = new UserProfile();
    }

    private void Start() {
        StartRound();
    }
    public void StartRound()
    {
        // Setup new target
        SetNewTarget();
        
        // Reset turn counter
        turnCounter = 0;
        // Start turn -> load tweets to use
        StartTurn();
    }
    public void StartTurn()
    {
        
        // Prepare new selectable tweets;
        List<Tweet> selectableTweets = new List<Tweet>();
        selectableTweets.Add(new Tweet(pfp, "Luke Groundwalker", "sandlover", "I like to tweet very much"));
        selectableTweets.Add(new Tweet(pfp, "Indiana Tomes", "averagewhipenjoyer", "Starfield will have minimum 60 fps on ultra on Celeron #starfield"));
        selectableTweets.Add(new Tweet(pfp, "Gerwant from Poland", "monsterhunter", "Skyrim should run on your bed clock"));
        // selectableTweets.Add(new Tweet(pfp, "Rahid", "otaku_in_closet", "It's not like I like anime bbbbbba-ka!!!! #anime #catgirlsforall"));
        // selectableTweets.Add(new Tweet(pfp, "Shockwellenreiter", "bicyc", "Cycling in the nineties!!! #cycplus"));
        selectableTweets.Add(new Tweet(pfp, "Indiana Tomes", "averagewhipenjoyer", "Starfield will have minimum 60 fps on ultra on Celeron #starfield"));
        selectableTweets.Add(new Tweet(pfp, "Gerwant from Poland", "monsterhunter", "Skyrim should run on your bed clock"));

        SelectableTweetsManager.Instance.StartSelectableTweetsManager(selectableTweets);

        // Prepare timeline
        // Get mock Tweets
        List<Tweet> nonInteractableTweets = new List<Tweet>();
        nonInteractableTweets.Add(new Tweet(pfp, "Gerwant from Poland", "monsterhunter", "Skyrim should run on your bed clock"));
        nonInteractableTweets.Add(new Tweet(pfp, "Indiana Tomes", "averagewhipenjoyer", "Starfield will have minimum 60 fps on ultra on Celeron #starfield"));
        nonInteractableTweets.Add(new Tweet(pfp, "Luke Groundwalker", "sandlover", "I like to tweet very much"));

        // Set mock tweets
        TimelineManager.Instance.SetNonInteractableTweets(nonInteractableTweets);

        // Start timeline manager
        TimelineManager.Instance.StartTimelineManager();
    }

    public void SetNewTarget()
    {
        // Get new target from database
        currentTarget.avatarResourcePath = "sample_avatar";
        currentTarget.userName = "Harold The Pain";
        currentTarget.userHandle = "@nagatokonoha";
        currentTarget.description = "Wants to destroy visible villages";
        currentTarget.traits = new string[] {
            "Likes to visit lots of places", 
            "Fond of starships", 
            "Lives Long and Prospers"};

        TargetInformationUI.Instance.SetTargetUser(currentTarget);
        
        // Reset agenda and boredom levels
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
        targetCounter++;
        // Check different agendaLevels, set flags

        // If some stuff like enough targets done -> end game 
        if (targetCounter == 3)
        {
            EndGame();
        }
        // Else start new round
        StartRound();

    }

    public void EndGame()
    {
        // Prepare outcome?
        Debug.Log("GAME OVER");
        Debug.Log("YOU DID WELL MISTER ALGORITHM");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set;}
    [SerializeField] Transform endScreen;
    public string pfpResourcePath = "sample_avatar";
    private int turnCounter = 0;
    private int targetCounter = 0;

    private UserProfile currentTarget;
    private UserProfileDB usersDB;
    private TimelineTweetDB timelineTweetDB;
    
    private List<Tweet> bangerTweets;
    private List<UserAgendaCompletion> metTargets;

    private int agendaScore = 0;
    private int boredomLevel = 0;

    private const int MAX_AGENDA_SCORE = 6;
    private const int MIN_AGENDA_SCORE = 6;
    private const int MAX_BOREDOM_LEVEL = 10;
    private const int MIN_BOREDOM_LEVEL = 0;
    private void Awake() {
        if ( Instance != null)
        {
            Debug.LogError("There's more than once GameManager! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
        currentTarget = new UserProfile();
        usersDB = new UserProfileDB();
        timelineTweetDB = new TimelineTweetDB();
        usersDB.StartDB();
        timelineTweetDB.StartDB();

        bangerTweets = new List<Tweet>();
        metTargets = new List<UserAgendaCompletion>();
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
        selectableTweets.Add(new Tweet(pfpResourcePath, "Luke Groundwalker", "sandlover", "I like to tweet very much", 2));
        selectableTweets.Add(new Tweet(pfpResourcePath, "Indiana Tomes", "averagewhipenjoyer", "Starfield will have minimum 60 fps on ultra on Celeron #starfield", 0));
        selectableTweets.Add(new Tweet(pfpResourcePath, "Gerwant from Poland", "monsterhunter", "Skyrim should run on your bed clock", 0));
        // selectableTweets.Add(new Tweet(pfp, "Rahid", "otaku_in_closet", "It's not like I like anime bbbbbba-ka!!!! #anime #catgirlsforall"));
        // selectableTweets.Add(new Tweet(pfp, "Shockwellenreiter", "bicyc", "Cycling in the nineties!!! #cycplus"));
        selectableTweets.Add(new Tweet(pfpResourcePath, "Indiana Tomes", "averagewhipenjoyer", "Starfield will have minimum 60 fps on ultra on Celeron #starfield", 0));
        selectableTweets.Add(new Tweet(pfpResourcePath, "Gerwant from Poland", "monsterhunter", "Skyrim should run on your bed clock", 1));

        SelectableTweetsManager.Instance.StartSelectableTweetsManager(selectableTweets);

        // Prepare timeline
        // Get mock Tweets
        List<Tweet> nonInteractableTweets = timelineTweetDB.GetNumberofTimelineTweets(3);

        // Set mock tweets
        TimelineManager.Instance.SetNonInteractableTweets(nonInteractableTweets);

        // Start timeline manager
        TimelineManager.Instance.StartTimelineManager();
    }

    public void SetNewTarget()
    {
        // Get new target from database
        currentTarget = usersDB.PopUserProfile();
        currentTarget.traits = new string[] {
            "Likes to visit lots of places", 
            "Fond of starships", 
            "Lives Long and Prospers"};

        TargetInformationUI.Instance.SetTargetUser(currentTarget);
        
        // Reset agenda and boredom levels
        agendaScore = 0;
        switch (targetCounter)
        {
            case 0:
                boredomLevel = 0;
                break;

            case 1:
                boredomLevel = 2;
                break;

            case 2:
                boredomLevel = 4;    
                break;

            default:
                break;
        }
    }
    public void EndTurn()
    {
        // Add points to meters    
        List<Tweet> selectedTweets = TimelineManager.Instance.GetListOfTimelineTweets();

        // C    alculate and add agenda
        int addAgendaScore = 0;
        foreach(Tweet tweet in selectedTweets)
        {
            if (tweet.GetAgendaScore() == 2)
            {
                bangerTweets.Add(tweet);
            }
            addAgendaScore += tweet.GetAgendaScore();
        }

        agendaScore += addAgendaScore;
        agendaScore = Mathf.Clamp(agendaScore, MIN_AGENDA_SCORE, MAX_AGENDA_SCORE);

        // Calculate and add boredom level
        int countMatches = 0;
        int finalCount = 0;
        foreach(Tweet tweet in selectedTweets)
        {
            foreach(string trait in currentTarget.GetTraits())
            {
                string[] tweetTraits = tweet.GetTraits();
                if ( Array.IndexOf(tweetTraits, trait) > -1)
                {
                    countMatches++;
                }
            }
        }

        // Max 9 mistmaches - whatever match they had
        finalCount = -9 + countMatches;
        boredomLevel += finalCount;
        boredomLevel = Mathf.Clamp(boredomLevel, MIN_BOREDOM_LEVEL, MAX_BOREDOM_LEVEL);
        if (boredomLevel == MAX_BOREDOM_LEVEL)
        {
            // User lost this target
            TargetInformationUI.Instance.UpdateBars(0, boredomLevel);
            EndRound();
        }

        if (agendaScore >= 4)
        {
            // User already won?
            TargetInformationUI.Instance.UpdateBars(agendaScore, boredomLevel);
            EndRound();
        }

        TargetInformationUI.Instance.UpdateBars(agendaScore, boredomLevel);
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
        if (agendaScore >= 4)
        {
            metTargets.Add(new UserAgendaCompletion(currentTarget, true));
        }
        else
        {
            metTargets.Add(new UserAgendaCompletion(currentTarget, false));
        }

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
        int countWins = 0;
        foreach (UserAgendaCompletion user in metTargets)
        {
            if (user.influenced)
            {
                countWins++;
            }
        }

        EndScreenManager end = endScreen.GetComponent<EndScreenManager>();
        if (countWins >=2)
        {
            end.SetData(bangerTweets, metTargets, true);
        }
        else
        {
            end.SetData(bangerTweets, metTargets, true);
        }

        end.SetEnabled(true);
        
    }
}

public struct UserAgendaCompletion
{
    public UserAgendaCompletion(UserProfile user, bool inf)
    {
        userProfile = user;
        influenced = inf;
    }

    public UserProfile userProfile { get; }
    public bool influenced { get; }

    public override string ToString() => $"({userProfile.userName}, {influenced})";
}
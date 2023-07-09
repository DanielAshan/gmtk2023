using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreenManager : MonoBehaviour
{
    [SerializeField] Transform metTargetsListTransform;
    [SerializeField] Transform bangerTweetsListTransform;

    [SerializeField] GameObject tweetPrefab;
    [SerializeField] GameObject userProfilePrefab;
    [SerializeField] TextMeshProUGUI resultText;
    [SerializeField] TextMeshProUGUI summaryText;
    private List<Tweet> bangerTweets;
    private List<Transform> bangerTweetsVisuals;
    private List<UserAgendaCompletion> metTargets;
    private List<Transform> metTargetsVisuals;
    private bool isGameWon = false;
    

    public void SetData(List<Tweet> listOfBangers, List<UserAgendaCompletion> listOfTargets, bool won)
    {
        this.bangerTweets = listOfBangers;
        this.metTargets = listOfTargets;
        this.isGameWon = won;
        LoadEndScreen();
    }

    public void LoadEndScreen()
    {
        bangerTweetsVisuals = new List<Transform>();
        metTargetsVisuals = new List<Transform>();

        if (isGameWon)
        {
            resultText.text = "You won!";
            summaryText.text = "Great! You are a good algorithm! There is a bright future in front of you! Here are the people you met and the banger tweets you sent to them";
        }
        else
        {
            resultText.text = "UUUU! GAME OVER!";
            summaryText.text = "Not good. You are probably going to training again. But maybe you had some banger tweets at least?";
        }
    }
    public void SetEnabled(bool value)
    {
        gameObject.SetActive(value);
        int index = 0;
        foreach (Tweet tweet in bangerTweets )
        {
            Transform newObject = Instantiate(tweetPrefab, bangerTweetsListTransform).transform;
            TweetVisual newTweetVisual = newObject.GetComponent<TweetVisual>();
            newTweetVisual.SetBangerTweet(tweet); 
            bangerTweetsVisuals.Add(newObject);
            index++;
            if (index == 3)
            {
                break;
            }
        }

        foreach (UserAgendaCompletion user in metTargets )
        {
            // Instaniate met targets
            Transform newObject = Instantiate(userProfilePrefab, metTargetsListTransform).transform;
            FinalTargetInfoUI newUser = newObject.GetComponent<FinalTargetInfoUI>();
            newUser.SetUser(user.userProfile);
            newUser.SetInfluenced(user.influenced);
            metTargetsVisuals.Add(newObject);
        }
    }
}

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
    private List<UserAgendaCompletion> metTargets;
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
        foreach (Tweet tweet in bangerTweets )
        {
            // Instaniate banger tweets
        }

        foreach (UserAgendaCompletion user in metTargets )
        {
            // Instaniate met targets
        }

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
    }
}

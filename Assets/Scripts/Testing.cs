using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Testing : MonoBehaviour
{
    public TwitDB twitDB;

    public void Start()
    {
        List<Twit> twitsList = twitDB.GetNumOfTwits(1);

        foreach (Twit i in twitsList)
        {
            Debug.Log(i.agenda_score);
            Debug.Log(i.content);
        }

    }
}

using System.Collections.Generic;
using UnityEngine;

public class TwitDB
{
    private Twits loadedTwits;

    private List<Twit> shuffledTwits;

    public void StartDB()
    {
        shuffledTwits = LoadAndRandomizeTwits();
    }

    private List<Twit> LoadAndRandomizeTwits()
    {
        loadedTwits = JLo.Instance.LoadTwits();

        List<Twit> twitsToShuffle = loadedTwits.twits;
        var count = twitsToShuffle.Count;
        var last = count;
        for (var i = 0; i < last; ++i)
        {
            var r = UnityEngine.Random.Range(i, count);
            var tmp = twitsToShuffle[i];
            twitsToShuffle[i] = twitsToShuffle[r];
            twitsToShuffle[r] = tmp;
        }

        return twitsToShuffle;
    }

    public List<Twit> GetNumOfTwits (int numOfTwits)
    {
        List<Twit> listOfRequestedTwits = new List<Twit>();

        for (int i = 0; i < numOfTwits; i++)
        {
            listOfRequestedTwits.Add(shuffledTwits[i]);
        }

        return listOfRequestedTwits;
    }

    public Twit GetSpecificTwit (string matchingTraitString, int matchingScoreVal)
    {
        Debug.Log("called getspecifictwit");

        foreach (Twit twit in shuffledTwits)
        {
            foreach (string trait in twit.triggered_traits)
            {
                if (twit.agenda_score == 2 && 
                    trait.Contains(matchingTraitString))
                    {
                        return twit;
                    }
            }
        }
        throw new System.Exception("GetSpecificTwit couldn't find requested twit.");
    }

    public Twit DequeueTwitFromTwits()
    {
        Twit poppedTwit = PopAtIndex(shuffledTwits, 0);

        return poppedTwit;
    }

    public static Twit PopAtIndex<Twit>(List<Twit> list, int index)
    {
        Twit r = list[index];
        list.RemoveAt(index);

        return r;
    }


}
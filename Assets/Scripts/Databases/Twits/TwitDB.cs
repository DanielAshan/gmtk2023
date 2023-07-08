using System.Collections.Generic;
using UnityEngine;

public class TwitDB : MonoBehaviour
{
    public JLo jloader;

    private Twits loadedTwits;

    private List<Twit> shuffledTwits;

    public void Awake()
    {
        shuffledTwits = LoadAndRandomizeTwits();
    }

    private List<Twit> LoadAndRandomizeTwits()
    {
        loadedTwits = jloader.LoadTwits();

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

    public void GetSpecificTwit (string matchingTraitString, int matchingScoreVal)
    {
        Debug.Log("called getspecifictwit");
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
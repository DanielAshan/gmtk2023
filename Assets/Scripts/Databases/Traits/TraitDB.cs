using System.Collections.Generic;
using UnityEngine;

public class TraitDB
{
    private Traits loadedTraits;

    private List<Trait> shuffledTraits;

    private List<Trait> usedTraits;

    public void StartDB ()
    {
        shuffledTraits = LoadAndRandomizeTraits();
        usedTraits = new List<Trait>();
    }

    private List<Trait> LoadAndRandomizeTraits() 
    {
        loadedTraits = JLo.Instance.LoadTraits();

        List<Trait> traitsToShuffle = loadedTraits.traits;
        var count = traitsToShuffle.Count;
        var last = count;
        for (var i = 0; i < last; ++i)
        {
            var r = UnityEngine.Random.Range(i, count);
            var tmp = traitsToShuffle[i];
            traitsToShuffle[i] = traitsToShuffle[r];
            traitsToShuffle[r] = tmp;
        }        
        return traitsToShuffle;
    }

    public List<Trait> GetAllTraits()
    {
        return shuffledTraits;
    }

    public string[] GetNumOfTraits(int numOfTraits)
    {
        List<Trait> list = new List<Trait>();
        // Check if we have enought tweets
        if (shuffledTraits.Count < numOfTraits)
        {
            // Not enough tweets
            // Remove leftovers and reload DB
            while(shuffledTraits.Count > 0)
            {
                Trait trait = PopTrait();
            }

            ReloadTraits();

        }

        // Enough Tweets - proceed
        for (int i = 0; i < numOfTraits; i++)
        {
            list.Add(PopTrait());
        }

        string[] returnList = new string[numOfTraits];
        for (int i = 0; i < numOfTraits; i++)
        {
            returnList[i] = list[i].content;
        }

        return returnList;
    }

    public void ReloadTraits()
    {
        shuffledTraits = usedTraits;
        shuffledTraits.Reverse();
        usedTraits = new List<Trait>();
    }
    private Trait PopTrait()
    {
        Trait poppedTrait = shuffledTraits[shuffledTraits.Count - 1];
        shuffledTraits.Remove(poppedTrait);
        usedTraits.Add(poppedTrait);
        
        return poppedTrait;
    }
    
}
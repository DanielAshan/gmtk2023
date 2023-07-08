using System.Collections.Generic;
using UnityEngine;

public class TraitDB
{
    private Traits loadedTraits;

    private List<Trait> shuffledTraits;

    public void StartDB ()
    {
        shuffledTraits = LoadAndRandomizeTraits();
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

    public List<Trait> GetNumOfTraits(int numOfTraits)
    {
        List<Trait> listOfRequestedTraits = new List<Trait>();

        for (int i = 0; i < numOfTraits; i++)
        {
            listOfRequestedTraits.Add(shuffledTraits[i]);
        }

        return listOfRequestedTraits;
    }

    
}
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;

public class TargetDB : MonoBehaviour
{
    public JLo jloader;

    public Targets loadedTargets;

    
    public void Awake()
    {
        List<Target> someTargets = LoadAndRandomizeTargets();
    }
    public List<Target> LoadAndRandomizeTargets()
    {


        loadedTargets = jloader.LoadTargets(); 

        List<Target>TargetsToShuffle = loadedTargets.targets;
        var count = TargetsToShuffle.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i)
        {
            var r = UnityEngine.Random.Range(i, count);
            var tmp = TargetsToShuffle[i];
            TargetsToShuffle[i] = TargetsToShuffle[r];
            TargetsToShuffle[r] = tmp;

            Debug.Log(TargetsToShuffle[i].name);
        }


        // System.Random random = new System.Random();
        // loadedTargets.targets = (List<Target>)loadedTargets.targets.OrderBy(x => random.Next()); 
        // foreach (var i in loadedTargets.targets)
        // {
        //     Debug.Log(i.name);
        // }

        return TargetsToShuffle;
    
    }


}

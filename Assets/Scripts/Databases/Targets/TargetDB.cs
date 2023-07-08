using System.Collections.Generic;
using UnityEngine;

public class TargetDB
{
    private Targets loadedTargets;

    private List<Target> shuffledTargets;
    
    public void StartDB()
    {
        
        shuffledTargets = LoadAndRandomizeTargets();
    }

    private List<Target> LoadAndRandomizeTargets()
    {
        loadedTargets = JLo.Instance.LoadTargets(); 

        List<Target>targetsToShuffle = loadedTargets.targets;
        var count = targetsToShuffle.Count;
        var last = count;
        for (var i = 0; i < last; ++i)
        {
            var r = UnityEngine.Random.Range(i, count);
            var tmp = targetsToShuffle[i];
            targetsToShuffle[i] = targetsToShuffle[r];
            targetsToShuffle[r] = tmp;

            // Debug.Log(targetsToShuffle[i].name);
        }

        return targetsToShuffle;
    }

    public List<Target> GetAllTargets()
    {
        return shuffledTargets;
    }
    public Target DequeueTargetFromTargets()
    {
        Target poppedTarget = PopAtIndex(shuffledTargets, 0);

        return poppedTarget;
    }

    public static Target PopAtIndex<Target>(List<Target> list, int index)
    {  
        Target r = list[index];
        list.RemoveAt(index);

        return r;
    }

}

using System.Collections.Generic;
using UnityEngine;

public class TargetDB : MonoBehaviour
{
    public JLo jloader;

    private Targets loadedTargets;

    private List<Target> shuffledTargets;

    
    public void Awake()
    {
        shuffledTargets = LoadAndRandomizeTargets();
    }
    private List<Target> LoadAndRandomizeTargets()
    {
        loadedTargets = jloader.LoadTargets(); 

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

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;

public class TargetDB : MonoBehaviour
{
    public JLo jloader;

    public Targets loadedTargets;

    

    void Start()
    {


        loadedTargets = jloader.LoadTargets(); 


        System.Random random = new System.Random();
        loadedTargets.targets = loadedTargets.targets.OrderBy(x => random.Next()).ToArray();
        foreach (var i in loadedTargets.targets)
        {
            Debug.Log(i.name);
        }
    
    }

}

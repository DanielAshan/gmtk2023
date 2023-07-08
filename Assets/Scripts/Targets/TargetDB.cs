using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDB : MonoBehaviour
{
    public JLo jloader;

    void Start()
    {
        // JLo jloader = GetComponent<JLo>();

        jloader.LoadTargets(); 
    }
}

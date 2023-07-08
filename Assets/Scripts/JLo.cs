using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JLo : MonoBehaviour
{
    public TextAsset jsonFile;

    void Start()
    {
        Targets targetsInJson = JsonUtility.FromJson<Targets>(jsonFile.text);

        foreach (Target target in targetsInJson.targets)
        {
            Debug.Log(target.name);
            Debug.Log(target.desc);
        }
    }
}

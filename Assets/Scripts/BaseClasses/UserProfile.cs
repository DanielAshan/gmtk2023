using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserProfile
{
    public string avatarResourcePath;
    public string userName;
    public string userHandle;
    public string[] traits;

    public int boredomLevel;
    public int agendaLevel;

    public string GetTraits()
    {
        string traitList = "";
        foreach (string trait in traits)
        {
            traitList += $"- {trait} \n";
        }

        return traitList;
    }
}

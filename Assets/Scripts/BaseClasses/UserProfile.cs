using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserProfile
{
    public string avatarResourcePath;
    public string userName;
    public string userHandle;
    public string description;
    public string[] traits;

    public int boredomLevel;
    public int agendaLevel;

    public UserProfile(string avatar, string name, string handle, string desc)
    {
        avatarResourcePath = avatar;
        userName = name;
        userHandle = handle;
        description = desc;
    }

    public UserProfile()
    {
        // No action, empty object
    }

    public void SetTraits(string[] traits)
    {
        this.traits = traits;
    }

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

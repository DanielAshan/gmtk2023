using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserProfileDB
{
    private List<UserProfile> userProfiles;

    private List<UserProfile> usedUserProfiles;
    
    public void StartDB() {
        userProfiles = new List<UserProfile>();
        usedUserProfiles = new List<UserProfile>();

        TargetDB targetDatabase = new TargetDB();
        targetDatabase.StartDB();
        List<Target> targets = targetDatabase.GetAllTargets();
        foreach (Target target in targets)
        {
            userProfiles.Add(
                new UserProfile(
                    target.avatarResourcePath,
                    target.name,
                    target.handle,
                    target.desc
                ));
        }
    }

    public UserProfile PopUserProfile()
    {
        UserProfile poppedProfile = userProfiles[userProfiles.Count - 1];
        userProfiles.Remove(poppedProfile);
        usedUserProfiles.Add(poppedProfile);
        if (userProfiles.Count == 0)
        {
            ReloadProfiles();
        }
        return poppedProfile;
    }

    public List<UserProfile> GetAllUserProfiles()
    {
        List<UserProfile> list = new List<UserProfile>();
        foreach (UserProfile user in userProfiles )
        {
            list.Add(user);
        }

        foreach (UserProfile user in usedUserProfiles )
        {
            list.Add(user);
        }

        return list;
    }

    public void ReloadProfiles()
    {
        userProfiles = usedUserProfiles;
        userProfiles.Reverse();
        usedUserProfiles = new List<UserProfile>();
    }

    public void DebugLogAllProfiles()
    {
        List<UserProfile> list = GetAllUserProfiles();

        foreach(UserProfile user in list)
        {
            Debug.Log($"UserProfile name{user.userName}, handle:{user.userHandle}");
        }
    }
}

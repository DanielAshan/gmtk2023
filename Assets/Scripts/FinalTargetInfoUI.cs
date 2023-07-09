using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FinalTargetInfoUI : MonoBehaviour
{
    public UserProfile user;

    [SerializeField] public TextMeshProUGUI handleText;
    [SerializeField] public TextMeshProUGUI userName;
    [SerializeField] public TextMeshProUGUI description;
    [SerializeField] public RawImage avatar;
    [SerializeField] public RawImage background;

    public bool influenced;

    private void Awake() {
        user = new UserProfile();
        background = GetComponent<RawImage>();
    }

    public void SetUser(UserProfile user)
    {
        this.user = user;
        UpdateVisual();
    }

    public void SetInfluenced(bool inf)
    {
        influenced = inf;
        UpdateInfluencedVisual();
    }

    public void UpdateVisual()
    {
        handleText.text = user.userHandle;
        userName.text = user.userName;
        description.text = user.description;
        Texture texture = Resources.Load("avatars/"+user.avatarResourcePath) as Texture2D;
        avatar.texture = texture;
    }    

    public void UpdateInfluencedVisual()
    {
        if (influenced)
        {
            // Update with green
            background.color = Color.green;
        }
        else
        {
            // Update with bad
            background.color = Color.red;
        }
    }
}

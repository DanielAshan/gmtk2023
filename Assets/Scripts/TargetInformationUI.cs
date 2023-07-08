using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TargetInformationUI : MonoBehaviour
{
    public static TargetInformationUI Instance { get; private set;}
    [SerializeField]
    private TextMeshProUGUI userNameText;
    [SerializeField]
    private TextMeshProUGUI handleText;

    [SerializeField]
    private TextMeshProUGUI traitsText;

    [SerializeField]
    public RawImage avatar;

    Texture2D texture;

    public UserProfile targetUser;

    private void Awake() {
        if ( Instance != null)
        {
            Debug.LogError("There's more than once GameManager! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void SetTargetUser(UserProfile targetUser)
    {
        this.targetUser = targetUser;
        UpdateVisual();
    }

    public void UpdateVisual()
    {
        userNameText.text = targetUser.userName;
        handleText.text = targetUser.userHandle;

        traitsText.text = targetUser.GetTraits();

        texture = Resources.Load(targetUser.avatarResourcePath) as Texture2D;
        avatar.texture = texture;
    }
}

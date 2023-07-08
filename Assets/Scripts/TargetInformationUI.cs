using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TargetInformationUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI handleText;

    [SerializeField]
    private TextMeshProUGUI traitsText;

    [SerializeField]
    public RawImage avatar;

    Texture2D texture;

    void Start()
    {
        handleText.text = "This is a test text";

        traitsText.text = " - This is a first trait \n - This is a second trait \n - And this is a third trait";

        texture = Resources.Load("hrld") as Texture2D;

        Debug.Log(texture);

        avatar.GetComponent<RawImage>().texture = texture;
    }
}

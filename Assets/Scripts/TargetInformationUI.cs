using UnityEngine;
using TMPro;

public class TargetInformationUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI handleText;

    [SerializeField]
    private TextMeshProUGUI traitsText;

    void Start()
    {
        handleText.text = "This is a test text";

        traitsText.text = " - This is a first trait \n - This is a second trait \n - And this is a third trait";
    }
}

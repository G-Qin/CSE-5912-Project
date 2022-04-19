using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GetVolumeValue : MonoBehaviour
{
    [SerializeField]
    public Slider Slider;

    private void Update()
    {
        this.GetComponent<TextMeshProUGUI>().text = Slider.value.ToString();
    }
}

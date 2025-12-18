using UnityEngine;
using UnityEngine.UI;

public class SliderChanger : MonoBehaviour
{
    [SerializeField] private Mixer _mixer;
    [SerializeField] private string _exposedParameter = "MasterVolume";
    
    private const float MinValue = 0.0001f;
    
    private Slider _slider;
    
    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _slider.minValue = MinValue;
    }

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(OnSliderValueChanged);
    }

    private void OnSliderValueChanged(float value)
    {
        _mixer.SetVolume(_exposedParameter, value);
    }
}

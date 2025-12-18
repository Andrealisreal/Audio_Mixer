using UnityEngine;
using UnityEngine.UI;

public class ToggleSwitcher : MonoBehaviour
{
    [SerializeField] private Mixer _mixer;
    [SerializeField] private string _exposedParameter = "MasterVolume";
    
    private Toggle _toggle;

    private void Awake()
    {
        _toggle = GetComponent<Toggle>();
    }

    private void OnEnable()
    {
        _toggle.onValueChanged.AddListener(OnSetSoundEnabled);
    }

    private void OnDisable()
    {
        _toggle.onValueChanged.RemoveListener(OnSetSoundEnabled);
    }

    private void OnSetSoundEnabled(bool value)
    {
        _mixer.SetSoundEnabled(_exposedParameter, value);
    }
}

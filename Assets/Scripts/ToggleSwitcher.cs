using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ToggleSwitcher : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _audioMixerGroup;
    [SerializeField] private Mixer _mixer;
    
    private Toggle _toggle;

    private void Awake()
    {
        _toggle = GetComponent<Toggle>();
    }

    private void OnEnable()
    {
        _toggle.onValueChanged.AddListener(_mixer.SetSoundEnabled);
    }

    private void OnDisable()
    {
        _toggle.onValueChanged.RemoveListener(_mixer.SetSoundEnabled);
    }
}

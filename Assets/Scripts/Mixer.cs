using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Mixer : MonoBehaviour
{
    private const string Master = "Master";
    private const string Music = "Music";
    private const string SFX = "SFX";

    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private Toggle _muteSoundToggle;
    [SerializeField] private Button _effectButtonOne;
    [SerializeField] private Button _effectButtonTwo;
    [SerializeField] private Button _effectButtonThree;
    [SerializeField] private Slider _globalVolumeSliders;
    [SerializeField] private Slider _musicVolumeSliders;
    [SerializeField] private Slider _sfxVolumeSliders;
    [SerializeField] private AudioSource[] _audioSources;
    
    private float _currentGlobalVolume;

    private void Awake()
    {
        _globalVolumeSliders.minValue = 0.0001f;
        _globalVolumeSliders.value = 1f;
        _musicVolumeSliders.minValue = 0.0001f;
        _musicVolumeSliders.value = 1f;
        _sfxVolumeSliders.minValue = 0.0001f;
        _sfxVolumeSliders.value = 1f;
    }
    
    private void Start()
    {
        SetSoundEnabled(_muteSoundToggle.isOn);
    }

    private void OnEnable()
    {
        _muteSoundToggle.onValueChanged.AddListener(SetSoundEnabled);
        _globalVolumeSliders.onValueChanged.AddListener(value => SetVolume(Master, value));
        _musicVolumeSliders.onValueChanged.AddListener(value => SetVolume(Music, value));
        _sfxVolumeSliders.onValueChanged.AddListener(value => SetVolume(SFX, value));
        _effectButtonOne.onClick.AddListener(_audioSources[0].Play);
        _effectButtonTwo.onClick.AddListener(_audioSources[1].Play);
        _effectButtonThree.onClick.AddListener(_audioSources[2].Play);
    }

    private void OnDisable()
    {
        _muteSoundToggle.onValueChanged.RemoveListener(SetSoundEnabled);
        _globalVolumeSliders.onValueChanged.RemoveListener(value => SetVolume(Master, value));
        _musicVolumeSliders.onValueChanged.RemoveListener(value => SetVolume(Music, value));
        _sfxVolumeSliders.onValueChanged.RemoveListener(value => SetVolume(SFX, value));
        _effectButtonOne.onClick.RemoveListener(_audioSources[0].Play);
        _effectButtonTwo.onClick.RemoveListener(_audioSources[1].Play);
        _effectButtonThree.onClick.RemoveListener(_audioSources[2].Play);
    }

    private void SetSoundEnabled(bool isEnabled)
    {
        _mixer.audioMixer.SetFloat(Master, isEnabled ? _currentGlobalVolume : -80f);
    }

    private void SetVolume(string param, float sliderValue)
    {
        _currentGlobalVolume = Mathf.Log10(sliderValue) * 20;
        _mixer.audioMixer.SetFloat(param, _currentGlobalVolume);
    }
}
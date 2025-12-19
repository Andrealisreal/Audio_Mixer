using UnityEngine;
using UnityEngine.Audio;

public class Mixer : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;
    
    private const float MinVolume = -80f;
    private const float SoundMultiplier = 20f;
    
    public void SetSoundEnabled(bool isEnabled)
    {
        if (isEnabled == false)
            _mixer.audioMixer.SetFloat(_mixer.name, MinVolume);
    }
    
    public void SetVolume(string exposedParameter, float sliderValue)
    {
        var volume = Mathf.Log10(sliderValue) * SoundMultiplier;
        _mixer.audioMixer.SetFloat(exposedParameter, volume);
    }
}
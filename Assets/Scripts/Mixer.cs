using UnityEngine;
using UnityEngine.Audio;

public class Mixer : MonoBehaviour
{
    [SerializeField] private AudioMixer _mixer;
    
    private const float MinVolume = -80f;
    
    private float _currentVolume;
    
    public void SetSoundEnabled(string exposedParameter, bool isEnabled)
    {
         _mixer.SetFloat(exposedParameter, isEnabled ? _currentVolume : MinVolume);
    }
    
    public void SetVolume(string exposedParameter, float sliderValue)
    {
        _currentVolume = Mathf.Log10(sliderValue) * 20;
        _mixer.SetFloat(exposedParameter, _currentVolume);
    }
}
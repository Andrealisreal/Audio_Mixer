using UnityEngine;
using UnityEngine.UI;

public class ButtonEffect : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(_audioSource.Play);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(_audioSource.Play);
    }
}

using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    private const string MasterGroup = "Master";
    private const string EffectsGroup = "Effects";
    private const string MusicGroup = "Music";

    [SerializeField] private AudioMixer _mixer;

    private float _minValue = 0.0001f;
    private float _maxValue = 1;

    public void ChangeMasterVolume(float value)
    {
        _mixer.SetFloat(MasterGroup, ConvertToVolume(value));
    }

    public void ChangeEffectsVolume(float value)
    {
        _mixer.SetFloat(EffectsGroup, ConvertToVolume(value));
    }

    public void ChangeMusicVolume(float value)
    {
        _mixer.SetFloat(MusicGroup, ConvertToVolume(value));
    }

    public void SwitchVolume()
    {
        _mixer.GetFloat(MasterGroup, out float currentValue);
        _mixer.SetFloat(MasterGroup, currentValue == ConvertToVolume(_minValue) ? ConvertToVolume(_maxValue) : ConvertToVolume(_minValue));
    }

    private float ConvertToVolume(float value)
    {
        value = Mathf.Clamp(value, _minValue, _maxValue);
        return Mathf.Log10(value) * 20;
    }
}
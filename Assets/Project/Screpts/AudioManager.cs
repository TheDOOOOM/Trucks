using System;
using _PlatformJump._Screpts.SO;
using UnityEngine;
using UnityEngine.Serialization;

public class AudioManager : MonoBehaviour, IService
{
    [SerializeField] private SounConfig _sounConfig;
    [SerializeField] private AudioSource _audioMenuMusick;
    [SerializeField] private AudioSource _audioGameMusick;
    [SerializeField] private AudioSource _buttonClick;

    public float SoundValue => _sounConfig.ValueSound;
    public float MusickValue => _sounConfig.ValueMusick;

    private void Start()
    {
        SetSoundValue();
        SetSound();
    }

    public void SetMusick(float value)
    {
        _audioMenuMusick.volume = value;
        _audioGameMusick.volume = value;
        _sounConfig.SetMuscikValue(value);
    }

    public void SetSound(float value)
    {
        _buttonClick.volume = value;
        _sounConfig.SetSoundValue(value);
    }

    public void PlayButtonClick()
    {
        _buttonClick.Play();
    }

    public void PlayMenuMusick()
    {
        _audioGameMusick.Stop();
        _audioMenuMusick.Play();
    }

    public void PlayGame()
    {
        _audioMenuMusick.Stop();
        _audioGameMusick.Play();
    }

    private void SetSoundValue()
    {
        _audioGameMusick.volume = _sounConfig.ValueMusick;
        _audioMenuMusick.volume = _sounConfig.ValueMusick;
    }

    private void SetSound()
    {
        _buttonClick.volume = _sounConfig.ValueSound;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource effectAudioSource;
    [SerializeField] private AudioSource defaultAudioSource;
    [SerializeField] private AudioSource bossAudioSource;
    [SerializeField] private AudioClip shootClip;
    [SerializeField] private AudioClip reloadClip;
    [SerializeField] private AudioClip energyClip;

    public void ShootAudio()
    {
        effectAudioSource.PlayOneShot(shootClip);
    }
    public void ReloadAudio()
    {
        effectAudioSource.PlayOneShot(reloadClip);
    }
    public void EnergyAudio()
    {
        effectAudioSource.PlayOneShot(energyClip);
    }
    public void BossAudio()
    {
        bossAudioSource.Play();
        defaultAudioSource.Stop();
    }
    public void DefaultAudio()
    {
        bossAudioSource.Stop();
        defaultAudioSource.Play();
    }
    public void StopAudio()
    {
        effectAudioSource.Stop();
        bossAudioSource.Stop();
        defaultAudioSource.Stop();
    }
}

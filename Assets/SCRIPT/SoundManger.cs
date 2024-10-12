using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManger : MonoBehaviour
{
    public static SoundManger Instance { get; private set; }
    private AudioSource m_AudioSource;
    private void Awake()
    {
        Instance = this;
        m_AudioSource = GetComponent<AudioSource>();
    }
    public void PlaySound(AudioClip _m_AudioSource)
    {
        m_AudioSource.PlayOneShot(_m_AudioSource);
    }
}

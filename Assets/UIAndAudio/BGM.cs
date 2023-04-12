using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    private AudioSource audioSource;
    public static BGM instance;
    [SerializeField]
    private AudioClip sandAudios, seaAudio;
    private void Start()
    {
        if (instance == null)
        {
            instance = this.GetComponent<BGM>();
        }
        audioSource = GetComponent<AudioSource>();
    }
    public void SandAudio()
    {
        audioSource.clip = sandAudios;
        audioSource.Play();
    }
    public void SeaAudio()
    {
        audioSource.clip = seaAudio;
        audioSource.Play();
    }
}

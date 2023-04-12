using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;
    public static AudioManager instance;
    [SerializeField]
    private AudioClip jumpAudio, walkAudio, rockAudio, dashAudio, switchAudio, deadAudio, switchSceneAudio, bagAudio, pickAudio;
    private void Start()
    {
        if (instance == null)
        {
            instance = this.GetComponent<AudioManager>();
        }
        audioSource = GetComponent<AudioSource>();
    }
    public void JumpAudio()
    {
        audioSource.clip = jumpAudio;
        audioSource.Play();
    }
    public void WalkAudio()
    {
        audioSource.clip = walkAudio;
        audioSource.Play();
    }
    public void RockAudio()
    {
        audioSource.clip = rockAudio;
        audioSource.Play();
    }
    public void DashAudio()
    {
        audioSource.clip = dashAudio;
        audioSource.Play();
    }
    public void SwitchAudio()
    {
        audioSource.clip = switchAudio;
        audioSource.Play();
    }
    public void DeadAudio()
    {
        audioSource.clip = deadAudio;
        audioSource.Play();
    }
    public void SwitchSceneAudio()
    {
        audioSource.clip = switchSceneAudio;
        audioSource.Play();
    }
    public void BagAudio()
    {
        audioSource.clip = bagAudio;
        audioSource.Play();
    }
    public void PickAudio()
    {
        audioSource.clip = pickAudio;
        audioSource.Play();
    }
}

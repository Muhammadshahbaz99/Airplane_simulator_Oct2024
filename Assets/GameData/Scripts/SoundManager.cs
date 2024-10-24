using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField] AudioSource audiosource;

    private void Awake()
    {
        instance = this;

        if (!audiosource)
            audiosource = GetComponent<AudioSource>();
    }
   public void PlayOnShot(AudioClip clip)
    {
        audiosource.PlayOneShot(clip);
    }
}

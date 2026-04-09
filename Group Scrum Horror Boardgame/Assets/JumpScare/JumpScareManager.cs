using System;
using UnityEngine;

public class JumpScareManager : MonoBehaviour
{
    [SerializeField] private SanityManager _sanityManager;

    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private bool jumpscare = false;

    private void Awake()
    {
        //Epic error handeling
        if (_sanityManager == null)
        {
            _sanityManager = FindObjectOfType<SanityManager>();

            if(_sanityManager == null)
            {
                Debug.LogError("Please check if there is a Sanity Manager in your scene~!");
            }
        }
        if (_audioSource == null)
        {
            _audioSource= FindObjectOfType<AudioSource>();

            if(_audioSource == null)
            {
                Debug.LogError("Please check if there is an Audio Source in your scene!");
            }
        }

        if(_audioClip == null)
        {
            Debug.LogError("Please check if there is an Audio Clip assigned!");
        }

    }

    // This is for testing, should be removed after it's connected to the chest
    private void Update()
    {
        if(jumpscare){
            GetJumpScared(5);
            jumpscare = false;
        }
    }

    public void GetJumpScared(int ammount)
    {
        _sanityManager.DrainCurrentSanity(ammount);
        _audioSource.clip = _audioClip;
        _audioSource.Play();
    }
}

using UnityEngine;
using System.Collections;
using Unity.Mathematics;

public class JumpScareManager : MonoBehaviour
{
    [SerializeField] private SanityManager _sanityManager;

    [Header("Audio")]
    [SerializeField] private AudioSource _audioSource;

    [Header("Animation")]
    [SerializeField] private GameObject _jumpScareObject;
    [SerializeField] private Animator _jumpScareAnimator;

    [Header("Spawn Chest")] 
    [SerializeField] private GameObject _triggerObject;
    [SerializeField] private Transform _playerCamera;
    [SerializeField] private GameObject _chestObject;
    [SerializeField] private float _spawnDistance = 2f;
    
    
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

        if (_jumpScareAnimator == null)
        {
            _jumpScareAnimator = _jumpScareObject.GetComponentInChildren<Animator>();
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
        if (_triggerObject == null)
        {
            return;
        }
        // todo: lock player controller
        // decrease sanity
        _sanityManager.DrainCurrentSanity(ammount);
        
        // spawn chest at correct position
        GameObject _spawnedChest = Instantiate(_chestObject, _triggerObject.transform.position, _triggerObject.transform.rotation);
        Destroy(_triggerObject);
        _jumpScareAnimator = _spawnedChest.GetComponentInChildren<Animator>();
        // play audio
        _audioSource.Play();
        // play animation
        _jumpScareAnimator.SetTrigger("JumpScare");
        // todo: release player controller
    }

}

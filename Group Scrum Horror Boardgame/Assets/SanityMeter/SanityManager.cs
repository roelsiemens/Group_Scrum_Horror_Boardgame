using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class SanityManager : MonoBehaviour
{
    // marking the private variables with _underscore
    [Header("Sanity settings")]
    private const int _maxSanity = 100;
    private const int _minSanity = 0;
    private const int _sanityFactor = _maxSanity / 100;
    private float _currentSanity;
    [SerializeField] private int _sanityMultiplier = 1;

    // testing 
    [SerializeField] private bool isHoldingTorch = false;

    [Header("Sanity Visual Settings")]
    [SerializeField] private Volume _sanityVolume;
    [SerializeField] private LensDistortion _lenseDistortion;
    [SerializeField] private Vignette _vignette;
    [SerializeField] private AudioSource _whisperSource;
    [SerializeField] private Camera _playerCamera;
    
    private void Awake()
    {
        _sanityVolume.weight = 0;
        _currentSanity = _maxSanity;
        if (_sanityVolume.profile.TryGet(out _lenseDistortion))
        {
            _lenseDistortion.intensity.Override(0f);
        }

        if (_sanityVolume.profile.TryGet(out _vignette))
        {
            _vignette.intensity.Override(0f);
        }
    }
    
    private void Update()
    {
        if (_currentSanity <= 0)
        {
            TempLoseGame();
            return;
        }
        
        if(isHoldingTorch)
        {
            RestoreCurrentSanity(Time.deltaTime);
        }
        else
        {
            DrainCurrentSanity(Time.deltaTime);
        }
        
        if(_currentSanity < _sanityFactor * 25)
        {
            SanityLevel4();
        }
        else if (_currentSanity < _sanityFactor * 50)
        {
            SanityLevel3();
        }
        else if(_currentSanity < _sanityFactor * 75)
        {
            SanityLevel2();
        }
        else
        {
            SanityLevel1();
        }
        
    }

    public IEnumerator ZoomEffect(float targetFOV, float duration)
    {
        float startFOV = _playerCamera.fieldOfView;
        float time = 0;

        while (time < duration)
        {
            _playerCamera.fieldOfView = Mathf.Lerp(startFOV, targetFOV, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        _playerCamera.fieldOfView = targetFOV;
    }
    public IEnumerator BlurEffect(float targetIntensity, float duration)
    {
        float time = 0;

        while (time < duration)
        {
            time += Time.deltaTime;
            yield return null;
        }
    }

    public void WarpEffect(float intensity)
    {
        _lenseDistortion.intensity.Override(intensity);
    }
    public void VignetteEffect(float intensity)
    {
        _lenseDistortion.intensity.Override(intensity);
    }

    // Sanity levels, the higher the number the less sane the player is.
    private void SanityLevel1()
    {
        Debug.unityLogger.Log("Crystal clear mind");
    }

    private void SanityLevel2()
    {
        Debug.unityLogger.Log("You lost a quarter of your sanity. A slight headache sets in");
        // Warping effect on the camera/ camera zooming in or out.
        StartCoroutine(ZoomEffect(75f, 4f));
        _sanityVolume.weight = 1f;
        WarpEffect(0.25f);
        VignetteEffect(0.2f);
        // Hearing whispering in the distance or other disturbing sounds. (for now I have only the whisper)
    }

    private void SanityLevel3()
    {
        Debug.unityLogger.Log("You lost a half of your sanity. You heart is pounding and you feel your hands shake.");
        // Increase warping effect 
        // Play more disturbing sound effect
    }

    private void SanityLevel4()
    {
        Debug.unityLogger.Log("You lost three quarters of your sanity. Are you still sane...?");
        // Spawn fake monsters into the scene
        // Play mimic jump scare even if the chest does not contain one. 
        // collapse player, play high pitch scream. This alerts enemies nearby. 
        // Player is slowed for a brief time and cannot crouch. 
    }

    private void TempLoseGame()
    {
        Time.timeScale = 0;
        Debug.Log("You lose the game");
    }
    
    /// <summary>
    /// This method returns the current sanity value.
    /// </summary>
    public float GetCurrentSanity(){
        return _currentSanity;
    }

    /// <summary>
    /// This method returns the maximum sanity value.
    /// </summary>
    public float GetMaxSanity()
    {
        return _maxSanity;
    }

    /// <summary>
    /// This method decreases the current sanity value instantly. Lowest value is 0.
    /// </summary>
    /// <param name="drainAmmount">The ammount of stamina to be drained.</param>
    public float DrainCurrentSanity(int drainAmmount)
    {
        _currentSanity = _currentSanity < 0 ? 0 : _currentSanity - drainAmmount;
        return _currentSanity;
    }
    
    /// <summary>
    /// This method decreases the current sanity value over time. Lowest value is 0.
    /// </summary>
    /// <param name="deltaTime">the time value over which the value is lowered.</param>
    public void DrainCurrentSanity(float deltaTime)
    {
        _currentSanity = Mathf.Clamp(_currentSanity - (deltaTime * _sanityMultiplier), _minSanity, _maxSanity);
    }

    /// <summary>
    /// This method increases the current sanity value. Highest value is defined by _maxSanity.
    /// </summary>
    /// <param name="deltaTime">the time value over which the value is increased.</param>
    public void RestoreCurrentSanity(float deltaTime)
    {
        _currentSanity = Mathf.Clamp(_currentSanity + (deltaTime * _sanityMultiplier), _minSanity, _maxSanity);
    }
    
}
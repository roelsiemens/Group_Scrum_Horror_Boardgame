using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;


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
    [SerializeField] private Camera _playerCamera;
    [SerializeField] private Volume _sanityVolume;
    [SerializeField] private float _effectTransitionSpeed = 1f;
    private LensDistortion _lenseDistortion;
    private ChromaticAberration _chromaticAberration;
    private Vignette _vignette;
    
    [Header("Sanity Audio Settings")]
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _sanity1Clip;
    [SerializeField] private AudioClip _sanity2Clip;
    [SerializeField] private AudioClip _sanity3Clip;
    [SerializeField] private AudioClip _sanity4Clip;

    [Header("Sanity UI Settings")] 
    [SerializeField] private Image _uiImage;
        
    [SerializeField] private Sprite _level1Sprite;
    [SerializeField] private Sprite _level2Sprite;
    [SerializeField] private Sprite _level3Sprite;
    [SerializeField] private Sprite _level4Sprite;
    
    public enum SanityState
    {
        Level1, 
        Level2, 
        Level3, 
        Level4
    }
    private SanityState _currentState;
    
    private void Awake()
    {
        _sanityVolume.weight = 1;
        _currentSanity = _maxSanity;
        if (_sanityVolume.profile.TryGet(out _lenseDistortion))
        {
            _lenseDistortion.intensity.Override(0);
            _lenseDistortion.active = true;
        }
        if (_sanityVolume.profile.TryGet(out _chromaticAberration))
        {
            _chromaticAberration.intensity.Override(0);
            _chromaticAberration.active = true;
        }

        if (_sanityVolume.profile.TryGet(out _vignette))
        {
            _vignette.intensity.Override(0);
            _vignette.active = true;
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
        
        SanityState newState = GetSanityState();

        if (newState != _currentState)
        {
            _currentState = newState;
            ApplySanityState(_currentState);
        }
    }

    public SanityState GetSanityState()
    {
        if(_currentSanity < _sanityFactor * 25)
        {
            return SanityState.Level4;
        }
        if (_currentSanity < _sanityFactor * 50)
        {
            return SanityState.Level3;
        }
        if(_currentSanity < _sanityFactor * 75)
        {
            return SanityState.Level2;
        }
        
        return SanityState.Level1;
    }

    private void ApplySanityState(SanityState state)
    {
        StopAllCoroutines();

        switch (state)
        {
            case SanityState.Level1:
                _uiImage.sprite = _level1Sprite;
                StartCoroutine(WarpEffect(60f, 0f,_effectTransitionSpeed));
                ChromaticAberration(0f);
                VignetteEffect(0f);
                _audioSource.clip = _sanity1Clip;
                _audioSource.Play();
                break;
            case SanityState.Level2:
                _uiImage.sprite = _level2Sprite;
                // Warping effect on the camera/ camera zooming in or out.
                StartCoroutine(WarpEffect(55f, 0.25f,_effectTransitionSpeed));
                ChromaticAberration(1f);
                // Hearing whispering in the distance or other disturbing sounds. (for now I have only the whisper)
                _audioSource.clip = _sanity2Clip;
                _audioSource.Play();
                break;
            case SanityState.Level3:
                _uiImage.sprite = _level3Sprite;
                Debug.unityLogger.Log("You lost a half of your sanity. You heart is pounding and you feel your hands shake.");
                // Increase warping effect 
                StartCoroutine(WarpEffect(50f, 0.5f ,_effectTransitionSpeed));
                VignetteEffect(0.6f);
                // Play more disturbing sound effect
                _audioSource.clip = _sanity3Clip;
                _audioSource.Play();
                break;
            case SanityState.Level4:
                _uiImage.sprite = _level4Sprite;
                _audioSource.clip = _sanity3Clip;
                _audioSource.Play();
                break;
        }
    }
    
    /// <summary>
    /// Camera visual effects.
    /// </summary>
    /// <param name="targetFOV">Field of view it will lerp towards</param>
    /// <param name="targetLensDistortion">Lens distortion value it will lerp towards</param>
    /// <param name="duration">How long it takes to reach the target values</param>
    /// <returns></returns>
    public IEnumerator WarpEffect(float targetFOV, float targetLensDistortion, float duration)
    {
        float startFOV = _playerCamera.fieldOfView;
        float time = 0;

        while (time < duration)
        {
            _playerCamera.fieldOfView = Mathf.Lerp(startFOV, targetFOV, time / duration);
            _lenseDistortion.intensity.Override(Mathf.Lerp(_lenseDistortion.intensity.value, targetLensDistortion, time / duration));
            time += Time.deltaTime;
            yield return null;
        }
        _playerCamera.fieldOfView = targetFOV;
        _lenseDistortion.intensity.Override(targetLensDistortion);
    }
    
    public void VignetteEffect(float intensity)
    {
        _lenseDistortion.intensity.Override(intensity);
    }
    public void ChromaticAberration(float intensity)
    {
        _chromaticAberration.intensity.Override(intensity);
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
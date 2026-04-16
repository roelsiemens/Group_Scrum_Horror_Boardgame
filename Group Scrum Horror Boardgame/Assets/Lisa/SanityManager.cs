using UnityEngine;
using UnityEngine.UI;

public class SanityManager : MonoBehaviour
{
    // marking the private variables with _underscore
    private const int _maxSanity = 100;
    private const int _minSanity = 0;
    private float _currentSanity;
    public int _sanityMultiplier = 1;

    // Player reference
    private GameObject _playerGO;
    [SerializeField] private bool isHoldingTorch = false;

    private void Awake()
    {
        _currentSanity = _maxSanity;
        _playerGO = GameObject.FindGameObjectWithTag("Player");
        if (_playerGO == null)
        {
            Debug.Log("No player object found!");
        }
    }

    private void Update()
    {
        if(isHoldingTorch)
        {
            RestoreCurrentSanity(Time.deltaTime);
        }
        else
        {
            DrainCurrentSanity(Time.deltaTime);
        }
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
    public float DrainCurrentSanity(int drainAmmount){
        _currentSanity = _currentSanity < 0 ? 0 : _currentSanity - drainAmmount;
        return _currentSanity;
    }

    /// <summary>
    /// This method decreases the current sanity value over time. Lowest value is 0.
    /// </summary>
    /// <param name="deltaTime">the time value over which the value is lowered.</param>
    public void DrainCurrentSanity(float deltaTime){
        _currentSanity = Mathf.Clamp(_currentSanity - (Time.deltaTime * _sanityMultiplier), _minSanity, _maxSanity);
    }

    /// <summary>
    /// This method increases the current sanity value. Highest value is defined by _maxSanity.
    /// </summary>
    /// <param name="deltaTime">the time value over which the value is increased.</param>
    public void RestoreCurrentSanity(float deltaTime){
        _currentSanity = Mathf.Clamp(_currentSanity + (Time.deltaTime * _sanityMultiplier), _minSanity, _maxSanity);
    }
}

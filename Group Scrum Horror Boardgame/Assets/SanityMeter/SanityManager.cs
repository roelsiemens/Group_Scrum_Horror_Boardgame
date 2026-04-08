using UnityEngine;
using UnityEngine.UI;

public class SanityManager : MonoBehaviour
{
    // marking the private variables wuith _
    private const int _maxSanity = 100;
    private const int _minSanity = 0;
    private float _currentSanity;
    private int _sanityDrainSpeed = 1;

    // Testing stuff
    public bool decrease = true;

    private void Awake()
    {
        _currentSanity = _maxSanity;
    }

    private void Update()
    {
        // Testing stuff
        if(decrease)
        {
            DrainCurrentSanity(Time.deltaTime);
        }
        else
        {
            RestoreCurrentSanity(Time.deltaTime);
        }
    }

    // testing stuff
   // private void OnGUI()
    // {
        // GUI.Box(new Rect (350, 10, Screen.width / 2 / (_maxSanity / _currentSanity), 25), "Sanity" + _currentSanity + "/" + _maxSanity);
   // }

    /// <summary>
    /// This method returns the maximun sanity value.
    /// </summary>
    public float GetMaxSanity(){
        return _maxSanity;
    }

    /// <summary>
    /// This method returns the current sanity value.
    /// </summary>
    public float GetCurrentSanity(){
        return _currentSanity;
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
        _currentSanity = Mathf.Clamp(_currentSanity - (Time.deltaTime * (1 /_sanityDrainSpeed)), 0.0f, _maxSanity);
    }

    /// <summary>
    /// This method increases the current sanity value. Highest value is defined by _maxSanity.
    /// </summary>
    /// <param name="deltaTime">the time value over which the value is increased.</param>
    public void RestoreCurrentSanity(float deltaTime){
        _currentSanity = Mathf.Clamp(_currentSanity + (Time.deltaTime * (1 /_sanityDrainSpeed)), 0.0f, _maxSanity);
    }

}

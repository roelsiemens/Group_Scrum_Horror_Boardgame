using UnityEngine;

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
    private void OnGUI()
    {
        GUI.Box(new Rect (350, 10, Screen.width / 2 / (_maxSanity / _currentSanity), 25), "Sanity" + _currentSanity + "/" + _maxSanity);
    }

    public float GetCurrentSanity(){
        return _currentSanity;
    }

    public void DrainCurrentSanity(float deltaTime){
        _currentSanity = Mathf.Clamp(_currentSanity - (Time.deltaTime * (1 /_sanityDrainSpeed)), 0.0f, _maxSanity);
    }

    public void RestoreCurrentSanity(float deltaTime){
        _currentSanity = Mathf.Clamp(_currentSanity + (Time.deltaTime * (1 /_sanityDrainSpeed)), 0.0f, _maxSanity);
    }

}

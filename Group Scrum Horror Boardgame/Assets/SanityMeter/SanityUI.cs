using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SanityUI : MonoBehaviour
{
    [SerializeField] private SanityManager _sanityManager;
    [SerializeField] private Slider _slider;

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
        _slider.maxValue = _sanityManager.GetMaxSanity();

    }

    private void Update()
    {
        _slider.value = _sanityManager.GetCurrentSanity();
    }

}

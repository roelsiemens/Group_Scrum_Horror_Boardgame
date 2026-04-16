using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SanityUI : MonoBehaviour
{
    [SerializeField] private SanityManager _sanityManagerRef;
    [SerializeField] private Slider _slider;

    private void Awake()
    {
        _slider.maxValue = _sanityManagerRef.GetMaxSanity();
    }

    private void Update()
    {
        _slider.value = _sanityManagerRef.GetCurrentSanity();
    }

}

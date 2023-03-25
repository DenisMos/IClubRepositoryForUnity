using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu ("My components/Enemy/Level health slider")]
public class LevelHealth : MonoBehaviour
{
    [HideInInspector]
    public int levelHealth = 100;

    [Header ("Уровень здровья")]
    public Slider _mySlider;

    void Start()
    {
        
    }

    
    void Update()
    {
        _mySlider.value = levelHealth;
    }
}

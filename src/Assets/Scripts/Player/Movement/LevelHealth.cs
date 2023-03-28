using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu ("My components/Enemy/Level health slider")]
public class LevelHealth : MonoBehaviour
{
    [HideInInspector]
    public int levelHealth = 100;

    [Header ("Уровень здровья")]
    public Slider _mySlider;

    public void SetDamage(int damage)
    {
		levelHealth -= damage;
        UpdateControls();
	}

    private void UpdateControls()
    {
		_mySlider.value = levelHealth;
	}
}

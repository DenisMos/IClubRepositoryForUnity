using UnityEngine;

[AddComponentMenu("My components/Enemy/Damage")]
public class Damage : MonoBehaviour
{
	[Header("Урон")]
	[SerializeField]
	private int _damage = 10;

	private const string TAG_PLAYER = "Player";

	private void OnTriggerEnter(Collider myCollider)
	{
		if (myCollider.tag == TAG_PLAYER)
		{
			myCollider.GetComponent<LevelHealth>().SetDamage(_damage);
		}
	}
}

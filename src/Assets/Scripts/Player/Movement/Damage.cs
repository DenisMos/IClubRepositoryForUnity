using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu ("My components/Enemy/Damage")]
public class Damage : MonoBehaviour
{
    [Header("Урон")]
    public int damage = 10;

    void OnTriggerEnter (Collider myCollider)
    {
        if (myCollider.tag == "Player")
        {
            myCollider.GetComponent <LevelHealth> ().levelHealth -= (damage);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

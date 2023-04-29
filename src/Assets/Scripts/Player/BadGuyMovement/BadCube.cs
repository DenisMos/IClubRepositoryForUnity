using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadCube : MonoBehaviour
{
    public Transform Target;

    void Start()
    {
        
    }

    void Update()
    {
        if(Target == null)
        {
            if (FindObjectOfType<PlayerController>() == null)
                return;

            Target = FindObjectOfType<PlayerController>().gameObject.transform;
        }
        else
        {
            var vec = Target.transform.position - transform.position;

            transform.position += vec.normalized * Time.deltaTime * 5f;
        }
        
    }
}

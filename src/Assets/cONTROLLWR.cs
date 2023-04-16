using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class cONTROLLWR : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var data = GameObject.FindGameObjectsWithTag("UIAC");
        var result = data.FirstOrDefault();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

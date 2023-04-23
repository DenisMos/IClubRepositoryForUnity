using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyberSoldierAnimControl : MonoBehaviour
{
    public Animator Animator;

    // Start is called before the first frame update
   private void Start()
    {
        Animator = GetComponent<Animator>();
    }
    public readonly string Walk = "Walk";
    public readonly string Idle = "Idle";
    public bool Trysetwalk(string name, bool state)
    {
        try
        {
            Animator.SetBool(name, state);
            return true;
        }
        catch 
        {
            return false; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

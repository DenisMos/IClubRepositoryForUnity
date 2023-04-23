using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuyController : MonoBehaviour
{
    public Animator _animator;
    private void Start()
    {
        _animator = GetComponent <Animator>();
        
    }
    public readonly string Walk = "Walk";
    public readonly string Idle = "Idle";
    public readonly string upWeapon = "upWeapon";
    public readonly string walkwithWeapon = "walkwithWeapon";
    public readonly string downWeapon = "downWeapon";

    public bool trySetWalk(string name, bool state)
    {
        try
        {
            _animator.SetBool(name, state);
            return true;
        }
        catch
        {
            return false;
        }
    }
}

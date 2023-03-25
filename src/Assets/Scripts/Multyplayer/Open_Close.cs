using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open_Close : MonoBehaviour
{
    public GameObject _menu;
    public GameObject _inventory;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            _menu.SetActive(!_menu.activeSelf);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            _inventory.SetActive(!_inventory.activeSelf);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThermometerSingleton : MonoBehaviour
{
    private static ThermometerSingleton _instance;

    public static ThermometerSingleton Instance
    {
        get
        {
            //normaly you would instantiate a new instance if one did not exist
            //but since this requires inventory, and their is no way to tell which
            //will instantiate first im just gonna skip that step
            return _instance;
        }
    }

    void Start()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;

        //inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
        DontDestroyOnLoad(transform.parent.gameObject);

    }

    
}

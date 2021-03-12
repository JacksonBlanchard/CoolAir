using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public PlayerController player;
    public GameObject testCubePrefab;
    public GameObject testCapsulePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            player.AcquireItem(testCubePrefab);
        }
        if(Input.GetKeyDown(KeyCode.L))
        {
            player.AcquireItem(testCapsulePrefab);
        }
        if(Input.GetKeyDown(KeyCode.H))
        {
            player.RemoveItem(Item.ItemType.Wrench);
        }
    }
}

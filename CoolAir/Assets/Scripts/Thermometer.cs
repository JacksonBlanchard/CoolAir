using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Thermometer : MonoBehaviour
{
    private Text thermometerText;
    [SerializeField]
    private int temp;
    [SerializeField]
    private float time;
    private int count;


    void Start()
    {
        time = 0;
        count = 0;
        temp = 56;
        thermometerText = this.GetComponent<Text>();
        thermometerText.text = "" + temp;
    }

    void Update()
    {
        if(count >= 20 && temp >= 71)
        {
            // End the game

        }

        else
        {
            time += Time.deltaTime;

            if(time >= 15)
            {
                time = 0;
                count++;
                temp++;
                thermometerText.text = "" + temp;

            }

        }



    }
}

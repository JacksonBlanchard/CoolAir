using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Thermometer : MonoBehaviour
{
    private Text thermometerText;   // The display text for the thermometer
    [SerializeField]
    private int temp;               // The current temperature
    [SerializeField]
    private float time;             // The timer for waiting until the degree changes
    private int count;              // Only used if we want specific seconds rather than a specific temp
    private int seconds = 20;       // The amount of time until the degree go up by one


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
        if(temp >= 71 /*&& count >= 15*/)
        {
            // End the game
            SceneManager.LoadScene("LoseScene");

        }

        else
        {
            time += Time.deltaTime;

            if(time >= seconds)
            {
                time = 0;
                //count++;
                temp++;
                thermometerText.text = "" + temp;

            }

        }



    }
}

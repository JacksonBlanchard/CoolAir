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

    public Slider thermometer;
    private static Thermometer _instance;

    public static Thermometer Instance
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
        DontDestroyOnLoad(transform.parent.parent.gameObject);
        time = 0;
        count = 0;
        temp = 56;
        //thermometerText = this.GetComponent<Text>();
        //thermometerText.text = "" + temp;
        thermometer.maxValue = 300;
        thermometer.value = 0;
    }

    void Update()
    {
        if(thermometer.value == 300)
        {
            // End the game
            SceneManager.LoadScene("LoseScene");

        }

        else
        {
            time = Time.time;
            thermometer.value = time;

            //if (time >= seconds)
            //{
            //    time = 0;
            //    //count++;
            //    temp++;
            //    //thermometerText.text = "" + temp;

            //}

        }



    }
}

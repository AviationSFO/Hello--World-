using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    private float timer = 0.0f;
    public TextMeshProUGUI timerObject;
    public TextMeshProUGUI deathObject;
    // Start is called before the first frame update
    void Start()
    {
        timerObject.text = "Time: " + timer;
        Debug.Log("Started timer succesfully");
    }

    // Update is called once per frame
    void Update()
    {
        if(deathObject.text == "")
        {
            timer += Time.deltaTime;
            timerObject.text = "Time: " + timer.ToString("F0");
        }
    }
}

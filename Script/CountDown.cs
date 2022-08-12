using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CountDown : MonoBehaviour
{
    public float currentTime = 0f;
    public float StartingTime = 90f;
    public TMP_Text countdown;



    // Start is called before the first frame update
    void Start()
    {
        currentTime = StartingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdown.text = currentTime.ToString("0");
        if (currentTime <= 0)
        {
            currentTime = 0;
        }
    }
    
}

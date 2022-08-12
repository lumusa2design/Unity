using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player1Health : MonoBehaviour
{
    public int currentHealth;
    public int MaxHealth;
    public Slider mySlider;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = MaxHealth; 
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            currentHealth = 0;
        }
        mySlider.value = currentHealth;
    }
}

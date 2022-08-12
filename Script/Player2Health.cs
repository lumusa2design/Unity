using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player2Health : MonoBehaviour
{
    public int currentHealth2;
    public int MaxHealth2;
    public Slider mySlider2;
   
    // Start is called before the first frame update
    void Start()
    {
        currentHealth2 = MaxHealth2;
    }

    // Update is called once per frame
    void Update()
    {
       

        if (currentHealth2 <= 0)
        {
            currentHealth2 = 0;
        }
        mySlider2.value = currentHealth2;
    }

   
}

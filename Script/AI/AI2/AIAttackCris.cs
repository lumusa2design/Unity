using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAttackCris : MonoBehaviour
{
    public Animator myAnimator;
    public CountDown counterAttack;
    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("RandomAttack",1,2);
        InvokeRepeating("CountDownAttacks", 0, 1);
        //CountDownAttacks();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void RandomAttack()
    {
       int  myRandomNumber = Random.Range(0, 4);
        //Debug.Log(myRandomNumber);
        switch (myRandomNumber)
        {
            case 0:
                BasicAttack();
                break;
            case 1:
                BackAttack();
                break;
            case 2:
                BasicKick();
                break;
        }
    }
    public void BasicAttack()
    {
        myAnimator.SetTrigger("AtaqueBasico");
       
    }
    public void BackAttack()
    {
        myAnimator.SetTrigger("AtaqueRetroceso");
      
    }
    public void BasicKick()
    {
        myAnimator.SetTrigger("Patada");
       
    }
    public void SpecialAttack()
    {
        myAnimator.SetTrigger("Especial");
    }
    public void CountDownAttacks()
    {
        float t = Random.Range(0.5f, 5);
        float currentTime = t;
        currentTime -= 1 * Time.time;
        if (currentTime <= 0)
        {
            currentTime = 0;
            RandomAttack();
        }
            //Debug.Log(currentTime + "esto es current");
        
    }

}

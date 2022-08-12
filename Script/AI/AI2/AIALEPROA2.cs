using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIALEPROA2 : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator myAnimator;
    public CountDown counterAttack;
    void Start()
    {
        InvokeRepeating("CountDownAttacks", 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RandomAttack()
    {
        int myRandomNumber = Random.Range(0, 5);
        switch (myRandomNumber)
        {
            case 0:
                LeftAttack();
                    break;
            case 1:
                RightAttack();
                break;
            case 2:
                BendPunch();
                break;
            case 3:
                BendKick();
                break;
            case 4:
                Special();
                break;
        }
    }
    public void LeftAttack()
    {
        myAnimator.SetTrigger("LeftPunch");
    }
    public void RightAttack()
    {
        myAnimator.SetTrigger("RightPunch");
    }
    public void BendPunch()
    {
        myAnimator.SetTrigger("BendPunch");
    }
    public void BendKick()
    {
        myAnimator.SetTrigger("BendKick");
    }
    public void Special()
    {
        myAnimator.SetTrigger("Special");
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
        Debug.Log(currentTime + "esto es current");

    }
}

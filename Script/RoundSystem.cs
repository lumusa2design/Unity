using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundSystem : MonoBehaviour
{
    public Player1Health HealthBar1;
    public Player2Health HealthBar2;
    public CountDown CountDown;
    public int RoundsPlayer1;
    public int RoundsPlayer2;
    public Animator Player1Animator;
    public Animator Player2Animator;
    public float myInitialCounter = 3;
    public float myCounter;
    public Text myIndicator;
    //public GameObject myPrefabs;
    public GameObject pastilla1J1;
    public GameObject pastilla1J2;
    public GameObject pastilla2J1;
    public GameObject pastilla2J2;
    Animator currentAnimator;
    Animator TheOtherOne;
    public Canvas myWin, myLoose, myUI;
    int RoundsCall;
    bool MyAdd;
    GameManager instance;
    //public GameObject Player1Life;
    //public GameObject Player2Life;
    //public GameObject Miniball;
    //public GameObject Panel;
    // Start is called before the first frame update
    void Start()
    {
        RoundsPlayer1 = 0;
        RoundsPlayer2 = 0;
        myIndicator.gameObject.SetActive(false);
        myWin.enabled = false;
        myLoose.enabled = false;
        myUI.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (HealthBar1.currentHealth <= 0)
        {
            MyAdd = false;
            currentAnimator = Player1Animator;
            TheOtherOne = Player2Animator;
            RoundsPlayer2 += 1;
            switchJ2();
            HealthBar1.currentHealth = 100;
            HealthBar2.currentHealth2 = 100;
            //backcountdown();
            StartCoroutine("myOwnCounter");

            //MyCounterBack();
        }
        if (HealthBar2.currentHealth2 <= 0)
        {
            //backcountdown();
            MyAdd = true;
            currentAnimator = Player2Animator;
            TheOtherOne = Player1Animator;
            HealthBar1.currentHealth = 100;
            HealthBar2.currentHealth2 = 100;
            RoundsPlayer1 += 1;
            switchJ1();
            StartCoroutine("myOwnCounter");
            //MyCounterBack();
            //PointsToP1();
        }
        if (CountDown.currentTime <= 0)
        {
            if (HealthBar1.currentHealth < HealthBar2.currentHealth2)
            {
                MyAdd = false;
                //backcountdown();
                currentAnimator = Player1Animator;
                TheOtherOne = Player2Animator;
                HealthBar1.currentHealth = 100;
                HealthBar2.currentHealth2 = 100;
                RoundsPlayer2 += 1;
                switchJ2();
                StartCoroutine("myOwnCounter");
                //MyCounterBack();
            }
            if (HealthBar2.currentHealth2 < HealthBar1.currentHealth)
            {
                MyAdd = true;
                //backcountdown();
                currentAnimator = Player2Animator;
                TheOtherOne = Player1Animator;
                HealthBar1.currentHealth = 100;
                HealthBar2.currentHealth2 = 100;
                RoundsPlayer1 += 1;
                switchJ1();
                StartCoroutine("myOwnCounter");
                //MyCounterBack();
            }
            if (HealthBar1.currentHealth == HealthBar2.currentHealth2)
            {
                CountDown.currentTime += 30;
            }
        }
    }

    /*public void PointsToP1()
    {
        Instantiate(Miniball, Panel.transform, Panel.transform.parent);
    }*/
    /*public void MyCounterBack()
    {
        Destroy(myPrefabs);
        myCounter = 3;
        myCounter -= 1 * Time.time;
        if(myCounter <= 0)
        {
            myCounter = 0;
        }
            Debug.Log(myCounter);
        if (myCounter == 0)
        {
       GameObject MyTry =  Instantiate(myPrefabs);
            MyTry.transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = true;
            MyTry.transform.GetChild(0).GetChild(0).GetComponent<CircleCollider2D>().enabled = false;
            MyTry.transform.GetChild(0).GetComponent<Player2Damage>().enabled = true;
            MyTry.transform.GetChild(0).GetComponent<AI_WalkCris>().enabled = true;
            MyTry.transform.GetChild(0).GetComponent<AIAttackCris>().enabled = true;
            MyTry.transform.GetChild(1).GetComponent<BoxCollider2D>().enabled = true;
            MyTry.transform.GetChild(1).GetComponent<PlayerMovement>().enabled = true;
            MyTry.transform.GetChild(1).GetChild(0).GetComponent<CircleCollider2D>().enabled = false;
            MyTry.transform.GetChild(1).GetChild(0).GetComponent<Animator>().enabled = true;
        }
    }*/
    private void switchJ1()
	{
        switch (RoundsPlayer1)
        {
            case 0:
                break;
            case 1:
                pastilla1J2.SetActive(false);
                break;
            case 2:
                pastilla2J2.SetActive(false);
                StartCoroutine("myPastillas");
                myWin.enabled = true;
                myUI.enabled = false;
                Time.timeScale = 0;
                break;
        }
	}

    private void switchJ2()
    {
        switch (RoundsPlayer2)
        {
            case 0:
                break;
            case 1:
                pastilla1J1.SetActive(false);
                break;
            case 2:
                pastilla2J1.SetActive(false);
                StartCoroutine("myPastillas");
                myLoose.enabled = true;
                myUI.enabled = false;
                Time.timeScale = 0;
                break;
        }
    }


    private IEnumerator myOwnCounter()
    {
        
        currentAnimator.SetTrigger("Loose");
        TheOtherOne.SetTrigger("Victory");
        Time.timeScale = 0.18f;
        yield return new WaitForSecondsRealtime(3);
       
        CountDown.currentTime = CountDown.StartingTime;

        Time.timeScale = 1;
    }

    private IEnumerator myPastillas()
    {
        yield return new WaitForSecondsRealtime(2);

    }
   /* public void backcountdown()
    {
        myIndicator.gameObject.SetActive(true);
        myCounter = myInitialCounter;
        myCounter = myCounter - 1 * Time.deltaTime;
        if(myCounter > 0)
        {
        myIndicator.text = myCounter.ToString("0");
        }
        if (myCounter <= 0 && myCounter > -2)
        {
            myIndicator.text = "Fight";
        }
        if(myCounter <= -2)
        {
            myIndicator.gameObject.SetActive(false);
        }
    }*/

}

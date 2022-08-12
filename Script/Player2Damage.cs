using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Damage : MonoBehaviour
{
    public int Speed;
    public bool bloqueo2 = false;
    public Player1Health HealthBar;
    public Player2Health myHealth;
    public Animator enemyAnimator;
    public Animator aleAnimator;
    
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (!bloqueo2)
        {
            Speed = 1;
        }
        else
        {
            Speed = 0;
        }
    }

    public void OnTriggerEnter2D(Collider2D CircleCollider2D)
    {
        //Debug.Log("Detecto contacto");
        if (CircleCollider2D.tag.Equals("Enemy2"))
        {
            //Debug.Log("Detecto contacto con enemigo ");

            if (!CircleCollider2D.gameObject.GetComponent<AdaySystemMovement>())
            {
                //Debug.Log("Detecto contacto con enemigo sin bloqueo");
                //Debug.Log("Alex golpea. Cris no bloquea");
                HealthBar.currentHealth -= 10;
                aleAnimator.SetTrigger("HighHit");
                CircleCollider2D.gameObject.GetComponent<Rigidbody2D>();//.AddForce(Vector2.left * 0.5F, ForceMode2D.Impulse);
            }
           

        }

    }
}

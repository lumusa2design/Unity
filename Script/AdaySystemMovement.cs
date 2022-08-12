using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdaySystemMovement : MonoBehaviour
{
    public Animator AdayAnimator;
    public float Speed2;
    public Player1Health HealthBar;
    public Player2Health EnemyHealth2;
    public Player2Damage enemyDamage;
    public Rigidbody2D myRb;
    public Animator crisIAanimator;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        //Sistema de movimiento horizontal de Aday
        if (Input.GetKey(KeyCode.D))
        {
            AdayAnimator.SetBool("AdayWalk", true);
            this.transform.Translate(Vector2.right * Speed2 * Time.deltaTime/4);

        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            AdayAnimator.SetBool("AdayWalk", false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            AdayAnimator.SetBool("AdayWalk", true);
            this.transform.Translate(Vector2.left * Speed2 * Time.deltaTime/4);

        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            AdayAnimator.SetBool("AdayWalk", false);
        }
        if (Input.GetMouseButtonDown(0))
        {
            AdayPunch();
        }
       
        if (Input.GetMouseButtonDown(1))
        {
            AdayKick();
        }

        void AdayPunch()
        {
            AdayAnimator.SetTrigger("AdayPunch");

        }
        
        void AdayKick()
        {
            AdayAnimator.SetTrigger("AdayKick");
        }


    }
    public void OnTriggerEnter2D(Collider2D CircleCollider2D)
    {
        Debug.Log("Detecto contacto");
        if (CircleCollider2D.tag.Equals("Enemy"))
        {
            Debug.Log("Detecto contacto con enemigo ");

            if (CircleCollider2D.gameObject.GetComponent<Player2Damage>())
            {
                Debug.Log("Detecto contacto con enemigo sin bloqueo");
                Debug.Log("Alex golpea. Cris no bloquea");
                EnemyHealth2.currentHealth2 -= 20;
                crisIAanimator.SetTrigger("HitCris");
                CircleCollider2D.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 5, ForceMode2D.Impulse);
            }
            /*if (CircleCollider2D.gameObject.GetComponent<Player2Damage>().bloqueo2)
            {
                Debug.Log("Detecto contacto con enemigo con bloqueo");

                Debug.Log("Alex golpea. cris Bloquea");
                EnemyHealth2.currentHealth2 -= 5;
                CircleCollider2D.gameObject.transform.GetChild(0).GetComponent<Animator>().SetTrigger("HitCris");
            }^*/

        }

    }
}

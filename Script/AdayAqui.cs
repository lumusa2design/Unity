using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdayAqui : MonoBehaviour
{
    public Animator myAnimator;
    public int Speed;
    public Rigidbody2D myRB;
    public float force;
    public bool bloqueo = false;
    public Player1Health HealthBar;
    public Player2Health EnemyHealth;
    public Player2Damage enemyDamage;
    public Animator crisAnimator;
    int maxJump = 1;
    int currentJump;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            myAnimator.SetBool("AdayWalk", true);
            this.transform.Translate(Vector2.right * Speed * Time.deltaTime / 4);

        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            myAnimator.SetBool("AdayWalk", false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            myAnimator.SetBool("AdayWalk", true);
            this.transform.Translate(Vector2.left * Speed * Time.deltaTime / 4);

        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            myAnimator.SetBool("AdayWalk", false);
        }
        if (Input.GetMouseButtonDown(0))
        {
            AdayPunch();
        }

        if (Input.GetMouseButtonDown(1))
        {
            myAnimator.SetTrigger("AdayKick");
        }

        void AdayPunch()
        {
            myAnimator.SetTrigger("AdayPunch");

        }
    }

    public void OnTriggerEnter2D(Collider2D CircleCollider2D)
    {
        Debug.Log("Detecto contacto");
        if (CircleCollider2D.tag.Equals("Enemy"))
        {
            Debug.Log("Detecto contacto con enemigo ");

            if (!CircleCollider2D.gameObject.GetComponent<Player2Damage>().bloqueo2)
            {
                Debug.Log("Detecto contacto con enemigo sin bloqueo");
                Debug.Log("Alex golpea. Cris no bloquea");
                EnemyHealth.currentHealth2 -= 10;
                crisAnimator.SetTrigger("HitCris");
                CircleCollider2D.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 5, ForceMode2D.Impulse);
            }
            if (CircleCollider2D.gameObject.GetComponent<Player2Damage>().bloqueo2)
            {
                Debug.Log("Detecto contacto con enemigo con bloqueo");

                Debug.Log("Alex golpea. cris Bloquea");
                EnemyHealth.currentHealth2 -= 5;
                CircleCollider2D.gameObject.transform.GetChild(0).GetComponent<Animator>().SetTrigger("HitCris");
            }

        }

    }
}

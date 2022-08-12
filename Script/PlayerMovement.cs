using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
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
    public BoxCollider2D myCollider;
    private Vector2 originalSizeCollider;
    private Vector2 originalSizeOffset;
    // bool NumberPunch;
    // Start is called before the first frame update
    void Start()
    {
        currentJump = 0;
        myCollider = this.GetComponent<BoxCollider2D>();
        originalSizeCollider = myCollider.size;
        originalSizeOffset = myCollider.offset;
        // NumberPunch = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Con la variable bloqueo controlo si se puede mover o no, según su valor verdadero o falso.
        if (!bloqueo)
        {
            Speed = 1;
        }
        else
        {
            Speed = 0;
        }


        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.S))
        {
            myAnimator.SetBool("Walk", true);
            this.transform.Translate(Vector2.right * Speed * Time.deltaTime);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            myAnimator.SetBool("Walk", false);
        }
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S))
        {
            myAnimator.SetBool("Walk", true);
            this.transform.Translate(Vector2.left * Speed * Time.deltaTime);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            myAnimator.SetBool("Walk", false);
        }

        if (Input.GetMouseButtonDown(0))
        {
            myAnimator.SetTrigger("LeftPunch");
        }
        if (Input.GetMouseButtonDown(1))
        {
            myAnimator.SetTrigger("Kick");
        }
        if (Input.GetKey(KeyCode.S))
        {
            ReduceSizeCollider();
            myAnimator.SetBool("bend", true);
            if (Input.GetMouseButtonDown(0))
            {
                myAnimator.SetTrigger("bendPunch");
            }
            if (Input.GetMouseButtonDown(1))
            {
                myAnimator.SetTrigger("BendKick");
            }
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            myAnimator.SetBool("bend", false);
            ReturnSizeCollider();
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            myAnimator.SetBool("Block", true);
            //Activo la variable bloqueo para que cuando se ejecute su animación correspondiente no se pueda mover.
            bloqueo = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            myAnimator.SetBool("Block", false);
            //Dessctivo la variable bloqueo para que cuando se ejecute su animación correspondiente no se pueda mover.
            bloqueo = false;
        }
        if (Input.GetKeyDown(KeyCode.Space)&& currentJump ==0)
        {
            this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * force, ForceMode2D.Impulse);
            myAnimator.SetTrigger("Jump");
            currentJump += 1;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            myAnimator.SetTrigger("Special");
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
                CircleCollider2D.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right  * 5, ForceMode2D.Impulse);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            currentJump = 0;
        }
    }
    public void ReduceSizeCollider()
    {
        myCollider.size = new Vector2(0.9268917f, 1.183462f);
        myCollider.offset = new Vector2(0.43f, 1.715305f);
    }
    public void ReturnSizeCollider()
    {
        myCollider.size = originalSizeCollider;
        myCollider.offset = originalSizeOffset;
    }









}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PJ_Cris : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator CrisAnimator;
    public float Speed;
    public float force;
    public Player1Health HealthBar;
    public Player2Health EnemyHealth;
    public Player2Damage enemyDamage;
    public Rigidbody2D myRb;
    public Animator EnemyAnimator;
    int maxJump = 1;
    int currentJump;
    public bool bloqueo = false;
    private BoxCollider2D myCollider;
    private Vector2 originalSizeCollider;
    private Vector2 sizeColliderDown = new Vector2(1.464031f, 2.85f);
    private Vector2 sizeColliderOffset = new Vector2(0.6880564f, 1.213736f);
    void Start()
    {
        currentJump = 0;
        myCollider = GetComponent<BoxCollider2D>();
        originalSizeCollider = myCollider.size;
    }

    // Update is called once per frame
    void Update()
    {
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
            CrisAnimator.SetBool("CaminarCris", true);
            this.transform.Translate(Vector2.right * Speed * Time.deltaTime);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            CrisAnimator.SetBool("CaminarCris", false);
        }
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S))
        {
            CrisAnimator.SetBool("CaminarCris", true);
            this.transform.Translate(Vector2.left * Speed * Time.deltaTime);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            CrisAnimator.SetBool("CaminarCris", false);
        }

        if (Input.GetMouseButtonDown(0))
        {
            CrisAnimator.SetTrigger("AtaqueBasico");
        }
        if (Input.GetMouseButtonDown(1))
        {
            CrisAnimator.SetTrigger("Patada");
        }
        if (Input.GetKey(KeyCode.S))
        {
            CrisAnimator.SetBool("Agacharse", true);
            //ReduceSizeCollider();
            if (Input.GetMouseButtonDown(0))
            {
                CrisAnimator.SetTrigger("GolpeAgachadoCris");
            }
            if (Input.GetMouseButtonDown(1))
            {
                CrisAnimator.SetTrigger("PatadaAgachada");
            }
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            CrisAnimator.SetBool("Agacharse", false);
            ReturnSizeCollider();
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            
            //Activo la variable bloqueo para que cuando se ejecute su animación correspondiente no se pueda mover.
            bloqueo = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            
            //Dessctivo la variable bloqueo para que cuando se ejecute su animación correspondiente no se pueda mover.
            bloqueo = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && currentJump == 0)
        {
            this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * force, ForceMode2D.Impulse);
            CrisAnimator.SetTrigger("Salto");
            currentJump += 1;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            CrisAnimator.SetTrigger("Especial");
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
                EnemyAnimator.SetTrigger("MediumHit");
                CircleCollider2D.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 5, ForceMode2D.Impulse);
            }
            if (CircleCollider2D.gameObject.GetComponent<Player2Damage>().bloqueo2)
            {
                Debug.Log("Detecto contacto con enemigo con bloqueo");

                Debug.Log("Alex golpea. cris Bloquea");
                EnemyHealth.currentHealth2 -= 5;
                CircleCollider2D.gameObject.transform.GetChild(0).GetComponent<Animator>().SetTrigger("MediumHit");
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
        myCollider.size = sizeColliderDown;
        //myCollider.offset = sizeColliderOffset;
    }
    public void ReturnSizeCollider()
    {
        myCollider.size = originalSizeCollider;
    }
}


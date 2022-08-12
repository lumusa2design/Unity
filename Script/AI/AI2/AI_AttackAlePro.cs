using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AI_AttackAlePro : MonoBehaviour
{
    [SerializeField]
    GameObject MyTarget;
    public Animator myAnimator;
    public float mySpeed = 2.5f;
    public float Distance;
    public AIAttackCris MyAttack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      Distance = Mathf.Abs(MyTarget.transform.position.x - this.transform.position.x);
        if(Distance > 3){

        myAnimator.SetBool("Walk", true);
        //myAgent.destination= MyTarget.transform.position;
        if (MyTarget.transform.position.x< this.gameObject.transform.position.x)
        {
        this.gameObject.transform.Translate(Vector2.left* mySpeed* Time.deltaTime);
    MyTarget.transform.localScale = new Vector3(1, 1, 1);
            this.transform.localScale = new Vector3(-1, 1, 1);

}
        else
{
    MyTarget.transform.localScale = new Vector3(-1, 1, 1);
    this.transform.localScale = new Vector3(1, 1, 1);
    this.gameObject.transform.Translate(Vector2.left * -mySpeed * Time.deltaTime);

}
        }
       if (Distance <= 3f)
{
    myAnimator.SetBool("Walk", false);

}

    }
}

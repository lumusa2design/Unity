using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopCamera : MonoBehaviour
{
    public Transform Player1;
    public Transform Player2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Player1.position.x < Player2.position.x)
        {
            Player1.transform.localScale = new Vector3(1, 1, 1);
            Player2.transform.localScale = new Vector3(-1, 1, 1);
            Player2.GetComponent<AI_WalkCris>().mySpeed = -1 * Player2.GetComponent<AI_WalkCris>().mySpeed;
        }
        else
        {
            Player1.transform.localScale = new Vector3(-1, 1, 1);
            Player2.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}

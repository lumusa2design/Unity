using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualObjetiveCamera2 : MonoBehaviour
{
    public Transform PJ1; //Declaro PJ1
    public Transform PJ2;//Declaro PJ2
    public Transform HighTry;
    public float Myvalue;
    public float minDistance = 3.140066f;//Declaro la distancia minima que puede enfocar como x La cámara
    public float DistanceTarget;//Declaro la variable que va a calcular la distancia entre PJ1 y PJ2
    public float centerCamera; //Esto me va a permitir calcular la distancia que va a tener de promedio en proporcion cámara/Jugador
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DistanceTarget = Mathf.Abs(PJ1.position.x - PJ2.position.x);
        centerCamera = (PJ1.position.x + PJ2.position.x) / 2;
        Myvalue = PJ1.position.y - HighTry.position.y;
        transform.position = new Vector3(
           centerCamera, 2.06F, -30);
        //if(DistanceTarget)
    }
}

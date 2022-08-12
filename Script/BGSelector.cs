using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGSelector : MonoBehaviour
{
    public int CurrentSelection;
    public int TotalBGs;
    public GameObject myParent;
    public Vector3 CurrentAngle;
    public Vector3 TargetRot;
    public Vector3 CurrentAngleChild1;
    public Vector3 TargetRotChild;
    private int index;
    public GameObject[] childs;
    public Vector3[] positionsChilds;

    private ChoosePlayer Choose;


    void Start()
    {
        index = PlayerPrefs.GetInt("Bgrotation");
        CurrentSelection = 2;

        for (int i = 0; i < 3; i++)
        {
            positionsChilds[i] = childs[i].GetComponent<RectTransform>().localPosition;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && CurrentSelection < TotalBGs)
        {
            RotateBG_Btn_Right();

        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && CurrentSelection > 1)
        {
            RotateBG_Btn_Left();

        }

        //movimiento del padre
        CurrentAngle = new Vector3(0, Mathf.LerpAngle(CurrentAngle.y, TargetRot.y, 0.0005f + Time.deltaTime), 0);
        transform.eulerAngles = CurrentAngle;

        //movimiento de los hijos
        CurrentAngleChild1 = new Vector3(0, Mathf.LerpAngle(CurrentAngleChild1.y, TargetRotChild.y, 0.0005f + Time.deltaTime), 0);
        childs[0].transform.eulerAngles = CurrentAngleChild1;
        childs[1].transform.eulerAngles = CurrentAngleChild1;
        childs[2].transform.eulerAngles = CurrentAngleChild1;

        PlayerPrefs.SetInt("Bgrotation", index);
    }

    public void RotateBG_Btn_Left()
    {
        CurrentAngle = transform.eulerAngles;
        TargetRot = TargetRot - new Vector3(0, 90, 0);

        CurrentAngleChild1 = transform.eulerAngles;
        TargetRotChild = TargetRotChild + new Vector3(0, 0, 0);

        CurrentSelection--;

        MoveBG();
    }

    public void RotateBG_Btn_Right()
    {
        CurrentAngle = transform.eulerAngles;
        TargetRot = TargetRot + new Vector3(0, 90, 0);

        CurrentAngleChild1 = transform.eulerAngles;
        TargetRotChild = TargetRotChild - new Vector3(0, 0, 0);
        CurrentSelection++;

        MoveBG();
    }

    private void MoveBG()
    {
        switch (CurrentSelection)
        {
            case 1:
                RotateBG(0);
                break;
            case 2:
                RotateBG(0); RotateBG(1); RotateBG(2);
                break;
            case 3:
                RotateBG(1);
                break;

        }
    }

    private void RotateBG(int index)
    {
        childs[index].gameObject.SetActive(false);
        childs[index].transform.parent = null;
        childs[index].transform.parent = myParent.transform;
        childs[index].GetComponent<RectTransform>().localPosition = positionsChilds[index];
        childs[index].gameObject.SetActive(true);
    }

    public void LoadScenes(string NameScene)
    {
        Choose.myCharacterSelected();

    }
}

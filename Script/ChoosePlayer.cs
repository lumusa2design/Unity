using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoosePlayer : MonoBehaviour
{
    private GameObject[] ChPlayer;
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        index = PlayerPrefs.GetInt("Bgrotation, PRotation");
        ChPlayer = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
            ChPlayer[i] = transform.GetChild(i).gameObject;

        foreach (GameObject objx in ChPlayer)
            objx.SetActive(false);

        if (ChPlayer[index])
            ChPlayer[index].SetActive(true);
    }

    public void BtnLeft1()
    {
        ChPlayer[index].SetActive(false);
        index--;
        if (index < 0)
            index = ChPlayer.Length - 1;
        ChPlayer[index].SetActive(true);
    }

    public void BtnRight1()
    {
        ChPlayer[index].SetActive(false);
        index++;
        if (index == ChPlayer.Length)
            index = 0;
        ChPlayer[index].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("Bgrotation, PRotation", index);
    }

    public void LoadScenes(string NameScene)
    {
        myCharacterSelected();
    }
    public void myCharacterSelected()
    {
        if (index == 0)
        {
            SceneManager.LoadScene("Ducha");
        }
        if (index == 1)
        {
            SceneManager.LoadScene("CrisAle");
        }
        if (index == 2)
        {
            SceneManager.LoadScene("PSselector");
        }
        if (index == 3)
        {
            SceneManager.LoadScene("AdayCris");
        }
        if (index == 4)
        {
            SceneManager.LoadScene("PSselector");
        }
        if (index == 5)
        {
            SceneManager.LoadScene("PSselector");
        }
    }
}

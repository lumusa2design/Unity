using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseScenarie : MonoBehaviour
{
    private GameObject[] ChScenarie;
    private int index;

    private ChoosePlayer player;

    // Start is called before the first frame update
    void Start()
    {
        index = PlayerPrefs.GetInt("Bgrotation, PRotation");
        ChScenarie = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
            ChScenarie[i] = transform.GetChild(i).gameObject;

        foreach (GameObject objx in ChScenarie)
            objx.SetActive(false);

        if (ChScenarie[index])
            ChScenarie[index].SetActive(true);
    }

    public void BtnLeft()
    {
        ChScenarie[index].SetActive(false);
        index--;
        if (index < 0)
            index = ChScenarie.Length - 1;
        ChScenarie[index].SetActive(true);
    }

    public void BtnRight()
    {
        ChScenarie[index].SetActive(false);
        index++;
        if (index == ChScenarie.Length)
            index = 0;
        ChScenarie[index].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("Bgrotation, PRotation", index);
        GameManager.instance.MyMusicType = index;
    }

    public void LoadScenes(string NameScene)
    {
        player.myCharacterSelected();
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static AudioClip[] audioeffects;
    public static GameManager instance;
    [SerializeField]
    int Player1RoundsWin = 0;
    [SerializeField]
    //int Player2RoundsWin = 0;
    public Camera myCamera;
    public AudioSource MyAudio;
    public AudioClip[] myMusic;
    public int MyMusicType;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MyAudio.clip =myMusic[MyMusicType];
        MyAudio.Play();
    }

    public void Salir()
    {
        Application.Quit();
    }
}

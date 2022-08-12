using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class SceneManagment : MonoBehaviour
{
    public GameObject ScreenCharge;
    public Slider Slider;

    public void LoadScenes(int NumberScene)
    {
        StartCoroutine(MakeTheLoad(NumberScene));
    }

    IEnumerator MakeTheLoad(int level)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(level);

        ScreenCharge.SetActive(true);

        while (!operation.isDone)
        {
            float Progress = Mathf.Clamp01(operation.progress / .9f);

            Slider.value = Progress;

            yield return null;
        }
    }
}
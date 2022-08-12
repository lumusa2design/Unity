using UnityEngine.SceneManagement;
using UnityEngine;

public static class LevelLoader
{
    public static string nextLevel;
    public static int nextLeveldos;

    public static void LoadLevel(string name)
    {
        nextLevel = name;

        SceneManager.LoadScene("Loading");
    }

    public static void LoadLevelDOS(int name)
    {
        nextLeveldos = name;

        SceneManager.LoadScene("Loading");
    }
}

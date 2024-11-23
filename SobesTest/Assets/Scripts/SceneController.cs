using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static void Restart()
    {
        int currentSceneID = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneID);
    }

    public static void NextLevel()
    {
        int currentSceneID = SceneManager.GetActiveScene().buildIndex;
        currentSceneID++;
        SceneManager.LoadScene(currentSceneID);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class nextlevel : MonoBehaviour
{
    public int sceneNumber; // Change this to the scene number you want to load.

    public void SceneLoad()
    {
        if (sceneNumber >= 0 && sceneNumber < SceneManager.sceneCountInBuildSettings)
        {
            UnlockNewLevel();
            SceneManager.LoadScene(sceneNumber);
        }
        else
        {
            Debug.LogError("Invalid scene number to load.");
        }
    }

    void UnlockNewLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        if (currentSceneIndex >= unlockedLevel - 1)
        {
            PlayerPrefs.SetInt("UnlockedLevel", unlockedLevel + 1);
            PlayerPrefs.Save();
        }
    }

      
}


using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public int sceneNumber = 1; // Default scene number, change this in the Inspector.

    public void SwitchScene()
    {
        string sceneName = "Scene" + sceneNumber;
        SceneManager.LoadScene(sceneName);
    }
}

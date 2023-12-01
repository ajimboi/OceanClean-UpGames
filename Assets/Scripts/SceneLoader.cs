using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public int sceneNumber ; // Change this to the scene number you want to load.

    public void Awake()
    {
        
    }
    public void SceneLoad()
    {
        int sceneName = sceneNumber;
        SceneManager.LoadScene(sceneName);
    }
}

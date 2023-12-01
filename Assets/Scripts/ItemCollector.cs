using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ItemCollector : MonoBehaviour
{
    private int collectedCount;
    [SerializeField] public int sceneNumber ;
    private int totalCollectibles;
    private bool canFinishLevel = false; // Add a flag to track if the level can be finished.

    [SerializeField] Text collectibleText;
    [SerializeField] GameObject finishPoint; // Reference to the Finish Point GameObject.

    private void Start()
    {
        totalCollectibles = GameObject.FindGameObjectsWithTag("Collectible").Length;
        UpdateUI();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            collectedCount++;
            Destroy(other.gameObject);
            UpdateUI();

            // Check if all collectibles have been collected.
            if (collectedCount == totalCollectibles)
            {
                canFinishLevel = true;
            }
        }
        else if (other.gameObject == finishPoint && canFinishLevel)
        {
            // Player has reached the finish point and can finish the level.
            FinishLevel();
        }
    }

    private void UpdateUI()
    {
        collectibleText.text = "Trash Remaining: " + (totalCollectibles - collectedCount);
    }

    private void FinishLevel()
    {
        int sceneName = sceneNumber;
        SceneManager.LoadScene(sceneName);
    }
}

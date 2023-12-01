using UnityEngine;
using UnityEngine.UI;

public class Collectible : MonoBehaviour
{
    public Text remainingText;
    private int collectedCount = 0;
    private int totalCollectibles;

    private void Start()
    {
        totalCollectibles = GameObject.FindGameObjectsWithTag("Collectible").Length;
        UpdateUI();
    }

    private void OnTriggerEnter(Collider other)
{
    Debug.Log("Trigger entered!");
    if (other.CompareTag("Player"))
    {
        Debug.Log("Player collided with collectible!");
        collectedCount++;
        UpdateUI();
        gameObject.SetActive(false); // Disable the collectible object when collected.
    }
}

    private void UpdateUI()
    {
        remainingText.text = "Collectibles Remaining: " + (totalCollectibles - collectedCount);
    }
}

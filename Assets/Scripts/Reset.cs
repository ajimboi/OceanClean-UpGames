using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    public int levelToReset = 2;

    public void Resetayam()
    {
        PlayerPrefs.SetInt("UnlockedLevel", levelToReset - 1);
        PlayerPrefs.Save();
    }
}

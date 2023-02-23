using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Levels : MonoBehaviour
{

    public void LoadLevelsMenu()
    {
        SceneManager.LoadScene("LevelsMenu");
    }
}
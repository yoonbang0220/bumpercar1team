using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMover : MonoBehaviour
{
    public void OnButtonClicked()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
}

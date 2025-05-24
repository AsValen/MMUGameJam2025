using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainButt : MonoBehaviour
{
    public void OnButtonClick()
    {
        SceneManager.LoadScene("GameScene");
    }
}

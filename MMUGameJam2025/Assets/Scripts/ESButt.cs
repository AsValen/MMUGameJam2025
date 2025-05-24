using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ESButt : MonoBehaviour
{
    public AudioSource exitSceneBG;
    public AudioSource endFlightButt;
    public AudioSource rewindButt;

    void Start()
    {
        Debug.Log("Music is playing~");

        exitSceneBG.Play();
        StartCoroutine(PlayBGMusicAfterDelay(2f)); // Delay of 2 seconds
    }

    private IEnumerator PlayBGMusicAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Debug.Log("Music is playing~");
        exitSceneBG.Play();
    }

    public void OnEndFlightClick()
    {
        Debug.Log("End flight button is clicked.");
        endFlightButt.Play();
        SceneManager.LoadScene("MainMenu");
    }

    public void OnRewindClick()
    {
        Debug.Log("Rewind button is clicked.");
        rewindButt.Play();
        SceneManager.LoadScene("GameScene");
    }
}

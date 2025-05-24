using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainButt : MonoBehaviour
{
    public AudioSource mainMenuBG;
    public AudioSource mainMenuButt;
    public float fadeDuration = 1.5f;  // Duration of fade out in seconds

    void Start()
    {
        Debug.Log("Music is playing~");
        mainMenuBG.Play();
    }

    public void OnButtonClick()
    {
        SceneManager.LoadScene("GameScene");
        Debug.Log("Button is clicked.");
        mainMenuButt.Play();
        StartCoroutine(FadeOut(mainMenuBG, fadeDuration));
    }

    private IEnumerator FadeOut(AudioSource audioSource, float duration)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / duration;
            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume; // Reset volume for next play if needed
    }
}

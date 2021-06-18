using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    // Start is called before the first frame update
    public float fadeDuration = 2f;
    public float displayImageDuration = 2f;
    public GameObject player;
    public CanvasGroup exitBackgoundImageCanvasGroup;
    public AudioSource exitAudio;
    public CanvasGroup caughtBackGroundImageCanvasGroup;
    public AudioSource caughtAudio;

    bool m_IsPlayerExit;
    bool m_IsPlayerCaught;
    float m_Timer;
    bool m_hasAudioPlayed;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            m_IsPlayerExit = true;
        }
    }

    public void CaughtPlayer()
    {
        m_IsPlayerCaught = true;
    }
    private void Update()
    {
        if (m_IsPlayerExit)
        {
            EndLevel(exitBackgoundImageCanvasGroup, false, exitAudio);
        }
        else if (m_IsPlayerCaught)
        {
            EndLevel(caughtBackGroundImageCanvasGroup, true, caughtAudio);
        }
    }

    void EndLevel(CanvasGroup imageCanvasGroup, bool doStart, AudioSource audioSource)
    {
        if (!m_hasAudioPlayed)
        {
            audioSource.Play();
            m_hasAudioPlayed = true;
        }

        m_Timer += Time.deltaTime;
        imageCanvasGroup.alpha = m_Timer / fadeDuration;

        if(m_Timer > fadeDuration + displayImageDuration)
        {
            if (doStart)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                Application.Quit();
            }
        }
    }

}

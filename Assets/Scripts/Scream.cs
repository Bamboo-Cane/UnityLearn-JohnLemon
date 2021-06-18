using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scream : MonoBehaviour
{
    public Button scream;

    public AudioSource audioSource;

    // Start is called before the first frame update

    // Update is called once per frame
    void FixedUpdate()
    {
        scream.onClick.AddListener(Screaming);
    }

    public void Screaming()
    {
        audioSource.Play();
    }
}

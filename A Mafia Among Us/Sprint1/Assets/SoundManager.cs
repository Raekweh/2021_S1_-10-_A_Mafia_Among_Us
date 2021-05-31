using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip reportSound;
    static AudioSource audioSrc;


    // Start is called before the first frame update
    void Start()
    {
        reportSound = Resources.Load<AudioClip>("ReportSound");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "ReportSound":
                audioSrc.PlayOneShot (reportSound);
                break;
        }
    }
}
  
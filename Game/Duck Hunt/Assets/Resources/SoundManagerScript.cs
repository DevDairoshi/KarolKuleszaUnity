using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip StepSound, ShootSound, HitSound, AmbienceSounds;
    public static AudioSource AudioSrc;

    // Start is called before the first frame update
    void Start()
    {
        StepSound = Resources.Load<AudioClip>("step");
        ShootSound = Resources.Load<AudioClip>("shoot");
        HitSound = Resources.Load<AudioClip>("hit");
        AmbienceSounds = Resources.Load<AudioClip>("ambience");

        AudioSrc = GetComponent<AudioSource>();
        AudioSrc.rolloffMode = AudioRolloffMode.Linear;
        AudioSrc.maxDistance = 5.0f;
        AudioSrc.minDistance = 4.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void Play(string clip)
    {
        switch (clip)
        {
            case "step":
            {
                    AudioSrc.PlayOneShot(StepSound);
                    break;
            }
            case "shoot":
            {
                AudioSrc.PlayOneShot(ShootSound);
                break;
            }
            case "hit":
            {
                AudioSrc.PlayOneShot(HitSound);
                break;
            }
            default:
            {
                break;
            }
        }
    }
}

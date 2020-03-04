using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum soundsGame
{
    ball,
    heart,
    boom,
    nhacnen
}
public class AudioControl : MonoBehaviour {
    public AudioClip soundBall;
    public AudioClip soundHeart;
    public AudioClip soundBoom;
    public AudioClip soundNhacnen;
    public static AudioControl instance;
    // Use this for initialization
    void Start() {
        instance = this;
        instance.GetComponent<AudioSource>().volume = 0.14f;
    }

    public static void PlaySound(soundsGame currentSound)
    {
        switch (currentSound)
        {
            case soundsGame.ball:
                {
                    instance.GetComponent<AudioSource>().PlayOneShot(instance.soundBall);
                }
                break;
            case soundsGame.heart:
                {
                    instance.GetComponent<AudioSource>().PlayOneShot(instance.soundHeart);
                }
                break;
            case soundsGame.boom:
                {
                    instance.GetComponent<AudioSource>().PlayOneShot(instance.soundBoom);
                }
                break;
            case soundsGame.nhacnen:
                {
                    instance.GetComponent<AudioSource>().PlayOneShot(instance.soundNhacnen);
                }
                break;
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}

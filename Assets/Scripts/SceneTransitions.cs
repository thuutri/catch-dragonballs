using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour {

    public Animator transitionAnim;
    public string sceneName;
    public AudioClip soundIntro;
    public static AudioSource instance;
    void Start()
    {
        instance = GetComponent<AudioSource>();
        instance.PlayOneShot(soundIntro);
    }
    void Update()
    {
        StartCoroutine(Wait());
        StartCoroutine(LoadScene());
        
    }

    IEnumerator LoadScene()
    {

        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(2.4f);
        SceneManager.LoadScene(sceneName);
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2.2f);
    }
}


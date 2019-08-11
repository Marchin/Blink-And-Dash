using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {
    AudioSource musicSource;
    [SerializeField]
    AudioClip music;
    [SerializeField]
    AudioClip victory;

    void Start (){
        musicSource = GetComponent<AudioSource>();
        musicSource.clip = music;
        musicSource.loop = true;
        //musicSource.Play();
	}

    public void VictorySound() {
        musicSource.loop = false;
        musicSource.clip = victory;
        musicSource.Play();
    }
}

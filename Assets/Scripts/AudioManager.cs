using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [Header("--------- Audio Source ---------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("--------- Audio Clip ---------")]
    public AudioClip backgroundGame;
    public AudioClip backgroundMainMenu;
    public AudioClip coins;
    public AudioClip health;
    public AudioClip damage;
    public AudioClip death;
    public AudioClip shooting;
    public AudioClip nextWave;

    private void Start()
    {
        musicSource.clip = backgroundGame;
        musicSource.Play();
    }
}

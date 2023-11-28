using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : MonoBehaviour
{
	[SerializeField]
	private AudioSource m_SFXAudioSource;

	[SerializeField]
	private AudioSource m_MusicAudioSource;

	private static SoundManager _instance;

	void Awake()
    {
		if (_instance == null)
        {
			_instance = this;
        }
		else
        {
			Destroy(this);
        }
    }

	public static void PlaySFX(AudioClip clip)
    {
		_instance.m_SFXAudioSource.PlayOneShot(clip);
    }

	public static void PlayMusic(AudioClip clip)
    {
		_instance.m_MusicAudioSource.Stop();
		_instance.m_MusicAudioSource.clip = clip;
		_instance.m_MusicAudioSource.Play();
    }
	
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (AudioSource))]
public class SimpleSound : MonoBehaviour {
	
	private AudioSource audioSource;
	public AudioClip audio;

	void Start()
	{
		audioSource = GetComponent<AudioSource>();
		if(audio) audioSource.clip = audio;
	}
	public void PlaySound()
	{
		if(audioSource.clip!=null)
			if(!audioSource.isPlaying)
			{
				audioSource.Play();
			}
	}
	
}

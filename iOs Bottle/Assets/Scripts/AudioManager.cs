using UnityEngine;
using System.Collections;
using UnityEngine.Audio; 
using System;

public class AudioManager : MonoBehaviour

{

	//Avoiding two AudioManager on the Scene..
	public static AudioManager instance;



	//Creating an array from the custom class
	public Sounds [] sounds; 
	//This method is called right before the Start Method
	void Awake () 
	{
		if (instance == null)
		{
			instance = this;
		}
		//If we already have one..destroy it
		else 
		{
			Destroy (gameObject);
			return;
		}

		DontDestroyOnLoad (gameObject);

		//For each sounds in the array, add this component..
		foreach (Sounds s in sounds) 
		{
			s.source = gameObject.AddComponent<AudioSource> ();
			s.source.clip = s.clip;
			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
		}	
	}

	void Start()
	{
		Play ("Theme");
	}
	//Looking for the right audio through the array
	public void Play (string name)
	{
		Sounds s = Array.Find (sounds, sound => sound.name == name);
		if (s == null) {
			Debug.LogWarning ("There's no sound");
			return;
		} 
		else 
		{
			s.source.Play (); 
		}

	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.Audio; 

//Para que salga en el inspector.. 
[System.Serializable]
public class Sounds 
{
	//Sounds component references..
	public AudioClip clip; 

	//Creating a slider..
	[Range(0f, 0.1f)]
	public float volume;
	[Range(.1f, 3.0f)]
	public float pitch; 

	public string name; 

	public bool loop;

	//Hiding in Inspector
	[HideInInspector]
	public AudioSource source; 

}

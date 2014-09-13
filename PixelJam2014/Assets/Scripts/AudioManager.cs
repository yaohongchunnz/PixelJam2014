using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {
	public AudioSource leftSource;
	public AudioSource rightSource;


	public AudioClip handStep1;
	public AudioClip handStep2;

	// Use this for initialization
	void Start () {
		this.playSound("handStep", "left");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void playSound(string sound, string side, int types = 1, float delay = 0f){

		var track = Random.Range(1, types);
		var soundToPlay = sound + track.ToString();
		AudioClip clipToPlay = null;
		switch (soundToPlay){
		case "handStep1":
			clipToPlay = handStep1;
			break;
		case "handStep2":
			clipToPlay = handStep2;
		     break;
	     
		}
		if(clipToPlay == null) {
			print ("Audio clip was not passed correctly to the Audio Manager");
			return;
		}
		if(side.ToLower() == "right"){
			rightSource.PlayOneShot(clipToPlay);
		} else {
			leftSource.PlayOneShot(clipToPlay);
		}



	}
}

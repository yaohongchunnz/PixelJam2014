﻿using UnityEngine;
using System.Collections;


public class BuildingDestroy : MonoBehaviour {
	public GameObject myParticle1;
	public GameObject newParticleEmmiter;
	private bool falling = false;
	public float myFallStep = 0.5f;
	public float randomStep = 0.025f;
	private int counter = 0;
	private int counterTrigger = 3;


	// Use this for initialization
	void Start () {
		this.blowUp ();
		
	
	}
	
	// Update is called once per frame
	void Update () {
		if(this.falling){
			var randomX = Random.value * this.randomStep- this.randomStep/2;
			var randomZ = Random.value * this.randomStep - this.randomStep/2;
			if(counter > this.counterTrigger) {
				this.transform.Translate(new Vector3(randomX, this.myFallStep * Time.deltaTime * -1,randomZ));
				this.counter = 0;

			}
			this.counter++;
		}
		if(this.transform.position.y < -2){
			Destroy(this.gameObject);

		}
	
	}
	void blowUp (){
		GameObject newParticle =  Instantiate(newParticleEmmiter, transform.position, transform.rotation) as GameObject;
		Destroy (newParticle,10f);
		newParticle.particleSystem.Play(true);
		myParticle1.particleSystem.Play(true);

		this.falling = true;
	}
}

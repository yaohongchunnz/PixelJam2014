using UnityEngine;
using System.Collections;


public class BuildingDestroyMedium : MonoBehaviour {
	public GameObject myParticle1;
	public GameObject myParticle2;
	public GameObject newParticleEmmiter;
	public GameObject rubble;
	private bool falling = false;
	public float myFallStep = 0.5f;
	public float randomStep = 0.05f;
	private int counter = 0;
	private int counterTrigger = 3;


	// Use this for initialization
	void Start () {
		//this.blowUp ();
		
	
	}
	
	// Update is called once per frame
	void Update () {
		if(this.falling){
			var randomX = Random.value * this.randomStep- this.randomStep/2;
			var randomZ = Random.value * this.randomStep - this.randomStep/2;
			this.transform.Translate(new Vector3(0, this.myFallStep * Time.deltaTime * -1,0));
			if(counter > this.counterTrigger) {
				this.transform.Translate(new Vector3(randomX, 0,randomZ));
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
		GameObject newRubble =  Instantiate(rubble, transform.position, transform.rotation) as GameObject;
		Destroy (newParticle,15f);
		newParticle.particleSystem.Play(true);
		myParticle1.particleSystem.Play(true);
		myParticle2.particleSystem.Play(true);

		this.falling = true;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderClap : MonoBehaviour {
	public AudioClip clip;
	bool canFlicker = true;

	void Update(){
		StartCoroutine (Flicker ()); //allows the IEnumerator flicker to work
	}

	IEnumerator Flicker (){
		if (canFlicker) {
			canFlicker = false;
			GetComponent<AudioSource> ().PlayOneShot (clip);

			GetComponent<Light>().enabled = true;
			yield return new WaitForSeconds (Random.Range (0.1f, 0.4f)); //sets the lenght of the flicker/lighting strike
			GetComponent<Light>().enabled = false;
			yield return new WaitForSeconds (Random.Range (0.1f, 5f)); //staggers time between strikes 
			canFlicker = true;	
		}
	}
}

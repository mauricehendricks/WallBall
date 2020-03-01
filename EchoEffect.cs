using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoEffect : MonoBehaviour
{
	public float timeBtwSpawns;
	public float startTimeBtwSpawns;
	public GameObject echo;

    void Update()
    {
		if (timeBtwSpawns <= 0) {
			//Spawn echo game object
			GameObject instance = (GameObject)Instantiate (echo, transform.position, Quaternion.identity);
			Destroy (instance, 8f);
			timeBtwSpawns = startTimeBtwSpawns;
		} else {
			timeBtwSpawns -= Time.deltaTime;
		}
    }
}

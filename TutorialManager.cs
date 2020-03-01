using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
	public int image = 1;

	public GameObject FirstImage;
	public GameObject SecondImage;
	public GameObject ThirdImage;

	void Start () {
		FirstImage = GameObject.Find("FirstImage");
		SecondImage = GameObject.Find("SecondImage");
		ThirdImage = GameObject.Find("ThirdImage");
	}

	public void NextImage() {
		//Debug.Log ("Next Image");
		if (image <= 2) {
			image++;
		} else if (image == 3) {
			image = 1;
		}
	}

	public void Update () {
		if (image == 1) {
			FirstImage.SetActive(true);
			SecondImage.SetActive(false);
			ThirdImage.SetActive(false);
		} else if (image == 2) {
			FirstImage.SetActive(false);
			SecondImage.SetActive(true);
			ThirdImage.SetActive(false);
		} else if (image == 3) {
			FirstImage.SetActive(false);
			SecondImage.SetActive(false);
			ThirdImage.SetActive(true);
		}
	}
}

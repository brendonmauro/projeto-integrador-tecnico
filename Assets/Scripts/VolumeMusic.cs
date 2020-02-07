using UnityEngine;
using System.Collections;

using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class VolumeMusic : MonoBehaviour {

	public GameObject volumeSlider;
	private float volume = 1f;
	// Update is called once per frame
	void Update () {
		audio.volume = volume;
	}

	public void AdjustVolume (){
		volume= GameObject.Find ("VolumeSlider").GetComponent<Slider>().value;
	}
}

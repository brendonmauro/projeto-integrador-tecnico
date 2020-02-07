using UnityEngine;
using System.Collections;

public class ParticleSystemScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		particleSystem.renderer.sortingLayerName = "PostForeground";
	}

}

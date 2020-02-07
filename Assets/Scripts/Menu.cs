using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	
	public void PlayGame (string scene) {

		Application.LoadLevel (scene);
	}

	public void Quit (){
		Application.Quit();
	}
}

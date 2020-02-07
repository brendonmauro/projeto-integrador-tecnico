using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {
	private int buttonWidth =200;
	private int buttonWeight =50;
	private int groupWidth =300;
	private int groupHeight =300;
	private bool pausePressed, showPauseMenuGui;
	public static bool deadGUI;
	public static bool winGUI;
	public GUIStyle style;
	public GUIStyle PauseStyle;

	void Start()
	{
		Time.timeScale = 1;
		pausePressed = false;
		showPauseMenuGui = false;
		deadGUI = false;
		winGUI = false;
	}
	
	void Update() {
		if (Input.GetKeyUp(KeyCode.P) && !pausePressed) {
			pausePressed = true;
		}
		if (pausePressed) {
			Time.timeScale = Time.timeScale==0? 1 : 0;
			showPauseMenuGui = showPauseMenuGui? false : true;
			pausePressed = false;
		}
	}
	public void OnGUI(){
		if (showPauseMenuGui) {
			GUI.BeginGroup(new Rect(((Screen.width / 2) - (groupWidth / 2)), ((Screen.height / 2) - (groupHeight / 2)), groupWidth, groupHeight)); 
			GUI.Label(new Rect(70,0, buttonWidth, buttonWeight),"Paused",style);
			if (GUI.Button(new Rect(0,60, buttonWidth, buttonWeight),"Return")){
				pausePressed = false;
				showPauseMenuGui = false;
				Time.timeScale = 1;
			}
			if (GUI.Button(new Rect(0,120, buttonWidth, buttonWeight),"Main Menu")){
				Application.LoadLevel(0);
			}
			if (GUI.Button(new Rect(0,180, buttonWidth, buttonWeight),"Restart Game")){
				Application.LoadLevel(1);
			}
			if (GUI.Button(new Rect(0,240, buttonWidth, buttonWeight),"Quit Game")){
				Application.Quit();
			}
			GUI.EndGroup();
		}
		if (deadGUI) {
			GUI.BeginGroup(new Rect(((Screen.width / 2) - (groupWidth / 2)), ((Screen.height / 2) - (groupHeight / 2)), groupWidth, groupHeight)); 
			GUI.Label(new Rect(40,0, buttonWidth, buttonWeight),"You Lose!",style);
			if (GUI.Button(new Rect(0,60, buttonWidth, buttonWeight),"Restart")){
				Application.LoadLevel(1);
			}
			if (GUI.Button(new Rect(0,120, buttonWidth, buttonWeight),"Main Menu")){
				Application.LoadLevel(0);
			}
			if (GUI.Button(new Rect(0,180, buttonWidth, buttonWeight),"Quit Game")){
				Application.Quit();
			}
			GUI.EndGroup();
		}
		if (winGUI) {
			GUI.BeginGroup(new Rect(((Screen.width / 2) - (groupWidth / 2)), ((Screen.height / 2) - (groupHeight / 2)), groupWidth, groupHeight)); 
			GUI.Label(new Rect(7,0, buttonWidth + 100, buttonWeight),"You've made it to the top!",style);
			if (GUI.Button(new Rect(15,60, buttonWidth, buttonWeight),"Restart")){
				Application.LoadLevel(1);
			}
			if (GUI.Button(new Rect(15,120, buttonWidth, buttonWeight),"Main Menu")){
				Application.LoadLevel(0);
			}
			if (GUI.Button(new Rect(15,180, buttonWidth, buttonWeight),"Quit Game")){
				Application.Quit();
			}
			GUI.EndGroup();
		}
	}
}

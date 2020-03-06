using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SwitchTo004 : MonoBehaviour {

	public string word;

	public void onClick(){
		switch(word){
		case "robot":
			if(DoneOrNot.isRobotDone == true)
				SceneManager.LoadScene ("004");
			break;
		case "soccer":
			if(DoneOrNot.isSoccerDone == true)
				SceneManager.LoadScene ("004");
			break;
		case "kick":
			if(DoneOrNot.isKickDone == true)
				SceneManager.LoadScene ("004");
			break;
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

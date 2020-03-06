using UnityEngine;
using System.Collections;

public class onClickWord : MonoBehaviour {

	public void onClick(){
		DoneOrNot.currentWord = gameObject.name;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

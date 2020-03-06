using UnityEngine;
using System.Collections;
using Vuforia;

public class VirtualButtonControl : MonoBehaviour,
                                    IVirtualButtonEventHandler
{
    public GameObject[] models;

	public bool isButtonPressed;
    // Use this for initialization
    void Start(){
		isButtonPressed = false;
        VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour>();
        for (int i = 0; i < vbs.Length; i++)
        {
            vbs[i].RegisterEventHandler(this);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnButtonPressed(VirtualButtonAbstractBehaviour vb)
    {
		isButtonPressed = true;
		Debug.Log ("WWWWWWWWWWWWWWWWWWWWWWWW");
        /*
		switch (vb.VirtualButtonName)
        {
		case "VirtualButton":
                Debug.Log("sahaifhifuif");
                models[0].SetActive(false);
                break;
        }*/
    }
    public void OnButtonReleased(VirtualButtonAbstractBehaviour vb)
    {
		isButtonPressed = false;
		Debug.Log ("MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM");
		/*
        switch (vb.VirtualButtonName)
        {
		case "VirtualButton":
                Debug.Log("sahaifhifuif");
                models[0].SetActive(true);
                break;
        }*/
    }
}

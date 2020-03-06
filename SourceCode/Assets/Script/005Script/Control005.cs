using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Control005 : MonoBehaviour {
	
	public Text countDown;
	public Text rashCnText;
	public Text scoreText;
	public Text usernameText;
	public Text resultText;
	public Text ppdText;
	public Text isBreakTime;
	public Text breakTime;
	public GameObject robot;
	public GameObject soccer;
	public GameObject kick;
	public GameObject butterfly;
	public GameObject horse;
	public Slider slider;
	public GameObject rashCanvas;

	public MicTest1 mic;
	private float countTime;
	private int count;
	private string[] words;
	// Use this for initialization
	void Start () {
		countTime = 0f;
		count = 0;
		words =new string[5]{"robot","soccer","kick","butterfly","horse"};
		mic.startrec ();
	}
	
	// Update is called once per frame
	void Update () {
		countTime += Time.deltaTime;
		countDown.text = ((int)countTime/60).ToString("D2") + ":" + ((int)countTime%60).ToString("D2");

		switch(count){
		case 0:
			kick.SetActive (false);
			soccer.SetActive (false);
			butterfly.SetActive (false);
			horse.SetActive (false);
			rashCnText.text = "n.机器人";
			robot.SetActive(true);
			Animation[] anime = robot.GetComponentsInChildren<Animation> (true);
			anime [0].Play ("robotStatic");
			mic.current = words [0];
			if (mic.recognized && mic.current == words [0]) {
				mic.recognized = false;
				slider.value += 0.2f;
				count++;
			}
			break;
		case 1:
			rashCnText.text = "n.足球";
			mic.current = "soccer";
			robot.SetActive (false);
			soccer.SetActive (true);
			anime = soccer.GetComponentsInChildren<Animation> (true);
			anime [0].Play ();
			if (mic.recognized && mic.current == words [1]) {
				mic.recognized = false;
				slider.value += 0.2f;
				count++;
			}
			break;
		case 2:
			rashCnText.text = "v.踢";
			mic.current = "kick";
			soccer.SetActive (false);
			kick.SetActive (true);
			anime = kick.GetComponentsInChildren<Animation> (true);
			anime [0].Play ("robotKick");
			if (mic.recognized && mic.current == words [2]) {
				mic.recognized = false;
				slider.value += 0.2f;
				count++;
			}
			break;
		case 3:
			rashCnText.text = "n.蝴蝶";
			mic.current = "butterfly";
			kick.SetActive (false);
			butterfly.SetActive (true);
			anime = butterfly.GetComponentsInChildren<Animation> (true);
			anime [0].Play ();
			if (mic.recognized && mic.current == words [3]) {
				mic.recognized = false;
				slider.value += 0.2f;
				count++;
			}
			break;
		case 4:
			rashCnText.text = "n.马";
			mic.current = "horse";
			butterfly.SetActive (false);
			horse.SetActive (true);
			//anime = hor.GetComponentsInChildren<Animation> (true);
			//anime [0].Play ();
			//butterfly.transform.localScale = new Vector3 (1, 1, 1);
			if (mic.recognized && mic.current == words [4]) {
				mic.recognized = false;
				slider.value += 0.2f;
				count++;
			}
			break;
		}

		if (count == 5) {
			setResult ();
			count++;
		}
	}

	void setResult(){
		iTween.MoveTo (rashCanvas,new Vector3(Screen.width/2,Screen.height/2,0),0.5f);
		//iTween.MoveTo (rashCanvas,new Vector3(540,960,0),0.5f);
		scoreText.text = (slider.value*100).ToString();
		if (slider.value >= 0.6) {
			resultText.text = "真棒，通过了！";
			ppdText.text = "+"+ ((slider.value - 0.5f)*100).ToString();
			breakTime.text = ((int)countTime/60).ToString("D2") + ":" + ((int)countTime%60).ToString("D2");

			DoneOrNot.ppdPoints += (int)((slider.value - 0.5f) * 100);
		} else {
			resultText.text = "可惜，再试试吧！";
			ppdText.text = "+0";
			isBreakTime.text = "";
			breakTime.text = "";
		}
	}

	public void onClick(){
		count++;
	}
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Control004 : MonoBehaviour {
	public Text engWordText;
	public Text howText;
	public Text cnWordText;
	public Text resultText;
	public Image cardBack;
	public GameObject robot;
	public GameObject soccer;
	public GameObject kick;
	public bool isRobotRec;
	public bool isSoccerRec;
	public bool isKickRec;

	private AudioSource currentAudio;
	private float sumTime;

	void setTexts(string eng, string how, string cn){
		engWordText.text = eng;
		howText.text = how;
		cnWordText.text = cn;
	}

	void setBack(string picName){
		Image[] images = cardBack.GetComponentsInChildren<Image>(true);
		images[0].sprite = Resources.Load(picName, typeof(Sprite)) as Sprite;
		images [0].transform.localScale = new Vector3 (1f,1f,1f);
	}

	// Use this for initialization
	void Start () {
		sumTime = 0f;

		resultText.text = "";

		isRobotRec = false;
		isSoccerRec = false;
		isKickRec = false;

		robot.SetActive(false);
		kick.SetActive(false);
		soccer.SetActive(false);

		switch (DoneOrNot.currentWord) {
		case "ButtonRobot":
			robot.SetActive(true);
			Animation[] anime = robot.GetComponentsInChildren<Animation>(true);
			anime [0].Play ("robotStatic");
			setTexts ("Robot", "[ˈroʊba:t]", "n.机器人");
			setBack ("Images/cards/robotIcon");
			break;
		case "ButtonSoccer":
			soccer.SetActive(true);
			setTexts ("Soccer","[ˈsa:kə(r)]","n.足球");
			setBack ("Images/cards/soccerIcon");
			break;
		case "ButtonKick":
			kick.SetActive(true);
			setTexts ("Kick","[kɪk]","v.踢");
			setBack ("Images/cards/kick");
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (isRobotRec) {
			resultText.text = "读的真准~";
			Animation[] anime = robot.GetComponentsInChildren<Animation> (true);
			anime [0].Play ("robotJump");
			sumTime += Time.deltaTime;
			if (sumTime >= 5.0f) {
				anime [0].Play ("robotStatic");
				sumTime = 0f;
				isRobotRec = false;
				resultText.text = "";
			}
		}
		if (isSoccerRec) {
			resultText.text = "读的真准~";
			Animation[] anime = soccer.GetComponentsInChildren<Animation> (true);
			anime [0].Play ();
			sumTime += Time.deltaTime;
			if (sumTime >= 5.0f) {
				anime [0].Stop ();
				sumTime = 0f;
				isSoccerRec = false;
				resultText.text = "";
			}
		}
		if (isKickRec) {
			resultText.text = "读的真准~";
			Animation[] anime = kick.GetComponentsInChildren<Animation> (true);
			anime [0].Play ("robotKick");
			sumTime += Time.deltaTime;
			if (sumTime >= 5.0f) {
				anime [0].Stop ("robotKick");
				sumTime = 0f;
				isKickRec = false;
				resultText.text = "";
			}
		}
	}

	public void onClick(){
		switch (DoneOrNot.currentWord) {
		case "ButtonRobot":
			AudioSource[] robotAudios = robot.GetComponentsInChildren<AudioSource>(true);
			currentAudio = robotAudios [0];
			currentAudio.Play ();
			break;
		case "ButtonSoccer":
			AudioSource[] soccerAudios = soccer.GetComponentsInChildren<AudioSource>(true);
			currentAudio = soccerAudios [0];
			currentAudio.Play ();
			break;
		case "ButtonKick":
			AudioSource[] kickAudios = kick.GetComponentsInChildren<AudioSource>(true);
			currentAudio = kickAudios [0];
			currentAudio.Play ();
			break;
		}
	}
}

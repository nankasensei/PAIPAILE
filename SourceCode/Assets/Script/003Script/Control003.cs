using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Control003 : MonoBehaviour {
	public Button buttonRobot;
	public Button buttonSoccer;
	public Button buttonKick;
    public Button buttonTrain;
    public Button buttonHandbag;
    public Button buttonGirl;
    public Button buttonBoy;
    public Button buttonPonyStory;
    public Button buttonUnit1;
    public Button buttonInOut;
    public Button buttonQuit;
    public Button buttonRushing;
    public Text usernameText;
	public Text ppdText;
	public GameObject panelLeft;
	public GameObject panelRight;
    public GameObject panelLeftIn;
    public GameObject panelRightIn;
    public GameObject dialogePanel;
    public Image colorBack;

	private float distance = 0f;
    private bool isInClass = true;
	// Use this for initialization
	void Start () {
		//iTween.MoveTo (panelRight,new Vector3(Screen.width/2,Screen.height/1.8f,0),0.5f);
		//iTween.MoveTo (panelLeft,new Vector3(-Screen.width/2,Screen.height/1.8f,0),0.5f);

		ppdText.text = (DoneOrNot.ppdPoints).ToString();
		dialogePanel.SetActive (false);

		if (DoneOrNot.isRobotDone) {
			buttonRobot.GetComponentInChildren<Text> ().text = "Robot";

			Image[] images = buttonRobot.GetComponentsInChildren<Image>(true);
			images[1].sprite = Resources.Load("Images/cards/robotIcon", typeof(Sprite)) as Sprite;
			images [1].transform.localScale = new Vector3 (1.5f,1.5f,1.5f);
		}
		if (DoneOrNot.isSoccerDone) {
			buttonSoccer.GetComponentInChildren<Text> ().text = "Soccer";

			Image[] images = buttonSoccer.GetComponentsInChildren<Image>(true);
			images[1].sprite = Resources.Load("Images/cards/soccerIcon", typeof(Sprite)) as Sprite;
			images [1].transform.localScale = new Vector3 (1.5f,1.5f,1.5f);
		}
		if (DoneOrNot.isKickDone) {
			buttonKick.GetComponentInChildren<Text> ().text = "Kick";

			Image[] images = buttonKick.GetComponentsInChildren<Image>(true);
			images[1].sprite = Resources.Load("Images/cards/kick", typeof(Sprite)) as Sprite;
			images [1].transform.localScale = new Vector3 (2,2,2);
		}
        if (DoneOrNot.isHandbagDone)
        {
            buttonHandbag.GetComponentInChildren<Text>().text = "Handbag";

            Image[] images = buttonHandbag.GetComponentsInChildren<Image>(true);
            images[1].sprite = Resources.Load("Images/cards/handbag", typeof(Sprite)) as Sprite;
            images[1].transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        if (DoneOrNot.isGirlDone)
        {
            buttonGirl.GetComponentInChildren<Text>().text = "Girl";

            Image[] images = buttonGirl.GetComponentsInChildren<Image>(true);
            images[1].sprite = Resources.Load("Images/cards/girl", typeof(Sprite)) as Sprite;
            images[1].transform.localScale = new Vector3(1.4f, 1.4f, 1.4f);
        }
        if (DoneOrNot.isTrainDone)
        {
            buttonTrain.GetComponentInChildren<Text>().text = "Train";

            Image[] images = buttonTrain.GetComponentsInChildren<Image>(true);
            images[1].sprite = Resources.Load("Images/cards/train", typeof(Sprite)) as Sprite;
            images[1].transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        if (DoneOrNot.isBoyDone)
        {
            buttonBoy.GetComponentInChildren<Text>().text = "Boy";

            Image[] images = buttonBoy.GetComponentsInChildren<Image>(true);
            images[1].sprite = Resources.Load("Images/cards/boy", typeof(Sprite)) as Sprite;
            images[1].transform.localScale = new Vector3(1.4f, 1.4f, 1.4f);
        }
        if (DoneOrNot.isUnit1Done)
        {
            Image[] images = buttonUnit1.GetComponentsInChildren<Image>(true);
            images[2].sprite = Resources.Load("Images/cards/unit1", typeof(Sprite)) as Sprite;
            images[2].transform.localScale = new Vector3(4f, 4f, 4f);
        }
    }

	// Update is called once per frame
	void Update () {
		ppdText.text = (DoneOrNot.ppdPoints).ToString();
		//----------------------------------------------------------------------------
		if (1 == Input.touchCount) {
			Touch touch = Input.GetTouch (0);
			Vector2 deltaPos = touch.deltaPosition;			
			distance += deltaPos.x;
			//向右划
			if (distance > Screen.width / 10) {
				iTween.MoveTo (panelLeft,new Vector3(Screen.width/2,Screen.height/1.8f,0),0.5f);
				iTween.MoveTo (panelRight,new Vector3(Screen.width*1.5f,Screen.height/1.8f,0),0.5f);
                iTween.MoveTo(panelLeftIn, new Vector3(Screen.width / 2, Screen.height / 1.8f, 0), 0.5f);
                iTween.MoveTo(panelRightIn, new Vector3(Screen.width * 1.5f, Screen.height / 1.8f, 0), 0.5f);
            }
			//向左划
			if (distance < -Screen.width / 10) {
				iTween.MoveTo (panelLeft,new Vector3(-Screen.width/2,Screen.height/1.8f,0),0.5f);
				iTween.MoveTo (panelRight,new Vector3(Screen.width/2,Screen.height/1.8f,0),0.5f);
                iTween.MoveTo(panelLeftIn, new Vector3(-Screen.width / 2, Screen.height / 1.8f, 0), 0.5f);
                iTween.MoveTo(panelRightIn, new Vector3(Screen.width / 2, Screen.height / 1.8f, 0), 0.5f);
            }
		} else {
			distance = 0f;
		}
    }

	public void onClick(){
		if (DoneOrNot.isPonyStory) {
		} else {
			dialogePanel.SetActive (true);
		}
	}
	public void onClickYes(){
		DoneOrNot.isPonyStory = true;
		DoneOrNot.ppdPoints -= 60;
		dialogePanel.SetActive (false);

		Image[] images = buttonPonyStory.GetComponentsInChildren<Image>(true);
		images[2].sprite = Resources.Load("Images/cards/mlp", typeof(Sprite)) as Sprite;
		images[2].transform.localScale = new Vector3(5,5,5);
	}
	public void onClickNo(){
		dialogePanel.SetActive (false);
	}
    public void onClickSwitchInOutClass()
    {
        isInClass = !isInClass;
        if (isInClass)
        {
            panelLeftIn.SetActive(true);
            panelRightIn.SetActive(true);
            panelLeft.SetActive(false);
            panelRight.SetActive(false);

            Image[] images = colorBack.GetComponentsInChildren<Image>(true);
            images[0].sprite = Resources.Load("Images/cards/orange", typeof(Sprite)) as Sprite;

            Image[] images1 = buttonInOut.GetComponentsInChildren<Image>(true);
            images1[0].sprite = Resources.Load("Images/cards/in", typeof(Sprite)) as Sprite;

            Image[] images2 = buttonRushing.GetComponentsInChildren<Image>(true);
            images2[0].sprite = Resources.Load("Images/rashing/rashingNext", typeof(Sprite)) as Sprite;

            Image[] images3 = buttonQuit.GetComponentsInChildren<Image>(true);
            images3[0].sprite = Resources.Load("Images/cards/quit", typeof(Sprite)) as Sprite;
        }
        else
        {
            panelLeftIn.SetActive(false);
            panelRightIn.SetActive(false);
            panelLeft.SetActive(true);
            panelRight.SetActive(true);

            Image[] images = colorBack.GetComponentsInChildren<Image>(true);
            images[0].sprite = Resources.Load("Images/cards/pink", typeof(Sprite)) as Sprite;

            Image[] images1 = buttonInOut.GetComponentsInChildren<Image>(true);
            images1[0].sprite = Resources.Load("Images/cards/out", typeof(Sprite)) as Sprite;

            Image[] images2 = buttonRushing.GetComponentsInChildren<Image>(true);
            images2[0].sprite = Resources.Load("Images/cards/rashingNext1", typeof(Sprite)) as Sprite;

            Image[] images3 = buttonQuit.GetComponentsInChildren<Image>(true);
            images3[0].sprite = Resources.Load("Images/cards/quit1", typeof(Sprite)) as Sprite;
        }
    }
}

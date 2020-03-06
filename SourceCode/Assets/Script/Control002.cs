using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Vuforia{
public class Control002 : MonoBehaviour {
		
		public GameObject Robot ;
		private listener robot;
		public GameObject Soccer;
		private listener soccer;
		public GameObject Pony;
		private listener pony;
		public GameObject Magic;
		private listener magic;
		public GameObject Sun;
		private listener sun;
		public GameObject Moon;
		private listener moon;
		public GameObject Evil;
		private listener evil;
		public GameObject Horse;
		private listener horse;
		public GameObject Goal;
		private listener goal;
        public GameObject Girl;
        private listener girl;
        public GameObject Boy;
        private listener boy;
        public GameObject Handbag;
        private listener handbag;
        public GameObject Train;
        private listener train;
        public GameObject video;
        public GameObject video2;

        public GameObject robotic;
		public GameObject socceric;
		public GameObject kickic;
		public GameObject shootic;
        public GameObject horseic;

        private AudioSource currentAudio;
		private bool isSentence = false;
	public Text TextWord;

	// Use this for initialization
	void Start () {
			listener[] robots = Robot.GetComponentsInChildren<listener>(true);
			robot = robots [0];
			listener[] soccers = Soccer.GetComponentsInChildren<listener>(true);
			soccer = soccers [0];
			listener[] ponys = Pony.GetComponentsInChildren<listener>(true);
			pony = ponys [0];
			listener[] magics = Magic.GetComponentsInChildren<listener>(true);
			magic = magics [0];
			listener[] suns = Sun.GetComponentsInChildren<listener>(true);
			sun = suns [0];
			listener[] moons = Moon.GetComponentsInChildren<listener>(true);
			moon = moons [0];
			listener[] evils = Evil.GetComponentsInChildren<listener>(true);
			evil = evils [0];
			listener[] horses = Horse.GetComponentsInChildren<listener>(true);
			horse = horses [0];
			listener[] goals = Goal.GetComponentsInChildren<listener>(true);
			goal = goals [0];
            listener[] girls = Girl.GetComponentsInChildren<listener>(true);
            girl = girls[0];
            listener[] boys = Boy.GetComponentsInChildren<listener>(true);
            boy = boys[0];
            listener[] handbags = Handbag.GetComponentsInChildren<listener>(true);
            handbag = handbags[0];
            listener[] trains = Train.GetComponentsInChildren<listener>(true);
            train = trains[0];
        }
	
	// Update is called once per frame
	void Update () {
            int recSum = 0;

            if (robot.kk)
                recSum++;
            if (soccer.kk)
                recSum++;
            if (boy.kk)
                recSum++;
            if (girl.kk)
                recSum++;
            if (train.kk)
                recSum++;
            if (handbag.kk)
                recSum++;
            if (moon.kk)
                recSum++;
            if (evil.kk)
                recSum++;
            if (magic.kk)
                recSum++;
            if (pony.kk)
                recSum++;
            if (sun.kk)
                recSum++;
            //------------------------------------文本控制 和 模型展示-----------------------------------------------------------------------------------------//			
            TextWord.text = "请将AR卡片置于下方区域";
			isSentence = false;

			if (robot.kk == true && soccer.kk == false) {
				Animation[] anime = robotic.GetComponentsInChildren<Animation>(true);
				VirtualButtonControl[] vb = Robot.GetComponentsInChildren<VirtualButtonControl>(true);

				appearALL (robotic);
				vanishAll (kickic);
				vanishAll (socceric);
				TextWord.text = "Robot（机器人）";
				DoneOrNot.isRobotDone = true;
				if (!vb [0].isButtonPressed) {
					anime [0].Play ("robotStatic");
				}else
					anime [0].Play ("robotJump");
			}
			if (robot.kk == false && soccer.kk == true) {
				Animation[] anime = socceric.GetComponentsInChildren<Animation>(true);
				VirtualButtonControl[] vb = Soccer.GetComponentsInChildren<VirtualButtonControl>(true);
				TextWord.text = "Soccer（足球）";
				appearALL (socceric);
				vanishAll (robotic);
				vanishAll (kickic);
				DoneOrNot.isSoccerDone = true;

				if (!vb [0].isButtonPressed) {
					anime [0].Stop ();
				} else {
					anime [0].Play ();
				}
			}
			if (robot.kk == true && soccer.kk == true) {
				Animation[] anime = kickic.GetComponentsInChildren<Animation>(true);
				vanishAll (robotic);
				vanishAll (socceric);
				appearCompound (robotic, socceric, kickic);
				anime [0].Play ("robotKick");
				TextWord.text = "Kick（踢）";
				DoneOrNot.isKickDone = true;
			}
			if (pony.kk == true && magic.kk == true && moon.kk == true && sun.kk == true && evil.kk == true) {
                video.transform.localScale = new Vector3(-0.3f,0.3f,0.17f);
                appearCompound (Pony, Magic,Moon,Sun,Evil, video);
				TextWord.text = "我的小马驹";
			} else {
				vanishAll (video);
			}

            if (boy.kk == true && girl.kk == true && train.kk == true && handbag.kk == true )
            {
                DoneOrNot.isUnit1Done = true;
                video2.transform.localScale = new Vector3(-0.3f, 0.3f, 0.17f);
                appearCompound(Boy, Girl, Train, Handbag, video2);
                TextWord.text = "Unity1:Is it your hangbag?";
            }
            else
            {
                vanishAll(video2);
            }

            if (goal.kk == true && robot.kk==true && soccer.kk == true) {
				Animation[] anime = shootic.GetComponentsInChildren<Animation>(true);
				vanishAll (robotic);
				vanishAll (socceric);
				vanishAll (kickic);
				appearCompound (robotic, socceric, kickic, shootic);
				anime [0].Play ();
				TextWord.text = "A robot kicked a soccer, but it missed the goal.";
				isSentence = true;
			}
            if (handbag.kk == true && recSum == 1)
            {
                TextWord.text = "Handbag（手提包）";
                DoneOrNot.isHandbagDone = true;
            }
            if (train.kk == true && recSum == 1)
            {
                TextWord.text = "Train（火车）";
                DoneOrNot.isTrainDone = true;
            }
            if (boy.kk == true && recSum == 1)
            {
                TextWord.text = "Boy（男孩）";
                DoneOrNot.isBoyDone = true;
            }
            if (girl.kk == true && recSum == 1)
            {
                TextWord.text = "Girl（女孩）";
                DoneOrNot.isGirlDone = true;
            }
            if (horse.kk)
            {
                TextWord.text = "Horse（马）";
                appearALL(horseic);
                DoneOrNot.isHorseDone = true;
            }
        }

	private void appearALL(GameObject obj)
	{
		Renderer[] rendererComponents = obj.GetComponentsInChildren<Renderer>(true);
		foreach (Renderer component in rendererComponents)
		{
			component.enabled = true;
		}
	}

		private void vanishAll(GameObject obj)
		{
			Renderer[] rendererComponents = obj.GetComponentsInChildren<Renderer>(true);
			foreach (Renderer component in rendererComponents)
			{
				component.enabled = false;
			}
		}

		private void appearCompound(GameObject a,GameObject b,GameObject c){
			Renderer[] rendererComponents = c.GetComponentsInChildren<Renderer>(true);
			foreach (Renderer component in rendererComponents)
			{
				component.enabled = true;
			}
			//GameObject.Find ("Cylinder").transform.position = (GameObject.Find ("Cube").transform.position + GameObject.Find ("Capsule").transform.position)/2.0f;
			c.transform.position = (a.transform.position + b.transform.position)/2.0f;
		}

		private void appearCompound(GameObject a,GameObject b,GameObject c,GameObject d){
			Renderer[] rendererComponents = d.GetComponentsInChildren<Renderer>(true);
			foreach (Renderer component in rendererComponents)
			{
				component.enabled = true;
			}
			//GameObject.Find ("Cylinder").transform.position = (GameObject.Find ("Cube").transform.position + GameObject.Find ("Capsule").transform.position)/2.0f;
			d.transform.position = (a.transform.position + b.transform.position + c.transform.position)/3.0f;
		}

        private void appearCompound(GameObject a, GameObject b, GameObject c, GameObject d, GameObject e)
        {
            Renderer[] rendererComponents = e.GetComponentsInChildren<Renderer>(true);
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = true;
            }
            //GameObject.Find ("Cylinder").transform.position = (GameObject.Find ("Cube").transform.position + GameObject.Find ("Capsule").transform.position)/2.0f;
            e.transform.position = (a.transform.position + b.transform.position + c.transform.position + d.transform.position) / 4.0f;
        }

        private void appearCompound(GameObject a,GameObject b,GameObject c,GameObject d,GameObject e,GameObject f){
			Renderer[] rendererComponents = f.GetComponentsInChildren<Renderer>(true);
			foreach (Renderer component in rendererComponents)
			{
				component.enabled = true;
			}
			//GameObject.Find ("Cylinder").transform.position = (GameObject.Find ("Cube").transform.position + GameObject.Find ("Capsule").transform.position)/2.0f;
			f.transform.position = (a.transform.position + b.transform.position + c.transform.position + d.transform.position + e.transform.position)/5.0f;
        }

		public void onClick(){
			if (robot.kk == true && soccer.kk == false) {
				AudioSource[] robotAudios = Robot.GetComponentsInChildren<AudioSource>(true);
				currentAudio = robotAudios [0];
				currentAudio.Play ();
				Debug.Log ("NOWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW");
			}
			if (robot.kk == false && soccer.kk == true) {
				AudioSource[] soccerAudios = Soccer.GetComponentsInChildren<AudioSource>(true);
				currentAudio = soccerAudios [0];
				currentAudio.Play ();
			}
			if (robot.kk == true && soccer.kk == true) {
				AudioSource[] kickAudios = kickic.GetComponentsInChildren<AudioSource>(true);
				currentAudio = kickAudios [0];
				currentAudio.Play ();
			}
		}

		public void onClickDisplayCN(){
			if (isSentence) {
				TextWord.text = "机器人踢了球一脚，但它踢偏了。";
			}
		}

}
}
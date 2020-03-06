using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class ButtonStartManage : MonoBehaviour {

    public GameObject everydayEnglish;
    private Image everydayEnglishImg;
    private float appearTime;
    private bool flag;
    private float alpha;

   public void onClick(){
        flag = true;
	}

	// Use this for initialization
	void Start () {
        flag = false;
        appearTime = 0;
        alpha = 0;
        everydayEnglish.SetActive(false);

        Image[] everydayEnglishImgs = everydayEnglish.GetComponentsInChildren<Image>(true);
        everydayEnglishImg = everydayEnglishImgs[0];
    }
	
	// Update is called once per frame
	void Update () {
        if (flag)
        {
            appearTime += Time.deltaTime;
            everydayEnglish.SetActive(true);
            alpha = (appearTime * 255f)/100f;
            everydayEnglishImg.color = new Color(255, 255, 255, alpha);
            if (appearTime >= 1)
            {
                SceneManager.LoadScene("002");
            }
        }
    }
}

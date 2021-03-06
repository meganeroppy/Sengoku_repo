﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FriendNode : MonoBehaviour {
	
	private GameObject window;

	private int index = 0;
	private Text myText;
	private Image myImage;
	private UILabel myLabel;
	private UISprite mySprite;

	// Use this for initialization
	void Start () {
		if(GameManager.isWithUGUI){
			window = Resources.Load("Outgame/Prefab/AnnounceWindow") as GameObject;
		}else{
			window = Resources.Load("Outgame/Prefab/AnnounceWindowNGUI") as GameObject;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void Press(){
		if(GameObject.FindWithTag("Announce")){
			return;
		}
		GameObject obj = Instantiate(window) as GameObject;
		obj.transform.SetParent(GameObject.Find("AnnounceLayer").transform);
		string str = "フレンド" + index.ToString() + "の情報を表示しています。";
		obj.SendMessage("Init", str);
	}
	
	private void SetIndex(int val){
		index = val;
		string str = "フレンド" + index.ToString();
		Sprite[] sprites = Resources.LoadAll<Sprite>("Outgame/Images/chibidot_sample");

		if(GameManager.isWithUGUI){
			myText = transform.GetChild(0).GetComponent<Text>();
			myImage = transform.GetChild(1).GetComponent<Image>();
			myText.text =  str;
			myImage.sprite = sprites[index % 32];
		}else{
			myLabel = transform.GetChild(0).GetComponent<UILabel>();
			mySprite = transform.GetChild(1).GetComponent<UISprite>();
			myLabel.text =  str;
			mySprite.spriteName = "chibidot_sample_" + ((index % 32)+1).ToString();
		}



		//myImage.sprite = Resources.Load("Outgame/Images/chibidot_sample_1", typeof(Sprite)) as Sprite;
	}
}
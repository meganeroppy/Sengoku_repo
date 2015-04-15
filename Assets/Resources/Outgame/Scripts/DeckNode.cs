using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DeckNode : MonoBehaviour {
	
	//private GameObject window;
	
	private int index = 0;
	private Text myText;
	private Image myImage;
	private UISprite mySprite;

	// Use this for initialization
	void Start () {
		//window = Resources.Load("Outgame/Prefab/AnnounceWindow") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void Press(){
		/*
		if(GameObject.FindWithTag("Announce")){
			return;
		}
		GameObject obj = Instantiate(window) as GameObject;
		obj.transform.SetParent(GameObject.Find("AnnouceLayer").transform);
		string str = "モンスター" + index.ToString() + "の情報を表示しています。";
		obj.SendMessage("Init", str);
		*/
	}
	
	private void SetIndex(int[] val){

		index = val[0];
		int numOfUnit = val[1];

		for(int i = 0 ; i < 5 ; i++){

			transform.GetChild(i).gameObject.transform.GetChild(0).gameObject.SendMessage("SetCellIndex", i < numOfUnit ? (index * 5) + i : -1);
		}
	}

	public int GetIndex(){
		return index;
	}
}
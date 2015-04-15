using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GoldLabel : MonoBehaviour {
	private Text myText;
	private UILabel myLabel;
	
	// Use this for initialization
	void Start () {
		if(GameManager.isWithUGUI){
			myText = GetComponent<Text>();
		}else{
			myLabel = GetComponent<UILabel>();
			
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(GameManager.isWithUGUI){
			myText.text = GameManager.gold.ToString();
		}else{
			myLabel.text = GameManager.gold.ToString();
		}
	}
}

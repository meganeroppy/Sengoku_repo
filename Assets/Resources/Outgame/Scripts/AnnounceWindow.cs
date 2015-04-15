using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AnnounceWindow : MonoBehaviour {

	private RectTransform myRect;
	private Transform bg;
	private Image myImage;// for uGUI
	private Text myText;// for uGUI
	private UISprite mySprite;// for NGUI
	private UILabel myLabel;// for NGUI
	private bool removable = true;

	// Use this for initialization
	void Start () {
	}

	protected void Init(string text){

		if(GameManager.isWithUGUI){
			myText = transform.GetChild(0).transform.GetChild(0).GetComponent<Text>();
			myText.enabled = true;
			myImage = GetComponent<Image>();
			myImage.enabled = true;

			myText.text = text;
			myRect = GetComponent<RectTransform>();

			bg = GameObject.FindWithTag("BG").transform;

			myRect.sizeDelta = new Vector2(0.0f, 0.0f);
			myRect.position = bg.position;
			myRect.localScale= new Vector2(1,1);
		}else{
		/////
			/// 
			/// 
			myLabel = transform.GetChild(0).transform.GetChild(0).GetComponent<UILabel>();
			
			myLabel.enabled = true;
			mySprite = GetComponent<UISprite>();
			
			mySprite.enabled = true;
			myLabel.text = text;
			
			transform.localScale = Vector3.one;
		}

	} 
	
	protected void Activate(bool key){
		if(GameManager.isWithUGUI){
			myText.enabled = key;
			myImage.enabled = key;
		}else{
			myLabel.enabled = key;
			mySprite.enabled = key;
		}
	}
	
	public void Press(){
		if(!removable){
			return;
		}

		if(GameManager.isWithUGUI){
			myText.enabled = false;
			myImage.enabled = false;
		}else{
			myLabel.enabled = false;
			mySprite.enabled = false;
		}

		for(int i = transform.childCount-1 ; i >= 0 ; i--){
			Destroy(transform.GetChild(i).gameObject);
		}
		Destroy(this.gameObject);
	}

	protected void SetAsNotRemovable(){
		removable = false;
	}
}

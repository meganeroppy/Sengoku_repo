using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BG : MonoBehaviour {

	protected enum BG_IMAGE{
		DEFAULT = 0,
		DECK
	};
	protected BG_IMAGE cur_bg = BG_IMAGE.DEFAULT;

	protected Image myImage;
	protected UISprite mySprite;

	private Sprite bg_default;
	private Sprite bg_check;

	protected void Start(){
		if(GameManager.isWithUGUI){
			myImage = GetComponent<Image>();
			bg_default = Resources.Load<Sprite>("Outgame/Images/bg_default");
			bg_check = Resources.Load<Sprite>("Outgame/Images/bg_check");
		}else{
			mySprite = GetComponent<UISprite>();
		}
	}

	protected void Update(){
		if(GameManager.subpageIsOpen){
			if(cur_bg != BG_IMAGE.DECK){
				SwitchImage("DECK");
			}
		}else{
			if(cur_bg != BG_IMAGE.DEFAULT){
				SwitchImage("DEFAULT");
			}
		}
	}

	protected void SwitchImage(string cmd){
		if(cmd == "DECK"){
			if(GameManager.isWithUGUI){
				myImage.sprite = bg_check;
			}else{
				mySprite.spriteName = "bg_check";
			}
			cur_bg = BG_IMAGE.DECK;
		}else{
			if(GameManager.isWithUGUI){

				myImage.sprite = bg_default;
			}else{
				mySprite.spriteName = "bg_default";
			}
			cur_bg = BG_IMAGE.DEFAULT;
		}
	}
}

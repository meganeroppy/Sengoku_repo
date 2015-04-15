using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PageTitleLabel : MonoBehaviour {

	private Text myText;
	private UILabel myLabel;

	void Start(){
		if(GameManager.isWithUGUI){
			myText = GetComponent<Text>();
		}else{
			myLabel = GetComponent<UILabel>();
		}
	}

	// Update is called once per frame
	void Update () {
		string str = "";

		switch(GameManager.cur_page){
		case GameManager.PAGE.MYPAGE:
			str = "マイページ";
			break;
		case GameManager.PAGE.PRESENT:
			str = "プレゼント";
			break;
		case GameManager.PAGE.INFO:
			str = "お知らせ";
			break;
		case GameManager.PAGE.DECK:

			if(DeckMenu.cur_subpage == DeckMenu.SUBPAGE.NONE){
				str = "デッキ";
			}else if(DeckMenu.cur_subpage == DeckMenu.SUBPAGE.EDIT){
				str = "デッキ編成";
			}else if(DeckMenu.cur_subpage == DeckMenu.SUBPAGE.STRENGTHEN){
				str = "強化合成";
			}else if(DeckMenu.cur_subpage == DeckMenu.SUBPAGE.EVOLVE){
				str = "進化合体";
			}else if(DeckMenu.cur_subpage == DeckMenu.SUBPAGE.SALE){
				str = "ユニット売却";
			}else{
				str = "UNDEFINED";
			}			

			break;
		case GameManager.PAGE.GACHA:
			str = "ガチャ";
			break;	
		case GameManager.PAGE.FRIEND:
			str = "フレンド";
			break;	
		case GameManager.PAGE.OTHER:
			str = "その他";
			break;	
		case GameManager.PAGE.SHOP:
			str = "ショップ";
			break;
		default: str = "";
			break;

		}

		if(GameManager.isWithUGUI){
			myText.text = str;
		}else{
			myLabel.text = str;
		}
	}
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BackButton : MonoBehaviour {

	private Image myImage;
	private UISprite mySprite;
	private bool m_awake;
	
	// Use this for initialization
	void Start () {
		//m_awake = false;
		if(GameManager.isWithUGUI){
			myImage = GetComponent<Image>();
		}else{
			mySprite = GetComponent<UISprite>();
		}
		
		//myImage.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

		switch(GameManager.cur_page){
		case GameManager.PAGE.MYPAGE :
		case GameManager.PAGE.SHOP :
		case GameManager.PAGE.GACHA :
		case GameManager.PAGE.FRIEND :
		case GameManager.PAGE.OTHER :
			if(m_awake){
				m_awake = false;
				EnableImage(false);
			}
			
			break;
		case GameManager.PAGE.PRESENT :
		case GameManager.PAGE.INFO :
			if(!m_awake){
				m_awake = true;
				EnableImage(true);
			}
			break;
		case GameManager.PAGE.DECK :
			if(GameManager.subpageIsOpen){
				if(!m_awake){
					m_awake = true;
					EnableImage(true);
				}
			}else{
				if(m_awake){
					m_awake = false;
					EnableImage(false);
				}
			}

			break;

		default :
			if(!m_awake){
				m_awake = true;
				EnableImage(true);
			}
			break;
		}
	}
	
	public void Press(){

		if(GameObject.FindWithTag("Announce")){
			Destroy(GameObject.FindWithTag("Announce"));
		}

		//GameManager.cur_page = GameManager.PAGE.MYPAGE;
		GameManager game = GameObject.Find("Main Camera").GetComponent<GameManager>();
		game.SendMessage("CloseSubpage");

		/*
		GameObject[] additives = GameObject.FindGameObjectsWithTag("Additive");
		for(int i = 0 ; i < additives.Length ; i++){
			Destroy(additives[i].gameObject);
		}
		*/
	}

	private void EnableImage(bool key){
		if(GameManager.isWithUGUI){
			myImage.enabled = key;
		}else{
			mySprite.enabled = key;
		}
	}
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ConfirmWindow : MonoBehaviour {

	enum TYPE{
		PURCHASE_DIAMOND,
		GACHA,
		GOLDGACHA,
		QUEST,
		CHARGE,
		SALE
	}
	TYPE type = TYPE.PURCHASE_DIAMOND;
	private Text myText;
	private UILabel myLabel;
	private RectTransform myRect;
	private int num;	// number or index
	private int price;	// cost of overall
	private GameObject announceWindow;
	private GameObject confirmWindow;
	private bool isTransparent = false;

	// Use this for initialization
	void Start () {
		announceWindow = Resources.Load("Outgame/Prefab/AnnounceWindow" + (GameManager.isWithUGUI ? "" : "NGUI")) as GameObject;
		confirmWindow = Resources.Load("Outgame/Prefab/ConfirmWindow" + (GameManager.isWithUGUI ? "" : "NGUI")) as GameObject;
	}
	
	// Update is called once per frame
	void Update () {

		if(!isTransparent){
			for(int i = 0 ; i < transform.parent.transform.childCount ; i++){
				if(transform.parent.transform.GetChild(i).name.Contains("Announce")){
					isTransparent = true;

					for(int j = 0 ; j < transform.childCount ; j++){
						transform.GetChild(j).gameObject.SetActive(false);
					}

					if(GameManager.isWithUGUI){
						GetComponent<Image>().enabled = false;
					}else{
						GetComponent<UISprite>().enabled = false;
					}

					return;
				}
			}
		}else{
			for(int i = 0 ; i < transform.parent.transform.childCount ; i++){
				if(transform.parent.transform.GetChild(i).name.Contains("Announce")){
					return;
				}
			}
			for(int j = 0 ; j < transform.childCount ; j++){
				transform.GetChild(j).gameObject.SetActive(true);
			}

			if(GameManager.isWithUGUI){
				GetComponent<Image>().enabled = true;
			}else{
				GetComponent<UISprite>().enabled = true;
			}

			isTransparent = false;
		}

	}

	private void Init(int[] val){

		this.num  = val[0];
		this.price = val[1];

		if(GameManager.isWithUGUI){
			myRect = GetComponent<RectTransform>();
			myRect.sizeDelta = new Vector2(0,0);
			myRect.localScale= new Vector2(1,1);
			myRect.position = GameObject.FindWithTag("BG").transform.position;
		}else{
			transform.localScale = Vector3.one;
		}
	}

	
	private void SetText(string text){

		string[] texts = text.Split(',');
		string tag = texts[0];

		if(tag == "PURCHASE"){
			type = TYPE.PURCHASE_DIAMOND;
		}else if(tag == "GACHA"){
			type = TYPE.GACHA;
		}else if(tag == "GOLDGACHA"){
			type = TYPE.GOLDGACHA;
		}else if(tag == "QUEST"){
			type = TYPE.QUEST;
		}else if(tag == "CHARGE"){
			type = TYPE.CHARGE;
		}else if(tag == "SALE"){
			type = TYPE.SALE;
		}
		if(GameManager.isWithUGUI){
			myText = transform.GetChild(0).gameObject.transform.FindChild("Text").GetComponent<Text>();
			myText.text = texts[1];
		}else{
			myLabel = transform.GetChild(0).gameObject.transform.FindChild("Text").GetComponent<UILabel>();
			myLabel.text = texts[1];			
		}

	}

	public void Accept(){
		if(type == TYPE.PURCHASE_DIAMOND){
			GameManager.AddDiamond(num);
		}else if(type == TYPE.GACHA || type == TYPE.GOLDGACHA){
			int cost = type == TYPE.GACHA ? GameManager.diamond_num : GameManager.gold;
			if(cost < (price)){
				GameObject obj = Instantiate(announceWindow) as GameObject;
				obj.transform.SetParent(GameObject.Find("AnnounceLayer").transform);

				string str = type == TYPE.GACHA ? "金貨が不足しています。 " : "ゴールドが不足しています。 ";
				obj.SendMessage("Init", str);
				Destroy(this.gameObject);

				return;
			}

			int[] order = {type == TYPE.GACHA ? 0 : 1, num, price};

			GameObject.Find("Main Camera").GetComponent<GameManager>().SendMessage("TryGacha", order);


		}else if(type == TYPE.QUEST){

			PlayerPrefs.SetInt("Stamina", GameManager.cur_stamina);
			PlayerPrefs.SetInt("Stamina_max", GameManager.max_stamina);

			if(GameManager.cur_stamina < (price)){
				if(GameObject.Find("ConfirmWindow(Clone)")){
					Destroy(GameObject.Find("ConfirmWindow(Clone)").gameObject);
				}else if(GameObject.Find("ConfirmWindowNGUI(Clone)")){
					Destroy(GameObject.Find("ConfirmWindowNGUI(Clone)").gameObject);
				}
				GameObject obj = Instantiate(confirmWindow) as GameObject;
				obj.transform.SetParent(GameObject.Find("AnnounceLayer").transform);
				
				string str = "CHARGE,兵糧が不足しています。\n金貨を消費して兵糧を回復させますか？";

				int[] order = {0, 1};
				obj.SendMessage("Init", order);
				obj.SendMessage("SetText", str);

				return;
			}
			
			GameObject.Find("Main Camera").GetComponent<GameManager>().SendMessage("TryQuest", price);


		}else if(type == TYPE.CHARGE){
			if(GameManager.diamond_num < (price)){
				GameObject obj = Instantiate(announceWindow) as GameObject;
				obj.transform.SetParent(GameObject.Find("AnnounceLayer").transform);
				
				string str = "金貨が不足しています。 ";
				obj.SendMessage("Init", str);
				
				return;
			}
			
			GameObject.Find("Main Camera").GetComponent<GameManager>().SendMessage("ChargeStamina", price);

		}else if(type == TYPE.SALE){
			int[] order = {num, price};

			GameObject.Find("Main Camera").GetComponent<GameManager>().SendMessage("SaleUnit", order);

			string str = GameManager.isWithUGUI ? "Content_deck" : "ScrollView_deckN";
			GameObject.Find(str).GetComponent<DeckView>().SendMessage("Reload");		
		
		}

		Destroy(this.gameObject);

	}

	public void Cancel(){
		Destroy(this.gameObject);
	}
}

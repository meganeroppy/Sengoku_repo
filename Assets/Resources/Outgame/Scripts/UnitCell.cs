using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UnitCell : MonoBehaviour {
	
	private GameObject announceWindow;
	private GameObject confirmWindow;

	private int cellIndex = 0;	// = box index
	//private int deckIndex = 0; 	// number on tip right displayig deck index 
	private Image deckSelection; // number image(for uGUI)
	private UISprite deckSelectionSprite; // number image(for NGUI)
	private Image myImage; // unit image (for uGUI)
	private UISprite mySprite; // unit image (for NGUI)
	private GameObject unableScreen;

	// Use this for initialization
	void Start () {
		if(unableScreen == null){
			unableScreen = transform.FindChild("UnableScreen").gameObject;
			//unableScreen.SetActive(false);
		}
		if(GameManager.isWithUGUI){
			announceWindow = Resources.Load("Outgame/Prefab/AnnounceWindow") as GameObject;
			confirmWindow = Resources.Load("Outgame/Prefab/ConfirmWindow") as GameObject;

			// set deckIndex
			deckSelection = transform.GetChild(0).GetComponent<Image>();
		}else{
			announceWindow = Resources.Load("Outgame/Prefab/AnnounceWindowNGUI") as GameObject;
			confirmWindow = Resources.Load("Outgame/Prefab/ConfirmWindowNGUI") as GameObject;
			
			// set deckIndex
			deckSelectionSprite = transform.GetChild(0).GetComponent<UISprite>();
		}
	}

	protected void Deselect(){
		if(GameManager.isWithUGUI){
			// remove selection number
			deckSelection = transform.GetChild(0).GetComponent<Image>();
			deckSelection.enabled = false;

		}else{
			// remove selection number
			deckSelectionSprite = transform.GetChild(0).GetComponent<UISprite>();
			deckSelectionSprite.enabled = false;
			unableScreen.SetActive(false);

		}
	}
	
	public void Press(){
		if(GameObject.FindWithTag("Announce")){
			return;
		}

		Unit unit = GameManager.unit_box[this.cellIndex] as Unit;

		Debug.Log("cellIndex =" + unit.GetBoxIndex().ToString() + "/uid =" + unit.GetUID().ToString() + "/deckIndex =" + unit.GetDeckIndex().ToString() + "/imageIndex =" + unit.GetImageIndex().ToString());

		ExecuteCellAction();
	}
	
	private void SetCellIndex(int val){
		if(val == -1){
			// no more unitCell will added 
			Destroy( transform.parent.gameObject);
			return;
		}

		// set cellIndex
		this.cellIndex = val;

		Sprite[] sprites = null;
		Unit unit = GameManager.unit_box[this.cellIndex] as Unit;

		int imageIndex = unit.GetImageIndex();

		bool selectionIsMax = GameObject.Find("SelectionTable").GetComponent<SelectionTable>().GetTemporalSelection().Count >= 5 ? true : false;

		if(GameManager.isWithUGUI){
			myImage = GetComponent<Image>();
			sprites = Resources.LoadAll<Sprite>("Outgame/Images/chibidot_sample");
			myImage.sprite = sprites[imageIndex];
			
			// remove selection number
			deckSelection = transform.GetChild(0).GetComponent<Image>();
			deckSelection.enabled = false;
			//unableScreen.SetActive(selectionIsMax);
		}else{
			mySprite = GetComponent<UISprite>();
			mySprite.spriteName = "chibidot_sample_" + (imageIndex+1).ToString();

			// remove selection number
			deckSelectionSprite = transform.GetChild(0).GetComponent<UISprite>();
			deckSelectionSprite.enabled = false;
		
			if(DeckMenu.cur_subpage == DeckMenu.SUBPAGE.EDIT){
				if(unableScreen == null){
					unableScreen = transform.FindChild("UnableScreen").gameObject;
				}
				unableScreen.SetActive(selectionIsMax);
			}else{
				if(unableScreen == null){
					unableScreen = transform.FindChild("UnableScreen").gameObject;
				}
				unableScreen.SetActive(false);
			}
		}


		if(unit.GetDeckIndex() == -1){
			//Debug.Log("This unit (cellIndex =" + unit.GetBoxIndex().ToString() + "/id =" + unit.GetUID().ToString() + "/deckIndex =" + unit.GetDeckIndex().ToString() + "/imageIndex =" + unit.GetImageIndex().ToString() + ") is not in the deck.");
			return;
		}

		for(int i = 0 ; i < GameManager.unit_deck.Count ; i++){

			if(unit.GetDeckIndex() == i){

				if(GameManager.isWithUGUI){
					// set selection number
					deckSelection.enabled = true;
					sprites = Resources.LoadAll<Sprite>("Outgame/Images/numbers");
					deckSelection.sprite = sprites[i];
				//	unableScreen.SetActive(true);
				}else{
					// set selection number
					deckSelectionSprite.enabled = true;
					deckSelectionSprite.spriteName = "numbers_1_" + (i+1).ToString();
					if(unableScreen == null){
						unableScreen = transform.FindChild("UnableScreen").gameObject;
					}	
					unableScreen.SetActive(true);
				}
				break;
			}
		}
	}

	protected void ExecuteCellAction(){

		Unit unit = GameManager.unit_box[this.cellIndex] as Unit;

		GameObject obj = null;

		switch(DeckMenu.cur_subpage){
		case DeckMenu.SUBPAGE.EDIT :
			SelectionTable table = GameObject.Find("SelectionTable").GetComponent<SelectionTable>();

			// set deckIndex
			int tmpDeckCount = table.GetTemporalSelection().Count;
			table.SendMessage("AddUnitToTable", unit);

			// set selection number
			if(GameManager.isWithUGUI){
				deckSelection.enabled = true;
				Sprite[] sprites = Resources.LoadAll<Sprite>("Outgame/Images/numbers");
				deckSelection.sprite = sprites[unit.GetDeckIndex()];
			}else{
				deckSelectionSprite.enabled = true;
				deckSelectionSprite.spriteName = "numbers_1_" + (tmpDeckCount+1).ToString();
				unableScreen.SetActive(true);
			}

			if(table.GetTemporalSelection().Count >= 5){
				BlackOutAllCells();
			}

			break;
		case DeckMenu.SUBPAGE.STRENGTHEN :
			break;
		case DeckMenu.SUBPAGE.EVOLVE :
			break;
		case DeckMenu.SUBPAGE.SALE :

			obj = Instantiate(confirmWindow) as GameObject;
			obj.transform.SetParent(GameObject.Find("AnnounceLayer").transform);

			int uni_uid = unit.GetUID();
			int price = unit.GetPrice();
			
			int[] order = {uni_uid, price};
			
			string text = "SALE,このユニットを" + price.ToString() + "ゴールドで売却します。\nよろしいですか？";
			
			obj.SendMessage("Init", order);
			obj.SendMessage("SetText", text);
			break;
		default :
			obj = Instantiate(announceWindow) as GameObject;
			obj.transform.SetParent(GameObject.Find("AnnounceLayer").transform);
			string str = "ユニット" + cellIndex.ToString() + "の情報を表示しています。";
			obj.SendMessage("Init", str);
			break;
		}
	}

	protected void BlackOutAllCells(){
		GameObject[] cells = GameObject.FindGameObjectsWithTag("UnitCell");
		foreach(GameObject cell in cells){
			cell.SendMessage("BlackOut");
		}
	}

	protected void BlackOut(){
		if(GameManager.isWithUGUI){
			//	unableScreen.SetActive(true);
		}else{
			if(unableScreen == null){
				unableScreen = transform.FindChild("UnableScreen").gameObject;
			}	
			unableScreen.SetActive(true);
		}
	}
}

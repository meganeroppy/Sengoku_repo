using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SelectionTable : MonoBehaviour {
	
	protected GameObject[] cellOnTable = new GameObject[5];
	protected ArrayList selection;
	protected GameObject applyButton;
	protected GameObject cancelButton;
	//protected bool selectionChanged = false;

	// Use this for initialization
	void Start () {
		applyButton = transform.FindChild("ApplyButton").gameObject;
		cancelButton = transform.FindChild("RemoveAllButton").gameObject;

		// display deck that has been already set
		DisplayCurrentDeck();
		GameManager.deckSelectionChanged = false;
	}
	
	// Update is called once per frame
	void Update () {
		switch(DeckMenu.cur_subpage){
		case DeckMenu.SUBPAGE.EDIT :
			if(!applyButton.activeInHierarchy){
				applyButton.SetActive(true);
			}
			
			if(!cancelButton.activeInHierarchy){
				cancelButton.SetActive(true);
			}

			break;
		default:
			if(applyButton.activeInHierarchy){
				applyButton.SetActive(false);
			}
			
			if(cancelButton.activeInHierarchy){
				cancelButton.SetActive(false);
			}

			break;
		}
	}

	protected void AddUnitToTable(Unit unit){	// Temproal Selection

		int targetTableCellIndex = selection.Count < 5 ? selection.Count : 4 ;

		int imageIndex = unit.GetImageIndex();

		if(GameManager.isWithUGUI){
			Image unitImage = cellOnTable[targetTableCellIndex].GetComponent<Image>();
			Sprite[] sprites = Resources.LoadAll<Sprite>("Outgame/Images/chibidot_sample");
			unitImage.sprite = sprites[imageIndex];
		}else{
			cellOnTable[targetTableCellIndex].GetComponent<UISprite>().spriteName = "chibidot_sample_" + (imageIndex+1).ToString();
		}

		if(selection.Count >= 5){
			selection.RemoveAt(4);
		}

		selection.Add(unit);
		GameManager.deckSelectionChanged = true;
	}

	protected void RemoveUnit(int index){

	}

	public void RemoveAllUnit(){
		for(int i = 0 ; i < selection.Count ; i++){
			if(GameManager.isWithUGUI){
				Image unitImage = cellOnTable[i].GetComponent<Image>();
				unitImage.sprite = Resources.Load("Outgame/Images/Empty", typeof(Sprite)) as Sprite;
			}else{
				cellOnTable[i].GetComponent<UISprite>().spriteName = "Empty";
			}
		}

		GameObject[] units = GameObject.FindGameObjectsWithTag("UnitCell");
		foreach(GameObject obj in units){
			obj.SendMessage("Deselect");
		}

		selection.Clear();
		GameManager.deckSelectionChanged = true;
	}

	public void ApplyUnit(){
		GameManager game = GameObject.Find("Main Camera").GetComponent<GameManager>();
		game.SendMessage("ApplyUnit", selection);
	}

	protected void DisplayCurrentDeck(){
		for(int i = 0 ; i < 5 ; i++){
			cellOnTable[i] = transform.FindChild("Cell" + i.ToString()).gameObject;
		}

		selection = new ArrayList();
		for(int i = 0 ; i < GameManager.unit_deck.Count ; i++){
			Unit unit = GameManager.unit_deck[i] as Unit;
			AddUnitToTable(unit);
		}
	}

	public ArrayList GetTemporalSelection(){
		return selection;
	}

	protected void UpdateSelection(){
		Debug.Log("Updated");
		if(selection != null){
			RemoveAllUnit();
		}

		DisplayCurrentDeck();
		GameManager.deckSelectionChanged = false;
	}
}
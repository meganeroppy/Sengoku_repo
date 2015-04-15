using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DeckDisplay : MonoBehaviour {

	protected GameObject[] cell = new GameObject[5];
	//protected float counter = 0;
	//protected float reloadInterval = 0.5f;

	// Use this for initialization
	void Start () {
		
		for(int i = 0 ; i < 5 ; i++){
			cell[i] = transform.FindChild("Cell" + i.ToString()).gameObject;
		}

		if(GameManager.unit_deck == null){
			return;
		}

		for(int i = 0 ; i < GameManager.unit_deck.Count ; i++){
			Unit unit = GameManager.unit_deck[i] as Unit;
			AddUnit(unit);
		}

	}

	protected void Update(){
		if(GameManager.deckIsUpdated){
			Reload();
			GameManager.deckIsUpdated = false;
		}
	}
	
	protected void AddUnit(Unit unit){
		 
		int tableCellIndex = unit.GetDeckIndex();
		int imageIndex = unit.GetImageIndex();

		if(GameManager.isWithUGUI){
			Image unitImage = cell[tableCellIndex].GetComponent<Image>();
			Sprite[] sprites = Resources.LoadAll<Sprite>("Outgame/Images/chibidot_sample");
			unitImage.sprite = sprites[imageIndex];
		}else{
			cell[tableCellIndex].GetComponent<UISprite>().spriteName = ("chibidot_sample_" + (imageIndex+1).ToString());
		}

	}

	protected void Reload(){

		for(int i = 0 ; i < 5 ; i++){
			if(GameManager.isWithUGUI){
				Image unitImage = cell[i].GetComponent<Image>();
				unitImage.sprite = Resources.Load("Outgame/Images/Empty", typeof(Sprite)) as Sprite;
			}else{
				cell[i].GetComponent<UISprite>().spriteName = ("Empty");
			}
		}

		for(int i = 0 ; i < GameManager.unit_deck.Count ; i++){
			Unit unit = GameManager.unit_deck[i] as Unit;
			AddUnit(unit);
		}
	}
}

using UnityEngine;
using System.Collections;

public class DeckMenuButton : TransitionButton {

	protected DeckMenu deckMenu; 

	// Use this for initialization
	void Start () {
		deckMenu = GameObject.Find("DeckMenu").GetComponent<DeckMenu>();
	}
	
	protected override void SetPage(){
		SetSubpage();
	} 
	
	protected virtual void SetSubpage(){
		deckMenu.SendMessage("SwitchSubpage", "NONE");
	} 
}

using UnityEngine;
using System.Collections;

public class EditButton : DeckMenuButton {

	protected override void SetSubpage(){
		deckMenu.SendMessage("SwitchSubpage", "DECK");
	} 	
}

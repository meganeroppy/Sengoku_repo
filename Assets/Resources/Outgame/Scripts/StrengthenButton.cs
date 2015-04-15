using UnityEngine;
using System.Collections;

public class StrengthenButton : DeckMenuButton {
	
	protected override void SetSubpage(){
		deckMenu.SendMessage("SwitchSubpage", "STRENGTHEN");
	} 	
}

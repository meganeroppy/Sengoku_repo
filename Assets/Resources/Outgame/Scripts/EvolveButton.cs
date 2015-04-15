using UnityEngine;
using System.Collections;

public class EvolveButton : DeckMenuButton {
	
	protected override void SetSubpage(){
		deckMenu.SendMessage("SwitchSubpage", "EVOLVE");
	} 	
}

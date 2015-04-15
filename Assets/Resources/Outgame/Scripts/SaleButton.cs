using UnityEngine;
using System.Collections;

public class SaleButton : DeckMenuButton {
	
	protected override void SetSubpage(){
		deckMenu.SendMessage("SwitchSubpage", "SALE");
	} 	
}
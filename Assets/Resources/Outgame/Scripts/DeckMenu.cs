
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DeckMenu : PageHundler {

	public enum SUBPAGE{
		EDIT = 0,
		STRENGTHEN,
		EVOLVE,
		SALE,
		NONE
	};
	public static SUBPAGE cur_subpage = SUBPAGE.NONE;
	protected GameObject subpage;
	protected DeckView deckView;


	protected override void Start ()
	{
		base.Start ();
		subpage = transform.FindChild("Subpage").gameObject;

	}


	protected override bool CheckDisplayFlug(){
		return GameManager.cur_page == GameManager.PAGE.DECK ? true : false;
	} 

	private void SwitchSubpage(string cmd){

		if(cmd == "NONE"){
			cur_subpage = SUBPAGE.NONE;
			menuRoot.SetActive(true);
			subpage.SetActive(false);
			GameManager.subpageIsOpen = false;
		}else if(cmd == "DECK"){
			cur_subpage = SUBPAGE.EDIT;
			menuRoot.SetActive(false);
			subpage.SetActive(true);
			GameManager.subpageIsOpen = true;
			if(GameManager.deckSelectionChanged){
				GameObject.Find("SelectionTable").SendMessage("UpdateSelection");
			}
		}else if(cmd == "STRENGTHEN"){
			cur_subpage = SUBPAGE.STRENGTHEN;
			menuRoot.SetActive(false);
			subpage.SetActive(true);

			GameManager.subpageIsOpen = true;
		}else if(cmd == "EVOLVE"){
			cur_subpage = SUBPAGE.EVOLVE;
			menuRoot.SetActive(false);
			subpage.SetActive(true);

			GameManager.subpageIsOpen = true;
		}else if(cmd == "SALE"){
			cur_subpage = SUBPAGE.SALE;
			menuRoot.SetActive(false);
			subpage.SetActive(true);
		
			GameManager.subpageIsOpen = true;
		}

		if(cmd != "NONE"){
			GameObject.Find("ScrollView_deckN").SendMessage("SetReloadFlug");
		}

	}

	/*
	protected string GetSubpageString(){

		if(cur_subpage == SUBPAGE.NONE){
			return "NONE";
		}else if(cur_subpage == SUBPAGE.EDIT){
			return "EDIT";
		}else if(cur_subpage == SUBPAGE.STRENGTHEN){
			return "STRENGTHEN";
		}else if(cur_subpage == SUBPAGE.EVOLVE){
			return "EVOLVE";
		}else if(cur_subpage == SUBPAGE.SALE){
			return "SALE";
		}else{
			return "UNDEFINED";
		}

	}


	private void SwitchMainBG(string cmd){
		GameObject.Find("MainBG").SendMessage("SwitchImage", cmd);
	}
	*/
}



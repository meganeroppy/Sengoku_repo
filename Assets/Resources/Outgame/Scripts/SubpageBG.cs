using UnityEngine;
using System.Collections;

public class SubpageBG : MonoBehaviour {

	protected GameObject selectionTable;

	// Use this for initialization
	void Start () {
		selectionTable = transform.FindChild("SelectionTable").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if(selectionTable.activeInHierarchy){
			if(DeckMenu.cur_subpage != DeckMenu.SUBPAGE.EDIT){
				selectionTable.SetActive(false);
			}
		}else{
			if(DeckMenu.cur_subpage == DeckMenu.SUBPAGE.EDIT){
				selectionTable.SetActive(true);
			}
		}
	}
}

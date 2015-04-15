using UnityEngine;
using System.Collections;


public class DeckView : ScrollController {

	protected override void Start(){
		num = GameManager.unit_box.Count;	// num = number of unit
	}

	protected override void Update ()
	{
		base.Update ();
		if(GameManager.boxIsUpdated ){
			Reload();
			GameManager.boxIsUpdated = false;
		}else if(reloadFlug){
			Reload();
			reloadFlug = false;
		} 
		//Debug.Log("scrollPos of " + this.gameObject.name + " = " + myUIScrollView.transform.localPosition.y.ToString());
	}

	protected override bool CheckDisplayFlug(){
		if(GameManager.cur_page != GameManager.PAGE.DECK || DeckMenu.cur_subpage == DeckMenu.SUBPAGE.NONE){
			return false;
		}
		return GameManager.cur_page == GameManager.PAGE.DECK ? true : false;
	} 
	
	protected override string SetMessage(){
		return " ユニットがいません。";
	}

	protected override void CreateNodes(){

		num = GameManager.unit_box.Count;	// num = number of unit
		int idx = 0;

		for(int i = 0 ; i < num ; i++){
			if(i % 5 == 0){
				if(GameManager.isWithUGUI){
					RectTransform item = GameObject.Instantiate(node) as RectTransform;
					item.SetParent(transform, false);
					AddCommand(item.gameObject, idx);
				}else{
					Transform item = GameObject.Instantiate(node) as Transform;
					//NGUITools.AddChild(this.gameObject, item);
					GetComponent<UIGrid>().AddChild(item, false);
					//item.SetParent(transform, true);
					item.transform.localScale = Vector3.one;
					AddCommand(item.gameObject, idx);
				}
				idx++;
			}
		}
	}
	
	protected override void AddCommand(GameObject target, int index){
		int[] val = new int[2];
		val[0] = index;	// index for node itself
		val[1] = (num - (index * 5)) >= 5 ? 5 : num % 5; // number of cells the target node will contain (max 5 cells)
		target.SendMessage("SetIndex", val);
	}
	
}

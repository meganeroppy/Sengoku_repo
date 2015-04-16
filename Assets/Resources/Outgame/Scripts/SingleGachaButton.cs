using UnityEngine;
using System.Collections;

public class SingleGachaButton : CommandButton {

	protected int[] num = {1,10};
	protected int[] price = {5,50};
	protected bool isMultiple = false;

	protected override void ExecuteCommand(){
		int index = isMultiple ? 1 : 0;
		string tag = "GACHA";
		
		GameObject obj = Instantiate(confirmWindow) as GameObject;
		obj.transform.SetParent(GameObject.Find("AnnounceLayer").transform);
		
		int[] order = {num[index], price[index]};
		
		string text = tag + ",金貨を" + 
			price[index].ToString() +"枚消費して" + (isMultiple ? "\n10連" : "" ) + "武将ガチャを回します。\nよろしいですか？";
		
		obj.SendMessage("Init", order);
		obj.SendMessage("SetText", text);
	}
}

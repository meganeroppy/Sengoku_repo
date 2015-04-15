using UnityEngine;
using System.Collections;

public class SingleGoldGachaButton : CommandButton {
	
	protected int[] num = {1,10};
	protected int[] price = {50,500};
	protected bool isMultiple = false;
	
	protected override void ExecuteCommand(){
		int index = isMultiple ? 1 : 0;
		string tag = "GOLDGACHA";
		
		GameObject obj = Instantiate(window) as GameObject;
		obj.transform.SetParent(GameObject.Find("AnnounceLayer").transform);
		
		int[] order = {num[index], price[index]};
		
		string text = tag + "," + 
			price[index].ToString() +"ゴールドを消費して" + (isMultiple ? "\n10連" : "" ) + "ガチャを回します。\nよろしいですか？";
		
		obj.SendMessage("Init", order);
		obj.SendMessage("SetText", text);
	}
}

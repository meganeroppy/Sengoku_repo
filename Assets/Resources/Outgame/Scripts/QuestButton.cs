using UnityEngine;
using System.Collections;

public class QuestButton : CommandButton {

	protected int cost = 5;

	protected override void ExecuteCommand ()
	{
		string tag = "QUEST";
		
		GameObject obj = Instantiate(confirmWindow) as GameObject;
		obj.transform.SetParent(GameObject.Find("AnnounceLayer").transform);

		int[] order = {0, cost};
		//int[] order = {num, num == 5 ? 400 : 100};
		
		string text = tag + ",兵糧を" + cost.ToString() + "消費してクエストに挑戦します。\nよろしいですか？";
		//string text = tag + "," + num.ToString() + "個の魔法石を\n" + (num == 5 ? 400 : 100).ToString() +"円で購入します。\nよろしいですか？";
		
		
		obj.SendMessage("Init", order);
		obj.SendMessage("SetText", text);
	}
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OtherNode : CommandButton {

	private string[] labels = {"ヘルプ", "購入情報", "招待コード発行",
		"招待コード入力", "シリアルコード入力", "コピーライト",
		"利用規約", "法律に基づく表記", "お問い合わせ"};

	private int index = 0;
	private Text myText;
	private UILabel myLabel;
	
	protected override void ExecuteCommand ()
	{
		return;
		/*
		string tag = "PURCHASE";
		
		GameObject obj = Instantiate(window) as GameObject;
		obj.transform.SetParent(GameObject.Find("ShopPageContents").transform.parent.transform.FindChild("AnnounceLayer").transform);
		
		int[] order = {num[index], price[index]};
		//int[] order = {num, num == 5 ? 400 : 100};
		
		string text = tag + "," + num[index].ToString() + "個の魔法石を\n" + price[index].ToString() +"円で購入します。\nよろしいですか？";
		//string text = tag + "," + num.ToString() + "個の魔法石を\n" + (num == 5 ? 400 : 100).ToString() +"円で購入します。\nよろしいですか？";
		
		
		obj.SendMessage("Init", order);
		obj.SendMessage("SetText", text);
		*/
	}
	
	
	private void SetIndex(int val){
		
		index = val;
		string str = labels[index];
		
		if(GameManager.isWithUGUI){
			myText = transform.GetChild(0).transform.GetChild(0).GetComponent<Text>();
			myText.text =  str;
			
		}else{
			myLabel = transform.GetChild(0).transform.GetChild(0).GetComponent<UILabel>();
			myLabel.text = str;
		}	
	}
}

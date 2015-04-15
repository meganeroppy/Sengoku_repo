using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShopNode : CommandButton {

	private int[] num = {1,6,12,30,60,80,175};
	private int[] price = {100,500,900,2100,3900,4900,9800};
	private int index = 0;
	private Text myText;
	private UILabel myLabel;

	protected override void ExecuteCommand ()
	{
		string tag = "PURCHASE";
		
		GameObject obj = Instantiate(window) as GameObject;
		obj.transform.SetParent(GameObject.Find("ShopPageContents").transform.parent.transform.FindChild("AnnounceLayer").transform);
		
		int[] order = {num[index], price[index]};
		//int[] order = {num, num == 5 ? 400 : 100};
		
		string text = tag + "," + num[index].ToString() + "個の魔法石を\n" + price[index].ToString() +"円で購入します。\nよろしいですか？";
		//string text = tag + "," + num.ToString() + "個の魔法石を\n" + (num == 5 ? 400 : 100).ToString() +"円で購入します。\nよろしいですか？";
		
		
		obj.SendMessage("Init", order);
		obj.SendMessage("SetText", text);
	}


	private void SetIndex(int val){

		index = val;
		string str = "魔法石 x " + num[index].ToString() + "          ¥" + price[index].ToString();

		if(GameManager.isWithUGUI){
			myText = transform.GetChild(0).GetComponent<Text>();
			myText.text =  str;
			
		}else{
			myLabel = transform.GetChild(0).GetComponent<UILabel>();
			myLabel.text = str;
		}	
	}
}

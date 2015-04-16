using UnityEngine;
using System.Collections;

public class ChargeButton : CommandButton {

	protected override void ExecuteCommand ()
	{

		if(GameManager.cur_stamina >= GameManager.max_stamina){
			GameObject obj = Instantiate(announceWindow) as GameObject;
			obj.transform.SetParent(GameObject.Find("AnnounceLayer").transform);

			string str =  "兵糧が減少していません！";
			obj.SendMessage("Init", str);
		}else{

			GameObject obj = Instantiate(confirmWindow) as GameObject;
			obj.transform.SetParent(GameObject.Find("AnnounceLayer").transform);

			string str = "CHARGE,金貨を消費して兵糧を回復させますか？";
			
			int[] order = {0, 1};
			
			obj.SendMessage("Init", order);
			obj.SendMessage("SetText", str);
		}
	}
}

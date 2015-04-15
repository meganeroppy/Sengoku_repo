#pragma warning disable 0219
#pragma warning disable 0414

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	public enum PAGE {
		MYPAGE = 0,
		PRESENT,
		INFO,
		DECK,
		SHOP,
		GACHA,
		FRIEND,
		OTHER
	};
	public static PAGE cur_page;
	public static int diamond_num;
	public static int cur_stamina;
	public static int max_stamina;
	public static int stamina_timer = 180;
	public static int cur_exp;
	public static int max_exp;
	public static int gold;
	public static int level;
	public static ArrayList unit_deck;
	public static ArrayList unit_box;
	public static int cur_unitIndex; // total number of unit since the this game launch at the fisrt time. WILL BE USED AS UID OF EACH UNIT.

	private GameObject window;
	public static bool subpageIsOpen = false;
	protected float counter = 0;
	public static bool boxIsUpdated = false;
	public static bool deckIsUpdated = false;

	public static bool isWithUGUI = false;
	public static bool deckSelectionChanged = false;

	// Use this for initialization
	void Awake () {

		if(GameObject.Find("uGUIContents")){
			isWithUGUI = true;
		}

		cur_page = Application.loadedLevelName.Equals("Outgame") ? PAGE.MYPAGE : PAGE.SHOP;

		LoadPlayerData();

		window = Resources.Load("Outgame/Prefab/AnnounceWindow"  + (isWithUGUI ? "" : "NGUI")) as GameObject;

/*	
 		 if(!GameObject.Find("EventSystem")){
			GameObject.Find("EventSystem_Shop").SendMessage("Activate");
		}
		*/
	}
	
	// Update is called once per frame
	void Update () {
		if(cur_stamina < max_stamina){
			if(counter >= 1){
				if(stamina_timer <= 0){
					cur_stamina ++;
					PlayerPrefs.SetInt("Stamina", cur_stamina);
					stamina_timer = 180;
				}
				stamina_timer--;
				counter = 0;		
			}else{
				counter += Time.deltaTime;
			}
		}else{
			if(stamina_timer < 180){
				stamina_timer = 180;
			}
		}
	}

	public static void AddDiamond(int val){
		diamond_num += val;
		PlayerPrefs.SetInt("Diamond", diamond_num);
	}

	public void TryGacha(int[] order){

		int gacha_type = order[0];	// gacha_type0 : premium / gacha_type1 : gold
		int num = order[1]; // number of trying
		int cost = order[2]; // could be diamonds or gold

		if(gacha_type == 0){
			diamond_num -= cost;
			PlayerPrefs.SetInt("Diamond", diamond_num);
		}else{
			gold -= cost;
			PlayerPrefs.SetInt("Gold", gold);
		}

		Transform parentTransform = GameObject.Find("AnnounceLayer").transform;
		GameObject obj = Instantiate(window) as GameObject;
		obj.transform.SetParent(parentTransform);
		obj.SendMessage("Init", "");
		
		Vector2 basePos = Vector2.zero;
		float interval = isWithUGUI ? 180 : 35 ;

		for (int i = 0 ; i < num ; i++){

			Unit newUnit = CreateNewUnit();

			GameObject item = Instantiate( Resources.Load("Outgame/Prefab/GachaItem" + (isWithUGUI ? "U" : ""))) as GameObject;

			Sprite[] sprites = Resources.LoadAll<Sprite>("Outgame/Images/chibidot_sample");

			int itemIndex = newUnit.GetImageIndex();

			Texture itemTexture = Resources.Load<Texture>("Outgame/Images/chibidot_sample_" + (itemIndex+1).ToString());

			unit_box.Add(newUnit);

			Debug.Log("Get [unit No." + itemIndex.ToString() + "]");

			if(isWithUGUI){
				item.GetComponent<Image>().sprite = sprites[itemIndex];
			}else{
				item.GetComponent<UISprite>().spriteName = "chibidot_sample_" + (itemIndex+1).ToString();
				//Debug.Log(item.GetComponent<UISprite>().spriteName);
			}
			
			item.transform.SetParent(obj.transform);

			if(num == 1){	// single gacha 
				item.transform.localPosition = Vector2.zero;
				item.transform.localScale = Vector2.one;

			}else{
				Vector2 offset =  new Vector2( ((i % 5) - 2)   * interval , i >= 5 ? interval : 0);
				item.transform.localPosition = basePos + offset;
				item.transform.localScale = new Vector2(0.8f, 0.8f);

			}
		}

		GameObject label = Instantiate( Resources.Load("Outgame/Prefab/GetLabel" + (isWithUGUI ? "U" : ""))) as GameObject;
		label.transform.SetParent(obj.transform);
		label.transform.localScale = Vector2.one * (isWithUGUI ? 2 : 1);
		label.transform.localPosition = Vector2.zero + new Vector2(0, (isWithUGUI ? -150 : -50));

		// save to playerprefs
		SaveUnitData();

		/*
		GameObject expBase = GameObject.Find("GachaExpressions");
		for(int i = 0 ; i < expBase.transform.childCount ; i++){
			expBase.transform.GetChild(i).GetComponent<Image>().enabled = true;
		}
		*/
	}

	public void TryQuest(int val){
		bool levelup = false;

		cur_stamina -= val;
		PlayerPrefs.SetInt("Stamina", cur_stamina);
		int score = Random.Range(3,8);

		cur_exp += score;
		if(cur_exp >= max_exp){
			levelup = true;
			level += 1;
			PlayerPrefs.SetInt("Level", level);

			cur_exp = cur_exp - max_exp;

			max_exp += 1;
			PlayerPrefs.SetInt("Exp_max", max_exp);

			cur_stamina = max_stamina;
			PlayerPrefs.SetInt("Stamina", cur_stamina);

		}
		PlayerPrefs.SetInt("Exp", cur_exp);
		
		Transform parentTransform = GameObject.Find("AnnounceLayer").transform;
		GameObject obj = Instantiate(window) as GameObject;
		obj.transform.SetParent(parentTransform);
		obj.SendMessage("Init", "スタミナを消費してクエストに挑戦しました。\n" + score.ToString() + "EXPを獲得しました。" + (!levelup ? "" : "\nレベルアップ!\nスタミナが全回復しました。") );
	}

	private Unit CreateNewUnit(){
		int uid = cur_unitIndex;
		cur_unitIndex++;
		int boxIndex = unit_box.Count;
		int deckIndex = -1;
		int imageIndex = Random.Range(0, 32);
		Unit newUnit = new Unit(uid, boxIndex, deckIndex, imageIndex);

		//string str = "[" + uid.ToString() + ","	+ boxIndex.ToString() + "," + deckIndex.ToString() + "," + imageIndex.ToString() + "],";
		return newUnit;
	}

	public void ChargeStamina(int val){
		diamond_num -= val;
		PlayerPrefs.SetInt("Diamond", diamond_num);

		cur_stamina = max_stamina;
		PlayerPrefs.SetInt("Stamina", cur_stamina);
		
		Transform parentTransform = GameObject.Find("AnnounceLayer").transform;
		GameObject obj = Instantiate(window) as GameObject;
		obj.transform.SetParent(parentTransform);
		obj.SendMessage("Init", "スタミナが回復しました。");
	}

	protected void CloseSubpage(){
		subpageIsOpen = false;
		if(cur_page == PAGE.DECK){
			GameObject.Find("DeckMenu").SendMessage("SwitchSubpage", "NONE");
		}else if(cur_page == PAGE.PRESENT || cur_page == PAGE.INFO){
			cur_page = PAGE.MYPAGE;
		}
	}

	protected void SaleUnit(int[] order){
		int choice = order[0];	// unit's uid
		gold += order[1];
		PlayerPrefs.SetInt("Gold", gold);

		for(int i = 0 ; i < unit_box.Count ; i++){
			Unit unit = unit_box[i] as Unit;
			if(unit.GetUID() == choice){
				unit_box.Remove(unit);
				break;
			}
		}

		// re-alocate bexIndex
		for(int i = 0 ; i < unit_box.Count ; i++){
			Unit unit = unit_box[i] as Unit;
			unit.SetBoxIndex(i);
		}

		Debug.Log("Unit No." + choice.ToString() + " has been sold");

		SaveUnitData();
	}

	protected void ApplyUnit(ArrayList newDeck){
		unit_deck.Clear();
		unit_deck = new ArrayList(newDeck);

		// reset dedckIndex
		foreach(Unit tmpObj in unit_box){
			tmpObj.SetDeckIndex(-1);
		}

		for(int i = 0 ; i < unit_deck.Count ; i++){
			Unit unit =unit_deck[i] as Unit;
			unit.SetDeckIndex(i);
			/*
			for(int j = 0 ; j < unit_box.Count ; j++){
				Unit unit2 =unit_box[j] as Unit;
				if(unit.GetUID() == unit2.GetUID()){
					unit2.SetDeckIndex(i);
				}
			}
			*/
		}

		SaveUnitData();
		SaveDeckData();
	}

	protected void LoadPlayerData(){
		diamond_num = PlayerPrefs.GetInt("Diamond", 0);
		cur_stamina = PlayerPrefs.GetInt("Stamina", 25);
		max_stamina = PlayerPrefs.GetInt("Stamina_max", 25);
		cur_exp = PlayerPrefs.GetInt("Exp", 0);
		max_exp = PlayerPrefs.GetInt("Exp_max", 10);
		level = PlayerPrefs.GetInt("Level", 1);
		gold = PlayerPrefs.GetInt("Gold", 0);
		cur_unitIndex = PlayerPrefs.GetInt("UnitIndex", 0);

		unit_box = new ArrayList();
		unit_deck = new ArrayList();

		string[] str =  PlayerPrefs.GetString("Unit", "0,1,2").Split(';');

		for(int i = 0 ; i < str.Length ; i++){
			if(!str[i].Contains("[")){
				str[i] = " ";
			} 
		}

		Debug.Log("Units in box have been loaded :" + PlayerPrefs.GetString("Unit", "0,1,2").ToString());
		if(str[0] != ""){
			for(int i = 0 ; i < str.Length ; i++){
				if(str[i].Equals(" ")){
					continue;
				}

				if(str[i].Contains("[")){
					str[i] = str[i].Remove(str[i].IndexOf("["), 1);
				}
				if(str[i].Contains("]")){
					str[i] = str[i].Remove(str[i].IndexOf("]"), 1);
				}

				string[] str2 = str[i].Split(',');

				int uid = int.Parse(str2[0]);
				int boxIndex = int.Parse(str2[1]);
				int deckIndex = int.Parse(str2[2]);
				int imageIndex = int.Parse(str2[3]);

				Unit unit = new Unit(uid, boxIndex, deckIndex, imageIndex);

				unit_box.Add(unit);
				if(unit.GetDeckIndex() != -1){
					unit_deck.Add(unit);
				}
			}
		}

		// sort deck
		ArrayList tmpArray = new ArrayList();
		int idx = 0;
		for(int i = 0 ; i < unit_deck.Count ; i++){
			for(int j = 0 ; j < unit_deck.Count ; j++){
				Unit unit = unit_deck[j] as Unit;
				if(unit.GetDeckIndex() == i){
					tmpArray.Add(unit);
					break;
				}
			}
		}
		unit_deck = tmpArray;
	}	

	protected void SaveUnitData(){
		string str = "";

		int idx = 0;
		while(idx < unit_box.Count){

			if(unit_box[idx].GetType().ToString() != "Unit"){
				//unit_box.RemoveAt(idx);
			}else{
				Unit unit = unit_box[idx] as Unit;
				str += "[" + unit.GetUID().ToString() + ","	+ unit.GetBoxIndex().ToString() + ","
						+ unit.GetDeckIndex().ToString() + "," + unit.GetImageIndex().ToString() + "]";
			}
			idx++;
			if(idx != unit_box.Count){
				str += ";";
			}
		}

		PlayerPrefs.SetString("Unit", str);
		PlayerPrefs.SetInt("UnitIndex", cur_unitIndex);

		str = "[uid, boxIdx, DeckIdx, ImgIdx] // " + str;
		boxIsUpdated = true;
		Debug.Log("Box data has been updated; new box = " + str);
	}

	protected void SaveDeckData(){
		int idx = 0;
		string str = "";
		
		while(idx < unit_deck.Count){
			
			if(unit_deck[idx].GetType().ToString() != "Unit"){
				//unit_box.RemoveAt(idx);
			}else{
				Unit unit = unit_deck[idx] as Unit;
				str += "[" + unit.GetUID().ToString() + ","	+ unit.GetBoxIndex().ToString() + ","
					+ unit.GetDeckIndex().ToString() + "," + unit.GetImageIndex().ToString() + "]";
			}
			idx++;
			if(idx != unit_deck.Count){
				str += ";";
			}
		}


		PlayerPrefs.SetString("Deck", str);
		deckIsUpdated = true;
		Debug.Log("Deck data has been updated; new deck = " + str);
	}
}

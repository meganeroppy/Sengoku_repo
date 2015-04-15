using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InfoNode : MonoBehaviour {


	private GameObject window;
	public string[] m_text;
	private Text myText;
	private UILabel myLabel;
	private int index;
	// Use this for initialization
	void Start () {
		index = Random.Range(0,3);

		if(GameManager.isWithUGUI){
			window = Resources.Load("Outgame/Prefab/AnnounceWindow") as GameObject;

			myText = transform.FindChild("Title").GetComponent<Text>();
			myText.text = m_text[index];
		}else{
			window = Resources.Load("Outgame/Prefab/AnnounceWindowNGUI") as GameObject;
			
			myLabel = transform.FindChild("Title").GetComponent<UILabel>();
			myLabel.text = m_text[index];	
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Press(){
		if(GameObject.FindWithTag("Announce")){
			return;
		}
		GameObject obj = Instantiate(window) as GameObject;
		obj.transform.SetParent(GameObject.Find("AnnounceLayer").transform);
		obj.SendMessage("Init", m_text[index]);
	}
}

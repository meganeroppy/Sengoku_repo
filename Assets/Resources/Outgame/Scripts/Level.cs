using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Level : MonoBehaviour {

	protected Text myText;
	protected UILabel myLabel;
	protected float counter = 0;
	protected float updateInterval = 0.5f;
	
	// Use this for initialization
	protected void Start () {
		if(GameManager.isWithUGUI){
			myText = transform.FindChild("Label").gameObject.GetComponent<Text>();
		}else{
			myLabel = transform.FindChild("Val").gameObject.GetComponent<UILabel>();
		}
	}
	
	// Update is called once per frame
	protected void Update () {
		if(counter > updateInterval){
			counter = 0;
			UpdateGauge();
		}else{
			counter += Time.deltaTime;
		}
	}
	
	protected void UpdateGauge(){
		string str = GameManager.level.ToString();
		if(GameManager.isWithUGUI){
			myText.text = str;
		}else{
			myLabel.text = str;
		}	
	}
}

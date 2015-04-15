using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PresentNode : MonoBehaviour {

	public string[] m_text;
	private Text myText;
	private UILabel myLabel;

	//private int index;

	// Use this for initialization
	void Start () {
		int index = Random.Range(0,3);

		if(GameManager.isWithUGUI){
			myText = transform.FindChild("Title").GetComponent<Text>();
			myText.text = m_text[index];
		}else{
			myLabel = transform.FindChild("Title").GetComponent<UILabel>();
			myLabel.text = m_text[index];	
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ReceiveItem(){
		GameManager.AddDiamond(1);
		if(!GameManager.isWithUGUI){
			transform.parent.GetComponent<UIGrid>().RemoveChild(transform);
		}
		Destroy(this.gameObject);

	}
}

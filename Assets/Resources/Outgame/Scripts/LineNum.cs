using UnityEngine;
using System.Collections;

public class LineNum : MonoBehaviour {

	UILabel myLabel;
	DeckNode cellLine;
	// Use this for initialization
	void Start () {
		myLabel = GetComponent<UILabel>();
		cellLine = transform.parent.transform.parent.GetComponent<DeckNode>();
	}
	
	// Update is called once per frame
	void Update () {
		myLabel.text = cellLine.GetIndex().ToString();
	}
}

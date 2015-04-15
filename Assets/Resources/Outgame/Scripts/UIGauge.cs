using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public abstract class UIGauge : MonoBehaviour {
	
	protected Image fill;
	protected UISprite fillSprite;
	protected Text label;
	protected UILabel gaugeLabel;
	protected Vector2 maxSize = Vector2.zero;
	protected float counter = 0;
	protected float updateInterval = 0.5f;

	// Use this for initialization
	protected virtual void Start () {
		if(GameManager.isWithUGUI){
			fill = transform.FindChild("Fill").gameObject.GetComponent<Image>();
			label = transform.FindChild("Label").gameObject.GetComponent<Text>();
			maxSize =fill.rectTransform.sizeDelta;
		}else{
			fillSprite = transform.FindChild("Fill").gameObject.GetComponent<UISprite>();
			gaugeLabel = transform.FindChild("Val").gameObject.GetComponent<UILabel>();
			maxSize =fillSprite.transform.localScale;
		}
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		if(counter > updateInterval){
			counter = 0;
			UpdateGauge();
		}else{
			counter += Time.deltaTime;
		}
	}
	
	protected virtual void UpdateGauge(){
	}
}

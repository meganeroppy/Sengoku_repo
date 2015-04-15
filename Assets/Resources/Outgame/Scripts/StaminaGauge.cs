using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StaminaGauge : UIGauge {

	private Text timer_text;
	private UILabel timer_label;
	private GameObject timer_bg;

	protected override void Start ()
	{
		base.Start ();
		timer_bg = transform.FindChild("Timer_bg").gameObject;
		if(GameManager.isWithUGUI){
			timer_text = timer_bg.transform.GetChild(0).GetComponent<Text>();
		}else{
			timer_label = timer_bg.transform.GetChild(0).GetComponent<UILabel>();
		}
	}

	protected override void Update ()
	{
		base.Update ();
		if(GameManager.cur_stamina >= GameManager.max_stamina){
			//timer_text.text = "";
			if(timer_bg.activeInHierarchy){
				timer_bg.SetActive(false);
			}
		}else{
			if(!timer_bg.activeInHierarchy){
				timer_bg.SetActive(true);
			}

			int val = GameManager.stamina_timer;
			int min = val / 60;
			int sec = val % 60;

			string str =  min.ToString() + ":" + (sec < 10 ? "0" + sec.ToString() : sec.ToString());

			if(GameManager.isWithUGUI){
				timer_text.text = str;
			}else{
				timer_label.text = str;
			}
		}
	}

	protected override void UpdateGauge(){
		string str = GameManager.cur_stamina.ToString() + "/" + GameManager.max_stamina.ToString();
		float percent = (float)GameManager.cur_stamina / (float)GameManager.max_stamina;
		float newSizeX  = maxSize.x * percent;
		
		if(GameManager.isWithUGUI){
			label.text = str;
			fill.rectTransform.sizeDelta = new Vector2(newSizeX, maxSize.y);
		}else{
			gaugeLabel.text = str;
			fillSprite.transform.localScale = new Vector2(newSizeX, maxSize.y);
		}
	}
}

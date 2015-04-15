using UnityEngine;
using System.Collections;

public class ExpGauge : UIGauge {

	protected override void UpdateGauge(){
		string str = GameManager.cur_exp.ToString() + "/" + GameManager.max_exp.ToString();
		float percent = (float)GameManager.cur_exp / (float)GameManager.max_exp;
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

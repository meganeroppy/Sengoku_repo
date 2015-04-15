using UnityEngine;
using System.Collections;

public class MultipleGoldGachaButton : SingleGoldGachaButton {

	protected override void Start ()
	{
		base.Start ();
		isMultiple = true;
	}
}

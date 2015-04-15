using UnityEngine;
using System.Collections;

public class MultipleGachaButton : SingleGachaButton {

protected override void Start ()
	{
		base.Start ();
		isMultiple = true;
	}
}

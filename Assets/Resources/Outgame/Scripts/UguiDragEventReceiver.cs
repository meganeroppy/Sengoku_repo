using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UguiDragEventReceiver : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
	public void OnBeginDrag(PointerEventData ped) {
		Debug.Log("マウスドラッグ開始 position="+ped.position);
	}
	public void OnDrag(PointerEventData ped) {
		Debug.Log("マウスドラッグ中 position="+ped.position);
	}
	public void OnEndDrag(PointerEventData ped) {
		Debug.Log("マウスドラッグ終了 position="+ped.position);
	}
}
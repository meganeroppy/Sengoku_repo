using UnityEngine;
using System.Collections;

public class Unit{

	protected int uid = -1;	// more than 2 units which have the same id never exist.
	protected int level = 1;
	protected int exp = 0;
	//protected int health = 1;
	//protected int attack = 1;
	//protected int defense = 1;
	protected int price = 10; // price when this unit is sold;
	protected int boxIndex = -1;
	protected int deckIndex = -1;
	protected int imageIndex = 0;

	public Unit(int uid, int boxIndex, int deckIndex, int imageIndex){
		this.uid = uid;
		this.boxIndex = boxIndex;
		this.deckIndex = deckIndex;
		this.imageIndex = imageIndex;

		level = 1;
		exp = 0;
	}

	public int GetPrice(){
		return price;
	}

	protected void GenerateUID(){

	}

	public int GetUID(){
		return uid;
	}

	public int GetBoxIndex(){
		return boxIndex;
	}

	public void SetBoxIndex(int boxIndex){
		this.boxIndex = boxIndex;
	}

	public int GetDeckIndex(){
		return deckIndex;
	}	

	public void SetDeckIndex(int deckIndex){
		this.deckIndex = deckIndex;
	}	

	public int GetImageIndex(){
		return imageIndex;
	}
}

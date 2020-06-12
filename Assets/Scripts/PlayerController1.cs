using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour {

	public float speed = 5f;
	private Rigidbody2D rb;
	private bool faceRight = true;
	private int flagHor;
	private int flagVer;
	public HashSet<Collider2D> _objInCollider = new HashSet<Collider2D>();
	public Canvas canv;
	public Canvas canv2;
	private SpriteRenderer sr;
	private int count_tolk_pers;



	void Start () {
		rb = GetComponent <Rigidbody2D> ();
		sr = GetComponent<SpriteRenderer>();
		canv2.enabled = false;
		canv.enabled = false;
		count_tolk_pers = 0;
	}

	void Update () {
		float moveX = Input.GetAxis ("Horizontal");
		float moveY = Input.GetAxis ("Vertical");
		float flafDiag = 1.0f;

		if (moveX != 0)
		{
			if (moveX > 0) { moveX = 1; }
			else { moveX = -1; }
		}
		flagHor = 0;
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
		{
			flagHor = 1;
		}

		if (moveY != 0)
		{
			if (moveY > 0) { moveY = 1; }
			else { moveY = -1; }
		}
		flagVer = 0;
		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
		{
			flagVer = 1;
		}

		if ((flagHor != 0) && (flagVer != 0))  flafDiag = 0.7f; 

		//rb.MovePosition (rb.position +(Vector2.right*mX*speed+ Vector2.up*mY*speed ) *Time.deltaTime);//*Time.deltaTime
		rb.MovePosition(rb.position + (Vector2.right * moveX * flagHor + Vector2.up * moveY * flagVer)*flafDiag*speed * Time.deltaTime);//*Time.deltaTime


		if (moveX>0 && !faceRight)
			flip();
		else if (moveX<0 && faceRight) flip();

		
	}

	void flip(){
		faceRight=!faceRight;
		//transform.Rotate(0f,180f,0f);
		//canv.GetComponent<RectTransform>().Rotate(0f, 180f, 0f);
		//canv2.GetComponent<RectTransform>().Rotate(0f, 180f, 0f);
		sr.flipX = !sr.flipX;
	}

	public void CanvasActiv()
	{
		canv.enabled = !canv.enabled;
	}

	public void CanvasActiv2()
	{
		canv2.enabled = !canv2.enabled;
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		//Debug.Log(coll.GetComponent<Transform>().localScale.x);
		_objInCollider.Add(coll);
		if (coll.tag == "talk_trigger")
		{
			count_tolk_pers++;
			if (count_tolk_pers == 1) CanvasActiv();
			//Debug.Log(count_tolk_pers);
		}
	}

	void OnTriggerExit2D(Collider2D coll)
	{
		_objInCollider.Remove(coll);
		if (coll.tag == "talk_trigger")
		{
			count_tolk_pers--;
			if (count_tolk_pers == 0) CanvasActiv();
		}
	}

}

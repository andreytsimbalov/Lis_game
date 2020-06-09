using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements.StyleEnums;

public class CamMove : MonoBehaviour {

	public GameObject player;
	private float xmax = 1000f;
	private float xmin = -1000f;
	private float ymax = 1000f;
	private float ymin = -1000f;
	static private float speed = 5f;

	private float dumping = speed;
	private Vector3 last_pos;// = new Vector3(0,0,0);

	
	private void Start()
	{
		last_pos = new Vector3(player.transform.position.x, player.transform.position.y, -10f);
		xmax = player.transform.position.x;
		xmin = player.transform.position.x;
		ymax = player.transform.position.y;
		ymin = player.transform.position.y;
	}


	void Update () {

		Vector3 new_pos = new Vector3(player.transform.position.x, player.transform.position.y, -10f);
		if (new_pos.x > xmax) new_pos.x = xmax;
		if (new_pos.x < xmin) new_pos.x = xmin;
		if (new_pos.y > ymax) new_pos.y = ymax;
		if (new_pos.y < ymin) new_pos.y = ymin;

		Vector3 os = new Vector3(new_pos.x - last_pos.x, new_pos.y - last_pos.y, -10f);
		//Vector3 q = player.transform.position;
		//Vector3 osp = new Vector3(new_pos.x-q.x,new_pos.y-q.y)

		//if (player.transform.position.x)
		//{

		//}

		float umn = 3.0f;

		if (Mathf.Sqrt((os.x) * (os.x) + (os.y) * (os.y)) > dumping*umn * Time.deltaTime)
		{
			//Debug.Log("error");
			//Debug.Log(Mathf.Sqrt((os.x) * (os.x) + (os.y) * (os.y))/Time.deltaTime);
			//Debug.Log(dumping * umn*Time.deltaTime);
			new_pos = Vector3.Lerp(last_pos, new_pos, dumping * Time.deltaTime);

			dumping = dumping + 1.0f;
		}
		else
		{
			dumping = speed;
			//Debug.Log("error1111");
		}

		//new_pos = Vector3.Lerp(last_pos, new_pos, 0.5f);

		transform.position = new_pos;
		last_pos = new_pos;


		HashSet<Collider2D> _objInCollider = player.GetComponent<PlayerController1>()._objInCollider;
		//HashSet<GameObject> _objInGO = player.GetComponent<PlayerController1>()._objInGO;

		//float xr = xmax;
		bool j_flag = true;
		foreach (Collider2D coll in _objInCollider)
		{
			
			if ((coll.isTrigger) && (coll.tag == "Camera_granica"))// чтобы пуля не реагировала на триггер
			{

				float xsize = coll.GetComponent<BoxCollider2D>().size.x;
				xsize = xsize * coll.GetComponent<Transform>().localScale.x;
				float ysize = coll.GetComponent<BoxCollider2D>().size.y;
				ysize = ysize * coll.GetComponent<Transform>().localScale.y;
				//float xr=0.0f;
				float xr = xsize / 2 + coll.GetComponent<Transform>().position.x;
				float xl = -xsize / 2 + coll.GetComponent<Transform>().position.x;
				float yt = ysize / 2 + coll.GetComponent<Transform>().position.y;
				float yb = -ysize / 2 + coll.GetComponent<Transform>().position.y;

				if (j_flag)
				{
					xmax = xr;
					ymax = yt;
					xmin = xl;
					ymin = yb;
					j_flag = false;
				}

				if (xr > xmax) xmax = xr;
				if (yt > ymax) ymax = yt;
				if (xl < xmin) xmin = xl;
				if (yb < ymin) ymin = yb;

				//Debug.Log(xmax);


			}
		}

	}

	//private void OnTriggerStay2D(Collider2D coll)
	//{
	//	Debug.Log(xmax);
	//	Debug.Log(coll.tag);
	//	if (coll.isTrigger) // чтобы пуля не реагировала на триггер
	//	{
	//		if (coll.tag == "Camera_granica")
	//		{
	//			xmax = coll.GetComponent<BoxCollider2D>().size.x;
	//			Debug.Log(xmax);
	//			xmax = xmax / 2 + coll.GetComponent<Transform>().position.x;

	//			Debug.Log(xmax);
	//		}




	//	}
	//}

}

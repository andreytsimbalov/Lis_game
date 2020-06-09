using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class DialogInitialize : MonoBehaviour
{
    public Canvas canv;
    private Canvas c1;
    

    public void InitDial()
    {
        //Debug.Log(123123123123);
        c1=Instantiate(canv);
        
        Vector2 offset = new Vector2(0, c1.transform.localScale.y/2 + 4);
        Vector2 selfpos2 = new Vector2(transform.position.x, transform.position.y);
        //Debug.Log(selfpos2);
        c1.transform.position = selfpos2 + offset;
    }

    public void DestrDial()
    {
    
        Destroy(c1,.0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //Debug.Log(c1);

        if(collision.tag == "Player")
        {
            InitDial();
        }
        
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            DestrDial();
        }
        
    }

}

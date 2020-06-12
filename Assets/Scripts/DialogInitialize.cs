using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.UI;

public class DialogInitialize : MonoBehaviour
{
    public Canvas canv;
    private Canvas c1;
    public Dialog dialogGetted;
    private Text nameText;
    private Text mainText;
    private Queue<string> sentenses;
    private bool playerAroundMe = false;

    private void Start()
    {
        sentenses = new Queue<string>();

        string jsonOne = JsonUtility.ToJson(dialogGetted);
        Debug.Log("диалоговое окно");
        Debug.Log(jsonOne);

        //PlayerPrefs.SetString("MyJsoneFile", jsonOne);
        //PlayerPrefs.Save();

        //string jsonData = PlayerPrefs.GetString("MyJsoneFile");
        //dialogGetted = JsonUtility.FromJson<Dialog>(jsonData);
        //Debug.Log(dialogGetted.name);
    }
    public void InitDialWithText(Dialog dialog)
    {
        //Debug.Log(123123123123);
        c1 = Instantiate(canv);

        Vector2 offset = new Vector2(0, c1.transform.localScale.y / 2 + 4);
        Vector2 selfpos2 = new Vector2(transform.position.x, transform.position.y);
        c1.transform.position = selfpos2 + offset;

        Image image = c1.GetComponentInChildren<Image>();
        nameText = image.GetComponentsInChildren<Text>()[0];
        mainText = image.GetComponentsInChildren<Text>()[1];
        Debug.Log(dialog.name);

        nameText.text = dialog.name;

        sentenses.Clear();
        foreach (string sent in dialog.sentenses)
        {
            sentenses.Enqueue(sent);
        }
        DisplayNextSent();

      
    }


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
        playerAroundMe = false;
        Destroy(c1,.0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            playerAroundMe = true;
            InitDialWithText(dialogGetted);
            //InitDial();
        }
        
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerAroundMe = false;
            DestrDial();
        }
        
    }

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.E)) && (playerAroundMe))
        {
            if (c1 != null) 
            { 
            DisplayNextSent();
            }
        }
    }


    public void DisplayNextSent()
    {
        if (sentenses.Count == 0)
        {
            EndDialog();
            return;
        }

        string sent = sentenses.Dequeue();

        mainText.text = sent;
    }

    public void EndDialog()
    {
        Debug.Log("End dialog");

        DestrDial();
    }

}

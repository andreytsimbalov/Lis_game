//using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Text nameText;
    public Text dialText;

    private Queue<string> sentenses;
    void Start()
    {
        sentenses = new Queue<string>();
    }

    public void StartDialog(Dialog dialog)
    {
        Debug.Log(dialog.name);
        sentenses.Clear();
        nameText.text = dialog.name;

        foreach (string sent in dialog.sentenses)
        {
            sentenses.Enqueue(sent);

        }
        DisplayNextSent();
    }

    public void DisplayNextSent()
    {
        if (sentenses.Count == 0)
        {
            EndDialog();
            return;
        }

        

        string sent = sentenses.Dequeue();
        //if (sent == sentenses.)
        //{

        //}

        Debug.Log(sent);
        dialText.text = sent;
    }

    public void EndDialog()
    {
        Debug.Log("End dialog");
        //Destroy(gameObject, .7f);
    }

}

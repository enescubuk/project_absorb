using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class FirstDialog : MonoBehaviour
{
    public DialogManager DialogManager;
    private void Awake()
    {
        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData("Welcome to our Inye Camp Soldier.", "General"));
        
        //For Selection
        var Text2 = new DialogData("Are you tired?");
        Text2.SelectList.Add("Correct", "Yes");
        Text2.SelectList.Add("Wrong", "No");
        Text2.SelectList.Add("Whatever", "Not your business");

        Text2.Callback = () => Check_Correct();

        dialogTexts.Add(Text2);
        //
        dialogTexts.Add(new DialogData("Anyway, You can visit /color:red/tents /color:white/to meet your commanders. They will help you."));

        DialogManager.Show(dialogTexts);
    }

    private void Check_Correct()
    {
        if(DialogManager.Result == "Correct")
        {
            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData("You should'nt."));

            DialogManager.Show(dialogTexts);
        }
        else if (DialogManager.Result == "Wrong")
        {
            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData("Good."));

            DialogManager.Show(dialogTexts);
        }
        else
        {
            var dialogTexts = new List<DialogData>();

            dialogTexts.Add(new DialogData("You need to be careful on your words!"));

            DialogManager.Show(dialogTexts);
        }
    }
}

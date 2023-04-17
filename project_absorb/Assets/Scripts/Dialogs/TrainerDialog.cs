using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class TrainerDialog : MonoBehaviour
{
    public DialogManager DialogManager;

    List<DialogData> dialogTexts;

    bool close;
    public void FirstTrainerDialog()
    {
        dialogTexts = new List<DialogData>();
        
        dialogTexts.Add(new DialogData("Hey, you are my new trainee right?" , "Trainer"));

        dialogTexts.Add(new DialogData("Take a look at your cards."));

        dialogTexts.Add(new DialogData("Just click /color:red/my tent."));

        DialogManager.Show(dialogTexts);
        
    }

    public void Close()
    {
        //dialogTexts.Add(new DialogData("/close/"));

        //DialogManager.Show(dialogTexts);
        
        dialogTexts.Clear();

        DialogManager.Hide();

        DialogManager.Show(dialogTexts);
    }
}

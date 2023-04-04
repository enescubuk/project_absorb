
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class StoryEvents : MonoBehaviour
{
    [SerializeField] Button button1;// => transform.GetChild(0).gameObject.GetComponent<Button>();
    [SerializeField] Button button2; //=> transform.GetChild(1).gameObject.GetComponent<Button>();

    [SerializeField] TMP_Text storyText;
    [SerializeField] public TMP_Text optionOne;
    [SerializeField] TMP_Text optionTwo;


    bool clickedButton1, clickedButton2;

    public List<IFunction> functionList = new List<IFunction>();

    void Start()
    {


        GetEvent();
    }

    public void GetEvent()
    {
        FunctionA funcA = new FunctionA();

        functionList.Add(funcA);

        // Choose random event from list
        IFunction theEvent = functionList[Random.Range(0,functionList.Count)];

        //Assign values
        theEvent.Assign();
        storyText.text = theEvent.texts[0];
        optionOne.text = theEvent.texts[1];
        optionTwo.text = theEvent.texts[2];


    }
    public void ButtonOne()
    {
        functionList[0].OptionOne();
    }
    public void ButtonTwo()
    {
        functionList[0].OptionTwo();
    }
    
}
public interface IFunction
{
    void OptionOne();
    void OptionTwo();
    void Assign();
    string[] texts { get; set; }
}  

public class FunctionA : IFunction
{
    string storyText = "You saw a wierd statue. What will you do?";
    string optionOneText = "Look at the statue \n <color=blue>" + "(Gain 10 HP) " + "</color>";
    string optionTwoText = "Stay out";

    public string[] texts { get; set; }
    public void OptionOne()
    {
        GameManager.current.playerHp += 10;
        RoomScript.current.NewWave(0);
        GameManager.current.storyEvent.SetActive(false);
        GameManager.current.storyEventTurn = false;
    }

    public void OptionTwo()
    {
        Debug.Log(optionTwoText);
        RoomScript.current.NewWave(0);
        GameManager.current.storyEvent.SetActive(false);
        GameManager.current.storyEventTurn = false;
    }
    public void Assign()
    {
        texts = new string[3];
        texts[0] = storyText;
        texts[1] = optionOneText;
        texts[2] = optionTwoText;
    }
}

public class FunctionB : IFunction
{
    string storyText = "Gem";
    string optionOneText = "One";
    string optionTwoText = "Two";

    public string[] texts {get; set;}
    public void OptionOne()
    {

    }

    public void OptionTwo()
    {

    }
    public string Apply()
    {
        return storyText;
    }
    public void Assign()
    {
        texts[0] = storyText;
        texts[1] = optionOneText;
        texts[2] = optionTwoText;
    }
}


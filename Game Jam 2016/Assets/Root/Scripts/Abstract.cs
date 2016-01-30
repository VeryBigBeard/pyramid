using UnityEngine;
using System.Collections;

public class Abstract : MonoBehaviour {

    public int score;   // Remember to change to private
    public int coins;   // Remember to change to private


    // GUI sizes
    private int ScreenX;
    private int ScreenY;
    private int labelX;
    private int labelY;
    private int gap;

    private string inputText;
    private string warningMsg;


    private GUIStyle skin;


    private bool chestGUI;
    private bool withdrawActive;
    private bool depositActive;
    private bool submit;


    private GameObject chest;

    // Use this for initialization
    void Start () {
        submit = false;
        inputText = "";
        warningMsg = "";
        withdrawActive = false;
        depositActive = false;
        gap = 50;
        labelX = 100;
        labelY = 50;
        chestGUI = false;
        chest = null;
        ScreenX = Screen.width;
        ScreenY = Screen.height;
        skin = new GUIStyle();
        skin.fontSize = 40;
        skin.alignment = TextAnchor.MiddleCenter;
        //style.fontSize = 40;
        //texture.
    }
	
	// Update is called once per frame
	void Update () {

    }

    void OnGUI()
    {


        //GUI.color = Color.black;
        //skin.label.fontSize = 40;
        skin.normal.textColor = Color.black;
        skin.fontSize = 40;
        GUI.Label(new Rect(ScreenX * 3 / 4, ScreenY * 1/10, labelX, labelY), coins.ToString(), skin);
        

        if(chestGUI)
        {
            GUI.Box(new Rect(ScreenX * 1/4, ScreenY * 1/6, ScreenX * 1/2, ScreenY * 4/6), "");
            skin.normal.textColor = Color.white;
            GUI.Label(new Rect((ScreenX * 1 / 2) - (labelX/2), (ScreenY * 1 / 6) + (labelY/2) + gap, labelX, labelY), "Chest\n" +
                                    "Coins: " + chest.GetComponent<Chest>().getCoins()
                                    , skin);


            GUI.skin.button.fontSize = 40;
            if (GUI.Button(new Rect((ScreenX * 1 / 2) - (labelX) - 3 * gap, (ScreenY * 3 / 6), 2*labelX, 2*labelY), "Deposit"))
            {
                depositActive = true;
            }
            if(GUI.Button(new Rect((ScreenX * 1 / 2) - (labelX) + 3 * gap, (ScreenY * 3 / 6), 2 * labelX, 2 * labelY), "Withdraw"))
            {
                withdrawActive = true;
            }

            if(depositActive || withdrawActive)
            {
                Event e = Event.current;
                if (e.keyCode == KeyCode.Return)
                {
                    submit = true;

                    int num = int.Parse(inputText); // Can cause FormatException

                    inputText = "";

                    // Logic
                    if (depositActive)
                    {
                        if (num <= coins)
                        {
                            coins -= num;
                            chest.GetComponent<Chest>().depositCoins(num);
                        }
                        else
                        {
                            warningMsg = "Not enough coins!";
                        }
                    } else if(withdrawActive)
                    {
                        int resp = chest.GetComponent<Chest>().withdrawCoins(num);
                        if (resp == -1)
                            warningMsg = "Not enough coins in the chest!";
                        else
                        {
                            coins += num;
                        }
                    }

                    submit = false;
                    depositActive = false;
                    withdrawActive = false;

                }
                else if (!submit)
                {
                    GUI.skin.textField.fontSize = 40;
                    inputText = GUI.TextField(new Rect((ScreenX * 1 / 2) - (2 * labelX), (ScreenY * 1 / 2) - (labelY / 2), 4 * labelX, labelY), inputText);
                }

            }

            skin.normal.textColor = Color.red;
            skin.fontSize = 20;
            GUI.Label(new Rect((ScreenX * 1 / 2) - (labelX / 2), (ScreenY * 3 / 4), labelX, labelY), warningMsg, skin);

            //GUI.Label(new Rect((ScreenX * 1 / 2) - (labelX/2), (ScreenY * 1 / 6) + (labelY) + gap, labelX, labelY), "Coins: " + chest.GetComponent<Chest>().getCoins(), skin);
        } else
        {
            submit = false;
            depositActive = false;
            withdrawActive = false;
        }

    }

    public void addScore(int points)
    {
        score += points;
    }

    public int getScore()
    {
        return score;

    }

    public void addCoins(int number)
    {
        coins += number;
    }

    public int getCoins()
    {
        return coins;
    }

    public void setChestGUI(bool value, GameObject chestValue)
    {
        chestGUI = value;
        chest = chestValue;
    }
}

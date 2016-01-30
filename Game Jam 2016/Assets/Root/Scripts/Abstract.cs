using UnityEngine;
using System.Collections;

public class Abstract : MonoBehaviour {

    private int score;
    private int coins;


    // GUI sizes
    private int ScreenX;
    private int ScreenY;
    private int labelX;
    private int labelY;
    private int gap;

    // Timer variables
    private int timeLeft;
    private float realTime = 240;

    private string inputText;
    private string warningMsg;


    private GUIStyle skin;

    public Texture coinTexture;

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
        realTime -= Time.deltaTime;
        timeLeft = (int) realTime;
        if(timeLeft <= 0)
        {
            // Death logic
        }
    }

    void OnGUI()
    {


        //GUI.color = Color.black;
        //skin.label.fontSize = 40;
        skin.normal.textColor = Color.black;
        skin.fontSize = 40;
        GUI.Label(new Rect(ScreenX * 3 / 4, ScreenY * 1 / 10 - labelY, labelX, labelY), score.ToString(), skin);
        GUI.Label(new Rect(ScreenX * 1 / 8, ScreenY * 1 / 10 - labelY, labelX, labelY), (int)(timeLeft/60) +
            ":" +
            (int)timeLeft%60
            , skin);
        skin.fontSize = 30;
        GUI.DrawTexture(new Rect(ScreenX * 3 / 4 - 25, ScreenY * 1 / 10 + gap/2, 50, 50), coinTexture);
        GUI.Label(new Rect(ScreenX * 3 / 4, ScreenY * 1/10 + gap/2, labelX, labelY), "x " + coins.ToString(), skin);
       


        if (chestGUI)
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

                    warningMsg = "";
                    submit = false;
                    depositActive = false;
                    withdrawActive = false;

                }
                else if (!submit)
                {
                    GUI.skin.textField.fontSize = 40;
                    inputText = GUI.TextField(new Rect((ScreenX * 1 / 2) - (2 * labelX), (ScreenY * 1 / 2) - (labelY / 2) - gap, 4 * labelX, labelY), inputText);
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
            warningMsg = "";
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

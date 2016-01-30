using UnityEngine;
using System.Collections;

public class Abstract : MonoBehaviour {

    public int score;   // Remember to change to private
    public int coins;   // Remember to change to private
    private GameObject abs;
    private int ScreenX;
    private int ScreenY;
    private GUIStyle skin;
    private Texture2D texture;

    // Use this for initialization
    void Start () {
        ScreenX = Screen.width;
        ScreenY = Screen.height;
        abs = GameObject.FindWithTag("Abstract");
        skin = new GUIStyle();
        //style.fontSize = 40;
        texture = new Texture2D(50, 50);
        //texture.
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {


        GUI.color = Color.black;
        //skin.label.fontSize = 40;
        skin.fontSize = 40;
        GUI.Label(new Rect(ScreenX * 3 / 4, ScreenY * 1/10, 100, 50), abs.GetComponent<Abstract>().getCoins().ToString(), skin);
        

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
}

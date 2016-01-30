using UnityEngine;
using System.Collections;

public class Chest : MonoBehaviour {

    private bool interactable;
    private GameObject abs;
    private int coinsStored;

	// Use this for initialization
	void Start () {
        abs = GameObject.FindWithTag("Abstract");
        interactable = false;
	}
	
	// Update is called once per frame
	void Update () {

        //print(coinsStored);

	}

    public void depositCoins(int coins)
    {
        print("Coins: " + coins);
        coinsStored += coins;
        print("Coins stored: " + coinsStored);
    }

    public int withdrawCoins(int coins)
    {
        if (coins > coinsStored) return -1;
        else {
            coinsStored -= coins;
            return 0;
        }
    }

    public int getCoins()
    {
        return coinsStored;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            interactable = true;
            abs.GetComponent<Abstract>().setChestGUI(true, gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            interactable = false;
            abs.GetComponent<Abstract>().setChestGUI(false, null);
        }
    }
}

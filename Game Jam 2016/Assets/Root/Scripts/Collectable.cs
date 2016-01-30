using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour {

    //public float distanceToCollect;
    public int scoreValue;
    public int coinValue;
    private GameObject player;
    private GameObject abs;

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
        abs = GameObject.FindWithTag("Abstract");
	}
	
	// Update is called once per frame
	void Update () {
        //print("Distance: " + Vector3.Distance(transform.position, player.transform.position));
	}

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            abs.GetComponent<Abstract>().addScore(scoreValue);
            abs.GetComponent<Abstract>().addCoins(coinValue);
            Destroy(gameObject);
        }

    }


}

using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public float speed;
    public float jumpForce;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * speed, 0, 0);


        if(Input.GetKeyDown(KeyCode.Space) && GetComponent<Rigidbody2D>().velocity.y == 0)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
        
    }
}

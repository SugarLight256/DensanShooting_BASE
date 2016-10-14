using UnityEngine;
using System.Collections;

public class preBull : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(transform.position.y <= -10)
        {
            Destroy(transform.gameObject);
        }
        transform.position += new Vector3(0,-0.2f, 0);
	}
}

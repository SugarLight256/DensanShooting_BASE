using UnityEngine;
using System.Collections;

public class preBull : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(transform.position.y <= -10 || transform.position.y >= 10 || transform.position.x <= -15 || transform.position.x >= 15)
        {
            Destroy(transform.gameObject);
        }
        Vector3 delta = -transform.up * speed * Time.deltaTime;
        transform.position += delta;
	}
}

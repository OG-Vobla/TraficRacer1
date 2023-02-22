using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteZoneScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	private void OnTriggerEnter2D(Collider2D collision)
	{
        
        Debug.Log("dsfg");
        collision.transform.position = new Vector2(collision.transform.position.x,7.6f);
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
        Debug.Log("sdf");
		collision.transform.position = new Vector2(collision.transform.position.x, 7.6f);
	}
}

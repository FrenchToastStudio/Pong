using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raquette : MonoBehaviour
{
	public float speed = 8;
	private double vitesse = 0.08;
	private Rigidbody rb;
	public string axis = "Vertical";
	
	
   	 // Start is called before the first frame update
   	 void Start()
   	 {
		rb = GetComponent<Rigidbody>();		
	}

   	 // Update is called once per frame
   	 void Update()
    	{
		/*Vector3 position = this.transform.position;
		if (Input.GetKey(KeyCode.S)){
    			position.y = position.y - (float)vitesse;
    			this.transform.position = position;
		}
		if (Input.GetKey(KeyCode.W)){
    			position.y = positio	n.y + (float)vitesse;
    			this.transform.position = position;
		} */
		float moveVertical = Input.GetAxis(axis);
		
		 GetComponent<Rigidbody2D>().velocity = new Vector2(0, moveVertical) * speed;

	
	}
}
	

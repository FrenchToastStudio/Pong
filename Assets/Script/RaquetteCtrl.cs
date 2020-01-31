using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaquetteCtrl : MonoBehaviour
{
	public string axis = "Vertical";
	private float speed = 0.25f;
	private bool bouge = true;
	private bool borderTouche;
   	 // Start is called before the first frame update
   	 void Start()
   	 {
		}

   	 // Update is called once per frame
   	 void Update(){

		 if(borderTouche == false && Input.GetAxisRaw(axis) < 0){
			 speed = 0.25f;
			 borderTouche = true;
		 } if(borderTouche == true && Input.GetAxisRaw(axis) > 0){
			 speed = 0.25f;
			 borderTouche = false;
		 }


			Vector2 position = this.transform.position;
	    	position.y += Input.GetAxisRaw(axis) * speed;
	    	this.transform.position = position;
		//  GetComponent<Rigidbody2D>().velocity = new Vector2(0, moveVertical) * speed;
	}

	void OnTriggerEnter2D(Collider2D col){

		//arrete la raquette si elle touche les bordures
		if(col.gameObject.name == "BorderUp"){
			speed = 0;
			borderTouche = false;
		} else if(col.gameObject.name == "BorderDown"){
			speed = 0;
			borderTouche = true;
		}
	}

}

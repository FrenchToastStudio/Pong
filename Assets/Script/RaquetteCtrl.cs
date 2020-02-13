using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaquetteCtrl : MonoBehaviour
{
	public string axis = "Vertical";
	private float speed = 0.25f;
	private bool bouge = true;
	private float maxY;
	private float minY;
	private float tailleRaquette;

   	 // Start is called before the first frame update
   	 void Start()
   	 {
		 GameObject border;
		 Vector2 positionBorder;
		 tailleRaquette = GetComponent<Collider2D>().bounds.size.y;

		 //positon y de la bordure du haut
		 border = GameObject.Find("BorderUp");
		 positionBorder = border.transform.position;
		 maxY = positionBorder.y - border.GetComponent<Collider2D>().bounds.size.y/2;

		 //position y de la bordure du bas;
		 border = GameObject.Find("BorderDown");
		 positionBorder = border.transform.position;
		 minY = positionBorder.y + border.GetComponent<Collider2D>().bounds.size.y/2;
		}

   	 // Update is called once per frame
   	 void Update(){
		 Vector2 position = this.transform.position;
		 float hautRaquette = position.y +  tailleRaquette/2;
		 float basRaquette = position.y -  tailleRaquette/2;

		 //verifie si la raquette touche le haut
		 if(hautRaquette >= maxY){
			 position.y = maxY - tailleRaquette/2;
		 }
		 if (basRaquette <= minY) {
			 position.y = minY + tailleRaquette/2;
		 }

	    	position.y += Input.GetAxisRaw(axis) * speed;
	    	this.transform.position = position;
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BalleCtrl : MonoBehaviour
{
    public float speed = 5f;
    private bool bouge = false;
    private float difficulte = 0.5f;
    private float angleRebondMax= 0.75f;
    private float directionY = 0f;
    private float directionX = 0.1f;
    private Pointage pointJoueurs;
        // Start is called before the first frame update
        void Start(){

            pointJoueurs = new Pointage();

            float nombreGenere = Random.Range(0f, 1f);
            if(nombreGenere > 0.5f){
            Debug.Log(nombreGenere);
                directionX = -directionX;
            }
        }

    // Update is called once per frame
    void Update(){

        //lance la balle au debute de la partie
        if(Input.GetKey(KeyCode.Space)){
            bouge = true;
        }
        //Reajuste la postione de la balle a chaque FPS
        Vector2 position = this.transform.position;
        if (bouge){

            //genere aleatoirement un cnhifre qui decide quelle joeur commence si
            //si la partie n'a pas encore commencer

            position.x += directionX;
            position.y += directionY * directionX;
            this.transform.position = position;

            Debug.Log("speed: " + speed);
            Debug.Log("direction X : " + directionX);
            Debug.Log("difficulte : " + difficulte);
        }

    }

    void OnTriggerEnter2D(Collider2D col){
        Debug.Log("all good");

        //si la balle frappe la Raquette de droite
         if(col.gameObject.tag == "RaquetteDroite"){

             //accelere la balle
             speed += speed * difficulte;

             //calcule la direction a l'horizontale
             directionX = (directionX + speed) * -1;

             //calcule la direction  a prendre a la verticale
             Vector2 position = this.transform.position;
             //calcluer ourenvoyer la balle
             directionY = balleRenvoyer(position, col.transform.position, col.bounds.size.y) * -1;
             Debug.Log(directionY);
         }

         //si la balle frappe la Raquette de Gauche
         if(col.gameObject.tag == "RaquetteGauche"){

             //accelere la balle
             speed += speed * difficulte;

             //calcule la direction a l'horizontale
             directionX = -directionX + speed;

             //calcule la direction  a prendre a la verticale
             Vector2 position = this.transform.position;
            //calcule la direction  a prendre a la verticale
            directionY = balleRenvoyer(position, col.transform.position, col.bounds.size.y);
         }


         //Reagi si la balle frappe la limite du terrai
         if(col.gameObject.tag== "border"){
             directionY = -directionY;
         }

         //ajoute les points au joueur de droite et renvoie la balle au joueur de gauche
         if(col.gameObject.name == "GoalRight"){
             pointJoueurs.AjouterPointJoueurGauche();
             GameObject.Find("Canvas/PointJoueurGauche").GetComponent<UnityEngine.UI.Text>().text = pointJoueurs.pointJoueurGauche.ToString();
             resetBalle();
         }
         //ajoute les points au joeur de gauche et renvoie la balle au joueur de droite
         if(col.gameObject.name == "GoalLeft"){
             pointJoueurs.AjouterPointJoueurDroite();
             GameObject.Find("Canvas2/PointJoueurDroite").GetComponent<UnityEngine.UI.Text>().text = pointJoueurs.pointJoueurDroite.ToString();
             resetBalle();
             directionX = -directionX;
         }

     }


   //renvoie l'angle ou il faut renvoyer la balle
   //(si negatif il faut renvoyer par en bas vice-versa)

   float balleRenvoyer(Vector2 positionBalle, Vector2 positionRaquette, float tailleRaquette){
       return (positionBalle.y - positionRaquette.y)/tailleRaquette * angleRebondMax;
   }

   //Reset la balle au centre
   void resetBalle(){
       Vector2 position = this.transform.position;
       bouge = false;
       position.y = 0;
       position.x = 0;
       directionY = 0;
       directionX = 0.1f;
       speed = 0.05f;
       difficulte = 0.5f;
       angleRebondMax = 0.75f;
       this.transform.position = position;
   }
}

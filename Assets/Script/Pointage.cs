
public class Pointage
{
    public int pointJoueurGauche{
        get;
        set;
    }
    public int pointJoueurDroite{
        get;
        set;
    }

    public void AjouterPointJoueurDroite(){
        pointJoueurDroite += 1;
    }

    public  void AjouterPointJoueurGauche(){
        pointJoueurGauche += 1;
    }
}

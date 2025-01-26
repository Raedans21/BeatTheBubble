using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    [SerializeField] GameObject Auto;
    [SerializeField] GameObject energy;
    [SerializeField] GameObject aerospace;
    [SerializeField] GameObject fashion;
    [SerializeField] GameObject entertainment;
    [SerializeField] GameObject tech;
    [SerializeField] GameObject realEstate;
    [SerializeField] GameObject health;

    



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        

        Auto.SetActive(true);
        energy.SetActive(false);
        aerospace.SetActive(false);
        fashion.SetActive(false);
        entertainment.SetActive(false);
        tech.SetActive(false);
        realEstate.SetActive(false);
        health.SetActive(false);


    }

    public void AutoSelected() {

     
            Auto.SetActive(true);
            energy.SetActive(false);
            aerospace.SetActive(false);
            fashion.SetActive(false);
            entertainment.SetActive(false);
            tech.SetActive(false);
            realEstate.SetActive(false);
            health.SetActive(false);
        
    }
      public void energySelected() {

        
            Auto.SetActive(false);
            energy.SetActive(true);
            aerospace.SetActive(false);
            fashion.SetActive(false);
            entertainment.SetActive(false);
            tech.SetActive(false);
            realEstate.SetActive(false);
        health.SetActive(false);
            
        
       
    }
      public void aerospaceSelected() {
        
            Auto.SetActive(false);
            energy.SetActive(false);
            aerospace.SetActive(true);
            fashion.SetActive(false);
            entertainment.SetActive(false);
            tech.SetActive(false);
            realEstate.SetActive(false);
            health.SetActive(false);

           
        
    }
      public void fashionSelected() {
        
            Auto.SetActive(false);
            energy.SetActive(false);
            aerospace.SetActive(false);
            fashion.SetActive(true);
            entertainment.SetActive(false);
            tech.SetActive(false);
            realEstate.SetActive(false);
            health.SetActive(false);


    }
      public void entertainmentSelected() {
        
            Auto.SetActive(false);
            energy.SetActive(false);
            aerospace.SetActive(false);
            fashion.SetActive(false);
            entertainment.SetActive(true);
            tech.SetActive(false);
            realEstate.SetActive(false);
            health.SetActive(false);


    }
      public void techSelected() {
        
            Auto.SetActive(false);
            energy.SetActive(false);
            aerospace.SetActive(false);
            fashion.SetActive(false);
            entertainment.SetActive(false);
            tech.SetActive(true);
            realEstate.SetActive(false);
            health.SetActive(false);


    }
      public void realEstateSelected() {



            Auto.SetActive(false);
            energy.SetActive(false);
            aerospace.SetActive(false);
            fashion.SetActive(false);
            entertainment.SetActive(false);
            tech.SetActive(false);
            realEstate.SetActive(true);
            health.SetActive(false);




    }
      public void healthSelected() {
        
            Auto.SetActive(false);
            energy.SetActive(false);
            aerospace.SetActive(false);
            fashion.SetActive(false);
            entertainment.SetActive(false);
            tech.SetActive(false);
            realEstate.SetActive(false);
            health.SetActive(true);


    }
     

}

using UnityEngine;

public class sAuraMouse : MonoBehaviour
{
  
    [SerializeField] Renderer rAura;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rAura.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
       

    }

    void OnMouseEnter()
    {

            rAura.enabled = true;

      


    }

        void OnMouseExit()


        {
            rAura.enabled=false;


        }




}

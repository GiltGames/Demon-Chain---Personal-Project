using UnityEngine;

public class sEnemy : MonoBehaviour
{
    public float vHealth;
    public float vHealthMax;
    [SerializeField] Transform oHealth;
    public float vForceArmour;
    public float vFireArmour;
    public float vLightningArmour;
    public float vFrostArmour;


    // resist is range 0 to 1
    public float vForceResist;
    public float vFireResist;
    public float vLightningResist;
    public float vFrostResist;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        oHealth = transform.Find("Health");
        vHealth = vHealthMax;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (vHealth <= 0)

        {

            pDead();


        }


    }

    public void pDead()
    {

        Destroy(gameObject);

    }

    public void pHit()

    {




        oHealth.localScale = new Vector3(vHealth / vHealthMax, 1, 1);


    }


}

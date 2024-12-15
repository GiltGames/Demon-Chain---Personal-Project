using UnityEngine;

public class sDemonHit : MonoBehaviour
{

    sDemonMove sDemonMove;
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sDemonMove = GameObject.Find("Demon").GetComponent<sDemonMove>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
        
        if (collision.gameObject.tag == "Enemy")
        {
            
            sEnemy sEnemy = collision.gameObject.GetComponent<sEnemy>();

            Debug.Log(sEnemy.vHealth);

            sEnemy.vHealth = sEnemy.vHealth - (sDemonMove.vDamageForceTmp - sEnemy.vForceArmour) / (1-sEnemy.vForceResist);
            sEnemy.vHealth = sEnemy.vHealth - (sDemonMove.vDamageFireTmp - sEnemy.vFireArmour) / (1-sEnemy.vFireResist);
            sEnemy.vHealth = sEnemy.vHealth - (sDemonMove.vDamageLightningTmp - sEnemy.vLightningArmour) / (1-sEnemy.vLightningResist);
            sEnemy.vHealth = sEnemy.vHealth - (sDemonMove.vDamageFrostTmp - sEnemy.vFrostArmour) / (1-sEnemy.vFrostResist);

            sEnemy.pHit();
            sDemonMove.vDemonMoveState = 2;
        }
    }

}

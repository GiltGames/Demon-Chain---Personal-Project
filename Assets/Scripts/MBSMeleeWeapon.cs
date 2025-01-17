using System.Collections;
using UnityEngine;

public class MBSMeleeWeapon : MonoBehaviour
{

    [SerializeField] float vWeaponDamage;
    [SerializeField] MBSPlayerHealth MBSPlayerHealth;
    [SerializeField] MBSEnemyMove MBSEnemyMove;
    [SerializeField] bool isCapableofHurting;
    [SerializeField] Vector3 vWeaponAngleEuler;
    [SerializeField] Vector3 vWeaponReadyAngleEuler = new Vector3(0,270,0);
    [SerializeField] Vector3 vWeaponEndAngleEuler;
    [SerializeField] Vector3 vWeaponNeutralAngleEuler;
    [SerializeField] float vWeaponReadySpeed;
    [SerializeField] float vWeaponStrikeSpeed;
    [SerializeField] GameObject gRightHand;
    [SerializeField] string vStatusTmp;
    [SerializeField] int vStatus;
    [SerializeField] bool isAttacking;
    [SerializeField] float vTol;
    //Tolerance for the overswing on angles
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Start()
    {
        MBSPlayerHealth = FindFirstObjectByType<MBSPlayerHealth>();
        isCapableofHurting = false;


    }

    private void Update()
    {
        if (isAttacking)
        { FnWeaponAttack(); }

        //Debuging...
        vWeaponAngleEuler = gRightHand.transform.localEulerAngles;

        if (Input.GetKeyDown(KeyCode.P))
        {
            vStatus = 1;
            vStatusTmp = "Pressed";
            isAttacking = true;
                
                
                }


    }






    void FnWeaponAttack()
    {
        //ready weapon
    
        {
            switch (vStatus)
            {
                case 1:

                    if (vWeaponAngleEuler.y  < vWeaponReadyAngleEuler.y)
                    {
                        vWeaponAngleEuler.y += vWeaponReadySpeed * Time.deltaTime;
                        vStatusTmp = "Readying";
                        FnMoveWeapon();

                    }
                    else
                    {
                        vStatus = 2;
                    }

                    break;
                case 2:


                    isCapableofHurting = true;

                    if (vWeaponAngleEuler.y < (vWeaponReadyAngleEuler.y+vTol) || vWeaponAngleEuler.y > vWeaponEndAngleEuler.y)
                    {

                        vWeaponAngleEuler.y -= vWeaponStrikeSpeed * Time.deltaTime;
                        FnMoveWeapon();
                        vStatusTmp = "striking";
                    }

                    else
                    {
                        vStatus = 3;

                    }
                    break;
                case 3:

                    isCapableofHurting = false;

                    if (vWeaponAngleEuler.y < vWeaponNeutralAngleEuler.y  || vWeaponAngleEuler.y > (vWeaponReadyAngleEuler.y+vTol))
                    {
                        vWeaponAngleEuler.y += vWeaponReadySpeed * Time.deltaTime;
                        vStatusTmp = "Recover";
                        FnMoveWeapon();
                    }

                    else
                    {
                        vStatus = 0;
                        isAttacking = false;
                        

                    }
                    break;


                    

            }
        }
        
    }

    private void FnMoveWeapon()
    {
        gRightHand.transform.localEulerAngles = vWeaponAngleEuler;


    }



    private void OnTriggerEnter(Collider other)
    {

        if (isCapableofHurting)
        {

            if (other.tag == "Player")

            {
                MBSPlayerHealth.vHealth -= vWeaponDamage;
                MBSEnemyMove.vMoveMode = 3;
                isCapableofHurting = false;


            }
        }
    }


}

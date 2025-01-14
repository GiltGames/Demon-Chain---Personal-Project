using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class MBSEnemyMove : MonoBehaviour
{
    [SerializeField] Transform vTarget;
    [SerializeField] Transform vPlayer;
    [SerializeField] float vSpeed;
    [SerializeField] float vTurnSpeed;
    [SerializeField] float vAcceleration;
    [SerializeField] float vStopDist;


    [SerializeField] int vBehaveType;
    [SerializeField] string[] sBehaveTypes;
    [SerializeField] float vDetectRange;
    [SerializeField] float vLoSRange;
   public int vMoveMode;
    [SerializeField] string[] sMoveTypes;

    [SerializeField] NavMeshAgent nAgent;
    [SerializeField] float vAboveGround;
    [SerializeField] string vRayCheck;
    [SerializeField] Vector3 vOffsetPlayer;
    [SerializeField] Transform gEyes;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nAgent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {

        // Move Mode

        switch (vMoveMode)
        {
            case 0:

                FnStill();

                break;

            case 1:

                FnActive();
                break;


            case 2:








                break;
        }


    }

    void FnStill()

    {
        vOffsetPlayer = vPlayer.transform.position - gEyes.transform.position;

        

        if (vOffsetPlayer.magnitude < vDetectRange || FnLoSCheck(vOffsetPlayer))
        
        
        {
            vMoveMode = 1;

            switch (vBehaveType)

            {
                case 0 : 
                    vTarget.position = vPlayer.position;
                    vTarget.position = new Vector3(vTarget.position.x, vAboveGround, vTarget.position.z);

                        break;


            }

            FnSetTarget(vTarget.position);

        }




    }


    void FnActive()
    {




    }


    void FnSetTarget(Vector3 vTargetTmp)
        {
        nAgent.enabled = true;
        nAgent.SetDestination(vTargetTmp);
        nAgent.acceleration = vAcceleration;
        nAgent.speed = vSpeed;
        nAgent.angularSpeed = vTurnSpeed;
        nAgent.stoppingDistance = vStopDist;


    }

    bool FnLoSCheck(Vector3 vOffsetTmp)
    {
        Physics.Raycast(gEyes.transform.position, vOffsetTmp, out RaycastHit hit, vLoSRange);
        Debug.DrawRay(gEyes.transform.position, vOffsetTmp);
        Debug.Log(hit);
        vRayCheck = hit.transform.name;

        // the ray hits the body which is the child of the player - so it has to be tagged for detection

            if(hit.transform.tag == "Player")


        {
            return true;
        }

        else {


            return false;

        }

    }



}

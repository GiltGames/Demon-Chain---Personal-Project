using UnityEngine;

public class sDemonMove : MonoBehaviour
{


    public int vDemonMoveState;
    public GameObject Hand;
    public GameObject Player;
    public float vFireSpeed;
    public float vFireSpeedMax = 100;
    public float vFireSpeedInc = 20;
    public float vMouseFire;
    public bool vMouseFireLetGo = false;
    public Rigidbody rb;
    public Vector3 vHomeDir;
    public float vDemonReturnSpeed;
    public float vDemonHomeVariance = 0.1f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        // Movestates 0, in hand  1 going out 2 coming back


        // if demon is recalled, no direction input

        if (vDemonMoveState == 0)
        {

           
            transform.rotation = Player.transform.rotation;
            transform.position = Hand.transform.position;
            rb.linearVelocity = Vector3.zero;
            MouseFire();

        }

       

        if (vDemonMoveState == 1)

        {
            MouseDirInput();
            MouseReturn();

        }


        if (vDemonMoveState == 2)

        {

            DemonReturn();

        }





    }


    void MouseDirInput()

    {





    }


    void MouseFire()
    {

      vMouseFire = Input.GetAxis("Fire1");

        if (vMouseFire > 0)
        {
            vFireSpeed = vFireSpeed + vFireSpeedInc * Time.deltaTime;

            if (vFireSpeed > vFireSpeedMax)
            {
                vFireSpeed = vFireSpeedMax;

            }
        }

        vMouseFireLetGo = Input.GetButtonUp("Fire1");

        if (vMouseFireLetGo)
        {

            vDemonMoveState = 1;
            rb.AddForce(transform.forward * vFireSpeed);
            vFireSpeed = 0;
        }



    }


    void MouseReturn()
    {

        if(Input.GetAxis("Fire1")>0)
        {
            vDemonMoveState = 2;
            rb.linearVelocity = Vector3.zero;
        }





    }


    void DemonReturn()
    {

        vHomeDir = (Hand.transform.position - transform.position);

        transform.LookAt(Hand.transform);

        if(vHomeDir.magnitude < vDemonHomeVariance)
        {
            vDemonMoveState = 0;
            transform.rotation = Quaternion.identity;
            transform.position = Hand.transform.position;
            rb.linearVelocity = Vector3.zero;
        }
        
        transform.position = transform.position + vHomeDir.normalized * vDemonReturnSpeed *Time.deltaTime;



    }


}

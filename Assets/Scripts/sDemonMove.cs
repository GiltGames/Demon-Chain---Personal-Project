
using Unity.VisualScripting;
using UnityEngine;

public class sDemonMove : MonoBehaviour
{


    public int vDemonMoveState;
    public GameObject Hand;
    public GameObject Player;
    public GameObject PowerMeter;
    public GameObject DemonLight1;
    public GameObject DemonLight2;
    public GameObject DemonLight3;
    public Light dL1;
    public Light dL2;
    public Light dL3;
    [SerializeField] ParticleSystem gDemonParticles;
    [SerializeField] float vDemonParticleSpeed;

    public float vDemonLightLevel;
    public float vDemonLightLevelMax;
    public float vLightset;
    public float vFireSpeed;
    public float vFireSpeedMax = 100;
    public float vFireSpeedInc = 20;
    public float vMouseFire;
    public bool vMouseFireLetGo = false;
    public Rigidbody rb;
    public Vector3 vHomeDir;
    public float vDemonReturnSpeed;
    public float vDemonHomeVariance = 0.1f;
    public float vMouseSensitityDemon=1;
    public float tSlowdown = 1f;
    public float vDamageForce;
    public float vDamageFire;
    public float vDamageLightning;
    public float vDamageFrostTmp;
    public float vDamageForceTmp;
    public float vDamageFireTmp;
    public float vDamageLightningTmp;
    public float vDamageFrost;
    public int vDemonType;

 



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        dL1 = DemonLight1.GetComponent<Light>();
        dL2 = DemonLight2.GetComponent<Light>();
        dL3 = DemonLight3.GetComponent<Light>();
        

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
        float vMouseX=Input.GetAxis("MouseX");
        float vMouseY = Input.GetAxis("MouseY");

        //direction change mechanism is to add vertical/horizontal force

        rb.AddForce(UnityEngine.Vector3.up*vMouseY*vMouseSensitityDemon*rb.linearVelocity.magnitude,ForceMode.Impulse);
        rb.AddForce(transform.right * vMouseX * vMouseSensitityDemon * rb.linearVelocity.magnitude, ForceMode.Impulse);





    }


    void MouseFire()
    {

      vMouseFire = Input.GetAxis("Fire1");

        if (vMouseFire > 0)
        {
            gDemonParticles.gameObject.SetActive(true);

            vFireSpeed = vFireSpeed + vFireSpeedInc * Time.deltaTime;

            if (vFireSpeed > vFireSpeedMax)
            {
                vFireSpeed = vFireSpeedMax;

            }

            vDemonLightLevel = vDemonLightLevelMax * (vFireSpeed / vFireSpeedMax);



            vLightset = vDemonLightLevel;
            var pMainTmp = gDemonParticles.GetComponent<ParticleSystem>().main;
            pMainTmp.startSpeed = vDemonLightLevel * vDemonParticleSpeed;

            pSetLight();

        }

        vMouseFireLetGo = Input.GetButtonUp("Fire1");

        if (vMouseFireLetGo)
        {

            vDemonMoveState = 1;
            rb.AddForce(transform.forward * vFireSpeed);
           


            switch (vDemonType)
            {
                case 0:
                    vDamageForceTmp = vDamageForce*vFireSpeed/vFireSpeedMax;


                    break;



            }

            vFireSpeed = 0;
        }



    }


    void MouseReturn()
    {

        if(Input.GetAxis("Fire1")>0)
        {
            vDemonMoveState = 2;
            rb.linearVelocity = UnityEngine.Vector3.zero;
            vLightset = 0;
            pSetLight();



        }





    }


    void DemonReturn()
    {

        vHomeDir = (Hand.transform.position - transform.position);

        var pMainTmp = gDemonParticles.GetComponent<ParticleSystem>().main;
        pMainTmp.startSpeed = 0;
        gDemonParticles.gameObject.SetActive(false);

        transform.LookAt(Hand.transform);

        if(vHomeDir.magnitude < vDemonHomeVariance)
        {
            vDemonMoveState = 0;
            transform.rotation = Quaternion.identity;
            transform.position = Hand.transform.position;
            rb.linearVelocity = Vector3.zero;
        }


        //reduce speed just before getting back
      
        if (vHomeDir.magnitude < vDemonHomeVariance*5)
        {
            tSlowdown =.3f;

        }
        
        

            transform.position = transform.position + vHomeDir.normalized * tSlowdown* vDemonReturnSpeed *Time.deltaTime;

        tSlowdown = 1;

    }

    void pSetLight()
    {
        dL1.intensity = vLightset;
        dL2.intensity = vLightset;
        dL3.intensity = vLightset;

    }

}

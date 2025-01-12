using UnityEngine;

public class aAuraMouse : MonoBehaviour
{
  
    [SerializeField] Renderer rAura;
    [SerializeField] Vector3 vOffset;
    [SerializeField] Vector3 vMousePoint;
    [SerializeField] Vector3 vMousePointNew;
    [SerializeField] float vXMove;
    [SerializeField] float vYMove;

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


 void OnMouseDown()
    {
        vOffset = transform.position;
        
        vMousePoint = Camera.main.WorldToScreenPoint(vOffset);
        vMousePoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, vMousePoint.z);



    }

    void OnMouseDrag()
    {
        vMousePointNew = Camera.main.WorldToScreenPoint(transform.position);
        vMousePointNew = new Vector3(Input.mousePosition.x, Input.mousePosition.y, vMousePoint.z);





        vXMove = Input.GetAxis("MouseX");
        vYMove = Input.GetAxis("MouseY");

      




    }

    private void GetMouseWorldPos()
    {



    }



}

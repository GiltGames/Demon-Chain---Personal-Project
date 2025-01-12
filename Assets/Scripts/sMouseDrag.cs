using Unity.VisualScripting;
using UnityEngine;

public class sMouseDrag : MonoBehaviour
{
    [SerializeField] Vector3 vOffset;
    [SerializeField] Vector3 vMousePoint;
    [SerializeField] Vector3 vMousePointNew;
    [SerializeField] Vector3 vNewObjectPos;
    [SerializeField] Vector3 vRefPos;
    [SerializeField] float vXMove;
    [SerializeField] float vYMove;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void OnMouseDown()
    {
        vOffset = transform.position;

        vMousePoint = Camera.main.WorldToScreenPoint(vOffset);
        vMousePoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, vMousePoint.z);

        vRefPos = Camera.main.ScreenToWorldPoint(vMousePoint);





    }

    void OnMouseDrag()
    {
        vMousePointNew = Camera.main.WorldToScreenPoint(transform.position);
        vMousePointNew = new Vector3(Input.mousePosition.x, Input.mousePosition.y, vMousePoint.z);
        vNewObjectPos = Camera.main.ScreenToWorldPoint(vMousePointNew);
        transform.position = (vNewObjectPos- vRefPos)/4 +vOffset;




        vXMove = Input.GetAxis("MouseX");
        vYMove = Input.GetAxis("MouseY");






    }

    private void GetMouseWorldPos()
    {



    }





}

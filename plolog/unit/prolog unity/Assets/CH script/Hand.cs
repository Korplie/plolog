using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 CameraPos = Camera.main.transform.position;
        Vector3 MouseP = Camera.main.ScreenToWorldPoint(new Vector2
        (Input.mousePosition.x, Input.mousePosition.y - Camera.main.transform.position.x));
        Vector3 target = new Vector3(0f, MouseP.y, MouseP.z);
        //transform.LookAt(target);
        float angle = Mathf.Atan2(MouseP.y, MouseP.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);





    }
}

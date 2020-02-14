using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseManager : MonoBehaviour
{
    private Vector2 MousePosition;
    public Camera camera;
    private GameObject Level;
    // Start is called before the first frame update

    void Start()
    {

        // Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        MousePosition = Input.mousePosition;
        MousePosition = camera.ScreenToWorldPoint(MousePosition);

        transform.position = MousePosition;
        if (Input.GetMouseButtonDown(0))
        {
            Level = GetClickObj();
            switch (Level.name)
            {
                case "Level1":
                    SceneManager.LoadScene(2);

                    break;

                default:
                    break;
            }
        }

    }
    private GameObject GetClickObj()
    {
        RaycastHit hit;
        GameObject target=null;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(true==(Physics.Raycast(ray.origin,ray.direction*10,out hit)))
        {
            Debug.Log("sans");
            target = hit.collider.gameObject;
            return target;
        }
        else
            return gameObject;

    }
}

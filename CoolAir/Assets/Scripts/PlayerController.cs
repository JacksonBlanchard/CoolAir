using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject interactable;
    float yawInput;
    float pitchInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ExamineObject(interactable);
    }

    public void ExamineObject(GameObject obj)
    {
        //obj.transform.position = (transform.position + transform.forward * 1f);
        yawInput = Input.GetAxisRaw("Mouse X") * 1.5f;
        pitchInput = Input.GetAxisRaw("Mouse Y") * 1.5f;

        if (Mathf.Abs(pitchInput) > Mathf.Abs(yawInput))
            obj.transform.Rotate(transform.right, pitchInput, Space.World);

        else
            obj.transform.Rotate(transform.up, -yawInput, Space.World);
    }
}

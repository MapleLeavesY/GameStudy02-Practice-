using UnityEngine;

public class Playere : MonoBehaviour
{


    private void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            Debug.Log("W Ispressed !");
        }
        else
        {
            Debug.Log(".");
        }
    }
}

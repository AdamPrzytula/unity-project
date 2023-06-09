using Unity.Mathematics;
using UnityEngine;

public class Movment : MonoBehaviour
{
    public CharacterController controler;
    public Transform cam;
    public float speed = 6f;
    public float turnSmooth = 0.1f;
    float turnSmoothVelo;


    void Update()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        
        Vector3 direction = new Vector3 (horizontal,0f, vertical).normalized;

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle =  Mathf.SmoothDampAngle(transform.eulerAngles.y , targetAngle, ref turnSmoothVelo , turnSmooth);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 movedir= Quaternion.Euler(0f , targetAngle, 0f) * Vector3.forward;
            controler.Move (movedir.normalized * speed * Time.deltaTime);
        }


    }
}

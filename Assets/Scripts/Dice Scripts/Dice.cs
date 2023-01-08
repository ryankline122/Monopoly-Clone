using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public Rigidbody rb;
    public int diceValue;
    public DiceSide[] diceSides;
    Vector3 initPos;
    bool grounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = 20;
        initPos = transform.position;
    }

    private void Update()
    {
        if(rb.velocity.x == 0 && rb.velocity.y == 0 && rb.velocity.z == 0){
            grounded = true;
            SideValueCheck();
        }else{
            grounded = false;
        }

        if (Input.GetMouseButtonDown(0)){
            RollDice();
        }else if (Input.GetKeyDown(KeyCode.Space)){
            Reset();
        }
    }

    void RollDice()
    {
        if(grounded)
        {
            int dirX = Random.Range(-1000, 1000);
            int dirY = Random.Range(-1000, 1000);

            transform.position = initPos;
            transform.rotation = Quaternion.identity;
            
            rb.AddForce(transform.up * 500);
   
            rb.AddTorque(transform.right * dirX);
            rb.AddTorque(transform.up * dirY);
        }
    }

    void Reset()
    {
        // Values to choose from to determine face-up number
        float[] rotationVals = { 0f, 90f, 180f, 270f };

        int rotX = Random.Range(0, 3);
        int rotZ = Random.Range(0, 3);

        transform.Rotate(rotationVals[rotX], 0f, rotationVals[rotZ]);
        transform.position = initPos;
    }

    void SideValueCheck()
    {
        diceValue = 0;
        foreach (DiceSide side in diceSides)
        {
            if (side.OnGround())
            {
                diceValue = side.value;
              //  print(diceValue + " has been rolled");
            }
        }
    }
}

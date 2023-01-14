using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnMovement : MonoBehaviour
{
    public Route currentRoute;

    public int routePos;
    public int steps;
    bool isMoving;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) && !isMoving)
        {
            steps = Random.Range(1, 2);
            //Debug.Log("Rolled " + steps);
            StartCoroutine(Move());
        }
    }

    IEnumerator Move()
    {
        Vector3 nextPos;
        if (isMoving)
        {
            yield break;
        }
        isMoving = true;

        while(steps > 0)
        {
            if(routePos + 1 < currentRoute.children.Count)
            {
                nextPos = currentRoute.children[routePos + 1].position;
                Debug.Log(routePos);
            }
            else
            {
                routePos = -1;
                nextPos = currentRoute.children[0].position;
                
            }
            
            while (MoveToNextNode(nextPos)){ yield return null;}

            yield return new WaitForSeconds(0.1f);
            steps--;
            routePos++;
        }

        isMoving = false;
    }

    bool MoveToNextNode(Vector3 target)
    {
        //Debug.Log("Target = " + target);
        //Debug.Log("Current = " + transform.position);

        target.y = transform.position.y;

        return target != (
            transform.position = Vector3.MoveTowards(
                transform.position, 
                new Vector3(target.x, transform.position.y, target.z), 
                6f * Time.deltaTime)
        );
        
    }
}

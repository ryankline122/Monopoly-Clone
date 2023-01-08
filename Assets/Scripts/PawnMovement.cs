using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnMovement : MonoBehaviour
{
    public Route currentRoute;

    int routePos;
    public int steps;
    bool isMoving;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) && !isMoving)
        {
            steps = Random.Range(1, 7);
            Debug.Log("Rolled " + steps);

            if (routePos + steps < currentRoute.children.Count)
            {
                StartCoroutine(Move());
            }
            else
            {
                steps -= currentRoute.children.Count;
            }
        }
    }

    IEnumerator Move()
    {
        if (isMoving)
        {
            yield break;
        }
        isMoving = true;

        while(steps > 0)
        {
            Vector3 nextPos = currentRoute.children[routePos + 1].position;
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
                2f * Time.deltaTime)
        );
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route : MonoBehaviour
{
    Transform[] childObjects;
    public List<Transform> children = new List<Transform>();

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        FillNodes();

        for (int i=0; i<children.Count; i++)
        {
            Vector3 currentNode = children[i].position;
            
            if(i > 0) {
                Vector3 prevNode = children[i-1].position;
                Gizmos.DrawLine(prevNode, currentNode);
            }
        }
    }

    void FillNodes()
    {
        children.Clear();
        childObjects= GetComponentsInChildren<Transform>();

        foreach(Transform child in childObjects)
        {
            if(child != this.transform)
            {
                children.Add(child);
            }
        }
    }
}

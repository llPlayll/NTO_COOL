using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Availability
{
    NotChosen = 0,
    NotAvailable,
    Available,
}

public class Building : MonoBehaviour
{
    public Vector2Int Size = Vector2Int.one;

    public void DrawAvailability(Availability type)
    {
        var components = GetComponentsInChildren<OutlineFx.OutlineFx>();

        foreach (var component in components)
        {
            switch (type)
            {
                case Availability.NotChosen:
                    component.enabled = false;
                    break;
                case Availability.NotAvailable:
                    component.enabled = true;
                    component.Color = Color.red;
                    break;
                case Availability.Available:
                    component.enabled = true;
                    component.Color = Color.green;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }


    
    private void OnDrawGizmos()
    {
        for (int x = 0; x < Size.x; x++)
        {
            for (int y = 0; y < Size.y; y++)
            {
                if ((x + y) % 2 == 0) Gizmos.color = new Color(0.88f, 0f, 1f, 0.3f);
                else Gizmos.color = new Color(1f, 0.68f, 0f, 0.3f);

                Gizmos.DrawCube(transform.position + new Vector3(x, 0, y), new Vector3(1, .1f, 1));
            }
        }
    }

    public virtual void Build()
    {
    }
}

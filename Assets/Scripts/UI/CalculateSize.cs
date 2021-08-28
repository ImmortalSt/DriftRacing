using System.Linq;
using UnityEngine;

public class CalculateSize : MonoBehaviour
{
    private Road[] children;

    public void Init()
    {
        children = GetComponentsInChildren<Road>();
        if (children.Length == 0)
            throw new System.ArgumentException("Children not found");
    } 

    public class Range
    {
        public float MaxValue = float.MinValue;
        public float MinValue = float.MaxValue;
    }
    
    public Range[] GetSize()
    {
        Range[] values = new Range[3];

        Transform[] transforms = children.Select(x => x.GetComponent<Transform>()).ToArray();

        foreach (var transform in transforms)
        {
            for (int i = 0; i < 3; i++)
            {
                if (values[i] == null) values[i] = new Range();

                if (values[i].MaxValue < transform.position[i])
                    values[i].MaxValue = transform.position[i];

                if (values[i].MinValue > transform.position[i])
                    values[i].MinValue = transform.position[i];
            }
        }

        return values;
    }
}

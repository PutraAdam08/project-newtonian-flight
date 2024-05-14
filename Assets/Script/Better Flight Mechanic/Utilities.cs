using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities
{
    public static float MoveTo(float value, float target, float speed, float deltaTime, float min = 0, float max = 1)
    {
        float diff = target - value;
        float delta = Mathf.Clamp(diff, -speed * deltaTime, speed * deltaTime);
        return Mathf.Clamp(value + delta, min, max);
    }

    public static Vector3 Scale6(Vector3 value, float posX, float negX, float posY, float negY, float posZ, float negZ)
    {
        Vector3 result = value;

        if(result.x > 0)
        {
            result.x *= posX;
        }
        else if(result.x < 0)
        {
            result.x *=negX;
        }

        if(result.y > 0)
        {
            result.y *= posX;
        }
        else if(result.y < 0)
        {
            result.y *=negX;
        }

        if(result.z > 0)
        {
            result.z *= posX;
        }
        else if(result.z < 0)
        {
            result.z *=negX;
        }

        return result;
    }
}

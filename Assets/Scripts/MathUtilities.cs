using UnityEngine;

public class MathUtilities : MonoBehaviour
{
    public static Vector3 TurnVector(Vector3 baseVector, float angleDeg){
        float xPrime = baseVector.x * Mathf.Cos(angleDeg * Mathf.Deg2Rad) - baseVector.z * Mathf.Sin(angleDeg * Mathf.Deg2Rad);
        float yPrime = baseVector.x * Mathf.Sin(angleDeg * Mathf.Deg2Rad) + baseVector.z * Mathf.Cos(angleDeg * Mathf.Deg2Rad);

        return new Vector3(xPrime, 0, yPrime);
    }
}


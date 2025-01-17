using System.Collections.Generic;
using UnityEngine;

namespace GreenNacho.AI.Flocking
{
    [System.Serializable]
    public class CohesionBehavior : FlockBehavior
    {
        public override Vector3 ComputeVector(Boid boid, List<Boid> neighbors)
        {
            Vector3 cohesionVector = Vector3.zero;

            if (neighbors.Count > 0)
            {
                foreach (Boid b in neighbors)
                    cohesionVector += b.transform.position;

                cohesionVector = (cohesionVector / neighbors.Count) - boid.transform.position;
            }

            float angleBetweenDirs = Vector3.Angle(boid.transform.forward, cohesionVector);
            float dynamicWeight = Mathf.Clamp01(angleBetweenDirs / 180f);

            cohesionVector *= staticWeight * dynamicWeight;

            return cohesionVector;
        }
    }
}
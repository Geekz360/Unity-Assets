using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPunch : MonoBehaviour
{



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // This is used for determining the direction of a punch, this first snippet
        // is used to set up the maths behind a punch
        string PunchLand(Vector3 OtherObject)
        {

            string front;

            string right;

            float t = 0.15f;

            if (Vector3.Dot(transform.forward, OtherObject-transform.position) > t)

                front = "Forward";

            else

                front = "Behind";

            // this section will determine if the punch was from the left, right or straight down the middle
            // and will be used later when multiple punch types are brought in
            // Each name in "" relates to an animation name
            if (Vector3.Dot(transform.right, OtherObject-transform.position) < -t)

                right = "PunchLeft";

            else if (Vector3.Dot(transform.right, OtherObject - transform.position) > t)

                right = "RightPunch";

            else

                right = "Punch";

            return front + right;

            // This will detect if the player makes contact with the opponent
            void OnCollisionEnter(Collision collision)
            {
                // The script will check if the player is colliding, to prevent the environment having an effect

                if (collision.gameObject.CompareTag("Player"))
                {

                    hitDirection = DirectionImpact(collision.transform.position);

                    StartCoroutine(ImpactAnim(hitDirection));

                }

            }
        }




    }

}
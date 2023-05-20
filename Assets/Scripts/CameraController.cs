using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float camspeed;
    [SerializeField] float distance;
    float looktarget;
    [SerializeField] Transform target;
    // Start is called before the first frame update


    // Update is called once per frame
    /// <summary>
    /// LateUpdate is called every frame, if the Behaviour is enabled.
    /// It is called after all Update functions have been called.
    /// </summary>
    private void LateUpdate()
    {
        transform.position = new Vector3(target.position.x + looktarget, transform.position.y, transform.position.z);
        looktarget = Mathf.Lerp(looktarget, (distance * target.localScale.x), Time.deltaTime * camspeed);

    }
}

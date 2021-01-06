using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionAdjustCamera : MonoBehaviour
{
    [SerializeField] private GameObject CamerContainer;
    void Update()
    {
        CameraPosition();
    }
    private void CameraPosition()
    {
        float width = Screen.width;
        float height = Screen.height;
        //5:4
        if (width / height == 1.25f)
        {
            CamerContainer.transform.position = new Vector3(0f, 0f, -1305f);
        }
        //4:3
        if (width / height >= 1.3f && width / height < 1.4f)
        {
            CamerContainer.transform.position = new Vector3(0f, 0f, -1255f);
        }
        //3:2
        if (width / height >= 1.49f && width / height <= 1.55f)
        {
            CamerContainer.transform.position = new Vector3(0f, 0f, -1113f);
        }
        //16:10
        if (width / height >= 1.59f && width / height <= 1.65f)
        {
            CamerContainer.transform.position = new Vector3(0f, 0f, -1055f);
        }
        //16:9
        if (width / height >= 1.7f && width / height <= 2f)
        {
            CamerContainer.transform.position = new Vector3(0f, 0f, -940f);
        }
        //64:27
        if (width / height >= 2.360f && width / height <= 3f)
        {
            CamerContainer.transform.position = new Vector3(0f, 0f, -726f);
        }
    }

}

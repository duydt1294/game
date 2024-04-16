using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public CinemachineVirtualCamera[] allVCams; // Danh sách các VCam
    private int currentVcamIndex = 0; // Chỉ số của VCam hiện tại

    private void Update()
    {
        // Kiểm tra điều kiện để chuyển đổi giữa các VCam
        if (transform.position.y >= 6f || transform.position.y >= 12) // Ví dụ: nhân vật di chuyển đến vị trí x > 10
        {
            // Tắt VCam hiện tại
            Debug.Log("vcam2");
            allVCams[currentVcamIndex].gameObject.SetActive(false);//tat vcam1
            // Chuyển đến VCam tiếp theo trong danh sách
            //currentVcamIndex = (currentVcamIndex + 1) % allVCams.Length;

            // Bật VCam mới
            //allVCams[currentVcamIndex].gameObject.SetActive(true);
        }
        
        
        else
        {
            allVCams[currentVcamIndex].gameObject.SetActive(true);
        }

        
    }
}

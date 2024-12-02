using UnityEngine;

public class OtterPositionManager : MonoBehaviour
{
    private const string OtterPositionKey = "OtterPosition";

    void Start()
    {
        RestorePosition();
    }

    void RestorePosition()
    {
        // Check if a saved position exists
        if (PlayerPrefs.HasKey(OtterPositionKey + "_X"))
        {
            float x = PlayerPrefs.GetFloat(OtterPositionKey + "_X");
            float y = PlayerPrefs.GetFloat(OtterPositionKey + "_Y");
            float z = PlayerPrefs.GetFloat(OtterPositionKey + "_Z");

            // Restore the position
            transform.position = new Vector3(x, y, z);
        }
        else
        {
            Debug.Log("No saved position found for the otter.");
        }
    }
}

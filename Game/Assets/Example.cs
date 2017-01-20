using UnityEngine;

public class Example : MonoBehaviour, AudioProcessor.AudioCallbacks
{
    void Start()
    {
        //Select the instance of AudioProcessor and pass a reference
        //to this object
        AudioProcessor processor = FindObjectOfType<AudioProcessor>();
        processor.addAudioCallback(this);
    }


    void Update()
    {

    }

    public void onOnbeatDetected()
    {
        Debug.Log("Beat!!!");
    }

    public void onSpectrum(float[] spectrum)
    {

    }
}
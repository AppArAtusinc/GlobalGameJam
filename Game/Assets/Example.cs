using UnityEngine;

public class Example : MonoBehaviour, AudioProcessor.AudioCallbacks
{

    ParticleSystem PS;

    private void Awake()
    {
        PS = GetComponent<ParticleSystem>();
    }

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
        PS.Emit(100);
    }

    public void onSpectrum(float[] spectrum)
    {

    }
}
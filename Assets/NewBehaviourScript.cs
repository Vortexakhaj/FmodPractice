using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    FMOD.ChannelGroup cgSys1;
    FMOD.Channel chaSys1;
    FMOD.RESULT playResult;

    FMOD.ChannelGroup cgSys2;
    FMOD.Channel chaSys2;
    FMOD.RESULT playResult2;

    void Start()
    {
        var resGetDrivers_core = FMODUnity.RuntimeManager.CoreSystem.getNumDrivers(out int totalDrivers);
        var resGetDrivers_info = FMODUnity.RuntimeManager.CoreSystem.getDriverInfo(0, out var driverName, 50, out var guid, out var systemrate, out var speakermode, out int speakerChannels);
        Debug.Log($"Total Core Drivers {totalDrivers}");
        Debug.Log($"Name :{driverName}");
        var resGetDrivers_core2 = FMODUnity.RuntimeManager.CoreSystem2.getNumDrivers(out int totalDrivers2);
        var resGetDrivers_info2 = FMODUnity.RuntimeManager.CoreSystem2.getDriverInfo(1, out var driverName2, 50, out var guid2, out var systemrate2, out var speakermode2, out int speakerChannels2);
        Debug.Log($"Total Core 2 Drivers {totalDrivers2}");
        Debug.Log($"Name 2 :{driverName2}");

        var resSysInit_system2 = FMODUnity.RuntimeManager.CoreSystem2.init(2, FMOD.INITFLAGS.NORMAL, (System.IntPtr)0);

        var soundResult_test = FMODUnity.RuntimeManager.CoreSystem2.createSound(Application.streamingAssetsPath + "/nicebeatzprod._-_Et_Je_Dance.mp3", FMOD.MODE.CREATESTREAM, out var sound_test);
        FMODUnity.RuntimeManager.CoreSystem.setDriver(1);
        FMODUnity.RuntimeManager.CoreSystem2.setDriver(0);
        playResult = FMODUnity.RuntimeManager.CoreSystem2.playSound(sound_test, cgSys1, false, out chaSys1);
    }

    private void OnDisable()
    {
        if (FMODUnity.RuntimeManager.StudioSystem2.isValid())
        {
            FMODUnity.RuntimeManager.StudioSystem2.release();
            FMODUnity.RuntimeManager.StudioSystem2.clearHandle();
        }
    }
}
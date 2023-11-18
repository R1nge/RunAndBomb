using UnityEditor;

namespace External.Joystick_Pack.Scripts.Editor
{
    [InitializeOnLoad]
    class EnableThreads
    {
        static EnableThreads()
        {
            PlayerSettings.WebGL.linkerTarget = WebGLLinkerTarget.Wasm;
            PlayerSettings.WebGL.threadsSupport = false;
            PlayerSettings.WebGL.memorySize = 512;
        }
    }
}
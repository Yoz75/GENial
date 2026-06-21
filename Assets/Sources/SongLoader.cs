using SFB;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Networking;

namespace Genial
{
    public class SongLoader : MonoBehaviour
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        //
        // WebGL
        //
        [DllImport("__Internal")]
        private static extern void UploadFile(string gameObjectName, string methodName, string filter, bool multiple);

        public void Load()
        {
            UploadFile(gameObject.name, "OnFileUpload", "mp3", false);
        }

        // Called from browser
        public void OnFileUpload(string url)
        {
            StartCoroutine(OutputRoutine(url));
        }
#else

        public void Load()
        {
            var extensions = new[] { new ExtensionFilter("Music", "mp3") };
            var path = StandaloneFileBrowser.OpenFilePanel("Music file", "", extensions, false);
            Debug.Log(path[0]);

            StartCoroutine(LoadClipCoroutine("file:///" + path[0]));
        }
#endif
        private IEnumerator LoadClipCoroutine(string url)
        {
            using UnityWebRequest uwr = UnityWebRequestMultimedia.GetAudioClip(url, AudioType.MPEG);
            yield return uwr.SendWebRequest();

            if(uwr.result == UnityWebRequest.Result.ConnectionError || uwr.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(uwr.error);
            }
            else
            {
                // Get the downloaded audio clip
                AudioClip clip = DownloadHandlerAudioClip.GetContent(uwr);

                // Assign and play
                SongConfiguration.Track = clip;
            }
        }
    }
}
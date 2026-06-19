using System;
using UnityEngine;

namespace Genial
{
    public class SongConfigurationUpdater : MonoBehaviour
    {
        public void UpdateBPM(string value)
        {
            if(!int.TryParse(value, out int bpm))
            {
                return;
            }

            SongConfiguration.BeatsPerMinute = bpm;
        }

        public void UpdateDelay(string value)
        {
            if(!float.TryParse(value, out float delay))
            {
                return;
            }

            SongConfiguration.StartDelay = delay;
        }
    }
}
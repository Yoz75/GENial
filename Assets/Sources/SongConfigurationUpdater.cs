using System;
using UnityEngine;

namespace Genial
{
    public class SongConfigurationUpdater : MonoBehaviour
    {
        public void UpdateBPM(float value)
        {
            SongConfiguration.BeatsPerMinute = value;
        }

        public void UpdateDelay(float value)
        {
            SongConfiguration.StartDelay = value;
        }
    }
}
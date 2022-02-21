using System;
using Mai2;
using Manager;
using Mono.Unix.Native;
using UnityEngine;
using VoiceCue = Mai2.Voice_000001.Cue;
using JingleCue = Mai2.Mai2Cue.Cue;

namespace Sinmai.Functions
{
    public class Sounds
    {
        public static void InjectSound()
        {
            // Target: 0 = Left, 1 = Right, 2 = Both.
            Manager.SoundManager.PlayJingle((JingleCue)Enum.Parse(typeof(JingleCue), "SE_ENTRY_AIME_OK"), 2);
            Manager.SoundManager.PlayVoice((VoiceCue)Enum.Parse(typeof(VoiceCue), "VO_000012"), 2);
        }
    }
}
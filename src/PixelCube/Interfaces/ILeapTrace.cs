﻿using System;

namespace PixelCube.LeapMotion
{
    public interface ILeapTrace
    {
        event EventHandler<ExhaleMenuArgs> ExhaleMenuEvent;    // Exhale Event
        event EventHandler<SelectMenuArgs> SelectMenuEvent;    // Select Event
        event EventHandler<TraceMenuArgs> TraceEvent;  // Trace Event

        void DoInit();    // LeapMotion initialize
        void Uninitialize();
    }
}

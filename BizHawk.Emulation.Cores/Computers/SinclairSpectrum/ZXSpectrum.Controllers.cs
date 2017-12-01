﻿
using BizHawk.Emulation.Common;

namespace BizHawk.Emulation.Cores.Computers.SinclairSpectrum
{
    public partial class ZXSpectrum
    {

        /// <summary>
        /// Controller mapping includes all keyboard keys from the following models:
        /// https://upload.wikimedia.org/wikipedia/commons/thumb/3/33/ZXSpectrum48k.jpg/1200px-ZXSpectrum48k.jpg
        /// https://upload.wikimedia.org/wikipedia/commons/c/ca/ZX_Spectrum%2B.jpg
        /// </summary>
        public static readonly ControllerDefinition ZXSpectrumControllerDefinition = new ControllerDefinition
        {
            Name = "ZXSpectrum Controller",
            BoolButtons =
            {
                // Joystick interface (not yet emulated) - Could be Kempston/Cursor/Protek
                "P1 Up", "P1 Down", "P1 Left", "P1 Right", "P1 Button", 
                // Keyboard - row 1    
                /*"Key True Video", "Key Inv Video",*/ "Key 1", "Key 2", "Key 3", "Key 4", "Key 5", "Key 6", "Key 7", "Key 8", "Key 9", "Key 0", "Key Break",
                // Keyboard - row 2
                "Key Delete", /*"Key Graph",*/ "Key Q", "Key W", "Key E", "Key R", "Key T", "Key Y", "Key U", "Key I", "Key O", "Key P",
                // Keyboard - row 3
                /*"Key Extend Mode", "Key Edit",*/ "Key A", "Key S", "Key D", "Key F", "Key G", "Key H", "Key J", "Key K", "Key L", "Key Return",
                // Keyboard - row 4
                "Key Caps Shift", /*"Key Caps Lock",*/ "Key Z", "Key X", "Key C", "Key V", "Key B", "Key N", "Key M", /*"Key Period",*/
                // Keyboard - row 5
                "Key Symbol Shift", /*"Key Semi-Colon", "Key Quote",*/ "Key Left Cursor", "Key Right Cursor", "Key Space", "Key Up Cursor", "Key Down Cursor", /*"Key Comma",*/
                // Tape functions
                "Play Tape", "Stop Tape", "RTZ Tape", "Record Tape"
            }
        };
    }
}
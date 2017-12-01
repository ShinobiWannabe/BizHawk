﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizHawk.Emulation.Cores.Computers.SinclairSpectrum
{
    /// <summary>
    /// The abstract class that all emulated models will inherit from
    /// * Memory *
    /// </summary>
    public abstract partial class SpectrumBase
    {
        /// <summary>
        /// ROM Banks
        /// </summary>        
        public byte[] ROM0 = new byte[0x4000];
        public byte[] ROM1 = new byte[0x4000];
        public byte[] ROM2 = new byte[0x4000];
        public byte[] ROM3 = new byte[0x4000];

        /// <summary>
        /// RAM Banks
        /// </summary>
        public byte[] RAM0 = new byte[0x4000];  // Bank 0
        public byte[] RAM1 = new byte[0x4000];  // Bank 1
        public byte[] RAM2 = new byte[0x4000];  // Bank 2
        public byte[] RAM3 = new byte[0x4000];  // Bank 3
        public byte[] RAM4 = new byte[0x4000];  // Bank 4
        public byte[] RAM5 = new byte[0x4000];  // Bank 5
        public byte[] RAM6 = new byte[0x4000];  // Bank 6
        public byte[] RAM7 = new byte[0x4000];  // Bank 7

        /// <summary>
        /// Represents the addressable memory space of the spectrum
        /// All banks for the emulated system should be added during initialisation
        /// </summary>
        public Dictionary<int, byte[]> Memory = new Dictionary<int, byte[]>();

        /// <summary>
        /// Simulates reading from the bus
        /// Paging should be handled here
        /// </summary>
        /// <param name="addr"></param>
        /// <returns></returns>
        public virtual byte ReadBus(ushort addr)
        {
            throw new NotImplementedException("Must be overriden");
        }

		/// <summary>
		/// Pushes a value onto the data bus that should be valid as long as the interrupt is true
		/// </summary>
		/// <param name="addr"></param>
		/// <returns></returns>
		public virtual byte PushBus()
		{
			throw new NotImplementedException("Must be overriden");
		}

		/// <summary>
		/// Simulates writing to the bus
		/// Paging should be handled here
		/// </summary>
		/// <param name="addr"></param>
		/// <param name="value"></param>
		public virtual void WriteBus(ushort addr, byte value)
        {
            throw new NotImplementedException("Must be overriden");
        }

        /// <summary>
        /// Reads a byte of data from a specified memory address
        /// (with memory contention if appropriate)
        /// </summary>
        /// <param name="addr"></param>
        /// <returns></returns>
        public virtual byte ReadMemory(ushort addr)
        {
            throw new NotImplementedException("Must be overriden");
        }
        /*
        /// <summary>
        /// Reads a byte of data from a specified memory address
        /// (with no memory contention)
        /// </summary>
        /// <param name="addr"></param>
        /// <returns></returns>
        public virtual byte PeekMemory(ushort addr)
        {
            var data = ReadBus(addr);
            return data;
        }
        */

        /// <summary>
        /// Writes a byte of data to a specified memory address
        /// (with memory contention if appropriate)
        /// </summary>
        /// <param name="addr"></param>
        /// <param name="value"></param>
        public virtual void WriteMemory(ushort addr, byte value)
        {
            throw new NotImplementedException("Must be overriden");
        }

        /*
        /// <summary>
        /// Writes a byte of data to a specified memory address
        /// (without contention)
        /// </summary>
        /// <param name="addr"></param>
        /// <param name="value"></param>
        public virtual void PokeMemory(ushort addr, byte value)
        {
            if (addr < 0x4000)
            {
                // Do nothing - we cannot write to ROM
                return;
            }

            WriteBus(addr, value);
        }
        */

        /// <summary>
        /// Fills memory from buffer
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="startAddress"></param>
        public virtual void FillMemory(byte[] buffer, ushort startAddress)
        {
            //buffer?.CopyTo(RAM, startAddress);
        }

        /// <summary>
        /// Sets up the ROM
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="startAddress"></param>
        public virtual void InitROM(RomData romData)
        {
            RomData = romData;
            // for 16/48k machines only ROM0 is used (no paging)
            RomData.RomBytes?.CopyTo(ROM0, 0);
        }

        /// <summary>
        /// ULA reads the memory at the specified address
        /// (No memory contention)
        /// </summary>
        /// <param name="addr"></param>
        /// <returns></returns>
        public virtual byte FetchScreenMemory(ushort addr)
        {
            //var value = RAM0[(addr & 0x3FFF)];// + 0x4000];
            var value = ReadBus((ushort)((addr & 0x3FFF) + 0x4000));
            return value;
        }

        /// <summary>
        /// Helper function to refresh memory array (probably not the best way to do things)
        /// </summary>
        public virtual void ReInitMemory()
        {
            throw new NotImplementedException("Must be overriden");
        }

        /// <summary>
        /// Returns the memory contention value for the specified T-State (cycle)
        /// The ZX Spectrum memory access is contended when the ULA is accessing the lower 16k of RAM
        /// </summary>
        /// <param name="Cycle"></param>
        /// <returns></returns>
        public virtual byte GetContentionValue(int cycle)
        {
            var val = _renderingCycleTable[cycle % UlaFrameCycleCount].ContentionDelay;
            return val;
        }
    }
}
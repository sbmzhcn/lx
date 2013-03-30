﻿using System;
using System.Collections.Generic;
using System.Text;

namespace XD2122GateImporter
{
    /// <summary>
    /// 
    /// </summary>
    public class TransItemFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nm"></param>
        /// <returns></returns>
        static public TransItem Create(NameMap nm, FromDBI fromDBI, ToDBI toDBI)
        {
            TransItem item = new TransItem();
            item.FromDevice = CreateFromDevice(nm.FromName, fromDBI);
            item.ToDevice = CreateToDevice(nm.ToName, toDBI, nm.Elvation );
            return item;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private static FromDevice CreateFromDevice(string name, FromDBI fromDBI)
        {
            FromDevice fd = new FromDevice();
            fd.DBI = fromDBI;
            fd.Name = name;
            fd.ID = fromDBI.ReadFromDeviceID(name);
            return fd;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private static ToDevice CreateToDevice(string name, ToDBI toDBI, float elvation)
        {
            ToDevice to = new ToDevice();
            to.DBI = toDBI;
            to.Name = name;
            to.ID = toDBI.ReadToDeviceID(name);
            to.ComAdr = toDBI.ReadToDeviceComAdr(to.ID);
            to.Elvation = elvation;
            return to;
        }
    }
}

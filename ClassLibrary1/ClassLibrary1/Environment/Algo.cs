﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace ClassLibrary1.Map
{
    public class Algo : IDisposable
    {
        bool disposed = false;
        IntPtr nativeAlgo;

        public Map CreateMap(int size)
        {
            var tiles = new TileType[size * size];
            Algo_fillMap(nativeAlgo, tiles, size);
            return new Map(tiles);
        }

        public Algo()
        {
            nativeAlgo = Algo_new();
        }

        ~Algo()
        {
            Dispose(false);
            Algo_delete(nativeAlgo);
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;
            if (disposing)
            {
                Algo_delete(nativeAlgo);
            }
            disposed = true;
        }


        [DllImport("libCPP.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static void Algo_fillMap(IntPtr algo, TileType[] tiles, int nbTiles);

        [DllImport("libCPP.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr Algo_new();

        [DllImport("libCPP.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr Algo_delete(IntPtr algo);
    }
}
}

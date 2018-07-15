﻿using System;
using System.Runtime.InteropServices;
using AdvancedDLSupport;
using Qt.NetCore.Internal;
using Qt.NetCore.Types;

namespace Qt.NetCore.Qml
{
    public class NetVariant : BaseDisposable
    {
        public NetVariant()
            :base(Interop.NetVariant.Create())
        {
            
        }

        public NetVariantType VariantType => Interop.NetVariant.GetVariantType(Handle);

        public NetInstance Instance
        {
            get
            {
                var result = Interop.NetVariant.GetNetInstance(Handle);
                return result == IntPtr.Zero ? null : new NetInstance(result);
            }
            set => Interop.NetVariant.SetNetInstance(Handle, value?.Handle ?? IntPtr.Zero);
        }

        public bool Bool
        {
            get => Interop.NetVariant.GetBool(Handle);
            set => Interop.NetVariant.SetBool(Handle, value);
        }
        
        public char Char
        {
            get => (char)Interop.NetVariant.GetChar(Handle);
            set => Interop.NetVariant.SetChar(Handle, value);
        }
        
        public int Int
        {
            get => Interop.NetVariant.GetInt(Handle);
            set => Interop.NetVariant.SetInt(Handle, value);
        }
        
        public uint UInt
        {
            get => Interop.NetVariant.GetUInt(Handle);
            set => Interop.NetVariant.SetUInt(Handle, value);
        }
        
        protected override void DisposeUnmanaged(IntPtr ptr)
        {
            Interop.NetVariant.Destroy(ptr);
        }
    }
    
    public interface INetVariantInterop
    {
        [NativeSymbol(Entrypoint = "net_variant_create")]
        IntPtr Create();
        [NativeSymbol(Entrypoint = "net_variant_destroy")]
        void Destroy(IntPtr variant);

        [NativeSymbol(Entrypoint = "net_variant_setNetInstance")]
        void SetNetInstance(IntPtr variant, IntPtr instance);
        [NativeSymbol(Entrypoint = "net_variant_getNetInstance")]
        IntPtr GetNetInstance(IntPtr variant);

        [NativeSymbol(Entrypoint = "net_variant_setBool")]
        void SetBool(IntPtr variant, bool value);
        [NativeSymbol(Entrypoint = "net_variant_getBool")]
        bool GetBool(IntPtr variant);
        
        [NativeSymbol(Entrypoint = "net_variant_setChar")]
        void SetChar(IntPtr variant, ushort value);
        [NativeSymbol(Entrypoint = "net_variant_getChar")]
        ushort GetChar(IntPtr variant);
        
        [NativeSymbol(Entrypoint = "net_variant_setInt")]
        void SetInt(IntPtr variant, int value);
        [NativeSymbol(Entrypoint = "net_variant_getInt")]
        int GetInt(IntPtr variant);
        
        [NativeSymbol(Entrypoint = "net_variant_setUInt")]
        void SetUInt(IntPtr variant, uint value);
        [NativeSymbol(Entrypoint = "net_variant_getUInt")]
        uint GetUInt(IntPtr variant);
        
        [NativeSymbol(Entrypoint = "net_variant_getVariantType")]
        NetVariantType GetVariantType(IntPtr variant);
    }
}
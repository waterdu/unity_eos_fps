// Copyright Epic Games, Inc. All Rights Reserved.
// This file is automatically generated. Changes to this file may be overwritten.

using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.P2P
{
	/// <summary>
	/// Structure containing information about who would like to receive a packet, and how much data can be stored safely.
	/// </summary>
	public class ReceivePacketOptions
	{
		/// <summary>
		/// API Version of the <see cref="ReceivePacketOptions" /> structure
		/// </summary>
		public int ApiVersion { get { return 2; } }

		/// <summary>
		/// The user who is receiving the packet
		/// </summary>
		public ProductUserId LocalUserId { get; set; }

		/// <summary>
		/// The maximum amount of data in bytes that can be safely copied to OutData in the function call
		/// </summary>
		public uint MaxDataSizeBytes { get; set; }

		/// <summary>
		/// An optional channel to request the data for. If NULL, we're retrieving the next packet on any channel
		/// </summary>
		public byte? RequestedChannel { get; set; }
	}

	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct ReceivePacketOptionsInternal : IDisposable
	{
		private int m_ApiVersion;
		private IntPtr m_LocalUserId;
		private uint m_MaxDataSizeBytes;
		private IntPtr m_RequestedChannel;

		public int ApiVersion
		{
			get
			{
				var value = Helper.GetDefault<int>();
				Helper.TryMarshalGet(m_ApiVersion, out value);
				return value;
			}
			set { Helper.TryMarshalSet(ref m_ApiVersion, value); }
		}

		public ProductUserId LocalUserId
		{
			get
			{
				var value = Helper.GetDefault<ProductUserId>();
				Helper.TryMarshalGet(m_LocalUserId, out value);
				return value;
			}
			set { Helper.TryMarshalSet(ref m_LocalUserId, value); }
		}

		public uint MaxDataSizeBytes
		{
			get
			{
				var value = Helper.GetDefault<uint>();
				Helper.TryMarshalGet(m_MaxDataSizeBytes, out value);
				return value;
			}
			set { Helper.TryMarshalSet(ref m_MaxDataSizeBytes, value); }
		}

		public byte? RequestedChannel
		{
			get
			{
				var value = Helper.GetDefault<byte?>();
				Helper.TryMarshalGet(m_RequestedChannel, out value);
				return value;
			}
			set { Helper.TryMarshalSet(ref m_RequestedChannel, value); }
		}

		public void Dispose()
		{
			Helper.TryMarshalDispose(ref m_RequestedChannel);
		}
	}
}
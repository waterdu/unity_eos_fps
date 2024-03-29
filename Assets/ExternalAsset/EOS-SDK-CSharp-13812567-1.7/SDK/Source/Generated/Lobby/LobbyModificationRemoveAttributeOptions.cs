// Copyright Epic Games, Inc. All Rights Reserved.
// This file is automatically generated. Changes to this file may be overwritten.

using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Lobby
{
	/// <summary>
	/// Input parameters for the <see cref="LobbyModification.RemoveAttribute" /> Function.
	/// </summary>
	public class LobbyModificationRemoveAttributeOptions
	{
		/// <summary>
		/// Version of the API
		/// </summary>
		public int ApiVersion { get { return 1; } }

		/// <summary>
		/// Name of the key
		/// </summary>
		public string Key { get; set; }
	}

	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct LobbyModificationRemoveAttributeOptionsInternal : IDisposable
	{
		private int m_ApiVersion;
		[MarshalAs(UnmanagedType.LPStr)]
		private string m_Key;

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

		public string Key
		{
			get
			{
				var value = Helper.GetDefault<string>();
				Helper.TryMarshalGet(m_Key, out value);
				return value;
			}
			set { Helper.TryMarshalSet(ref m_Key, value); }
		}

		public void Dispose()
		{
		}
	}
}
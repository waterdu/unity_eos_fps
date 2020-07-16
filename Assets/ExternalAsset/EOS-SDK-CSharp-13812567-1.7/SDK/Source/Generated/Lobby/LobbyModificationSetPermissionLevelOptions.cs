// Copyright Epic Games, Inc. All Rights Reserved.
// This file is automatically generated. Changes to this file may be overwritten.

using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Lobby
{
	/// <summary>
	/// Input parameters for the <see cref="LobbyModification.SetPermissionLevel" /> Function.
	/// </summary>
	public class LobbyModificationSetPermissionLevelOptions
	{
		/// <summary>
		/// Version of the API
		/// </summary>
		public int ApiVersion { get { return 1; } }

		/// <summary>
		/// Permission level of the lobby
		/// </summary>
		public LobbyPermissionLevel PermissionLevel { get; set; }
	}

	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct LobbyModificationSetPermissionLevelOptionsInternal : IDisposable
	{
		private int m_ApiVersion;
		private LobbyPermissionLevel m_PermissionLevel;

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

		public LobbyPermissionLevel PermissionLevel
		{
			get
			{
				var value = Helper.GetDefault<LobbyPermissionLevel>();
				Helper.TryMarshalGet(m_PermissionLevel, out value);
				return value;
			}
			set { Helper.TryMarshalSet(ref m_PermissionLevel, value); }
		}

		public void Dispose()
		{
		}
	}
}
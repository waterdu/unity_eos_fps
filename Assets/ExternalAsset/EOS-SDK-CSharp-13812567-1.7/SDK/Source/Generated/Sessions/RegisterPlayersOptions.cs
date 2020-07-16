// Copyright Epic Games, Inc. All Rights Reserved.
// This file is automatically generated. Changes to this file may be overwritten.

using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Sessions
{
	/// <summary>
	/// Input parameters for the <see cref="SessionsInterface.RegisterPlayers" /> Function.
	/// </summary>
	public class RegisterPlayersOptions
	{
		/// <summary>
		/// Version of the API
		/// </summary>
		public int ApiVersion { get { return 1; } }

		/// <summary>
		/// Name of the session for which to register players
		/// </summary>
		public string SessionName { get; set; }

		/// <summary>
		/// Array of players to register with the session
		/// </summary>
		public ProductUserId[] PlayersToRegister { get; set; }

	}

	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct RegisterPlayersOptionsInternal : IDisposable
	{
		private int m_ApiVersion;
		[MarshalAs(UnmanagedType.LPStr)]
		private string m_SessionName;
		private IntPtr m_PlayersToRegister;
		private uint m_PlayersToRegisterCount;

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

		public string SessionName
		{
			get
			{
				var value = Helper.GetDefault<string>();
				Helper.TryMarshalGet(m_SessionName, out value);
				return value;
			}
			set { Helper.TryMarshalSet(ref m_SessionName, value); }
		}

		public ProductUserId[] PlayersToRegister
		{
			get
			{
				var value = Helper.GetDefault<ProductUserId[]>();
				Helper.TryMarshalGet(m_PlayersToRegister, out value, m_PlayersToRegisterCount);
				return value;
			}
			set { Helper.TryMarshalSet(ref m_PlayersToRegister, value, out m_PlayersToRegisterCount); }
		}


		public void Dispose()
		{
			Helper.TryMarshalDispose(ref m_PlayersToRegister);
		}
	}
}
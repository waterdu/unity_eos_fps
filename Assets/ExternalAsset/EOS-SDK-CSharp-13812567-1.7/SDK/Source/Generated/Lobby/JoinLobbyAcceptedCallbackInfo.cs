// Copyright Epic Games, Inc. All Rights Reserved.
// This file is automatically generated. Changes to this file may be overwritten.

using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Lobby
{
	/// <summary>
	/// Output parameters for the <see cref="OnJoinLobbyAcceptedCallback" /> Function.
	/// </summary>
	public class JoinLobbyAcceptedCallbackInfo
	{
		/// <summary>
		/// Context that was passed into <see cref="LobbyInterface.AddNotifyJoinLobbyAccepted" />
		/// </summary>
		public object ClientData { get; set; }

		/// <summary>
		/// User that initialized the join game
		/// </summary>
		public ProductUserId LocalUserId { get; set; }

		/// <summary>
		/// The UI Event associated with this Join Game event.
		/// This should be used with <see cref="LobbyInterface.CopyLobbyDetailsHandleByUiEventId" /> to get a handle to be used
		/// when calling <see cref="LobbyInterface.JoinLobby" />.
		/// </summary>
		public ulong UiEventId { get; set; }
	}

	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct JoinLobbyAcceptedCallbackInfoInternal : ICallbackInfo
	{
		private IntPtr m_ClientData;
		private IntPtr m_LocalUserId;
		private ulong m_UiEventId;

		public object ClientData
		{
			get
			{
				var value = Helper.GetDefault<object>();
				Helper.TryMarshalGet(m_ClientData, out value);
				return value;
			}
		}

		public IntPtr ClientDataAddress { get { return m_ClientData; } }

		public ProductUserId LocalUserId
		{
			get
			{
				var value = Helper.GetDefault<ProductUserId>();
				Helper.TryMarshalGet(m_LocalUserId, out value);
				return value;
			}
		}

		public ulong UiEventId
		{
			get
			{
				var value = Helper.GetDefault<ulong>();
				Helper.TryMarshalGet(m_UiEventId, out value);
				return value;
			}
		}
	}
}
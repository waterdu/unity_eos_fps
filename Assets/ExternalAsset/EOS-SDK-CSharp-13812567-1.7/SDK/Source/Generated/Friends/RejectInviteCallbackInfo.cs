// Copyright Epic Games, Inc. All Rights Reserved.
// This file is automatically generated. Changes to this file may be overwritten.

using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Friends
{
	/// <summary>
	/// Output parameters for the <see cref="FriendsInterface.RejectInvite" /> Function.
	/// </summary>
	public class RejectInviteCallbackInfo
	{
		/// <summary>
		/// Result code for the operation. <see cref="Result.Success" /> is returned if an invite was accepted, otherwise one of the error codes is returned. See <see cref="Common" />
		/// </summary>
		public Result ResultCode { get; set; }

		/// <summary>
		/// Context that was passed into to <see cref="FriendsInterface.RejectInvite" />
		/// </summary>
		public object ClientData { get; set; }

		/// <summary>
		/// Account ID of the user who is rejecting a friendship invitation
		/// </summary>
		public EpicAccountId LocalUserId { get; set; }

		/// <summary>
		/// Account ID of the user who sent the friendship invitation
		/// </summary>
		public EpicAccountId TargetUserId { get; set; }
	}

	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct RejectInviteCallbackInfoInternal : ICallbackInfo
	{
		private Result m_ResultCode;
		private IntPtr m_ClientData;
		private IntPtr m_LocalUserId;
		private IntPtr m_TargetUserId;

		public Result ResultCode
		{
			get
			{
				var value = Helper.GetDefault<Result>();
				Helper.TryMarshalGet(m_ResultCode, out value);
				return value;
			}
		}

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

		public EpicAccountId LocalUserId
		{
			get
			{
				var value = Helper.GetDefault<EpicAccountId>();
				Helper.TryMarshalGet(m_LocalUserId, out value);
				return value;
			}
		}

		public EpicAccountId TargetUserId
		{
			get
			{
				var value = Helper.GetDefault<EpicAccountId>();
				Helper.TryMarshalGet(m_TargetUserId, out value);
				return value;
			}
		}
	}
}
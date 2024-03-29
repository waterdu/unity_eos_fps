// Copyright Epic Games, Inc. All Rights Reserved.
// This file is automatically generated. Changes to this file may be overwritten.

using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Presence
{
	/// <summary>
	/// Data for the <see cref="CreatePresenceModificationOptions" /> function.
	/// </summary>
	public class CreatePresenceModificationOptions
	{
		/// <summary>
		/// API Version of the <see cref="CreatePresenceModificationOptions" /> function
		/// </summary>
		public int ApiVersion { get { return 1; } }

		/// <summary>
		/// The local user account id
		/// </summary>
		public EpicAccountId LocalUserId { get; set; }
	}

	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct CreatePresenceModificationOptionsInternal : IDisposable
	{
		private int m_ApiVersion;
		private IntPtr m_LocalUserId;

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

		public EpicAccountId LocalUserId
		{
			get
			{
				var value = Helper.GetDefault<EpicAccountId>();
				Helper.TryMarshalGet(m_LocalUserId, out value);
				return value;
			}
			set { Helper.TryMarshalSet(ref m_LocalUserId, value); }
		}

		public void Dispose()
		{
		}
	}
}
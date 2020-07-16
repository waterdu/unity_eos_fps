// Copyright Epic Games, Inc. All Rights Reserved.
// This file is automatically generated. Changes to this file may be overwritten.

using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Connect
{
	/// <summary>
	/// Input parameters for the <see cref="ConnectInterface.LinkAccount" /> Function.
	/// </summary>
	public class LinkAccountOptions
	{
		/// <summary>
		/// Version of the API
		/// </summary>
		public int ApiVersion { get { return 1; } }

		/// <summary>
		/// Existing logged in user that will link to the external account referenced by the continuance token
		/// </summary>
		public ProductUserId LocalUserId { get; set; }

		/// <summary>
		/// Continuance token from previous call to <see cref="ConnectInterface.Login" />
		/// </summary>
		public ContinuanceToken ContinuanceToken { get; set; }
	}

	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct LinkAccountOptionsInternal : IDisposable
	{
		private int m_ApiVersion;
		private IntPtr m_LocalUserId;
		private IntPtr m_ContinuanceToken;

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

		public ContinuanceToken ContinuanceToken
		{
			get
			{
				var value = Helper.GetDefault<ContinuanceToken>();
				Helper.TryMarshalGet(m_ContinuanceToken, out value);
				return value;
			}
			set { Helper.TryMarshalSet(ref m_ContinuanceToken, value); }
		}

		public void Dispose()
		{
		}
	}
}
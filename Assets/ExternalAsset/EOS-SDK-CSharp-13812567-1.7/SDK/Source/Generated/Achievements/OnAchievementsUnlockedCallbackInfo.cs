// Copyright Epic Games, Inc. All Rights Reserved.
// This file is automatically generated. Changes to this file may be overwritten.

using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Achievements
{
	/// <summary>
	/// Output parameters for the <see cref="OnAchievementsUnlockedCallback" /> Function.
	/// </summary>
	public class OnAchievementsUnlockedCallbackInfo
	{
		/// <summary>
		/// Context that was passed into <see cref="AchievementsInterface.AddNotifyAchievementsUnlocked" />
		/// </summary>
		public object ClientData { get; set; }

		/// <summary>
		/// Account ID for user that received the unlocked achievements notification
		/// </summary>
		public ProductUserId UserId { get; set; }

		/// <summary>
		/// This member is not used and will always be set to NULL.
		/// </summary>
		public string[] AchievementIds { get; set; }
	}

	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct OnAchievementsUnlockedCallbackInfoInternal : ICallbackInfo
	{
		private IntPtr m_ClientData;
		private IntPtr m_UserId;
		private uint m_AchievementsCount;
		private IntPtr m_AchievementIds;

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

		public ProductUserId UserId
		{
			get
			{
				var value = Helper.GetDefault<ProductUserId>();
				Helper.TryMarshalGet(m_UserId, out value);
				return value;
			}
		}

		public string[] AchievementIds
		{
			get
			{
				var value = Helper.GetDefault<string[]>();
				Helper.TryMarshalGet(m_AchievementIds, out value, m_AchievementsCount);
				return value;
			}
		}
	}
}
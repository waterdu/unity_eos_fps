// Copyright Epic Games, Inc. All Rights Reserved.
// This file is automatically generated. Changes to this file may be overwritten.

using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Achievements
{
	/// <summary>
	/// Contains information about a single achievement definition with localized text.
	/// </summary>
	public class DefinitionV2
	{
		/// <summary>
		/// Version of the API.
		/// </summary>
		public int ApiVersion { get { return 2; } }

		/// <summary>
		/// Achievement ID that can be used to uniquely identify the achievement.
		/// </summary>
		public string AchievementId { get; set; }

		/// <summary>
		/// Localized display name for the achievement when it has been unlocked.
		/// </summary>
		public string UnlockedDisplayName { get; set; }

		/// <summary>
		/// Localized description for the achievement when it has been unlocked.
		/// </summary>
		public string UnlockedDescription { get; set; }

		/// <summary>
		/// Localized display name for the achievement when it is locked or hidden.
		/// </summary>
		public string LockedDisplayName { get; set; }

		/// <summary>
		/// Localized description for the achievement when it is locked or hidden.
		/// </summary>
		public string LockedDescription { get; set; }

		/// <summary>
		/// Localized flavor text that can be used by the game in an arbitrary manner. This may be null if there is no data configured in the dev portal
		/// </summary>
		public string FlavorText { get; set; }

		/// <summary>
		/// URL of an icon to display for the achievement when it is unlocked. This may be null if there is no data configured in the dev portal
		/// </summary>
		public string UnlockedIconURL { get; set; }

		/// <summary>
		/// URL of an icon to display for the achievement when it is locked or hidden. This may be null if there is no data configured in the dev portal
		/// </summary>
		public string LockedIconURL { get; set; }

		/// <summary>
		/// True if achievement is hidden, false otherwise.
		/// </summary>
		public bool IsHidden { get; set; }

		/// <summary>
		/// Array of stat thresholds that need to be satisfied to unlock the achievement.
		/// </summary>
		public StatThresholds[] StatThresholds { get; set; }
	}

	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct DefinitionV2Internal : IDisposable
	{
		private int m_ApiVersion;
		[MarshalAs(UnmanagedType.LPStr)]
		private string m_AchievementId;
		[MarshalAs(UnmanagedType.LPStr)]
		private string m_UnlockedDisplayName;
		[MarshalAs(UnmanagedType.LPStr)]
		private string m_UnlockedDescription;
		[MarshalAs(UnmanagedType.LPStr)]
		private string m_LockedDisplayName;
		[MarshalAs(UnmanagedType.LPStr)]
		private string m_LockedDescription;
		[MarshalAs(UnmanagedType.LPStr)]
		private string m_FlavorText;
		[MarshalAs(UnmanagedType.LPStr)]
		private string m_UnlockedIconURL;
		[MarshalAs(UnmanagedType.LPStr)]
		private string m_LockedIconURL;
		private int m_IsHidden;
		private uint m_StatThresholdsCount;
		private IntPtr m_StatThresholds;

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

		public string AchievementId
		{
			get
			{
				var value = Helper.GetDefault<string>();
				Helper.TryMarshalGet(m_AchievementId, out value);
				return value;
			}
			set { Helper.TryMarshalSet(ref m_AchievementId, value); }
		}

		public string UnlockedDisplayName
		{
			get
			{
				var value = Helper.GetDefault<string>();
				Helper.TryMarshalGet(m_UnlockedDisplayName, out value);
				return value;
			}
			set { Helper.TryMarshalSet(ref m_UnlockedDisplayName, value); }
		}

		public string UnlockedDescription
		{
			get
			{
				var value = Helper.GetDefault<string>();
				Helper.TryMarshalGet(m_UnlockedDescription, out value);
				return value;
			}
			set { Helper.TryMarshalSet(ref m_UnlockedDescription, value); }
		}

		public string LockedDisplayName
		{
			get
			{
				var value = Helper.GetDefault<string>();
				Helper.TryMarshalGet(m_LockedDisplayName, out value);
				return value;
			}
			set { Helper.TryMarshalSet(ref m_LockedDisplayName, value); }
		}

		public string LockedDescription
		{
			get
			{
				var value = Helper.GetDefault<string>();
				Helper.TryMarshalGet(m_LockedDescription, out value);
				return value;
			}
			set { Helper.TryMarshalSet(ref m_LockedDescription, value); }
		}

		public string FlavorText
		{
			get
			{
				var value = Helper.GetDefault<string>();
				Helper.TryMarshalGet(m_FlavorText, out value);
				return value;
			}
			set { Helper.TryMarshalSet(ref m_FlavorText, value); }
		}

		public string UnlockedIconURL
		{
			get
			{
				var value = Helper.GetDefault<string>();
				Helper.TryMarshalGet(m_UnlockedIconURL, out value);
				return value;
			}
			set { Helper.TryMarshalSet(ref m_UnlockedIconURL, value); }
		}

		public string LockedIconURL
		{
			get
			{
				var value = Helper.GetDefault<string>();
				Helper.TryMarshalGet(m_LockedIconURL, out value);
				return value;
			}
			set { Helper.TryMarshalSet(ref m_LockedIconURL, value); }
		}

		public bool IsHidden
		{
			get
			{
				var value = Helper.GetDefault<bool>();
				Helper.TryMarshalGet(m_IsHidden, out value);
				return value;
			}
			set { Helper.TryMarshalSet(ref m_IsHidden, value); }
		}

		public StatThresholdsInternal[] StatThresholds
		{
			get
			{
				var value = Helper.GetDefault<StatThresholdsInternal[]>();
				Helper.TryMarshalGet(m_StatThresholds, out value, m_StatThresholdsCount);
				return value;
			}
			set { Helper.TryMarshalSet(ref m_StatThresholds, value, out m_StatThresholdsCount); }
		}

		public void Dispose()
		{
			Helper.TryMarshalDispose(ref m_StatThresholds);
		}
	}
}
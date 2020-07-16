// Copyright Epic Games, Inc. All Rights Reserved.
// This file is automatically generated. Changes to this file may be overwritten.

using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Leaderboards
{
	/// <summary>
	/// Contains information about a single leaderboard definition
	/// </summary>
	public class Definition
	{
		/// <summary>
		/// Version of the API.
		/// </summary>
		public int ApiVersion { get { return 1; } }

		/// <summary>
		/// Unique ID to identify leaderboard.
		/// </summary>
		public string LeaderboardId { get; set; }

		/// <summary>
		/// Name of stat used to rank leaderboard.
		/// </summary>
		public string StatName { get; set; }

		/// <summary>
		/// Aggregation used to sort leaderboard.
		/// </summary>
		public LeaderboardAggregation Aggregation { get; set; }

		/// <summary>
		/// The POSIX timestamp for the start time, or <see cref="LeaderboardsInterface.TimeUndefined" />.
		/// </summary>
		public DateTimeOffset? StartTime { get; set; }

		/// <summary>
		/// The POSIX timestamp for the end time, or <see cref="LeaderboardsInterface.TimeUndefined" />.
		/// </summary>
		public DateTimeOffset? EndTime { get; set; }
	}

	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct DefinitionInternal : IDisposable
	{
		private int m_ApiVersion;
		[MarshalAs(UnmanagedType.LPStr)]
		private string m_LeaderboardId;
		[MarshalAs(UnmanagedType.LPStr)]
		private string m_StatName;
		private LeaderboardAggregation m_Aggregation;
		private long m_StartTime;
		private long m_EndTime;

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

		public string LeaderboardId
		{
			get
			{
				var value = Helper.GetDefault<string>();
				Helper.TryMarshalGet(m_LeaderboardId, out value);
				return value;
			}
			set { Helper.TryMarshalSet(ref m_LeaderboardId, value); }
		}

		public string StatName
		{
			get
			{
				var value = Helper.GetDefault<string>();
				Helper.TryMarshalGet(m_StatName, out value);
				return value;
			}
			set { Helper.TryMarshalSet(ref m_StatName, value); }
		}

		public LeaderboardAggregation Aggregation
		{
			get
			{
				var value = Helper.GetDefault<LeaderboardAggregation>();
				Helper.TryMarshalGet(m_Aggregation, out value);
				return value;
			}
			set { Helper.TryMarshalSet(ref m_Aggregation, value); }
		}

		public DateTimeOffset? StartTime
		{
			get
			{
				var value = Helper.GetDefault<DateTimeOffset?>();
				Helper.TryMarshalGet(m_StartTime, out value);
				return value;
			}
			set { Helper.TryMarshalSet(ref m_StartTime, value); }
		}

		public DateTimeOffset? EndTime
		{
			get
			{
				var value = Helper.GetDefault<DateTimeOffset?>();
				Helper.TryMarshalGet(m_EndTime, out value);
				return value;
			}
			set { Helper.TryMarshalSet(ref m_EndTime, value); }
		}

		public void Dispose()
		{
		}
	}
}
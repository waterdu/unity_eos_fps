// Copyright Epic Games, Inc. All Rights Reserved.
// This file is automatically generated. Changes to this file may be overwritten.

using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Achievements
{
	public sealed class AchievementsInterface : Handle
	{
		public AchievementsInterface() : base(IntPtr.Zero)
		{
		}

		public AchievementsInterface(IntPtr innerHandle) : base(innerHandle)
		{
		}

		/// <summary>
		/// Timestamp value representing an undefined UnlockTime for <see cref="PlayerAchievement" /> and <see cref="UnlockedAchievement" />
		/// </summary>
		public const int AchievementUnlocktimeUndefined = -1;

		/// <summary>
		/// Query for a list of definitions for all existing achievements, including localized text, icon IDs and whether an achievement is hidden.
		/// 
		/// @note When the Social Overlay is enabled then this will be called automatically. The Social Overlay is enabled by default (see <see cref="Platform.PlatformFlags.DisableSocialOverlay" />).
		/// </summary>
		/// <param name="options">Structure containing information about the application whose achievement definitions we're retrieving.</param>
		/// <param name="clientData">Arbitrary data that is passed back to you in the CompletionDelegate</param>
		/// <param name="completionDelegate">This function is called when the query definitions operation completes.</param>
		/// <returns>
		/// <see cref="Result.Success" /> if the operation completes successfully
		/// <see cref="Result.InvalidParameters" /> if any of the options are incorrect
		/// </returns>
		public void QueryDefinitions(QueryDefinitionsOptions options, object clientData, OnQueryDefinitionsCompleteCallback completionDelegate)
		{
			var optionsInternal = Helper.CopyProperties<QueryDefinitionsOptionsInternal>(options);

			var completionDelegateInternal = new OnQueryDefinitionsCompleteCallbackInternal(OnQueryDefinitionsComplete);
			var clientDataAddress = IntPtr.Zero;
			Helper.AddCallback(ref clientDataAddress, clientData, completionDelegate, completionDelegateInternal);

			EOS_Achievements_QueryDefinitions(InnerHandle, ref optionsInternal, clientDataAddress, completionDelegateInternal);
			Helper.TryMarshalDispose(ref optionsInternal);
		}

		/// <summary>
		/// Fetch the number of achievement definitions that are cached locally.
		/// <seealso cref="CopyAchievementDefinitionByIndex" />
		/// <seealso cref="Achievements" />
		/// </summary>
		/// <param name="options">The Options associated with retrieving the achievement definition count</param>
		/// <returns>
		/// Number of achievement definitions or 0 if there is an error
		/// </returns>
		public uint GetAchievementDefinitionCount(GetAchievementDefinitionCountOptions options)
		{
			var optionsInternal = Helper.CopyProperties<GetAchievementDefinitionCountOptionsInternal>(options);

			var funcResult = EOS_Achievements_GetAchievementDefinitionCount(InnerHandle, ref optionsInternal);
			Helper.TryMarshalDispose(ref optionsInternal);

			var funcResultReturn = Helper.GetDefault<uint>();
			Helper.TryMarshalGet(funcResult, out funcResultReturn);
			return funcResultReturn;
		}

		/// <summary>
		/// Fetches an achievement definition from a given index.
		/// <seealso cref="Release" />
		/// <seealso cref="Achievements" />
		/// </summary>
		/// <param name="options">Structure containing the index being accessed</param>
		/// <param name="outDefinition">The achievement definition for the given index, if it exists and is valid, use <see cref="Release" /> when finished</param>
		/// <returns>
		/// <see cref="Result.Success" /> if the information is available and passed out in OutDefinition
		/// <see cref="Result.InvalidParameters" /> if you pass a null pointer for the out parameter
		/// <see cref="Result.NotFound" /> if the achievement definition is not found
		/// </returns>
		public Result CopyAchievementDefinitionV2ByIndex(CopyAchievementDefinitionV2ByIndexOptions options, out DefinitionV2 outDefinition)
		{
			var optionsInternal = Helper.CopyProperties<CopyAchievementDefinitionV2ByIndexOptionsInternal>(options);

			outDefinition = Helper.GetDefault<DefinitionV2>();

			var outDefinitionAddress = IntPtr.Zero;

			var funcResult = EOS_Achievements_CopyAchievementDefinitionV2ByIndex(InnerHandle, ref optionsInternal, ref outDefinitionAddress);
			Helper.TryMarshalDispose(ref optionsInternal);

			if (Helper.TryMarshalGet<DefinitionV2Internal, DefinitionV2>(outDefinitionAddress, out outDefinition))
			{
				EOS_Achievements_DefinitionV2_Release(outDefinitionAddress);
			}

			var funcResultReturn = Helper.GetDefault<Result>();
			Helper.TryMarshalGet(funcResult, out funcResultReturn);
			return funcResultReturn;
		}

		/// <summary>
		/// Fetches an achievement definition from a given achievement ID.
		/// <seealso cref="Release" />
		/// <seealso cref="Achievements" />
		/// </summary>
		/// <param name="options">Structure containing the achievement ID being accessed</param>
		/// <param name="outDefinition">The achievement definition for the given achievement ID, if it exists and is valid, use <see cref="Release" /> when finished</param>
		/// <returns>
		/// <see cref="Result.Success" /> if the information is available and passed out in OutDefinition
		/// <see cref="Result.InvalidParameters" /> if you pass a null pointer for the out parameter
		/// <see cref="Result.NotFound" /> if the achievement definition is not found
		/// </returns>
		public Result CopyAchievementDefinitionV2ByAchievementId(CopyAchievementDefinitionV2ByAchievementIdOptions options, out DefinitionV2 outDefinition)
		{
			var optionsInternal = Helper.CopyProperties<CopyAchievementDefinitionV2ByAchievementIdOptionsInternal>(options);

			outDefinition = Helper.GetDefault<DefinitionV2>();

			var outDefinitionAddress = IntPtr.Zero;

			var funcResult = EOS_Achievements_CopyAchievementDefinitionV2ByAchievementId(InnerHandle, ref optionsInternal, ref outDefinitionAddress);
			Helper.TryMarshalDispose(ref optionsInternal);

			if (Helper.TryMarshalGet<DefinitionV2Internal, DefinitionV2>(outDefinitionAddress, out outDefinition))
			{
				EOS_Achievements_DefinitionV2_Release(outDefinitionAddress);
			}

			var funcResultReturn = Helper.GetDefault<Result>();
			Helper.TryMarshalGet(funcResult, out funcResultReturn);
			return funcResultReturn;
		}

		/// <summary>
		/// Query for a list of achievements for a specific player, including progress towards completion for each achievement.
		/// 
		/// @note When the Social Overlay is enabled then this will be called automatically. The Social Overlay is enabled by default (see <see cref="Platform.PlatformFlags.DisableSocialOverlay" />).
		/// </summary>
		/// <param name="options">Structure containing information about the player whose achievements we're retrieving.</param>
		/// <param name="clientData">Arbitrary data that is passed back to you in the CompletionDelegate</param>
		/// <param name="completionDelegate">This function is called when the query player achievements operation completes.</param>
		/// <returns>
		/// <see cref="Result.Success" /> if the operation completes successfully
		/// <see cref="Result.InvalidParameters" /> if any of the options are incorrect
		/// </returns>
		public void QueryPlayerAchievements(QueryPlayerAchievementsOptions options, object clientData, OnQueryPlayerAchievementsCompleteCallback completionDelegate)
		{
			var optionsInternal = Helper.CopyProperties<QueryPlayerAchievementsOptionsInternal>(options);

			var completionDelegateInternal = new OnQueryPlayerAchievementsCompleteCallbackInternal(OnQueryPlayerAchievementsComplete);
			var clientDataAddress = IntPtr.Zero;
			Helper.AddCallback(ref clientDataAddress, clientData, completionDelegate, completionDelegateInternal);

			EOS_Achievements_QueryPlayerAchievements(InnerHandle, ref optionsInternal, clientDataAddress, completionDelegateInternal);
			Helper.TryMarshalDispose(ref optionsInternal);
		}

		/// <summary>
		/// Fetch the number of player achievements that are cached locally.
		/// <seealso cref="CopyPlayerAchievementByIndex" />
		/// <seealso cref="Achievements" />
		/// </summary>
		/// <param name="options">The Options associated with retrieving the player achievement count</param>
		/// <returns>
		/// Number of player achievements or 0 if there is an error
		/// </returns>
		public uint GetPlayerAchievementCount(GetPlayerAchievementCountOptions options)
		{
			var optionsInternal = Helper.CopyProperties<GetPlayerAchievementCountOptionsInternal>(options);

			var funcResult = EOS_Achievements_GetPlayerAchievementCount(InnerHandle, ref optionsInternal);
			Helper.TryMarshalDispose(ref optionsInternal);

			var funcResultReturn = Helper.GetDefault<uint>();
			Helper.TryMarshalGet(funcResult, out funcResultReturn);
			return funcResultReturn;
		}

		/// <summary>
		/// Fetches a player achievement from a given index.
		/// <seealso cref="Release" />
		/// <seealso cref="Achievements" />
		/// </summary>
		/// <param name="options">Structure containing the account id and index being accessed</param>
		/// <param name="outAchievement">The player achievement data for the given index, if it exists and is valid, use <see cref="Release" /> when finished</param>
		/// <returns>
		/// <see cref="Result.Success" /> if the information is available and passed out in OutAchievement
		/// <see cref="Result.InvalidParameters" /> if you pass a null pointer for the out parameter
		/// <see cref="Result.NotFound" /> if the player achievement is not found
		/// </returns>
		public Result CopyPlayerAchievementByIndex(CopyPlayerAchievementByIndexOptions options, out PlayerAchievement outAchievement)
		{
			var optionsInternal = Helper.CopyProperties<CopyPlayerAchievementByIndexOptionsInternal>(options);

			outAchievement = Helper.GetDefault<PlayerAchievement>();

			var outAchievementAddress = IntPtr.Zero;

			var funcResult = EOS_Achievements_CopyPlayerAchievementByIndex(InnerHandle, ref optionsInternal, ref outAchievementAddress);
			Helper.TryMarshalDispose(ref optionsInternal);

			if (Helper.TryMarshalGet<PlayerAchievementInternal, PlayerAchievement>(outAchievementAddress, out outAchievement))
			{
				EOS_Achievements_PlayerAchievement_Release(outAchievementAddress);
			}

			var funcResultReturn = Helper.GetDefault<Result>();
			Helper.TryMarshalGet(funcResult, out funcResultReturn);
			return funcResultReturn;
		}

		/// <summary>
		/// Fetches a player achievement from a given achievement id.
		/// <seealso cref="Release" />
		/// <seealso cref="Achievements" />
		/// </summary>
		/// <param name="options">Structure containing the account id and achievement id being accessed</param>
		/// <param name="outAchievement">The player achievement data for the given achievement id, if it exists and is valid, use <see cref="Release" /> when finished</param>
		/// <returns>
		/// <see cref="Result.Success" /> if the information is available and passed out in OutAchievement
		/// <see cref="Result.InvalidParameters" /> if you pass a null pointer for the out parameter
		/// <see cref="Result.NotFound" /> if the player achievement is not found
		/// </returns>
		public Result CopyPlayerAchievementByAchievementId(CopyPlayerAchievementByAchievementIdOptions options, out PlayerAchievement outAchievement)
		{
			var optionsInternal = Helper.CopyProperties<CopyPlayerAchievementByAchievementIdOptionsInternal>(options);

			outAchievement = Helper.GetDefault<PlayerAchievement>();

			var outAchievementAddress = IntPtr.Zero;

			var funcResult = EOS_Achievements_CopyPlayerAchievementByAchievementId(InnerHandle, ref optionsInternal, ref outAchievementAddress);
			Helper.TryMarshalDispose(ref optionsInternal);

			if (Helper.TryMarshalGet<PlayerAchievementInternal, PlayerAchievement>(outAchievementAddress, out outAchievement))
			{
				EOS_Achievements_PlayerAchievement_Release(outAchievementAddress);
			}

			var funcResultReturn = Helper.GetDefault<Result>();
			Helper.TryMarshalGet(funcResult, out funcResultReturn);
			return funcResultReturn;
		}

		/// <summary>
		/// Unlocks a number of achievements for a specific player.
		/// </summary>
		/// <param name="options">Structure containing information about the achievements and the player whose achievements we're unlocking.</param>
		/// <param name="clientData">Arbitrary data that is passed back to you in the CompletionDelegate</param>
		/// <param name="completionDelegate">This function is called when the unlock achievements operation completes.</param>
		/// <returns>
		/// <see cref="Result.Success" /> if the operation completes successfully
		/// <see cref="Result.InvalidParameters" /> if any of the options are incorrect
		/// </returns>
		public void UnlockAchievements(UnlockAchievementsOptions options, object clientData, OnUnlockAchievementsCompleteCallback completionDelegate)
		{
			var optionsInternal = Helper.CopyProperties<UnlockAchievementsOptionsInternal>(options);

			var completionDelegateInternal = new OnUnlockAchievementsCompleteCallbackInternal(OnUnlockAchievementsComplete);
			var clientDataAddress = IntPtr.Zero;
			Helper.AddCallback(ref clientDataAddress, clientData, completionDelegate, completionDelegateInternal);

			EOS_Achievements_UnlockAchievements(InnerHandle, ref optionsInternal, clientDataAddress, completionDelegateInternal);
			Helper.TryMarshalDispose(ref optionsInternal);
		}

		/// <summary>
		/// Register to receive achievement unlocked notifications.
		/// @note must call <see cref="RemoveNotifyAchievementsUnlocked" /> to remove the notification
		/// <seealso cref="RemoveNotifyAchievementsUnlocked" />
		/// <seealso cref="Achievements" />
		/// </summary>
		/// <param name="options">Structure containing information about the achievement unlocked notification</param>
		/// <param name="clientData">Arbitrary data that is passed back to you in the CompletionDelegate</param>
		/// <param name="notificationFn">A callback that is fired when an achievement unlocked notification for a user has been received</param>
		/// <returns>
		/// handle representing the registered callback
		/// </returns>
		public ulong AddNotifyAchievementsUnlockedV2(AddNotifyAchievementsUnlockedV2Options options, object clientData, OnAchievementsUnlockedCallbackV2 notificationFn)
		{
			var optionsInternal = Helper.CopyProperties<AddNotifyAchievementsUnlockedV2OptionsInternal>(options);

			var notificationFnInternal = new OnAchievementsUnlockedCallbackV2Internal(OnAchievementsUnlockedV2);
			var clientDataAddress = IntPtr.Zero;
			Helper.AddCallback(ref clientDataAddress, clientData, notificationFn, notificationFnInternal);

			var funcResult = EOS_Achievements_AddNotifyAchievementsUnlockedV2(InnerHandle, ref optionsInternal, clientDataAddress, notificationFnInternal);
			Helper.TryMarshalDispose(ref optionsInternal);

			Helper.TryAssignNotificationIdToCallback(clientDataAddress, funcResult);

			var funcResultReturn = Helper.GetDefault<ulong>();
			Helper.TryMarshalGet(funcResult, out funcResultReturn);
			return funcResultReturn;
		}

		/// <summary>
		/// Unregister from receiving achievement unlocked notifications.
		/// <seealso cref="AddNotifyAchievementsUnlocked" />
		/// <seealso cref="Achievements" />
		/// </summary>
		/// <param name="inId">Handle representing the registered callback</param>
		public void RemoveNotifyAchievementsUnlocked(ulong inId)
		{
			Helper.TryRemoveCallbackByNotificationId(inId);
			EOS_Achievements_RemoveNotifyAchievementsUnlocked(InnerHandle, inId);
		}

		/// <summary>
		/// DEPRECATED! Use <see cref="CopyAchievementDefinitionV2ByIndex" /> instead.
		/// 
		/// Fetches an achievement definition from a given index.
		/// <seealso cref="CopyAchievementDefinitionV2ByIndex" />
		/// <seealso cref="Release" />
		/// <seealso cref="Achievements" />
		/// </summary>
		/// <param name="options">Structure containing the index being accessed</param>
		/// <param name="outDefinition">The achievement definition for the given index, if it exists and is valid, use <see cref="Release" /> when finished</param>
		/// <returns>
		/// <see cref="Result.Success" /> if the information is available and passed out in OutDefinition
		/// <see cref="Result.InvalidParameters" /> if you pass a null pointer for the out parameter
		/// <see cref="Result.NotFound" /> if the achievement definition is not found
		/// </returns>
		public Result CopyAchievementDefinitionByIndex(CopyAchievementDefinitionByIndexOptions options, out Definition outDefinition)
		{
			var optionsInternal = Helper.CopyProperties<CopyAchievementDefinitionByIndexOptionsInternal>(options);

			outDefinition = Helper.GetDefault<Definition>();

			var outDefinitionAddress = IntPtr.Zero;

			var funcResult = EOS_Achievements_CopyAchievementDefinitionByIndex(InnerHandle, ref optionsInternal, ref outDefinitionAddress);
			Helper.TryMarshalDispose(ref optionsInternal);

			if (Helper.TryMarshalGet<DefinitionInternal, Definition>(outDefinitionAddress, out outDefinition))
			{
				EOS_Achievements_Definition_Release(outDefinitionAddress);
			}

			var funcResultReturn = Helper.GetDefault<Result>();
			Helper.TryMarshalGet(funcResult, out funcResultReturn);
			return funcResultReturn;
		}

		/// <summary>
		/// DEPRECATED! Use <see cref="CopyAchievementDefinitionV2ByAchievementId" /> instead.
		/// 
		/// Fetches an achievement definition from a given achievement ID.
		/// <seealso cref="Release" />
		/// <seealso cref="CopyAchievementDefinitionV2ByAchievementId" />
		/// <seealso cref="Achievements" />
		/// </summary>
		/// <param name="options">Structure containing the achievement ID being accessed</param>
		/// <param name="outDefinition">The achievement definition for the given achievement ID, if it exists and is valid, use <see cref="Release" /> when finished</param>
		/// <returns>
		/// <see cref="Result.Success" /> if the information is available and passed out in OutDefinition
		/// <see cref="Result.InvalidParameters" /> if you pass a null pointer for the out parameter
		/// <see cref="Result.NotFound" /> if the achievement definition is not found
		/// </returns>
		public Result CopyAchievementDefinitionByAchievementId(CopyAchievementDefinitionByAchievementIdOptions options, out Definition outDefinition)
		{
			var optionsInternal = Helper.CopyProperties<CopyAchievementDefinitionByAchievementIdOptionsInternal>(options);

			outDefinition = Helper.GetDefault<Definition>();

			var outDefinitionAddress = IntPtr.Zero;

			var funcResult = EOS_Achievements_CopyAchievementDefinitionByAchievementId(InnerHandle, ref optionsInternal, ref outDefinitionAddress);
			Helper.TryMarshalDispose(ref optionsInternal);

			if (Helper.TryMarshalGet<DefinitionInternal, Definition>(outDefinitionAddress, out outDefinition))
			{
				EOS_Achievements_Definition_Release(outDefinitionAddress);
			}

			var funcResultReturn = Helper.GetDefault<Result>();
			Helper.TryMarshalGet(funcResult, out funcResultReturn);
			return funcResultReturn;
		}

		/// <summary>
		/// DEPRECATED! Use <see cref="GetPlayerAchievementCount" />, <see cref="CopyPlayerAchievementByIndex" /> and filter for unlocked instead.
		/// 
		/// Fetch the number of unlocked achievements that are cached locally.
		/// <seealso cref="CopyUnlockedAchievementByIndex" />
		/// <seealso cref="Achievements" />
		/// </summary>
		/// <param name="options">The Options associated with retrieving the unlocked achievement count</param>
		/// <returns>
		/// Number of unlocked achievements or 0 if there is an error
		/// </returns>
		public uint GetUnlockedAchievementCount(GetUnlockedAchievementCountOptions options)
		{
			var optionsInternal = Helper.CopyProperties<GetUnlockedAchievementCountOptionsInternal>(options);

			var funcResult = EOS_Achievements_GetUnlockedAchievementCount(InnerHandle, ref optionsInternal);
			Helper.TryMarshalDispose(ref optionsInternal);

			var funcResultReturn = Helper.GetDefault<uint>();
			Helper.TryMarshalGet(funcResult, out funcResultReturn);
			return funcResultReturn;
		}

		/// <summary>
		/// DEPRECATED! Use <see cref="CopyPlayerAchievementByAchievementId" /> instead.
		/// 
		/// Fetches an unlocked achievement from a given index.
		/// <seealso cref="Release" />
		/// <seealso cref="Achievements" />
		/// </summary>
		/// <param name="options">Structure containing the account id and index being accessed</param>
		/// <param name="outAchievement">The unlocked achievement data for the given index, if it exists and is valid, use <see cref="Release" /> when finished</param>
		/// <returns>
		/// <see cref="Result.Success" /> if the information is available and passed out in OutAchievement
		/// <see cref="Result.InvalidParameters" /> if you pass a null pointer for the out parameter
		/// <see cref="Result.NotFound" /> if the unlocked achievement is not found
		/// </returns>
		public Result CopyUnlockedAchievementByIndex(CopyUnlockedAchievementByIndexOptions options, out UnlockedAchievement outAchievement)
		{
			var optionsInternal = Helper.CopyProperties<CopyUnlockedAchievementByIndexOptionsInternal>(options);

			outAchievement = Helper.GetDefault<UnlockedAchievement>();

			var outAchievementAddress = IntPtr.Zero;

			var funcResult = EOS_Achievements_CopyUnlockedAchievementByIndex(InnerHandle, ref optionsInternal, ref outAchievementAddress);
			Helper.TryMarshalDispose(ref optionsInternal);

			if (Helper.TryMarshalGet<UnlockedAchievementInternal, UnlockedAchievement>(outAchievementAddress, out outAchievement))
			{
				EOS_Achievements_UnlockedAchievement_Release(outAchievementAddress);
			}

			var funcResultReturn = Helper.GetDefault<Result>();
			Helper.TryMarshalGet(funcResult, out funcResultReturn);
			return funcResultReturn;
		}

		/// <summary>
		/// DEPRECATED! Use <see cref="CopyPlayerAchievementByAchievementId" /> instead.
		/// 
		/// Fetches an unlocked achievement from a given achievement ID.
		/// <seealso cref="Release" />
		/// <seealso cref="Achievements" />
		/// </summary>
		/// <param name="options">Structure containing the account id and achievement ID being accessed</param>
		/// <param name="outAchievement">The unlocked achievement data for the given achievement ID, if it exists and is valid, use <see cref="Release" /> when finished</param>
		/// <returns>
		/// <see cref="Result.Success" /> if the information is available and passed out in OutAchievement
		/// <see cref="Result.InvalidParameters" /> if you pass a null pointer for the out parameter
		/// <see cref="Result.NotFound" /> if the unlocked achievement is not found
		/// </returns>
		public Result CopyUnlockedAchievementByAchievementId(CopyUnlockedAchievementByAchievementIdOptions options, out UnlockedAchievement outAchievement)
		{
			var optionsInternal = Helper.CopyProperties<CopyUnlockedAchievementByAchievementIdOptionsInternal>(options);

			outAchievement = Helper.GetDefault<UnlockedAchievement>();

			var outAchievementAddress = IntPtr.Zero;

			var funcResult = EOS_Achievements_CopyUnlockedAchievementByAchievementId(InnerHandle, ref optionsInternal, ref outAchievementAddress);
			Helper.TryMarshalDispose(ref optionsInternal);

			if (Helper.TryMarshalGet<UnlockedAchievementInternal, UnlockedAchievement>(outAchievementAddress, out outAchievement))
			{
				EOS_Achievements_UnlockedAchievement_Release(outAchievementAddress);
			}

			var funcResultReturn = Helper.GetDefault<Result>();
			Helper.TryMarshalGet(funcResult, out funcResultReturn);
			return funcResultReturn;
		}

		/// <summary>
		/// DEPRECATED! Use <see cref="AddNotifyAchievementsUnlockedV2" /> instead.
		/// 
		/// Register to receive achievement unlocked notifications.
		/// @note must call <see cref="RemoveNotifyAchievementsUnlocked" /> to remove the notification
		/// <seealso cref="RemoveNotifyAchievementsUnlocked" />
		/// <seealso cref="Achievements" />
		/// </summary>
		/// <param name="options">Structure containing information about the achievement unlocked notification</param>
		/// <param name="clientData">Arbitrary data that is passed back to you in the CompletionDelegate</param>
		/// <param name="notificationFn">A callback that is fired when an achievement unlocked notification for a user has been received</param>
		/// <returns>
		/// handle representing the registered callback
		/// </returns>
		public ulong AddNotifyAchievementsUnlocked(AddNotifyAchievementsUnlockedOptions options, object clientData, OnAchievementsUnlockedCallback notificationFn)
		{
			var optionsInternal = Helper.CopyProperties<AddNotifyAchievementsUnlockedOptionsInternal>(options);

			var notificationFnInternal = new OnAchievementsUnlockedCallbackInternal(OnAchievementsUnlocked);
			var clientDataAddress = IntPtr.Zero;
			Helper.AddCallback(ref clientDataAddress, clientData, notificationFn, notificationFnInternal);

			var funcResult = EOS_Achievements_AddNotifyAchievementsUnlocked(InnerHandle, ref optionsInternal, clientDataAddress, notificationFnInternal);
			Helper.TryMarshalDispose(ref optionsInternal);

			Helper.TryAssignNotificationIdToCallback(clientDataAddress, funcResult);

			var funcResultReturn = Helper.GetDefault<ulong>();
			Helper.TryMarshalGet(funcResult, out funcResultReturn);
			return funcResultReturn;
		}

		[MonoPInvokeCallback]
		internal static void OnAchievementsUnlocked(IntPtr address)
		{
			OnAchievementsUnlockedCallback callback = null;
			OnAchievementsUnlockedCallbackInfo callbackInfo = null;
			if (Helper.TryGetAndRemoveCallback<OnAchievementsUnlockedCallback, OnAchievementsUnlockedCallbackInfoInternal, OnAchievementsUnlockedCallbackInfo>(address, out callback, out callbackInfo))
			{
				callback(callbackInfo);
			}
		}

		[MonoPInvokeCallback]
		internal static void OnAchievementsUnlockedV2(IntPtr address)
		{
			OnAchievementsUnlockedCallbackV2 callback = null;
			OnAchievementsUnlockedCallbackV2Info callbackInfo = null;
			if (Helper.TryGetAndRemoveCallback<OnAchievementsUnlockedCallbackV2, OnAchievementsUnlockedCallbackV2InfoInternal, OnAchievementsUnlockedCallbackV2Info>(address, out callback, out callbackInfo))
			{
				callback(callbackInfo);
			}
		}

		[MonoPInvokeCallback]
		internal static void OnUnlockAchievementsComplete(IntPtr address)
		{
			OnUnlockAchievementsCompleteCallback callback = null;
			OnUnlockAchievementsCompleteCallbackInfo callbackInfo = null;
			if (Helper.TryGetAndRemoveCallback<OnUnlockAchievementsCompleteCallback, OnUnlockAchievementsCompleteCallbackInfoInternal, OnUnlockAchievementsCompleteCallbackInfo>(address, out callback, out callbackInfo))
			{
				callback(callbackInfo);
			}
		}

		[MonoPInvokeCallback]
		internal static void OnQueryPlayerAchievementsComplete(IntPtr address)
		{
			OnQueryPlayerAchievementsCompleteCallback callback = null;
			OnQueryPlayerAchievementsCompleteCallbackInfo callbackInfo = null;
			if (Helper.TryGetAndRemoveCallback<OnQueryPlayerAchievementsCompleteCallback, OnQueryPlayerAchievementsCompleteCallbackInfoInternal, OnQueryPlayerAchievementsCompleteCallbackInfo>(address, out callback, out callbackInfo))
			{
				callback(callbackInfo);
			}
		}

		[MonoPInvokeCallback]
		internal static void OnQueryDefinitionsComplete(IntPtr address)
		{
			OnQueryDefinitionsCompleteCallback callback = null;
			OnQueryDefinitionsCompleteCallbackInfo callbackInfo = null;
			if (Helper.TryGetAndRemoveCallback<OnQueryDefinitionsCompleteCallback, OnQueryDefinitionsCompleteCallbackInfoInternal, OnQueryDefinitionsCompleteCallbackInfo>(address, out callback, out callbackInfo))
			{
				callback(callbackInfo);
			}
		}

		[DllImport(Config.BinaryName)]
		private static extern void EOS_Achievements_UnlockedAchievement_Release(IntPtr achievement);

		[DllImport(Config.BinaryName)]
		private static extern void EOS_Achievements_Definition_Release(IntPtr achievementDefinition);

		[DllImport(Config.BinaryName)]
		private static extern void EOS_Achievements_PlayerAchievement_Release(IntPtr achievement);

		[DllImport(Config.BinaryName)]
		private static extern void EOS_Achievements_DefinitionV2_Release(IntPtr achievementDefinition);

		[DllImport(Config.BinaryName)]
		private static extern ulong EOS_Achievements_AddNotifyAchievementsUnlocked(IntPtr handle, ref AddNotifyAchievementsUnlockedOptionsInternal options, IntPtr clientData, OnAchievementsUnlockedCallbackInternal notificationFn);

		[DllImport(Config.BinaryName)]
		private static extern Result EOS_Achievements_CopyUnlockedAchievementByAchievementId(IntPtr handle, ref CopyUnlockedAchievementByAchievementIdOptionsInternal options, ref IntPtr outAchievement);

		[DllImport(Config.BinaryName)]
		private static extern Result EOS_Achievements_CopyUnlockedAchievementByIndex(IntPtr handle, ref CopyUnlockedAchievementByIndexOptionsInternal options, ref IntPtr outAchievement);

		[DllImport(Config.BinaryName)]
		private static extern uint EOS_Achievements_GetUnlockedAchievementCount(IntPtr handle, ref GetUnlockedAchievementCountOptionsInternal options);

		[DllImport(Config.BinaryName)]
		private static extern Result EOS_Achievements_CopyAchievementDefinitionByAchievementId(IntPtr handle, ref CopyAchievementDefinitionByAchievementIdOptionsInternal options, ref IntPtr outDefinition);

		[DllImport(Config.BinaryName)]
		private static extern Result EOS_Achievements_CopyAchievementDefinitionByIndex(IntPtr handle, ref CopyAchievementDefinitionByIndexOptionsInternal options, ref IntPtr outDefinition);

		[DllImport(Config.BinaryName)]
		private static extern void EOS_Achievements_RemoveNotifyAchievementsUnlocked(IntPtr handle, ulong inId);

		[DllImport(Config.BinaryName)]
		private static extern ulong EOS_Achievements_AddNotifyAchievementsUnlockedV2(IntPtr handle, ref AddNotifyAchievementsUnlockedV2OptionsInternal options, IntPtr clientData, OnAchievementsUnlockedCallbackV2Internal notificationFn);

		[DllImport(Config.BinaryName)]
		private static extern void EOS_Achievements_UnlockAchievements(IntPtr handle, ref UnlockAchievementsOptionsInternal options, IntPtr clientData, OnUnlockAchievementsCompleteCallbackInternal completionDelegate);

		[DllImport(Config.BinaryName)]
		private static extern Result EOS_Achievements_CopyPlayerAchievementByAchievementId(IntPtr handle, ref CopyPlayerAchievementByAchievementIdOptionsInternal options, ref IntPtr outAchievement);

		[DllImport(Config.BinaryName)]
		private static extern Result EOS_Achievements_CopyPlayerAchievementByIndex(IntPtr handle, ref CopyPlayerAchievementByIndexOptionsInternal options, ref IntPtr outAchievement);

		[DllImport(Config.BinaryName)]
		private static extern uint EOS_Achievements_GetPlayerAchievementCount(IntPtr handle, ref GetPlayerAchievementCountOptionsInternal options);

		[DllImport(Config.BinaryName)]
		private static extern void EOS_Achievements_QueryPlayerAchievements(IntPtr handle, ref QueryPlayerAchievementsOptionsInternal options, IntPtr clientData, OnQueryPlayerAchievementsCompleteCallbackInternal completionDelegate);

		[DllImport(Config.BinaryName)]
		private static extern Result EOS_Achievements_CopyAchievementDefinitionV2ByAchievementId(IntPtr handle, ref CopyAchievementDefinitionV2ByAchievementIdOptionsInternal options, ref IntPtr outDefinition);

		[DllImport(Config.BinaryName)]
		private static extern Result EOS_Achievements_CopyAchievementDefinitionV2ByIndex(IntPtr handle, ref CopyAchievementDefinitionV2ByIndexOptionsInternal options, ref IntPtr outDefinition);

		[DllImport(Config.BinaryName)]
		private static extern uint EOS_Achievements_GetAchievementDefinitionCount(IntPtr handle, ref GetAchievementDefinitionCountOptionsInternal options);

		[DllImport(Config.BinaryName)]
		private static extern void EOS_Achievements_QueryDefinitions(IntPtr handle, ref QueryDefinitionsOptionsInternal options, IntPtr clientData, OnQueryDefinitionsCompleteCallbackInternal completionDelegate);
	}
}
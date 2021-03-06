﻿/*  Company :       Nequeo Pty Ltd, http://www.Nequeo.com.au/
 *  Copyright :     Copyright © Nequeo Pty Ltd 2008 http://www.nequeo.com.au/
 * 
 *  File :          
 *  Purpose :       
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Nequeo.IO.Audio.Api.Interfaces
{
    [Guid("F4B1A599-7266-4319-A8CA-E70ACB11E8CD"),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    interface IAudioSessionControl
    {
        /// <summary>
        /// Retrieves the current state of the audio session.
        /// </summary>
        /// <param name="state">Receives the current session state.</param>
        /// <returns>An HRESULT code indicating whether the operation succeeded of failed.</returns>
        [PreserveSig]
        int GetState(
            [Out] out AudioSessionState state);

        /// <summary>
        /// Retrieves the display name for the audio session.
        /// </summary>
        /// <param name="displayName">Receives a string that contains the display name.</param>
        /// <returns>An HRESULT code indicating whether the operation succeeded of failed.</returns>
        [PreserveSig]
        int GetDisplayName(
            [Out] [MarshalAs(UnmanagedType.LPWStr)] out string displayName);

        /// <summary>
        /// Assigns a display name to the current audio session.
        /// </summary>
        /// <param name="displayName">A string that contains the new display name for the session.</param>
        /// <param name="eventContext">A user context value that is passed to the notification callback.</param>
        /// <returns>An HRESULT code indicating whether the operation succeeded of failed.</returns>
        [PreserveSig]
        int SetDisplayName(
            [In] [MarshalAs(UnmanagedType.LPWStr)] string displayName,
            [In] [MarshalAs(UnmanagedType.LPStruct)] Guid eventContext);

        /// <summary>
        /// Retrieves the path for the display icon for the audio session.
        /// </summary>
        /// <param name="iconPath">Receives a string that specifies the fully qualified path of the file that contains the icon.</param>
        /// <returns>An HRESULT code indicating whether the operation succeeded of failed.</returns>
        [PreserveSig]
        int GetIconPath(
            [Out] [MarshalAs(UnmanagedType.LPWStr)] out string iconPath);

        /// <summary>
        /// Assigns a display icon to the current session.
        /// </summary>
        /// <param name="iconPath">A string that specifies the fully qualified path of the file that contains the new icon.</param>
        /// <param name="eventContext">A user context value that is passed to the notification callback.</param>
        /// <returns>An HRESULT code indicating whether the operation succeeded of failed.</returns>
        [PreserveSig]
        int SetIconPath(
            [In] [MarshalAs(UnmanagedType.LPWStr)] string iconPath,
            [In] [MarshalAs(UnmanagedType.LPStruct)] Guid eventContext);

        /// <summary>
        /// Retrieves the grouping parameter of the audio session.
        /// </summary>
        /// <param name="groupingId">Receives the grouping parameter ID.</param>
        /// <returns>An HRESULT code indicating whether the operation succeeded of failed.</returns>
        [PreserveSig]
        int GetGroupingParam(
            [Out] out Guid groupingId);

        /// <summary>
        /// Assigns a session to a grouping of sessions.
        /// </summary>
        /// <param name="groupingId">The new grouping parameter ID.</param>
        /// <param name="eventContext">A user context value that is passed to the notification callback.</param>
        /// <returns>An HRESULT code indicating whether the operation succeeded of failed.</returns>
        [PreserveSig]
        int SetGroupingParam(
            [In] [MarshalAs(UnmanagedType.LPStruct)] Guid groupingId,
            [In] [MarshalAs(UnmanagedType.LPStruct)] Guid eventContext);

        /// <summary>
        /// Registers the client to receive notifications of session events, including changes in the session state.
        /// </summary>
        /// <param name="client">A client-implemented <see cref="IAudioSessionEvents"/> interface.</param>
        /// <returns>An HRESULT code indicating whether the operation succeeded of failed.</returns>
        [PreserveSig]
        int RegisterAudioSessionNotification(
            [In] IAudioSessionEvents client);

        /// <summary>
        /// Deletes a previous registration by the client to receive notifications.
        /// </summary>
        /// <param name="client">A client-implemented <see cref="IAudioSessionEvents"/> interface.</param>
        /// <returns>An HRESULT code indicating whether the operation succeeded of failed.</returns>
        [PreserveSig]
        int UnregisterAudioSessionNotification(
            [In] IAudioSessionEvents client);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Notifications.Android;
using UnityEngine;

public class Notification : MonoBehaviour
{
    private const string ChannelId = "Channelid";
    public void ScheduleNotification(DateTime date)
    {
        AndroidNotificationChannel notificationChannel = new AndroidNotificationChannel()
        {
            Id = ChannelId,
            Description = "Energy Recharged Message!",
            Name = "Notification Channel",
            Importance = Importance.Default
        };
        AndroidNotificationCenter.RegisterNotificationChannel(notificationChannel);

        AndroidNotification notification = new AndroidNotification()
        {
            FireTime = date,
            LargeIcon = "default",
            SmallIcon = "default",
            Text = "Your Energy is fully Recovered. Come back to Continue where you left off!",
            Title = "Energy Recovered!"
        };
        AndroidNotificationCenter.SendNotification(notification, ChannelId);
    }
}

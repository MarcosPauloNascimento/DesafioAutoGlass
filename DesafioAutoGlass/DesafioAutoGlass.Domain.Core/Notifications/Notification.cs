﻿namespace DesafioAutoGlass.Domain.Core.Notifications
{
    public class Notification
    {
        public Notification(string mensage)
        {
            Mensage = mensage;
        }

        public string Mensage { get; }
    }
}
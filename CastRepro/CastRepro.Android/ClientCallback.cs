using Android.App;
using Android.Content;
using Android.Gms.Cast;
using Android.Gms.Cast.Framework.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CastRepro.Droid
{
    class ClientCallback : RemoteMediaClient.Callback
    {
        private readonly RemoteMediaClient client;

        public ClientCallback(RemoteMediaClient client)
        {
            this.client = client;
        }
        public override void OnStatusUpdated()
        {
            bool playing;
            var status = client.MediaStatus;

            if (status != null)
            {
                int idleStatus = status.IdleReason;
                int playerStatus = status.PlayerState;

                switch (playerStatus)
                {
                    
                }
            }
        }
    }

}
using Android.Content;
using Android.Gms.Cast;
using Android.Gms.Cast.Framework;
using Android.Gms.Cast.Framework.Media;
using Android.Runtime;
using System.Collections.Generic;

namespace CastRepro.Droid
{
    [Android.Runtime.Preserve(AllMembers = true)]
    [Register("castrepro.droid.castoptionsprovider")]
    public class CastOptionsProvider : Java.Lang.Object, IOptionsProvider
    {
        public IList<SessionProvider> GetAdditionalSessionProviders(Context appContext)
        {
            return null;
        }

        public CastOptions GetCastOptions(Context appContext)
        {
            NotificationOptions notificationOptions = new NotificationOptions.Builder()
                .SetTargetActivityClassName(typeof(MainActivity).FullName)
                .Build();

            CastMediaOptions mediaOptions = new CastMediaOptions.Builder()
                .SetNotificationOptions(notificationOptions)
                .Build();

            return new CastOptions.Builder()
                .SetReceiverApplicationId(CastMediaControlIntent.DefaultMediaReceiverApplicationId)
                .SetCastMediaOptions(mediaOptions)
                .Build();
        }
    }
}
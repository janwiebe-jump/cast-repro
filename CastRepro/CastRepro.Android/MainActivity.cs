using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using MediaManager;
using Android.Gms.Cast.Framework;
using AndroidX.MediaRouter.Media;
using Android.Gms.Cast;
using Android.Content;
using Plugin.CurrentActivity;
using Android.Gms.Cast.Framework.Media;

namespace CastRepro.Droid
{
    [Activity(Label = "CastRepro", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, ISessionManagerListener
    {
        private CastContext castContext;
        private MediaRouteSelectorCallback callback;
        private MediaRouteSelector mediaRouteSelector;
        private MediaRouter mediaRouter;
        private CastSession castSession;
        private RemoteMediaClient client;

        public MediaRouteSelector MediaRouteSelector => mediaRouteSelector;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            CrossMediaManager.Current.Init(this);
            CrossCurrentActivity.Current.Init(this, savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            InitCast();

            LoadApplication(new App());            
        }

        private void InitCast()
        {
            castContext = CastContext.GetSharedInstance(this.ApplicationContext);

            castContext.SessionManager.AddSessionManagerListener(this);

            //var prov = new MediaRouteActionProvider(Application.Context);

            callback = new MediaRouteSelectorCallback();

            mediaRouteSelector = new MediaRouteSelector.Builder()
                // These are the framework-supported intents
                //.AddControlCategory(MediaControlIntent.CategoryRemotePlayback)
                //.AddControlCategory(MediaControlIntent.cate)
                //.AddControlCategory(MediaControlIntent.CategoryLiveAudio)
                .AddControlCategory(CastMediaControlIntent.CategoryForCast(CastMediaControlIntent.DefaultMediaReceiverApplicationId))
                .Build();

            mediaRouter = MediaRouter.GetInstance(this.ApplicationContext);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public void OnSessionEnded(Java.Lang.Object session, int error)
        {
        }

        public void OnSessionEnding(Java.Lang.Object session)
        {
        }

        public void OnSessionResumeFailed(Java.Lang.Object session, int error)
        {
        }

        public void OnSessionResumed(Java.Lang.Object session, bool wasSuspended)
        {
        }

        public void OnSessionResuming(Java.Lang.Object session, string sessionId)
        {
        }

        public void OnSessionStartFailed(Java.Lang.Object session, int error)
        {
        }

        public void OnSessionStarted(Java.Lang.Object session, string sessionId)
        {
            castSession = session as CastSession;
            client = castSession.RemoteMediaClient;

            client.RegisterCallback(new ClientCallback(client));

            // Play the stuff!

            MediaLoadOptions.Builder builder = new MediaLoadOptions.Builder();
            builder.SetAutoplay(true);

            client.Load(buildMediaInfo(), builder.Build());
        }

        public MediaInfo buildMediaInfo()
        {
            MediaMetadata songData = new MediaMetadata(MediaMetadata.MediaTypeMusicTrack);
            songData.PutString(MediaMetadata.KeyTitle, "lol");



            MediaInfo.Builder builder = new MediaInfo.Builder("http://www.hochmuth.com/mp3/Haydn_Cello_Concerto_D-1.mp3");
            builder.SetStreamType(MediaInfo.StreamTypeBuffered);
            builder.SetContentType("audio/mp3");
            builder.SetMetadata(songData);

            return builder.Build();
        }

        public void OnSessionStarting(Java.Lang.Object session)
        {
        }

        public void OnSessionSuspended(Java.Lang.Object session, int reason)
        {
        }
    }
}
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.MediaRouter.App;
using CastRepro;
using CastRepro.Droid;
using Plugin.CurrentActivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms.Platform.Android;

[assembly: Xamarin.Forms.ExportRenderer(typeof(AudioOutputView), typeof(AudioOutputViewRenderer))]

namespace CastRepro.Droid
{
    class AudioOutputViewRenderer : ViewRenderer<AudioOutputView, View>
    {
        private MediaRouteButton button;

        public AudioOutputViewRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<AudioOutputView> e)
        {
            base.OnElementChanged(e);

            var activity = CrossCurrentActivity.Current.Activity as MainActivity;
            if (activity != null)
            {
                button = new MediaRouteButton(Context)
                {
                    RouteSelector = activity.MediaRouteSelector,
                };

                //button.SetAlwaysVisible(true);

                SetNativeControl(button);
            }
        }
    }
}
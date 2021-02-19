using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.MediaRouter.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CastRepro.Droid
{
    class MediaRouteSelectorCallback : AndroidX.MediaRouter.Media.MediaRouter.Callback
    {

        public override void OnRouteSelected(MediaRouter router, MediaRouter.RouteInfo route)
        {
            base.OnRouteSelected(router, route);
        }

        public override void OnRouteUnselected(MediaRouter router, MediaRouter.RouteInfo route)
        {
            base.OnRouteUnselected(router, route);
        }

        public override void OnRouteUnselected(MediaRouter router, MediaRouter.RouteInfo route, int reason)
        {
            base.OnRouteUnselected(router, route, reason);
        }

        public override void OnRouteAdded(MediaRouter router, MediaRouter.RouteInfo route)
        {
            base.OnRouteAdded(router, route);
        }

        public override void OnRouteChanged(MediaRouter router, MediaRouter.RouteInfo route)
        {
            base.OnRouteChanged(router, route);
        }
    }
}
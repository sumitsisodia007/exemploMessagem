using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;
using exemploMessagem.models;

namespace exemploMessagem.Droid
{
    [Activity(Label = "exemploMessagem", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());

            MessagingCenter.Subscribe<Mensagem>(this, "mensagem", mensagem => {
                EnviarMensagem(mensagem.Descricao);
            });
        }

        public void EnviarMensagem(string mensagem)
        {
            Toast.MakeText(this.ApplicationContext, mensagem, ToastLength.Long).Show();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            MessagingCenter.Unsubscribe<Mensagem>(this, "mensagem");
        }
    }
}


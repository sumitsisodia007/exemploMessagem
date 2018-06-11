using exemploMessagem.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace exemploMessagem
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Master : ContentPage
	{
        ObservableCollection<string> itens = new ObservableCollection<string>();

		public Master ()
		{
			InitializeComponent ();


            itens.Add("Item 1");
            itens.Add("Item 2");
            listView.ItemsSource = itens;

            MessagingCenter.Subscribe<Mensagem>(this, "mensagem", registroItem => {
                itens.Add(registroItem.Descricao);
            });

        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Mensagem>(this, "mensagem");
        }
    }
}
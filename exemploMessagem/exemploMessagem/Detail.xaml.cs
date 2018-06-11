using exemploMessagem.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace exemploMessagem
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Detail : ContentPage
	{
		public Detail ()
		{
			InitializeComponent ();

            button.Clicked += Button_Clicked;
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(new Mensagem() { Descricao = entry.Text }, "mensagem");
        }
    }
}